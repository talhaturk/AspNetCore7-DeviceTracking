using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Contracts;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DevicesController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public DevicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Device> devices = _serviceManager.DeviceService.GetAllDevices(false)
                .OrderBy(d => d.DeviceId);
            return View(devices);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] DeviceDtoForInsertion deviceDto, IFormFile file)
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
                deviceDto.ImageUrl = String.Concat("/images/device/", file.FileName);


                _serviceManager.DeviceService.CreateOneDevice(deviceDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            DeviceDtoForUpdate device = _serviceManager.DeviceService.GetOneDeviceForUpdate(id, false);
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] DeviceDtoForUpdate deviceDto, IFormFile file)
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
                deviceDto.ImageUrl = String.Concat("/images/device/", file.FileName);

                _serviceManager.DeviceService.UpdateOneDevice(deviceDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _serviceManager.DeviceService.DeleteOneDevice(id);
            return RedirectToAction("Index");
        }

    }
}