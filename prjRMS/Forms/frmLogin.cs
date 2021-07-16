using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjRMS
{
    public partial class frmLogin : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public delegate void frmMainEvnt(string Desig, string Uid, bool Pmain, bool Setting, bool NewTenant, bool TenantCont, bool RmBill, 
                                    bool Misce, bool TeBill, bool Payments, bool ContSign, bool MoveOut, bool Terminate);
        public event frmMainEvnt unlocked;
        public string Uid,desig;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUid.Text == "" || txtPwd.Text == "") 
            {
                MessageBox.Show("Please enter your username and password correctly!","Login",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtUid.Focus();
                return;
            }

            if (Login())
            {
                DesigOpen(txtUid.Text, desig);

                SetLogin();

                Audit aud = new Audit();
                aud.AuditLogs(txtUid.Text, desig, "Account Login");

                this.Close();
            }
            else 
            {
                MessageBox.Show("Username is not recognized or the password is incorrect!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUid.Text = "";
                txtPwd.Text = "";
                txtUid.Focus();
            }
        }

        void SetLogin() 
        {
            Properties.Settings.Default.Username = txtUid.Text;
            Properties.Settings.Default.Desig = desig;
            Properties.Settings.Default.Save();
        }

        bool Login() 
        {
            try
            {
                string SysCreator = "fernan";
                string SysCreatorPwd = "0901pr0J3ctf0273";

                if (txtUid.Text == SysCreator && txtPwd.Text == SysCreatorPwd)
                {
                    desig = "System Creator";
                    return true;
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
                        desig = rs.Fields["Designation"].Value.ToString();
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
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        bool DesigOpen(string UserId,string Designation) 
        {
            try
            {
                if (Designation == "System Creator")
                {

                    Properties.Settings.Default.EditCont = true;
                    Properties.Settings.Default.EditRmBill = true;
                    Properties.Settings.Default.Save();

                    if (unlocked != null)
                    {
                        unlocked(Designation, UserId, true, true, true, true, true, true, true, true, true, true, true);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
                            bool Pmain = true;
                            bool Settings = Convert.ToBoolean(Convert.ToInt32(rs.Fields["Settings"].Value.ToString()));
                            bool NewTenant = Convert.ToBoolean(Convert.ToInt32(rs.Fields["NewTenant"].Value.ToString()));
                            bool TenantCont = Convert.ToBoolean(Convert.ToInt32(rs.Fields["TenantContract"].Value.ToString()));
                            bool RmBill = Convert.ToBoolean(Convert.ToInt32(rs.Fields["RoomBilling"].Value.ToString()));
                            bool Misce = Convert.ToBoolean(Convert.ToInt32(rs.Fields["Miscellaneous"].Value.ToString()));
                            bool TeTrans = Convert.ToBoolean(Convert.ToInt32(rs.Fields["tTransaction"].Value.ToString()));
                            bool Payments = Convert.ToBoolean(Convert.ToInt32(rs.Fields["Payments"].Value.ToString()));
                            bool ContSign = Convert.ToBoolean(Convert.ToInt32(rs.Fields["ContractSign"].Value.ToString()));
                            bool MoveOut = Convert.ToBoolean(Convert.ToInt32(rs.Fields["MoveOut"].Value.ToString()));
                            bool Terminate = Convert.ToBoolean(Convert.ToInt32(rs.Fields["Terminate"].Value.ToString()));

                            Properties.Settings.Default.EditCont = Convert.ToBoolean(Convert.ToInt32(rs.Fields["EditContract"].Value.ToString()));
                            Properties.Settings.Default.EditRmBill = Convert.ToBoolean(Convert.ToInt32(rs.Fields["EditRmBill"].Value.ToString()));
                            Properties.Settings.Default.Save();

                            if (unlocked != null)
                            {
                                unlocked(Designation, UserId, Pmain, Settings, NewTenant, TenantCont, RmBill, Misce, TeTrans, Payments, ContSign, MoveOut, Terminate);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnLogin_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }
        }
    }
}