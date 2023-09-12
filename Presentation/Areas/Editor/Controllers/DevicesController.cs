using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Contracts;

namespace Presentation.Areas.Editor.Controllers
{
    [Area("Editor")]
    [Authorize(Roles = "Editor")]
    public class DevicesController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public DevicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Device> devices = _serviceManager.DeviceService.GetAllDevices(false)
                .OrderBy(d => d.DeviceId);
            return View(devices);
        }

    }
}
