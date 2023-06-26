using AutoMapper;
using CRM.Data.Entities;
using CRM.Models.DTO.Company.Requests;
using CRM.Models.DTO.Company.Responses;
using CRM.Models.DTO.Deal.Requests;
using CRM.Models.DTO.Deal.Responses;
using CRM.Services.Repositories;
using CRM.Services.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DealController : ControllerBase
{
    private readonly IDealRepository _dealRepository;
    private readonly IMapper _mapper;
    public DealController(
        IDealRepository dealRepository, 
        IMapper mapper)
    {
        _dealRepository = dealRepository;
        _mapper = mapper;
    }

    [HttpPost("create"),
        ProducesResponseType(typeof(CreateDealResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<CreateDealResponse>> CreateAsync([FromQuery] CreateDealRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new CreateDealResponse
                {
                    Result = false,
                    StatusCode = 0,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _dealRepository.CreateAsync(_mapper.Map<Deal>(request));

            return Ok(new CreateDealResponse
            {
                Result = true,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new CreateDealResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpGet("get"),
        ProducesResponseType(typeof(GetDealResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<GetDealResponse>> GetAsync([FromQuery] GetDealRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new GetDealResponse
                {
                    Result = null,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _dealRepository.GetByIdAsync(request.DealId);


            return Ok(new GetDealResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new GetDealResponse
            {
                Result = null,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpGet("get-all"),
        ProducesResponseType(typeof(GetAllDealResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllDealResponse>> GetAllAsync()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new GetAllDealResponse
                {
                    Result = null,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _dealRepository.GetAllAsync();


            return Ok(new GetAllDealResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new GetAllDealResponse
            {
                Result = null,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpPut("update"),
        ProducesResponseType(typeof(UpdateDealResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<UpdateDealResponse>> UpdateAsync([FromQuery] UpdateDealRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new UpdateDealResponse
                {
                    Result = false,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _dealRepository.UpdateAsync(request.Deal);

            return Ok(new UpdateDealResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });

        }
        catch (Exception ex)
        {
            return Ok(new UpdateDealResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpDelete("delete"),
        ProducesResponseType(typeof(DeleteDealResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<DeleteDealResponse>> DeleteAsync([FromQuery] DeleteDealRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Ok(new DeleteDealResponse
                {
                    Result = false,
                    StatusCode = 1001,
                    ErrorMessage = $"Данные не прошли валидацию! ({string.Join(',', ModelState.Values)})"
                });
            }

            var result = await _dealRepository.DeleteAsync(_mapper.Map<Deal>(request));

            return Ok(new DeleteDealResponse
            {
                Result = result,
                StatusCode = 200,
                ErrorMessage = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new DeleteDealResponse
            {
                Result = false,
                StatusCode = 1001,
                ErrorMessage = ex.Message
            });
        }
    }
}
