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
    /// Interaction logic for AddNewMenagerLevelOfResponsibility.xaml
    /// </summary>
    public partial class AddNewMenagerLevelOfResponsibility : Window
    {
        AddNewLevelOfResponsibilitiViewMOdel addNewLevelOfResponsibilitiViewMOdel;
        public AddNewMenagerLevelOfResponsibility()
        {
            InitializeComponent();
            addNewLevelOfResponsibilitiViewMOdel = new AddNewLevelOfResponsibilitiViewMOdel(this);
            this.DataContext = addNewLevelOfResponsibilitiViewMOdel;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddLevel_Click(object sender, RoutedEventArgs e)
        {
            SelectLevelView selectView = new SelectLevelView(addNewLevelOfResponsibilitiViewMOdel.SelectedMenager);
            selectView.Show();
            Close();
        }
    }
}
