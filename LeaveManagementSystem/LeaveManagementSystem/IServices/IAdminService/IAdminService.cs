using LeaveManagementSystem.DTOs.RensponseDTO;
using LeaveManagementSystem.DTOs.RequestDTO;
using LeaveManagementSystem.Entity;

namespace LeaveManagementSystem.IServices.IAdminService
{
    public interface IAdminService
    {
        Task<UsersResponseDTO> AddUsers(UsersRequestDTO usersRequestDTO);
        Task<List<UsersResponseDTO>> ShowUserAll();
        Task<UsersResponseDTO> ShowUser(int Id);
        Task<UsersResponseDTO> UpdateUser(int Id, UsersRequestDTO usersRequestDTO);
        Task<String> DeleteUser(int Id);
        Task<LeavePoliciesResponseDTO> CreateLeavePolicy(LeavePoliciesRequestDTO leavePoliciesRequestDTO);
        Task<LeavePoliciesResponseDTO> GetLeavePolicy(int id);
        Task<String> DeleteLeavePolicy(int id);
        Task<LeaveRequestResponseDTO> CreateLeaveRequest(LeaveRequestRequestDTO leaveRequestDTO);
        Task<LeaveRequestResponseDTO> GetLeaveRequest(int id);
        Task<LeaveRequestResponseDTO> ApproveLeaveRequest(int id);

    }
}
