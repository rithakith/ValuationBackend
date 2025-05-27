# Valuation Backend

A comprehensive ASP.NET Core Web API for property valuation and asset management, designed for local authorities and property assessment organizations.

## Overview

The Valuation Backend is a robust RESTful API that provides comprehensive property valuation services including asset management, rating assessments, building rates, sales evidence tracking, rental evidence management, and inspection reports. The system supports both land and building valuations with extensive data management capabilities.

## Features

### Core Functionality

- **Asset Management**: Complete CRUD operations for property assets
- **Property Valuation**: Comprehensive valuation workflows for different property types
- **Rating System**: Property rating and assessment management
- **Evidence Tracking**: Sales and rental evidence management
- **Inspection Reports**: Property inspection and condition reporting
- **User Management**: Authentication and user task management
- **Reconciliation**: Asset reconciliation and number change tracking

### API Endpoints

#### Assets

- Asset CRUD operations
- Asset filtering by property type, ward, owner, rating card status
- Asset search by asset number and request ID

#### Valuation Services

- **Building Rates**: Land Authority (LA) and Land Miscellaneous (LM) building rates
- **Past Valuations**: Historical valuation data for LA and LM
- **Sales Evidence**: Property sales data for LA
- **Rental Evidence**: Property rental data for LA
- **Condition Reports**: Property condition assessments

#### Property Management

- **Domestic Rating Cards**: Residential property rating information
- **Land Miscellaneous**: Land-based property management with sorting and pagination
- **Inspection Reports**: Property inspection workflows

#### Administrative

- **Authentication**: JWT-based user authentication
- **Master Data**: Centralized reference data management
- **User Tasks**: Task overview and work summary reporting
- **Reports**: Comprehensive reporting system

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Database**: PostgreSQL with Entity Framework Core
- **Authentication**: JWT Bearer Token
- **API Documentation**: Swagger/OpenAPI
- **Configuration**: Environment variables support via DotNetEnv

## Dependencies

```xml
- Microsoft.AspNetCore.OpenApi (8.0.14)
- Microsoft.AspNetCore.Authentication.JwtBearer (8.0.0)
- Microsoft.EntityFrameworkCore (9.0.5)
- Microsoft.EntityFrameworkCore.Design (9.0.4)
- Npgsql.EntityFrameworkCore.PostgreSQL (9.0.4)
- Swashbuckle.AspNetCore (8.1.1)
- System.IdentityModel.Tokens.Jwt (8.10.0)
- DotNetEnv (3.1.1)
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- PostgreSQL database
- Visual Studio 2022 or VS Code

### Configuration

1. **Database Connection**: Update the connection string in `appsettings.json` or set the `DB_CONNECTION_STRING` environment variable:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Your PostgreSQL connection string"
     }
   }
   ```

2. **JWT Configuration**: Configure JWT settings in `appsettings.json` or use environment variables:

   ```json
   {
     "JwtSettings": {
       "SecretKey": "your-secret-key-here",
       "Issuer": "ValuationBackend",
       "Audience": "ValuationUsers",
       "ExpiryMinutes": 60
     }
   }
   ```

3. **Environment Variables** (optional):
   - `DB_CONNECTION_STRING`: Database connection string
   - `JWT_SECRET_KEY`: JWT secret key
   - `JWT_ISSUER`: JWT issuer
   - `JWT_AUDIENCE`: JWT audience
   - `JWT_EXPIRY_MINUTES`: Token expiry time in minutes

### Installation & Running

1. **Clone the repository**
2. **Restore packages**:

   ```bash
   dotnet restore
   ```

3. **Update database**:

   ```bash
   dotnet ef database update
   ```

4. **Run the application**:

   ```bash
   dotnet run
   ```

5. **Access the API**:
   - API Base URL: `https://localhost:5001` or `http://localhost:5000`
   - Swagger Documentation: `https://localhost:5001/swagger`

## Database Schema

The application uses Entity Framework Core with PostgreSQL and includes migrations for:

- Assets and asset divisions
- Users and profiles
- Rating requests and user tasks
- Master data and image data
- Condition reports and inspection reports
- Building rates and valuation data
- Sales and rental evidence
- Land miscellaneous master files

## API Features

### Sorting and Pagination

Many endpoints support sorting and pagination:

- **Land Miscellaneous API**: Supports sorting by various fields (id, masterfileno, plantype, planno, status)
- **Pagination**: Page-based pagination with configurable page sizes
- **Search**: Text-based search with pagination and sorting

### Authentication

- JWT Bearer token authentication
- Login, logout, and forgot password endpoints
- Token-based authorization for protected endpoints

### Error Handling

- Comprehensive error handling with appropriate HTTP status codes
- Validation error responses with detailed error messages
- Exception handling with proper error logging

## Development

### Project Structure

```
ValuationBackend/
├── Controllers/           # API Controllers
│   ├── iteration2/       # Enhanced controllers
├── Data/                 # Database context and configuration
├── Extensions/           # Service and repository extensions
├── Migrations/           # EF Core migrations
├── Models/               # Entity models and DTOs
├── repositories/         # Data access layer
├── services/            # Business logic layer
├── Properties/          # Application properties
└── Program.cs           # Application entry point
```

### Adding New Features

1. Create entity models in the `Models` folder
2. Add repository interfaces and implementations
3. Create service classes for business logic
4. Implement controllers with proper routing
5. Add migrations for database changes
6. Update dependency injection in `Program.cs`

## Contributing

1. Follow the existing code structure and naming conventions
2. Use repository and service patterns for data access and business logic
3. Implement proper error handling and validation
4. Add appropriate unit tests for new features
5. Update API documentation for new endpoints

## License

This project is proprietary software for valuation and property management purposes.

## Support

For technical support or questions about the API, please refer to the Swagger documentation at `/swagger` when the application is running.
