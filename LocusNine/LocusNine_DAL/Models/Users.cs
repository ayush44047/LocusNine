using System;
using System.Collections.Generic;

namespace LocusNine_DAL.Models
{
    public partial class Users
    {
        public int Userid { get; set; }
        public int Roleid { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public virtual Roles Role { get; set; }
    }
}
