using CRM.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WebClient.Controllers
{

    [Authorize]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            List<CrmContact> contacts = new List<CrmContact>
            {
                new CrmContact
                {
                    ContactId = 1,
                    CompanyId = 1,
                    Address = "Address-1",
                    Email = "email1@example.com",
                    FullName = "Lastname Firstname Patronymic - 1",
                    PhoneNumber = "+71234567890"
                },
                new CrmContact
                {
                    ContactId = 2,
                    CompanyId = 1,
                    Address = "Address-1",
                    Email = "email2@example.com",
                    FullName = "Lastname Firstname Patronymic - 2",
                    PhoneNumber = "+71234567891"
                },
                new CrmContact
                {
                    ContactId = 3,
                    CompanyId = 2,
                    Address = "Address-2",
                    Email = "email3@example.com",
                    FullName = "Lastname Firstname Patronymic - 3",
                    PhoneNumber = "+71234567892"
                }
            };

            return View(contacts);
        }
    }
}
