--PROCEDIMIENTO ALMACENADO GESTION

CREATE OR ALTER PROCEDURE sp_Gestion_CRUD
    @Accion NVARCHAR(20),
    @cod_gestion INT = NULL,
    @nom_gestion NVARCHAR(50) = NULL,
    @fechaini_gestion DATE = NULL,
    @fechafin_gestion DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT cod_gestion, nom_gestion, fechaini_gestion, fechafin_gestion
        FROM Gestion
        ORDER BY fechaini_gestion DESC;
    END

    ELSE IF @Accion = 'AGREGAR'
    BEGIN
        -- Validar solapamiento
        IF EXISTS (SELECT 1 FROM Gestion 
                   WHERE (@fechaini_gestion BETWEEN fechaini_gestion AND fechafin_gestion) 
                      OR (@fechafin_gestion BETWEEN fechaini_gestion AND fechafin_gestion))
        BEGIN
            RAISERROR('Ya existe una gestión en el rango de fechas.', 16, 1);
            RETURN;
        END

        INSERT INTO Gestion (nom_gestion, fechaini_gestion, fechafin_gestion)
        VALUES (@nom_gestion, @fechaini_gestion, @fechafin_gestion);

        -- ?? Aquí devuelve el ID generado
        SELECT CAST(SCOPE_IDENTITY() AS INT) AS cod_gestion;

    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE Gestion
        SET nom_gestion = @nom_gestion,
            fechaini_gestion = @fechaini_gestion,
            fechafin_gestion = @fechafin_gestion
        WHERE cod_gestion = @cod_gestion;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Gestion WHERE cod_gestion = @cod_gestion;
    END

    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT * FROM Gestion WHERE cod_gestion = @cod_gestion;
    END
END;


select *from Gestion

DELETE FROM Gestion;
