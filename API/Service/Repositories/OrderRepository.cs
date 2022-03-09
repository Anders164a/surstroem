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
    public class OrderRepository : GenericRepository<Order, surstroemContext>, IOrderRepository
    {
        public OrderRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }

        public async Task<ICollection<Order>> GetOrdersWithAllInfo()
        {
            return await _dbcontext.Set<Order>()
                .Include(o => o.ShipAddress)
                .Include(o => o.ShipAddress.PostalCode)
                .Include(o => o.ShipAddress.PostalCode.Country)
                .Include(o => o.PayAddress)
                .Include(o => o.PayAddress.PostalCode)
                .Include(o => o.PayAddress.PostalCode.Country)
                .Include(o => o.User)
                .Include(o => o.User.Address)
                .Include(o => o.User.Address.PostalCode)
                .Include(o => o.User.Address.PostalCode.Country)
                .Include(o => o.DeliveryState)
                .Include(o => o.DeliveryType)
                .ToListAsync();
        }
    }
}
