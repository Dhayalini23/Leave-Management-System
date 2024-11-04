namespace LeaveManagementSystem.DTOs.RensponseDTO
{
    public class UsersResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserRole { get; set; }
        //public int ? LeaveRequestId { get; set; }
        public decimal Salary { get; set; }
    }
}
