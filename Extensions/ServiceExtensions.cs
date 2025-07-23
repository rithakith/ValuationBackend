using ValuationBackend.Services;
using ValuationBackend.Services.iteration2;

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
            services.AddScoped<ILMBuildingRatesService, LMBuildingRatesService>();
            services.AddScoped<ILMPastValuationService, LMPastValuationService>();
            services.AddScoped<IDomesticRatingCardService, DomesticRatingCardService>();
            services.AddScoped<IOfficesRatingCardService, OfficesRatingCardService>();
            services.AddScoped<ILMRentalEvidenceService, LMRentalEvidenceService>();
            services.AddScoped<ILMSalesEvidenceService, LMSalesEvidenceService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IAssetNumberChangeService, AssetNumberChangeService>();
            services.AddScoped<IAssetDivisionService, AssetDivisionService>();
            services.AddScoped<IReconciliationService, ReconciliationService>();
            services.AddScoped<ILAMasterfileService, LAMasterfileService>();
            services.AddScoped<ILALotService, LALotService>();
            services.AddScoped<IPastValuationsLACoordinateService, PastValuationsLACoordinateService>();
            services.AddScoped<IBuildingRatesLACoordinateService, BuildingRatesLACoordinateService>();
            services.AddScoped<ISalesEvidenceLACoordinateService, SalesEvidenceLACoordinateService>();
            services.AddScoped<IRentalEvidenceLACoordinateService, RentalEvidenceLACoordinateService>();
            services.AddScoped<IRequestTypeService, RequestTypeService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
