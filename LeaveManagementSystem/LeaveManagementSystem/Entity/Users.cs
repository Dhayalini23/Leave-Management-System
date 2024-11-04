using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Entity
{
    public class Users
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserRole { get; set; }
        public decimal Salary { get; set; }
        public List<LeaveRequest> ? LeaveRequests { get; set; } 

    }
}
