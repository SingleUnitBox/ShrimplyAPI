using AutoMapper;
using ShrimplyAPI.Models.Domain;
using ShrimplyAPI.Models.Dto;

namespace ShrimplyAPI.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Family, FamilyDto>().ReverseMap();
            CreateMap<Family, CreateFamilyRequestDto>().ReverseMap();
            CreateMap<Family, EditFamilyRequestDto>().ReverseMap();
            CreateMap<Shrimp, CreateShrimpRequestDto>().ReverseMap();
            CreateMap<Shrimp, ShrimpDto>().ReverseMap();
            CreateMap<Shrimp, EditShrimpRequestDto>().ReverseMap();
        }
    }
}
