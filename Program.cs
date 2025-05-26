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

// Register repositories
builder.Services.AddScoped<ValuationBackend.Repositories.IConditionReportRepository, ValuationBackend.Repositories.ConditionReportRepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IBuildingRatesLARepository, ValuationBackend.Repositories.BuildingRatesLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IPastValuationsLARepository, ValuationBackend.Repositories.PastValuationsLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IRentalEvidenceLARepository, ValuationBackend.Repositories.RentalEvidenceLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.ISalesEvidenceLARepository, ValuationBackend.Repositories.SalesEvidenceLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.ILAMasterfileRepository, ValuationBackend.Repositories.LAMasterfileRepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IRequestTypeRepository, ValuationBackend.Repositories.RequestTypeRepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IRequestRepository, ValuationBackend.Repositories.RequestRepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IAssetRepository, ValuationBackend.Repositories.AssetRepository>();

// Register services
builder.Services.AddScoped<ValuationBackend.Services.IConditionReportService, ValuationBackend.Services.ConditionReportService>();
builder.Services.AddScoped<ValuationBackend.Services.IBuildingRatesLAService, ValuationBackend.Services.BuildingRatesLAService>();
builder.Services.AddScoped<ValuationBackend.Services.IPastValuationsLAService, ValuationBackend.Services.PastValuationsLAService>();
builder.Services.AddScoped<ValuationBackend.Services.IRentalEvidenceLAService, ValuationBackend.Services.RentalEvidenceLAService>();
builder.Services.AddScoped<ValuationBackend.Services.ISalesEvidenceLAService, ValuationBackend.Services.SalesEvidenceLAService>();
builder.Services.AddScoped<ValuationBackend.Services.ILAMasterfileService, ValuationBackend.Services.LAMasterfileService>();
builder.Services.AddScoped<ValuationBackend.Services.IRequestTypeService, ValuationBackend.Services.RequestTypeService>();
builder.Services.AddScoped<ValuationBackend.Services.IRequestService, ValuationBackend.Services.RequestService>();
builder.Services.AddScoped<ValuationBackend.Services.IAssetService, ValuationBackend.Services.AssetService>();

// Register repositories and services using extension methods
builder.Services.AddRepositories();
builder.Services.AddServices();


// Configure PostgreSQL
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Configure JWT settings from environment variables
var jwtSettings = new JwtSettings
{
    SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
        ?? throw new InvalidOperationException("JWT_SECRET_KEY environment variable is not configured."),
    Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
        ?? throw new InvalidOperationException("JWT_ISSUER environment variable is not configured."),
    Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
        ?? throw new InvalidOperationException("JWT_AUDIENCE environment variable is not configured."),
    ExpiryMinutes = int.TryParse(Environment.GetEnvironmentVariable("JWT_EXPIRY_MINUTES"), out var expiry)
        ? expiry : 60
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

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Initialize(dbContext);
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
