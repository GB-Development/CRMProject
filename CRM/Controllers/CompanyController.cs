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

    [   HttpPost("create"), 
        ProducesResponseType(typeof(CreateComponyResponse), 
        StatusCodes.Status200OK)]
    public ActionResult<CreateComponyResponse> Create([FromQuery] CreateComponyRequest request)
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
                StatusCode = 200,
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

    [   HttpGet("get"),
        ProducesResponseType(typeof(GetComponyResponse),
        StatusCodes.Status200OK)]
    public ActionResult<GetComponyResponse> Get([FromQuery] GetComponyRequest request)
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

    [   HttpPut("update"),
        ProducesResponseType(typeof(UpdateComponyResponse),
        StatusCodes.Status200OK)]
    public ActionResult<UpdateComponyResponse> Update([FromQuery] UpdateComponyRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new UpdateComponyResponse
                {
                    Result = _mapper.Map<Company>(request),
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = _companyRepository.Update(request.Company);

            return Ok(new UpdateComponyResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });

        }
        catch (Exception ex)
        {
            return Ok(new UpdateComponyResponse
            {
                Result = null,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [   HttpDelete("delete"),
        ProducesResponseType(typeof(DeleteComponyResponse),
        StatusCodes.Status200OK)]
    public ActionResult<DeleteComponyResponse> Delete([FromQuery] DeleteComponyRequest request)
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
                StatusCode = 200,
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
