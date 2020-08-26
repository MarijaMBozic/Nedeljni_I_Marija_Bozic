using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Nedeljni_I_Marija_Bozic.Models
{
    public class Menager:User
    {
        public int ManagerId { get; set; }
        public string Email { get; set; }
        public string BackupPassword { get; set; }
        public int LevelOfResponsibility { get; set; }
        public int NumOfSuccessfulProjects { get; set; }
        public double Salary { get; set; }
        public int NumberOfOffice { get; set; }
    }
}
