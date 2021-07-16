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
    public partial class frmChangePwd : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string Uid;

        public frmChangePwd()
        {
            InitializeComponent();
        }

        private void frmChangePwd_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmChangePwd_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmChangePwd_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePwd_Load(object sender, EventArgs e)
        {
            txtUid.Text = Uid;
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Text == "") 
            {
                MessageBox.Show("Please enter your old password!","Change Password",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (chekPass())
            {
                frmUpdatePass shw = new frmUpdatePass();
                shw.Uid = txtUid.Text;
                this.Hide();
                this.Close();
                shw.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Old password is wrong!","Change Password",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtOldPass.Text = "";
                txtOldPass.Focus();
            }
        }

        bool chekPass() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call slctLogin('" + txtUid.Text +
                                            "','" + txtOldPass.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);
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
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

        }

        private void txtOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnCon_Click(sender,e);
            }
        }
    }
}
