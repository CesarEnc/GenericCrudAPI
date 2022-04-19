using System;
using System.Collections.Generic;

#nullable disable

namespace Cobros.Service.Models
{
    public partial class Role
    {
        public Role()
        {
            SystemUsers = new HashSet<SystemUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
