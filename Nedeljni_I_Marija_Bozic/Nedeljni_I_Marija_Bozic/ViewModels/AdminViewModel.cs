using Nedeljni_I_Marija_Bozic.Models;
using Nedeljni_I_Marija_Bozic.Service;
using Nedeljni_I_Marija_Bozic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.ViewModels
{
    public class AdminViewModel:ViewModelBase
    {
        AdminView adminView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public AdminViewModel(AdminView adminViewOpen)
        {
            this.adminView = adminViewOpen;
            Admin = service.GetAdminByUserId(ServiceCode.CurrentUser.UserId);
        }
        #endregion

        #region Properties
        private Administrator admin;
        public Administrator Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }
        #endregion
    }
}
