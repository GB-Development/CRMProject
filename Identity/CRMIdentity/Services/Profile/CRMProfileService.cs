using CRMIdentity.Data.Models;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CRMIdentity.Services.Profile
{
    public class CRMProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<CRMUser> _userClaimsPrincipalFactory;
        private readonly UserManager<CRMUser> _userManager;

        public CRMProfileService(
            IUserClaimsPrincipalFactory<CRMUser> userClaimsPrincipalFactory,
            UserManager<CRMUser> userManager)
        {
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            if (context == null) return;

            CRMUser user = await _userManager.GetUserAsync(context.Subject);

            if (user == null) return;

            ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);

            if (userClaims == null) return;

            var t = context.RequestedClaimTypes;

            List<Claim> claims = userClaims.Claims.Where(u => context.RequestedClaimTypes.Contains(u.Type)).ToList();
          
            claims.Add(new Claim(JwtClaimTypes.Name, user.Name));

            if (_userManager.SupportsUserRole)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                foreach (var rolename in roles)
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, rolename));
                }
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            if (context == null) return;
            context.IsActive = (await _userManager.GetUserAsync(context.Subject)) != null;
        }
    }
}
