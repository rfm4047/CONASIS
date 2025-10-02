--PROCEDIMIENTO ALMACENADO ACTIVIDAD 2025

CREATE OR ALTER PROCEDURE sp_Actividad_CRUD
    @Accion NVARCHAR(20),
    @cod_actividad INT = NULL,
    @nombre NVARCHAR(100) = NULL,
    @fechaini DATE = NULL,
    @fechafin DATE = NULL,
    @cod_periodo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'MOSTRAR'
        SELECT a.*, p.nombre AS NombrePeriodo
        FROM Actividad a
        INNER JOIN Periodo p ON a.cod_periodo = p.cod_periodo;

    ELSE IF @Accion = 'AGREGAR'
        INSERT INTO Actividad (nombre, fechaini, fechafin, cod_periodo)
        VALUES (@nombre, @fechaini, @fechafin, @cod_periodo);

    ELSE IF @Accion = 'MODIFICAR'
        UPDATE Actividad
        SET nombre = @nombre,
            fechaini = @fechaini,
            fechafin = @fechafin
        WHERE cod_actividad = @cod_actividad;

    ELSE IF @Accion = 'ELIMINAR'
        DELETE FROM Actividad WHERE cod_actividad = @cod_actividad;

    ELSE IF @Accion = 'BUSCAR'
        SELECT * FROM Actividad WHERE cod_actividad = @cod_actividad;
END;
