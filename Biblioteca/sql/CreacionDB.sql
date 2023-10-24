USE MASTER 

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Biblioteca')
    BEGIN
        DROP DATABASE Biblioteca
    END

CREATE DATABASE BIBLIOTECA 

GO

USE BIBLIOTECA 

GO


CREATE TABLE Libro(
	ISBN nvarchar(13) NOT NULL CHECK (ISBN LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') PRIMARY KEY,
	Titulo nvarchar(50) NOT NULL,
	Editorial nvarchar(50) NOT NULL,
	Sinopsis nvarchar(1000) not null,
	Caratula nvarchar(200),
	Unidades int NOT NULL,
	Disponibilidad nvarchar(15) NOT NULL CHECK (Disponibilidad IN ('Prestable','Consulta'))
)

CREATE TABLE Autor(
	ID smallint identity(1,1) PRIMARY KEY,
	Nombre nvarchar(50) NOT NULL
)

CREATE TABLE Categoria(
	ID smallint identity(1,1) PRIMARY KEY,
	Descripcion nvarchar(40)
)

CREATE TABLE Lector(
	NumCarnet smallint identity(1,1) primary key,
	Nombre nvarchar(50) not null,
	Contrasena nvarchar(30) not null,
	Telefono char(9) NOT NULL CHECK(Telefono LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	Email nvarchar(40) not null
)

CREATE TABLE Escribe(
	ISBN_Libro nvarchar(13) NOT NULL CHECK (ISBN_Libro LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	ID_Autor smallint not null
)

ALTER TABLE Escribe
   ADD CONSTRAINT PK_Escribe PRIMARY KEY (ISBN_Libro, ID_Autor)
   

ALTER TABLE Escribe
	ADD CONSTRAINT FK_Autor_Escribe FOREIGN KEY (ID_Autor) REFERENCES Autor(ID) ON UPDATE CASCADE

ALTER TABLE Escribe
	ADD CONSTRAINT FK_Libro_Escribe FOREIGN KEY (ISBN_Libro) REFERENCES Libro(ISBN) ON UPDATE CASCADE

CREATE TABLE Toma_Prestado(
	Fecha_Prestamo DATETIME NOT NULL,
	Fecha_Devolucion DATETIME,
	ISBN_Libro nvarchar(13) NOT NULL CHECK (ISBN_Libro LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	NumCarnet smallint not null
)

ALTER TABLE Toma_Prestado
   ADD CONSTRAINT PK_Toma_Prestado PRIMARY KEY (ISBN_libro, NumCarnet, Fecha_Prestamo)

ALTER TABLE Toma_Prestado
	ADD CONSTRAINT FK_Lector_Toma_Prestado FOREIGN KEY (NumCarnet) REFERENCES Lector(NumCarnet) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE Toma_Prestado
	ADD CONSTRAINT FK_Libro_Toma_Presado FOREIGN KEY (ISBN_Libro) REFERENCES Libro(ISBN) ON DELETE CASCADE ON UPDATE CASCADE


CREATE TABLE Va_Sobre(
	ISBN_Libro nvarchar(13) NOT NULL CHECK (ISBN_Libro LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	ID_Categoria smallint NOT NULL
)

ALTER TABLE Va_Sobre
   ADD CONSTRAINT PK_Libro_Va_Sobre PRIMARY KEY (ISBN_libro, ID_Categoria)

ALTER TABLE Va_Sobre
	ADD CONSTRAINT FK_Categoria_Va_Sobre FOREIGN KEY (ID_Categoria) REFERENCES Categoria(ID) ON UPDATE CASCADE

ALTER TABLE Va_Sobre
	ADD CONSTRAINT FK_Libro_Va_Sobre FOREIGN KEY (ISBN_Libro) REFERENCES Libro(ISBN) ON UPDATE CASCADE ON DELETE CASCADE


GO

CREATE RULE FECHA_MENOR_ACTUAL AS (@CAMPO <= GETDATE()) 
GO
EXEC SP_BINDRULE FECHA_MENOR_ACTUAL, 'Toma_Prestado.Fecha_Prestamo'
EXEC SP_BINDRULE FECHA_MENOR_ACTUAL, 'Toma_Prestado.Fecha_Devolucion'


ALTER TABLE Toma_Prestado
	ADD CONSTRAINT CK_Fechas_Correctas CHECK (Fecha_Prestamo < Fecha_Devolucion)

DBCC CHECKIDENT ('Autor', RESEED, 0);
DBCC CHECKIDENT ('Categoria', RESEED, 0);
DBCC CHECKIDENT ('Lector', RESEED, 0);
