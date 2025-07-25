using AutoMapper;
using ValuationBackend.DTOs.iteration2;
using ValuationBackend.Models.iteration2;

namespace ValuationBackend.Mappings
{
    public class I2RentalEvidenceProfile : Profile
    {
        public I2RentalEvidenceProfile()
        {
            CreateMap<I2RentalEvidence, I2RentalEvidenceDto>();
            CreateMap<CreateI2RentalEvidenceDto, I2RentalEvidence>();
            CreateMap<UpdateI2RentalEvidenceDto, I2RentalEvidence>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}