using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjRMS
{
    class DashBoardRem
    {
        public string ReservedRem()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                decimal ResTotal = Properties.Settings.Default.ResTotalDays;
                decimal ResLeft = Properties.Settings.Default.ResLeftDays;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getReservedRem(" + ResTotal + "," + ResLeft + ",'Reserved')", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return rs.Fields["TotalReminder"].Value.ToString();
                    }
                    else {
                        return "0";
                    }
                }
                else {
                    return "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return "0";
            }
        }

        public string ContractRem()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                decimal ResLeft = Properties.Settings.Default.ContLeftDays;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getContractRem(" + ResLeft + ",'Under Contract')", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return rs.Fields["TotalReminder"].Value.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else
                {
                    return "0";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "0";
            }
        }
    }
}
