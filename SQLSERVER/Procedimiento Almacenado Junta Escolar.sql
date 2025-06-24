------PROCEDIMIENTO ALMACENADO JUNTA ESCOLAR---------------
select *from JuntaEscolar

---AGREGAR JUNTAESCOLAR----
DROP PROC PA_AGREGARJUNTAESC
CREATE PROC PA_AGREGARJUNTAESC
@codrepje INT,
@nombrerje VARCHAR (25),
@apprje VARCHAR (25),
@apmrje VARCHAR(25),
@cirje VARCHAR (15),
@extrje VARCHAR (8),
@telfrje VARCHAR (15),
@cargorje VARCHAR (15)

AS
INSERT INTO JuntaEscolar VALUES (@codrepje, @nombrerje, @apprje,@apmrje,@cirje, @extrje, @telfrje,@cargorje)
GO


---CARGAR JUNTA ESCOLAR---
DROP PROC PA_CARGARJUNTAESCOLAR
CREATE PROC PA_CARGARJUNTAESCOLAR

AS
SELECT codrepje, nomrepje, appje, apmrje, cirepje, extrepje, telf, cargo
FROM JuntaEscolar 
GO




INSERT INTO JuntaEscolar VALUES (codrepje= @codprepje, nomnrerje=@nombrerje,apprje=@apprje, apmrje=@apmrje,
								 cirje=@cirje, extrje=@extrje, telfrje=@telfrje, cargorje=@cargorje)
GO
