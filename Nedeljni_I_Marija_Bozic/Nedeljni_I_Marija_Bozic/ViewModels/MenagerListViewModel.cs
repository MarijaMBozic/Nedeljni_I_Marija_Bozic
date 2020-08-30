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
    public class MenagerListViewModel:ViewModelBase
    {
        MenagerListView menagerView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public MenagerListViewModel(MenagerListView menagerViewOpen)
        {
            this.menagerView = menagerViewOpen;
            ListOfMenagers = new ObservableCollection<Menager>(service.GetAllMenagersList());
        }
        #endregion
        #region Property

        private ObservableCollection<Menager> listOfMenagers;
        public ObservableCollection<Menager> ListOfMenagers
        {
            get
            {
                return listOfMenagers;
            }
            set
            {
                listOfMenagers = value;
                OnPropertyChanged("ListOfMenagers");
            }
        }

        private Menager selectedMenager;
        public Menager SelectedMenager
        {
            get
            {
                return selectedMenager;
            }
            set
            {
                selectedMenager = value;
                OnPropertyChanged("SelectedMenager");
            }
        }
        #endregion
    }
}
