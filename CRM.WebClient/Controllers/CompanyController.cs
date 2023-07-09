using CRM.CrmApi.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WebClient.Controllers
{

    [Authorize]
    public class CompanyController : Controller
    {
        private readonly CrmApiClient _client;

        public CompanyController(CrmApiClient client)
        {
            _client = client;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Create(CompanyCreateDto company)
		{
            var result = await _client.СreateComponyAsync(company);

            if (result == 0)
            {
                ModelState.AddModelError("", "Error added new conpamy, return code 0");

                return View(company);
            }

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Index()
        {
            var companies = await _client.GetAllComponiesAsync();

            return View(companies);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _client.GetComponyByIDAsync(id);
            if (company is null)
            {
                return NotFound();
            }

            return View("Edit", company);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Company company)
        {
            var result = await _client.UpdateComponyAsync(new CompanyUpdateDto
            {
                CompanyId=company.CompanyId,
                CompanyName=company.CompanyName,
                Inn=company.Inn
            });

            if (!result)
            {
                ModelState.AddModelError("", "Error update company, result false.");

                return View(company);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var company = await _client.GetComponyByIDAsync(id);
            if (company is null)
            {
                return NotFound();
            }

            return View("Delete", new CompanyDeleteDto
            {
                CompanyId = company.CompanyId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CompanyDeleteDto company)
        {
            var result = await _client.DeleteComponyAsync(company);

			if (!result)
			{
				ModelState.AddModelError("", "Error delete company, result false.");

				return View(company);
			}

			return RedirectToAction("Index");
        }
    }
}
