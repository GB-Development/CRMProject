using CRM.CrmApi.Client;
using CRM.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM.WebClient.Controllers
{

    [Authorize]
    public class DealController : Controller
    {
		private readonly CrmApiClient _client;

		public DealController(CrmApiClient client)
		{
			_client = client;
		}
		public async Task<IActionResult> Index()
        {
            var deals = await _client.GetAllDealsAsync();

            return View(deals);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var deal = new DealCreateDto { 
                ManagerId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value 
            };

            var companies = await _client.GetAllComponiesAsync();

            var data = companies.Select(x => new SelectListItem { Text = x.CompanyName, Value = x.CompanyId.ToString() });

			ViewBag.Companies = data;

			return View(deal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DealCreateDto deal)
        {
            var result = await _client.СreateDealAsync(deal);

            if (result == 0)
            {
                ModelState.AddModelError("", "Error added new deal, return code 0");

                return View(deal);
            }

            return RedirectToAction("Index");
        }

		public async Task<IActionResult> Delete(int id)
		{
			var deal = await _client.GetDealByIDAsync(id);
			if (deal is null)
			{
				return NotFound();
			}

			return View("Delete", new DealDeleteDto
			{
				DealId = deal.DealId
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(DealDeleteDto deal)
		{
			var result = await _client.DeleteDealAsync(deal);

			if (!result)
			{
				ModelState.AddModelError("", "Error delete deal, result false.");

				return View(deal);
			}

			return RedirectToAction("Index");
		}
	}
}
