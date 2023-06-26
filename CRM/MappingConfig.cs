using AutoMapper;
using CRM.Controllers;
using CRM.Model.DTO;
using CRM.Model.Entities;

namespace CRM


{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<CompanyCreateDto, Company>().ReverseMap();
            CreateMap<CompanyUpdateDto, Company>().ReverseMap();
            CreateMap<CompanyDeleteDto, Company>().ReverseMap();

            CreateMap<ContactCreateDto, Contact>().ReverseMap();
            CreateMap<ContactUpdateDto, Contact>().ReverseMap();
            CreateMap<ContactDeleteDto, Contact>().ReverseMap();

            CreateMap<DealCreateDto, Deal>().ReverseMap();
            CreateMap<DealUpdateDto, Deal>().ReverseMap();
            CreateMap<DealDeleteDto, Deal>().ReverseMap();
        }

    }
}
