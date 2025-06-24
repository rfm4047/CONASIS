------PROCEDIMIENTO ALMACENADO AGREGAR ADMINISTRATIVO-------------


---AGREGAR ADMINISTRATIVO---
DROP PROC PA_AGREGARADMINISTRATIVO
CREATE PROC PA_AGREGARADMINISTRATIVO
@idplantelf INT,
@cargoadm CHAR (30)

AS
INSERT INTO Administrativo VALUES (@idplantelf, @cargoadm)
GO

---ULTIMO CODIGO PLANTEL---

CREATE PROC PA_ULTIMOCODPLANTEL
AS
SELECT DISTINCT TOP 1 codplantel FROM Plantel ORDER BY codplantel DESC

---EDITAR ADMINISTRATIVO----

CREATE PROC PA_EDITARADMINISTRATIVO
@idplantelf INT,
@cargoadm CHAR (30)

AS
UPDATE Administrativo SET idplantelf=@idplantelf, cargoadm=@cargoadm
GO

---CARGAR ADMINISTRATIVO---

CREATE PROC PA_CARGARADMINISTRATIVO
AS
SELECT idplantelf, nomplantel, applantel, amplantel, generoplantel,
		ciplantel, extplantel, telfplantel, fechanacplantel, direccionplantel,
		itemplantel, especialidadplantel, rdaplantel,  cargoadm
FROM Plantel INNER JOIN Administrativo ON Plantel.codplantel = Administrativo.idplantelf


---CONSULTAS---
SELECT *FROM ADMINISTRATIVO
SELECT *FROM PLANTEL
TRUNCATE TABLE PLANTEL
INSERT INTO ADMINISTRATIVO VALUES (1,'SECRETARIA')