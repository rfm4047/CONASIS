PROCEDIMIENTOS ALMACENADOS TABLA INSTITUCION 2025


--PROCEDIMIENTO ALMACENADO CARGAR INSTITUCION--
CREATE PROC [dbo].[CargarInst]
as
select top 1 * from Institucion order by codinst ASC


--PROCEDIMIENTO ALMACENADO MODIFICAR INSTITUCION--
CREATE PROC [dbo].[ModificarInstitucion]
@nominst VARCHAR(30),
@dptoinst VARCHAR(10),
@nivelinst VARCHAR(8),
@turnoinst VARCHAR(6),
@nservicioinst VARCHAR(7),
@nprogramainst VARCHAR(10),
@nsieinst VARCHAR(10),
@mejorarinst VARCHAR(10),
@direccioninst VARCHAR (50),
@nucleoescinst VARCHAR(10),
@subdistinst VARCHAR(10),
@uvinst VARCHAR(10),
@mzinst VARCHAR(10),
@distedinst VARCHAR (10),
@distmuninst VARCHAR (10),
@telfuniedinst VARCHAR (15),
@telfdirectorainst VARCHAR (15),
@codinst INT
as
UPDATE Institucion  set  nominst=@nominst, dptoinst=@dptoinst, nivelinst=@nivelinst,
						 turnoinst=@turnoinst, nservicioinst=@nservicioinst, nprogramainst=@nprogramainst,
						 nsieinst=@nsieinst, mejorarinst=@mejorarinst, direccioninst=@direccioninst,
						 nucleoescinst=@nucleoescinst, subdistinst=@subdistinst, uvinst=@uvinst, mzinst=@mzinst,
						 distedinst=@distedinst, distmuninst=@distmuninst, telfuniedinst=@telfuniedinst, 
						 telfdirectorainst=@telfdirectorainst
						 WHERE codinst= @codinst
go

-----------------------------


select *from Institucion


-----------------------------

--MODIFICAR TABLA INSTITUCION--
ALTER TABLE Institucion
ADD CONSTRAINT df_fechamodificacion 
DEFAULT GETDATE() FOR fechamodificacion;
GO
--ACTUALIZAR TABLA INSTITUCION--
UPDATE Institucion 
SET fechamodificacion = GETDATE() 
WHERE fechamodificacion IS NULL;
GO