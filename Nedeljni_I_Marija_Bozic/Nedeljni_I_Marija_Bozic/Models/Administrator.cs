using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.Models
{
    public class Administrator:User
    {
        public int AdministratorId { get; set; }
        public int CompanyUserId { get; set; }
        public int AdministratorTypeId { get; set; }
        public string AdministratorTypeName { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
