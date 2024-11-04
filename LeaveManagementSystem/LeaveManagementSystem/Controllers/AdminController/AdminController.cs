using LeaveManagementSystem.DTOs.RensponseDTO;
using LeaveManagementSystem.DTOs.RequestDTO;
using LeaveManagementSystem.Entity;
using LeaveManagementSystem.IServices.IAdminService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [HttpPost("Add-Users")]
        public async Task<IActionResult> AddUsers(UsersRequestDTO usersRequestDTO)
        {
            try
            {
                var data = await _adminService.AddUsers(usersRequestDTO);
                return Ok(data);
            }
            catch (Exception ex) 
            {
                throw new  Exception(ex.Message);
            }
           
        }

        [HttpGet("All-Users-Show")]
        public async Task<IActionResult> ShowUserAll()
        {
            var data = await _adminService.ShowUserAll();
            return Ok(data);
        }

        [HttpGet("Get-the-userDetails")]
        public async Task<IActionResult> ShowUser(int Id)
        {
            var data = await _adminService.ShowUser(Id);
            return Ok(data);
        }

        [HttpPut("Update-Users/")]
        public async Task<IActionResult> UpdateUser(int Id, UsersRequestDTO usersRequestDTO)
        {
            var data = await _adminService.UpdateUser(Id, usersRequestDTO);
            return Ok(data);
        }

        [HttpDelete("Delete-User")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var data = await _adminService.DeleteUser(Id);
            return Ok(data);
        }

        [HttpPost("Create-Leave-Policy")]
        public async Task<IActionResult> CreateLeavePolicy(LeavePoliciesRequestDTO leavePoliciesRequestDTO)
        {
            try
            {
                var data = await _adminService.CreateLeavePolicy(leavePoliciesRequestDTO);
                return Ok(data);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("Get-LeavePolicy-By-ID")]
        public async Task<IActionResult> GetLeavePolicy(int Id)
        {
            var data = await _adminService.GetLeavePolicy(Id);
            return Ok(data);
        }


        [HttpDelete("Delete-Leave-Policy")]
        public async Task<IActionResult> DeleteLeavePolicy(int Id)
        {
            var data = await _adminService.DeleteLeavePolicy(Id);
            return Ok(data);
        }

        [HttpPost("Create-LeaveRequest-for-Employee")]
        public async Task<IActionResult> CreateLeaveRequest(LeaveRequestRequestDTO leaveRequestDTO)
        {
            var data = await _adminService.CreateLeaveRequest(leaveRequestDTO);
            return Ok(data);
        }

        [HttpGet("Show-the-Leave-Request-By-ID")]
        public async Task<IActionResult> GetLeaveRequest(int Id)
        {
            var data = await _adminService.GetLeaveRequest(Id);
            return Ok(data);
        }

        [HttpPut("Approve-Leave-Request-Admin")]
        public async Task<IActionResult> ApproveLeaveRequest(int Id)
        {
            var data = await _adminService.ApproveLeaveRequest(Id);
            return Ok(data);
        }

    }
}
