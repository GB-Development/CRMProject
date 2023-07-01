using Microsoft.AspNetCore.Mvc;

namespace CRM.WebClient.Controllers
{
    public class WorkflowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
