# Steps to Apply OfficesRatingCard Migration

## 1. First, ensure the backend project builds successfully:
```bash
cd /path/to/ValuationBackend
dotnet build
```

## 2. Apply the database migration:
```bash
dotnet ef database update
```

If you get an error about migrations, you may need to:

## 3. Remove the manual migration file and create it properly:
```bash
# Remove the manually created migration
rm Migrations/AddOfficesRatingCardTable.cs

# Create migration using EF Core tools
dotnet ef migrations add AddOfficesRatingCardTable
```

## 4. Then apply the migration:
```bash
dotnet ef database update
```

## 5. Run the backend:
```bash
dotnet run
```

## 6. Verify the endpoint is available:
Navigate to: http://localhost:5221/swagger
Look for the OfficesRatingCard endpoints

## Troubleshooting:
If the controller is not appearing in Swagger:
1. Make sure the project has rebuilt
2. Check that all namespaces are correct
3. Ensure the controller is registered in Program.cs or Startup.cs

If you're still getting 404:
1. Check the backend console for any startup errors
2. Verify the database connection string
3. Check if the Assets table exists (required for foreign key)