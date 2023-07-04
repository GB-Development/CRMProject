using CRM.CRMapi.Client;
using CRM.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WebClient.Controllers
{

    [Authorize]
    public class CompanyController : Controller
    {
        private readonly CrmClient _client;

        public CompanyController(CrmClient client)
        {
            _client = client;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Create(CompanyCreateDto company)
		{
            await _client.CreateAsync(company);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Index()
        {
            var companies = await _client.GetAllAllAsync();
            List<CrmCompany> companies2 = new List<CrmCompany>();

            foreach (var companyApi in companies)
            {
                var clientCompany = new CrmCompany
                {
                    CompanyName = companyApi.CompanyName,
                    CompanyId = companyApi.CompanyId,
                    INN = companyApi.Inn
                };
                companies2.Add(clientCompany);
            }


            return View(companies2);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _client.GetByIDAsync(id);
            if (company is null)
            {
                return NotFound();
            }

            return View("Edit", company);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Company company)
        {
            await _client.UpdateAsync(new CompanyUpdateDto
            {
                CompanyId=company.CompanyId,
                CompanyName=company.CompanyName,
                Inn=company.Inn
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var company = await _client.GetByIDAsync(id);
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
            await _client.DeleteAsync(company);

            return RedirectToAction("Index");
        }
    }
}
