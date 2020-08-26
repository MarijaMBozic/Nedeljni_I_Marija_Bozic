using Nedeljni_I_Marija_Bozic.Command;
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
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_I_Marija_Bozic.ViewModels
{
    public class AddNewAdminViewModel:ViewModelBase
    {
        AddNewAdmin addNewAdminView;
        ServiceCode service = new ServiceCode();
        #region Constructor
        public AddNewAdminViewModel(AddNewAdmin addNewAdminOpen)
        {
            addNewAdminView = addNewAdminOpen;
            GenderList = new ObservableCollection<Gender>(service.GettAllGender());
            MaritalStatusList = new ObservableCollection<MaritalStatus>(service.GettAllMaritalStatus());
            TypeList = new ObservableCollection<AdministratorType>(service.GettAllAdminType());
        }
        #endregion
        #region Property
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

        private ObservableCollection<AdministratorType> typeList;
        public ObservableCollection<AdministratorType> TypeList
        {
            get
            {
                return typeList;
            }
            set
            {
                typeList = value;
                OnPropertyChanged("TypeList");
            }
        }

        private AdministratorType selectedType;
        public AdministratorType SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {
                selectedType = value;
                OnPropertyChanged("SelectedType");
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

        private Administrator admin = new Administrator();
        public Administrator Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }
        #endregion
        #region Commands    

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(param));
                }
                return save;
            }
        }
        public void SaveExecute(object parametar)
        {
            try
            {
                if (User.UserId == 0)
                {
                    var passwordBox = parametar as PasswordBox;
                    var password = passwordBox.Password;
                    User.Password = password;
                    User.GenderId = selectedGender.GenderId;
                    User.MaritalStatusId = selectedMaritalStatus.MaritalStatusId;
                    User.RoleId = 2;

                    MessageBoxResult result=MessageBox.Show("Are you sure you want to save the new Administrator", "Add New Admin", MessageBoxButton.YesNo);
                    if(result == MessageBoxResult.Yes)
                    {
                        int userId = service.AddCompanyUser(User);
                        if (userId != 0)
                        {
                            Admin.CompanyUserId = userId;
                            Admin.AdministratorTypeId = selectedType.AdministratorTypeId;
                            Admin.ExpirationDate = DateTime.Now.AddDays(7);

                            if (service.AddAdminUser(Admin) != 0)
                            {
                                MessageBox.Show("You have successfully added new administrator");
                                Logging.LoggAction("AddNewAdmnViewModel", "Info", "Succesfull add new Admin");
                                MasterAdminView masterView = new MasterAdminView();
                                masterView.Show();
                                addNewAdminView.Close();
                            }
                        }
                    }
                    else
                    {
                        MasterAdminView masterView = new MasterAdminView();
                        masterView.Show();
                        addNewAdminView.Close();
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
