using LeaveManagementSystem.IRepository.IManagerRepository;
using LeaveManagementSystem.IServices.IManagerService;

namespace LeaveManagementSystem.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

    }
}
