--PROCEDIMIENTO ALMACENADO MOTIVO --



CREATE OR ALTER PROCEDURE sp_Motivo_CRUD
    @Accion     VARCHAR(20),
    @codmotivo  INT = NULL,
    @motivo     VARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO Motivo (motivo)
        VALUES (@motivo);

        DECLARE @NuevoID INT = SCOPE_IDENTITY();

        SELECT 
            codmotivo, 
            cmot, 
            motivo
        FROM Motivo
        WHERE codmotivo = @NuevoID;
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE Motivo
        SET motivo = @motivo
        WHERE codmotivo = @codmotivo;

        SELECT 
            codmotivo, 
            cmot, 
            motivo
        FROM Motivo
        WHERE codmotivo = @codmotivo;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Motivo
        WHERE codmotivo = @codmotivo;
    END

    ELSE IF @Accion = 'LISTAR'
    BEGIN
        SELECT codmotivo, cmot, motivo
        FROM Motivo
        ORDER BY codmotivo;
    END

    ELSE IF @Accion = 'OBTENER'
    BEGIN
        SELECT codmotivo, cmot, motivo
        FROM Motivo
        WHERE codmotivo = @codmotivo;
    END
END
GO







DROP TABLE IF EXISTS Motivo;
GO

CREATE TABLE Motivo
(
    codmotivo INT IDENTITY(1,1) NOT NULL 
        CONSTRAINT pk_motlicencia PRIMARY KEY,
    cmot AS ('ML' + RIGHT('00' + CONVERT(VARCHAR, codmotivo), 2)),
    motivo VARCHAR(30) NOT NULL
);
GO

EXEC sp_Motivo_CRUD @Accion = 'LISTAR';
