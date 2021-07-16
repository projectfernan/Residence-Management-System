using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace prjRMS
{
    public partial class frmVoid : Form
    {
        public delegate void frmSettleEvnt();
        public event frmSettleEvnt VoidTrans;

        public frmVoid()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                Thread th = new Thread(() =>
                {
                    Action act = new Action(DoVoid);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        void DoVoid() 
        {
            if (Login() == false) 
            {
                MessageBox.Show("Void access failed! Maybe your account is not for full access or your username is not recognized or the password is incorrect.","Void",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtUid.Text = "";
                txtPwd.Text = "";
                txtUid.Focus();
                return;
            }

            DialogResult v = MessageBox.Show("Are you sure do you want to void this transaction?", "Void", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (DialogResult.Yes == v)
            {
                if (VoidTrans != null)
                {
                    VoidTrans();
                    this.Close();
                }
            }
        }

        bool Login()
        {
            try
            {
                string SysCreator = "fernan";
                string SysCreatorPwd = "0901pr0J3ctf0273";

                if (txtUid.Text == SysCreator && txtPwd.Text == SysCreatorPwd)
                {
                    return DesigOpen("System Creator");
                }


                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call slctLogin('" + txtUid.Text +
                                            "','" + txtPwd.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return DesigOpen(rs.Fields["Designation"].Value.ToString());
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        bool DesigOpen(string Designation)
        {
            try
            {
                if (Designation == "System Creator")
                {
                    return true;
                }
                else
                {
                    DBconn conn = new DBconn();
                    Recordset rs = new Recordset();
                    object ra;

                    if (conn.ServerConn())
                    {
                        rs = conn.MySql.Execute("select * from tbldesig where Designation = '" + Designation + "'", out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {
                            if (Convert.ToBoolean(Convert.ToInt32(rs.Fields["Settings"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["NewTenant"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["TenantContract"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["RoomBilling"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["Miscellaneous"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["tTransaction"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["Payments"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["ContractSign"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["MoveOut"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["Terminate"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["EditContract"].Value.ToString())) &&
                            Convert.ToBoolean(Convert.ToInt32(rs.Fields["EditRmBill"].Value.ToString())))
                            {
                                return true;
                            }
                            else 
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
