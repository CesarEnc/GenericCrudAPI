using Cobros.Service.Intefaces;
using Cobros.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobros.Service.Implementations
{
    public class ClientsRepository: GenericRepository<Client>,IClientsRepository
    {
        public ClientsRepository(CobrosDBContext _context): base(_context){}


    }
}
