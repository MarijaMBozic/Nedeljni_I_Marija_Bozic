using Nedeljni_I_Marija_Bozic.Helpers;
using Nedeljni_I_Marija_Bozic.Models;
using Nedeljni_I_Marija_Bozic.Service;
using Nedeljni_I_Marija_Bozic.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nedeljni_I_Marija_Bozic.ViewModels
{
    public class SelectLevelViewModel:ViewModelBase
    {
        SelectLevelView selectLevelView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public SelectLevelViewModel(Menager menager, SelectLevelView selectLevelViewOpen)
        {
            this.selectLevelView = selectLevelViewOpen;
            this.menager = menager;
            selectLevelView = selectLevelViewOpen;
            LevelOfResponsibilityList= new ObservableCollection<LevelOfResponsibility>(service.GettAllLevelsOfResponsibility());
        }
        #endregion
        #region Property

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

        private ObservableCollection<LevelOfResponsibility> levelOfResponsibilityList;
        public ObservableCollection<LevelOfResponsibility> LevelOfResponsibilityList
        {
            get
            {
                return levelOfResponsibilityList;
            }
            set
            {
                levelOfResponsibilityList = value;
                OnPropertyChanged("LevelOfResponsibilityList");
            }
        }

        private LevelOfResponsibility selectedLevelOfResponsibility;
        public LevelOfResponsibility SelectedLevelOfResponsibility
        {
            get
            {
                return selectedLevelOfResponsibility;
            }
            set
            {
                selectedLevelOfResponsibility = value;
                OnPropertyChanged("SelectedLevelOfResponsibility");
            }
        }
        #endregion       

        #region Commands
        public void UpdateMenager()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to add this level to this menager", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Menager.LevelOfResponsibility = selectedLevelOfResponsibility.LevelOfResponsibilityId;
                    bool succesfulUpdate = service.UpdateMenager(Menager);
                    if (succesfulUpdate)
                    {
                        MessageBox.Show("You have successfully added level of responsibility");
                        Logging.LoggAction("UpdateLevelOfresponsibilitiViewModel", "Info", "Succesfull added level of responsibility");
                        selectLevelView.Close();
                    }
                }
                else
                {
                    selectLevelView.Close();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
