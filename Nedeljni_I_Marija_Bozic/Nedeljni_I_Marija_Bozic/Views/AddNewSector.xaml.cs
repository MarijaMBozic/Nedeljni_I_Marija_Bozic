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
    /// Interaction logic for AddNewSector.xaml
    /// </summary>
    public partial class AddNewSector : Window
    {
        private bool isValidName;
        AddNewSectorViewModel addNewSector;
        public AddNewSector()
        {
            InitializeComponent();
            addNewSector = new AddNewSectorViewModel(this);
            this.DataContext = addNewSector;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            addNewSector.SaveSector();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void IsAddingNewSectorEnabled()
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
                lblValidationName.Visibility = Visibility.Visible;
                lblValidationName.FontSize = 16;
                lblValidationName.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationName.Content = "The name must contain at least 2 caracters!";
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
                lblValidationName.Visibility = Visibility.Hidden;
                txtName.BorderBrush = new SolidColorBrush(Colors.Black);
                txtName.Foreground = new SolidColorBrush(Colors.Black);
                isValidName = true;
            }
            IsAddingNewSectorEnabled();
        }
    }
}
