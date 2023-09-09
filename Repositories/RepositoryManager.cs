using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly IDeviceRepository _deviceRepository;

        private readonly IUserDevicesRepository _userDevicesRepository;

        public RepositoryManager(RepositoryContext context, IDeviceRepository deviceRepository, IUserDevicesRepository userDevicesRepository)
        {
            _context = context;
            _deviceRepository = deviceRepository;
            _userDevicesRepository = userDevicesRepository;
        }

        public IDeviceRepository Device => _deviceRepository;
        public IUserDevicesRepository UserDevices => _userDevicesRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
