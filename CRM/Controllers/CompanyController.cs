using CRM.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
}
