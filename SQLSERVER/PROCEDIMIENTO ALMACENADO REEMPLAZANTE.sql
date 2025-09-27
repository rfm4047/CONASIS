
--PROCEDIMIENTO ALMACENADO REEMPLAZANTE--

CREATE OR ALTER PROCEDURE sp_Reemplazante_CRUD
    @Accion           VARCHAR(20),
    @codreemplazante  INT = NULL,
    @nomreemp         VARCHAR(20) = NULL,
    @appaternoreemp   VARCHAR(40) = NULL,
    @apmaternoreemp   VARCHAR(40) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO Reemplazante (nomreemp, appaternoreemp, apmaternoreemp)
        VALUES (@nomreemp, @appaternoreemp, @apmaternoreemp);

        DECLARE @NuevoID INT = SCOPE_IDENTITY();

        SELECT codreemplazante, creemp, nomreemp, appaternoreemp, apmaternoreemp
        FROM Reemplazante
        WHERE codreemplazante = @NuevoID;
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE Reemplazante
        SET nomreemp = @nomreemp,
            appaternoreemp = @appaternoreemp,
            apmaternoreemp = @apmaternoreemp
        WHERE codreemplazante = @codreemplazante;

        SELECT codreemplazante, creemp, nomreemp, appaternoreemp, apmaternoreemp
        FROM Reemplazante
        WHERE codreemplazante = @codreemplazante;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Reemplazante
        WHERE codreemplazante = @codreemplazante;
    END

    ELSE IF @Accion = 'LISTAR'
    BEGIN
        SELECT codreemplazante, creemp, nomreemp, appaternoreemp, apmaternoreemp
        FROM Reemplazante
        ORDER BY codreemplazante;
    END

    ELSE IF @Accion = 'OBTENER'
    BEGIN
        SELECT codreemplazante, creemp, nomreemp, appaternoreemp, apmaternoreemp
        FROM Reemplazante
        WHERE codreemplazante = @codreemplazante;
    END
END
GO
