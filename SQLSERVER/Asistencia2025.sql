-- ===================================================
-- SISTEMA DE ASISTENCIA UNIDAD EDUCATIVA 1
-- SCRIPT COMPLETO DE CREACIÓN DE TABLAS
-- ===================================================

-- Crear base de datos
CREATE DATABASE Asistencia2025;
GO

USE Asistencia2025;
GO

-- ===================================================
-- 1. TABLAS MAESTRAS (Sin dependencias)
-- ===================================================

-- Tabla Institucion //2025OK
CREATE TABLE Institucion
(
    codinst INT NOT NULL CONSTRAINT pk_institucion PRIMARY KEY,
    nominst VARCHAR(30) NOT NULL,
    dptoinst VARCHAR(20) NOT NULL,
    nivelinst VARCHAR(15) NOT NULL,
    turnoinst VARCHAR(15) NOT NULL,
    nservicioinst VARCHAR(20) NOT NULL,
    nprogramainst VARCHAR(20) NOT NULL,
    nsieinst VARCHAR(20) NOT NULL,
    mejorarinst VARCHAR(20) NULL,
    direccioninst VARCHAR(50) NOT NULL,
    nucleoescinst VARCHAR(20) NOT NULL,
    subdistinst VARCHAR(20) NOT NULL,
    uvinst VARCHAR(20) NOT NULL,
    mzinst VARCHAR(20) NOT NULL,
    distedinst VARCHAR(20) NOT NULL,
    distmuninst VARCHAR(20) NOT NULL,
    telfuniedinst VARCHAR(15) NOT NULL,
    telfdirectorainst VARCHAR(15) NOT NULL,
    fechacreacion DATETIME DEFAULT GETDATE(),
    fechamodificacion DATETIME GETDATE()
);
GO

-- Tabla Nivel
CREATE TABLE Nivel
(
    codnivel INT IDENTITY(1,1) PRIMARY KEY,
    cni AS ('NI' + RIGHT('00' + CONVERT(VARCHAR, codnivel), 2)),
    nomnivel VARCHAR(20) NOT NULL
);


-- Tabla Paralelo
CREATE TABLE Paralelo
(
    codparalelo INT IDENTITY(1,1) PRIMARY KEY,
    cpar AS ('PAR' + RIGHT('00' + CONVERT(VARCHAR, codparalelo), 2)),
    nomparalelo VARCHAR(5) NOT NULL
);



-- Tabla Actividad
CREATE TABLE Actividad
(
    codact INT NOT NULL CONSTRAINT pk_actividad PRIMARY KEY,
    cact AS ('ACT' + RIGHT('00' + CONVERT(VARCHAR, codact), 2)),
    nomact CHAR(50) NOT NULL,
    fechainiact DATE NOT NULL,
    fechafinact DATE NOT NULL
);
GO


-- Tabla Motivo
CREATE TABLE Motivo
(
    codmotivo INT NOT NULL CONSTRAINT pk_motlicencia PRIMARY KEY,
    cmot AS ('ML' + RIGHT('00' + CONVERT(VARCHAR, codmotivo), 2)),
    motivo VARCHAR(30) NOT NULL
);
GO

-- Tabla Reemplazante

CREATE TABLE Reemplazante
(
    codreemplazante INT IDENTITY(1,1) NOT NULL CONSTRAINT pk_reemplazante PRIMARY KEY,
    creemp AS ('RE' + RIGHT('00' + CONVERT(VARCHAR, codreemplazante), 2)),
    nomreemp VARCHAR(20) NOT NULL,
    appaternoreemp VARCHAR(40) NOT NULL,
    apmaternoreemp VARCHAR(40) NOT NULL
);
GO

-- ==============================
-- TABLA GESTIÓN
-- ==============================
DROP TABLE Gestion
CREATE TABLE Gestion (
    cod_gestion INT PRIMARY KEY IDENTITY(1,1),
    nom_gestion NVARCHAR(50) NOT NULL,
    fechaini_gestion DATE NOT NULL,
    fechafin_gestion DATE NOT NULL
);
-- ==============================
-- TABLA TIPODIA (Catálogo)
-- ==============================
CREATE TABLE TipoDia (
    idtipodia INT PRIMARY KEY IDENTITY(1,1),
    nom_tipodia NVARCHAR(50) NOT NULL
    -- Ej: 'Hábil', 'Feriado Nacional', 'Feriado Departamental',
    --     'Descanso Pedagógico', 'Suspensión'
);
-- ==============================
-- TABLA CALENDARIO ESCOLAR (cada día de la gestión)
-- ==============================
DROP TABLE Calendario_Escolar
CREATE TABLE Calendario_Escolar (
    idcalendario INT PRIMARY KEY IDENTITY(1,1),
    fecha DATE NOT NULL,
    idtipodia INT NOT NULL,
    motivo NVARCHAR(100) NULL,
    cod_gestion INT NOT NULL,

    CONSTRAINT FK_Calendario_TipoDia FOREIGN KEY (idtipodia) REFERENCES TipoDia(idtipodia),
    CONSTRAINT FK_Calendario_Gestion FOREIGN KEY (cod_gestion) REFERENCES Gestion(cod_gestion)
);
-- ==============================
-- TABLA TRIMESTRE/BIMESTRE
-- ==============================
DROP TABLE Periodo
CREATE TABLE Periodo (
    cod_periodo INT PRIMARY KEY IDENTITY(1,1),
    tipo NVARCHAR(20) NOT NULL,  -- 'Trimestre' o 'Bimestre'
    nombre NVARCHAR(50) NOT NULL, -- Ej: '1er Trimestre', '2do Bimestre'
    fechaini DATE NOT NULL,
    fechafin DATE NOT NULL,
    cod_gestion INT NOT NULL,

    CONSTRAINT FK_Periodo_Gestion FOREIGN KEY (cod_gestion) REFERENCES Gestion(cod_gestion)
);

-- ==============================
-- TABLA ACTIVIDAD
-- ==============================
DROP TABLE Actividad
CREATE TABLE Actividad (
    cod_actividad INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    fechaini DATE NOT NULL,
    fechafin DATE NOT NULL,
    cod_periodo INT NOT NULL,

    CONSTRAINT FK_Actividad_Periodo FOREIGN KEY (cod_periodo) REFERENCES Periodo(cod_periodo)
);

-- ==============================
-- TABLA ASISTENCIA
-- ==============================
drop table Asistencia
CREATE TABLE Asistencia (
    id_asistencia INT PRIMARY KEY IDENTITY(1,1),
    fecha DATE NOT NULL,
    cod_gestion INT NOT NULL,
    id_persona INT NOT NULL,   -- FK a Plantel (Docente/Admin)
    horaEntrada TIME NULL,
    horaSalida TIME NULL,
    observacion NVARCHAR(200) NULL,

    -- Relación con gestión
    CONSTRAINT FK_Asistencia_Gestion FOREIGN KEY (cod_gestion) REFERENCES Gestion(cod_gestion)

    -- OJO: aquí no ponemos FK directo a Calendario para mantener flexibilidad,
    -- pero se validará por software que la fecha exista en Calendario_Escolar
);
-- Tabla Usuarios
CREATE TABLE Usuarios
(
    coduser INT NOT NULL CONSTRAINT pk_usuarios PRIMARY KEY,
    nombreusuario VARCHAR(20) NOT NULL CONSTRAINT u_usuario UNIQUE,
    password VARCHAR(100) NOT NULL, -- Para hash de password
    rol VARCHAR(20) NOT NULL DEFAULT 'USUARIO',
    estado CHAR(8) NOT NULL DEFAULT 'ACTIVO' CONSTRAINT ck_estado_usuario CHECK (estado IN ('ACTIVO', 'INACTIVO')),
    fechacreacion DATETIME DEFAULT GETDATE(),
    ultimoacceso DATETIME NULL
);
GO

-- ===================================================
-- 2. TABLAS CON UNA DEPENDENCIA
-- ===================================================

-- Tabla Plantel (Personal de la institución)
DROP TABLE Plantel
CREATE TABLE Plantel
(
    codplantel INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nomplantel CHAR(30) NOT NULL,
    applantel CHAR(30) NULL,              -- sólo estos dos permiten NULL
    amplantel CHAR(30) NULL,
    generoplantel CHAR(9) NOT NULL CONSTRAINT ck_genero_plantel CHECK (generoplantel IN ('MASCULINO','FEMENINO')),
    ciplantel VARCHAR(10) NOT NULL CONSTRAINT u_ci_plantel UNIQUE,
    extplantel CHAR(6) NOT NULL,
    telfplantel CHAR(15) NOT NULL,
    fechanacplantel DATE NOT NULL,
    direccionplantel VARCHAR(50) NULL,
    especialidadplantel CHAR(25) NULL,
    itemplantel VARCHAR(5) NOT NULL CONSTRAINT u_item_plantel UNIQUE,
    rdaplantel VARCHAR(7) NOT NULL CONSTRAINT u_rda_plantel UNIQUE,
    estadoplantel CHAR(8) NOT NULL DEFAULT 'ACTIVO' CONSTRAINT ck_estado_plantel CHECK (estadoplantel IN ('ACTIVO','INACTIVO')),
    idplantel_reemplaza INT NULL, -- recursividad: este plantel reemplaza a otro plantel
    CONSTRAINT FK_Plantel_Reemplaza FOREIGN KEY (idplantel_reemplaza) REFERENCES Plantel(codplantel)
);
GO

-- Tabla JuntaEscolar
DROP TABLE JuntaEscolar
CREATE TABLE JuntaEscolar
(
    codje INT IDENTITY(1,1) NOT NULL CONSTRAINT pk_juntaescolar PRIMARY KEY,
    codigo AS ('JE' + RIGHT('000' + CONVERT(VARCHAR, codje), 3)),
    nomje VARCHAR(25) NOT NULL,
    appaternoje VARCHAR(25) NOT NULL,
    apmaternoje VARCHAR(25) NOT NULL,
    cije VARCHAR(15) NOT NULL CONSTRAINT u_ci_je UNIQUE,
    extje VARCHAR(8) NOT NULL,
    telfje NUMERIC(15) NOT NULL,
    estado VARCHAR(15) NOT NULL DEFAULT 'ACTIVO' CONSTRAINT ck_estado_je CHECK (estado IN ('ACTIVO', 'INACTIVO')),
    fechacreacion DATETIME DEFAULT GETDATE(),
     codcargo INT NOT NULL 
        CONSTRAINT fk_junta_cargo FOREIGN KEY (codcargo)
        REFERENCES Cargo(codcargo)
);
GO

-- Tabla CalendarioEsc
CREATE TABLE CalendarioEsc
(
    codcal INT NOT NULL CONSTRAINT pk_calendarioesc PRIMARY KEY,
    ccal AS ('CAL' + RIGHT('00' + CONVERT(VARCHAR, codcal), 2)),
    nomcal VARCHAR(30) NOT NULL,
    fechainicioesc DATE NOT NULL,
    fechafinesc DATE NOT NULL,
    idgestionf INT NOT NULL,
    CONSTRAINT FK_calendario_gestion FOREIGN KEY (idgestionf) REFERENCES Gestion(codgestion)
);
GO

-- Tabla Curso
CREATE TABLE Curso
(
    codcurso INT IDENTITY(1,1) PRIMARY KEY,
    ccur AS ('CR' + RIGHT('00' + CONVERT(VARCHAR, codcurso), 2)),
    nomcurso VARCHAR(30) NOT NULL,
    idnivelf INT NOT NULL,
    idparalelof INT NOT NULL,
    CONSTRAINT FK_curso_nivel FOREIGN KEY (idnivelf) REFERENCES Nivel(codnivel),
    CONSTRAINT FK_curso_paralelo FOREIGN KEY (idparalelof) REFERENCES Paralelo(codparalelo)
);

-- Tabla Reemplazo
CREATE TABLE Reemplazo
(
    IdReemplazo INT IDENTITY(1,1) PRIMARY KEY,
    IdPlantelSolicita INT NOT NULL,
    IdReemplazante INT NOT NULL,
    FechaSolicitud DATE NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    IdMotivo INT NOT NULL,
    CONSTRAINT FK_Reemplazo_Plantel FOREIGN KEY (IdPlantelSolicita) REFERENCES Plantel(codplantel),
    CONSTRAINT FK_Reemplazo_Reemplazante FOREIGN KEY (IdReemplazante) REFERENCES Reemplazante(codreemplazante),
    CONSTRAINT FK_Reemplazo_Motivo FOREIGN KEY (IdMotivo) REFERENCES Motivo(CodMotivo)
);
GO


-- ===================================================
-- 3. TABLAS QUE DEPENDEN DE PLANTEL
-- ===================================================

-- Tabla Docente
DROP TABLE Docente
CREATE TABLE Docente
(
    iddocente INT NOT NULL PRIMARY KEY DEFAULT NEXT VALUE FOR Seq_Docente,
    idplantelf INT NOT NULL,
    cplant AS ('DOC' + RIGHT('000' + CONVERT(VARCHAR, iddocente), 3)),
    horaplanilla VARCHAR(10) NOT NULL,
    cargahorariadocente VARCHAR(10) NOT NULL,
    CONSTRAINT FK_docente_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel)
);
GO


-- Tabla Administrativo
CREATE TABLE Administrativo
(
    idadm INT NOT NULL PRIMARY KEY DEFAULT NEXT VALUE FOR Seq_Administrativo,
    idplantelf INT NOT NULL,
    cplant AS ('ADM' + RIGHT('000' + CONVERT(VARCHAR, idadm), 3)),
    cargoadm CHAR(30) NOT NULL,
    CONSTRAINT FK_administrativo_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel)
);
GO

-- Tabla TelfPlantel
CREATE TABLE TelfPlantel
(
    idtelef INT IDENTITY(1,1) NOT NULL CONSTRAINT pk_telfplantel PRIMARY KEY,
    telffijo NUMERIC(10) NULL,
    telfcelular NUMERIC(10) NOT NULL CONSTRAINT u_telfcel UNIQUE,
    idplantelf INT NOT NULL,
    CONSTRAINT FK_telfplantel_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel)
);
GO

-- Tabla Huella
CREATE TABLE Huella
(
    codhuella INT NOT NULL CONSTRAINT pk_huella PRIMARY KEY,
    nomhuella VARCHAR(8) NOT NULL CONSTRAINT u_dedo UNIQUE,
    idplantelf INT NOT NULL,
    CONSTRAINT FK_huella_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel)
);
GO

-- Tabla Permiso
CREATE TABLE Permiso
(
    codpermiso INT NOT NULL CONSTRAINT pk_permiso PRIMARY KEY,
    fechasolpermiso DATE NOT NULL,
    hrinipermiso TIME NOT NULL,
    hrfinpermiso TIME NOT NULL,
    idmotperf INT NOT NULL,
    idplantelf INT NOT NULL,
    CONSTRAINT FK_permiso_motpermiso FOREIGN KEY (idmotperf) REFERENCES MotivoPermiso(codmotpermiso),
    CONSTRAINT FK_permiso_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel)
);
GO

-- Tabla Licencia
CREATE TABLE Licencia
(
    codlicencia INT NOT NULL CONSTRAINT pk_licencia PRIMARY KEY,
    clic AS ('LIC' + RIGHT('00' + CONVERT(VARCHAR, codlicencia), 2)),
    fechasollic DATE NOT NULL,
    fechainilic DATE NOT NULL,
    fechafinlic DATE NOT NULL,
    idplantelf INT NOT NULL,
    idmotlicf INT NOT NULL,
    idreemplazantef INT NOT NULL,
    CONSTRAINT FK_licencia_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel),
    CONSTRAINT FK_licencia_motlicencia FOREIGN KEY (idmotlicf) REFERENCES MotivoLicencia(codmotivolicencia),
    CONSTRAINT FK_licencia_reemplazante FOREIGN KEY (idreemplazantef) REFERENCES Reemplazante(codreemplazante)
);
GO

-- ===================================================
-- 4. TABLAS DE CALENDARIO Y ACTIVIDADES
-- ===================================================

-- Tabla Bimestre
CREATE TABLE Bimestre
(
    codbim INT NOT NULL CONSTRAINT pk_bimestre PRIMARY KEY,
    cbim AS ('BIM' + RIGHT('00' + CONVERT(VARCHAR, codbim), 2)),
    nombim VARCHAR(30) NOT NULL,
    fechainibim DATE NOT NULL,
    fechafinbim DATE NOT NULL,
    idcalf INT NOT NULL,
    CONSTRAINT FK_bimestre_calendario FOREIGN KEY (idcalf) REFERENCES CalendarioEsc(codcal)
);
GO

-- Tabla ActBim (Relación Actividad-Bimestre)
CREATE TABLE ActBim
(
    codactbim INT NOT NULL CONSTRAINT pk_actbim PRIMARY KEY,
    idactividadf INT NOT NULL,
    idbimestref INT NOT NULL,
    CONSTRAINT FK_actbim_actividad FOREIGN KEY (idactividadf) REFERENCES Actividad(codact),
    CONSTRAINT FK_actbim_bimestre FOREIGN KEY (idbimestref) REFERENCES Bimestre(codbim)
);
GO

-- ===================================================
-- 5. TABLAS DE HORARIOS Y ASIGNACIONES
-- ===================================================

-- Tabla Materia
CREATE TABLE Materia
(
    codmateria INT IDENTITY(1,1) PRIMARY KEY,
    cmat AS ('MAT' + RIGHT('00' + CONVERT(VARCHAR, codmateria), 2)),
    nommateria VARCHAR(50) NOT NULL,
    sigla VARCHAR(10) NOT NULL
);


-- Tabla Asignacion
CREATE TABLE Asignacion
(
    codasignacion INT IDENTITY(1,1) PRIMARY KEY,
    casig AS ('ASG' + RIGHT('00' + CONVERT(VARCHAR, codasignacion), 2)),
    dia VARCHAR(10) NOT NULL,
    horainicio TIME NOT NULL,
    horafin TIME NOT NULL,
    idmateriaf INT NOT NULL,
    idcursof INT NOT NULL,
    iddocentef INT NOT NULL,
    CONSTRAINT FK_asignacion_materia FOREIGN KEY (idmateriaf) REFERENCES Materia(codmateria),
    CONSTRAINT FK_asignacion_curso FOREIGN KEY (idcursof) REFERENCES Curso(codcurso),
    CONSTRAINT FK_asignacion_docente FOREIGN KEY (iddocentef) REFERENCES Docente(iddocente)
);

GO
--HORARIO ADMINISTRATIVO
DROP TABLE HorarioAdministrativo

CREATE TABLE HorarioAdministrativo (
    idhorarioadm INT IDENTITY(1,1) PRIMARY KEY,
    idadm INT NOT NULL,
    diaSemana VARCHAR(15) NOT NULL,
    horaEntrada TIME NOT NULL,
    horaSalida TIME NOT NULL,
    horaRecesoInicio TIME NULL,
    horaRecesoFin TIME NULL,
    toleranciaMinutos INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Horario_Admin FOREIGN KEY (idadm) REFERENCES Administrativo(idadm)
);
--HORARIO DOCENTE
CREATE TABLE HorarioDocente (
    idhorariodoc INT IDENTITY(1,1) PRIMARY KEY,
    iddocente INT NOT NULL,
    codmateria INT NOT NULL,
    codcurso INT NOT NULL,
    codparalelo INT NOT NULL,
    diaSemana VARCHAR(15) NOT NULL,     -- LUNES, MARTES, etc.
    horaInicio TIME NOT NULL,
    horaFin TIME NOT NULL,
    horaRecesoInicio TIME NULL,
    horaRecesoFin TIME NULL,
    toleranciaMinutos INT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Horario_Docente FOREIGN KEY (iddocente) REFERENCES Docente(iddocente),
    CONSTRAINT FK_Horario_Materia FOREIGN KEY (codmateria) REFERENCES Materia(codmateria),
    CONSTRAINT FK_Horario_Curso FOREIGN KEY (codcurso) REFERENCES Curso(codcurso),
    CONSTRAINT FK_Horario_Paralelo FOREIGN KEY (codparalelo) REFERENCES Paralelo(codparalelo)
);



-- ===================================================
-- 6. TABLAS DE JUNTA ESCOLAR
-- ===================================================


-- Tabla Cargos (tipos de cargo disponibles, catálogo)
DROP TABLE Cargo
CREATE TABLE Cargo (
    codcargo INT IDENTITY(1,1) PRIMARY KEY,
    ccar AS ('CRG' + RIGHT('00' + CONVERT(VARCHAR, codcargo), 2)),
    nomcargo VARCHAR(25) NOT NULL  -- Presidente, Vicepresidente, etc.
);
GO

-- Tabla de historial de asignación de cargos
DROP TABLE CargoHistorial 
CREATE TABLE CargoHistorial (
    idhistorial INT IDENTITY(1,1) PRIMARY KEY,
    codje INT NOT NULL,       -- representante
    codcargo INT NOT NULL,       -- tipo de cargo
    fecha_inicio DATE NOT NULL,  -- cuándo asumió
    fecha_fin DATE NULL,         -- cuándo terminó (NULL = sigue vigente)
    CONSTRAINT FK_historial_rep FOREIGN KEY (codje) REFERENCES JuntaEscolar(codje),
    CONSTRAINT FK_historial_cargo FOREIGN KEY (codcargo) REFERENCES Cargo(codcargo)
);
GO


-- ===================================================
-- 7. TABLAS DE REPORTES Y FORMULARIOS
-- ===================================================

-- Tabla ParteAsistencia
CREATE TABLE ParteAsistencia
(
    codparteasistencia INT NOT NULL CONSTRAINT pk_parteasistencia PRIMARY KEY,
    fechamesasistido DATE NOT NULL,
    fechaenvio DATE NOT NULL,
    nroplanilla INT NULL,
    observaciones TEXT NULL
);
GO

-- Tabla Form101
CREATE TABLE Form101
(
    codform101 INT NOT NULL CONSTRAINT pk_form101 PRIMARY KEY,
    fechapresentacion DATE NOT NULL,
    mesform101 NUMERIC(2) NOT NULL,
    anoform101 NUMERIC(4) NOT NULL,
    idrepjef INT NOT NULL,
    CONSTRAINT FK_form101_juntaescolar FOREIGN KEY (idrepjef) REFERENCES JuntaEscolar(codrepje)
);
GO

-- ===================================================
-- 8. TABLA PRINCIPAL DE ASISTENCIA
-- ===================================================

-- Tabla Asistencia (Principal)
CREATE TABLE Asistencia
(
    codasistencia INT NOT NULL CONSTRAINT pk_asistencia PRIMARY KEY,
    fecha DATE NOT NULL,
    horario TIME NOT NULL,
    estado VARCHAR(10) NOT NULL CONSTRAINT ck_estado_asistencia CHECK (estado IN ('PRESENTE', 'AUSENTE', 'TARDANZA', 'FALTA', 'JUSTIFICADA')),
    observaciones VARCHAR(100) NULL,
    idplantelf INT NOT NULL,
    idhuellaf INT NOT NULL,
    idparteasisf INT NOT NULL,
    idform101f INT NOT NULL,
    idgestionf INT NOT NULL,
    idcalescf INT NOT NULL,
    CONSTRAINT FK_asistencia_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel),
    CONSTRAINT FK_asistencia_huella FOREIGN KEY (idhuellaf) REFERENCES Huella(codhuella),
    CONSTRAINT FK_asistencia_parteasistencia FOREIGN KEY (idparteasisf) REFERENCES ParteAsistencia(codparteasistencia),
    CONSTRAINT FK_asistencia_form101 FOREIGN KEY (idform101f) REFERENCES Form101(codform101),
    CONSTRAINT FK_asistencia_gestion FOREIGN KEY (idgestionf) REFERENCES Gestion(codgestion),
    CONSTRAINT FK_asistencia_calendarioesc FOREIGN KEY (idcalescf) REFERENCES CalendarioEsc(codcal)
);
GO

-- ===================================================
-- 9. TABLA DE RELACIÓN FORMULARIO-ASISTENCIA
-- ===================================================

-- Tabla AsistenciaForm101
CREATE TABLE AsistenciaForm101
(
    codasisform101 INT NOT NULL CONSTRAINT pk_asistenciaform101 PRIMARY KEY,
    idform101f INT NOT NULL,
    idrepjef INT NOT NULL,
    idplantelf INT NOT NULL,
    idinstitucionf INT NOT NULL,
    idasistenciaf INT NOT NULL,
    CONSTRAINT FK_asistenciaform101_form101 FOREIGN KEY (idform101f) REFERENCES Form101(codform101),
    CONSTRAINT FK_asistenciaform101_juntaescolar FOREIGN KEY (idrepjef) REFERENCES JuntaEscolar(codrepje),
    CONSTRAINT FK_asistenciaform101_plantel FOREIGN KEY (idplantelf) REFERENCES Plantel(codplantel),
    CONSTRAINT FK_asistenciaform101_institucion FOREIGN KEY (idinstitucionf) REFERENCES Institucion(codinst),
    CONSTRAINT FK_asistenciaform101_asistencia FOREIGN KEY (idasistenciaf) REFERENCES Asistencia(codasistencia)
);
GO

-- ===================================================
-- 10. ÍNDICES PARA OPTIMIZACIÓN
-- ===================================================

-- Índices en campos más consultados
CREATE INDEX IX_Asistencia_Fecha ON Asistencia(fecha);
CREATE INDEX IX_Asistencia_Plantel ON Asistencia(idplantelf);
CREATE INDEX IX_Plantel_CI ON Plantel(ciplantel);
CREATE INDEX IX_Plantel_Item ON Plantel(itemplantel);
CREATE INDEX IX_Docente_Plantel ON Docente(idplantelf);
CREATE INDEX IX_Administrativo_Plantel ON Administrativo(idplantelf);
CREATE INDEX IX_Asignacion_Docente ON Asignacion(iddocentef);
CREATE INDEX IX_Asignacion_Curso ON Asignacion(idcursof);
GO

-- ===================================================
-- 11. TRIGGERS PARA AUDITORÍA (OPCIONAL)
-- ===================================================

-- Trigger para auditar cambios en Plantel
CREATE TRIGGER TR_Plantel_Update
ON Plantel
AFTER UPDATE
AS
BEGIN
    UPDATE Plantel 
    SET fechamodificacion = GETDATE()
    WHERE codplantel IN (SELECT codplantel FROM inserted);
END;
GO

-- ===================================================
-- MENSAJE DE CONFIRMACIÓN
-- ===================================================
PRINT 'Base de datos AsistenciaUE1 creada exitosamente';
PRINT 'Total de tablas creadas: 23';
PRINT 'Índices de optimización: 8';
PRINT 'Triggers de auditoría: 1';
GO