--PROCEDIMIENTO ALMACENADO CARGO--

-- ==========================================
-- CRUD CARGO
-- Acciones: AGREGAR, EDITAR, ELIMINAR
-- ==========================================
CREATE OR ALTER PROCEDURE sp_Cargo_CRUD
    @Accion     NVARCHAR(20),
    @codcargo   INT = NULL OUTPUT,
    @nomcargo   VARCHAR(25) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO Cargo(nomcargo) VALUES(@nomcargo);
        SET @codcargo = SCOPE_IDENTITY();
    END
    ELSE IF @Accion = 'EDITAR'
    BEGIN
        UPDATE Cargo SET nomcargo = @nomcargo
        WHERE codcargo = @codcargo;
    END
    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Cargo WHERE codcargo = @codcargo;
    END
END;
GO

-- ==========================================
-- LISTAR CARGOS
-- ==========================================
CREATE OR ALTER PROCEDURE sp_Cargo_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT codcargo,
           ccar,        -- columna calculada CRGxx
           nomcargo
    FROM Cargo
    ORDER BY codcargo;
END;
GO

--------------------------------------------
--CAMBIAR CHAR A VARHAR EN NOMCARGO

ALTER TABLE Cargo
ALTER COLUMN nomcargo VARCHAR(30) NOT NULL;
