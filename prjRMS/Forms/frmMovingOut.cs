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
    public partial class frmMovingOut : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmMovingOut()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMovingOut_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmMovingOut_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmMovingOut_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmMovingOut_Load(object sender, EventArgs e)
        {
            headerTpi();
            //fillTpi();
        }

        void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 5;

            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Move Out Date", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Room No", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Bed", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Assisted By", w, HorizontalAlignment.Left);
        }

        void fillTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select Id,cId,MoveOutDate,Name,RoomNo,Bed,AssistedBy from vwemoveout order by MoveOutDate desc", out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            DateTime MoveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());

                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(MoveOut.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["AssistedBy"].Value.ToString());
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

        void findTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    switch (cboCateg.Text)
                    {
                        case "RoomNo":
                            rs = conn.MySql.Execute("select Id,cId,MoveOutDate,Name,RoomNo,Bed,AssistedBy from vwemoveout where cast(" +
                                           cboCateg.Text + " as char) like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);

                            break;
                        default:
                            rs = conn.MySql.Execute("select Id,cId,MoveOutDate,Name,RoomNo,Bed,AssistedBy from vwemoveout where " +
                                           cboCateg.Text + " like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);

                            break;
                    }

                   
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            DateTime MoveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());

                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(MoveOut.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["AssistedBy"].Value.ToString());
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

        private void btnMoveOut_Click(object sender, EventArgs e)
        {
            frmSetMoveOut shw = new frmSetMoveOut();
            shw.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            headerTpi();

            Thread th = new Thread(() =>
            {
                Action act = new Action(findTpi);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            headerTpi();
            Thread th = new Thread(() =>
            {
                Action act = new Action(fillTpi);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnUpdDt_Click(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select move in record that you want to update move out date!", "Update Move In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmUpdMoving shw = new frmUpdMoving();
            shw.mID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
            shw.cID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[1].Text);
            shw.MoveDate = Convert.ToDateTime(lstTpi.SelectedItems[0].SubItems[2].Text);
            shw.wLoad = "MoveOut";
            shw.ShowDialog();
        }
    }
}
