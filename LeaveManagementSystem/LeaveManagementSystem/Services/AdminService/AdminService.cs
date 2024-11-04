using LeaveManagementSystem.DTOs.RensponseDTO;
using LeaveManagementSystem.DTOs.RequestDTO;
using LeaveManagementSystem.Entity;
using LeaveManagementSystem.IRepository.IAdminRepository;
using LeaveManagementSystem.IServices.IAdminService;

namespace LeaveManagementSystem.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<UsersResponseDTO> AddUsers(UsersRequestDTO usersRequestDTO)
        {
            if (usersRequestDTO.UserRole == "Manager" || usersRequestDTO.UserRole == "Employee")
            {
                var users = new Users();
                users.Name = usersRequestDTO.Name;

                users.UserRole = usersRequestDTO.UserRole;
                users.Salary = usersRequestDTO.Salary;

                var data = await _adminRepository.AddUsers(users);

                var LeaveRequestList = new List<LeaveRequest>();
                foreach (var item in LeaveRequestList)
                {
                    var leaveRequest = new List<LeaveRequest>();
                    var UsersId = item.UsersId;
                    var LeavePoliciesID = item.LeavePoliciesID;
                    var Date = item.Date;
                }



                var userResponse = new UsersResponseDTO();
                userResponse.Name = data.Name;
                userResponse.UserRole = data.UserRole;
                userResponse.Salary = data.Salary;
                return userResponse;
            }
            else
            {
                throw new Exception("Invalid Role Declaration Employee and Manager only Create Account");
            }
              



          
        }



        public async Task<List<UsersResponseDTO>> ShowUserAll()
        {
            var userList = await _adminRepository.ShowUserAll();

            var userResponseList = new List<UsersResponseDTO>();

            foreach (var user in userList)
            {
                var userResponse = new UsersResponseDTO
                {
                    Name = user.Name,
                    UserRole = user.UserRole,
                    Salary = user.Salary
                };

                userResponseList.Add(userResponse);
            }

            return userResponseList;
        }

        public async Task<UsersResponseDTO> ShowUser(int Id)
        {
            var user = await _adminRepository.ShowUser(Id);
            var userResponse = new UsersResponseDTO();
            userResponse.Name = user.Name;
            userResponse.UserRole = user.UserRole;
            userResponse.Salary = user.Salary;
            userResponse.Id = user.Id;

            return userResponse;
        }

        public async Task<UsersResponseDTO> UpdateUser(int Id, UsersRequestDTO usersRequestDTO)
        {
            var user = await _adminRepository.ShowUser(Id);


            user.Name = usersRequestDTO.Name;
            user.UserRole = usersRequestDTO.UserRole;
            user.Salary = usersRequestDTO.Salary;

            var data = await _adminRepository.UpdateUser(user);

            var userResponse = new UsersResponseDTO();
            userResponse.Name = data.Name;
            userResponse.UserRole = data.UserRole;
            userResponse.Salary = data.Salary;
            userResponse.Id = data.Id;

            return userResponse;
        }

        public async Task<String> DeleteUser(int Id)
        {
            var user = await _adminRepository.ShowUser(Id);

            var data = await _adminRepository.DeleteUser(user);

            return "Deleted Successfully";

        }

        public async Task<LeavePoliciesResponseDTO> CreateLeavePolicy(LeavePoliciesRequestDTO leavePoliciesRequestDTO)
        {
            var leave = new LeavePolicy();
            leave.LeavePolicyType = leavePoliciesRequestDTO.LeavePolicyType;
            leave.MaxDays = leavePoliciesRequestDTO.MaxDays;

            leave.carryOverLimit = CalculateCarryOverLimit(leave.MaxDays);
            leave.PayCut = CalculatePayCut(leave.MaxDays);
            leave.MaxDays = CalculateMaxDays(leave.MaxDays);

            var data = await _adminRepository.CreateLeavePolicy(leave);

            var respone = new LeavePoliciesResponseDTO();
            respone.carryOverLimit = data.carryOverLimit;
            respone.MaxDays = respone.MaxDays;
            respone.LeavePolicyType = respone.LeavePolicyType;
            respone.PayCut = data.PayCut;
            return respone;

        }

        private int CalculateMaxDays(int maxDays)
        {
            if (maxDays == 1)
            {
                return maxDays;
            }
            else
            {
                throw new ArgumentException("Allow the Max days only one day");
            }
        }


        private int CalculateCarryOverLimit(int maxDays)
        {
            return (int)(maxDays * 0.1);
        }

        private decimal CalculatePayCut(int maxDays)
        {
            return (decimal)(maxDays * 0.1);
        }


        public async Task<LeavePoliciesResponseDTO> GetLeavePolicy(int id)
        {
            var data = await _adminRepository.GetLeavePolicy(id);
            var respone = new LeavePoliciesResponseDTO();
            respone.PayCut = data.PayCut;
            respone.carryOverLimit = data.carryOverLimit;
            respone.MaxDays= data.MaxDays;
            respone.LeavePolicyType= respone.LeavePolicyType;

            return respone;
            
        }

        public async Task<String> DeleteLeavePolicy(int id)
        {
            var get = await _adminRepository.GetLeavePolicy(id);

            var data = await _adminRepository.DeleteLeavePolicy(get);
         
            return "Deleted Successfully";
        }

        public async Task<LeaveRequestResponseDTO> CreateLeaveRequest(LeaveRequestRequestDTO leaveRequestDTO)
        {
            var leave = new LeaveRequest();
            leave.Date = leaveRequestDTO.Date;
            leave.LeavePoliciesID = leaveRequestDTO.LeavePoliciesID;
            leave.UsersId = leaveRequestDTO.UsersId;


            var data = await _adminRepository.CreateLeaveRequest(leave);
            var respone = new LeaveRequestResponseDTO();
            respone.Status = data.Status;
            respone.Date = data.Date;
            respone.LeavePoliciesID= data.LeavePoliciesID;
            respone.UsersId = data.UsersId;

            return respone;
        }

        public async Task<LeaveRequestResponseDTO> GetLeaveRequest(int id)
        {
            var data = await _adminRepository.GetLeaveRequest(id);
            var respone = new LeaveRequestResponseDTO();
            respone.Status = data.Status;
            respone.Date = data.Date;
            respone.LeavePoliciesID = data.LeavePoliciesID;
            respone.UsersId= data.UsersId;
            return respone;
        }

        public async Task<LeaveRequestResponseDTO> ApproveLeaveRequest(int id)
        {
            var get = await _adminRepository.GetLeaveRequest(id);
            get.Status = true;

            var up = await _adminRepository.ApproveLeaveRequest(get);

            var respone = new LeaveRequestResponseDTO();
            respone.Status = get.Status;
            respone.Date = get.Date;
            respone.LeavePoliciesID = get.LeavePoliciesID;
            respone.UsersId = get.UsersId;
            return respone;
        }

  

    }
}
