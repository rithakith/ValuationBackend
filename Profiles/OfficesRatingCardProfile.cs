using AutoMapper;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Models;

namespace ValuationBackend.Profiles
{
    public class OfficesRatingCardProfile : Profile
    {
        public OfficesRatingCardProfile()
        {
            // Entity to DTO
            CreateMap<OfficesRatingCard, OfficesRatingCardDto>();

            // Create DTO to Entity
            CreateMap<CreateOfficesRatingCardDto, OfficesRatingCard>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Asset, opt => opt.Ignore());

            // Update DTO to Entity
            CreateMap<UpdateOfficesRatingCardDto, OfficesRatingCard>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AssetId, opt => opt.Ignore())
                .ForMember(dest => dest.NewNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Owner, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Asset, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}