using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Entity
{
    public class LeavePolicy
    {
        [Key]
        public int ID { get; set; }
        public string LeavePolicyType { get; set; }
        public int MaxDays { get; set; }
        public decimal PayCut { get; set; }
        public int carryOverLimit { get; set; }
    }
}
