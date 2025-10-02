--PROCEDIMIENTO ALMACENADO PERIODO 2025

CREATE OR ALTER PROCEDURE sp_Periodo_CRUD
    @Accion NVARCHAR(20),
    @cod_periodo INT = NULL,
    @tipo NVARCHAR(20) = NULL,
    @nombre NVARCHAR(50) = NULL,
    @fechaini DATE = NULL,
    @fechafin DATE = NULL,
    @cod_gestion INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT * 
        FROM Periodo
        WHERE (@cod_gestion IS NULL OR cod_gestion = @cod_gestion)
        ORDER BY fechaini;
    END

    ELSE IF @Accion = 'AGREGAR'
    BEGIN
        -- Validar solapamiento de fechas dentro de la misma gestión
        IF EXISTS (
            SELECT 1 
            FROM Periodo
            WHERE cod_gestion = @cod_gestion
              AND (
                   (@fechaini BETWEEN fechaini AND fechafin)
                   OR (@fechafin BETWEEN fechaini AND fechafin)
                   OR (fechaini BETWEEN @fechaini AND @fechafin)
                  )
        )
        BEGIN
            RAISERROR('El periodo se solapa con otro existente en la misma gestión.', 16, 1);
            RETURN;
        END

        INSERT INTO Periodo (tipo, nombre, fechaini, fechafin, cod_gestion)
        VALUES (@tipo, @nombre, @fechaini, @fechafin, @cod_gestion);
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        -- Validar solapamiento de fechas (excluyendo el periodo actual)
        IF EXISTS (
            SELECT 1 
            FROM Periodo
            WHERE cod_gestion = @cod_gestion
              AND cod_periodo <> @cod_periodo
              AND (
                   (@fechaini BETWEEN fechaini AND fechafin)
                   OR (@fechafin BETWEEN fechaini AND fechafin)
                   OR (fechaini BETWEEN @fechaini AND @fechafin)
                  )
        )
        BEGIN
            RAISERROR('El periodo se solapa con otro existente en la misma gestión.', 16, 1);
            RETURN;
        END

        UPDATE Periodo
        SET tipo = @tipo,
            nombre = @nombre,
            fechaini = @fechaini,
            fechafin = @fechafin
        WHERE cod_periodo = @cod_periodo;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Periodo WHERE cod_periodo = @cod_periodo;
    END

    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT * 
        FROM Periodo 
        WHERE cod_periodo = @cod_periodo;
    END
END;
