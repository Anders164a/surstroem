using API.Dtos;
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

        public async Task<ICollection<User>> GetUserContactInformation(int userId)
        {
            return await _dbcontext.Users.Where(c => c.AddressId == userId)
                                .Include(c => c.Address)
                                .ThenInclude(s => s.PostalCode)
                                .ThenInclude(d => d.Country)
                                .AsSplitQuery()
                                /*.Include(c => c.Id)
                                .Include(c => c.Firstname)
                                .Include(c => c.Lastname)
                                .Include(c => c.Email)
                                .Include(c => c.PhoneNumber)
                                .Include(c => c.Address)
                                .ThenInclude(s => s.Floor)
                                .Include(e => e.)
                                .AsSplitQuery()*/
                .ToListAsync();
        }
    }
}
