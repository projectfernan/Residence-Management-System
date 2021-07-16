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
    public partial class frmUpdateSysAcc : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string Uid, Name, Desig;

        public frmUpdateSysAcc()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateSysAcc_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmUpdateSysAcc_MouseMove(object sender, MouseEventArgs e)
        {

            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmUpdateSysAcc_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmUpdateSysAcc_Load(object sender, EventArgs e)
        {
            txtUid.Text = Uid;
            txtName.Text = Name;
            cboDesig.Text = Desig;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cboDesig.Text == "")
            {
                MessageBox.Show("Please don't leave a blank!","Update",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DialogResult ys = MessageBox.Show("Are you sure that you want to save changes?","Update",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (ys == DialogResult.Yes) 
            {
                if (updSysAcc())
                {
                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "System Acc: (" + txtUid.Text + ") updated.");

                    MessageBox.Show("System account successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        bool updSysAcc()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("update tblsystemacc set Name = '" + txtName.Text + "', Designation = '" + 
                                            cboDesig.Text + "' where Username = '" + txtUid.Text + "'", out ra, (int)CommandTypeEnum.adCmdText);
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

    }
}
