-- 1. Crear tabla de auditoría para eliminaciones
DROP TABLE log_eliminaciones
CREATE TABLE log_eliminaciones (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tabla VARCHAR(50) NOT NULL,
    id_registro INT NOT NULL,
    motivo TEXT NOT NULL,
    usuario VARCHAR(100) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    datos_eliminados TEXT,
    ip_usuario VARCHAR(50) DEFAULT NULL
);

-- 2. Procedimiento para eliminar administrativo con auditoría
DROP PROCEDURE sp_Eliminar_Administrativo_Con_Auditoria

CREATE OR ALTER PROCEDURE sp_Eliminar_Administrativo_Con_Auditoria
    @idadm INT,
    @motivo VARCHAR(500),
    @usuario VARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        -- 1. Validar que no tenga asistencias (cuando implementes esa tabla)
        -- IF EXISTS (SELECT 1 FROM asistencias WHERE idadm = @idadm)
        -- BEGIN
        --     RAISERROR('El administrativo tiene registros de asistencia. No se puede eliminar.', 16, 1);
        --     RETURN;
        -- END

        -- 2. Registrar en log ANTES de eliminar
        INSERT INTO log_eliminaciones (tabla, id_registro, motivo, usuario, fecha, datos_eliminados)
        SELECT 'administrativo_eliminado', @idadm, @motivo, @usuario, GETDATE(),
               CONCAT('ID: ', a.idadm, 
                     ' - Código: ', a.cplant,
                     ' - Nombre: ', p.nomplantel, ' ', ISNULL(p.applantel, ''), ' ', ISNULL(p.amplantel, ''),
                     ' - Cargo: ', a.cargoadm,
                     ' - Item: ', p.itemplantel,
                     ' - CI: ', p.ciplantel)
        FROM Administrativo a 
        INNER JOIN Plantel p ON a.idplantelf = p.codplantel
        WHERE a.idadm = @idadm;

        -- 3. Eliminar el administrativo
        DELETE FROM Administrativo WHERE idadm = @idadm;

        -- 4. Eliminar el plantel solo si no tiene otras referencias
        DELETE FROM Plantel 
        WHERE codplantel NOT IN (
            SELECT DISTINCT idplantelf FROM Docente
            UNION
            SELECT DISTINCT idplantelf FROM Administrativo
        );

        COMMIT TRANSACTION
        
        SELECT 'Eliminación exitosa' AS Resultado;
        
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO

-- 3. Función para validar si se puede eliminar
DROP FUNCTION fn_Puede_Eliminar_Administrativo
CREATE OR ALTER FUNCTION fn_Puede_Eliminar_Administrativo(@idadm INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        CASE 
            WHEN NOT EXISTS (SELECT 1 FROM Administrativo WHERE idadm = @idadm) THEN 0
            -- Agregar más validaciones según necesites
            -- WHEN EXISTS (SELECT 1 FROM asistencias WHERE idadm = @idadm) THEN 0
            ELSE 1 
        END AS PuedeEliminar,
        
        CASE 
            WHEN NOT EXISTS (SELECT 1 FROM Administrativo WHERE idadm = @idadm) THEN 'El administrativo no existe'
            -- WHEN EXISTS (SELECT 1 FROM asistencias WHERE idadm = @idadm) THEN 'Tiene registros de asistencia'
            ELSE 'Puede ser eliminado' 
        END AS Motivo
);

-- 4. Vista para consultar eliminaciones recientes
DROP view  vw_Eliminaciones_Recientes AS
SELECT TOP 100
CREATE OR ALTER VIEW vw_Eliminaciones_Recientes AS
SELECT TOP 100
    le.id,
    le.tabla,
    le.id_registro,
    le.motivo,
    le.usuario,
    le.fecha,
    le.datos_eliminados
FROM log_eliminaciones le
ORDER BY le.fecha DESC;


---------------------------------------------------------------
--mas sencillo--

-- Procedimiento para verificar si el plantel tiene asistencias registradas
CREATE OR  ALTER PROCEDURE PA_VERIFICAR_ASISTENCIAS_PLANTEL
    @codplantel INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @total_asistencias_docente INT = 0;
    DECLARE @total_asistencias_admin INT = 0;
    DECLARE @total_asistencias INT = 0;
    
    -- Contar asistencias de docentes relacionados con este plantel
    SELECT @total_asistencias_docente = ISNULL(COUNT(*), 0)
    FROM ASISTENCIA A 
    INNER JOIN DOCENTE D ON A.iddocente = D.iddocente 
    WHERE D.idplantelf = @codplantel;
    
    -- Contar asistencias de administrativos relacionados con este plantel
    SELECT @total_asistencias_admin = ISNULL(COUNT(*), 0)
    FROM ASISTENCIA A 
    INNER JOIN ADMINISTRATIVO AD ON A.idadm = AD.idadm
    WHERE AD.idplantelf = @codplantel;
    
    -- Total de asistencias
    SET @total_asistencias = @total_asistencias_docente + @total_asistencias_admin;
    
    SELECT 
        @total_asistencias AS total_asistencias,
        @total_asistencias_docente AS asistencias_docente,
        @total_asistencias_admin AS asistencias_administrativo;
END

-- Procedimiento para eliminar físicamente el plantel y sus dependencias
CREATE OR ALTER PROCEDURE PA_ELIMINAR_PLANTEL
    @codplantel INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Verificar nuevamente que no tenga asistencias antes de eliminar
        DECLARE @total_asistencias_docente INT = 0;
        DECLARE @total_asistencias_admin INT = 0;
        DECLARE @total_asistencias INT = 0;
        
        SELECT @total_asistencias_docente = ISNULL(COUNT(*), 0)
        FROM ASISTENCIA A 
        INNER JOIN DOCENTE D ON A.iddocente = D.iddocente 
        WHERE D.idplantelf = @codplantel;
        
        SELECT @total_asistencias_admin = ISNULL(COUNT(*), 0)
        FROM ASISTENCIA A 
        INNER JOIN ADMINISTRATIVO AD ON A.idadm = AD.idadm 
        WHERE AD.idplantelf = @codplantel;
        
        SET @total_asistencias = @total_asistencias_docente + @total_asistencias_admin;
        
        IF @total_asistencias > 0
        BEGIN
            RAISERROR('No se puede eliminar: el plantel tiene %d asistencias registradas (%d docentes, %d administrativos)', 
                     16, 1, @total_asistencias, @total_asistencias_docente, @total_asistencias_admin);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Verificar que el plantel existe
        IF NOT EXISTS (SELECT 1 FROM PLANTEL WHERE codplantel = @codplantel)
        BEGIN
            RAISERROR('El plantel especificado no existe', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Eliminar en orden jerárquico (hijos primero, padre después)
        -- 1. Eliminar registros de DOCENTE relacionados
        DELETE FROM DOCENTE WHERE idplantelf = @codplantel;
        
        -- 2. Eliminar registros de ADMINISTRATIVO relacionados  
        DELETE FROM ADMINISTRATIVO WHERE idplantelf = @codplantel;
        
        -- 3. Finalmente eliminar el PLANTEL (tabla padre)
        DELETE FROM PLANTEL WHERE codplantel = @codplantel;
        
        -- Confirmar transacción
        COMMIT TRANSACTION;
        
        -- Retornar información de lo que se eliminó
        SELECT 
            'Eliminación exitosa' AS resultado,
            @@ROWCOUNT AS filas_afectadas_plantel;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END

-- Procedimiento para cambiar estado del plantel
CREATE OR ALTER PROCEDURE PA_CAMBIAR_ESTADO_PLANTEL
    @codplantel INT,
    @estadoplantel VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Verificar que el plantel existe
    IF NOT EXISTS (SELECT 1 FROM PLANTEL WHERE codplantel = @codplantel)
    BEGIN
        RAISERROR('El plantel especificado no existe', 16, 1);
        RETURN;
    END
    
    -- Actualizar el estado
    UPDATE PLANTEL 
    SET estadoplantel = @estadoplantel,
        fechamodificacion = GETDATE()
    WHERE codplantel = @codplantel;
    
END

-- Procedimiento para obtener información completa del plantel y sus dependencias
CREATE PROCEDURE PA_OBTENER_INFO_PLANTEL
    @codplantel INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Información básica del plantel
    SELECT 
        P.codplantel,
        P.nomplantel,
        P.applantel,
        P.amplantel,
        P.ciplantel,
        P.estadoplantel,
        P.especialidadplantel,
        P.itemplantel,
        P.generoplantel,
        P.telfplantel,
        -- Contadores de dependencias
        (SELECT COUNT(*) FROM DOCENTE D WHERE D.idplantelf = P.codplantel) AS total_docentes,
        (SELECT COUNT(*) FROM ADMINISTRATIVO A WHERE A.idplantelf = P.codplantel) AS total_administrativos,
        -- Contadores de asistencias
        (SELECT COUNT(*) FROM ASISTENCIA AST 
         INNER JOIN DOCENTE D ON AST.iddocente = D.iddocente 
         WHERE D.idplantelf = P.codplantel) AS asistencias_docente,
        (SELECT COUNT(*) FROM ASISTENCIA AST 
         INNER JOIN ADMINISTRATIVO A ON AST.idadm = A.idadm
         WHERE A.idplantelf = P.codplantel) AS asistencias_administrativo
    FROM PLANTEL P 
    WHERE P.codplantel = @codplantel;
    
    -- Detalle de docentes asociados (opcional para mostrar en confirmación)
    SELECT 
        'DOCENTE' AS tipo,
        D.iddocente AS id,
        D.cargahorariadocente AS cargo_info,
        D.horaplanilla AS horas
    FROM DOCENTE D 
    WHERE D.idplantelf = @codplantel;
    
    -- Detalle de administrativos asociados (opcional para mostrar en confirmación)
    SELECT 
        'ADMINISTRATIVO' AS tipo,
        A.idadm AS id,
        A.cargoadm AS cargo_info
    FROM ADMINISTRATIVO A 
    WHERE A.idplantelf = @codplantel;
END


EXEC sp_helptext 'sp_Plantel_CRUD';


ALTER PROCEDURE PA_CAMBIAR_ESTADO_PLANTEL
    @codplantel INT,
    @estadoplantel VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Plantel WHERE codplantel = @codplantel)
    BEGIN
        RAISERROR('El plantel especificado no existe',16,1);
        RETURN;
    END;

    UPDATE Plantel
    SET estadoplantel = @estadoplantel,
        fechamodificacion = GETDATE()
    WHERE codplantel = @codplantel;
END;
GO

SELECT 'Tabla PLANTEL existe' AS Resultado
WHERE EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PLANTEL');

-- Paso 2: Ver TODAS las columnas de la tabla PLANTEL
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'PLANTEL'
ORDER BY ORDINAL_POSITION;


SELECT 
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'PLANTEL' AND COLUMN_NAME = 'fechamodificacion'
        ) 
        THEN 'La columna fechamodificacion SÍ existe' 
        ELSE 'La columna fechamodificacion NO existe'
    END AS Estado_Columna;


    ALTER TABLE PLANTEL 
ADD fechamodificacion DATETIME NULL DEFAULT GETDATE();

SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'PLANTEL' AND COLUMN_NAME = 'fechamodificacion';



CREATE PROCEDURE PA_CAMBIAR_ESTADO_PLANTEL
    @codplantel INT,
    @estadoplantel VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Verificar que el plantel existe
        IF NOT EXISTS (SELECT 1 FROM PLANTEL WHERE codplantel = @codplantel)
        BEGIN
            RAISERROR('El plantel especificado no existe', 16, 1);
            RETURN;
        END
        
        -- Actualizar el estado
        UPDATE PLANTEL 
        SET estadoplantel = @estadoplantel,
            fechamodificacion = GETDATE()
        WHERE codplantel = @codplantel;
        
        -- Confirmar la actualización
        IF @@ROWCOUNT > 0
        BEGIN
            PRINT 'Plantel actualizado correctamente';
            SELECT 'SUCCESS' AS Resultado, @@ROWCOUNT AS FilasAfectadas;
        END
        ELSE
        BEGIN
            RAISERROR('No se pudo actualizar el registro', 16, 1);
        END
        
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;