using CRM.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WebClient.Controllers
{

    [Authorize]
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            List<CrmCompany> companies = new List<CrmCompany> 
            { 
                new CrmCompany
                {
                    CompanyName = "Company-1",
                    INN = "11111111",
                    WebSite = "info@company1.com"
                },
                new CrmCompany
                {
                    CompanyName = "Company-2",
                    INN = "22222222",
                    WebSite = "info@company2.com"
                },
                new CrmCompany
                {
                    CompanyName = "Company-3",
                    INN = "33333333",
                    WebSite = "info@company3.com"
                },
            };
            return View(companies);
        }
    }
}
