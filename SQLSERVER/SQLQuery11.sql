--PROCEDIMIENTOS PARA HORARIOS
--HORARIO DOCENTE
CREATE OR ALTER PROCEDURE sp_Asignacion_CRUD
    @Accion NVARCHAR(20),
    @codasignacion INT = NULL,
    @dia VARCHAR(10) = NULL,
    @horainicio TIME = NULL,
    @horafin TIME = NULL,
    @idmateriaf INT = NULL,
    @idcursof INT = NULL,
    @iddocentef INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- INSERTAR
    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO Asignacion (dia, horainicio, horafin, idmateriaf, idcursof, iddocentef)
        VALUES (@dia, @horainicio, @horafin, @idmateriaf, @idcursof, @iddocentef);

        SELECT SCOPE_IDENTITY() AS NuevoId;
    END

    -- MODIFICAR
    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE Asignacion
        SET dia = @dia,
            horainicio = @horainicio,
            horafin = @horafin,
            idmateriaf = @idmateriaf,
            idcursof = @idcursof,
            iddocentef = @iddocentef
        WHERE codasignacion = @codasignacion;
    END

    -- ELIMINAR
    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Asignacion WHERE codasignacion = @codasignacion;
    END

    -- MOSTRAR TODO
    ELSE IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT 
            a.codasignacion,
            a.dia,
            a.horainicio,
            a.horafin,
            m.nommateria,
            c.nomcurso,
            d.iddocente,
            p.nomplantel + ' ' + p.applantel + ' ' + p.amplantel AS NombreCompleto
        FROM Asignacion a
        INNER JOIN Materia m ON a.idmateriaf = m.codmateria
        INNER JOIN Curso c ON a.idcursof = c.codcurso
        INNER JOIN Docente d ON a.iddocentef = d.iddocente
        INNER JOIN Plantel p ON d.idplantelf = p.codplantel;
    END

    -- BUSCAR POR ID
    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT * FROM Asignacion WHERE codasignacion = @codasignacion;
    END
END
GO


--HORARIO ADMINISTRATIVO

