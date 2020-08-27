using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.Helpers
{
    public class RandomString
    {
        private static Random random = new Random();
        public static void RandomStringManager()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string result= new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            InsertManagerAccessCode(result);
        }

        public static void InsertManagerAccessCode(string randomString)
        {
            try
            {
                string newAccessCode = string.Format("{0}", randomString);
                File.WriteAllText(@"..\..\ManagerAccess\ManagerAccess.txt", newAccessCode);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("{0}", ex.ToString());
            }
        }
    }
}
