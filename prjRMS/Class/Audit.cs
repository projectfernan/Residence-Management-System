using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjRMS
{
    class Audit
    {
        public void AuditLogs(string Uid,string Desig,string Evnt) 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn()) 
                {
                    rs = conn.MySql.Execute("call insAuditLogs('" + Uid + "','" + Desig + "','" + Evnt + "')",out ra,(int)CommandTypeEnum.adCmdText);
                }
            }
            catch 
            {
            
            }
        }
    }
}
