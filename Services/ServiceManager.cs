using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IDeviceService _deviceService;
        private readonly IUserDevicesService _userDevicesService;

        public ServiceManager(IDeviceService deviceService, IUserDevicesService userDevicesService)
        {
            _deviceService = deviceService;
            _userDevicesService = userDevicesService;
        }

        public IDeviceService DeviceService => _deviceService;
        public IUserDevicesService UserDevicesService => _userDevicesService;
    }
}
