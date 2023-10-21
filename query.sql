CREATE TABLE Garagem (
    Codigo NVARCHAR(255) PRIMARY KEY,
    Nome NVARCHAR(255),
    PrecoPrimeiraHora DECIMAL(18, 2),
    PrecoHorasExtra DECIMAL(18, 2),
    PrecoMensalista DECIMAL(18, 2)
);
CREATE TABLE Carro (
    Placa NVARCHAR(255) PRIMARY KEY,
    Marca NVARCHAR(255),
    Modelo NVARCHAR(255)
);
CREATE TABLE FormaPagamento (
    Codigo NVARCHAR(255) PRIMARY KEY,
    Nome NVARCHAR(255)
);
CREATE TABLE Passagem (
    Id INT PRIMARY KEY IDENTITY,
    Garagem NVARCHAR(255) FOREIGN KEY REFERENCES Garagem(Codigo),
    CarroPlaca NVARCHAR(255) FOREIGN KEY REFERENCES Carro(Placa),
    CarroMarca NVARCHAR(255),
    CarroModelo NVARCHAR(255),
    DataHoraEntrada DATETIME,
    DataHoraSaida DATETIME,
    FormaPagamento NVARCHAR(255) FOREIGN KEY REFERENCES FormaPagamento(Codigo),
    PrecoTotal DECIMAL(18, 2)
);
