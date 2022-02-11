using API.Service.Interfaces;
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
    }
}
