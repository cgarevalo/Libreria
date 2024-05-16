USE [Libreria_DB]
GO

CREATE PROCEDURE storedListarLibros AS
SELECT Titulo, Autor, L.Descripcion, Editorial, Activo, Lsbn, NumeroPaginas, I.Descripcion AS descIdioma, G.Descripcion AS descGenero, L.IdGenero , L.IdIdioma, L.Id, FechaPublicacion, ImagenPortada, OrigenImagen
FROM Libros L, Generos G, Idiomas I
WHERE G.Id = L.IdGenero AND I.Id = L.IdIdioma

go

CREATE PROCEDURE storedListarCompleto AS
SELECT L.Titulo, L.Autor, L.Descripcion, L.Editorial, L.Activo, L.Lsbn, L.NumeroPaginas, I.Descripcion AS descIdioma, G.Descripcion AS descGenero, L.IdGenero, L.IdIdioma, L.Id, L.FechaPublicacion, L.ImagenPortada, L.OrigenImagen
FROM Libros L
INNER JOIN Generos G ON L.IdGenero = G.Id
INNER JOIN Idiomas I ON L.IdIdioma = I.Id
WHERE L.Activo = 1

go

CREATE procedure storedAltaLibro
@titulo varchar(100),
@autor varchar(100),
@descripcion varchar(300),
@imagenPortada varchar(500),
@fechaPublicacion Date,
@idGenero int,
@idIdioma int,
@numeroPaginas int,
@editorial varchar(100),
@lsbn varchar(300),
@origenImagen varchar(20) 
AS
INSERT INTO Libros (Titulo, Autor, Descripcion, ImagenPortada, FechaPublicacion, IdGenero, IdIdioma, NumeroPaginas, Editorial, Lsbn, Activo, OrigenImagen) 
VALUES(@titulo, @autor, @descripcion, @imagenPortada, @fechaPublicacion, @idGenero, @idIdioma, @numeroPaginas, @editorial, @lsbn, 1, @origenImagen)

go

CREATE procedure storedModificarLibro
@titulo varchar(100),
@autor varchar(100),
@descripcion varchar(300),
@imagenPortada varchar(500),
@fechaPublicacion Date,
@idGenero int,
@idIdioma int,
@numeroPaginas int,
@editorial varchar(100),
@lsbn varchar(300),
@id int,
@origenImagen varchar(20)
AS
UPDATE Libros SET Titulo = @titulo, Autor = @autor, Descripcion = @descripcion, ImagenPortada = @imagenPortada, FechaPublicacion = @fechaPublicacion, IdGenero = @idGenero, IdIdioma = @idIdioma, NumeroPaginas = @numeroPaginas, Editorial = @editorial, Lsbn = @lsbn, OrigenImagen = @origenImagen
WHERE Id = @id