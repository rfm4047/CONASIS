-- 1️⃣ ELIMINAR DATOS DE HIJOS PRIMERO (por las FK)
DELETE FROM Docente;
DELETE FROM Administrativo;

-- 2️⃣ ELIMINAR DATOS DE PLANTEL
DELETE FROM Plantel;

-- 3️⃣ RESETEAR EL IDENTITY DE PLANTEL
DBCC CHECKIDENT ('Plantel', RESEED, 0);
-- Ahora el próximo Plantel será codplantel = 1

-- 4️⃣ RESETEAR LAS SECUENCIAS DE DOCENTE Y ADMINISTRATIVO
ALTER SEQUENCE Seq_Docente RESTART WITH 1;
ALTER SEQUENCE Seq_Administrativo RESTART WITH 1;

PRINT 'Plantel reiniciado. Próximo será 1.';
PRINT 'Seq_Docente reiniciada. Próximo será 1.';
PRINT 'Seq_Administrativo reiniciada. Próximo será 1.';


DECLARE @NuevoId INT;

EXEC sp_Administrativo_CRUD 
    @Accion = 'AGREGAR',
    @idplantelf = 6,  -- <-- Usa un codplantel real que exista en Plantel
    @cargoadm = 'SECRETARIA';


    SELECT name 
FROM sys.procedures
WHERE name LIKE '%Docente%';


EXEC sp_helptext 'sp_Docente_CRUD';
