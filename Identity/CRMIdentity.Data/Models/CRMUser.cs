using Microsoft.AspNetCore.Identity;

namespace CRMIdentity.Data.Models
{
    public class CRMUser: IdentityUser
    {
        public string? Name { get; set; }
    }
}
