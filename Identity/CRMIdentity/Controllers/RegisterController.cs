using CRMIdentity.Data.Models;
using CRMIdentity.Data.Models.Dto.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRMUserManagementService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<CRMUser> _userManager;

        public RegisterController(UserManager<CRMUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] AccountRegisterRequestDto model)
        {
              
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nameExist = await _userManager.FindByNameAsync(model.Login);
            
            if (nameExist != null) 
            {
                return BadRequest(new AccountRegisterResponseDto("User login already exist"));
            }

            var emailExist = await _userManager.FindByEmailAsync(model.Email);

            if (emailExist != null)
            {
                return BadRequest(new AccountRegisterResponseDto("User with such email already exist"));
            }

            var user = new CRMUser { 
                UserName = model.Login, 
                Name = model.Name, 
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("name", user.Name));
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
            await _userManager.AddToRoleAsync(user, Roles.User);

            return Ok(new AccountRegisterResponseDto(user));
        }

    }
}
