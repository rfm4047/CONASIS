
--PROCEDIMIENTO AGREGAR REEMPLAZO
CREATE OR ALTER PROCEDURE sp_AgregarReemplazo
    @IdPlantelSolicita INT,
    @IdReemplazante INT = NULL,
    @IdPlantelReemplazante INT = NULL,
    @FechaSolicitud DATE,
    @FechaInicio DATE,
    @FechaFin DATE,
    @IdMotivo INT
AS
BEGIN
    INSERT INTO Reemplazo(
        IdPlantelSolicita, 
        IdReemplazante, 
        codplantel_reemplazante,
        FechaSolicitud, 
        FechaInicio, 
        FechaFin, 
        IdMotivo
    )
    VALUES (
        @IdPlantelSolicita,
        @IdReemplazante,
        @IdPlantelReemplazante,
        @FechaSolicitud,
        @FechaInicio,
        @FechaFin,
        @IdMotivo
    );

    -- devolver el id insertado
    SELECT SCOPE_IDENTITY() AS NewId;
END;
GO

-----------------------------------------------
CREATE OR ALTER PROCEDURE sp_ModificarReemplazo
    @IdReemplazo INT,
    @IdPlantelSolicita INT,
    @CodReemplazante INT = NULL,          -- externo
    @CodPlantelReemplazante INT = NULL,   -- interno
    @FechaSolicitud DATE,
    @FechaInicio DATE,
    @FechaFin DATE,
    @IdMotivo INT
AS
BEGIN
    UPDATE Reemplazo
    SET
        IdPlantelSolicita       = @IdPlantelSolicita,
        codreemplazante         = @CodReemplazante,       -- externo
        codplantel_reemplazante = @CodPlantelReemplazante,-- interno
        FechaSolicitud          = @FechaSolicitud,
        FechaInicio             = @FechaInicio,
        FechaFin                = @FechaFin,
        IdMotivo                = @IdMotivo
    WHERE IdReemplazo = @IdReemplazo;
END;
GO
------------------------------------------------------------------------------
    CREATE OR ALTER PROCEDURE sp_EliminarReemplazo
        @IdReemplazo INT
    AS
    BEGIN
        DELETE FROM Reemplazo
        WHERE IdReemplazo = @IdReemplazo;
    END;
    GO



--PARA EL DATAGRIDVIEW DE FRMREEMPLAZO
CREATE OR ALTER PROCEDURE sp_ListarReemplazos
AS
BEGIN
    SELECT 
        r.IdReemplazo,

        -- IDs reales (para combos)
        r.IdPlantelSolicita,
        r.IdReemplazante,
        r.codplantel_reemplazante AS IdPlantelReemplazante,
        r.IdMotivo,

        -- Nombres legibles (para mostrar en la grilla)
        LTRIM(RTRIM(pSolicita.applantel)) + ' ' + 
        LTRIM(RTRIM(pSolicita.amplantel)) + ' ' + 
        LTRIM(RTRIM(pSolicita.nomplantel)) AS PlantelSolicitaNombre,

        CASE 
            WHEN r.IdReemplazante IS NOT NULL THEN 
                LTRIM(RTRIM(reemp.appaternoreemp)) + ' ' + 
                LTRIM(RTRIM(reemp.apmaternoreemp)) + ' ' + 
                LTRIM(RTRIM(reemp.nomreemp))
            WHEN r.codplantel_reemplazante IS NOT NULL THEN 
                LTRIM(RTRIM(pReemp.applantel)) + ' ' + 
                LTRIM(RTRIM(pReemp.amplantel)) + ' ' + 
                LTRIM(RTRIM(pReemp.nomplantel))
            ELSE '---'
        END AS ReemplazanteNombre,

        r.FechaSolicitud,
        r.FechaInicio,
        r.FechaFin,

        m.motivo AS MotivoNombre
    FROM Reemplazo r
    INNER JOIN Plantel pSolicita 
        ON r.IdPlantelSolicita = pSolicita.codplantel
    LEFT JOIN Reemplazante reemp 
        ON r.IdReemplazante = reemp.codreemplazante
    LEFT JOIN Plantel pReemp 
        ON r.codplantel_reemplazante = pReemp.codplantel
    INNER JOIN Motivo m 
        ON r.IdMotivo = m.codmotivo
    ORDER BY r.IdReemplazo DESC;
END;
GO





--PARA EL COMBOBOX DE FRMREEMPLAZO
CREATE OR ALTER PROCEDURE sp_ListarPersonasReemplazo
AS
BEGIN
    SET NOCOUNT ON;

    -- DOCENTES
    SELECT 
        d.iddocente AS Codigo,
        'DOCENTE' AS Tipo,
        d.idplantelf AS IdPlantel,
        LTRIM(RTRIM(p.applantel)) + ' ' +
        LTRIM(RTRIM(p.amplantel)) + ' ' +
        LTRIM(RTRIM(p.nomplantel)) AS NombreCompleto
    FROM Docente d
    INNER JOIN Plantel p ON d.idplantelf = p.codplantel

    UNION ALL

    -- ADMINISTRATIVOS
    SELECT 
        a.idadm AS Codigo,
        'ADMIN' AS Tipo,
        a.idplantelf AS IdPlantel,
        LTRIM(RTRIM(p.applantel)) + ' ' +
        LTRIM(RTRIM(p.amplantel)) + ' ' +
        LTRIM(RTRIM(p.nomplantel)) AS NombreCompleto
    FROM Administrativo a
    INNER JOIN Plantel p ON a.idplantelf = p.codplantel

    UNION ALL

    -- EXTERNOS
    SELECT 
        r.codreemplazante AS Codigo,
        'EXTERNO' AS Tipo,
        NULL AS IdPlantel,
        LTRIM(RTRIM(r.appaternoreemp)) + ' ' +
        LTRIM(RTRIM(r.apmaternoreemp)) + ' ' +
        LTRIM(RTRIM(r.nomreemp)) AS NombreCompleto
    FROM Reemplazante r

    ORDER BY Tipo, NombreCompleto;
END;




ALTER TABLE Plantel 
ALTER COLUMN nomplantel VARCHAR(30) NOT NULL;

ALTER TABLE Plantel 
ALTER COLUMN applantel VARCHAR(30) NULL;

ALTER TABLE Plantel 
ALTER COLUMN amplantel VARCHAR(30) NULL;

ALTER TABLE Reemplazante 
ALTER COLUMN nomreemp VARCHAR(20) NOT NULL;

ALTER TABLE Reemplazante 
ALTER COLUMN appaternoreemp VARCHAR(40) NOT NULL;

ALTER TABLE Reemplazante 
ALTER COLUMN apmaternoreemp VARCHAR(40) NOT NULL;



UPDATE Plantel
SET 
    nomplantel = LTRIM(RTRIM(nomplantel)),
    applantel = LTRIM(RTRIM(applantel)),
    amplantel = LTRIM(RTRIM(amplantel));

UPDATE Reemplazante
SET
    nomreemp = LTRIM(RTRIM(nomreemp)),
    appaternoreemp = LTRIM(RTRIM(appaternoreemp)),
    apmaternoreemp = LTRIM(RTRIM(apmaternoreemp));



    SELECT * FROM Reemplazante WHERE codreemplazante = 4;


    ALTER TABLE Reemplazo
ADD codreemplazante INT NULL,     -- externo
    codplantel_reemplazante INT NULL; -- interno


-- agregar columna para internos
ALTER TABLE Reemplazo
ADD codplantel_reemplazante INT NULL;

-- volver a crear FK del reemplazante externo (con otro nombre)
ALTER TABLE Reemplazo
ADD CONSTRAINT FK_Reemplazo_Reemplazante_Externo 
FOREIGN KEY (codreemplazante) REFERENCES Reemplazante(codreemplazante);

-- nueva FK para internos
ALTER TABLE Reemplazo
ADD CONSTRAINT FK_Reemplazo_Plantel_Reemplazante
FOREIGN KEY (codplantel_reemplazante) REFERENCES Plantel(codplantel);


ALTER TABLE Reemplazo
DROP CONSTRAINT FK_Reemplazo_Reemplazante;


EXEC sp_help Reemplazo;
-- o
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Reemplazo';


-- volver a crear FK del reemplazante externo (con otro nombre)
ALTER TABLE Reemplazo
ADD CONSTRAINT FK_Reemplazo_Reemplazante_Externo 
FOREIGN KEY (codreemplazante) REFERENCES Reemplazante(codreemplazante);

-- nueva FK para internos
ALTER TABLE Reemplazo
ADD CONSTRAINT FK_Reemplazo_Plantel_Reemplazante
FOREIGN KEY (codplantel_reemplazante) REFERENCES Plantel(codplantel);


SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Plantel';

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Motivo';

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Reemplazo';


EXEC sp_ListarReemplazantes;

-- Verifica qué tienes guardado en Reemplazo
SELECT TOP 20 
    IdReemplazo, IdPlantelSolicita, IdReemplazante, codplantel_reemplazante, IdMotivo
FROM Reemplazo
ORDER BY IdReemplazo DESC;


ALTER TABLE Reemplazo
ALTER COLUMN IdReemplazante INT NULL;


-- Ver las foreign keys de la tabla Reemplazo
EXEC sp_fkeys @fktable_name = 'Reemplazo', @fktable_owner = 'dbo';


SELECT codplantel FROM Plantel;


-- Para Plantel
EXEC sp_help 'dbo.Plantel';

-- Para Reemplazo
EXEC sp_help 'dbo.Reemplazo';
