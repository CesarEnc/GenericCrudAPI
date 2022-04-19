using Cobros.Service.Intefaces;
using Cobros.Service.Models;
using Microsoft.AspNetCore.Mvc;
namespace Cobros.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : GenericController<Client>
    {
        public ClientController(IClientsRepository clients): base(clients){}
    }
}
