# Internal Management System API

A backend-focused RESTful API built with ASP.NET Core for managing product data in an internal system.

This project was developed as a hands-on exercise to practise backend development concepts, API design, and database integration using modern .NET technologies.

---

## Tech Stack

- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQL Server (LocalDB)
- Swagger / OpenAPI
- C#

---

## Key Features

- RESTful API design with resource-based routing
- Full CRUD operations (GET, POST, PUT, DELETE) for product management
- DTO-based input validation using Data Annotations
- Server-side ID generation via SQL Server
- Query filtering using query parameters (keyword and category)
- Interactive API testing and documentation via Swagger UI

---

## Project Structure

- `Controllers/` – API endpoints and request handling
- `Models/` – Database entity definitions
- `Dtos/` – Data transfer objects for API input/output
- `Data/` – Entity Framework Core database context
- `Program.cs` – Application configuration and middleware setup

---

## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio

### Running the Project
1. Clone this repository
2. Open the solution in Visual Studio
3. Run the application (swagger ui will pop up in browser)
