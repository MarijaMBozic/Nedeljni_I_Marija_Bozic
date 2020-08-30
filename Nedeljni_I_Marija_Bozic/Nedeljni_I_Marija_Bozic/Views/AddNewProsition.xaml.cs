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
    /// Interaction logic for AddNewProsition.xaml
    /// </summary>
    public partial class AddNewProsition : Window
    {
        private bool isValidName;
        AddNewPositionViewModel addNewPosition;
        public AddNewProsition()
        {
            InitializeComponent();
            addNewPosition = new AddNewPositionViewModel(this);
            this.DataContext = addNewPosition;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            addNewPosition.SavePosition();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void IsAddingNewPositionEnabled()
        {
            if (isValidName)
            {
                btnOK.IsEnabled = true;
            }
            else
            {
                btnOK.IsEnabled = false;
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Focus())
            {
                lblValidationPosition.Visibility = Visibility.Visible;
                lblValidationPosition.FontSize = 16;
                lblValidationPosition.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationPosition.Content = "The name must contain at least 2 caracters!";
            }

            string patternName = @"^([a-zA-Z ]{2,100})$";
            Match match = Regex.Match(txtName.Text, patternName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtName.Foreground = new SolidColorBrush(Colors.Red);
                isValidName = false;
            }
            else
            {
                lblValidationPosition.Visibility = Visibility.Hidden;
                txtName.BorderBrush = new SolidColorBrush(Colors.Black);
                txtName.Foreground = new SolidColorBrush(Colors.Black);
                isValidName = true;
            }
            IsAddingNewPositionEnabled();
        }
    }
}
