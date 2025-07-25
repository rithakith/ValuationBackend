using ValuationBackend.Repositories;
using ValuationBackend.Repositories.iteration2;

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
            services.AddScoped<ILALotRepository, LALotRepository>();
            services.AddScoped<IPastValuationsLACoordinateRepository, PastValuationsLACoordinateRepository>();
            services.AddScoped<IBuildingRatesLACoordinateRepository, BuildingRatesLACoordinateRepository>();
            services.AddScoped<ISalesEvidenceLACoordinateRepository, SalesEvidenceLACoordinateRepository>();
            services.AddScoped<IRentalEvidenceLACoordinateRepository, RentalEvidenceLACoordinateRepository>();
            services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<II2RentalEvidenceRepository, I2RentalEvidenceRepository>();


            return services;
        }
    }
}
