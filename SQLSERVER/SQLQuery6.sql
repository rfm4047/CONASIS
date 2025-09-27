
SELECT 
    c.name AS Columna,
    t.name AS TipoDato,
    c.max_length AS Longitud,
    c.is_nullable AS AceptaNulos
FROM sys.columns c
JOIN sys.types t ON c.user_type_id = t.user_type_id
WHERE c.object_id = OBJECT_ID('Administrativo');


ALTER TABLE Administrativo
ALTER COLUMN cargoadm VARCHAR(30) NOT NULL;