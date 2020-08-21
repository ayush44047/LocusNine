using System;
using System.Collections.Generic;
using System.Text;

namespace LocusNine_DAL.Models
{
    public partial class UserDetail
    {
        public int? Userid { get; set; }
        public int Roleid { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Rolename { get; set; }

    }
}
