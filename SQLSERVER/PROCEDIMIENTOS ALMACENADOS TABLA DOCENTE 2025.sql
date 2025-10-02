---------------------------------------
--CONSULTAR PARA DOCENTE

SELECT *FROM PLANTEL
SELECT *FROM DOCENTE
SELECT *FROM ADMINISTRATIVO

-- Secuencia para Docentes
CREATE SEQUENCE Seq_Docente
    AS INT
    START WITH 1
    INCREMENT BY 1;

SELECT TOP 1 * FROM Docente
sp_help Docente


SELECT TOP 5 * FROM Docente ORDER BY iddocente DESC;
SELECT MAX(iddocente) AS UltimoId FROM Docente;
-------------------------------------------------------------------------
-- Procedimiento CRUD para Docente

DROP PROCEDURE sp_Docente_CRUD
CREATE OR ALTER PROCEDURE sp_Docente_CRUD
    @Accion NVARCHAR(20),
    @iddocente INT = NULL OUTPUT,
    @idplantelf INT = NULL,
    @horaplanilla VARCHAR(10) = NULL,
    @cargahorariadocente VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        PRINT 'Valor recibido en @idplantelf = ' + CAST(@idplantelf AS VARCHAR(10));

        IF NOT EXISTS (SELECT 1 FROM Plantel WHERE codplantel = @idplantelf)
        BEGIN
            RAISERROR('El Plantel con codplantel = %d no existe. Inserte Plantel primero.', 16, 1, @idplantelf);
            RETURN;
        END

        DECLARE @Inserted TABLE (
            iddocente INT,
            cplant VARCHAR(50)
        );

        INSERT INTO Docente (idplantelf, horaplanilla, cargahorariadocente)
        OUTPUT inserted.iddocente, inserted.cplant INTO @Inserted
        VALUES (@idplantelf, @horaplanilla, @cargahorariadocente);

        SELECT @iddocente = iddocente FROM @Inserted;

        SELECT iddocente AS NuevoIdDocente, cplant AS NuevoCplant
        FROM @Inserted;
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE Docente
        SET idplantelf = @idplantelf,
            horaplanilla = @horaplanilla,
            cargahorariadocente = @cargahorariadocente
        WHERE iddocente = @iddocente;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Docente
        WHERE iddocente = @iddocente;
    END

    ELSE IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT 
            d.iddocente,
            RTRIM(d.cplant) AS cplant,
            RTRIM(d.horaplanilla) AS horaplanilla,
            RTRIM(d.cargahorariadocente) AS cargahorariodocente,
            RTRIM(p.nomplantel) AS nomplantel,
            RTRIM(p.applantel) AS applantel,
            RTRIM(p.amplantel) AS amplantel,
            RTRIM(p.ciplantel) AS ciplantel
        FROM Docente d
        INNER JOIN Plantel p ON d.idplantelf = p.codplantel;
    END

    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT 
            d.iddocente,
            d.idplantelf,
            RTRIM(d.cplant) AS cplant,
            RTRIM(d.horaplanilla) AS horaplanilla,
            RTRIM(d.cargahorariadocente) AS cargahorariadocente,
            p.codplantel,
            RTRIM(p.nomplantel) AS nomplantel,
            RTRIM(p.applantel) AS applantel,
            RTRIM(p.amplantel) AS amplantel,
            RTRIM(p.generoplantel) AS generoplantel,
            RTRIM(p.ciplantel) AS ciplantel,
            RTRIM(p.extplantel) AS extplantel,
            RTRIM(p.telfplantel) AS telfplantel,
            p.fechanacplantel,
            RTRIM(p.direccionplantel) AS direccionplantel,
            RTRIM(p.especialidadplantel) AS especialidadplantel,
            RTRIM(p.itemplantel) AS itemplantel,
            RTRIM(p.rdaplantel) AS rdaplantel,
            RTRIM(p.estadoplantel) AS estadoplantel
        FROM Docente d
        INNER JOIN Plantel p ON d.idplantelf = p.codplantel
        WHERE d.iddocente = @iddocente;
    END
END
GO



-------------------------------------------------------------------
--AGREGAR DATOS A DOCENTE

-- Docente 1
EXEC sp_Docente_CRUD
    @Accion = 'AGREGAR',
    @idplantelf = 1,
    @horaplanilla = 120,
    @cargahorariadocente = 100;
           
-- Docente 2
EXEC sp_Docente_CRUD
    @Accion = 'AGREGAR',
    @idplantelf = 2,
    @horaplanilla = 80,
    @cargahorariadocente = 70;

-- Docente 4
EXEC sp_Docente_CRUD
    @Accion = 'AGREGAR',
    @idplantelf = 4,
    @horaplanilla = 100,
    @cargahorariadocente = 90;
-- Docente 6
EXEC sp_Docente_CRUD
    @Accion = 'AGREGAR',
    @idplantelf = 6,
    @horaplanilla = 120,
    @cargahorariadocente = 90;



	EXEC sp_Docente_CRUD @Accion = 'MOSTRAR';
	
    -- Índices para FK
CREATE INDEX IX_Docente_idplantelf ON dbo.Docente(idplantelf);
CREATE INDEX IX_Administrativo_idplantelf ON dbo.Administrativo(idplantelf);
GO


---------------------------------------------------------------------------
--REINICIAR CODIGO PARA DOCENTE

SELECT CAST(CURRENT_VALUE FOR Seq_Docente AS INT) AS NuevoIdDocente;
SELECT NEXT VALUE FOR Seq_Docente AS NuevoIdDocente;
ALTER SEQUENCE Seq_Docente RESTART WITH 6;

---------------------------------------------------------------------------
--MOSTRAR LISTA DE DOCENTE+PLANTEL
CREATE OR ALTER PROCEDURE sp_Docente_Plantel_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        d.iddocente,
        d.cplant, 
        p.nomplantel, 
        p.applantel, 
        p.amplantel,
        p.especialidadplantel,
        p.itemplantel,
        p.rdaplantel,
        d.horaplanilla,
        d.cargahorariadocente
    FROM Docente d
    INNER JOIN Plantel p ON d.idplantelf = p.codplantel
    ORDER BY d.cplant;
END
GO


SELECT 
    CAST(current_value AS INT) AS ValorActual,
    CAST(current_value AS INT) + 1 AS SiguienteValor
FROM sys.sequences
WHERE name = 'Seq_Docente';


SELECT IDENT_CURRENT('Plantel') + 1 AS SiguienteCodPlantel;

--------------------------------------------------------------------
--REINICIAR CODIGO DE DOCENTE

DECLARE @UltimoIdDocente INT;
DECLARE @SQL NVARCHAR(200);

-- 1️ Obtener el último iddocente en la tabla
SELECT @UltimoIdDocente = ISNULL(MAX(iddocente), 0)
FROM Docente;

-- 2️ Preparar el comando para reiniciar la secuencia
SET @SQL = 'ALTER SEQUENCE Seq_Docente RESTART WITH ' + CAST(@UltimoIdDocente + 1 AS NVARCHAR(10));

-- 3️ Ejecutar el comando
EXEC sp_executesql @SQL;

-- 4️ Confirmar el valor actual
SELECT 
    CAST(current_value AS INT) AS ValorActual,
    CAST(current_value AS INT) + 1 AS SiguienteValor
FROM sys.sequences
WHERE name = 'Seq_Docente';



EXEC sp_Docente_CRUD @Accion='MOSTRAR';


EXEC sp_Docente_CRUD @Accion='BUSCAR', @iddocente=4;



--------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE sp_Docente_BuscarPorNombre
    @nombre NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        d.iddocente,
        RTRIM(p.applantel) + ' ' + RTRIM(p.amplantel) + ' ' + RTRIM(p.nomplantel) AS NombreCompleto
    FROM Docente d
    INNER JOIN Plantel p ON d.idplantelf = p.codplantel
    WHERE (RTRIM(p.applantel) + ' ' + RTRIM(p.amplantel) + ' ' + RTRIM(p.nomplantel)) LIKE '%' + @nombre + '%'
    ORDER BY p.applantel, p.amplantel, p.nomplantel;
END
GO
