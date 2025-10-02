--PROCEDIMIENTO ALMACENADO JUNTA ESCOLAR
-- ==========================================
-- CRUD JUNTA ESCOLAR
-- Acciones: AGREGAR, EDITAR, ELIMINAR
-- ==========================================

CREATE OR ALTER PROCEDURE sp_JuntaEscolar_CRUD
    @Accion NVARCHAR(20),
    @codje INT = NULL,
    @nomje VARCHAR(25) = NULL,
    @appaternoje VARCHAR(25) = NULL,
    @apmaternoje VARCHAR(25) = NULL,
    @cije VARCHAR(15) = NULL,
    @extje VARCHAR(8) = NULL,
    @telfje NUMERIC(15) = NULL,
    @estado VARCHAR(15) = NULL,
     @codcargo INT = NULL

AS
BEGIN
    SET NOCOUNT ON;

    -- INSERTAR
    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO JuntaEscolar (nomje, appaternoje, apmaternoje, cije, extje, telfje, estado, codcargo)
        VALUES (@nomje, @appaternoje, @apmaternoje, @cije, @extje, @telfje, ISNULL(@estado, 'ACTIVO'),@codcargo);

        SELECT SCOPE_IDENTITY() AS NuevoId, 
               ('JE' + RIGHT('000' + CONVERT(VARCHAR, SCOPE_IDENTITY()), 3)) AS NuevoCodigo;
        RETURN;
    END;

    -- MODIFICAR
    IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE JuntaEscolar
        SET nomje = @nomje,
            appaternoje = @appaternoje,
            apmaternoje = @apmaternoje,
            cije = @cije,
            extje = @extje,
            telfje = @telfje,
            estado = @estado,
            codcargo = @codcargo 
        WHERE codje = @codje;
        RETURN;
    END;

    -- ELIMINAR
    IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM JuntaEscolar
        WHERE codje = @codje;
        RETURN;
    END;

    -- LISTAR TODOS
    IF @Accion = 'LISTAR'
    BEGIN
        SELECT codje, codigo, nomje, appaternoje, apmaternoje, cije, extje, telfje, estado, fechacreacion, c.codcargo, c.nomcargo
        FROM JuntaEscolar je
INNER JOIN Cargo c ON je.codcargo = c.codcargo;
        RETURN;
    END;

    -- BUSCAR POR ID
    IF @Accion = 'BUSCAR'
    BEGIN
        SELECT codje, codigo, nomje, appaternoje, apmaternoje, cije, extje, telfje, estado, fechacreacion
        FROM JuntaEscolar
        WHERE codje = @codje;
        RETURN;
    END;
END;
GO

-------------------------------------------------------------------
--CONSULTAS PARA JUNTA ESCOLAR


-- el cargo vigente de cada representante

SELECT 
    je.nomje + ' ' + je.appaternoje + ' ' + je.apmaternoje AS NombreCompleto,
    c.nomcargo AS Cargo,
    ch.fecha_inicio
FROM CargoHistorial ch
INNER JOIN JuntaEscolar je ON ch.codje = je.codje
INNER JOIN Cargo c ON ch.codcargo = c.codcargo
WHERE ch.fecha_fin IS NULL;   -- solo los cargos activos


--Historial de un cargo específico (ejemplo: presidente)

SELECT 
    c.nomcargo,
    je.nomje + ' ' + je.appaternoje + ' ' + je.apmaternoje AS NombreCompleto,
    ch.fecha_inicio,
    ISNULL(CONVERT(VARCHAR, ch.fecha_fin), 'Vigente') AS Estado
FROM CargoHistorial ch
INNER JOIN JuntaEscolar je ON ch.codje = je.codje
INNER JOIN Cargo c ON ch.codcargo = c.codcargo
WHERE c.nomcargo = 'Presidente'
ORDER BY ch.fecha_inicio;


--Historial completo de un representante

SELECT 
    je.nomje + ' ' + je.appaternoje + ' ' + je.apmaternoje AS NombreCompleto,
    c.nomcargo,
    ch.fecha_inicio,
    ISNULL(CONVERT(VARCHAR, ch.fecha_fin), 'Vigente') AS Estado
FROM CargoHistorial ch
INNER JOIN JuntaEscolar je ON ch.codje = je.codje
INNER JOIN Cargo c ON ch.codcargo = c.codcargo
WHERE je.codje = 1   -- aquí va el ID del representante
ORDER BY ch.fecha_inicio;


--Procedimiento para asignar un nuevo cargo

CREATE PROCEDURE sp_AsignarCargo
    @codje INT,   -- representante que asume
    @codcargo INT    -- cargo (ej. presidente, secretario, etc.)
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Cerrar el cargo vigente (si existe)
    UPDATE CargoHistorial
    SET fecha_fin = GETDATE()
    WHERE codcargo = @codcargo
      AND fecha_fin IS NULL;

    -- 2. Insertar el nuevo registro
    INSERT INTO CargoHistorial (codje, codcargo, fecha_inicio, fecha_fin)
    VALUES (@codje, @codcargo, GETDATE(), NULL);
END;
GO


--Verificación rápida (qué cargos están vigentes ahora)

SELECT c.nomcargo, 
       je.nomje + ' ' + je.appaternoje AS Representante,
       ch.fecha_inicio
FROM CargoHistorial ch
JOIN JuntaEscolar je ON je.codje = ch.codje
JOIN Cargo c ON c.codcargo = ch.codcargo
WHERE ch.fecha_fin IS NULL;


--Procedimiento: sp_ConsultarCargoEnFecha

CREATE PROCEDURE sp_ConsultarCargoEnFecha
    @codcargo INT,     -- cargo (ej: Presidente, Secretario, etc.)
    @fecha DATE        -- fecha a consultar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.nomcargo,
        je.nomje + ' ' + je.appaternoje + ' ' + je.apmaternoje AS NombreCompleto,
        ch.fecha_inicio,
        ISNULL(ch.fecha_fin, 'Vigente') AS fecha_fin
    FROM CargoHistorial ch
    INNER JOIN JuntaEscolar je ON ch.codje = je.codje
    INNER JOIN Cargo c ON ch.codcargo = c.codcargo
    WHERE ch.codcargo = @codcargo
      AND @fecha BETWEEN ch.fecha_inicio AND ISNULL(ch.fecha_fin, @fecha)
    ORDER BY ch.fecha_inicio;
END;
GO

--Procedimiento: sp_ConsultarCargosEnFecha

CREATE PROCEDURE sp_ConsultarCargosEnFecha
    @fecha DATE   -- fecha a consultar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.nomcargo,
        je.nomje + ' ' + je.appaternoje + ' ' + je.apmaternoje AS NombreCompleto,
        ch.fecha_inicio,
        ISNULL(ch.fecha_fin, 'Vigente') AS fecha_fin
    FROM CargoHistorial ch
    INNER JOIN JuntaEscolar je ON ch.codje = je.codje
    INNER JOIN Cargo c ON ch.codcargo = c.codcargo
    WHERE @fecha BETWEEN ch.fecha_inicio AND ISNULL(ch.fecha_fin, @fecha)
    ORDER BY c.nomcargo;
END;
GO


--Procedimiento: sp_ReporteHistorialGestion

CREATE PROCEDURE sp_ReporteHistorialGestion
    @gestion INT   -- año escolar (ejemplo: 2025)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.nomcargo,
        je.nomje + ' ' + je.appaternoje + ' ' + je.apmaternoje AS NombreCompleto,
        ch.fecha_inicio,
        ISNULL(CONVERT(VARCHAR, ch.fecha_fin, 23), 'Vigente') AS fecha_fin
    FROM CargoHistorial ch
    INNER JOIN JuntaEscolar je ON ch.codje = je.codje
    INNER JOIN Cargo c ON ch.codcargo = c.codcargo
    WHERE YEAR(ch.fecha_inicio) = @gestion
       OR (ch.fecha_fin IS NOT NULL AND YEAR(ch.fecha_fin) = @gestion)
    ORDER BY c.nomcargo, ch.fecha_inicio;
END;
GO


--Procedimiento: sp_ResumenCargosPorGestion


CREATE PROCEDURE sp_ResumenCargosPorGestion
    @gestion INT   -- año escolar (ejemplo: 2025)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.nomcargo,
        COUNT(DISTINCT ch.codje) AS CantidadRepresentantes,
        COUNT(ch.idhistorial) AS CantidadCambios
    FROM CargoHistorial ch
    INNER JOIN Cargo c ON ch.codcargo = c.codcargo
    WHERE YEAR(ch.fecha_inicio) = @gestion
       OR (ch.fecha_fin IS NOT NULL AND YEAR(ch.fecha_fin) = @gestion)
    GROUP BY c.nomcargo
    ORDER BY c.nomcargo;
END;
GO

-----------------------------------------------------

ALTER TABLE JuntaEscolar
ADD codcargo INT NOT NULL 
    CONSTRAINT fk_junta_cargo FOREIGN KEY (codcargo)
    REFERENCES Cargo(codcargo);

    ALTER TABLE JuntaEscolar
ADD codcargo INT NOT NULL 
    CONSTRAINT fk_juntaescolar_cargo FOREIGN KEY (codcargo) REFERENCES Cargo(codcargo);


    SELECT *
FROM JuntaEscolar;
