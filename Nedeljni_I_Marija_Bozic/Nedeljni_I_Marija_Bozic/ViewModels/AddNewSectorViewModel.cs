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
    public class AddNewSectorViewModel:ViewModelBase
    {
        AddNewSector addNewSector;
        ServiceCode service = new ServiceCode();
        #region Constructor
        public AddNewSectorViewModel(AddNewSector addNewSectorOpen)
        {
            addNewSector = addNewSectorOpen;
            SectorList = new ObservableCollection<Sector>(service.GettAllSectors(out defaultSector));
        }
        #endregion
        #region Property
        private Sector defaultSector;
        public Sector DefaultSector
        {
            get
            {
                return defaultSector;
            }
            set
            {
                defaultSector = value;
                OnPropertyChanged("DefaultSector");
            }
        }
        private Sector sector = new Sector();
        public Sector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }
        private ObservableCollection<Sector> sectorList;
        public ObservableCollection<Sector> SectorList
        {
            get
            {
                return sectorList;
            }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }
        #endregion
        #region Commands
        public void SaveSector()
        {
            try
            {
                if(SectorList.Count==15)
                {
                    MessageBox.Show("Maximum number of sectors is reached!\nPlease delete some of the existing \nsector if you want to add a new one!");
                    addNewSector.Close();
                }
                else
                {
                    if (Sector.SectorId == 0)
                    {
                        if (Sector.Description == null)
                        {
                            Sector.Description = "";
                        }
                        bool uniqueSectorName = service.CheckSectorName(Sector.Name);
                        if (!uniqueSectorName)
                        {
                            MessageBoxResult result = MessageBox.Show("Are you sure you want to add the new sector", "Add New Sector", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                int sectorId = service.AddSector(Sector);
                                if (sectorId != 0)
                                {
                                    MessageBox.Show("You have successfully added new sector");
                                    Logging.LoggAction("AddNewSectorViewModel", "Info", "Succesfull add new sector");
                                    addNewSector.Close();
                                }
                            }
                            else
                            {
                                addNewSector.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Name is not unique!");
                        }
                    }
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
