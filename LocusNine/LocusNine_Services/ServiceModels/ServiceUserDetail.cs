using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocusNine_Services.Models
{
    public class ServiceUserDetail
    {
        public int? Userid { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Rolename { get; set; }
        public int Roleid { get; set; }
    }
}
