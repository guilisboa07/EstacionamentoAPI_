# Estacionamento API

## Visão Geral

A Estacionamento API é uma aplicação que permite a gestão de garagens, passagens e carros em um estacionamento. Ela fornece uma API RESTful que permite realizar operações como adicionar garagens, registrar passagens de carros e gerenciar informações sobre os carros no estacionamento.

## Requisitos

Para executar a Estacionamento API, você precisará do seguinte:

- [.NET Core 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- Um servidor de banco de dados SQL, como SQL Server ou SQLite.

## Configuração

1. Clone o repositório:
   ```
   git clone https://github.com/guilisboa07/WebApplication1.git
   ```

2. Navegue até a pasta do projeto:
   ```
   cd WebApplication1
   ```

3. Configure a string de conexão do banco de dados no arquivo `appsettings.json`. Por exemplo:
   ```json
   "ConnectionStrings": {
     "EstacionamentoDatabase": "Server=localhost;Database=estacionamento;User Id=sa;Password=Pass@Word;"
   }
   ```

4. Abra um terminal e execute a aplicação:
   ```
   dotnet run
   ```

A aplicação estará disponível em `http://localhost:5000`.

## Uso

### Gerenciamento de Garagens

#### Listar Garagens

{
    "Garagens":
    [
        {
            "Codigo":"EVO01",
            "Nome": "Estamplaza Vila Olimpia",
            "Preco_1aHora": "40",
            "Preco_HorasExtra": "10",
            "Preco_Mensalista": "550"
        },
        {
            "Codigo":"PLJK01",
            "Nome": "Plaza JK",
            "Preco_1aHora": "35",
            "Preco_HorasExtra": "12",
            "Preco_Mensalista": "380"
        },
        {
            "Codigo":"SZJK01",
            "Nome": "Spazio JK",
            "Preco_1aHora": "30",
            "Preco_HorasExtra": "15",
            "Preco_Mensalista": "350"
        },
        {
            "Codigo":"CSLU01",
            "Nome": "Condominio São Luiz",
            "Preco_1aHora": "50",
            "Preco_HorasExtra": "12",
            "Preco_Mensalista": "550"
        },
        {
            "Codigo":"COTO01",
            "Nome": "Corporate Tower Itaim",
            "Preco_1aHora": "30",
            "Preco_HorasExtra": "12",
            "Preco_Mensalista": "360"
        }
    ]
}
### Listar Passagens
{
    "Passagens":[
        {
            "Garagem":"EVO01",
            "CarroPlaca":"ABC-0O12",
            "CarroMarca":"Honda",
            "CarroModelo":"FIT",
            "DataHoraEntrada":"04/09/2023 13:30",
            "DataHoraSaida":"04/09/2023 15:15",
            "FormaPagamento":"PIX",
            "PrecoTotal":""
        },
        {
            "Garagem":"EVO01",
            "CarroPlaca":"DKO-3927",
            "CarroMarca":"Toyota",
            "CarroModelo":"Yaris",
            "DataHoraEntrada":"05/09/2023 08:40",
            "DataHoraSaida":"05/09/2023 09:55",
            "FormaPagamento":"CCR",
            "PrecoTotal":""
        },
        {
            "Garagem":"EVO01",
            "CarroPlaca":"SPE-9F42",
            "CarroMarca":"Fiat",
            "CarroModelo":"Argo",
            "DataHoraEntrada":"04/09/2023 10:15",
            "DataHoraSaida":"04/09/2023 11:20",
            "FormaPagamento":"TAG",
            "PrecoTotal":""
        },
        {
            "Garagem":"EVO01",
            "CarroPlaca":"WPS-0385",
            "CarroMarca":"Fiat",
            "CarroModelo":"Fiorino",
            "DataHoraEntrada":"06/09/2023 09:10",
            "DataHoraSaida":"10/09/2023 11:30",
            "FormaPagamento":"MEN",
            "PrecoTotal":""
        },
        {
            "Garagem":"EVO01",
            "CarroPlaca":"FER-E345",
            "CarroMarca":"Volkwagen",
            "CarroModelo":"Gol",
            "DataHoraEntrada":"05/09/2023 09:40",
            "DataHoraSaida":"05/09/2023 12:40",
            "FormaPagamento":"MEN",
            "PrecoTotal":""
        },
        {
            "Garagem":"EVO01",
            "CarroPlaca":"FER-E345",
            "CarroMarca":"Volkwagen",
            "CarroModelo":"Gol",
            "DataHoraEntrada":"05/09/2023 15:10",
            "DataHoraSaida":"05/09/2023 19:30",
            "FormaPagamento":"MEN",
            "PrecoTotal":""
        },        



        {
            "Garagem":"PLJK01",
            "CarroPlaca":"FCK-1E44",
            "CarroMarca":"Fiat",
            "CarroModelo":"Palio",
            "DataHoraEntrada":"04/09/2023 10:11",
            "DataHoraSaida":"04/09/2023 14:33",
            "FormaPagamento": "DIN",
            "PrecoTotal":""
        },
        {
            "Garagem":"PLJK01",
            "CarroPlaca":"HHI-0492",
            "CarroMarca":"BMW",
            "CarroModelo":"320i",
            "DataHoraEntrada":"04/09/2023 09:40",
            "DataHoraSaida":"04/09/2023 17:49",
            "FormaPagamento":"PIX",
            "PrecoTotal":""
        },
        {
            "Garagem":"PLJK01",
            "CarroPlaca":"HRQ-9018",
            "CarroMarca":"Audi",
            "CarroModelo":"A4",
            "DataHoraEntrada":"05/09/2023 10:22",
            "DataHoraSaida":"05/09/2023 18:36",
            "FormaPagamento":"MEN",
            "PrecoTotal":""
        },



        {
            "Garagem":"CSLU01",
            "CarroPlaca":"JZH-6272",
            "CarroMarca":"Volkswagen",
            "CarroModelo":"Tiguan",
            "DataHoraEntrada":"04/09/2023 10:12",
            "DataHoraSaida":"04/09/2023 16:30",
            "FormaPagamento":"PIX",
            "PrecoTotal":""
        },
        {
            "Garagem":"CSLU01",
            "CarroPlaca":"KLV-3182",
            "CarroMarca":"Volkswagen",
            "CarroModelo":"T-Cross",
            "DataHoraEntrada":"05/09/2023 11:10",
            "DataHoraSaida":"05/09/2023 20:45",
            "FormaPagamento":"CDE",
            "PrecoTotal":""
        },
        {
            "Garagem":"CSLU01",
            "CarroPlaca":"MOR-6228",
            "CarroMarca":"Volkswagen",
            "CarroModelo":"Jetta",
            "DataHoraEntrada":"04/09/2023 09:10",
            "DataHoraSaida":"04/09/2023 16:49",
            "FormaPagamento":"CDE",
            "PrecoTotal":""
        },
        {
            "Garagem":"CSLU01",
            "CarroPlaca":"JTW-1439",
            "CarroMarca":"Honda",
            "CarroModelo":"Civic",
            "DataHoraEntrada":"05/09/2023 11:12",
            "DataHoraSaida":"05/09/2023 12:30",
            "FormaPagamento":"CCR",
            "PrecoTotal":""
        },
        {
            "Garagem":"CSLU01",
            "CarroPlaca":"MYQ-5648",
            "CarroMarca":"Honda",
            "CarroModelo":"H-RV",
            "DataHoraEntrada":"04/09/2023 14:55",
            "DataHoraSaida":"04/09/2023 15:59",
            "FormaPagamento":"TAG",
            "PrecoTotal":""
        },


        {
            "Garagem":"COTO01",
            "CarroPlaca":"LSX-4521",
            "CarroMarca":"Jeep",
            "CarroModelo":"Renegate",
            "DataHoraEntrada":"04/09/2023 09:12",
            "DataHoraSaida":"04/09/2023 18:33",
            "FormaPagamento":"MEN",
            "PrecoTotal":""
        },
        {
            "Garagem":"COTO01",
            "CarroPlaca":"BDI-8423",
            "CarroMarca":"Jeep",
            "CarroModelo":"Commander",
            "DataHoraEntrada":"05/09/2023 10:12",
            "DataHoraSaida":"05/09/2023 11:30",
            "FormaPagamento":"PIX",
            "PrecoTotal":""
        },
        {
            "Garagem":"COTO01",
            "CarroPlaca":"LVX-7196",
            "CarroMarca":"Chevrolet",
            "CarroModelo":"Prisma",
            "DataHoraEntrada":"04/09/2023 11:30",
            "DataHoraSaida":"04/09/2023 12:40",
            "FormaPagamento":"CDE",
            "PrecoTotal":""
        },
        {
            "Garagem":"COTO01",
            "CarroPlaca":"FDH-4726",
            "CarroMarca":"Chevrolet",
            "CarroModelo":"S10",
            "DataHoraEntrada":"04/09/2023 15:30",
            "DataHoraSaida":"04/09/2023 16:50",
            "FormaPagamento":"CCR",
            "PrecoTotal":""
        },
        {
            "Garagem":"COTO01",
            "CarroPlaca":"NCF-5760",
            "CarroMarca":"Chevrolet",
            "CarroModelo":"Onix",
            "DataHoraEntrada":"04/09/2023 10:10",
            "DataHoraSaida":"04/09/2023 18:40",
            "FormaPagamento":"TAG",
            "PrecoTotal":""
        },
        {
            "Garagem":"COTO01",
            "CarroPlaca":"IND-6562",
            "CarroMarca":"Porsche",
            "CarroModelo":"911",
            "DataHoraEntrada":"05/09/2023 10:12",
            "DataHoraSaida":"05/09/2023 14:55",
            "FormaPagamento":"TAG",
            "PrecoTotal":""
        }

    ]

}

### Listar Formas de Pagamento
{
    "FormasPagamento": [
        {
            "Codigo":"DIN",
            "Descricao":"Dinheiro"
        },
        {
            "Codigo":"MEN",
            "Descricao":"Mensalista"
        },        
        {
            "Codigo":"PIX",
            "Descricao":"PIX"
        },
        {
            "Codigo":"TAG",
            "Descricao":"TAG"
        },
        {
            "Codigo":"CDE",
            "Descricao":"Cartão de Débito"
        },
        {
            "Codigo":"CCR",
            "Descricao":"Cartão de Crédito"
        }
    ]
}

Classes e Modelos:

Classe Garagem:
Propriedades: Codigo, Nome, PrecoPrimeiraHora, PrecoHorasExtra, PrecoMensalista.

Classe Passagem:
Propriedades: Garagem (referência a Garagem), CarroPlaca (referência a Carro), DataHoraEntrada, DataHoraSaida, FormaPagamento, PrecoTotal.

Classe Carro:
Propriedades: Placa, Marca, Modelo.

### Banco de Dados
Lista das tabelas e relacionamentos

Tabela Garagem
Codigo	VARCHAR(10)	Chave Primária
Nome	VARCHAR(100)	Não Nulo
PrecoPrimeiraHora	DECIMAL(10,2)	Não Nulo
PrecoHorasExtra	DECIMAL(10,2)	Não Nulo
PrecoMensalista	DECIMAL(10,2)	Não Nulo

Tabela Carro
Placa	VARCHAR(10)	Chave Primária
Marca	VARCHAR(50)	Não Nulo
Modelo	VARCHAR(50)	Não Nulo

Tabela Passagem
IDPassagem	INT	Chave Primária, Auto-incremento
Garagem	VARCHAR(10)	Chave Estrangeira (Garagem)
CarroPlaca	VARCHAR(10)	Chave Estrangeira (Carro)
DataHoraEntrada	DATETIME	Não Nulo
DataHoraSaida	DATETIME	
FormaPagamento	VARCHAR(20)	Chave Estrangeira (FormaPagamento)
PrecoTotal	DECIMAL(10,2)	Não Nulo

Tabela FormaPagamento
Codigo	VARCHAR(10)	Chave Primária
Nome	VARCHAR(50)	Não Nulo
