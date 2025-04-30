# CustomerManagementApi

A simple RESTful Web API built with .NET 8.0 for managing customer data.

## Features
- CRUD operations for customer entity
- DTO-based request models for cleaner input handling
- AutoMapper integration
- ID is auto-assigned on creation (not passed by client)
- JSON serialization using attributes
- Logging with built-in .NET logger
- Unit testing with xUnit

## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022+ or VS Code

### Run the API
```bash
dotnet build
dotnet run
```
Visit: `https://localhost:<port>/swagger`

## Example Endpoints
- `GET /api/customers`
- `GET /api/customers/{id}`
- `POST /api/customers` → accepts DTO without ID
- `PUT /api/customers/{id}`
- `DELETE /api/customers/{id}`

## Run Tests
```bash
dotnet test
```

## License
MIT
