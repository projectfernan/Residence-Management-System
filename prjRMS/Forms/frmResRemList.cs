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
    public partial class frmResRemList : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmResRemList()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmResRemList_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmResRemList_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmResRemList_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmResRemList_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        public void headerResList()
        {
            lstResList.Clear();
            int w = lstResList.Width / 5;

            lstResList.Columns.Add("Start Date", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Room No", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Bed", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Days Left", w, HorizontalAlignment.Left);
        }

        public void FillResRem()
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

                    rs = conn.MySql.Execute("call slctReservedRem(" + ResTotal + "," + ResLeft + ",'Reserved','" + cboCateg.Text + "','')", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());

                            viewlst = lstResList.Items.Add(StartDt.ToString("yyyy-MM-dd"), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DaysLeft"].Value.ToString());
                            //viewlst.BackColor = Color.
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

        public void FindResRem()
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

                    rs = conn.MySql.Execute("call slctReservedRem(" + ResTotal + "," + ResLeft + ",'Reserved','" + cboCateg.Text + "','" + txtKeycode.Text + "')", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);

                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());

                            viewlst = lstResList.Items.Add(StartDt.ToString("yyyy-MM-dd"), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DaysLeft"].Value.ToString());

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            headerResList();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FindResRem);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnSearch_Click(sender,e);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            headerResList();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillResRem);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {

        }
    }
}
