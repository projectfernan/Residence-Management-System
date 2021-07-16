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
    public partial class frmAddMoveIn : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int CID;

        public frmAddMoveIn()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddMoveIn_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmAddMoveIn_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmAddMoveIn_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmAddMoveIn_Load(object sender, EventArgs e)
        {
            headerTpi();

            Disable();
        }

        void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 2;

            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Room No", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
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

                    rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate from vweassignbed where BedStatus = 'Under Contract'", out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["cId"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));

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
                        case "Name":
                            rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate from vweassignbed where " +
                                                     "BedStatus = 'Under Contract' and MoveInDate = EndDate and " + cboCateg.Text + " like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
                            break;
                        case "RoomNo":
                            rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate from vweassignbed where " +
                                                     "BedStatus = 'Under Contract' and MoveInDate = EndDate and Cast(" + cboCateg.Text + " as char) like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
                            break;
                    }

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["cId"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));

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

        void Enable()
        {
            txtAssisted.Enabled = true;
            dtMoveOut.Enabled = true;
            btnSettle.Enabled = true;
        }

        void Disable()
        {
            txtAssisted.Enabled = false;
            dtMoveOut.Enabled = false;
            btnSettle.Enabled = false;
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
            if (e.KeyCode == Keys.Enter) 
            {
                btnSearch_Click(sender, e);
            }
        }

        private void lstTpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count > 0)
            {
                CID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                txtTenant.Text = lstTpi.SelectedItems[0].SubItems[1].Text;
                txtRmNo.Text = lstTpi.SelectedItems[0].SubItems[2].Text;
                txtBed.Text = lstTpi.SelectedItems[0].SubItems[3].Text;
                txtStartDt.Text = lstTpi.SelectedItems[0].SubItems[4].Text;
                txtEndDt.Text = lstTpi.SelectedItems[0].SubItems[5].Text;

                Enable();
                txtAssisted.Focus();
            }
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        bool ChkMoveIn(int cId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call chkMoveIn(" + cId + ")", out ra, (int)CommandTypeEnum.adCmdText);
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

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (txtAssisted.Text == "")
            {
                MessageBox.Show("Please fill all fields!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult s = MessageBox.Show("Are you sure that all of your entries are correct?", "Move In", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (s != DialogResult.Yes)
            {
                return;
            }

            if (ChkMoveIn(CID)) 
            {
                MessageBox.Show(txtTenant.Text  + " is already move in!","Move In",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            Thread th = new Thread(() =>
            {
                Action act = new Action(insMoveIn);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void insMoveIn()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime MoveOut = dtMoveOut.Value;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblMoveIn(" +
                                                CID + ",'" +
                                                txtAssisted.Text + "','" +
                                                MoveOut.ToString("yyyy-MM-dd HH:mm") + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Move Out cId: (" + CID.ToString() + ") saved.");

                    DateTime dtMo = dtMoveOut.Value;
                    UpdContStat ud = new UpdContStat();
                    if (ud.UpdMoveIn(CID, dtMo))
                    {
                        MessageBox.Show(txtTenant.Text + " successfully move In!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
