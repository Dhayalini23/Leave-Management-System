using LeaveManagementSystem.IServices.IManagerService;
using LeaveManagementSystem.Services.ManagerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers.ManagerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManagerService _serviceManager;

        public ManagerController(IManagerService serviceManager)
        {
            _serviceManager = serviceManager;
        }
    }
}
