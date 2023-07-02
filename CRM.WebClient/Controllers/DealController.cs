using CRM.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WebClient.Controllers
{

    [Authorize]
    public class DealController : Controller
    {
        public IActionResult Index()
        {
            List<CrmDeal> deals = new List<CrmDeal> 
            {
                new CrmDeal
                {
                    ManagerId = Guid.NewGuid().ToString(),
                    Company = new CrmCompany
                    {
                        CompanyName = "Company-1",
                        INN = "11111111",
                        WebSite = "info@company1.com"
                    },
                    DateContact = DateTime.Now
                },
                new CrmDeal
                {
                    ManagerId = Guid.NewGuid().ToString(),
                    Company = new CrmCompany
                    {
                        CompanyName = "Company-2",
                        INN = "22222222",
                        WebSite = "info@company2.com"
                    },
                    DateContact = DateTime.Now
                },
                new CrmDeal
                {
                    ManagerId = Guid.NewGuid().ToString(),
                    Company = new CrmCompany
                    {
                        CompanyName = "Company-3",
                        INN = "33333333",
                        WebSite = "info@company3.com"
                    },
                    DateContact = DateTime.Now
                }
            };
            return View(deals);
        }
    }
}
