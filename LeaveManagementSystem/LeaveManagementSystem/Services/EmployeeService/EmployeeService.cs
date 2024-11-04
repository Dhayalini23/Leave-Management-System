using LeaveManagementSystem.IRepository.IEmployeeRepository;
using LeaveManagementSystem.IServices.IEmployeeService;

namespace LeaveManagementSystem.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

    }
}
