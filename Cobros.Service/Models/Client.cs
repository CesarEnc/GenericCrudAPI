using Cobros.Service.Intefaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Cobros.Service.Models
{
    public partial class Client : IEntity
    {
        public Client()
        {
            ClientMovements = new HashSet<ClientMovement>();
            ClientPhones = new HashSet<ClientPhone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }

        public virtual ICollection<ClientMovement> ClientMovements { get; set; }
        public virtual ICollection<ClientPhone> ClientPhones { get; set; }
    }
}
