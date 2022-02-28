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
    public class OrderProductRepository : GenericRepository<OrderProduct, surstroemContext>, IOrderProductRepository
    {
        public OrderProductRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }

        public async Task<OrderProduct> GetOrderProductWithName(int orderId)
        {
            return await _dbcontext.OrderProducts.Where(c => c.Id == orderId).FirstOrDefaultAsync();
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
    }
}
