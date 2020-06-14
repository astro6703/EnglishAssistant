using EnglishAssistant.ViewModels.Shared.Components;
using Microsoft.AspNetCore.Mvc;

namespace EnglishAssistant.Components
{
    public class Profile : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userIdentity = User.Identity;
            var isAuthenticated = userIdentity?.IsAuthenticated ?? false;
            var viewModel = new ProfileViewModel
            {
                IsAuthenticated = isAuthenticated,
                Username = isAuthenticated ? userIdentity.Name : string.Empty
            };

            return View(viewModel);
        }
    }
}