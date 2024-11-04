using LeaveManagementSystem.DataBase;
using LeaveManagementSystem.IRepository.IManagerRepository;

namespace LeaveManagementSystem.Repository.ManagerRepository
{
    public class ManagerRepository : IManagerRepository
    {
        private AppDbContext _appDbContext;
        public ManagerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
