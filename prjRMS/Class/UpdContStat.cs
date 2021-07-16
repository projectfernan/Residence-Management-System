using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjRMS
{
    class UpdContStat
    {
        public bool checkContStat(int cId) 
        {
            try 
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call chkContStat(" + cId + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return true;
                    }
                    else {
                        return false;
                    }
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

        public bool UpdateStatus(int cId, string fName, int fValue) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("update tbltenantcontract set " + fName + " = " + fValue + " where Id = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
                    return true;
                }
                else {
                    return false;
                }
            }
            catch{
                return false;
            }
        }

        public bool ContStatus(int cId, string fValue)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("update tbltenantcontract set ContractStatus = '" + fValue + "' where Id = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
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

        public void UpdExtension(int cId) 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Recordset rs2 = new Recordset();
                Recordset rs3 = new Recordset();
                object ra;
                object ra2;
                object ra3;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select RewExId from tbltenantcontract where Id = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false) 
                    {
                        int ExId = Convert.ToInt32(rs.Fields["RewExId"].Value.ToString());

                        //rs2 = conn.MySql.Execute("update tbltenantcontract set ContractStatus = 'Extend' where Id = " + ExId, out ra2, (int)CommandTypeEnum.adCmdText);
                        rs3 = conn.MySql.Execute("update tblreserved set cId = " + cId + " where cId = " + ExId, out ra3, (int)CommandTypeEnum.adCmdText);
                    }
                }
            }
            catch
            {
                
            }
        }

        public void UpdAdjustment(int cId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Recordset rs2 = new Recordset();
                Recordset rs3 = new Recordset();
                object ra;
                object ra2;
                object ra3;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select RewExId from tbltenantcontract where Id = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int ExId = Convert.ToInt32(rs.Fields["RewExId"].Value.ToString());

                        rs2 = conn.MySql.Execute("update tbltenantcontract set ContractStatus = 'Adjusted' where Id = " + ExId, out ra2, (int)CommandTypeEnum.adCmdText);
                        rs3 = conn.MySql.Execute("update tblreserved set cId = " + cId + " where cId = " + ExId, out ra3, (int)CommandTypeEnum.adCmdText);
                    }
                }
            }
            catch
            {

            }
        }

        public bool UpdMoveOut(int cId,DateTime DtMO)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {

                    string MoveOut = DtMO.ToString("yyyy-MM-dd");
                    rs = conn.MySql.Execute("update tbltenantcontract set MoveOutDate = '" + MoveOut + "' where Id = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
                    conn.rsCUD("update tblbedhistory set MoveOutDate = '" + MoveOut + "' where cId = " + cId);
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

        public bool UpdMoveIn(int cId, DateTime DtMO)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {

                    string MoveOut = DtMO.ToString("yyyy-MM-dd");
                    rs = conn.MySql.Execute("update tbltenantcontract set MoveInDate = '" + MoveOut + "' where Id = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
                    conn.rsCUD("update tblbedhistory set MoveInDate = '" + MoveOut + "' where cId = " + cId);
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

        public bool UpdBhMoveOut(int cId, DateTime DtMO)
        {
            try
            {
                DBconn conn = new DBconn();
                string MoveOut = DtMO.ToString("yyyy-MM-dd");

                conn.rsCUD("update tblbedhistory set MoveInDate = '" + MoveOut + "' where Id = " + cId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdSecDep(int cId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select RewExId from tbltenantcontract where Id = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int ExId = Convert.ToInt32(rs.Fields["RewExId"].Value.ToString());

                        conn.rsCUD("update tbldeposits set cId = " + cId + " where cId = " + ExId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
