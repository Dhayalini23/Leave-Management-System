using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Entity
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool ? Status { get; set; } = false;
        public int LeavePoliciesID { get; set; }
        public int UsersId { get; set; }

        public LeavePolicy leavePolicies { get; set; }
        public Users users { get; set; }

    }
}
