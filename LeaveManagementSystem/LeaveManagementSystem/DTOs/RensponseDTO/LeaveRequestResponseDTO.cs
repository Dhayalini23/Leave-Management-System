namespace LeaveManagementSystem.DTOs.RensponseDTO
{
    public class LeaveRequestResponseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Status { get; set; } = false;
        public int LeavePoliciesID { get; set; }
        public int UsersId { get; set; }
    }
}
