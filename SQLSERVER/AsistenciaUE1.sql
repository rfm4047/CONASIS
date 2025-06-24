CREATE DATABASE asistenciaue1
DROP DATABASE asistenciaue1
USE asistenciaue1
GO


select * from Institucion

-------------------------------------------------------------------------------------
TABLAS PARA ASISTENCIA

DROP TABLE Gestion
CREATE TABLE Gestion
(
codgestion INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_idgestion PRIMARY KEY(codgestion),
cges AS ('GES'+ RIGHT ('00'+CONVERT (VARCHAR, codgestion),(2))),
nomgestion VARCHAR(4) NOT NULL CONSTRAINT u_gestion UNIQUE,
fechainigestion DATE NOT NULL,
fechafingestion DATE NOT NULL,
);
GO

DROP TABLE Asistencia
CREATE TABLE Asistencia
(
codasistencia INT NOT NULL PRIMARY KEY,
fecha DATE NOT NULL,
estado VARCHAR(10) NOT NULL,
idplantelf INT,
idhuellaf INT NOT NULL,
idparteasisf INT NOT NULL,
idform101f INT NOT NULL,
idgestionf INT NOT NULL,
idcalescf INT NOT NULL,

CONSTRAINT FK_asistencia_huella FOREIGN KEY (idhuellaf) REFERENCES Huella(codhuella),
CONSTRAINT FK_asistencia_parte_asistencia FOREIGN KEY (idparteasisf) REFERENCES ParteAsistencia(codparteasistencia),
CONSTRAINT FK_asistencia_form_101 FOREIGN KEY (idform101f) REFERENCES Form101(codform101),
CONSTRAINT FK_asistencia_gestion FOREIGN KEY (idgestionf) REFERENCES Gestion(codgestion),
CONSTRAINT FK_asistencia_CalendarioEsc FOREIGN KEY (idcalescf) REFERENCES CalendarioEsc(codcal),
	
);
GO

DROP TABLE Huella
CREATE TABLE Huella
(
codhuella INT NOT NULL CONSTRAINT pk_idhuella PRIMARY KEY(codhuella),
nomhuella VARCHAR(8)  NOT NULL CONSTRAINT u_dedo UNIQUE,
idplantelf INT NOT NULL,

CONSTRAINT FK_clave_plantel FOREIGN KEY (idplantelf) REFERENCES ^Plantel(codplantel),
);
GO

----------------------------------------------------------------------------------
TABLAS PARA CALENDARIO ESCOLAR

DROP TABLE Actividad
CREATE TABLE Actividad
(
codact INT NOT NULL CONSTRAINT pk_idact PRIMARY KEY (codact),
cact AS ('ACT'+ RIGHT ('00'+convert (VARCHAR, codact)(2))),
nomact CHAR (50) NOT NULL,
fechainiact DATE NOT NULL,
fechafinact DATE NOT NULL,

);
GO

DROP TABLE Bimestre
CREATE TABLE Bimestre
(
codbim INT NOT NULL CONSTRAINT pk_idcodbim PRIMARY KEY (codbim),
cbim AS ('BIM'+ RIGHT ('00'+convert (VARCHAR, codbim)(2))),
nombim VARCHAR (30) NOT NULL,
fechainibim DATE NOT NULL,
fechafinbim DATE NOT NULL,
idcalf INT NOT NULL,

CONSTRAINT FK_bimestre_calesc FOREIGN KEY (idcalf) REFERENCES CalendarioEsc(codcal),
);
GO

DROP TABLE ActBim
CREATE TABLE ActBim
(

codactbim INT  NOT NULL CONSTRAINT pk_idactbim PRIMARY KEY (codactbim),
idactividadf INT NOT NULL,
idbimestref INT NOT NULL,

CONSTRAINT FK_cargo_actbim1 FOREIGN KEY (idactividadf) REFERENCES actividad(codact),
CONSTRAINT FK_cargo_actbim2 FOREIGN KEY (idbimestref) REFERENCES bimestre(codbim),

);
GO

-------------------------------------------------------------------------------------
TABLAS PARA HORARIO

DROP TABLE Asignacion
CREATE TABLE Asignacion
(
codasignacion INT NOT NULL PRIMARY KEY,
casig AS ('ASG'+ RIGHT ('00'+convert (VARCHAR, codasignacion)(2))),
dia VARCHAR (10) NOT NULL,
idmateriaf INT NOT NULL,
idcursof INT NOT NULL,
iddocentef INT NOT NULL,


CONSTRAINT FK_asignacion_curso FOREIGN KEY (idcursof) REFERENCES Curso(codcurso),
CONSTRAINT FK_asignacion_docente FOREIGN KEY (iddocentef) REFERENCES Docente(coddocente),
);
GO

DROP TABLE Curso
CREATE TABLE Curso
(
codcurso INT NOT NULL PRIMARY KEY,
ccur AS ('CR'+ RIGHT ('00'+convert (VARCHAR, codcurso)(2))),
nomcurso VARCHAR(10) NOT NULL,
idnivelf INT NOT NULL,
idparalelof INT NOT NULL,

CONSTRAINT FK_curso_idnivelf FOREIGN KEY (idnivelf) REFERENCES Nivel(cod_nivel),
CONSTRAINT FK_curso_idparalelof FOREIGN KEY (idparalelof) REFERENCES Paralelo(cod_paralelo),
);
GO

CREATE TABLE Nivel
(
codnivel INT  NOT NULL CONSTRAINT pk_idnivel PRIMARY KEY(codnivel),
cni AS ('NI'+ RIGHT ('00'+convert (VARCHAR, codnivel)(2))),
nomnivel CHAR (10) NOT NULL,
);
GO

DROP TABLE Paralelo
CREATE TABLE Paralelo
(
codparalelo INT NOT NULL CONSTRAINT pk_idparalelo PRIMARY KEY(codparalelo),
cpar AS ('PAR'+ RIGHT ('00'+convert (VARCHAR, codparalelo)(2))),
nomparalelo CHAR (1) NOT NULL,
);
GO

----------------------------------------------------------------------------------------
TABLAS PARA INSTITUCION

	
DROP TABLE Institucion
CREATE TABLE Institucion
(
codinst INT  NOT NULL,CONSTRAINT pk_idinst PRIMARY KEY(codinst),
nominst VARCHAR(30) NOT NULL,
dptoinst VARCHAR(20)NOT NULL,
nivelinst VARCHAR(15) NOT NULL,
turnoinst VARCHAR(15)NOT NULL,
nservicioinst VARCHAR(20)NOT NULL,
nprogramainst VARCHAR(20) NOT NULL,
nsieinst VARCHAR(20) NOT NULL,
mejorarinst VARCHAR(20) NULL,
direccioninst VARCHAR (50) NOT NULL,
nucleoescinst VARCHAR(20) NOT NULL,
subdistinst VARCHAR(20) NOT NULL,
uvinst VARCHAR(20) NOT NULL,
mzinst VARCHAR(20) NOT NULL,
distedinst VARCHAR (20) NOT NULL,
distmuninst VARCHAR (20) NOT NULL,
telfuniedinst VARCHAR (15) NOT NULL,
telfdirectorainst VARCHAR (15) NOT NULL,

);
GO


----------------------------------------------------------------------------------------
TABLAS PARA JUNTA ESCOLAR

DROP TABLE Cargo
CREATE TABLE Cargo
(
codcargo INT  NOT NULL CONSTRAINT pk_idcargo PRIMARY KEY(codcargo),
ccar AS ('CRG'+ RIGHT ('00'+convert (VARCHAR, codcargo)(2))),
nomcargo CHAR(25) NOT NULL,
);
 GO
 
DROP TABLE Cargorepje
CREATE TABLE Cargorepje
(

codcargorepje INT  NOT NULL CONSTRAINT pk_idcargorepje PRIMARY KEY (codcargorepje),
fechacargorepje DATE NOT NULL,
idcargof INT NOT NULL,
idrepjef INT NOT NULL,

CONSTRAINT FK_cargo_repje1 FOREIGN KEY (idcargof) REFERENCES Cargo(codcargo),
CONSTRAINT FK_cargo_repje2 FOREIGN KEY (idrepjef) REFERENCES JuntaEscolar(codrepje),

);
GO

DROP TABLE JuntaEscolar
CREATE TABLE JuntaEscolar
(
codrepje INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_idrepje PRIMARY KEY(codrepje),
CODIGO AS('JE'+ RIGHT ('00'+CONVERT (VARCHAR, codrepje),(2))),
nomrepje CHAR (25) NOT NULL,
apje CHAR (25) NOT NULL,
cirepje VARCHAR (15) NOT NULL,
extrepje VARCHAR(8) NOT NULL,
telf NUMERIC (15) NOT NULL,
estado CHAR (15) NOT NULL,
);
GO


------------------------------------------------------------------------------------
TABLAS PARA PERMISO

DROP TABLE Permiso
CREATE TABLE Permiso
(
codpermiso INT NOT NULL,
fechasolpermiso DATE NOT NULL,
hrinipermiso TIME NOT NULL,
hrfinpermiso TIME NOT NULL,
idmotperf INT NOT NULL,
idplantelf INT NOT NULL,

CONSTRAINT FK_permiso_motper FOREIGN KEY (idmotperf) REFERENCES MotivoPermiso(codmotpermiso),
CONSTRAINT FK_permiso_idplantelf FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel)
);
GO

DROP TABLE MotivoPermiso
CREATE TABLE MotivoPermiso
(
codmotpermiso INT NOT NULL CONSTRAINT pk_idmotpermisopk PRIMARY KEY(codmotpermiso),
motpermiso VARCHAR(30) NOT NULL,
);
GO

----------------------------------------------------------------------------------------
TABLAS PARA LICENCIA

DROP TABLE Licencia
CREATE TABLE Licencia
(
codlicencia INT NOT NULL,
clic AS ('LIC'+ RIGHT ('00'+convert (VARCHAR, codlicencia)(2))),
fechasollic DATE NOT NULL,
fechainilic DATE NOT NULL,
fechafinlic DATE NOT NULL,
idplantelf INT NOT NULL,
idmotlicf INT NOT NULL,
idlicf INT NOT NULL,

CONSTRAINT FK_licencia_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel),
CONSTRAINT FK_licencia_motlic FOREIGN KEY (idmotlicf) REFERENCES MotivoLicencia(codmotivolicencia),
CONSTRAINT FK_licencia_lic FOREIGN KEY (idlicf) REFERENCES Reemplazante(codreemplazante)

);
GO

CREATE TABLE MotivoLicencia
(
codmotivolicencia INT NOT NULL CONSTRAINT pk_idmotlicenciapk PRIMARY KEY(codmotivolicencia), 
cml AS ('ML'+ RIGHT ('00'+convert (VARCHAR, codmotivolicencia)(2))),
motlic VARCHAR(30) NOT NULL,
);
GO

CREATE TABLE Reemplazante
(
codreemplazante INT NOT NULL CONSTRAINT pk_idreemplazante PRIMARY KEY(codreemplazante),
creemp AS ('RE'+ RIGHT ('00'+convert (VARCHAR, codreemplazante),(2))),
nomreemp CHAR (20) NOT NULL,
apreemp CHAR (40) NOT NULL,
);
GO

----------------------------------------------------------------------------------------
TABLAS PARA PLANTEL

TRUNCATE TABLE PLANTEL
DROP TABLE Plantel
CREATE TABLE Plantel
(
codplantel INT IDENTITY(1,1) NOT NULL CONSTRAINT pk_idplantel PRIMARY KEY(codplantel),	
nomplantel CHAR (30) NOT NULL,
applantel CHAR (30) NOT NULL,
amplantel CHAR (30) NOT NULL,
generoplantel CHAR (9) NOT NULL,
ciplantel VARCHAR (10) NOT NULL,
extplantel CHAR (6) NOT NULL,
telfplantel CHAR (8) NOT NULL,
fechanacplantel DATE NOT NULL,
direccionplantel VARCHAR (50) NULL,
especialidadplantel CHAR (25)  NULL,
itemplantel VARCHAR (5) NOT NULL CONSTRAINT u_item UNIQUE,
rdaplantel VARCHAR (7) NOT NULL CONSTRAINT u_rda UNIQUE

);
GO
SELECT *FROM Plantel
estadoplantel CHAR (8) NOT NULL,
claveplantel VARCHAR (8) NOT NULL,


DROP TABLE telfplantel
CREATE TABLE telfplantel
(
telffijo NUMERIC (10) NOT NULL,
telfcelular NUMERIC (10) NOT NULL CONSTRAINT u_telfcel UNIQUE,
idplantelf INT NOT NULL,

CONSTRAINT FK_telfplantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel),
);
GO


DROP TABLE Administrativo
CREATE TABLE Administrativo
(
idplantelf INT,
idadm INT IDENTITY (1,1),
cplant AS ('ADM'+ RIGHT ('00'+convert (VARCHAR, idplantelf),(2))),
cargoadm CHAR (30) NOT NULL

CONSTRAINT FK_Plantel_Adm FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel),
);
GO 


DROP TABLE Docente
CREATE TABLE Docente
(
idplantelf INT,
iddocente INT IDENTITY (1,1),
cplant AS ('DOC'+ RIGHT ('00'+convert (VARCHAR, iddocente),(2))),
horaplanilla VARCHAR (3) NOT NULL,
cargahorariadocente VARCHAR (3) NOT NULL

CONSTRAINT FK_Plantel_Doc FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel),
);
GO
--coddocente INT NOT NULL CONSTRAINT pk_iddoc PRIMARY KEY(coddocente)


-------------------------------------------------------------------------------------
TABLAS PARA REPORTES

DROP TABLE ParteAsistencia
CREATE TABLE ParteAsistencia
(
codparteasistencia INT NOT NULL CONSTRAINT pk_idparteasistencia PRIMARY KEY(codparteasistencia),
fechamesasistido DATE NOT NUL
L,
fechaenvio DATE NOT NULL,
nroplanilla INT NULL,
);
GO

drop table form101
CREATE TABLE form101
(
codform101 INT NOT NULL PRIMARY KEY,
fechapresentacion DATE NOT NULL,
mesform101 NUMERIC(2) NOT NULL,
añoform101 NUMERIC (4) NOT NULL,
idrepjef INT NOT NULL,

CONSTRAINT FK_form_101_idrepjef FOREIGN KEY (idrepjef) REFERENCES JuntaEscolar(codrepje),
);
GO

CREATE TABLE AsistenciaForm101
(
codasisform101 INT NOT NULL,
idform101 INT NOT NULL,
idrepjef INT NOT NULL,
idplantelf INT NOT NULL,
idinstitucionf INT NOT NULL,
idasistenciaf INT NOT NULL,

CONSTRAINT FK_form_101_asistencia FOREGIN KEY (idasistenciaf) REFERENCES Asistencia(codasistencia),
CONSTRAINT FK_form_101_idrepjef FOREIGN KEY (idrepjef) REFERENCES JuntaEscolar(codrepje),
CONSTRAINT FK_form_101_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel),
CONSTRAINT FK_form_101_institucion FOREIGN KEY (idinstitucionf) REFERENCES Institucion (codinstitucion),

);
CREATE TABLE Usuarios
coduser INT  NOT NULL,CONSTRAINT pk_idinst PRIMARY KEY(coduser),
Login VARCHAR (20) NOT NULL,
Pass VARCHAR (20)NOT NULL,
F





 
 
