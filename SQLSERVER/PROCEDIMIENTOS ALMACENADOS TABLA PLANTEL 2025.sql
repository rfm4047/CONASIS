--PROCEDIMIENTO ALMACENADO CARGAR PLANTEL--

CREATE PROCEDURE CargarPlantel
AS
BEGIN
    SELECT 
        codplantel,
        nomplantel,
        applantel,
        amplantel,
        generoplantel,
        ciplantel,
        extplantel,
        telfplantel,
        fechanacplantel,
        direccionplantel,
        especialidadplantel,
        itemplantel,
        rdaplantel,
        estadoplantel
    FROM Plantel
    ORDER BY codplantel DESC;
END;
GO

----------------------------------------------------
SELECT *FROM PLANTEL


----------------------------------------------------


-- Inserción de datos aleatorios en la tabla Plantel

SET IDENTITY_INSERT Plantel ON;

INSERT INTO Plantel (
    codplantel, nomplantel, applantel, amplantel, ciplantel, extplantel,
    telfplantel, fechanacplantel, generoplantel, direccionplantel,
    rdaplantel, itemplantel, especialidadplantel
)
VALUES
(1, 'JUAN',    'PEREZ',    'LOPEZ',    '1234567', 'SCZ', '71234567', '1990-05-14', 'MASCULINO', 'AV. PRADO 123', 'RDA001', 'IT01', 'MATEMÁTICAS'),
(2, 'MARIA',   'GOMEZ',    'RAMOS',    '7654321', 'LPZ', '78945612', '1988-11-30', 'FEMENINO',  'CALLE 12 #45',  'RDA002', 'IT02', 'FÍSICA'),
(3, 'CARLOS',  'QUISPE',   'MAMANI',   '8765432', 'CBBA','76543210', '1995-01-22', 'MASCULINO', 'ZONA NORTE',    'RDA003', 'IT03', 'DIRECTORA'),
(4, 'LUISA',   'SUAREZ',   'CONDORI',  '6543210', 'ORU', '72123456', '1992-07-10', 'FEMENINO',  'AV. LAS FLORES','RDA004', 'IT04', 'QUÍMICA'),
(5, 'PEDRO',   'ROJAS',    'VARGAS',   '9988776', 'PND', '73456789', '1993-03-05', 'MASCULINO', 'BARRIO CENTRAL','RDA005', 'IT05', 'SECRETARIA'),
(6, 'MARCOS',    'ROCA',    'ROCA',    '22334456', 'SCZ', '71295147', '1990-05-05', 'MASCULINO', 'AV. PIRAI 13', 'RDA006', 'IT06', 'SOCIALES')

SET IDENTITY_INSERT Plantel OFF;


----------------------------------------------------------------------------------
--Procedimiento CRUD para Plantel

DROP PROCEDURE sp_Plantel_CRUD
GO
CREATE OR ALTER PROCEDURE sp_Plantel_CRUD
    @Accion NVARCHAR(20),
    @codplantel INT = NULL,
    @nomplantel CHAR(30) = NULL,
    @applantel CHAR(30) = NULL,
    @amplantel CHAR(30) = NULL,
    @generoplantel CHAR(9) = NULL,
    @ciplantel VARCHAR(10) = NULL,
    @extplantel CHAR(6) = NULL,
    @telfplantel CHAR(15) = NULL,
    @fechanacplantel DATE = NULL,
    @direccionplantel VARCHAR(50) = NULL,
    @especialidadplantel CHAR(25) = NULL,
    @itemplantel VARCHAR(5) = NULL,
    @rdaplantel VARCHAR(7) = NULL,
    @estadoplantel CHAR(8) = 'ACTIVO',
    @idplantel_reemplaza INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO Plantel (nomplantel, applantel, amplantel, generoplantel, ciplantel,
                             extplantel, telfplantel, fechanacplantel, direccionplantel,
                             especialidadplantel, itemplantel, rdaplantel, estadoplantel, idplantel_reemplaza)
        OUTPUT inserted.codplantel
        VALUES (@nomplantel, @applantel, @amplantel, @generoplantel, @ciplantel,
                @extplantel, @telfplantel, @fechanacplantel, @direccionplantel,
                @especialidadplantel, @itemplantel, @rdaplantel, @estadoplantel, @idplantel_reemplaza);
    END
    ELSE IF @Accion = 'MODIFICAR'
    BEGIN  
        UPDATE Plantel
        SET nomplantel = @nomplantel,
            applantel = @applantel,
            amplantel = @amplantel,
            generoplantel = @generoplantel,
            ciplantel = @ciplantel,
            extplantel = @extplantel,
            telfplantel = @telfplantel,
            fechanacplantel = @fechanacplantel,
            direccionplantel = @direccionplantel,
            especialidadplantel = @especialidadplantel,
            itemplantel = @itemplantel,
            rdaplantel = @rdaplantel,
            estadoplantel = @estadoplantel,
            idplantel_reemplaza = @idplantel_reemplaza
        WHERE codplantel = @codplantel;
    END
    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Plantel WHERE codplantel = @codplantel;
    END
    ELSE IF @Accion  = ('LISTAR''MOSTRAR')
    BEGIN
        SELECT * FROM Plantel;
    END
END
GO
----------------------------------------------------------------------



DECLARE @UltimoPlantel INT;
SELECT @UltimoPlantel = ISNULL(MAX(codplantel), 0) FROM Plantel;

DBCC CHECKIDENT ('Plantel', RESEED, @UltimoPlantel);


DECLARE @UltimoPlantel INT;
SELECT @UltimoPlantel = ISNULL(MAX(codplantel), 0) FROM Plantel;

PRINT 'Último Plantel: ' + CAST(@UltimoPlantel AS NVARCHAR(10));
PRINT 'El siguiente registro será: ' + CAST(@UltimoPlantel + 1 AS NVARCHAR(10));

DBCC CHECKIDENT ('Plantel', RESEED, @UltimoPlantel);


SET IDENTITY_INSERT Plantel ON;

-- ACTUALIZA las filas para que sus códigos sean consecutivos
UPDATE Plantel SET codplantel = 16 WHERE codplantel = 18;
UPDATE Plantel SET codplantel = 17 WHERE codplantel = 19;

SET IDENTITY_INSERT Plantel OFF;


ALTER TABLE Plantel
ADD fechamodificacion DATETIME NOT NULL 
    CONSTRAINT DF_Plantel_fechamodificacion DEFAULT(GETDATE());



    SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'PLANTEL' AND COLUMN_NAME = 'fechamodificacion';




CREATE OR ALTER PROCEDURE sp_ListarPlanteles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        codplantel,
        LTRIM(RTRIM(applantel)) + ' ' + 
        LTRIM(RTRIM(amplantel)) + ' ' + 
        LTRIM(RTRIM(nomplantel)) AS NombreCompleto
    FROM Plantel
    ORDER BY 
        LTRIM(RTRIM(applantel)),
        LTRIM(RTRIM(amplantel)),
        LTRIM(RTRIM(nomplantel));
END;


EXEC sp_ListarPlanteles;
