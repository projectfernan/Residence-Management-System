using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjRMS
{
    class clsPayments
    {
        public void insPayment(int cId,string pInvNo, string pItem, decimal pAmt, string pType, string pBank, string pChekNo, string pChekDt, string pDtGiven, int bilId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insPayment(" +
                                            cId + "," +
                                            "'" + pInvNo + "'," +
                                            "'" + pItem + "'," +
                                            pAmt + "," +
                                            "'" + pType + "'," +
                                            "'" + pChekNo + "'," +
                                            "'" + pBank + "'," +
                                            "'" + pChekDt + "'," +
                                            "'" + pDtGiven + "'," + bilId + ")",
                                            out ra, (int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
