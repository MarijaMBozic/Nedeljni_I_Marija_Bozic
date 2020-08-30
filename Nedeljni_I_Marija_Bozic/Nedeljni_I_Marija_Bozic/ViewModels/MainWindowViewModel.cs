using Nedeljni_I_Marija_Bozic.Command;
using Nedeljni_I_Marija_Bozic.Helpers;
using Nedeljni_I_Marija_Bozic.Models;
using Nedeljni_I_Marija_Bozic.Service;
using Nedeljni_I_Marija_Bozic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_I_Marija_Bozic.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        MainWindow main;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public MainWindowViewModel(MainWindow mainOpen)
        {
           this.main = mainOpen;
           RandomString.RandomStringManager();
        }
        #endregion
        #region Properties
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        #endregion

        #region Command
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(param));
                }
                return login;
            }
        }

        private void LoginExecute(object parametar)
        {
            var passwordBox = parametar as PasswordBox;
            var password = passwordBox.Password;
            try
            {
                if (service.LoginMaster(username, password) !=null)
                {

                    MessageBox.Show("Successful login");
                    MasterAdminView window = new MasterAdminView();
                    window.Show();
                    main.Close();
                }
                else if(service.LoginUserPass(username, password) != null)
                {
                    if(ServiceCode.CurrentUser.RoleId==1)
                    {
                        Menager menager = service.GetMenagerByUserId(ServiceCode.CurrentUser.UserId);
                        if(menager.LevelOfResponsibility==4)
                        {
                            MessageBox.Show("Your account is not yet available.\nWait for the admin to assign you \na level of responsibility ");
                        }
                        else
                        {
                            ManagerView managerView = new ManagerView(menager);
                            managerView.Show();
                            main.Close();
                        }                       
                    }
                    else if(ServiceCode.CurrentUser.RoleId == 2)
                    {
                        Administrator admin = service.GetAdminByUserId(ServiceCode.CurrentUser.UserId);
                        if (admin.ExpirationDate<DateTime.Now)
                        {
                            MessageBox.Show("You need to contact company's menagment\nTo extend your access to acount!");
                        }
                        else
                        {
                            AdminView adminView = new AdminView();
                            adminView.Show();
                            main.Close();
                        }
                    }
                    else if(ServiceCode.CurrentUser.RoleId == 3)
                    {
                        WorkerView workerView = new WorkerView();
                        workerView.Show();
                        main.Close();
                    }
                }
                else if(service.LoginManagerBackUpPass(username, password) != null)
                {
                    Menager menager = service.GetMenagerByUserId(ServiceCode.CurrentUser.UserId);
                    if (menager.LevelOfResponsibility == 4)
                    {
                        MessageBox.Show("Your account is not yet available.\nWait for the admin to assign you \na level of responsibility ");
                    }
                    else
                    {
                        ManagerView managerView = new ManagerView(menager);
                        managerView.Show();
                        main.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong credentials");
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
