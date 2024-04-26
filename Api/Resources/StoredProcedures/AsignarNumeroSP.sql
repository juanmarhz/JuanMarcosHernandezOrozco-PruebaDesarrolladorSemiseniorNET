CREATE OR ALTER PROCEDURE AsignarNumero
    @ClienteId INT
	AS
	BEGIN
    DECLARE @Numero INT
    SET @Numero = CAST(RAND() * 99999 AS INT) + 1

		-- Se verifica que el numero no haya sido asignado anteriormente
    WHILE EXISTS (SELECT 1 FROM NumerosAsignados WHERE Numero = @Numero)
    BEGIN
        SET @Numero = CAST(RAND() * 99999 AS INT) + 1
    END

		-- Se verifica que el número no tenga más de 3 dígitos consecutivos iguales
    DECLARE @NumeroStr NVARCHAR(5)
    SET @NumeroStr = CAST(@Numero AS NVARCHAR(5))

    WHILE CHARINDEX('000', @NumeroStr) > 0 OR CHARINDEX('111', @NumeroStr) > 0 OR CHARINDEX('222', @NumeroStr) > 0 OR CHARINDEX('333', @NumeroStr) > 0 OR CHARINDEX('444', @NumeroStr) > 0 OR CHARINDEX('555', @NumeroStr) > 0 OR CHARINDEX('666', @NumeroStr) > 0 OR CHARINDEX('777', @NumeroStr) > 0 OR CHARINDEX('888', @NumeroStr) > 0 OR CHARINDEX('999', @NumeroStr) > 0
    BEGIN
        SET @Numero = CAST(RAND() * 99999 AS INT) + 1
        SET @NumeroStr = CAST(@Numero AS NVARCHAR(5))
    END

		-- Se insertan los datos relacionados a la tabla de Números asignados
    INSERT INTO NumerosAsignados (ClienteId, Numero)
    VALUES (@ClienteId, @Numero)

    SELECT Id, ClienteId, Numero FROM NumerosAsignados WHERE ClienteId = @ClienteId and Numero = @Numero
	END