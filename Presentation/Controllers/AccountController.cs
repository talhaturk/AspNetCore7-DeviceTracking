using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] UserForAutheticationDto userForAutheticationDto)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(userForAutheticationDto.UserName);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    var signResult = await _signInManager.PasswordSignInAsync(user, userForAutheticationDto.Password, false, false);
                    if (signResult.Succeeded)
                    {
                        //return Redirect(userForAutheticationDto?.ReturnUrl ?? "/");
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password.");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied([FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            return View();
        }
    }
}
