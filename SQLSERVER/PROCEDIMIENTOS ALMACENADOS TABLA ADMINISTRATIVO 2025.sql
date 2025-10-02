---------------------------------------
--CONSULTAR PARA ADMINISTRATIVO

SELECT *FROM PLANTEL
SELECT *FROM DOCENTE
SELECT *FROM Administrativo


-- Secuencia para Administrativos
CREATE SEQUENCE Seq_Administrativo
    AS INT
    START WITH 1
    INCREMENT BY 1;
--------------------------------------------------------
-- Procedimiento CRUD para Administrativo

   
CREATE OR ALTER PROCEDURE sp_Administrativo_CRUD
    @Accion NVARCHAR(20),
    @idadm INT = NULL OUTPUT,
    @idplantelf INT = NULL,
    @cargoadm VARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        PRINT 'Valor recibido en @idplantelf = ' + CAST(@idplantelf AS VARCHAR(10));

        -- Validar que exista el Plantel
        IF NOT EXISTS (SELECT 1 FROM Plantel WHERE codplantel = @idplantelf)
        BEGIN
            RAISERROR('El Plantel con codplantel = %d no existe. Inserte Plantel primero.', 16, 1, @idplantelf);
            RETURN;
        END

        -- Tabla temporal para capturar lo insertado
        DECLARE @Inserted TABLE (
            idadm INT,
            cplant VARCHAR(50)
        );

        -- INSERT con OUTPUT para capturar idadm y cplant
        INSERT INTO Administrativo (idplantelf, cargoadm)
        OUTPUT inserted.idadm, inserted.cplant INTO @Inserted
        VALUES (@idplantelf, @cargoadm);

        -- Pasar el id al parámetro de salida
        SELECT @idadm = idadm FROM @Inserted;

        -- Devolver id y cplant generado
        SELECT idadm AS NuevoIdAdm, cplant AS NuevoCplant FROM @Inserted;
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE Administrativo
        SET idplantelf = @idplantelf,
            cargoadm = @cargoadm
        WHERE idadm = @idadm;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Administrativo WHERE idadm = @idadm;
    END

    ELSE IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT 
            a.idadm,
            RTRIM(a.cplant) AS cplant,
            RTRIM(a.cargoadm) AS cargoadm,
            RTRIM(p.nomplantel) AS nomplantel,
            RTRIM(p.applantel) AS applantel,
            RTRIM(p.amplantel) AS amplantel,
            RTRIM(p.ciplantel) AS ciplantel
        FROM Administrativo a
        INNER JOIN Plantel p ON a.idplantelf = p.codplantel;
    END

    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT 
            a.idadm,
            a.idplantelf,
            RTRIM(a.cplant) AS cplant,
            RTRIM(a.cargoadm) AS cargoadm,
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
        FROM Administrativo a
        INNER JOIN Plantel p ON a.idplantelf = p.codplantel
        WHERE a.idadm = @idadm;
    END
END
GO


---------------------------------------------------------------
--MOSTRAR LISTA DE ADMINISTRATIVO+PLANTEL

CREATE OR ALTER PROCEDURE sp_Administrativo_Plantel_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        a.idadm,
        a.cplant, 
        p.nomplantel, 
        p.applantel, 
        p.amplantel,
        p.itemplantel,
        p.rdaplantel,
        a.cargoadm
    FROM Administrativo a
    INNER JOIN Plantel p ON a.idplantelf = p.codplantel
    ORDER BY a.cplant;
END
GO





-----------------------------------------
--AGREGAR DATOS A ADMINISTRATIVO

-- Agregar Director
EXEC sp_Administrativo_CRUD
    @Accion = 'AGREGAR',
    @idplantelf = 3,          -- Cambia al ID del plantel correspondiente
    @cargoadm = 'Director';

-- Agregar Secretario
EXEC sp_Administrativo_CRUD
    @Accion = 'AGREGAR',
    @idplantelf = 6,          -- Mismo plantel o diferente, según corresponda
    @cargoadm = 'Secretario';




    SELECT *
FROM Plantel
WHERE ciplantel = '456951';




SELECT 
    a.IdAdm, 
    p.CPlant, 
    p.NomPlantel, 
    p.ApPlantel, 
    ...
FROM Administrativo a
INNER JOIN Plantel p ON a.IdPlantelF = p.CodPlantel;


-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_Administrativo_BuscarPorNombre
    @nombre NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        a.idadm,
        RTRIM(p.applantel) + ' ' + RTRIM(p.amplantel) + ' ' + RTRIM(p.nomplantel) AS NombreCompleto
    FROM Administrativo a
    INNER JOIN Plantel p ON a.idplantelf = p.codplantel
    WHERE (RTRIM(p.applantel) + ' ' + RTRIM(p.amplantel) + ' ' + RTRIM(p.nomplantel)) LIKE '%' + @nombre + '%'
    ORDER BY p.applantel, p.amplantel, p.nomplantel;
END
GO
