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
    /// Interaction logic for MasterAdminView.xaml
    /// </summary>
    public partial class MasterAdminView : Window
    {
        public MasterAdminView()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AddNewAdmin admin = new AddNewAdmin();
            admin.Show();
            Close();
        }
    }
}
