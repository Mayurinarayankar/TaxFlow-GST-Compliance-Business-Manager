# 💼 TaxFlow API

A robust, secure, and scalable backend API for a tax management application, built using **.NET 8** and **Clean Architecture**.

## 🚀 Features
- 🔐 **Secure Authentication**: JWT-based login and registration with BCrypt password hashing.
- 🏗️ **Clean Architecture**: Separation of concerns across Domain, Application, Infrastructure, and API layers.
- 🗄️ **Entity Framework Core**: Type-safe database interactions with SQL Server/PostgreSQL.
- 🧪 **Testable Design**: Dependency injection and interface-driven development for easy unit testing.

## 🛠️ Tech Stack
- **Framework**: .NET 8 (C#)
- **Architecture**: Clean Architecture
- **Database**: SQL Server / PostgreSQL (via EF Core)
- **Security**: JWT, BCrypt.Net
- **Documentation**: Swagger / OpenAPI

## 📂 Project Structure
```text
Backend/
├── TaxFlow.Domain/         # Core entities and business rules
├── TaxFlow.Application/    # Interfaces, DTOs, and business logic
├── TaxFlow.Infrastructure/ # Database context, repositories, and external services
├── TaxFlow.API/            # Controllers, middleware, and dependency injection
└── TaxFlow.Tests/          # Unit and integration tests