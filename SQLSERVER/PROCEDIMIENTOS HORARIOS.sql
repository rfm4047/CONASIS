--PROCEDIMIENTOS HORARIOS

--HORARIO ADMINISTRATIVO
CREATE OR ALTER PROCEDURE sp_HorarioAdministrativo_CRUD
    @Accion NVARCHAR(20),
    @idhorarioadm INT = NULL,
    @idadm INT = NULL,
    @diaSemana VARCHAR(15) = NULL,
    @horaEntrada TIME = NULL,
    @horaSalida TIME = NULL,
    @horaRecesoInicio TIME = NULL,
    @horaRecesoFin TIME = NULL,
    @toleranciaMinutos INT = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO HorarioAdministrativo (idadm, diaSemana, horaEntrada, horaSalida, horaRecesoInicio, horaRecesoFin, toleranciaMinutos)
        VALUES (@idadm, @diaSemana, @horaEntrada, @horaSalida, @horaRecesoInicio, @horaRecesoFin, @toleranciaMinutos);
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE HorarioAdministrativo
        SET idadm = @idadm,
            diaSemana = @diaSemana,
            horaEntrada = @horaEntrada,
            horaSalida = @horaSalida,
            horaRecesoInicio = @horaRecesoInicio,
            horaRecesoFin = @horaRecesoFin,
            toleranciaMinutos = @toleranciaMinutos
        WHERE idhorarioadm = @idhorarioadm;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM HorarioAdministrativo
        WHERE idhorarioadm = @idhorarioadm;
    END

    ELSE IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT 
            ha.idhorarioadm,
            ha.diaSemana,
            ha.horaEntrada,
            ha.horaSalida,
            ha.horaRecesoInicio,
            ha.horaRecesoFin,
            ha.toleranciaMinutos,
            a.idadm,
            a.cplant,
            a.cargoadm,
            p.nomplantel,
            p.applantel,
            p.amplantel
        FROM HorarioAdministrativo ha
        INNER JOIN Administrativo a ON ha.idadm = a.idadm
        INNER JOIN Plantel p ON a.idplantelf = p.codplantel;
    END

    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT 
            ha.idhorarioadm,
            ha.diaSemana,
            ha.horaEntrada,
            ha.horaSalida,
            ha.horaRecesoInicio,
            ha.horaRecesoFin,
            ha.toleranciaMinutos,
            a.idadm,
            a.cplant,
            a.cargoadm,
            p.nomplantel,
            p.applantel,
            p.amplantel
        FROM HorarioAdministrativo ha
        INNER JOIN Administrativo a ON ha.idadm = a.idadm
        INNER JOIN Plantel p ON a.idplantelf = p.codplantel
        WHERE ha.idhorarioadm = @idhorarioadm;
    END
END
GO




-- Insertar horario de lunes con receso
EXEC sp_HorarioAdministrativo_CRUD 
    @Accion = 'AGREGAR',
    @idadm = 1,
    @diaSemana = 'LUNES',
    @horaEntrada = '08:00',
    @horaSalida = '16:00',
    @horaRecesoInicio = '12:30',
    @horaRecesoFin = '13:00';

-- Mostrar todos los horarios
EXEC sp_HorarioAdministrativo_CRUD @Accion = 'MOSTRAR';

SELECT * FROM Plantel

ALTER TABLE HorarioAdministrativo
ADD toleranciaMinutos INT NOT NULL DEFAULT 0; -- minutos de tolerancia en la entrada


---------------------------------------
CREATE OR ALTER PROCEDURE sp_Horario_Listar
AS
BEGIN
    -- Administrativo (FIJO)
    SELECT 
        RTRIM(p.applantel) + ' ' + RTRIM(p.amplantel) + ' ' + RTRIM(p.nomplantel) AS NombreCompleto,
        'FIJO' AS TipoHorario,
        CAST(ROUND(
            (DATEDIFF(MINUTE, ha.horaEntrada, ha.horaSalida) 
             - ISNULL(DATEDIFF(MINUTE, ha.horaRecesoInicio, ha.horaRecesoFin), 0)) / 60.0, 2
        ) AS DECIMAL(5,2)) AS TiempoTotalHoras
    FROM HorarioAdministrativo ha
    INNER JOIN Administrativo a ON ha.idadm = a.idadm
    INNER JOIN Plantel p ON a.idplantelf = p.codplantel

    UNION ALL

    -- Docente (VARIABLE)
    SELECT 
        RTRIM(p.applantel) + ' ' + RTRIM(p.amplantel) + ' ' + RTRIM(p.nomplantel) AS NombreCompleto,
        'VARIABLE' AS TipoHorario,
        CAST(ROUND(DATEDIFF(MINUTE, hd.horaInicio, hd.horaFin) / 60.0, 2) AS DECIMAL(5,2)) AS TiempoTotalHoras
    FROM HorarioDocente hd
    INNER JOIN Docente d ON hd.iddocente = d.iddocente
    INNER JOIN Plantel p ON d.idplantelf = p.codplantel;
END
GO
---------------------------------------------------------
--HORARIO GENERAL PARA EL FORMHORARIO DATAGRIDVIEW
CREATE OR ALTER PROCEDURE sp_Horario_Listar
AS
BEGIN
    SET NOCOUNT ON;

    -- Horario Administrativo (FIJO)
    SELECT 
        RTRIM(p.applantel) + ' ' + RTRIM(p.amplantel) + ' ' + RTRIM(p.nomplantel) AS NombreCompleto,
        'FIJO' AS TipoHorario,
        CAST(ROUND(
            (DATEDIFF(MINUTE, ha.horaEntrada, ha.horaSalida) 
             - ISNULL(DATEDIFF(MINUTE, ha.horaRecesoInicio, ha.horaRecesoFin), 0)) / 60.0, 2
        ) AS DECIMAL(5,2)) AS TiempoTotalHoras
    FROM HorarioAdministrativo ha
    INNER JOIN Administrativo a ON ha.idadm = a.idadm
    INNER JOIN Plantel p ON a.idplantelf = p.codplantel

    UNION ALL

    -- Horario Docente (VARIABLE) → ahora desde Asignacion
    SELECT 
        RTRIM(p.applantel) + ' ' + RTRIM(p.amplantel) + ' ' + RTRIM(p.nomplantel) AS NombreCompleto,
        'VARIABLE' AS TipoHorario,
        CAST(ROUND(DATEDIFF(MINUTE, asig.horainicio, asig.horafin) / 60.0, 2) AS DECIMAL(5,2)) AS TiempoTotalHoras
    FROM Asignacion asig
    INNER JOIN Docente d ON asig.iddocentef = d.iddocente
    INNER JOIN Plantel p ON d.idplantelf = p.codplantel;
END
GO



-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

