using AutoMapper;
using CRM.Data.Entities;
using CRM.Models.DTO.Company.Requests;
using CRM.Models.DTO.Company.Responses;
using CRM.Models.DTO.Contact.Requests;
using CRM.Services.Repositories;
using CRM.Services.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    public ContactController(
        IContactRepository contactRepository, 
        IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    [HttpPost("create"),
        ProducesResponseType(typeof(CreateContactResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<CreateContactResponse>> CreateAsync([FromQuery] CreateContactRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new CreateContactResponse
                {
                    Result = false,
                    StatusCode = 0,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _contactRepository.CreateAsync(_mapper.Map<Contact>(request));

            return Ok(new CreateContactResponse
            {
                Result = true,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new CreateContactResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpGet("get"),
        ProducesResponseType(typeof(GetContactResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<GetContactResponse>> GetAsync([FromQuery] GetContactRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new GetContactResponse
                {
                    Result = null,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _contactRepository.GetByIdAsync(request.CompanyId);


            return Ok(new GetContactResponse
            {
                Result = result,
                StatusCode = 1001,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new GetContactResponse
            {
                Result = null,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpPut("update"),
        ProducesResponseType(typeof(UpdateContactResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<UpdateContactResponse>> UpdateAsync([FromQuery] UpdateContactRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new UpdateContactResponse
                {
                    Result = false,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _contactRepository.UpdateAsync(request.Company);

            return Ok(new UpdateContactResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });

        }
        catch (Exception ex)
        {
            return Ok(new UpdateContactResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpDelete("delete"),
        ProducesResponseType(typeof(DeleteContactResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<DeleteContactResponse>> DeleteAsync([FromQuery] DeleteContactRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new DeleteContactResponse
                {
                    Result = false,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _contactRepository.DeleteAsync(_mapper.Map<Contact>(request));

            return Ok(new DeleteContactResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new DeleteContactResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }
}
