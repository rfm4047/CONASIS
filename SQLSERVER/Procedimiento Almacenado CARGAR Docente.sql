CREATE PROC PA_CARGARDOCENTE

AS
SELECT idplantelf, nomplantel, applantel, amplantel, generoplantel,
		ciplantel, extplantel, telfplantel, fechanacplantel, direccionplantel,
		itemplantel, especialidadplantel, rdaplantel,  cargahorariadocente, horaplanilla
FROM Plantel
INNER JOIN Docente ON Plantel.codplantel = Docente.idplantelf



