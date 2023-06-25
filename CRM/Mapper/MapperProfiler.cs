using AutoMapper;
using CRM.Data.Entities;
using CRM.Models.DTO.Company.Requests;

namespace CRM.Mapper;

public class MapperProfiler : Profile
{
    public MapperProfiler()
    {
        CreateMap<CreateComponyRequest, Company>();
        CreateMap<DeleteComponyRequest, Company>();
        CreateMap<UpdateComponyRequest, Company>();
    }
}
