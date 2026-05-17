# SchoolManager

Sistema de gerenciamento escolar desenvolvido com ASP.NET Core MVC e Entity Framework Core.

## Sobre o Projeto

O SchoolManager é uma aplicação web criada com o objetivo de praticar conceitos de desenvolvimento backend utilizando C# e ASP.NET Core MVC. O sistema simula um ambiente de gestão escolar, permitindo organizar e administrar informações acadêmicas de forma estruturada.

O projeto foi desenvolvido focando em boas práticas de arquitetura, organização de código e integração com banco de dados relacional.

## Tecnologias Utilizadas

* ASP.NET Core MVC
* C#
* Entity Framework Core
* MySQL
* Pomelo EntityFrameworkCore MySql
* Bootstrap
* Razor Pages
* Dependency Injection
* LINQ

## Funcionalidades

### Gerenciamento de Alunos

* Cadastro de alunos
* Edição de informações
* Exclusão de registros
* Listagem de alunos

### Gerenciamento de Professores

* Cadastro de professores
* Atualização de dados
* Remoção de registros
* Consulta de professores

### Gerenciamento Escolar

* Organização de dados acadêmicos
* Integração com banco de dados
* Persistência utilizando Entity Framework Core
* Sistema baseado em arquitetura MVC

## Estrutura do Projeto

```bash
SchoolManager/
│
├── Controllers/
├── Models/
├── Views/
├── Data/
├── Services/
├── wwwroot/
├── Migrations/
├── appsettings.json
└── Program.cs
```

## Conceitos Praticados

Durante o desenvolvimento deste projeto foram praticados conceitos importantes como:

* Arquitetura MVC
* Injeção de Dependência
* ORM com Entity Framework Core
* Migrations
* CRUD completo
* Organização em camadas
* Relacionamento entre entidades
* Boas práticas com ASP.NET Core
* Consumo e manipulação de banco de dados

## Como Executar o Projeto

### Pré-requisitos

Antes de começar, você vai precisar ter instalado:

* .NET SDK
* MySQL Server
* MySQL Workbench (opcional)
* Visual Studio ou VS Code

## Clone o repositório

```bash
git clone https://github.com/andreprimonluiz-ship-it/SchoolManager.git
```

## Acesse a pasta do projeto

```bash
cd SchoolManager
```

## Configure a connection string

No arquivo `appsettings.json`, configure sua conexão com o banco:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=schoolmanagerdb;user=root;password=sua_senha"
}
```

## Execute as migrations

```bash
dotnet ef database update
```

## Rode o projeto

```bash
dotnet run
```

Depois disso, acesse:

```bash
https://localhost:xxxx
```

## Objetivo do Projeto

Este projeto foi desenvolvido com fins de estudo e evolução como desenvolvedor backend .NET.

O principal objetivo é praticar:

* Desenvolvimento de aplicações web
* Integração com banco de dados
* Arquitetura de software
* Estruturação de sistemas reais
* Boas práticas de programação

## Próximas Melhorias

* Sistema de autenticação
* Controle de permissões
* API REST
* Validações avançadas
* DTOs
* AutoMapper
* Paginação
* Logs
* Dashboard administrativo
* Clean Architecture
* Docker
* Testes automatizados
  
## Autor

Desenvolvido por André Luiz.

* GitHub: [https://github.com/andreprimonluiz-ship-it](https://github.com/andreprimonluiz-ship-it)
