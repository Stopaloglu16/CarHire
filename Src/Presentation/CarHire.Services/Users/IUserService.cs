﻿using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;

namespace CarHire.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto> GetUserById(int Id);

        Task<CreateUserResponse> Add(CreateAdminUserRequest createUserRequest); 
    }
}
