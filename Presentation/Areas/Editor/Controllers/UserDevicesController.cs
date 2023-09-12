using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace Presentation.Areas.Editor.Controllers
{
    [Area("Editor")]
    [Authorize(Roles = "Editor")]
    public class UserDevicesController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public UserDevicesController(IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userDevices = _serviceManager.UserDevicesService.GetAllDevices(false)
                .OrderBy(d => d.UserDevicesId);
            return View(userDevices);
        }

        public IActionResult Create()
        {
            ViewBag.Users = GetUsersSelectList();
            ViewBag.Devices = GetDevicesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] UserDevices userDevices)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.UserDevicesService.CreateOneDevice(userDevices);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserChange([FromRoute(Name = "id")] int id)
        {
            ViewBag.Users = GetUsersSelectList();
            var userDevices = _serviceManager.UserDevicesService.GetOneDevice(id, false);
            return View(userDevices);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserChange(UserDevices userDevices)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.UserDevicesService.UpdateOneDevice(userDevices);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _serviceManager.UserDevicesService.DeleteOneDevice(id);
            return RedirectToAction("Index");
        }

        private SelectList GetUsersSelectList()
        {
            return new SelectList(_userManager.Users.ToList(), "Id", "Name", 1);
        }

        private SelectList GetDevicesSelectList()
        {
            // UserDevices tablosundaki Device nesnelerinin id listesi
            var idList = _serviceManager.UserDevicesService.GetAllDevices(false).Select(d => d.DeviceId).ToList();

            // UserDevices tablosunda olmayan Device nesnelerini SelectList'e alma
            return new SelectList(
                _serviceManager
                .DeviceService
                .GetAllDevices(false)
                .Where(d => !idList.Contains(d.DeviceId))
                , "DeviceId"
                , "DeviceName"
                , 1);
        }
    }
}
