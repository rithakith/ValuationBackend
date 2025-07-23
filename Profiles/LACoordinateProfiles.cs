using AutoMapper;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Profiles
{
    public class LACoordinateProfiles : Profile
    {
        public LACoordinateProfiles()
        {
            // PastValuationsLA Coordinate Mappings
            CreateMap<PastValuationsLACoordinate, PastValuationsLACoordinateResponseDto>();
            CreateMap<PastValuationsLACoordinateCreateDto, PastValuationsLACoordinate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PastValuationId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PastValuation, opt => opt.Ignore())
                .ForMember(dest => dest.Masterfile, opt => opt.Ignore());
            CreateMap<PastValuationsLACoordinateUpdateDto, PastValuationsLACoordinate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PastValuation, opt => opt.Ignore())
                .ForMember(dest => dest.Masterfile, opt => opt.Ignore());

            // BuildingRatesLA Coordinate Mappings
            CreateMap<BuildingRatesLACoordinate, BuildingRatesLACoordinateResponseDto>();
            CreateMap<BuildingRatesLACoordinateCreateDto, BuildingRatesLACoordinate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.BuildingRateId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.BuildingRate, opt => opt.Ignore())
                .ForMember(dest => dest.Masterfile, opt => opt.Ignore());
            CreateMap<BuildingRatesLACoordinateUpdateDto, BuildingRatesLACoordinate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.BuildingRate, opt => opt.Ignore())
                .ForMember(dest => dest.Masterfile, opt => opt.Ignore());

            // SalesEvidenceLA Coordinate Mappings
            CreateMap<SalesEvidenceLACoordinate, SalesEvidenceLACoordinateResponseDto>();
            CreateMap<SalesEvidenceLACoordinateCreateDto, SalesEvidenceLACoordinate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SalesEvidenceId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.SalesEvidence, opt => opt.Ignore())
                .ForMember(dest => dest.Masterfile, opt => opt.Ignore());
            CreateMap<SalesEvidenceLACoordinateUpdateDto, SalesEvidenceLACoordinate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.SalesEvidence, opt => opt.Ignore())
                .ForMember(dest => dest.Masterfile, opt => opt.Ignore());

            // RentalEvidenceLA Coordinate Mappings
            CreateMap<RentalEvidenceLACoordinate, RentalEvidenceLACoordinateResponseDto>();
            CreateMap<RentalEvidenceLACoordinateCreateDto, RentalEvidenceLACoordinate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RentalEvidenceId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.RentalEvidence, opt => opt.Ignore())
                .ForMember(dest => dest.Masterfile, opt => opt.Ignore());
            CreateMap<RentalEvidenceLACoordinateUpdateDto, RentalEvidenceLACoordinate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.RentalEvidence, opt => opt.Ignore())
                .ForMember(dest => dest.Masterfile, opt => opt.Ignore());
        }
    }
}
