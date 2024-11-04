using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarDealership
{
    internal class DataloadHelper
    {
        public static void LoadUserLabel(Label lbl)
        {
            using (var context = new user100_dbEntities())
            {
                var user = context.iiUsers.FirstOrDefault(u => u.id == MainWindow.UserID);
                lbl.Content = user.name + " " + user.lastname;
            }
        }
    }
}
