# Product Catalog API

A small REST API for managing products. I built this project to practice building a backend with ASP.NET Core, Entity Framework Core, and PostgreSQL.

## What it can do

- List all products
- Filter products by category
- Get one product by ID
- Create a product
- Update a product
- Delete a product

## Tools

- C# and ASP.NET Core Web API
- .NET 10
- Entity Framework Core
- PostgreSQL
- Scalar
- xUnit for tests

## Run the project

### Requirements

- .NET 10 SDK
- PostgreSQL

### Setup

1. Clone the repository and open its folder.
2. Create a PostgreSQL database called `productcatalog`.
3. Check the connection string in `ProductCatalogAPI/appsettings.Development.json`.
4. Run database migrations:

```bash
dotnet ef database update
```

5. Start the API

```bash
dotnet run
```

The API will be available at:

```text
http://localhost:5153
```

## Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/products` | Get all products |
| GET | `/api/products?category=Electronics` | Filter by category |
| GET | `/api/products/{id}` | Get one product |
| POST | `/api/products` | Create a product |
| PUT | `/api/products/{id}` | Update a product |
| DELETE | `/api/products/{id}` | Delete a product |

Use **Scalar** (https://localhost:5135/scalar) for documentation and manually testing the endpoints.

**Example request**:

```http
GET http://localhost:5153/api/products
```

Example product for a `POST` request:

```json
{
  "name": "Keychron K2",
  "category": "Keyboards",
  "price": 999.00,
  "stock": 10
}
```

## Run tests

```bash
dotnet test
```
