using Nedeljni_I_Marija_Bozic.Models;
using Nedeljni_I_Marija_Bozic.Service;
using Nedeljni_I_Marija_Bozic.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.ViewModels
{
    public class WorkerListViewModel:ViewModelBase
    {
        WorkerList workerView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public WorkerListViewModel(WorkerList workerViewOpen)
        {
            this.workerView = workerViewOpen;
            ListOfWorkers = new ObservableCollection<Worker>(service.GetAllWorkers());
        }
        #endregion
        #region Property

        private ObservableCollection<Worker> listOfWorkers;
        public ObservableCollection<Worker> ListOfWorkers
        {
            get
            {
                return listOfWorkers;
            }
            set
            {
                listOfWorkers = value;
                OnPropertyChanged("ListOfWorkers");
            }
        }

        private Worker selectedWorker;
        public Worker SelectedWorker
        {
            get
            {
                return selectedWorker;
            }
            set
            {
                selectedWorker = value;
                OnPropertyChanged("SelectedWorker");
            }
        }
        #endregion
    }
}
