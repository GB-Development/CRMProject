using CRMIdentity.Pages;
using CRMIdentity.Repository;
using IdentityServer.Pages.Admin.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.Pages.Admin.ApiScopes;

[SecurityHeaders]
[Authorize]
public class NewModel : PageModel
{
    private readonly ApiScopeRepository _repository;

    public NewModel(ApiScopeRepository repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public ApiScopeModel InputModel { get; set; } = default!;
        
    public void OnGet()
    {
        InputModel = new ApiScopeModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            await _repository.CreateAsync(InputModel);
            return RedirectToPage("/Admin/ApiScopes/Edit", new { id = InputModel.Name });
        }

        return Page();
    }
}