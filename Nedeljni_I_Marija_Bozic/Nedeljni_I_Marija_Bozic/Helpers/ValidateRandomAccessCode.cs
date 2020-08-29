using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nedeljni_I_Marija_Bozic.Helpers
{
    public class ValidateRandomAccessCode
    {
        public static bool IsVaslidAccesCode(string accessCodeInput)
        {
            string locationFile = @"..\..\ManagerAccess\ManagerAccess.txt";
            if (File.Exists(locationFile))
            {
                string[] credentials = File.ReadAllLines(locationFile);
                string accesCode = credentials[0];            
               
                if (accesCode.ToLower() == accessCodeInput.ToLower())
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Insert access code is not valid try agen");
            }
            return false;
        }
    }
}
