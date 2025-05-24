using ValuationBackend.Services;

namespace ValuationBackend.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IConditionReportService, ConditionReportService>();
            services.AddScoped<IBuildingRatesLAService, BuildingRatesLAService>();
            services.AddScoped<IPastValuationsLAService, PastValuationsLAService>();
            services.AddScoped<IRentalEvidenceLAService, RentalEvidenceLAService>();
            services.AddScoped<ISalesEvidenceLAService, SalesEvidenceLAService>();
            services.AddScoped<IInspectionReportService, InspectionReportService>();
            services.AddScoped<ILandMiscellaneousService, LandMiscellaneousService>();
            // Add other service registrations here
            return services;
        }
    }
}
