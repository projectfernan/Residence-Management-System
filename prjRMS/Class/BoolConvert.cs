using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRMS
{
    class BoolConvert
    {
        public bool BoolConv(string i)
        {
            Int32 x = Convert.ToInt32(i);
            return Convert.ToBoolean(x);    
        }
    }
}
