--PROCEDIMIENTO ALMACENADO TIPODIA

CREATE OR ALTER PROCEDURE sp_TipoDia_CRUD
    @Accion NVARCHAR(20),
    @idtipodia INT = NULL,
    @nom_tipodia NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'MOSTRAR'
        SELECT * FROM TipoDia;

    ELSE IF @Accion = 'AGREGAR'
        INSERT INTO TipoDia (nom_tipodia) VALUES (@nom_tipodia);

    ELSE IF @Accion = 'MODIFICAR'
        UPDATE TipoDia SET nom_tipodia = @nom_tipodia WHERE idtipodia = @idtipodia;

    ELSE IF @Accion = 'ELIMINAR'
        DELETE FROM TipoDia WHERE idtipodia = @idtipodia;

    ELSE IF @Accion = 'BUSCAR'
        SELECT * FROM TipoDia WHERE idtipodia = @idtipodia;
END;



EXEC sp_TipoDia_CRUD 'AGREGAR', NULL, 'Hábil';
EXEC sp_TipoDia_CRUD 'AGREGAR', NULL, 'Feriado';
EXEC sp_TipoDia_CRUD 'AGREGAR', NULL, 'Vacaciones';
EXEC sp_TipoDia_CRUD 'AGREGAR', NULL, 'Descanso Pedagógico';

EXEC sp_TipoDia_CRUD 'MOSTRAR';

SELECT * FROM TipoDia;
