using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfConclusionOfContract { get; set; }
        public int ManagerWhoSignedContractId { get; set; }
        public DateTime StartDateProject { get; set; }
        public DateTime EndDateProject { get; set; }
        public int HourlyRate { get; set; }
        public int RealizationId { get; set; }
        public int ManagerId { get; set; }
        public List<Worker> ListOfWorkersOnProject { get; set; }
    }
}
