using API.Service.Interfaces;
using API.Service.Repositories;
using surstroem.Data;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Repositories
{
    public class AddressRepository : GenericRepository<Address, surstroemContext>, IAddressRepository
    {
        public AddressRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}
