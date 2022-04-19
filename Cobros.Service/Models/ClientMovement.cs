using System;
using System.Collections.Generic;

#nullable disable

namespace Cobros.Service.Models
{
    public partial class ClientMovement
    {
        public long Id { get; set; }
        public int ClientId { get; set; }
        public decimal? Amount { get; set; }
        public string AmountType { get; set; }

        public virtual Client Client { get; set; }
    }
}
