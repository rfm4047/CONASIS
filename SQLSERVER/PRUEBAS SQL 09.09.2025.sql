---------------------------------------
--CONSULTAR PARA DOCENTE

SELECT TOP 1 * FROM Docente
sp_help Docente


SELECT TOP 5 * FROM Docente ORDER BY iddocente DESC;
SELECT MAX(iddocente) AS UltimoId FROM Docente;

SELECT *FROM PLANTEL
SELECT *FROM DOCENTE
SELECT *FROM ADMINISTRATIVO

-- Secuencia para Docentes
CREATE SEQUENCE Seq_Docente
    AS INT
    START WITH 1
    INCREMENT BY 1;

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
        INSERT INTO Docente (idplantelf, horaplanilla, cargahorariadocente)
        VALUES (@idplantelf, @horaplanilla, @cargahorariadocente);

         DECLARE @NuevoId INT = SCOPE_IDENTITY();

        SELECT 
        @NuevoId AS NuevoIdDocente,
        cplant   AS NuevoCplant
    FROM Docente
    WHERE iddocente = @NuevoId;
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
        DELETE FROM Docente WHERE iddocente = @iddocente;
    END

    ELSE IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT d.iddocente, d.cplant, d.horaplanilla, d.cargahorariadocente,
               p.nomplantel, p.applantel, p.amplantel, p.ciplantel
        FROM Docente d
        INNER JOIN Plantel p ON d.idplantelf = p.codplantel;
    END
END


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





ALTER TABLE Plantel
ALTER COLUMN applantel VARCHAR(30) NULL;

ALTER TABLE Plantel
ALTER COLUMN amplantel VARCHAR(30) NULL;

-- 1. Eliminar restricciones dependientes de las columnas CHAR
ALTER TABLE Plantel DROP CONSTRAINT ck_genero_plantel;
ALTER TABLE Plantel DROP CONSTRAINT u_ci_plantel;
ALTER TABLE Plantel DROP CONSTRAINT u_item_plantel;
ALTER TABLE Plantel DROP CONSTRAINT u_rda_plantel;
ALTER TABLE Plantel DROP CONSTRAINT ck_estado_plantel;
ALTER TABLE Plantel DROP CONSTRAINT DF__Plantel__estadop__656C112C; -- este nombre puede variar

-- 2. Modificar columnas CHAR -> VARCHAR
ALTER TABLE Plantel ALTER COLUMN nomplantel VARCHAR(30) NOT NULL;
ALTER TABLE Plantel ALTER COLUMN applantel VARCHAR(30) NULL;
ALTER TABLE Plantel ALTER COLUMN amplantel VARCHAR(30) NULL;
ALTER TABLE Plantel ALTER COLUMN generoplantel VARCHAR(9) NOT NULL;
ALTER TABLE Plantel ALTER COLUMN ciplantel VARCHAR(10) NOT NULL;
ALTER TABLE Plantel ALTER COLUMN extplantel VARCHAR(6) NOT NULL;
ALTER TABLE Plantel ALTER COLUMN telfplantel VARCHAR(15) NOT NULL;
ALTER TABLE Plantel ALTER COLUMN direccionplantel VARCHAR(50) NULL;
ALTER TABLE Plantel ALTER COLUMN especialidadplantel VARCHAR(25) NULL;
ALTER TABLE Plantel ALTER COLUMN itemplantel VARCHAR(5) NOT NULL;
ALTER TABLE Plantel ALTER COLUMN rdaplantel VARCHAR(7) NOT NULL;
ALTER TABLE Plantel ALTER COLUMN estadoplantel VARCHAR(8) NOT NULL;

-- 3. Volver a crear restricciones únicas
ALTER TABLE Plantel ADD CONSTRAINT u_ci_plantel UNIQUE (ciplantel);
ALTER TABLE Plantel ADD CONSTRAINT u_item_plantel UNIQUE (itemplantel);
ALTER TABLE Plantel ADD CONSTRAINT u_rda_plantel UNIQUE (rdaplantel);

-- 4. Volver a crear restricciones de CHECK
ALTER TABLE Plantel ADD CONSTRAINT ck_genero_plantel 
CHECK (generoplantel IN ('MASCULINO','FEMENINO'));

ALTER TABLE Plantel ADD CONSTRAINT ck_estado_plantel 
CHECK (estadoplantel IN ('ACTIVO','INACTIVO'));

-- 5. Volver a crear el valor por defecto
ALTER TABLE Plantel ADD CONSTRAINT DF_Plantel_Estado 
DEFAULT 'ACTIVO' FOR estadoplantel;

sp_help Plantel;
