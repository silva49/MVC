CREATE TABLE tblContacto (
  Id int NOT NULL PRIMARY KEY,
  Nombre varchar(50) NULL,
  Telefono Varchar(50) NULL

)

INSERT INTO	dbo.tblContacto (Id,Nombre,Telefono)
VALUES (1,'Juana de Arco', '1234567')

SELECT * FROM dbo.tblContacto	

	CREATE PROC SPContacto
	@opc INT,
	@Id INT = NULL,
	@Nombre VARCHAR(50) = NULL,
	@Telefono VARCHAR (50) = NULL
    AS

IF @opc = 1
 BEGIN
	   SELECT * FROM tblContacto
 END

 GO

 