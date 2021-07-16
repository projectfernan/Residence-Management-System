using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRMS
{
    class MakeMoney
    {
        public string Currency(decimal amt) {
            try
            {
                string ret = string.Format("{0:C}", amt);

                if (ret.Contains("₱"))
                {
                    return ret.Replace("₱", "");
                }
                else if (ret.Contains("$"))
                {
                    return ret.Replace("$", "");
                }
                else 
                {
                    return "0.00";
                }
            }
            catch {
                return "0.00";
            }
            
        }
    }
}
