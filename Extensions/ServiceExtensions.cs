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
            services.AddScoped<ILMBuildingRatesService, LMBuildingRatesService>();
            services.AddScoped<ILMRentalEvidenceService, LMRentalEvidenceService>();
            services.AddScoped<ILMSalesEvidenceService, LMSalesEvidenceService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IAssetNumberChangeService, AssetNumberChangeService>();
            services.AddScoped<IAssetDivisionService, AssetDivisionService>();
            services.AddScoped<ILAMasterfileService, LAMasterfileService>();
            services.AddScoped<IRequestTypeService, RequestTypeService>();
            services.AddScoped<IRequestService, RequestService>();

            return services;
        }
    }
}
