﻿using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserDevicesController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public UserDevicesController(IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userDevices = _serviceManager.UserDevicesService.GetAllDevices(false)
                .OrderBy(d => d.UserDevicesId);
            return View(userDevices);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = GetUsersSelectList();
            ViewBag.Devices = GetDevicesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] UserDevices userDevices)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.UserDevicesService.CreateOneDevice(userDevices);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public IActionResult UserChange([FromRoute(Name = "id")] int id)
        {
            ViewBag.Users = GetUsersSelectList();
            var userDevices = _serviceManager.UserDevicesService.GetOneDevice(id, false);
            return View(userDevices);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserChange([FromBody]UserDevices userDevices)
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
            var deviceList = new SelectList(
                _serviceManager
                .DeviceService
                .GetAllDevices(false)
                .Where(d => !idList.Contains(d.DeviceId))
                , "DeviceId"
                , "DeviceName"
                , 1);

            if (deviceList == null || !deviceList.Any())
            {
                ModelState.AddModelError("deviceList", "Device list is empty.");
            }

            
            return deviceList;
        }
    }
}
