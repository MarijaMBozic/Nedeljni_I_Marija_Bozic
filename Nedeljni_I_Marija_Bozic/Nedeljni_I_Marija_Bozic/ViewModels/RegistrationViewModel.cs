using Nedeljni_I_Marija_Bozic.Helpers;
using Nedeljni_I_Marija_Bozic.Models;
using Nedeljni_I_Marija_Bozic.Service;
using Nedeljni_I_Marija_Bozic.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Nedeljni_I_Marija_Bozic.ViewModels
{
    public class RegistrationViewModel: ViewModelBase
    {
        Registration registrationView;
        ServiceCode service = new ServiceCode();
        public int count =3;
        
        #region Constructor
        public RegistrationViewModel(Registration registrationViewOpen)
        {
            registrationView = registrationViewOpen;
            GenderList = new ObservableCollection<Gender>(service.GettAllGender());
            MaritalStatusList = new ObservableCollection<MaritalStatus>(service.GettAllMaritalStatus());
            SectorList = new ObservableCollection<Sector>(service.GettAllSectors());
            PositionList = new ObservableCollection<Position>(service.GettAllPositions());
            QualificationList = new ObservableCollection<Qualifications>(service.GettAllQualificationLevels());
            LevelOfResponsibilityList = new ObservableCollection<LevelOfResponsibility>(service.GettAllLevelsOfResponsibility());
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

        private bool workerBtn;
        public bool WorkerBtn
        {
            get
            {
                return workerBtn;
            }
            set
            {
                workerBtn = value;
                OnPropertyChanged("WorkerBtn");
            }
        }

        private bool menagerBtn;
        public bool MenagerBtn
        {
            get
            {
                return menagerBtn;
            }
            set
            {
                menagerBtn = value;
                OnPropertyChanged("MenagerBtn");
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
        public bool CheckAccessCode(string inputText)
        {
            try
            {
                if(count>0)
                {
                    count--;
                    if (ValidateRandomAccessCode.IsVaslidAccesCode(inputText))
                    {
                        MessageBox.Show("The code is valid.You can continue with the registration of the manager's account");
                        ManagerRegistry = true;
                        return true;
                    }
                    else
                    { 
                        if(count>0)
                        {
                            MessageBox.Show(string.Format("The code is not valid.You can try {0} more times", count));
                        }                        
                    }                 
                }                    
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion
    }
}
