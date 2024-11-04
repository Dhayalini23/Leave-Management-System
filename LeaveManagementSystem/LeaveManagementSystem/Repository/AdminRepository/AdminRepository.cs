using LeaveManagementSystem.DataBase;
using LeaveManagementSystem.Entity;
using LeaveManagementSystem.IRepository.IAdminRepository;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Repository.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Users> AddUsers(Users users)
        {
            await _appDbContext.AddAsync(users);
            await _appDbContext.SaveChangesAsync();
            return users;
        }

        public async Task<List<Users>>  ShowUserAll()
        {
             var data = await _appDbContext.Users.ToListAsync();
            return data;
        }

        public async Task<Users> ShowUser(int Id)
        {
            var data = await _appDbContext.Users.SingleOrDefaultAsync(x => x.Id == Id);
            return data;
        }

        public async Task<Users> UpdateUser(Users users)
        {
            _appDbContext.Users.Update(users);
            _appDbContext.SaveChanges();
            return users;
        }

        public async Task<String> DeleteUser(Users users)
        {
            _appDbContext.Users.Remove(users);
            await _appDbContext.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<LeavePolicy> CreateLeavePolicy(LeavePolicy leavePolicy)
        {
            await _appDbContext.LeavePolicies.AddAsync(leavePolicy);
            await _appDbContext.SaveChangesAsync();
            return leavePolicy;
        }

        public async Task<LeavePolicy> GetLeavePolicy(int id)
        {
            var data = await _appDbContext.LeavePolicies.SingleOrDefaultAsync(x => x.ID == id);
            return data;
        }

        public async Task<String> DeleteLeavePolicy(LeavePolicy leavePolicy)
        {
             _appDbContext.Remove(leavePolicy);
            await _appDbContext.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<LeaveRequest> CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            await _appDbContext.LeaveRequests.AddAsync(leaveRequest);
            await _appDbContext.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> GetLeaveRequest(int id)
        {
            var data = await _appDbContext.LeaveRequests.SingleOrDefaultAsync(x => x.Id == id);
            return data;

        }

        public async Task<LeaveRequest> ApproveLeaveRequest(LeaveRequest leaveRequest)
        {
            _appDbContext.LeaveRequests.Update(leaveRequest);
            await _appDbContext.SaveChangesAsync();
            return leaveRequest;
        }


    }
}
