using CRM.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WebClient.Controllers
{
    [Authorize]
    public class WorkflowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
