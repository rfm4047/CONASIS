------PROCEDIMIENTO ALMACENADO DOCENTE---------------


---AGREGAR DOCENTE----
DROP PROC PA_AGREGARDOCENTE
CREATE PROC PA_AGREGARDOCENTE
@idplantelf INT,
@horaplanilla VARCHAR (3),
@cargahorariadocente VARCHAR(3)

AS
INSERT INTO Docente VALUES (@idplantelf, @horaplanilla, @cargahorariadocente)
GO

---ULTIMO CODIGO PLANTEL---

CREATE PROC PA_ULTIMOCODPLANTEL
AS
SELECT DISTINCT TOP 1 codplantel FROM Plantel ORDER BY codplantel DESC



---EDITAR DOCENTE----

CREATE PROC PA_EDITARDOCENTE
@idplantelf INT,
@horaplanilla VARCHAR (3),
@cargahorariadocente VARCHAR(3)

AS
UPDATE Docente SET idplantelf=@idplantelf, horaplanilla=@horaplanilla, cargahorariadocente=@cargahorariadocente
GO

---CARGAR DOCENTE---
DROP PROC PA_CARGARDOCENTE
CREATE PROC PA_CARGARDOCENTE

AS
SELECT idplantelf, cplant, nomplantel, applantel, amplantel, generoplantel,
		ciplantel, extplantel, telfplantel, fechanacplantel, direccionplantel,
		itemplantel, especialidadplantel, rdaplantel,  cargahorariadocente, horaplanilla
FROM Plantel INNER JOIN Docente ON Plantel.codplantel = Docente.idplantelf


---CONSULTAS DOCENTE---
SELECT *FROM DOCENTE
DELETE FROM PLANTEL
SELECT *FROM Plantel
SELECT *FROM ADMINISTRATIVO
TRUNCATE TABLE PLANTEL

INSERT INTO Docente VALUES (1,'104','104')