	
	
	--Creaci�n de la base de datos
	CREATE DATABASE PruebaTecnicaOnOff;
	
	--Checkout a la base de datos
	USE PruebaTecnicaOnOff;
	
	--Creaci�n de la tabla NumeroAsignado
	CREATE TABLE NumerosAsignados (
    Id INT PRIMARY KEY IDENTITY,
    ClienteId INT,
    Numero INT,
    CONSTRAINT UC_Numero UNIQUE(Numero),
    CONSTRAINT FK_ClienteId FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
	);

	--Creaci�n de la tabla Productos
	CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(MAX)
	);
	
	--Creaci�n de la tabla Clientes
	CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Email NVARCHAR(100),
    ApiKey NVARCHAR(100)
	);

	--Se enriquese de datos a la tabla clientes
	INSERT INTO Clientes (Nombre, Email, ApiKey) VALUES
	('Bingo1', 'bg1@bb.com', 'apikey1'),
	('Bingo2', 'bg2@bb.com', 'apikey2'),
	('Bingo3', 'bg3@bb.com', 'apikey3'),
	('Bingo4', 'bg4@bb.com', 'apikey4'),
	('Bingo5', 'bg5@bb.com', 'apikey5');

	--Creaci�n de SP para generaci�n de numeros asignados
	CREATE PROCEDURE AsignarNumero
    @ClienteId INT
	AS
	BEGIN
    DECLARE @Numero INT
    SET @Numero = CAST(RAND() * 99999 AS INT) + 1

		-- Se verifica que el n�mero no haya sido asignado previamente
    WHILE EXISTS (SELECT 1 FROM NumerosAsignados WHERE Numero = @Numero)
    BEGIN
        SET @Numero = CAST(RAND() * 99999 AS INT) + 1
    END

		-- Se verifica que el n�mero no tenga m�s de 3 d�gitos consecutivos iguales
    DECLARE @NumeroStr NVARCHAR(5)
    SET @NumeroStr = CAST(@Numero AS NVARCHAR(5))

    WHILE CHARINDEX('000', @NumeroStr) > 0 OR CHARINDEX('111', @NumeroStr) > 0 OR CHARINDEX('222', @NumeroStr) > 0 OR CHARINDEX('333', @NumeroStr) > 0 OR CHARINDEX('444', @NumeroStr) > 0 OR CHARINDEX('555', @NumeroStr) > 0 OR CHARINDEX('666', @NumeroStr) > 0 OR CHARINDEX('777', @NumeroStr) > 0 OR CHARINDEX('888', @NumeroStr) > 0 OR CHARINDEX('999', @NumeroStr) > 0
    BEGIN
        SET @Numero = CAST(RAND() * 99999 AS INT) + 1
        SET @NumeroStr = CAST(@Numero AS NVARCHAR(5))
    END

		-- Se insertan los datos relacionados a la tabla de N�meros asignados
    INSERT INTO NumerosAsignados (ClienteId, Numero)
    VALUES (@ClienteId, @Numero)

    SELECT Id, ClienteId, Numero FROM NumerosAsignados WHERE ClienteId = @ClienteId and Numero = @Numero
	END
