using CRM.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;
    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
}
