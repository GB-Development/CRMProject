using AutoMapper;
using CRM.Data.Entities;
using CRM.Models.DTO.Company.Requests;
using CRM.Models.DTO.Contact.Requests;

namespace CRM.Mapper;

public class MapperProfiler : Profile
{
    public MapperProfiler()
    {
        CreateMap<CreateCompanyRequest, Company>();
        CreateMap<DeleteCompanyRequest, Company>();

        CreateMap<CreateContactRequest, Contact>();
        CreateMap<DeleteContactRequest, Contact>();
    }
}
