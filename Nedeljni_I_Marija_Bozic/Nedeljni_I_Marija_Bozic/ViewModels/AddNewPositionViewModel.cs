using Nedeljni_I_Marija_Bozic.Helpers;
using Nedeljni_I_Marija_Bozic.Models;
using Nedeljni_I_Marija_Bozic.Service;
using Nedeljni_I_Marija_Bozic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nedeljni_I_Marija_Bozic.ViewModels
{
    public class AddNewPositionViewModel:ViewModelBase
    {
        AddNewProsition addNewPosition;
        ServiceCode service = new ServiceCode();
        #region Constructor
        public AddNewPositionViewModel(AddNewProsition addNewPositionOpen)
        {
            addNewPosition = addNewPositionOpen;            
        }
        #endregion
        #region Property
        private Position position = new Position();
        public Position Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }
        #endregion
        #region Commands
        public void SavePosition()
        {
            try
            {
                if (Position.PositionId == 0)
                {
                    if(Position.Description==null)
                    {
                        Position.Description = "";
                    }                  
                    bool uniquePositionName = service.CheckPositionName(Position.Name);
                    if (!uniquePositionName)
                    {
                        MessageBoxResult result = MessageBox.Show("Are you sure you want to save the new position", "Add New Position", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            int positionId = service.AddPosition(Position);
                            if (positionId != 0)
                            {
                                MessageBox.Show("You have successfully added new position");
                                Logging.LoggAction("AddNewPositionViewModel", "Info", "Succesfull add new position");
                                addNewPosition.Close();                                
                            }
                        }
                        else
                        {
                            addNewPosition.Close();
                        }
                    }
                    else
                    {                        
                        MessageBox.Show("Name is not unique!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
