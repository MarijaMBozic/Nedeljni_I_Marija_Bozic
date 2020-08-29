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
    /// Interaction logic for CheckRandomAccessCodeView.xaml
    /// </summary>
    public partial class CheckRandomAccessCodeView : Window
    {
        RegistrationViewModel register;
        public CheckRandomAccessCodeView(RegistrationViewModel register)
        {
            this.register = register;
            this.DataContext = register;
            InitializeComponent();

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
           if(register.CheckAccessCode(txtCode.Password))
            {
                Close();
                register.MenagerBtn = true;
                register.WorkerBtn = true;
            }
           if(register.count==0)
            {
                Close();
                MessageBox.Show("The code is not valid!\nYou no longer have the option to register as a manager.\nYou can only register as a worker!");
                register.WorkerRegistry = true;
                register.MenagerBtn = true;
                register.WorkerBtn = true;
            }
        }
    }
}
