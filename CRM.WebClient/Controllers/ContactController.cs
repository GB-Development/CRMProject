using CRM.CrmApi.Client;
using CRM.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace CRM.WebClient.Controllers
{

	[Authorize]
    public class ContactController : Controller
    {
        private readonly CrmApiClient _client;

        public ContactController(CrmApiClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _client.GetAllComponiesAsync();

            return View(companies);
        }

        
        public IActionResult Create(int id)
        {
            return View("Create", new ContactCreateDto
            {
                CompanyId = id,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactCreateDto contact)
        {
			var result = await _client.СreateContactAsync(contact);

			if (result == 0)
			{
				ModelState.AddModelError("", "Error added new contact, return code 0");

				return View(contact);
			}

			return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _client.GetContactByIDAsync(id);
            if (contact is null)
            {
                return NotFound();
            }

            return View("Edit", contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {
            var result = await _client.UpdateContactAsync(new ContactUpdateDto
            {
                CompanyId = contact.CompanyId,
                ContactId = contact.ContactId,
                FullName = contact.FullName,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                Address = contact.Address
            });

            if (!result)
            {
                ModelState.AddModelError("", "Error update contact, result false.");

                return View(contact);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _client.GetContactByIDAsync(id);
            if (contact is null)
            {
                return NotFound();
            }

            return View("Delete", new ContactDeleteDto
            {
                ContactId = contact.ContactId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ContactDeleteDto contact)
        {
            var result = await _client.DeleteContactAsync(contact);

            if (!result)
            {
                ModelState.AddModelError("", "Error delete contact, result false.");

                return View(contact);
            }

            return RedirectToAction("Index");
        }
    }
}
