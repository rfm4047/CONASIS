--------------------------------------------------------
-- Procedimiento CRUD para JUNTA ESCOLAR

CREATE OR ALTER PROCEDURE sp_JuntaEscolar_CRUD
    @Accion NVARCHAR(20),
    @codrepje INT = NULL,
    @nomrepje VARCHAR(25) = NULL,
    @appaternoje VARCHAR(25) = NULL,
    @apmaternoje VARCHAR(25) = NULL,
    @cirepje VARCHAR(15) = NULL,
    @extrepje VARCHAR(8) = NULL,
    @telf VARCHAR(15) = NULL,
    @estadoje VARCHAR(8) =NULL,
BEGIN
    SET NOCOUNT ON;

    -- AGREGAR
    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO JuntaEscolar (nomrepje, appaternoje, apmaternoje, cirepje, extrepje, telf, estado)
        VALUES (@nomrepje, @appaternoje, @apmaternoje, @cirepje, @extrepje, @telf, ISNULL(@estado,'ACTIVO'));

        DECLARE @NuevoId INT = SCOPE_IDENTITY();
        SELECT 
            @NuevoId AS NuevoCodRepje,
            codigo AS NuevoCodigo
        FROM JuntaEscolar WHERE codrepje = @NuevoId;
    END

    -- MODIFICAR
    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE JuntaEscolar
        SET nomrepje = @nomrepje,
            appaternoje = @appaternoje,
            apmaternoje = @apmaternoje,
            cirepje = @cirepje,
            extrepje = @extrepje,
            telf = @telf,
            estado = @estado
        WHERE codrepje = @codrepje;
    END

    -- ELIMINAR
    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM JuntaEscolar WHERE codrepje = @codrepje;
    END

    -- MOSTRAR
    ELSE IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT codrepje, codigo, nomrepje, appaternoje, apmaternoje, cirepje, extrepje, telf, estado, fechacreacion
        FROM JuntaEscolar
        ORDER BY codrepje DESC;
    END

    -- BUSCAR
    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT codje, codigo, nomrje, appaternoje, apmaternoje, cirepje, extrepje, telf, estado, fechacreacion
        FROM JuntaEscolar
        WHERE codje = @codje;
    END
END
GO

EXEC sp_help JuntaEscolar;


---------------------------------------------------------------
--Procedimiento CRUD para CARGO de JUNTA ESCOLAR

CREATE OR ALTER PROCEDURE sp_Cargo_CRUD
    @Accion NVARCHAR(20),
    @codcargo INT = NULL,
    @nomcargo CHAR(25) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO Cargo (codcargo, nomcargo)
        VALUES (@codcargo, @nomcargo);

        SELECT @codcargo AS NuevoCodCargo;
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE Cargo
        SET nomcargo = @nomcargo
        WHERE codcargo = @codcargo;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM Cargo WHERE codcargo = @codcargo;
    END

    ELSE IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT * FROM Cargo ORDER BY codcargo;
    END

    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT * FROM Cargo 
        WHERE codcargo = @codcargo 
           OR nomcargo LIKE '%' + @nomcargo + '%';
    END
END
GO


----------------------------------------------------------------------
--Procedimiento CRUD para CARGO HISTORIAL
CREATE OR ALTER PROCEDURE sp_CargoHistorial_CRUD
    @Accion NVARCHAR(20),
    @idhistorial INT = NULL,
    @codrepje INT = NULL,
    @codcargo INT = NULL,
    @fecha_inicio DATE = NULL,
    @fecha_fin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO CargoHistorial (codrepje, codcargo, fecha_inicio, fecha_fin)
        VALUES (@codrepje, @codcargo, @fecha_inicio, @fecha_fin);

        DECLARE @NuevoId INT = SCOPE_IDENTITY();
        SELECT @NuevoId AS NuevoIdHistorial;
    END

    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE CargoHistorial
        SET codrepje = @codrepje,
            codcargo = @codcargo,
            fecha_inicio = @fecha_inicio,
            fecha_fin = @fecha_fin
        WHERE idhistorial = @idhistorial;
    END

    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM CargoHistorial WHERE idhistorial = @idhistorial;
    END

    ELSE IF @Accion = 'MOSTRAR'
    BEGIN
        SELECT ch.idhistorial, je.codigo AS CodigoRepresentante, je.nomrepje, je.appaternoje, je.apmaternoje,
               c.nomcargo, ch.fecha_inicio, ch.fecha_fin
        FROM CargoHistorial ch
        INNER JOIN JuntaEscolar je ON ch.codrepje = je.codrepje
        INNER JOIN Cargo c ON ch.codcargo = c.codcargo
        ORDER BY ch.fecha_inicio DESC;
    END

    ELSE IF @Accion = 'BUSCAR'
    BEGIN
        SELECT ch.idhistorial, je.codigo AS CodigoRepresentante, je.nomrepje, je.appaternoje, je.apmaternoje,
               c.nomcargo, ch.fecha_inicio, ch.fecha_fin
        FROM CargoHistorial ch
        INNER JOIN JuntaEscolar je ON ch.codrepje = je.codrepje
        INNER JOIN Cargo c ON ch.codcargo = c.codcargo
        WHERE ch.idhistorial = @idhistorial
           OR je.nomrepje LIKE '%' + ISNULL(@codrepje,'') + '%';
    END
END
GO
