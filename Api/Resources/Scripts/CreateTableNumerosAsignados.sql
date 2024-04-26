CREATE TABLE NumerosAsignados (
    Id INT PRIMARY KEY IDENTITY,
    ClienteId INT,
    NumeroAsignado INT,
    CONSTRAINT UC_NumeroAsignado UNIQUE(NumeroAsignado),
    CONSTRAINT FK_ClienteId FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
	);