using ValuationBackend.Repositories;
using ValuationBackend.repositories;
using ValuationBackend.repositories.iteration2;

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
            services.AddScoped<ILMBuildingRatesRepository, LMBuildingRatesRepository>();
            services.AddScoped<ILMPastValuationRepository, LMPastValuationRepository>();
            services.AddScoped<ILMRentalEvidenceRepository, LMRentalEvidenceRepository>();
            services.AddScoped<ILMSalesEvidenceRepository, LMSalesEvidenceRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IAssetNumberChangeRepository, AssetNumberChangeRepository>();
            services.AddScoped<IAssetDivisionRepository, AssetDivisionRepository>();
            services.AddScoped<IReconciliationRepository, ReconciliationRepository>();
            services.AddScoped<IDomesticRatingCardRepository, DomesticRatingCardRepository>();
            services.AddScoped<IOfficesRatingCardRepository, OfficesRatingCardRepository>();
            services.AddScoped<ILAMasterfileRepository, LAMasterfileRepository>();
            services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();


            return services;
        }
    }
}
