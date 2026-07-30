# GI Joe API

A full-stack character tracking application built with ASP.NET Core and React.

This project began as a simple API for managing GI Joe characters and has grown into a full-stack application with a React frontend inspired by classic 1980's action figure file cards.

## Features

- Create GI Joe characters
- Read character data
- Update existing characters
- Delete characters
- Search characters by name
- Pagination support
- SQLite database integration
- Entity Framework Core
- Swagger API documentation
- CORS configuration for frontend integration

## Tech Stack

- C#
- .NET
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Running the API

Navigate to the project directory:

```bash
dotnet run
```

The API will run at:

```text
http://localhost:5116
```

Swagger UI:

```text
http://localhost:5116/swagger
```

## Endpoints

- GET /api/joes
- GET /api/joes/search?name=
- GET /api/joes/{id}
- POST /api/joes
- PUT /api/joes/{id}
- DELETE /api/joes/{id}

## Project Status

Under active development as part of a structured C# and .NET learning roadmap.
