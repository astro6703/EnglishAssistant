using System;
using System.Linq;
using System.Threading.Tasks;
using EnglishAssistant.Models.User;
using EnglishAssistant.RequestParameters;
using EnglishAssistant.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnglishAssistant.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel { IsSuccessfulAttempt = true };
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserRequestParameters userRequestParameters)
        {
            var user = await userManager.FindByNameAsync(userRequestParameters.Username);

            if (user != null)
            {
                await signInManager.SignOutAsync();
                var signInResult = await signInManager.PasswordSignInAsync(user,
                                                                           userRequestParameters.Password,
                                                                           isPersistent: true,
                                                                           lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            var viewModel = new LoginViewModel
            {
                IsSuccessfulAttempt = false,
                Username = userRequestParameters.Username
            };
            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View(new LoginViewModel { IsSuccessfulAttempt = true });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(UserRequestParameters userRequestParameters)
        {
            var user = new User { UserName = userRequestParameters.Username };
            var identityResult = await userManager.CreateAsync(user, userRequestParameters.Password);

            if (identityResult.Succeeded)
            {
                await signInManager.PasswordSignInAsync(user,
                                                        userRequestParameters.Password,
                                                        isPersistent: true,
                                                        lockoutOnFailure: false);

                return RedirectToAction("Index", "Home");
            }

            var viewModel = new LoginViewModel
            {
                IsSuccessfulAttempt = false,
                ModelErrors = identityResult.Errors
                                            .Select(x => x.Description)
                                            .ToArray(),
                Username = userRequestParameters.Username
            };
            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}