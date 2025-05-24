using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories
builder.Services.AddScoped<ValuationBackend.Repositories.IConditionReportRepository, ValuationBackend.Repositories.ConditionReportRepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IBuildingRatesLARepository, ValuationBackend.Repositories.BuildingRatesLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IPastValuationsLARepository, ValuationBackend.Repositories.PastValuationsLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.IRentalEvidenceLARepository, ValuationBackend.Repositories.RentalEvidenceLARepository>();
builder.Services.AddScoped<ValuationBackend.Repositories.ISalesEvidenceLARepository, ValuationBackend.Repositories.SalesEvidenceLARepository>();

// Register services
builder.Services.AddScoped<ValuationBackend.Services.IConditionReportService, ValuationBackend.Services.ConditionReportService>();
builder.Services.AddScoped<ValuationBackend.Services.IBuildingRatesLAService, ValuationBackend.Services.BuildingRatesLAService>();
builder.Services.AddScoped<ValuationBackend.Services.IPastValuationsLAService, ValuationBackend.Services.PastValuationsLAService>();
builder.Services.AddScoped<ValuationBackend.Services.IRentalEvidenceLAService, ValuationBackend.Services.RentalEvidenceLAService>();
builder.Services.AddScoped<ValuationBackend.Services.ISalesEvidenceLAService, ValuationBackend.Services.SalesEvidenceLAService>();

// Configure PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Build app
var app = builder.Build();

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Initialize(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
