using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int Userid { get; set; }
        public int SalaryMonth { get; set; }
        public int SalaryYear { get; set; }
        public double SalaryForMonth { get; set; }
    }
}
