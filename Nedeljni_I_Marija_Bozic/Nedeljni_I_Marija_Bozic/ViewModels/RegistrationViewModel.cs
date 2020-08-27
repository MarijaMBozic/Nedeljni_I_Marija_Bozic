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
    public class RegistrationViewModel: ViewModelBase
    {
        Registration registrationView;
        ServiceCode service = new ServiceCode();
        #region Constructor
        public RegistrationViewModel(Registration registrationViewOpen)
        {
            registrationView = registrationViewOpen;
            GenderList = new ObservableCollection<Gender>(service.GettAllGender());
            MaritalStatusList = new ObservableCollection<MaritalStatus>(service.GettAllMaritalStatus());
            SectorList = new ObservableCollection<Sector>(service.GettAllSectors());
            PositionList = new ObservableCollection<Position>(service.GettAllPositions());
            QualificationList = new ObservableCollection<Qualifications>(service.GettAllQualificationLevels());
        }
        #endregion
        #region Property
        
        private bool workerRegistry;
        public bool WorkerRegistry
        {
            get
            {
                return workerRegistry;
            }
            set
            {
                workerRegistry = value;
                OnPropertyChanged("WorkerRegistry");
            }
        }

        private bool managerRegistry;
        public bool ManagerRegistry
        {
            get
            {
                return managerRegistry;
            }
            set
            {
                managerRegistry = value;
                OnPropertyChanged("ManagerRegistry");
            }
        }

        private ObservableCollection<Gender> genderList;
        public ObservableCollection<Gender> GenderList
        {
            get
            {
                return genderList;
            }
            set
            {
                genderList = value;
                OnPropertyChanged("GenderList");
            }
        }

        private Gender selectedGender;
        public Gender SelectedGender
        {
            get
            {
                return selectedGender;
            }
            set
            {
                selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }

        private ObservableCollection<MaritalStatus> maritalStatusList;
        public ObservableCollection<MaritalStatus> MaritalStatusList
        {
            get
            {
                return maritalStatusList;
            }
            set
            {
                maritalStatusList = value;
                OnPropertyChanged("MaritalStatusList");
            }
        }

        private MaritalStatus selectedMaritalStatus;
        public MaritalStatus SelectedMaritalStatus
        {
            get
            {
                return selectedMaritalStatus;
            }
            set
            {
                selectedMaritalStatus = value;
                OnPropertyChanged("SelectedMaritalStatus");
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

        private ObservableCollection<Position> positionList;
        public ObservableCollection<Position> PositionList
        {
            get
            {
                return positionList;
            }
            set
            {
                positionList = value;
                OnPropertyChanged("PositionList");
            }
        }

        private Position selectedPosition;
        public Position SelectedPosition
        {
            get
            {
                return selectedPosition;
            }
            set
            {
                selectedPosition = value;
                OnPropertyChanged("SelectedPosition");
            }
        }

        private ObservableCollection<Qualifications> qualificationList;
        public ObservableCollection<Qualifications> QualificationList
        {
            get
            {
                return qualificationList;
            }
            set
            {
                qualificationList = value;
                OnPropertyChanged("QualificationList");
            }
        }

        private Qualifications selectedQualification;
        public Qualifications SelectedQualification
        {
            get
            {
                return selectedQualification;
            }
            set
            {
                selectedQualification = value;
                OnPropertyChanged("SelectedQualification");
            }
        }

        private User user = new User();
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private Worker worker = new Worker();
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
