using CloudDoc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CloudDoc.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserController(SignInManager<User> singIngManager,UserManager<User> userManager)
        {
            _signInManager = singIngManager;
            _userManager = userManager;
        }
        public IActionResult LogIn()
        {

            return View();
        }
    }
}
