--PROCEDIMIENTO ALMACENADO ASISTENCIA 2025


CREATE OR ALTER PROCEDURE sp_Asistencia_CRUD
    @Accion NVARCHAR(20),
    @id_asistencia INT = NULL,
    @fecha DATE = NULL,
    @cod_gestion INT = NULL,
    @id_persona INT = NULL,
    @horaEntrada TIME = NULL,
    @horaSalida TIME = NULL,
    @observacion NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'MOSTRAR'
        SELECT * FROM Asistencia;

    ELSE IF @Accion = 'AGREGAR'
    BEGIN
        -- Validar que el día sea hábil
        IF EXISTS (
            SELECT 1 FROM Calendario_Escolar
            WHERE fecha = @fecha AND cod_gestion = @cod_gestion
              AND idtipodia = (SELECT idtipodia FROM TipoDia WHERE nom_tipodia = 'Hábil')
        )
        BEGIN
            INSERT INTO Asistencia (fecha, cod_gestion, id_persona, horaEntrada, horaSalida, observacion)
            VALUES (@fecha, @cod_gestion, @id_persona, @horaEntrada, @horaSalida, @observacion);
        END
        ELSE
        BEGIN
            RAISERROR('No se puede registrar asistencia en un día no hábil.', 16, 1);
        END
    END

    ELSE IF @Accion = 'MODIFICAR'
        UPDATE Asistencia
        SET fecha = @fecha,
            cod_gestion = @cod_gestion,
            id_persona = @id_persona,
            horaEntrada = @horaEntrada,
            horaSalida = @horaSalida,
            observacion = @observacion
        WHERE id_asistencia = @id_asistencia;

    ELSE IF @Accion = 'ELIMINAR'
        DELETE FROM Asistencia WHERE id_asistencia = @id_asistencia;

    ELSE IF @Accion = 'BUSCAR'
        SELECT * FROM Asistencia WHERE id_asistencia = @id_asistencia;
END;
