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
    public partial class frmSysAcc : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmSysAcc()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSysAcc_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmSysAcc_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmSysAcc_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmSysAcc_Load(object sender, EventArgs e)
        {
            headerSysAcc();
            FillSysAcc();
        }

        public void headerSysAcc()
        {
            lstSysAcc.Clear();
            int w = lstSysAcc.Width / 4;

            lstSysAcc.Columns.Add("Date Registered", w, HorizontalAlignment.Left);
            lstSysAcc.Columns.Add("Username", w, HorizontalAlignment.Left);
            lstSysAcc.Columns.Add("Designation", w, HorizontalAlignment.Left);
            lstSysAcc.Columns.Add("Name", w, HorizontalAlignment.Left);
        }

        public void FillSysAcc()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    decimal ResTotal = Properties.Settings.Default.ResTotalDays;
                    decimal ResLeft = Properties.Settings.Default.ResLeftDays;

                    rs = conn.MySql.Execute("select DateReg,Username,Designation,Name from tblsystemacc order by DateReg,Username", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstSysAcc.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstSysAcc.Items.Add(rs.Fields["DateReg"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Username"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Designation"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            rs.MoveNext();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FindSysAcc()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select DateReg,Username,Designation,Name from tblsystemacc where " + cboCateg.Text + " like '%" + txtKeycode.Text + "%' order by DateReg,Username", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstSysAcc.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstSysAcc.Items.Add(rs.Fields["DateReg"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Username"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Designation"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            rs.MoveNext();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            headerSysAcc();
            FillSysAcc();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            headerSysAcc();
            FindSysAcc();
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSysAcc shw = new frmAddSysAcc();
            shw.ShowDialog();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (lstSysAcc.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select account record that you want to edit!","Edit",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            frmUpdateSysAcc shw = new frmUpdateSysAcc();
            shw.Uid = lstSysAcc.SelectedItems[0].SubItems[1].Text;
            shw.Name = lstSysAcc.SelectedItems[0].SubItems[3].Text;
            shw.Desig = lstSysAcc.SelectedItems[0].SubItems[2].Text;

            shw.ShowDialog();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (lstSysAcc.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select account record that you want to change the password!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmChangePwd shw = new frmChangePwd();
            shw.Uid = lstSysAcc.SelectedItems[0].SubItems[1].Text;
            shw.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult ys = MessageBox.Show("Are you sure do you want to delete this system account?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (ys == DialogResult.Yes) 
            {
                if (delSysAcc()) 
                {
                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig,"System Acc: (" + lstSysAcc.SelectedItems[0].SubItems[1].Text + ") is deleted.");

                    MessageBox.Show("System account successfully deleted!","Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    headerSysAcc();
                    FillSysAcc();
                }
            }
        }

        bool delSysAcc()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    string Uid = lstSysAcc.SelectedItems[0].SubItems[1].Text;
                    rs = conn.MySql.Execute("delete from tblsystemacc where Username = '" + Uid + "'", out rc, (int)CommandTypeEnum.adCmdText);

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
