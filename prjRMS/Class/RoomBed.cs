using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRMS
{
    class RoomBed
    {
        public bool chekBed(int cId) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getBed(" + cId + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        } 
    }
}
