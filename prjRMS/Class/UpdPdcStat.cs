using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjRMS
{
    class UpdPdcStat
    {
        public bool PdcUsed(int PdcId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updPdcStat(" + PdcId + ")", out ra, (int)CommandTypeEnum.adCmdText);
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

        public void TransferPDC(int cId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Recordset rs2 = new Recordset();
                Recordset rs3 = new Recordset();
                Recordset rs4 = new Recordset();
                object ra;
                object ra2;
                object ra3;
                object ra4;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("CALL getAdjustment(" + cId + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int ExId = Convert.ToInt32(rs.Fields["RewExId"].Value.ToString());
                        decimal Mf = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());

                        rs2 = conn.MySql.Execute("update tblpdc set cId = " + cId + " where cId = " + ExId + " and UsedStat = 0", out ra2, (int)CommandTypeEnum.adCmdText);
                        rs4 = conn.MySql.Execute("update tbltenantbills set Amount = " + Mf + " where BillName = 'Monthly Rent' and cId = " + ExId + " and BillStat = 0", out ra4, (int)CommandTypeEnum.adCmdText);
                        rs3 = conn.MySql.Execute("update tbltenantbills set cId = " + cId + " where cId = " + ExId + " and BillStat = 0", out ra3, (int)CommandTypeEnum.adCmdText);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
