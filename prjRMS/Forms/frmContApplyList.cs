using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace prjRMS
{
    public partial class frmContApplyList : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int RmNo;
        public string Bed;

        int ContID;
        DateTime InDt;
        DateTime OutDt;

        public frmContApplyList()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContApplyList_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmContApplyList_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmContApplyList_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmContApplyList_Load(object sender, EventArgs e)
        {
            headerTpi();
            fillTpi();
        }

        public void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 4;

            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("ContractName", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("ContractType", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("ContractStatus", w, HorizontalAlignment.Left);
        }

        public void fillTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from vwepaymentname where ContractStatus = 'Applying' order by Name", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
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

        public void findTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from vwepaymentname where ContractStatus = 'Applying' and " + cboCateg.Text + " like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
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

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                headerTpi();
                findTpi();
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

        private void btnHold_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(AssignHold);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void AssignHold() 
        {
            if (lstTpi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a record you want to hold to bed" + Bed + "!", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ContID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
            string Tname = lstTpi.SelectedItems[0].SubItems[1].Text;

            DialogResult ins = MessageBox.Show("Are you sure do you want to hold bed " + Bed + " to " + Tname + "?", "Hold", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ins == DialogResult.Yes)
            {
                insReserved(ContID, RmNo, Bed);
                insBedHistory();
                UpdContStat upd = new UpdContStat();
                upd.ContStatus(ContID, "Hold");

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Rm No: (" + RmNo.ToString() + ") Bed: (" + Bed + ") hold to (" + Tname + ")");
            }
        }

        void insReserved(int cId, int Rm, string Kama)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblReserved(" +
                                            cId + "," +
                                            Rm + ",'" +
                                            Kama + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    string Tname = lstTpi.SelectedItems[0].SubItems[1].Text;
                    MessageBox.Show("Bed " + Bed + " is successfully hold " + Tname + "!", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
