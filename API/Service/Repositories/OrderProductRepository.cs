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

        public async Task<ICollection<OrderProduct>> GetOrderProductsByOrderId(int orderId)
        {
            return await _dbcontext.OrderProducts.Where(c => c.OrderId == orderId)
                .ToListAsync();
        }
    }
}
