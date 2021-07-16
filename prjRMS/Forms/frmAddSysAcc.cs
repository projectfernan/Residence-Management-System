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
    public partial class frmAddSysAcc : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmAddSysAcc()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddSysAcc_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmAddSysAcc_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmAddSysAcc_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUid.Text == "" || txtPwd.Text == "" || txtConfirm.Text == "" || txtName.Text == "" || cboDesig.Text == "") 
            {
                MessageBox.Show("Please don't leave a blank!","Save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (txtUid.Text == "fernan") 
            {
                MessageBox.Show("This username is for system creator only!","Save",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUid.Text = "";
                txtUid.Focus();
                return;
            }

            if (chkUid() == true) 
            {
                MessageBox.Show("Username is already exist!","Save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtUid.Text = "";
                txtUid.Focus();
                return;
            }

            if (txtPwd.Text != txtConfirm.Text) 
            {
                MessageBox.Show("Password and confirm pwd did not match!","Save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtPwd.Text = "";
                txtConfirm.Text = "";
                txtPwd.Focus();
                return;
            }

            DialogResult ys = MessageBox.Show("Are you sure that all of you entries are correct?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (ys == DialogResult.Yes) 
            {
                if (insSysAcc()) 
                {
                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "System Acc: (" + txtUid.Text + ") created.");

                    MessageBox.Show("New system account successfully saved!","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        bool chkUid()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call chkUid('" + txtUid.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        bool insSysAcc() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblSystemAcc('" + txtUid.Text + "','" + txtPwd.Text + "','" + cboDesig.Text + "','" + txtName.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);
                    return true;
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

        private void frmAddSysAcc_Load(object sender, EventArgs e)
        {
            loadDesig(cboDesig);
        }

        void loadDesig(ComboBox cbo)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    cbo.Items.Clear();
                    rs = conn.MySql.Execute("select Designation from tbldesig order by Designation", out ra, (int)CommandTypeEnum.adCmdText);
                    while (rs.EOF == false)
                    {
                        cbo.Items.Add(rs.Fields["Designation"].Value.ToString());
                        rs.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDesig_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
