using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using ValuationBackend.Data;
using ValuationBackend.Extensions;
using ValuationBackend.Models;
using DotNetEnv;

// Load environment variables from .env file
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Configure enum serialization to use string names instead of integer values
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories and services using extension methods
builder.Services.AddRepositories();
builder.Services.AddServices();


// Configure PostgreSQL
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Configure JWT settings from environment variables or fallback to appsettings.json
var jwtSettings = new JwtSettings
{
    SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
        ?? builder.Configuration["JwtSettings:SecretKey"]
        ?? "fallback-secret-key-for-development-only-min-32-chars",
    Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
        ?? builder.Configuration["JwtSettings:Issuer"]
        ?? "ValuationBackend",
    Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
        ?? builder.Configuration["JwtSettings:Audience"]
        ?? "ValuationUsers",
    ExpiryMinutes = int.TryParse(Environment.GetEnvironmentVariable("JWT_EXPIRY_MINUTES"), out var expiry)
        ? expiry : (int.TryParse(builder.Configuration["JwtSettings:ExpiryMinutes"], out var configExpiry) ? configExpiry : 60)
};

// Register JWT settings
builder.Services.Configure<JwtSettings>(options =>
{
    options.SecretKey = jwtSettings.SecretKey;
    options.Issuer = jwtSettings.Issuer;
    options.Audience = jwtSettings.Audience;
    options.ExpiryMinutes = jwtSettings.ExpiryMinutes;
});

// Add Authentication
var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// CORS Policy (allow all — adjust as needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Build the app
var app = builder.Build();

// Initialize database with error handling
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Only reset database if explicitly requested (e.g., via environment variable)
        var shouldResetDb = Environment.GetEnvironmentVariable("RESET_DATABASE")?.ToLower() == "true";

        if (shouldResetDb)
        {
            Console.WriteLine("Resetting database...");
            // Add database reset logic here if needed
        }

        DbInitializer.Initialize(dbContext);
        Console.WriteLine("Database initialized successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database initialization failed: {ex.Message}");
        Console.WriteLine("Application will continue without database initialization.");
        Console.WriteLine("Swagger UI will still be available for API documentation.");
    }
}

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection(); // Only enable in production
}

app.UseCors("AllowAll");

app.UseAuthentication(); // Must come before Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();

// Make Program class accessible to test projects
public partial class Program { }
