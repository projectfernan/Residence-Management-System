using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjRMS
{
    class UpdBillStat
    {
        public bool BillPaid(int bId,string rem)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updBillStatRem(" + bId + ",'" + rem + "')", out ra, (int)CommandTypeEnum.adCmdText);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool BillsInv(int bId, string Inv)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updBillsInv(" + bId + ",'" + Inv + "')", out ra, (int)CommandTypeEnum.adCmdText);
                    return true;
                }
                else
                {
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
