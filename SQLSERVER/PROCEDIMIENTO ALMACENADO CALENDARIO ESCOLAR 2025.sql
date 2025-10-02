--PROCEDIMIENTO ALMACENADO CALENDARIO ESCOLAR 2025

CREATE OR ALTER PROCEDURE sp_CalendarioEscolar_CRUD
    @Accion NVARCHAR(20),
    @idcalendario INT = NULL,
    @fecha DATE = NULL,
    @idtipodia INT = NULL,
    @motivo NVARCHAR(100) = NULL,
    @cod_gestion INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'MOSTRAR'
        SELECT c.*, t.nom_tipodia, g.nom_gestion
        FROM Calendario_Escolar c
        INNER JOIN TipoDia t ON c.idtipodia = t.idtipodia
        INNER JOIN Gestion g ON c.cod_gestion = g.cod_gestion;

    ELSE IF @Accion = 'AGREGAR'
        INSERT INTO Calendario_Escolar (fecha, idtipodia, motivo, cod_gestion)
        VALUES (@fecha, @idtipodia, @motivo, @cod_gestion);

    ELSE IF @Accion = 'MODIFICAR'
        UPDATE Calendario_Escolar
        SET fecha = @fecha,
            idtipodia = @idtipodia,
            motivo = @motivo
        WHERE idcalendario = @idcalendario;

    ELSE IF @Accion = 'ELIMINAR'
        DELETE FROM Calendario_Escolar WHERE idcalendario = @idcalendario;

    ELSE IF @Accion = 'BUSCAR'
        SELECT * FROM Calendario_Escolar WHERE idcalendario = @idcalendario;
END;


SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Calendario_Escolar';

SELECT * FROM Calendario_Escolar