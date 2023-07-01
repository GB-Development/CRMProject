using CRM.WebClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WebClient.Controllers
{
    public class WorkflowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Task()
        {
            List<CrmTask> tasks = new List<CrmTask>();
            return View(tasks);
        }

        public IActionResult Company()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
