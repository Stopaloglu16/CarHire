using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Services.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        

        public async Task<UserDto> GetUserById(int Id)
        {
            var myReturn = await _userRepository.GetByIdAsync(Id);

            if(myReturn == null) return null;

            return new UserDto() {
                FullName = myReturn.FullName,
                //BranchId = myReturn.BranchId,
                UserEmail = myReturn.UserEmail,
                UserName = myReturn.UserName,
                RoleGroupId = myReturn.RoleGroupId,
                UserTypeId = myReturn.UserTypeId
            };

        }

        public Task<IEnumerable<UserDto>> GetUsers()
        {
            throw new NotImplementedException();
        }


        public async Task<CreateUserResponse> AddAdminUser(CreateAdminUserRequest createUserRequest)
        {
            var myReturn = await _userRepository.AddAsync(
             new User()
             {
                 FullName = createUserRequest.FullName,
                 UserEmail = createUserRequest.UserEmail,
                 UserName = createUserRequest.UserName,
                 RoleGroupId = createUserRequest.RoleGroupId,
                 UserTypeId = createUserRequest.UserTypeId
             });

            if (myReturn == null) return new CreateUserResponse(0, new BasicErrorHandler("SystemIssue"));

            return new CreateUserResponse(myReturn.Id, new BasicErrorHandler());
        }

        public async Task<CreateUserResponse> AddBranchUser(CreateBrancUserRequest createUserRequest)
        {
            var myReturn = await _userRepository.AddAsync(
             new User()
             {
                 FullName = createUserRequest.FullName,
                 BranchId = createUserRequest.BranchId,
                 UserEmail = createUserRequest.UserEmail,
                 UserName = createUserRequest.UserName,
                 RoleGroupId = createUserRequest.RoleGroupId,
                 UserTypeId = createUserRequest.UserTypeId
             });

            if (myReturn == null) return new CreateUserResponse(0, new BasicErrorHandler("SystemIssue"));

            return new CreateUserResponse(myReturn.Id, new BasicErrorHandler());
        }

        public async Task<CreateUserResponse> AddCustomerUser(CreateCustomerUserRequest createUserRequest)
        {
            var myReturn = await _userRepository.AddAsync(
             new User()
             {
                 FullName = createUserRequest.FullName,
                 UserEmail = createUserRequest.UserEmail,
                 UserName = createUserRequest.UserName,
                 RoleGroupId = createUserRequest.RoleGroupId,
                 UserTypeId = createUserRequest.UserTypeId
             });

            if (myReturn == null) return new CreateUserResponse(0, new BasicErrorHandler("SystemIssue"));

            return new CreateUserResponse(myReturn.Id, new BasicErrorHandler());
        }
    }
}
