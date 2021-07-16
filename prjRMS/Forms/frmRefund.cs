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
    public partial class frmRefund : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        int CIDb;
        decimal DepositsBal;
        decimal RefundAmt;
        Recordset recset = new Recordset();

        public frmRefund()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRefund_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmRefund_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmRefund_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmRefund_Load(object sender, EventArgs e)
        {
            headerTpi();
            Thread th = new Thread(() =>
            {
                Action act = new Action(fillTpi);
                this.BeginInvoke(act);
            });
            th.Start();

            headerBills();
        }

        void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 5;
            int wD = w / 2;
            int wB = wD / 2;
            int wN = w + w + w + wB;


            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", wN, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Room No", wD, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Bed", wB, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Start Date", wD, HorizontalAlignment.Left);
            lstTpi.Columns.Add("End Date", wD, HorizontalAlignment.Left);
            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
        }

        void headerBills()
        {
            lstBills.Clear();
            int w = lstBills.Width / 3;

            lstBills.Columns.Add("", 0, HorizontalAlignment.Left);
            lstBills.Columns.Add("Bill Name", w, HorizontalAlignment.Left);
            lstBills.Columns.Add("Remarks", w, HorizontalAlignment.Left);
            lstBills.Columns.Add("Amount", w, HorizontalAlignment.Left);
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

                    rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate,BedStatus from " +
                        "vweassignbed where BedStatus = 'Move Out' order by Name", out rc, (int)CommandTypeEnum.adCmdText);

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
                            viewlst.SubItems.Add(rs.Fields["BedStatus"].Value.ToString());
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
                            rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate,BedStatus from " +
                           "vweassignbed where Cast(" + cboCateg.Text + " as char) like '%" + txtKeycode.Text + "%' order by Name", out rc, (int)CommandTypeEnum.adCmdText);
                            break;
                        default:
                            rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate,BedStatus from " +
                           "vweassignbed where " + cboCateg.Text + " like '%" + txtKeycode.Text + "%' order by Name", out rc, (int)CommandTypeEnum.adCmdText);
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
                            viewlst.SubItems.Add(rs.Fields["BedStatus"].Value.ToString());
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

        void addRefItem(string Item,string Amt) 
        {
            ListViewItem viewlst = new ListViewItem();
            viewlst = lstBills.Items.Add(Item);
            viewlst.SubItems.Add(Amt);
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
                Action act = new Action(findTpi);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void lstTpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count > 0) 
            {
                CIDb = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);

                headerBills();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(GetItems);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        void GetItems() 
        {
            try 
            {
                DBconn conn = new DBconn();
                recset = new Recordset(); 
                object ra;

                MakeMoney p = new MakeMoney();
                decimal bAmt = 0;
                int stat = 0;

                lblTotalB.Text = "0.00";
                lblTotalDepo.Text = "0.00";
                lblTotalRef.Text = "0.00";

                DepositsBal = 0;
                RefundAmt = 0;

                if (conn.ServerConn())
                {
                    recset = conn.MySql.Execute("select Id,Name,ContractName,StartDate,EndDate,BillName,Remarks,Amount from vweprinttenantbills where " +
                                           "cId = " + CIDb + " and Remarks <> 'Late' and Remarks <> 'On Time'", out ra, (int)CommandTypeEnum.adCmdText);

                    if (recset.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= recset.RecordCount; lup++)
                        {
                            lstBills.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            string mf = p.Currency(Convert.ToDecimal(recset.Fields["Amount"].Value.ToString()));

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstBills.Items.Add(recset.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(recset.Fields["BillName"].Value.ToString());
                            switch (recset.Fields["Remarks"].Value.ToString())
                            {
                                case "Unsettled":
                                    viewlst.SubItems.Add("Unsettled");
                                    stat = stat + 1;
                                    break;
                                default:
                                    viewlst.SubItems.Add("Settled");
                                    break;
                            }
                            viewlst.SubItems.Add(mf);

                            bAmt = bAmt + Convert.ToDecimal(recset.Fields["Amount"].Value.ToString());

                            recset.MoveNext();
                        }

                        DepositsBal = DepoBal(CIDb);
                        RefundAmt = LessDepoBal(CIDb);

                        lblTotalB.Text = p.Currency(bAmt);
                        lblTotalDepo.Text = p.Currency(DepositsBal);

                        if (stat == 0)
                        {
                            lblTotalRef.Text = p.Currency(RefundAmt);
                        }
                        else
                        {
                            lblTotalRef.Text = "0.00";
                        }
                    }
                    else 
                    {
                        DepositsBal = DepoBal(CIDb);
                        lblTotalDepo.Text = p.Currency(DepositsBal);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        decimal DepoBal(int cid)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getBalDepo(" + cid + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return Convert.ToDecimal(rs.Fields["TotalDepo"].Value.ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        decimal LessDepoBal(int cid)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getLessDepo(" + cid + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return Convert.ToDecimal(rs.Fields["LessDepo"].Value.ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems[0].SubItems[6].Text != "Move Out")
            {
                MessageBox.Show("This process cannot proceed if the tenant is not yet move out!", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblTotalRef.Text == "0.00")
            {
                MessageBox.Show("There is no refundable amount to be printed!", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Thread th = new Thread(() =>
            {
                Action act = new Action(RefundPrint);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void RefundPrint()
        {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtRefundRep.rpt";

                WaitMouse wc = new WaitMouse();
                wc.WaitCurTrue();

                CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                AR.Load(Rpath);
                AR.SetDataSource(recset);
                AR.SetParameterValue("DepoBal", DepositsBal);
                AR.SetParameterValue("RefundAmt", RefundAmt);

                frmRepViewer shw = new frmRepViewer();
                shw.crViewer.ReportSource = AR;

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Deposits Refund cId: (" + CIDb + ") printed.");

                wc.WaitCurFalse();

                shw.ShowDialog();
            }
            catch (Exception ex)
            {
                WaitMouse wc = new WaitMouse();
                wc.WaitCurFalse();

                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a record that you want to refund in tenant's list for refund!","Refund",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (lstTpi.SelectedItems[0].SubItems[6].Text != "Move Out") 
            {
                MessageBox.Show("This process cannot proceed if the tenant is not yet move out!","Refund",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            Thread th = new Thread(() =>
            {
                Action act = new Action(Refund);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void Refund() 
        {
            if (lblTotalRef.Text == "0.00")
            {
                MessageBox.Show("There is no refundable amount!","Refund",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DialogResult ys = MessageBox.Show("Are you sure do you want to refund it now?","Refund",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if(ys != DialogResult.Yes)
            {
                return;
            }

            UpdContStat us = new UpdContStat();
            us.ContStatus(CIDb, "Refunded");

            MessageBox.Show("Refunded successfully!", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPayments shw = new frmPayments();
            shw.ShowDialog();
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
