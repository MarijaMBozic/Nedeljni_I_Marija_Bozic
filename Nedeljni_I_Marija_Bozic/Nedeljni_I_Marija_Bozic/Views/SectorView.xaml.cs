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
    /// Interaction logic for SectorView.xaml
    /// </summary>
    public partial class SectorView : Window
    {
        public SectorView()
        {
            InitializeComponent();
            this.DataContext = new SectorViewModel(this);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddNewSector_Click(object sender, RoutedEventArgs e)
        {
            AddNewSector addSector = new AddNewSector();
            addSector.Show();
            Close();
        }
    }
}
