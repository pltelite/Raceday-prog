RaceDay Event Management System - Full Stack Application

A production-ready full-stack platform built with ASP.NET Core 8, EF Core, and Azure Blob Storage for managing sporting and racing events across South Africa.

## 🚀 Architectural Overview

- **RaceDay.API**: Decoupled RESTful Web API handling database operations (EF Core), authentication (BCrypt), and Azure Blob Storage image uploads.
- **RaceDay.Web**: ASP.NET Core MVC web application delivering role-aware interfaces for Organisers and Participants without direct database connections.
- **Infrastructure**: Containerised using Docker & Docker Compose; continuous integration powered by GitHub Actions.

## 🛠️ Tech Stack

- **Framework**: .NET 8.0 / ASP.NET Core (API & MVC)
- **Database & ORM**: Entity Framework Core with SQL Server
- **Cloud Storage**: Azure Blob Storage SDK (`Azure.Storage.Blobs`)
- **Containerisation**: Docker & Docker Compose
- **Styling**: Bootstrap 5 (Responsive, energetic sporting theme)
- **CI/CD**: GitHub Actions

## 🐳 Docker Deployment (Single Command)

To build and launch both the Web API and MVC frontend containers simultaneously:

```bash
docker-compose up --build
```

- **MVC Frontend**: Access at `http://localhost:5000`
- **Web API / Swagger**: Access at `http://localhost:7123/swagger`

## 🔧 Local Development Setup

1. **Clone the Repository**:
  ```bash
  git clone https://github.com/YOUR_GITHUB_USERNAME/RaceDay.git
  cd RaceDay
  ```

2. **Update Connection Strings**:
  Configure SQL Server and Azure Blob Storage connections in `RaceDay.API/appsettings.json`.

3. **Apply Database Migrations**:
  ```bash
  dotnet ef database update --project RaceDay.API
  ```

4. **Run both applications**:
  ```bash
  dotnet run --project RaceDay.API
  dotnet run --project RaceDay.Web
  ```
