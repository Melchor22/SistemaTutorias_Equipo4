CREATE DATABASE SistemaTutorias;

USE SistemaTutorias;

CREATE TABLE PeriodosEscolares (
	IDPeriodoEscolar INT IDENTITY(1,1) PRIMARY KEY,
	FechaInicio DATETIME NOT NULL,
	FechaFin DATETIME NOT NULL
);

CREATE TABLE CategoriasProblematica (
	IDCategoria INT IDENTITY(1,1) PRIMARY KEY,
	Tipo NVARCHAR(100) NOT NULL
);

CREATE TABLE Roles (
	IDRol INT IDENTITY(1,1) PRIMARY KEY,
	NombreRol NVARCHAR(50) NOT NULL
);

CREATE TABLE Academicos (
	NumPersonal NVARCHAR(25) PRIMARY KEY,
	Nombres NVARCHAR(50) NOT NULL,
	ApellidoPaterno NVARCHAR(50),
	ApellidoMaterno NVARCHAR(50),
	Correo NVARCHAR(80),
	Telefono NVARCHAR(15)
);

CREATE TABLE AreasAcademicas (
	IDAreaAcademica INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(40) NOT NULL
);

CREATE TABLE ProgramasEducativos (
	IDProgramaEducativo INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(150) NOT NULL,
	IDAreaAcademica INT NOT NULL,
	FOREIGN KEY (IDAreaAcademica) REFERENCES AreasAcademicas(IDAreaAcademica)
);

CREATE TABLE Estudiantes (
	Matricula NVARCHAR(10) PRIMARY KEY,
	Nombres NVARCHAR(50) NOT NULL,
	ApellidoPaterno NVARCHAR(50),
	ApellidoMaterno NVARCHAR(50),
	Correo NVARCHAR(80),
	Telefono NVARCHAR(15),
	IDProgramaEducativo INT NOT NULL,
	FOREIGN KEY (IDProgramaEducativo) REFERENCES ProgramasEducativos(IDProgramaEducativo)
);

CREATE TABLE ExperienciasEducativas (
	NRC INT PRIMARY KEY,
	Nombre NVARCHAR(100) NOT NULL,
	Creditos INT NOT NULL,
	NumPersonal NVARCHAR(25) NOT NULL,
	FOREIGN KEY (NumPersonal) REFERENCES Academicos(NumPersonal)
);

CREATE TABLE ExperienciasEducativasEstudiantes (
	IDExperienciaEducativaEstudiante INT IDENTITY(1,1) PRIMARY KEY,
	NRC INT NOT NULL,
	Matricula NVARCHAR(10) NOT NULL,
	FOREIGN KEY (NRC) REFERENCES ExperienciasEducativas(NRC),
	FOREIGN KEY (Matricula) REFERENCES Estudiantes(Matricula)
);

CREATE TABLE RolesAcademicos (
	IDRolAcademico INT IDENTITY(1,1) PRIMARY KEY,
	[Password] NVARCHAR(20) NOT NULL,
	IDRol INT NOT NULL,
	NumPersonal NVARCHAR(25) NOT NULL,
	FOREIGN KEY (IDRol) REFERENCES Roles(IDRol),
	FOREIGN KEY (NumPersonal) REFERENCES Academicos(NumPersonal)
);

CREATE TABLE ReportesGenerales (
	IDReporteGeneral INT IDENTITY(1,1) PRIMARY KEY,
	Descripcion NTEXT NOT NULL,
	ComentarioGeneral NVARCHAR(500) NOT NULL,
	IDRolAcademico INT NOT NULL,
	FOREIGN KEY (IDRolAcademico) REFERENCES RolesAcademicos(IDRolAcademico)
);

CREATE TABLE ReportesTutoria (
	IDReporteTutoria INT IDENTITY(1,1) PRIMARY KEY,
	Descripcion NTEXT NOT NULL,
	ComentarioGeneral NVARCHAR(500) NOT NULL,
	IDTutoriaAcademica INT NOT NULL
);

CREATE TABLE TutoriasAcademicas (
	IDTutoriaAcademica INT IDENTITY(1,1) PRIMARY KEY,
	Duracion TIME,
	Fecha DATETIME NOT NULL,
	NumSesion INT NOT NULL,
	IDReporteTutoria INT,
	IDPeriodoEscolar INT NOT NULL,
	FOREIGN KEY (IDReporteTutoria) REFERENCES ReportesTutoria(IDReporteTutoria),
	FOREIGN KEY (IDPeriodoEscolar) REFERENCES PeriodosEscolares(IDPeriodoEscolar)
);

ALTER TABLE ReportesTutoria
ADD CONSTRAINT FK_ReportesTutoria_TutoriasAcademicas FOREIGN KEY (IDTutoriaAcademica)
REFERENCES TutoriasAcademicas (IDTutoriaAcademica);

CREATE TABLE TutoriasAcademicasEstudiantes (
	IDTutoriaAcademicaestudiante INT IDENTITY(1,1) PRIMARY KEY,
	IDTutoriaAcademica INT NOT NULL,
	Matricula NVARCHAR(10) NOT NULL,
	FOREIGN KEY (IDTutoriaAcademica) REFERENCES TutoriasAcademicas(IDTutoriaAcademica),
	FOREIGN KEY (Matricula) REFERENCES Estudiantes(Matricula)
);

CREATE TABLE ProblematicasAcademicas (
	IDProblematicaAcademica INT IDENTITY(1,1) PRIMARY KEY,
	Estado NVARCHAR(15) NOT NULL,
	Descripcion NTEXT NOT NULL,
	IDCategoria INT NOT NULL,
	IDTutoriaAcademica INT NOT NULL,
	NRC INT,
	FOREIGN KEY (IDCategoria) REFERENCES CategoriasProblematica(IDCategoria),
	FOREIGN KEY (IDTutoriaAcademica) REFERENCES TutoriasAcademicas(IDTutoriaAcademica),
	FOREIGN KEY (NRC) REFERENCES ExperienciasEducativas(NRC)
);