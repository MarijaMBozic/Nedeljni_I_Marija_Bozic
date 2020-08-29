using Nedeljni_I_Marija_Bozic.Models;
using Nedeljni_I_Marija_Bozic.Service;
using Nedeljni_I_Marija_Bozic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.ViewModels
{
    public class WorkerViewModel:ViewModelBase
    {
        WorkerView workerView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public WorkerViewModel(WorkerView workerViewOpen)
        {
            this.workerView = workerViewOpen;
            Worker = service.GetWorkerByUserId(ServiceCode.CurrentUser.UserId);
        }
        #endregion

        #region Properties
        private Worker worker;
        public Worker Worker
        {
            get
            {
                return worker;
            }
            set
            {
                worker = value;
                OnPropertyChanged("Worker");
            }
        }
        #endregion
    }
}
