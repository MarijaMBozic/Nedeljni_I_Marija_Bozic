using Nedeljni_I_Marija_Bozic.ViewModels;
using Nedeljni_I_Marija_Bozic.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nedeljni_I_Marija_Bozic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}
