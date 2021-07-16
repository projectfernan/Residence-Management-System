using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRMS
{
    class TenantID
    {
        public int Id()
        {
            int x = Properties.Settings.Default.TenantID;
            return x;
        }

        public void UpdateID()
        {
            int x = 1 + Properties.Settings.Default.TenantID;
            Properties.Settings.Default.TenantID = x;
            Properties.Settings.Default.Save();
        }


    }
}
