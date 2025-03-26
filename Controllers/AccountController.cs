using CloudDoc.Models;
using CloudDoc.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CloudDoc.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AccountController(SignInManager<AppUser> singIngManager,UserManager<AppUser> userManager)
        {
            _signInManager = singIngManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserLogInViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userViewModel.UserName, userViewModel.Password, userViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "result.Error");
            }
            return View(userViewModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    FullName = userViewModel.FullName,
                    Address = userViewModel.Address
                };
                var result = await _userManager.CreateAsync(user, userViewModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
