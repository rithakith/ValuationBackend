using ValuationBackend.Repositories;

namespace ValuationBackend.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IConditionReportRepository, ConditionReportRepository>();
            services.AddScoped<IBuildingRatesLARepository, BuildingRatesLARepository>();
            services.AddScoped<IPastValuationsLARepository, PastValuationsLARepository>();
            services.AddScoped<IRentalEvidenceLARepository, RentalEvidenceLARepository>();
            services.AddScoped<ISalesEvidenceLARepository, SalesEvidenceLARepository>();
            services.AddScoped<IInspectionReportRepository, InspectionReportRepository>();
            services.AddScoped<ILandMiscellaneousRepository, LandMiscellaneousRepository>();
            // Add other repository registrations here
            return services;
        }
    }
}
