using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<ICollection<User>> GetUsersByAddressId(int addresId);
        Task<ICollection<User>> GetUsersByOrderId(int orderId);
        Task<ICollection<User>> GetUserContactInformation(int userId);
    }
}
