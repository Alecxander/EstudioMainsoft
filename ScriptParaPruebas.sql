create table Alumno(
Id int identity primary key,
IdMateria int not null,
Nombre varchar(30) not null,
Correo varchar(50),
foreign key (IdMateria) references Materia(Id)
)

create table Materia(
Id int identity primary key,
IdProfesor int not null,
Nombre varchar(30) not null,
foreign key (idProfesor) references Profesor(Id)
)


create table Profesor(
Id int identity primary key,
Nombre varchar (30) not null,
Edad tinyint
)


CREATE PROCEDURE ObtenerAlumnos
AS
Begin
	SET NOCOUNT ON;
	SELECT A.Id, A.Nombre, A.Correo, M.Nombre [Materia], P.Nombre [Profesor] FROM Alumno A
	INNER JOIN Materia M ON M.Id = A.IdMateria 
	INNER JOIN Profesor P ON P.Id = M.Id
end
