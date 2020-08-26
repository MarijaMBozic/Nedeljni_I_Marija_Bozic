﻿using Nedeljni_I_Marija_Bozic.ViewModels;
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
    /// Interaction logic for AddNewAdmin.xaml
    /// </summary>
    public partial class AddNewAdmin : Window
    {
        public AddNewAdmin()
        {
            InitializeComponent();
            this.DataContext = new AddNewAdminViewModel(this);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MasterAdminView master = new MasterAdminView();
            master.Show();
            Close();
        }
    }
}
