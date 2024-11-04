using LeaveManagementSystem.Entity;

namespace LeaveManagementSystem.IRepository.IAdminRepository
{
    public interface IAdminRepository
    {
        Task<Users> AddUsers(Users users);
        Task<List<Users>> ShowUserAll();
        Task<Users> ShowUser(int Id);
        Task<Users> UpdateUser(Users users);
        Task<String> DeleteUser(Users users);

        Task<LeavePolicy> CreateLeavePolicy(LeavePolicy leavePolicy);
        Task<LeavePolicy> GetLeavePolicy(int id);
        Task<String> DeleteLeavePolicy(LeavePolicy leavePolicy);
        Task<LeaveRequest> CreateLeaveRequest(LeaveRequest leaveRequest);
        Task<LeaveRequest> GetLeaveRequest(int id);
        Task<LeaveRequest> ApproveLeaveRequest(LeaveRequest leaveRequest);
    }
}
