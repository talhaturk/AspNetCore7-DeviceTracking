using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IServiceManager serviceManager)
        {
            _logger = logger;
            _userManager = userManager;
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcı oturum açmışsa, kullanıcıyı bulun
                AppUser user = await _userManager.GetUserAsync(User);
                return View(user);

            }

            return View();
        }

        [Authorize(Roles =("Admin"))]
        public async Task<IActionResult> Device()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            var devices = _serviceManager.UserDevicesService.GetAllDevices(false)
                .Where(d => d.AppUserId.Equals(user.Id))
                .AsQueryable();

            //var devices = _serviceManager.DeviceService.GetAllDevices(false);
            

            return View(devices);
        }

    }
}