use master
go
create database LEROSE_DB
go
use LEROSE_DB
go
USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

---------------------------------------------------------------------------------

USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[_EstadoVenta](
	[Id] [int] NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[BorradoLogico] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

---------------------------------------------------------------------------------

USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[NumeroDocumento] [bigint] NULL,
	[SuperUsuario] [bit] NULL,
	[Mail] [varchar](255) NULL,
	[Clave] [varchar](255) NULL,
	[BorradoLogico] [bit] NULL,
	[Fecha] [datetime] NULL,
	[Calle] [varchar](255) NULL,
	[NumeroCalle] [bigint] NULL,
	[Localidad] [varchar](255) NULL,
	[Provincia] [varchar](255) NULL,
	[CodigoPostal] [bigint] NULL,
	[Telefono] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


---------------------------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Marcas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[BorradoLogico] [bit] NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



---------------------------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[BorradoLogico] [bit] NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


---------------------------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](255) NULL,
	[Descripcion] [varchar](255) NULL,
	[Id_Marca] [int] NULL,
	[Id_Categoria] [int] NULL,
	[Imagen] [varchar](1000) NULL,
	[Precio] [money] NULL,
	[Fecha] [datetime] NULL,
	[Id_Usuario] [int] NULL,
	[BorradoLogico] [bit] NULL,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD FOREIGN KEY([Id_Categoria])
REFERENCES [dbo].[Categorias] ([Id])
GO

ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD FOREIGN KEY([Id_Marca])
REFERENCES [dbo].[Marcas] ([Id])
GO

ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO


---------------------------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Carrito](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [decimal](18, 0) NULL,
	[BorradoLogico] [bit] NULL,
	[Id_Usuario] [int] NULL,
	[Fecha] [datetime] NULL,
	[Id_EstadoVenta] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD FOREIGN KEY([Id_EstadoVenta])
REFERENCES [dbo].[_EstadoVenta] ([Id])
GO

ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO


---------------------------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticulosPorCarrito](
	[Id_Articulo] [int] NULL,
	[Id_Carrito] [int] NULL,
	[PrecioEnVenta] [money] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ArticulosPorCarrito]  WITH CHECK ADD FOREIGN KEY([Id_Articulo])
REFERENCES [dbo].[Articulos] ([Id])
GO

ALTER TABLE [dbo].[ArticulosPorCarrito]  WITH CHECK ADD FOREIGN KEY([Id_Carrito])
REFERENCES [dbo].[Carrito] ([Id])
GO



---------------------------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FormaPago](
	[Id] [int] NOT NULL,
	[NumeroTarjeta] [bigint] NULL,
	[NombreTitular] [varchar](255) NULL,
	[VencimientoDia] [int] NULL,
	[VencimientoMes] [int] NULL,
	[CodigoSeguridad] [int] NULL,
	[Id_Usuario] [int] NULL,
	[Fecha] [datetime] NULL,
	[BorradoLogico] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FormaPago]  WITH CHECK ADD FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO

ALTER TABLE [dbo].[FormaPago]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_FormaPago] FOREIGN KEY([Id])
REFERENCES [dbo].[Carrito] ([Id])
GO

ALTER TABLE [dbo].[FormaPago] CHECK CONSTRAINT [FK_Carrito_FormaPago]
GO



---------------------------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ConsultaUsuarios] AS
SELECT * FROM Usuario
GO


---------------------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ConsultaVentas] AS
SELECT 
c.Id as Id,
c.Fecha as Fecha,
c.Monto as Monto,
e.Id as IdEstado,
e.Descripcion as Estado
FROM Carrito c
LEFT JOIN _EstadoVenta e ON e.Id = c.Id_EstadoVenta
GO


---------------------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[GetEstados] AS
SELECT * FROM _EstadoVenta
GO


---------------------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[LeerCarritoId] AS
SELECT TOP (1) Id
FROM Carrito c order by c.Id desc

GO


---------------------------------------------------------------------------------

USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create PROCEDURE [dbo].[AltaArticulo]
(
@codigo varchar (255),
@nombre varchar (255),
@descripcion varchar (255),
@idMarca int,
@idCategoria int,
@imagen varchar (255),
@precio money,
@fecha datetime,
@usuario int,
@borrado bit
)
AS
BEGIN

INSERT INTO Articulos VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagen, @precio, @fecha, @usuario, @borrado)

END
GO

------------------------------------------------------------

USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AltaCategoria]
(
@descripcion varchar (255),
@borrado bit
)
AS
BEGIN

INSERT INTO Categorias VALUES (@descripcion, @borrado)

END
GO


------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AltaMarca]
(
@descripcion varchar (255),
@borrado bit
)
AS
BEGIN

INSERT INTO Marcas VALUES (@descripcion, @borrado)

END
GO

----------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create PROCEDURE [dbo].[BajaArticulo]
(
@id int
)
AS
BEGIN


UPDATE Articulos SET BorradoLogico = 1 WHERE Id = @id
END
GO


-------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[BajaCategoria]
(
@id int
)
AS
BEGIN

UPDATE Categorias SET BorradoLogico = 1 WHERE Id = @id

END
GO


------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[BajaMarca]
(
@id int
)
AS
BEGIN

UPDATE Marcas SET BorradoLogico = 1 WHERE Id = @id

END
GO


--------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetArticulosCarrito]
@id int
AS
SELECT 
art.Id AS Id,
art.Codigo AS Codigo,
art.Nombre AS Nombre,
art.Imagen AS Imagen,
art.Precio AS Precio
FROM Articulos art
INNER JOIN ArticulosPorCarrito apc ON apc.Id_Articulo = art.Id
INNER JOIN Carrito car ON car.Id = apc.Id_Carrito
WHERE car.Id = @id

GO


---------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetComprasUsuario]
@id int
AS
SELECT 
car.Id AS Id,
car.Monto AS Monto,
car.Fecha AS Fecha
FROM Carrito car
WHERE car.Id = @id

GO


-----------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GuardarCarrito]
(
@fecha datetime,
@usuario int,
@borrado bit,
@monto money,
@estado int
)
AS
BEGIN

INSERT INTO [Carrito]
           ([Monto]
           ,[BorradoLogico]
           ,[Id_Usuario]
           ,[Fecha],
		   Id_EstadoVenta)
VALUES 
(@monto, @borrado, @usuario, @fecha, @estado)


END
GO


---------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create PROCEDURE [dbo].[GuardarListaArticulos]

(@articulo int, @carrito int, @precio money)

AS
BEGIN

INSERT INTO [dbo].[ArticulosPorCarrito]
           ([Id_Articulo]
           ,[Id_Carrito]
           ,[PrecioEnVenta])
     VALUES
           (@articulo
           ,@carrito
           ,@precio)

END
GO


-------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GuardarPago]
(
@id int,
@fecha datetime,
@usuario int,
@borrado bit,
@numeroTarjeta bigint, 
@nombreTitular varchar(255), 
@vencimientoDia int, 
@vencimientoMes int, 
@codigoSeguridad int 
)
AS
BEGIN


INSERT INTO [dbo].FormaPago 
(
           Id
           ,[NumeroTarjeta]
           ,[NombreTitular]
           ,[VencimientoDia]
           ,[VencimientoMes]
           ,[CodigoSeguridad]
           ,[BorradoLogico]
           ,[Id_Usuario]
           ,[Fecha])
VALUES 
(@id,
@numeroTarjeta,
@nombreTitular,
@vencimientoDia, 
@vencimientoMes,
@codigoSeguridad, 
@borrado, 
@usuario, 
@fecha)


 
END
GO


--------------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Loguear]

@mail varchar(255),
@clave varchar(255)

AS

select
usu.Id,
usu.Nombre,
usu.NumeroDocumento,
usu.SuperUsuario,
usu.Fecha
from Usuario usu 
Where usu.Mail = @mail 
and usu.Clave = @clave

GO


------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[ModificarArticulo]
(
@id int,
@codigo varchar (255),
@nombre varchar (255),
@descripcion varchar (255),
@idMarca int,
@idCategoria int,
@imagen varchar (255),
@precio money,
@fecha datetime,
@usuario int,
@borrado bit
)
AS
BEGIN

UPDATE Articulos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, Id_Marca = @idMarca, Id_Categoria = @idCategoria, Imagen = @imagen, Precio = @precio WHERE Id = @id

END
GO


------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ModificarCategoria]
(
@id int,
@descripcion varchar (255)
)
AS
BEGIN

UPDATE Categorias
set Descripcion = @descripcion
WHERE Id = @id

END
GO


-------------------------------------------------------------------


USE LEROSE_DB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[ModificarEstado]
(
@id int,
@estado int
)
AS
BEGIN

UPDATE Carrito
set Id_EstadoVenta = @estado
WHERE Id = @id

END
GO


-----------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ModificarMarca]
(
@id int,
@descripcion varchar (255)
)
AS
BEGIN

UPDATE Marcas
set Descripcion = @descripcion
WHERE Id = @id

END
GO


-----------------------------------------------------------------------------


USE LEROSE_DB
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[Registrar]
(
@fecha datetime,
@borrado bit,
@nombre varchar(255), 
@documento bigint,
@mail varchar(255), 
@calle varchar(255), 
@nrCalle bigint, 
@localidad varchar(255), 
@provincia varchar(255), 
@postal bigint, 
@telefono bigint, 
@clave varchar(255),
@super bit
)
AS
BEGIN


INSERT INTO Usuario 
(
           [Nombre]
           ,[NumeroDocumento]
           ,[Mail]
           ,[Calle]
           ,[NumeroCalle]
           ,[Localidad]
           ,[Provincia]
           ,[CodigoPostal]
           ,[Telefono]
           ,[BorradoLogico]
           ,[Fecha]
		   ,SuperUsuario
		   ,Clave
		   )
VALUES 
(@nombre,
@documento,
@mail, 
@calle,
@nrCalle, 
@localidad,
@provincia, 
@postal, 
@telefono, 
@borrado, 
@fecha,
@super,
@clave)


 
END
GO

----------------------------------------------------------------------------------


CREATE PROCEDURE [dbo].[CambioPass]

@dni varchar(255),
@pass varchar(255)

AS

UPDATE [dbo].Usuario
   SET [Clave] = @pass
 WHERE NumeroDocumento = @dni 

GO


-----------------------------------------------------------------------------------


INSERT INTO [dbo].[_EstadoVenta]
VALUES  (1,'Cerrada',0),(2,'Falta Envio',0),(3,'Falta Cobro',0),(4,'Cancelada',0)
GO


-----------------------------------------------------------------------------------


INSERT INTO [dbo].[Marcas]
VALUES ('Boss',0),('Carolina Herrera',0),('Calvin Klein',0)
GO


-----------------------------------------------------------------------------------


INSERT INTO [dbo].[Categorias]
VALUES ('Hombre',0),('Mujer',0)
GO


-----------------------------------------------------------------------------------


INSERT INTO [dbo].[Usuario]
VALUES ('Admin',78692541,1,'admin@utn.com',1234,0,'20200707','Av. Siempre Viva',123,'Springfield','Oregon',1564,01159987441),
       ('Usuario',78692541,1,'usuario@utn.com',1234,0,'20200707','Av. No Tan Viva',123,'Springfield','Oregon',1564,01178963214)
GO


-----------------------------------------------------------------------------------


INSERT INTO [dbo].[Articulos]        
VALUES     ('1','Bottled','Fragancia Boss Bottled',1,1,'https://lh3.google.com/u/0/d/1vMCTPULGhw0QF9KB9EaZ-SU1O9Ccz1cL=w1680-h939-iv1'
           ,5000,'20200707',1,0),
		   ('2','Good Girl','Fragancia Carolina Herrera Good Girl',2,2,'https://lh3.google.com/u/0/d/1GzvYyEtp6MYMeQpi5HOrYDRBTUd1b4IH=w1680-h939-iv1'
           ,7350,'20200707',1,0),
		   ('3','Eternity','Fragancia Calvin Klein Eternity edp',3,1,'https://lh3.google.com/u/0/d/1h_regsXMKT2SHULeQEDgVDGkgeBwwrFW=w1680-h457-iv1'
           ,4780,'20200707',1,0)
GO


-------------------------------------------------------------------------------------


INSERT INTO [dbo].[Carrito]
VALUES (12350,0,1,'20200707',1),(12350,0,1,'20200707',3),(12350,0,1,'20200707',4)
GO


--------------------------------------------------------------------------------------


INSERT INTO [dbo].[ArticulosPorCarrito]
VALUES (1,1,5000),(2,1,12350),
       (1,2,5000),(2,2,12350),
	   (1,3,5000),(2,3,12350)
GO


---------------------------------------------------------------------------------------


INSERT INTO [dbo].[FormaPago]
VALUES
           (1,224452528987,'Ramon Diaz',20,3,313,1,'20200707',0),
		   (2,223457854187,'Jose Canseco',04,7,175,2,'20200707',0),
		   (3,798642887451,'Christopher Louis',11,12,698,1,'20200707',0)
GO

