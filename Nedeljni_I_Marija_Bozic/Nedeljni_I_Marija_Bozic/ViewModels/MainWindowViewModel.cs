using Nedeljni_I_Marija_Bozic.Command;
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
