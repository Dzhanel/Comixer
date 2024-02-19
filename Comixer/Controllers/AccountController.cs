using Comixer.Data.Entities;
using Comixer.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Comixer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            RegisterViewModel model = new()
            {
                ReturnUrl = returnUrl,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var newUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                Email = viewModel.Email,
                UserName = viewModel.Username
            };

            var result = await userManager.CreateAsync(newUser, viewModel.Password);


            if (result.Succeeded)
            {
                await signInManager.PasswordSignInAsync(newUser, viewModel.Password, false, false);
                string redirect = viewModel.ReturnUrl ?? "/Home/Index";
                return Redirect(redirect);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(viewModel);

        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            var viewModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = await userManager.FindByEmailAsync(viewModel.Email);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (viewModel.ReturnUrl != null)
                    {
                        return Redirect(viewModel.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid login");
            return View(viewModel);
        }
    }
}
