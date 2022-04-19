using System;
using System.Collections.Generic;

#nullable disable

namespace Cobros.Service.Models
{
    public partial class SystemUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
