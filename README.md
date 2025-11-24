# Zoo Backend API

Este é o backend do projeto **Zoo**, desenvolvido em **.NET 8** com Entity Framework Core e SQL Server.

## Pré-requisitos

- .NET 8 SDK
- SQL Server (local ou container)
- Ferramentas EF Core CLI (`dotnet-ef`)

## Configuração da conexão com o banco

No arquivo `appsettings.json`, configure a conexão com seu SQL Server:


"DefaultConnection": "Server=localhost,1433;Database=ZooDB;User Id=sa;Password=SuaSenhaAqui;TrustServerCertificate=True;"

No arquivo ApplicationDbContextFactory.cs:

optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ZooDB;User Id=sa;Password=SuaSenhaAqui;TrustServerCertificate=True;");

    Ajuste usuário, senha e porta conforme seu ambiente.

Criando o banco e aplicando migrations

    Abra um terminal na pasta do projeto Zoo.Data:

cd src/Zoo.Data

    Crie a migration inicial:

dotnet ef migrations add InitialCreate

    Atualize o banco de dados:

dotnet ef database update

    Pronto! O banco deve conter as tabelas Animais, Cuidados e __EFMigrationsHistory.
