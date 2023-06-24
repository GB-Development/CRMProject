using AutoMapper;
using CRM.Data.Entities;
using CRM.Models.DTO.Company.Requests;

namespace CRM.Mapper;

public class MapperProfiler : Profile
{
    public MapperProfiler()
    {
        CreateMap<Company, CreateComponyRequest>();
        CreateMap<Company, DeleteComponyRequest>();
    }
}
