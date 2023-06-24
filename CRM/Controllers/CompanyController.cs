using AutoMapper;
using CRM.Data.Entities;
using CRM.Models.DTO.Company.Requests;
using CRM.Models.DTO.Company.Responses;
using CRM.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public CompanyController(
        ICompanyRepository companyRepository, 
        IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public ActionResult<CreateComponyResponse> Create(CreateComponyRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new CreateComponyResponse
                {
                    Result = false,
                    StatusCode = 0,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = _companyRepository.Create(_mapper.Map<Company>(request));

            return Ok(new CreateComponyResponse
            {
                Result = true,
                StatusCode = 400,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new CreateComponyResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    public ActionResult<GetComponyResponse> Get(GetComponyRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new GetComponyResponse
                {
                    Result = null,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = _companyRepository.Get(request.CompanyId);


            return Ok(new GetComponyResponse
            {
                Result = result,
                StatusCode = 1001,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new GetComponyResponse
            {
                Result = null,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    public ActionResult<UpdateComponyResponse> Update(UpdateComponyRequest request)
    {
        var response = new UpdateComponyResponse();
        return Ok(response);
    }

    public ActionResult<DeleteComponyResponse> Delete(DeleteComponyRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new DeleteComponyResponse
                {
                    Result = false,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = _companyRepository.Delete(_mapper.Map<Company>(request));

            return Ok(new DeleteComponyResponse
            {
                Result = result,
                StatusCode = 400,
                ErrorMessage = null
            }); 
        }
        catch (Exception ex)
        {
            return Ok(new DeleteComponyResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }
}
