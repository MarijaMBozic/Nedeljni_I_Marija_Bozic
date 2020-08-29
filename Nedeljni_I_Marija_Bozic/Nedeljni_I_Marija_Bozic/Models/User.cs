using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Jmbg { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string Address { get; set; }
        public int MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
