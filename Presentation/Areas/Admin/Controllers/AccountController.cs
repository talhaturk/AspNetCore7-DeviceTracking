using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var userList = _userManager.Users.ToList();
            return View(userList);
        }

        public IActionResult Create()
        {
            ViewBag.Roles = GetRolesSelectList();
            return View();
        }

        private SelectList GetRolesSelectList()
        {
            return new SelectList(_roleManager.Roles.ToList(), "Name", "Name", 3);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] RegisterDto model, IFormFile file)
        {
            if(ModelState.IsValid)
            {

                // file operation
                string path = Path.Combine(Directory.GetCurrentDirectory()
                , "wwwroot"
                , "images"
                , "device"
                , file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.ImageUrl = String.Concat("/images/device/", file.FileName);

                var random = new Random();
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    ImageUrl = model.ImageUrl,
                    Id = random.Next(100, 900000)
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            RegisterDto model = new RegisterDto()
            {
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
            };
            ViewBag.Roles = GetRolesSelectList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] RegisterDto model, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                // file operation
                string path = Path.Combine(Directory.GetCurrentDirectory()
                , "wwwroot"
                , "images"
                , "device"
                , file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.ImageUrl = String.Concat("/images/device/", file.FileName);

                AppUser user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Email = model.Email;
                    user.ImageUrl = model.ImageUrl;
                    user.UserName = model.UserName;

                    await _userManager.UpdateAsync(user);

                    var userRoles = await _userManager.GetRolesAsync(user);
                    foreach (var role in userRoles)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                    }

                    var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
                    if (roleResult.Succeeded)
                    {
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, model.Password);
                    }

                    return RedirectToAction("Index", "Account");
                }
            }

            return View();
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index", "Account");
        }
    }
}
