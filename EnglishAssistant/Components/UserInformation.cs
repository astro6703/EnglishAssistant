using EnglishAssistant.ViewModels.Shared.Components;
using Microsoft.AspNetCore.Mvc;

namespace EnglishAssistant.Components
{
    public class UserInformation : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userIdentity = User.Identity;
            var isAuthenticated = userIdentity?.IsAuthenticated ?? false;
            var viewModel = new UserInformationViewModel
            {
                IsAuthenticated = isAuthenticated,
                Username = isAuthenticated ? userIdentity.Name : string.Empty
            };

            return View(viewModel);
        }
    }
}