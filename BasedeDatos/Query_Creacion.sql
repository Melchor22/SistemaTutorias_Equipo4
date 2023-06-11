CREATE DATABASE SistemaTutorias;

USE SistemaTutorias;

CREATE TABLE PeriodosEscolares (
	IDPeriodoEscolar INT IDENTITY(1,1) PRIMARY KEY,
	FechaInicio DATETIME,
	FechaFin DATETIME
);

CREATE TABLE CategoriasProblematica (
	IDCategoria INT IDENTITY(1,1) PRIMARY KEY,
	Tipo NVARCHAR(100)
);

CREATE TABLE Roles (
	IDRol INT IDENTITY(1,1) PRIMARY KEY,
	NombreRol NVARCHAR(50)
);

CREATE TABLE Academicos (
	NumPersonal NVARCHAR(25) PRIMARY KEY,
	Nombres NVARCHAR(50),
	ApellidoPaterno NVARCHAR(50),
	ApellidoMaterno NVARCHAR(50),
	Correo NVARCHAR(80),
	Telefono NVARCHAR(15)
);

CREATE TABLE AreasAcademicas (
	IDAreaAcademica INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(40)
);

CREATE TABLE ProgramasEducativos (
	IDProgramaEducativo INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(150),
	IDAreaAcademica INT,
	FOREIGN KEY (IDAreaAcademica) REFERENCES AreasAcademicas(IDAreaAcademica)
);

CREATE TABLE Estudiantes (
	Matricula NVARCHAR(10) PRIMARY KEY,
	Nombres NVARCHAR(50),
	ApellidoPaterno NVARCHAR(50),
	ApellidoMaterno NVARCHAR(50),
	Correo NVARCHAR(80),
	Telefono NVARCHAR(15),
	IDProgramaEducativo INT,
	FOREIGN KEY (IDProgramaEducativo) REFERENCES ProgramasEducativos(IDProgramaEducativo)
);

CREATE TABLE ExperienciasEducativas (
	NRC INT PRIMARY KEY,
	Nombre NVARCHAR(100),
	Creditos INT,
	NumPersonal NVARCHAR(25),
	FOREIGN KEY (NumPersonal) REFERENCES Academicos(NumPersonal)
);

CREATE TABLE ExperienciasEducativasEstudiantes (
	IDExperienciaEducativaEstudiante INT IDENTITY(1,1) PRIMARY KEY,
	NRC INT,
	Matricula NVARCHAR(10),
	FOREIGN KEY (NRC) REFERENCES ExperienciasEducativas(NRC),
	FOREIGN KEY (Matricula) REFERENCES Estudiantes(Matricula)
);

CREATE TABLE RolesAcademicos (
	IDRolAcademico INT IDENTITY(1,1) PRIMARY KEY,
	[Password] NVARCHAR(20),
	IDRol INT,
	NumPersonal NVARCHAR(25),
	FOREIGN KEY (IDRol) REFERENCES Roles(IDRol),
	FOREIGN KEY (NumPersonal) REFERENCES Academicos(NumPersonal)
);

CREATE TABLE ReportesGenerales (
	IDReporteGeneral INT IDENTITY(1,1) PRIMARY KEY,
	Descripcion NTEXT,
	ComentarioGeneral NVARCHAR(500),
	IDRolAcademico INT,
	FOREIGN KEY (IDRolAcademico) REFERENCES RolesAcademicos(IDRolAcademico)
);

CREATE TABLE ReportesTutoria (
	IDReporteTutoria INT IDENTITY(1,1) PRIMARY KEY,
	Descripcion NTEXT,
	ComentarioGeneral NVARCHAR(500),
	IDTutoriaAcademica INT
);

CREATE TABLE TutoriasAcademicas (
	IDTutoriaAcademica INT IDENTITY(1,1) PRIMARY KEY,
	Duracion TIME,
	Fecha DATETIME,
	NumSesion INT,
	IDRolAcademico INT,
	IDReporteTutoria INT,
	IDPeriodoEscolar INT,
	FOREIGN KEY (IDRolAcademico) REFERENCES RolesAcademicos(IDRolAcademico),
	FOREIGN KEY (IDReporteTutoria) REFERENCES ReportesTutoria(IDReporteTutoria),
	FOREIGN KEY (IDPeriodoEscolar) REFERENCES PeriodosEscolares(IDPeriodoEscolar)
);

ALTER TABLE TutoriasAcademicas ADD FechaCierre DATETIME;

ALTER TABLE ReportesTutoria
ADD CONSTRAINT FK_ReportesTutoria_TutoriasAcademicas FOREIGN KEY (IDTutoriaAcademica)
REFERENCES TutoriasAcademicas (IDTutoriaAcademica);

CREATE TABLE TutoriasAcademicasEstudiantes (
	IDTutoriaAcademicaestudiante INT IDENTITY(1,1) PRIMARY KEY,
	IDTutoriaAcademica INT,
	Matricula NVARCHAR(10),
	FOREIGN KEY (IDTutoriaAcademica) REFERENCES TutoriasAcademicas(IDTutoriaAcademica),
	FOREIGN KEY (Matricula) REFERENCES Estudiantes(Matricula)
);

CREATE TABLE ProblematicasAcademicas (
	IDProblematicaAcademica INT IDENTITY(1,1) PRIMARY KEY,
	Estado NVARCHAR(15),
	Descripcion NTEXT,
	IDCategoria INT,
	IDTutoriaAcademicaEstudiante INT,
	NRC INT,
	FOREIGN KEY (IDCategoria) REFERENCES CategoriasProblematica(IDCategoria),
	FOREIGN KEY (IDTutoriaAcademicaEstudiante) REFERENCES TutoriasAcademicasEstudiantes(IDTutoriaAcademicaEstudiante),
	FOREIGN KEY (NRC) REFERENCES ExperienciasEducativas(NRC)
);

ALTER TABLE ProblematicasAcademicas ADD Solucion NTEXT;