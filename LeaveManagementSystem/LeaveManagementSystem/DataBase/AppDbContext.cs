using LeaveManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

       public DbSet<Users> Users { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeavePolicy> LeavePolicies { get; set; }
    }
}

