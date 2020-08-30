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
    class AddNewLevelOfResponsibilitiViewMOdel:ViewModelBase
    {
        AddNewMenagerLevelOfResponsibility menagerView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public AddNewLevelOfResponsibilitiViewMOdel(AddNewMenagerLevelOfResponsibility menagerViewOpen)
        {
            this.menagerView = menagerViewOpen;
            ListOfMenagers = new ObservableCollection<Menager>(service.GetAllMenagersWithoutLevelOfResponsibility());
            SelectedMenager = ListOfMenagers.FirstOrDefault(m => m.ManagerId == menager.ManagerId);
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

        private Menager menager=new Menager();
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
        #endregion
    }
}
