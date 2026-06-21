# 📮 ViaCepIntegration.NET

Projeto de estudo em **.NET 10 / ASP.NET Core**, criado para aplicar na prática os conceitos de C# e arquitetura em camadas, migrando conhecimento de Java/Spring para o ecossistema .NET.

A API realiza cadastro de pessoas com preenchimento automático de endereço, através de integração com a **API pública ViaCEP**.

---

## 🧠 Sobre o projeto

Construído como parte do meu processo de aprendizado em .NET, aplicando os mesmos princípios de Clean Code, separação de camadas e boas práticas que já uso no desenvolvimento Java/Spring.

✔️ Arquitetura em camadas (Controller → Service → Repository → Client)

✔️ Integração com API externa (ViaCEP)

✔️ Persistência relacional com Entity Framework Core

✔️ Relacionamento OneToMany / ManyToOne entre entidades

✔️ DTOs com `record` para imutabilidade

✔️ Configuração tipada via Options Pattern

---

## 🏗️ Estrutura de camadas
Controllers/   → recebe as requisições HTTP

Services/      → regra de negócio

Repositories/  → comunicação com o banco via EF Core

Clients/       → integração com a API externa (ViaCEP)

Entities/      → representação das tabelas no banco

Dto/Request/   → dados recebidos do cliente

Dto/Response/  → dados devolvidos ao cliente

Config/        → configurações tipadas (Options Pattern)

Data/          → DbContext (EF Core)

---

## 🚀 Stack

- **C# / .NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **ViaCEP API** (integração externa)

---

## 📚 Conceitos aplicados

- Injeção de Dependência nativa do .NET
- Options Pattern para configuração tipada
- Relacionamentos EF Core (OneToMany / ManyToOne)
- DTOs imutáveis com `record`
- Programação assíncrona (`async`/`await`/`Task`)
- Migrations com EF Core CLI

---

## 📫 Contato

[LinkedIn](https://www.linkedin.com/in/gabriel-lima-892682213) | ogabriellima1999@gmail.com

---

<p align="center">
  🚀 Projeto de estudo aplicando arquitetura enterprise em .NET
</p>
