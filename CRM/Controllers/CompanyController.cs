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
        ProducesResponseType(typeof(CreateCompanyResponse), 
        StatusCodes.Status200OK)]
    public async Task<ActionResult<CreateCompanyResponse>> CreateAsync([FromQuery] CreateCompanyRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new CreateCompanyResponse
                {
                    Result = false,
                    StatusCode = 0,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _companyRepository.CreateAsync(_mapper.Map<Company>(request));

            return Ok(new CreateCompanyResponse
            {
                Result = true,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new CreateCompanyResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [   HttpGet("get"),
        ProducesResponseType(typeof(GetCompanyResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<GetCompanyResponse>> GetAsync([FromQuery] GetCompanyRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new GetCompanyResponse
                {
                    Result = null,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _companyRepository.GetByIdAsync(request.CompanyId);


            return Ok(new GetCompanyResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new GetCompanyResponse
            {
                Result = null,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpGet("get-all"),
        ProducesResponseType(typeof(GetAllCompanyResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllCompanyResponse>> GetAllAsync()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new GetAllCompanyResponse
                {
                    Result = null,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _companyRepository.GetAllAsync();


            return Ok(new GetAllCompanyResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new GetAllCompanyResponse
            {
                Result = null,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [   HttpPut("update"),
        ProducesResponseType(typeof(UpdateCompanyResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<UpdateCompanyResponse>> UpdateAsync([FromQuery] UpdateCompanyRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new UpdateCompanyResponse
                {
                    Result = false,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _companyRepository.UpdateAsync(request.Company);

            return Ok(new UpdateCompanyResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });

        }
        catch (Exception ex)
        {
            return Ok(new UpdateCompanyResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [   HttpDelete("delete"),
        ProducesResponseType(typeof(DeleteCompanyResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<DeleteCompanyResponse>> DeleteAsync([FromQuery] DeleteCompanyRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new DeleteCompanyResponse
                {
                    Result = false,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _companyRepository.DeleteAsync(_mapper.Map<Company>(request));

            return Ok(new DeleteCompanyResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            }); 
        }
        catch (Exception ex)
        {
            return Ok(new DeleteCompanyResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }
}
