CREATE DATABASE Educacion

GO

USE Educacion

GO

/*	Creacion de tablas colegio, usuario, materia y calificaciones	*/
Create table COLEGIO
(
id numeric IDENTITY(1,1) PRIMARY KEY,
nombre varchar(256) unique,
tipoColegio varchar(64)
);

Create table MATERIA
(
id numeric IDENTITY(1,1) PRIMARY KEY,
idColegio numeric,
nombre varchar(256) unique,
area varchar(128),
numeroEstudiantes int,
docenteAsignado varchar(512),
curso varchar(64),
paralelo varchar(16),

CONSTRAINT fk_Colegio FOREIGN KEY (idColegio) REFERENCES COLEGIO (id),
);

Create table USUARIO
(
id numeric IDENTITY(1,1) PRIMARY KEY,
nombreCompleto varchar(256),
username varchar(128) unique,
password varchar(128),
correoElectronico varchar(256),
rol varchar(32),
);

Create table CALIFICACIONES
(
id numeric IDENTITY(1,1) PRIMARY KEY,
idColegio numeric,
idMateria numeric,
idUsuario numeric,
calificacion decimal(2),

CONSTRAINT fk_Colegio_Calificaciones FOREIGN KEY (idColegio) REFERENCES Asignatura (Id),
CONSTRAINT fk_Materia FOREIGN KEY (idMateria) REFERENCES MATERIA (Id),
CONSTRAINT fk_Usuario FOREIGN KEY (idUsuario) REFERENCES USUARIO (Id)
);
