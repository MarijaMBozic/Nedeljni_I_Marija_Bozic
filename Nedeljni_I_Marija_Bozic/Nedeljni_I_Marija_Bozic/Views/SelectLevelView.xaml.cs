using Nedeljni_I_Marija_Bozic.Models;
using Nedeljni_I_Marija_Bozic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for SelectLevelView.xaml
    /// </summary>
    public partial class SelectLevelView : Window
    {
        private bool isValidLevel;
        SelectLevelViewModel selectLevelViewModel;
        public SelectLevelView(Menager menager)
        {
            InitializeComponent();
            selectLevelViewModel = new SelectLevelViewModel(menager, this);
            this.DataContext = selectLevelViewModel;
        }

        private void IsAddingLevelEnabled()
        {
            if (isValidLevel)
            {
                btnOK.IsEnabled=true;
            }
            else
            {
                btnOK.IsEnabled=false;
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            selectLevelViewModel.UpdateMenager();
        }

        private void cmbSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSelect.SelectedItem == null)
            {
                isValidLevel = false;
            }
            else
            {
                isValidLevel = true;
            }
            IsAddingLevelEnabled();
        }
    }
}
