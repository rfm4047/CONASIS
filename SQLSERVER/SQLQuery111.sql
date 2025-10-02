CREATE OR ALTER PROCEDURE sp_Administrativo_BuscarPorNombre
    @nombre NVARCHAR(100)
AS
BEGIN
    SELECT 
        a.idadm,
        p.ApPlantel,
        p.AmPlantel,
        p.NomPlantel
    FROM Administrativo a
    INNER JOIN Plantel p ON a.idPlantelF = p.CodPlantel
    WHERE p.ApPlantel LIKE '%' + @nombre + '%'
       OR p.AmPlantel LIKE '%' + @nombre + '%'
       OR p.NomPlantel LIKE '%' + @nombre + '%';
END


select *from HorarioAdministrativo

select *from Materia
CREATE OR ALTER PROCEDURE sp_HorarioAdministrativo_CRUD
    @Accion NVARCHAR(20),
    @idhorarioadm INT = NULL,
    @idadm INT = NULL,
    @diaSemana VARCHAR(15) = NULL,
    @horaEntrada TIME = NULL,
    @horaSalida TIME = NULL,
    @horaRecesoInicio TIME = NULL,
    @horaRecesoFin TIME = NULL,
    @toleranciaMinutos INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT * 
        FROM HorarioAdministrativo;
    END

    ELSE IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO HorarioAdministrativo
        (idadm, diaSemana, horaEntrada, horaSalida, horaRecesoInicio, horaRecesoFin, toleranciaMinutos)
        VALUES (@idadm, @diaSemana, @horaEntrada, @horaSalida, @horaRecesoInicio, @horaRecesoFin, @toleranciaMinutos);
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE HorarioAdministrativo
        SET diaSemana = @diaSemana,
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

    ELSE IF @Accion = 'ELIMINAR_TODOS'
    BEGIN
        DELETE FROM HorarioAdministrativo
        WHERE idadm = @idadm;
    END

    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT * 
        FROM HorarioAdministrativo
        WHERE idhorarioadm = @idhorarioadm;
    END

   ELSE IF @Accion = 'RESUMEN'
    BEGIN
        SELECT 
            a.CPlant AS Codigo,
            LTRIM(RTRIM(p.ApPlantel)) + ' ' + 
            LTRIM(RTRIM(p.AmPlantel)) + ' ' + 
            LTRIM(RTRIM(p.NomPlantel)) AS NombreCompleto,
            CAST(SUM(DATEDIFF(MINUTE, h.horaEntrada, h.horaSalida)) / 60.0 AS DECIMAL(10,2)) AS TotalHoras,
            a.IdAdm
        FROM HorarioAdministrativo h
        INNER JOIN Administrativo a ON h.idadm = a.IdAdm
        INNER JOIN Plantel p ON a.IdPlantelF = p.CodPlantel
        GROUP BY a.CPlant, p.ApPlantel, p.AmPlantel, p.NomPlantel, a.IdAdm;
    END

END;
