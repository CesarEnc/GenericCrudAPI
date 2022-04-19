using System;
using System.Collections.Generic;

#nullable disable

namespace Cobros.Service.Models
{
    public partial class ClientPhone
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string PhoneNumber { get; set; }
        public string Tag { get; set; }

        public virtual Client Client { get; set; }
    }
}
