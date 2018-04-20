--IF (NOT EXISTS(SELECT * FROM sys.schemas WHERE name = 'Login'))
--BEGIN
--	EXEC('CREATE SCHEMA [Login] AUTHORIZATION [dbo]')
--END

--alter schema Login TRANSFER dbo.ServiceToken

--alter schema Login TRANSFER dbo.ServiceUsuario



create table ProductoCategoria(
	ProductoCategoriaID [int] IDENTITY(1,1) primary key NOT NULL ,
	Nombre varchar(30) NOT NULL,
	FechaCreacion [datetime] default getdate() not null
)

--insert into ProductoCategoria (Nombre) values ('Bebidas'),('Granos')

create table Producto(
	ProductoID int identity(1,1) primary key,
	ProductoCategoriaID int not null,
	Nombre varchar(100) not null,
	Color varchar(30),
	Precio money not null,
	FechaCreacion [datetime] default getdate() not null,
	foreign key (ProductoCategoriaID)  references ProductoCategoria(ProductoCategoriaID)
);

select * from ProductoCategoria
select * from Producto

--insert into Producto (ProductoCategoriaID, Nombre, Color, Precio) values
--(1, 'Gaseosa Manzana', 'Rosada' , 2500), (2, 'Arroz', 'Blanco', 1900), (2, 'Lentejas', 'Cafe', 2450) 