using CRM.IdentityServer.Client;
using CRM.WebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CRM.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RegistryClient _registryClient;

        public HomeController( 
            ILogger<HomeController> logger,
            RegistryClient registryClient)
        {
            _logger = logger;
            _registryClient = registryClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Login(string redirectUrl)
        {
            return View("Index");
        }

        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync("oidc");
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Registry()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Registry(RegistryModel registryModel)
        {
            if (registryModel == null) { return View(); }
            if (!ModelState.IsValid)
            {
                return View(registryModel);
            }

            await _registryClient.RegisterAsync(new AccountRegisterRequestDto
            {
                Login = registryModel.Login,
                Name = registryModel.Name,
                Email = registryModel.Email,
                Password = registryModel.Password
            });

            return RedirectToAction("Index");
        }
    }
}
