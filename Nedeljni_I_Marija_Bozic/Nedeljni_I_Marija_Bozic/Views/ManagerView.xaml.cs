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
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {

        public ManagerView(Menager menager)
        {
            InitializeComponent();
            this.DataContext = new MenagerViewModel(menager, this);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();            
        }

        private void btnAddNewposition_Click(object sender, RoutedEventArgs e)
        {
            AddNewProsition newPosition = new AddNewProsition();
            newPosition.Show();
        }
    }
}
