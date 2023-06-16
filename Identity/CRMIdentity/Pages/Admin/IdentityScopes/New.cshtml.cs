using CRMIdentity.Pages;
using CRMIdentity.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.Pages.Admin.IdentityScopes;

[SecurityHeaders]
[Authorize]
public class NewModel : PageModel
{
    private readonly IdentityScopeRepository _repository;

    public NewModel(IdentityScopeRepository repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public IdentityScopeModel InputModel { get; set; } = default!;

    public void OnGet()
    {
        InputModel = new IdentityScopeModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            await _repository.CreateAsync(InputModel);
            return RedirectToPage("/Admin/IdentityScopes/Edit", new { id = InputModel.Name });
        }

        return Page();
    }
}