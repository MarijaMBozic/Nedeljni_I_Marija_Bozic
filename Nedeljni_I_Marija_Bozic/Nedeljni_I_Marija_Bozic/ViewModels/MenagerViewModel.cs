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
    public class MenagerViewModel:ViewModelBase
    {
        ManagerView menagerView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public MenagerViewModel(Menager menager, ManagerView menagerViewOpen)
        {
            this.menagerView = menagerViewOpen;
            this.menager = menager;
            ListOfWorkers = new ObservableCollection<Worker>(service.GetAllWorkerByMenagerId(menager.ManagerId));           
        }
        #endregion

        #region Properties
        private Menager menager;
        public Menager Menager
        {
            get
            {
                return menager;
            }
            set
            {
                menager = value;
                OnPropertyChanged("Menager");
            }
        }

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
                if(value.Count>0)
                {
                    Info = true;
                }
                else
                {
                    Info = false;
                }
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

        private bool info;
        public bool Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;              
                OnPropertyChanged("Info");
            }
        }

        #endregion
    }
}
