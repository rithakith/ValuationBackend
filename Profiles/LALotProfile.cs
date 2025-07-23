using AutoMapper;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Profiles
{
    public class LALotProfile : Profile
    {
        public LALotProfile()
        {
            // Entity to DTO
            CreateMap<LALot, LALotResponseDto>()
                .ForMember(dest => dest.MasterFileRefNo, opt => opt.MapFrom(src => src.MasterFile.MasterFilesRefNo));

            // Create DTO to Entity
            CreateMap<LALotCreateDto, LALot>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.MasterFile, opt => opt.Ignore());

            // Update DTO to Entity
            CreateMap<LALotUpdateDto, LALot>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.MasterFile, opt => opt.Ignore());
        }
    }
}
