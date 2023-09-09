using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DeviceManager : IDeviceService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public DeviceManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneDevice(DeviceDtoForInsertion deviceDto)
        {
            Device device = _mapper.Map<Device>(deviceDto);
            _manager.Device.Create(device);
            _manager.Save();
        }

        public void DeleteOneDevice(int id)
        {
            Device device = GetOneDevice(id, false);
            if (device != null)
            {
                _manager.Device.RemoveOneDevice(device);
                _manager.Save();
            }
        }

        public IEnumerable<Device> GetAllDevices(bool trackChanges)
        {
            return _manager.Device.GetAllDevices(trackChanges);
        }

        public Device? GetOneDevice(int id, bool trackChanges)
        {
            var device = _manager.Device.GetOneDevice(id, trackChanges);
            if (device is null) 
            {
                throw new Exception("Device Not Found!");
            }
            return device;
        }

        public DeviceDtoForUpdate GetOneDeviceForUpdate(int id, bool trackChanges)
        {
            var device = GetOneDevice(id, trackChanges);
            var deviceDto = _mapper.Map<DeviceDtoForUpdate>(device);
            return deviceDto;
        }

        public void UpdateOneDevice(DeviceDtoForUpdate deviceDto)
        {
            var entity = _mapper.Map<Device>(deviceDto);
            _manager.Device.UpdateOneDevice(entity);
            _manager.Save();
        }
    }
}
