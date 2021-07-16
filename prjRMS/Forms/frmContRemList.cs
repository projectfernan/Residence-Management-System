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
    public partial class frmContRemList : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmContRemList()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContRemList_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmContRemList_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmContRemList_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmContRemList_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        void headerContList()
        {
            lstResList.Clear();
            int w = lstResList.Width / 5;

            lstResList.Columns.Add("End Date", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Room No", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Bed", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Days Left", w, HorizontalAlignment.Left);
        }

        void FillContRem()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    decimal ResLeft = Properties.Settings.Default.ContLeftDays;

                    rs = conn.MySql.Execute("call slctContractRem(" + ResLeft + ",'Under Contract','" + cboCateg.Text + "','')", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());

                            viewlst = lstResList.Items.Add(EndDt.ToString("yyyy-MM-dd"), lup);
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

        void FindContRem()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    decimal ResLeft = Properties.Settings.Default.ContLeftDays;

                    rs = conn.MySql.Execute("call slctContractRem(" + ResLeft + ",'Under Contract','" + cboCateg.Text + "','" + txtKeycode.Text + "')", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);

                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());

                            viewlst = lstResList.Items.Add(EndDt.ToString("yyyy-MM-dd"), lup);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            headerContList();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillContRem);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            headerContList();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FindContRem);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnSearch_Click(sender, e);
            }
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
