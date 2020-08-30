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
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
            this.DataContext = new AdminViewModel(this);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnPosition_Click(object sender, RoutedEventArgs e)
        {
            AddNewProsition addNewPosition = new AddNewProsition();
            addNewPosition.Show();
        }

        private void btnSectors_Click(object sender, RoutedEventArgs e)
        {
            SectorView sector = new SectorView();
            sector.Show();

        }

        private void btnWorkers_Click(object sender, RoutedEventArgs e)
        {
            WorkerList workerList = new WorkerList();
            workerList.Show();
        }

        private void btnAllMenagers_Click(object sender, RoutedEventArgs e)
        {
            MenagerListView menager = new MenagerListView();
            menager.Show();
        }

        private void btnLevelOfresponsibiliti_Click(object sender, RoutedEventArgs e)
        {
            AddNewMenagerLevelOfResponsibility levelView = new AddNewMenagerLevelOfResponsibility();
            levelView.Show();
        }
    }
}
