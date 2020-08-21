using System;
using System.Collections.Generic;

namespace LocusNine_DAL.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public int Roleid { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
