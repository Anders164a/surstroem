﻿using API.Dtos;
using API.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using surstroem.Data;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Repositories
{
    public class UserRepository : GenericRepository<User, surstroemContext>, IUserRepository
    {
        public UserRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }

        public async Task<ICollection<User>> GetUsersByAddressId(int addressId)
        {
            return await _dbcontext.Users.Where(c => c.AddressId == addressId)
                               .Include(c => c.Id)
                               .Include(c => c.Firstname)
                               .Include(c => c.Lastname)
                               .Include(c => c.Address)
                .ToListAsync();
        }

        public async Task<ICollection<User>> GetUsersByOrderId(int addressId)
        {
            return await _dbcontext.Users.Where(c => c.AddressId == addressId)
                               .Include(c => c.Id)
                               .Include(c => c.Firstname)
                               .Include(c => c.Lastname)
                               .Include(c => c.Address)
                .ToListAsync();
        }

        public async Task<User> GetUserContactInformation(int userId)
        {
            return await _dbcontext.Users.Where(c => c.Id == userId)
                                .Include(c => c.Address)
                                .ThenInclude(s => s.PostalCode)
                                .ThenInclude(d => d.Country)
                                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }

        public async Task PutNewUserPassword(int userId, string passwordHash, string passwordSalt)
        {
            var user = new User() { Id = userId, PasswordHash = passwordHash, PasswordSalt = passwordSalt};
            _dbcontext.Users.Attach(user);
            _dbcontext.Entry(user).Property(x => x.PasswordHash).IsModified = true;
            _dbcontext.Entry(user).Property(x => x.PasswordSalt).IsModified = true;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task PutNewUserAddress(int userId, int address)
        {
            var user = new User() { Id = userId, AddressId = address};
            _dbcontext.Users.Attach(user);
            _dbcontext.Entry(user).Property(x => x.AddressId).IsModified = true;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task PutNewUserInfo(int userId, string firstName, string lastName, string email, int phoneNumber)
        {
            var user = new User() { Id = userId, Firstname = firstName, Lastname = lastName, Email = email, PhoneNumber = phoneNumber };
            _dbcontext.Users.Attach(user);
            _dbcontext.Entry(user).Property(x => x.Firstname).IsModified = true;
            _dbcontext.Entry(user).Property(x => x.Lastname).IsModified = true;
            _dbcontext.Entry(user).Property(x => x.Email).IsModified = true;
            _dbcontext.Entry(user).Property(x => x.PhoneNumber).IsModified = true;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await _dbcontext.Users.Where(c => c.Email == userEmail)
                                .Include(c => c.Address)
                                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }
    }
}