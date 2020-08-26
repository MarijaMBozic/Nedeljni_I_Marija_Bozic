using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.Models
{
    public class Worker:User
    {
        public int WorkerId { get; set; }
        public int ManagerId { get; set; }
        public int SectorId { get; set; }
        public int PositionId { get; set; }
        public int YearsOfService { get; set; }
        public double Salary { get; set; }
        public int QualificationsId { get; set; }
    }
}
