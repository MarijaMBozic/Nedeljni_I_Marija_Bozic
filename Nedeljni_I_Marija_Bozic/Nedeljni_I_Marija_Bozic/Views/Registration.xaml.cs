﻿using Nedeljni_I_Marija_Bozic.ViewModels;
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
        private bool isValidSector;
        private bool isValidYearsOfService;
        private bool isValidQualification;
        private bool isValidEmail;
        private bool isValidBackupPassword;
        private bool isValidNumberOfOfice;

        RegistrationViewModel register;
        public Registration()
        {            
            register = new RegistrationViewModel(this);
            this.DataContext = register;
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private bool IsRegistrationUserWorkerEnabled()
        {
            if (isValidFirstName &&
                isValidlastName &&
                isValidJMBG &&
                isValidGender &&
                isValidAddress &&
                isValidMaritalStatus &&
                isValidUsername &&
                isValidPassword &&
                isValidSector &&
                isValidYearsOfService &&
                isValidQualification)
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        private bool IsRegistrationUserMenagerEnabled()
        {
            if (isValidFirstName &&
                isValidlastName &&
                isValidJMBG &&
                isValidGender &&
                isValidAddress &&
                isValidMaritalStatus &&
                isValidUsername &&
                isValidPassword &&
                isValidEmail &&
                isValidBackupPassword &&
                isValidNumberOfOfice)
            {
                return true;
            }
            else
            {
                return false;
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
            IsRegistrationUserWorkerEnabled();
            IsRegistrationUserMenagerEnabled();
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
            IsRegistrationUserWorkerEnabled();
            IsRegistrationUserMenagerEnabled();

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
            IsRegistrationUserWorkerEnabled();
            IsRegistrationUserMenagerEnabled();
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
            IsRegistrationUserWorkerEnabled();
            IsRegistrationUserMenagerEnabled();
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
            IsRegistrationUserWorkerEnabled();
            IsRegistrationUserMenagerEnabled();
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
            IsRegistrationUserWorkerEnabled();
            IsRegistrationUserMenagerEnabled();
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
            IsRegistrationUserWorkerEnabled();
            IsRegistrationUserMenagerEnabled();
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
            IsRegistrationUserWorkerEnabled();
            IsRegistrationUserMenagerEnabled();
        }

        private void btnMenager_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to registrate as menager", "Registration", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                CheckRandomAccessCodeView view = new CheckRandomAccessCodeView(register);
                register.User.RoleId = 1;
                view.Show();
            }
        }

        private void btnWorker_Click(object sender, RoutedEventArgs e)
        {
            if(register.SectorList.Count==0 || register.ManagerList.Count == 0)
            {
                MessageBox.Show("Registration for workers is currently not possible");
                register.WorkerBtn = true;
            }
            else
            {
                register.User.RoleId = 3;
                register.WorkerRegistry = true;
                register.MenagerBtn = true;
                register.WorkerBtn = true;
            }
        }

        private void btnSavemenager_Click(object sender, RoutedEventArgs e)
        {
            if (IsRegistrationUserMenagerEnabled())
            {
                register.SaveUserExecute(txtPassword.Password, txtBackupPassword.Password);
            }
            else
            {
                MessageBox.Show("You have not filled in all required fields");
            }
        }

        private void btnSaveWorker_Click(object sender, RoutedEventArgs e)
        {
            if (IsRegistrationUserWorkerEnabled())
            {
                register.SaveUserExecute(txtPassword.Password, "");
            }
            else
            {
                MessageBox.Show("You have not filled in all required fields");
            }            
        }

        private void cmbSector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSector.Focus())
            {
                lblValidationSector.Visibility = Visibility.Visible;
                lblValidationSector.FontSize = 16;
                lblValidationSector.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationSector.Content = "You have to select sector!";
            }

            if (cmbSector.SelectedItem == null)
            {
                lblValidationSector.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationSector.Foreground = new SolidColorBrush(Colors.Red);
                isValidSector = false;
            }
            else
            {
                lblValidationGender.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Black);
                isValidSector = true;
            }
            IsRegistrationUserWorkerEnabled();
        }

        private void txtYearsOfexpirienc_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtYearsOfexpirienc.Focus())
            {
                lblValidationYearsOfService.Visibility = Visibility.Visible;
                lblValidationYearsOfService.FontSize = 16;
                lblValidationYearsOfService.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationYearsOfService.Content = "The have to input years of service!\nYears of service must be between \n1 and 45";
            }

            string patternYearsOfService = @"^([0-9]{1,2})$";
            Match match = Regex.Match(txtYearsOfexpirienc.Text, patternYearsOfService, RegexOptions.IgnoreCase);

            bool isValidYears = int.TryParse(txtYearsOfexpirienc.Text, out int value);

            if (!match.Success || value >45 || value<0)
            {
                txtYearsOfexpirienc.BorderBrush = new SolidColorBrush(Colors.Red);
                txtYearsOfexpirienc.Foreground = new SolidColorBrush(Colors.Red);
                isValidYearsOfService = false;
            }
            else
            {
                lblValidationYearsOfService.Visibility = Visibility.Hidden;
                txtYearsOfexpirienc.BorderBrush = new SolidColorBrush(Colors.Black);
                txtYearsOfexpirienc.Foreground = new SolidColorBrush(Colors.Black);
                isValidYearsOfService = true;
            }
            IsRegistrationUserWorkerEnabled();
            
        }

        private void cmbQualification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbQualification.Focus())
            {
                lblValidationQualification.Visibility = Visibility.Visible;
                lblValidationQualification.FontSize = 16;
                lblValidationQualification.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationQualification.Content = "You have to select qualification level!";
            }

            if (cmbQualification.SelectedItem == null)
            {
                lblValidationQualification.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationQualification.Foreground = new SolidColorBrush(Colors.Red);
                isValidQualification = false;
            }
            else
            {
                lblValidationQualification.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationQualification.Foreground = new SolidColorBrush(Colors.Black);
                isValidQualification = true;
            }
            IsRegistrationUserWorkerEnabled();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEmail.Focus())
            {
                lblValidationEmail.Visibility = Visibility.Visible;
                lblValidationEmail.FontSize = 16;
                lblValidationEmail.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationEmail.Content = "The email is not in valid form!";
            }

            string patternEmail = @"^([a-zA-Z0-9_\-\\.]+)@([a-zA-Z0-9_\-\\.]+)\.([a-zA-Z]{2,5})$";
            Match match = Regex.Match(txtEmail.Text, patternEmail, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                txtEmail.Foreground = new SolidColorBrush(Colors.Red);
                isValidEmail = false;
            }
            else
            {
                lblValidationEmail.Visibility = Visibility.Hidden;
                txtEmail.BorderBrush = new SolidColorBrush(Colors.Black);
                txtEmail.Foreground = new SolidColorBrush(Colors.Black);
                isValidEmail = true;
            }
            IsRegistrationUserMenagerEnabled();
        }

        private void txtBackupPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtBackupPassword.Focus())
            {
                lblValidationBackupPassword.Visibility = Visibility.Visible;
                lblValidationBackupPassword.FontSize = 16;
                lblValidationBackupPassword.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationBackupPassword.Content = "The password must contains at least:\nMinimum length 5 characters!";
            }

            string patternPassword = @"^[A-Za-z0-9\d@$!%*#?&]{5,}$";
            Match match = Regex.Match(txtBackupPassword.Password, patternPassword, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtBackupPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                txtBackupPassword.Foreground = new SolidColorBrush(Colors.Red);
                isValidBackupPassword = false;
            }
            else
            {
                lblValidationBackupPassword.Visibility = Visibility.Hidden;
                txtBackupPassword.BorderBrush = new SolidColorBrush(Colors.Black);
                txtBackupPassword.Foreground = new SolidColorBrush(Colors.Black);
                isValidBackupPassword = true;
            }
            IsRegistrationUserMenagerEnabled();
        }

        private void txtNumberOfOffice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNumberOfOffice.Focus())
            {
                lblValidationNumberOfOfice.Visibility = Visibility.Visible;
                lblValidationNumberOfOfice.FontSize = 16;
                lblValidationNumberOfOfice.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationNumberOfOfice.Content = "The have to input \nnumber of office(1-999)!";
            }

            string patternYearsOfService = @"^([0-9]{1,3})$";
            Match match = Regex.Match(txtNumberOfOffice.Text, patternYearsOfService, RegexOptions.IgnoreCase);

            bool isValidYears = int.TryParse(txtNumberOfOffice.Text, out int value);

            if (!match.Success || value < 0)
            {
                txtNumberOfOffice.BorderBrush = new SolidColorBrush(Colors.Red);
                txtNumberOfOffice.Foreground = new SolidColorBrush(Colors.Red);
                isValidNumberOfOfice = false;
            }
            else
            {
                lblValidationNumberOfOfice.Visibility = Visibility.Hidden;
                txtNumberOfOffice.BorderBrush = new SolidColorBrush(Colors.Black);
                txtNumberOfOffice.Foreground = new SolidColorBrush(Colors.Black);
                isValidNumberOfOfice = true;
            }
            IsRegistrationUserMenagerEnabled();
        }
    }
}
