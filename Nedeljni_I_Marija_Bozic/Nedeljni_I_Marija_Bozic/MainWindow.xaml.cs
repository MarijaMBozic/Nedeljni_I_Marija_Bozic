﻿using Nedeljni_I_Marija_Bozic.ViewModels;
using Nedeljni_I_Marija_Bozic.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nedeljni_I_Marija_Bozic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isValidUsername;
        private bool isValidPassword;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration viewRegistration = new Registration();
            viewRegistration.Show();
            Close();
        }
        private void IsLoginEnabled()
        {
            if (isValidUsername &&
                isValidPassword)
            {
                btnLogin.IsEnabled = true;
            }
            else
            {
                btnLogin.IsEnabled = false;
            }
        }
        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUsername.Focus())
            {
                lblValidationUserName.Visibility = Visibility.Visible;
                lblValidationUserName.FontSize = 16;
                lblValidationUserName.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationUserName.Content = "The username contains \nat least 5 characters!";
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
                lblValidationUserName.Visibility = Visibility.Hidden;
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Black);
                txtUsername.Foreground = new SolidColorBrush(Colors.Black);
                isValidUsername = true;
            }
            IsLoginEnabled();
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
            IsLoginEnabled();
        }
    }
}
