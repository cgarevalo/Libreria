CREATE PROCEDURE storedAltaUsuario
@User varchar(50),
@pass varchar(50),
@jerarquia bit
AS
INSERT INTO Usuarios (Usuario, Contraseña, Jerarquia)
OUTPUT inserted.Id
VALUES(@User, @pass, @jerarquia)