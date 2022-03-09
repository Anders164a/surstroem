﻿using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<ICollection<User>> GetUsersByAddressId(int addresId);
        Task<ICollection<User>> GetUsersWithAllInfo();
        Task<User> GetUserWithAllInfo(int userId);
        Task<User> GetUserByEmail(string userEmail);
        Task PutNewUserPassword(int userId, string passwordHash, string passwordSalt);
        Task PutNewUserAddress(int userId, int address);
        Task PutNewUserInfo(int userId, string firstName, string lastName, string email, int phoneNumber);
    }
}
