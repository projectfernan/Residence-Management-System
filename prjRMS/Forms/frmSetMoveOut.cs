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
    public partial class frmSetMoveOut : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int CID;

        public frmSetMoveOut()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetMoveOut_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmSetMoveOut_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmSetMoveOut_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmSetMoveOut_Load(object sender, EventArgs e)
        {
            headerTpi();
            //fillTpi();

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
                                                     "BedStatus = 'Under Contract' and MoveOutDate = EndDate and " + cboCateg.Text + " like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
                            break;
                        case "RoomNo":
                            rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate from vweassignbed where " +
                                                     "BedStatus = 'Under Contract' and MoveOutDate = EndDate and Cast(" + cboCateg.Text + " as char) like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
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
                if (ChkBills(CID))
                {
                    string tName = lstTpi.SelectedItems[0].SubItems[1].Text;
                    MessageBox.Show("This process cannot proceed if " + tName + " has unsettled bills!","Settle Move Out",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Disable();
                    return;
                }

                txtTenant.Text = lstTpi.SelectedItems[0].SubItems[1].Text;
                txtRmNo.Text = lstTpi.SelectedItems[0].SubItems[2].Text;
                txtBed.Text = lstTpi.SelectedItems[0].SubItems[3].Text;
                txtStartDt.Text = lstTpi.SelectedItems[0].SubItems[4].Text;
                txtEndDt.Text = lstTpi.SelectedItems[0].SubItems[5].Text;
                
                Enable();
                txtAssisted.Focus();
            }
        }

        bool ChkBills(int cId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select Id from tbltenantbills where cId = " + cId + " and BillStat = 0 limit 1", out ra, (int)CommandTypeEnum.adCmdText);
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

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (txtAssisted.Text == "")
            {
                MessageBox.Show("Please fill all fields!","Settle",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DialogResult s = MessageBox.Show("Are you sure that all of your entries are correct?","Settle",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (s != DialogResult.Yes)
            {
                return;
            }

            Thread th = new Thread(() =>
            {
                Action act = new Action(insMoveOut);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void insMoveOut() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime MoveOut = dtMoveOut.Value;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblMoveOut(" + 
                                                CID + ",'" +
                                                txtAssisted.Text + "','" +
                                                MoveOut.ToString("yyyy-MM-dd HH:mm") + "')", out ra, (int)CommandTypeEnum.adCmdText);


                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Move Out cId: (" + CID.ToString() + ") saved.");

                    DateTime dtMo = dtMoveOut.Value;
                    UpdContStat ud = new UpdContStat();
                    if (ud.UpdMoveOut(CID, dtMo))
                    {
                        ud.ContStatus(CID, "Move Out");
                        MessageBox.Show(txtTenant.Text + " successfully move out!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
