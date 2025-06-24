

PROCEDIMIENTO ALMACENADO PLANTEL

DROP PROC PA_GuardarPlantel
CREATE PROC PA_GuardarPlantel
@nomplantel CHAR (30),
@applantel CHAR (30),
@amplantel CHAR (30),
@generoplantel CHAR (9),
@ciplantel VARCHAR (10),
@extplantel CHAR (6),
@telfplantel CHAR (8),
@fechanacplantel DATE,
@direccionplantel VARCHAR (50),
@especialidadplantel CHAR (25),
@itemplantel VARCHAR (5),
@rdaplantel VARCHAR (7)

as
insert into Plantel values (@nomplantel, @applantel, @amplantel, @generoplantel,
							@ciplantel, @extplantel, @telfplantel, @fechanacplantel, @direccionplantel,
							@especialidadplantel, @itemplantel, @rdaplantel)
go
------------------------------------------------------
PROCEDIMIENTO ALMACENADO PLANTEL

CREATE PROC PA_ModificarPlantel
@nomplantel CHAR (30),
@applantel CHAR (30),
@amplantel CHAR (30),
@generoplantel CHAR (9),
@ciplantel VARCHAR (10),
@extplantel CHAR (6),
@telfplantel CHAR (8),
@fechanacplantel DATE,
@direccionplantel VARCHAR (50),
@especialidadplantel CHAR (25),
@itemplantel VARCHAR (5),
@rdaplantel VARCHAR (7),
@codplantel INT

as
update Plantel set nomplantel=@nomplantel,applantel=@applantel, amplantel=@amplantel, generoplantel=@generoplantel,
					ciplantel=@ciplantel, extplantel=@extplantel, telfplantel=@telfplantel, 
					fechanacplantel=@fechanacplantel, direccionplantel=@direccionplantel,
					especialidadplantel=@especialidadplantel, itemplantel=@itemplantel, rdaplantel=@rdaplantel
					WHERE codplantel=@codplantel
go

SELECT *FROM PLANTEL
SELECT *FROM DOCENTE
SELECT *FROM ADMINISTRATIVO
--SELECT nombre, apellido1, departamento FROM personas INNER JOIN departamentos WHERE personas.dep = departamentos.dep

CREATE PROC CARGAR_PLANTEL 
AS
SELECT codplantel, nomplantel, applantel, amplantel, generoplantel,
		ciplantel, extplantel, telfplantel, fechanacplantel, direccionplantel,
		rdaplantel, itemplantel, especialidadplantel
FROM Plantel
GO
