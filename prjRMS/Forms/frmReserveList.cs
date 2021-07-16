using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading;

namespace prjRMS
{
    public partial class frmReserveList : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        DateTime InDt;
        DateTime OutDt;
        int ContID;

        public int RmNo;
        public string Bed;
        public bool vAssign, vHold;

        public frmReserveList()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReserveList_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmReserveList_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmReserveList_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        public void headerResList()
        {
            lstResList.Clear();
            int w = lstResList.Width / 5;

            lstResList.Columns.Add("", 0, HorizontalAlignment.Left);
            lstResList.Columns.Add("", 0, HorizontalAlignment.Left);
            lstResList.Columns.Add("Request Date", 150, HorizontalAlignment.Left);
            lstResList.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("ContractName", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("ContractStatus", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Remarks", w, HorizontalAlignment.Left);
        }

        public void FillReserve()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("call slctReservationList('Name','');", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);

                            DateTime RecDt = Convert.ToDateTime(rs.Fields["RecDate"].Value.ToString());

                            viewlst = lstResList.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(RecDt.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Remarks"].Value.ToString());

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

        void FindReserve()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from vwereservation where " + cboCateg.Text + " like '" + txtKeycode.Text + "%' order by RecDate", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);

                            DateTime RecDt = Convert.ToDateTime(rs.Fields["RecDate"].Value.ToString());

                            viewlst = lstResList.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(RecDt.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());

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

        public void FindFillReserve()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("call slctReservationList('" + cboCateg.Text + "','" + txtKeycode.Text + "');", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            DateTime RecDt = Convert.ToDateTime(rs.Fields["RecDate"].Value.ToString());

                            viewlst = lstResList.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(RecDt.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Remarks"].Value.ToString());

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

        private void frmReserveList_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);

            btnAssign.Visible = vAssign;
            SepAss.Visible = vAssign;
            btnHold.Visible = vHold;
            SepHol.Visible = vHold;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(BedAssign);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void BedAssign() 
        {
            try
            {
                if (lstResList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a record you want to assign to bed" + Bed + "!", "Assign", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ContID = Convert.ToInt32(lstResList.SelectedItems[0].SubItems[1].Text);
                string Tname = lstResList.SelectedItems[0].SubItems[3].Text;

                DialogResult ins = MessageBox.Show("Are you sure do you want to assign " + Tname + " to bed " + Bed + "?", "Assign", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ins == DialogResult.Yes)
                {
                    insReserved(ContID, RmNo, Bed);
                    insBedHistory();
                    DelReservation(ContID);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Rm No: (" + RmNo.ToString() + ") Bed: (" + Bed + ") assign to (" + Tname + ")");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void insReserved(int cId,int Rm,string Kama) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Object ra;

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("call insTblReserved(" +
                                            cId + "," +
                                            Rm + ",'" +
                                            Kama + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    string Tname = lstResList.SelectedItems[0].SubItems[3].Text;
                    MessageBox.Show(Tname +" is successfully assigned to bed " + Bed + "!","Assign",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool getMoveInOut() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select MoveInDate,MoveOutDate from tbltenantcontract where Id = " + ContID, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        InDt = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                        OutDt = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());
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

        void insBedHistory() 
        {
            try
            {
                DBconn conn = new DBconn();
                if (getMoveInOut() == false) 
                {
                    return;
                }

                string QueryBedHistory = "call insBedHistory(" +
                                            ContID + "," +
                                            RmNo + ",'" +
                                            Bed + "','" +
                                            InDt.ToString("yyyy-MM-dd") + "','" +
                                            OutDt.ToString("yyyy-MM-dd") + "')";

                conn.rsCUD(QueryBedHistory);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DelReservation(int cId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("delete from tblreservation where cId = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
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
            headerResList();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillReserve);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            headerResList();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FindFillReserve);
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

    }
}
