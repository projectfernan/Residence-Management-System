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
    public partial class frmUpdatePass : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string Uid;

        public frmUpdatePass()
        {
            InitializeComponent();
        }

        private void frmUpdatePass_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmUpdatePass_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmUpdatePass_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtNewPass.Text != txtConfirm.Text)
            {
                MessageBox.Show("New password did not match to confirm new pwd!","Save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtNewPass.Text = "";
                txtConfirm.Text = "";
                txtNewPass.Focus();
                return;
            }

            if (updPassword()) 
            {
                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "System Acc: (" + Uid + ") password updated.");

                MessageBox.Show("New password successfully saved!","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
        }

        bool updPassword()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("update tblsystemacc set Password = '" + txtNewPass.Text + "' where Username = '" + Uid + "'", out ra, (int)CommandTypeEnum.adCmdText);
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

        private void txtConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
