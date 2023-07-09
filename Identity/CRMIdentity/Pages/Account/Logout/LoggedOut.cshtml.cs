using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRMIdentity.Pages.Logout
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class LoggedOut : PageModel
    {
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly ILogger<LoggedOut> _logger;

        public LoggedOutViewModel View { get; set; }

        public LoggedOut(IIdentityServerInteractionService interactionService, ILogger<LoggedOut> logger)
        {
            _interactionService = interactionService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet(string logoutId)
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interactionService.GetLogoutContextAsync(logoutId);

            View = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = LogoutOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = String.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl
            };

            await Task.Delay(1000);

            if (string.IsNullOrEmpty(logout?.PostLogoutRedirectUri) == false)
            {
                try
                {
                    return Redirect($"https://{new Uri(logout?.PostLogoutRedirectUri).Authority}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Logout redirect url create error. Message: {ex.Message}");
                }
            }

            return RedirectToPage("/Account/Login/Index");

        }
    }
}