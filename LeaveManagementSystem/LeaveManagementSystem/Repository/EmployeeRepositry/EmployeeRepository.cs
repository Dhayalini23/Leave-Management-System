using LeaveManagementSystem.DataBase;
using LeaveManagementSystem.IRepository.IEmployeeRepository;

namespace LeaveManagementSystem.Repository.EmployeeRepositry
{
    public class EmployeeRepository : IEmployeeRepository
    { 
        private AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
