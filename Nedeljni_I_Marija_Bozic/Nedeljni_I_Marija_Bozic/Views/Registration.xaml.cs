using Nedeljni_I_Marija_Bozic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nedeljni_I_Marija_Bozic.Views
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private bool isValidFirstName;
        private bool isValidlastName;
        private bool isValidGender;
        private bool isValidAddress;
        private bool isValidUsername;
        private bool isValidPassword;
        private bool isValidMaritalStatus;
        private bool isValidJMBG;
        public Registration()
        {
            InitializeComponent();
            this.DataContext = new RegistrationViewModel(this);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void IsRegistrationUserEnabled()
        {
            if (isValidFirstName &&
                isValidlastName &&
                isValidJMBG &&
                isValidGender &&
                isValidAddress &&
                isValidMaritalStatus &&
                isValidUsername &&
                isValidPassword )
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFirstName.Focus())
            {
                lblValidationFirstName.Visibility = Visibility.Visible;
                lblValidationFirstName.FontSize = 16;
                lblValidationFirstName.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationFirstName.Content = "The first name must contain \nat least 2 caracters!";
            }

            string patternFullName = @"^([a-zA-Z ]{2,100})$";
            Match match = Regex.Match(txtFirstName.Text, patternFullName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtFirstName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtFirstName.Foreground = new SolidColorBrush(Colors.Red);
                isValidFirstName = false;
            }
            else
            {
                lblValidationFirstName.Visibility = Visibility.Hidden;
                txtFirstName.BorderBrush = new SolidColorBrush(Colors.Black);
                txtFirstName.Foreground = new SolidColorBrush(Colors.Black);
                isValidFirstName = true;
            }
            IsRegistrationUserEnabled();
        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLastName.Focus())
            {
                lblValidationLastname.Visibility = Visibility.Visible;
                lblValidationLastname.FontSize = 16;
                lblValidationLastname.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationLastname.Content = "The last name must contain \nat least 2 caracters!";
            }

            string patternFullName = @"^([a-zA-Z ]{2,100})$";
            Match match = Regex.Match(txtLastName.Text, patternFullName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtLastName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtLastName.Foreground = new SolidColorBrush(Colors.Red);
                isValidlastName = false;
            }
            else
            {
                lblValidationLastname.Visibility = Visibility.Hidden;
                txtLastName.BorderBrush = new SolidColorBrush(Colors.Black);
                txtLastName.Foreground = new SolidColorBrush(Colors.Black);
                isValidlastName = true;
            }
            IsRegistrationUserEnabled();

        }

        private void txtJMBG_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtJMBG.Focus())
            {
                lblValidationJMBG.Visibility = Visibility.Visible;
                lblValidationJMBG.FontSize = 16;
                lblValidationJMBG.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationJMBG.Content = "The JMBG must contain \n13 caracters!";
            }
            string patternJMBG = @"^([0-9]{12})$";
            Match match = Regex.Match(txtJMBG.Text, patternJMBG, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                txtJMBG.BorderBrush = new SolidColorBrush(Colors.Red);
                txtJMBG.Foreground = new SolidColorBrush(Colors.Red);
                isValidJMBG = false;
            }
            else
            {
                lblValidationJMBG.Visibility = Visibility.Hidden;
                txtJMBG.BorderBrush = new SolidColorBrush(Colors.Black);
                txtJMBG.Foreground = new SolidColorBrush(Colors.Black);
                isValidJMBG = true;
            }
            IsRegistrationUserEnabled();
        }

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbGender.Focus())
            {
                lblValidationGender.Visibility = Visibility.Visible;
                lblValidationGender.FontSize = 16;
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationGender.Content = "You have to select gender!";
            }

            if (cmbGender.SelectedItem == null)
            {
                lblValidationGender.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Red);
                isValidGender = false;
            }
            else
            {
                lblValidationGender.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Black);
                isValidGender = true;
            }
            IsRegistrationUserEnabled();
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAddress.Focus())
            {
                lblValidationAddress.Visibility = Visibility.Visible;
                lblValidationAddress.FontSize = 16;
                lblValidationAddress.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationAddress.Content = "The must insert \nAddress!";
            }

            string patterntxtAddress = @"^([a-zA-Z0-9._ -]{2,100})$";
            Match match = Regex.Match(txtAddress.Text, patterntxtAddress, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtAddress.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAddress.Foreground = new SolidColorBrush(Colors.Red);
                isValidAddress = false;
            }
            else
            {
                lblValidationAddress.Visibility = Visibility.Hidden;
                txtAddress.BorderBrush = new SolidColorBrush(Colors.Black);
                txtAddress.Foreground = new SolidColorBrush(Colors.Black);
                isValidAddress = true;
            }
            IsRegistrationUserEnabled();
        }

        private void cmbMaritalStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMaritalStatus.Focus())
            {
                lblValidationMaritalStatus.Visibility = Visibility.Visible;
                lblValidationMaritalStatus.FontSize = 16;
                lblValidationMaritalStatus.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationMaritalStatus.Content = "You have to select STATUS!";
            }

            if (cmbMaritalStatus.SelectedItem == null)
            {
                lblValidationMaritalStatus.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationMaritalStatus.Foreground = new SolidColorBrush(Colors.Red);
                isValidMaritalStatus = false;
            }
            else
            {
                lblValidationMaritalStatus.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationMaritalStatus.Foreground = new SolidColorBrush(Colors.Black);
                isValidMaritalStatus = true;
            }
            IsRegistrationUserEnabled();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUsername.Focus())
            {
                lblValidationUsername.Visibility = Visibility.Visible;
                lblValidationUsername.FontSize = 16;
                lblValidationUsername.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationUsername.Content = "The username contains \nat least 5 characters!";
            }

            string patternUserName = @"^([a-zA-Z0-9]{5,100})$";
            Match match = Regex.Match(txtUsername.Text, patternUserName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                txtUsername.Foreground = new SolidColorBrush(Colors.Red);
                isValidUsername = false;
            }
            else
            {
                lblValidationUsername.Visibility = Visibility.Hidden;
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Black);
                txtUsername.Foreground = new SolidColorBrush(Colors.Black);
                isValidUsername = true;
            }
            IsRegistrationUserEnabled();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Focus())
            {
                lblValidationPassword.Visibility = Visibility.Visible;
                lblValidationPassword.FontSize = 16;
                lblValidationPassword.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationPassword.Content = "The password must contains at least:\nMinimum length 6 characters!";
            }

            string patternPassword = @"^[A-Za-z0-9\d@$!%*#?&]{6,}$";
            Match match = Regex.Match(txtPassword.Password, patternPassword, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPassword.Foreground = new SolidColorBrush(Colors.Red);
                isValidPassword = false;
            }
            else
            {
                lblValidationPassword.Visibility = Visibility.Hidden;
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Black);
                txtPassword.Foreground = new SolidColorBrush(Colors.Black);
                isValidPassword = true;
            }
            IsRegistrationUserEnabled();
        }      
    }
}
