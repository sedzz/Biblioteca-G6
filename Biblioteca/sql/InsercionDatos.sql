USE BIBLIOTECA

DELETE FROM Va_Sobre

DELETE FROM Toma_Prestado

DELETE FROM Escribe

DELETE FROM Autor

DELETE FROM Categoria

DELETE FROM Lector
DELETE FROM LIBRO


DBCC CHECKIDENT ('Autor', RESEED, 0);
DBCC CHECKIDENT ('Categoria', RESEED, 0);
DBCC CHECKIDENT ('Lector', RESEED, 0);



INSERT INTO Autor (Nombre)
VALUES
    ('Miguel de Cervantes'),
    ('Federico Garc�a Lorca'),
    ('Isabel Allende')

INSERT INTO Categoria (Descripcion)
VALUES
    ('Novela'),
    ('Poes�a'),
    ('Historia');

INSERT INTO Lector (Nombre, Contrasena, Telefono, Email)
VALUES
    ('Mar�a P�rez', 'contrase�a1', '123456789', 'maria@gmail.com'),
    ('Juan Rodr�guez', 'contrase�a2', '987654321', 'juan@gmail.com'),
    ('Laura G�mez', 'contrase�a3', '555555555', 'laura@gmail.com');

INSERT INTO Libro (ISBN, Titulo, Editorial, Sinopsis, Caratula, Unidades, Disponibilidad)
VALUES
    ('9788490626407', 'Don Quijote de la Mancha', 'Ediciones C�tedra', 'La obra maestra de la literatura espa�ola.', 'donquijote.jpg', 10, 'Prestable'),
    ('9788437609537', 'Bodas de sangre', 'Espasa Calpe', 'Tragedia l�rica sobre el poder de la pasi�n.', 'bodasdesangre.jpg', 5, 'Prestable'),
    ('9788408113673', 'La casa de los esp�ritus', 'Plaza & Jan�s', 'Una saga familiar en una tierra ficticia de Am�rica del Sur.', 'lacasa.jpg', 8, 'Prestable'),
    ('9780345803481', 'Cincuenta Sombras de Grey', 'Vintage Espanol', 'Un romance sensual y una exploraci�n de los deseos m�s oscuros.', '50sombras.jpg', 12, 'Prestable');

INSERT INTO Escribe (ISBN_Libro, ID_Autor)
VALUES
    ('9788490626407', 1),
    ('9788437609537', 2),
    ('9788408113673', 2),
    ('9780345803481', 1);

INSERT INTO Va_Sobre (ISBN_Libro, ID_Categoria)
VALUES
    ('9788490626407', 1),
    ('9788437609537', 2),
    ('9788408113673', 1),
    ('9780345803481', 1);

INSERT INTO Toma_Prestado (Fecha_Prestamo, Fecha_Devolucion, ISBN_Libro, NumCarnet)
VALUES
    ('9-10-2023', '12-10-2023', '9788490626407', 1),
    ('10-10-2023', '18-10-2023', '9788437609537', 2),
    ('11-10-2023', '15-10-2023', '9788408113673', 3),
    ('12-10-2023', '20-10-2023', '9780345803481', 1);
