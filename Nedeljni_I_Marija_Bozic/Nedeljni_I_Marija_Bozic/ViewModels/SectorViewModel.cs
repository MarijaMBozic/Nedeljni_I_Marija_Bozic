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
    public class SectorViewModel:ViewModelBase
    {
        SectorView sectorView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public SectorViewModel(SectorView sectorViewOpen)
        {
            this.sectorView = sectorViewOpen;
            ListOfSectors = new ObservableCollection<Sector>(service.GettAllSectors(out defaultSector));
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
        private ObservableCollection<Sector> listOfSectors;
        public ObservableCollection<Sector> ListOfSectors
        {
            get
            {
                return listOfSectors;
            }
            set
            {
                listOfSectors = value;
                OnPropertyChanged("ListOfSectors");
            }
        }

        private Sector selectedSector;
        public Sector SelectedSector
        {
            get
            {
                return selectedSector;
            }
            set
            {
                selectedSector = value;
                OnPropertyChanged("SelectedSector");
            }
        }
        #endregion
    }
}
