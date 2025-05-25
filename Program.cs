using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ValuationBackend.Data;
using ValuationBackend.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories
builder.Services.AddScoped<ValuationBackend.Repositories.IConditionReportRepository, ValuationBackend.Repositories.ConditionReportRepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IBuildingRatesLARepository, ValuationBackend.Repositories.BuildingRatesLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IPastValuationsLARepository, ValuationBackend.Repositories.PastValuationsLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IRentalEvidenceLARepository, ValuationBackend.Repositories.RentalEvidenceLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.ISalesEvidenceLARepository, ValuationBackend.Repositories.SalesEvidenceLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.ILAMasterfileRepository, ValuationBackend.Repositories.LAMasterfileRepository>();

// Register services
builder.Services.AddScoped<ValuationBackend.Services.IConditionReportService, ValuationBackend.Services.ConditionReportService>();
builder.Services.AddScoped<ValuationBackend.Services.IBuildingRatesLAService, ValuationBackend.Services.BuildingRatesLAService>();
builder.Services.AddScoped<ValuationBackend.Services.IPastValuationsLAService, ValuationBackend.Services.PastValuationsLAService>();
builder.Services.AddScoped<ValuationBackend.Services.IRentalEvidenceLAService, ValuationBackend.Services.RentalEvidenceLAService>();
builder.Services.AddScoped<ValuationBackend.Services.ISalesEvidenceLAService, ValuationBackend.Services.SalesEvidenceLAService>();
builder.Services.AddScoped<ValuationBackend.Services.ILAMasterfileService, ValuationBackend.Services.LAMasterfileService>();

// Register repositories and services using extension methods
builder.Services.AddRepositories();
builder.Services.AddServices();


// Configure PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure JWT settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

if (jwtSettings == null || string.IsNullOrWhiteSpace(jwtSettings.SecretKey))
{
    throw new InvalidOperationException("JWT settings or SecretKey is not configured correctly.");
}

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
