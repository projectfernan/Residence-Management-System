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
    public partial class frmTenantBills : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        int CIDb,bId,RmNo;
        string Tname;

        string PrintCateg;

        public Recordset recset = new Recordset(); 

        public frmTenantBills()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTenantBills_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmTenantBills_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmTenantBills_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmTenantBills_Load(object sender, EventArgs e)
        {
            headerTpi();
            headerBills();
        }

        void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 5;
            int wD = w / 2;
            int wB = wD / 2;
            int wN = w + w + wB;


            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", wN, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Room No", wD, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Bed", wB, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Start Date", wD, HorizontalAlignment.Left);
            lstTpi.Columns.Add("End Date", wD, HorizontalAlignment.Left);
            lstTpi.Columns.Add("MoveIn Date", wD, HorizontalAlignment.Left);
            lstTpi.Columns.Add("MoveOut Date", wD, HorizontalAlignment.Left);
            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
        }

        void headerBills()
        {
            lstBills.Clear();
            int w = lstBills.Width / 6;

            lstBills.Columns.Add("", 0, HorizontalAlignment.Left);
            lstBills.Columns.Add("", 0, HorizontalAlignment.Left);
            lstBills.Columns.Add("Billing Date", w, HorizontalAlignment.Left);
            lstBills.Columns.Add("Due Date", w, HorizontalAlignment.Left);
            lstBills.Columns.Add("Bill Name", w, HorizontalAlignment.Left);
            lstBills.Columns.Add("Period",w, HorizontalAlignment.Left);
            lstBills.Columns.Add("Amount", w, HorizontalAlignment.Left);
            //lstBills.Columns.Add("Penalty", w, HorizontalAlignment.Left);
            //lstBills.Columns.Add("TotalAmt", w, HorizontalAlignment.Left);
            lstBills.Columns.Add("Remarks", w, HorizontalAlignment.Left);
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

                    rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate,MoveInDate,MoveOutDate,BedStatus from " +
                        "vweassignbed order by Name", out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                            DateTime MveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime MveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["cId"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(MveIn.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(MveOut.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["BedStatus"].Value.ToString());
                            rs.MoveNext();
                        }

                        wc.WaitCurFalse();
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

                    switch(cboCateg.Text)
                    {
                        case "RoomNo":
                            rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate,MoveInDate,MoveOutDate,BedStatus from " +
                           "vweassignbed where Cast(" + cboCateg.Text + " as char) like '%" + txtKeycode.Text + "%' order by Name", out rc, (int)CommandTypeEnum.adCmdText);
                            break;
                        default:
                            rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate,MoveInDate,MoveOutDate,BedStatus from " +
                           "vweassignbed where " + cboCateg.Text + " like '%" + txtKeycode.Text + "%' order by Name", out rc, (int)CommandTypeEnum.adCmdText);
                            break;
                    }

                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                            DateTime MveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime MveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["cId"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(MveIn.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(MveOut.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["BedStatus"].Value.ToString());
                            rs.MoveNext();
                        }

                        wc.WaitCurFalse();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getfillTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select cId,Name,RoomNo,Bed,StartDate,EndDate,MoveInDate,MoveOutDate,BedStatus from " +
                                            "vweassignbed where BedStatus <> 'Applying' and BedStatus <> 'Reserved' and " +
                                            "BedStatus <> 'Hold' and cId = " + CIDb, out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        RmNo = Convert.ToInt32(rs.Fields["RoomNo"].Value.ToString());
                        Tname = rs.Fields["Name"].Value.ToString();
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                            DateTime MoveInDt = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime MoveOutDt = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["cId"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(MoveInDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(MoveOutDt.ToString("yyyy-MM-dd"));
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

        void fillBills()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    recset = new Recordset();
                    object rc;

                    decimal Pena = Convert.ToDecimal(Properties.Settings.Default.RentPena);
                    DateTime NowDt = DateTime.Now;

                    recset = conn.MySql.Execute("call slctTenantBilling(" + CIDb + "," + Pena + ",'" + 
                                                NowDt.ToString("yyyy-MM-dd") + "')", out rc, (int)CommandTypeEnum.adCmdText);

                    if (recset.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= recset.RecordCount; lup++)
                        {
                            lstBills.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            MakeMoney p = new MakeMoney();
                            string mf = p.Currency(Convert.ToDecimal(recset.Fields["Amount"].Value.ToString()));
                            //string pa = p.Currency(Convert.ToDecimal(recset.Fields["Penalty"].Value.ToString()));
                            //string ta = p.Currency(Convert.ToDecimal(recset.Fields["TotalAmt"].Value.ToString()));
                            DateTime StartDt = Convert.ToDateTime(recset.Fields["BillingDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(recset.Fields["DueDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstBills.Items.Add(recset.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(recset.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(recset.Fields["BillName"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["Period"].Value.ToString());
                            viewlst.SubItems.Add(mf);
                            //viewlst.SubItems.Add(pa);
                            //viewlst.SubItems.Add(ta);
                            viewlst.SubItems.Add(recset.Fields["Remarks"].Value.ToString());
                            recset.MoveNext();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void findBills()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    recset = new Recordset();
                    object rc;

                    DateTime FrmDt = dtFrom.Value;
                    DateTime ToDt = dtTo.Value;

                    //if (cboMode.Text == "All")
                    //{
                    //    recset = conn.MySql.Execute("select * from vweprinttenantbills where BillingDate >= '" + FrmDt.ToString("yyyy-MM-dd") + "' and BillingDate <= '" +
                    //                       ToDt.ToString("yyyy-MM-dd") + "' and " + cboBcateg.Text + " like '" + txtBKeyCode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
                    //}
                    //else
                    //{
                    //    recset = conn.MySql.Execute("select * from vweprinttenantbills where BillingDate >= '" + FrmDt.ToString("yyyy-MM-dd") + "' and BillingDate <= '" +
                    //                       ToDt.ToString("yyyy-MM-dd") + "' and " + cboBcateg.Text + " like '" + txtBKeyCode.Text + "%' and Remarks = '" + cboMode.Text + "'", out rc, (int)CommandTypeEnum.adCmdText);
                    //}

                    decimal PenaPer = Convert.ToDecimal(Properties.Settings.Default.RentPena);
                    DateTime NowDt = DateTime.Now;

                    recset = conn.MySql.Execute("call slctAllTenantBilling('" + FrmDt.ToString("yyyy-MM-dd") + 
                        "','" + ToDt.ToString("yyyy-MM-dd") + "','" + cboBcateg.Text + "','" + txtBKeyCode.Text +
                        "','" + cboMode.Text + "'," + PenaPer + ",'" + NowDt.ToString("yyyy-MM-dd") + "')", out rc, (int)CommandTypeEnum.adCmdText);

                    if (recset.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= recset.RecordCount; lup++)
                        {
                            lstBills.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            MakeMoney p = new MakeMoney();
                            string mf = p.Currency(Convert.ToDecimal(recset.Fields["Amount"].Value.ToString()));
                            //string pa = p.Currency(Convert.ToDecimal(recset.Fields["Penalty"].Value.ToString()));
                            //string ta = p.Currency(Convert.ToDecimal(recset.Fields["TotalAmt"].Value.ToString()));
                            DateTime StartDt = Convert.ToDateTime(recset.Fields["BillingDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(recset.Fields["DueDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstBills.Items.Add(recset.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(recset.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(recset.Fields["BillName"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["Period"].Value.ToString());
                            viewlst.SubItems.Add(mf);
                            //viewlst.SubItems.Add(pa);
                            //viewlst.SubItems.Add(ta);
                            viewlst.SubItems.Add(recset.Fields["Remarks"].Value.ToString());
                            recset.MoveNext();
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
            headerTpi();
            Thread th = new Thread(() =>
            {
                Action act = new Action(fillTpi);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
                CIDb = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                headerBills();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(fillBills);
                    this.BeginInvoke(act);
                });
                th.Start();

                PrintCateg = "Tenant";
            }
        }

        private void cboMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnBfind_Click(object sender, EventArgs e)
        {
            headerBills();
            Thread th = new Thread(() =>
            {
                Action act = new Action(findBills);
                this.BeginInvoke(act);
            });
            th.Start();

            PrintCateg = "Bills";
        }

        private void txtBKeyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBfind_Click(sender, e);
            }
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            frmPayments shw = new frmPayments();
            shw.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            switch(PrintCateg)
            {
                case "Tenant":
                    if (lstTpi.SelectedItems.Count > 0)
                    {
                        Thread th = new Thread(() =>
                        {
                            Action act = new Action(tenantBillsPrint);
                            this.BeginInvoke(act);
                        });
                        th.Start();
                    }
                    break;
                default:
                    MessageBox.Show("Please select a tenant that you want to print!","Print",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    break;
                //case "Bills":
                //    Thread th2 = new Thread(() =>
                //    {
                //         Action act = new Action(BillsPrint);
                //         this.BeginInvoke(act);
                //    });
                //    th2.Start();
                //   break;
            }
        }

        void tenantBillsPrint()
        {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtTenantBills.rpt";

                WaitMouse wc = new WaitMouse();
                wc.WaitCurTrue();

                CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                AR.Load(Rpath);
                AR.SetDataSource(recset);

                frmRepViewer shw = new frmRepViewer();
                shw.crViewer.ReportSource = AR;

                string cID = lstTpi.SelectedItems[0].SubItems[0].Text;
                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Billing cId: (" + cID + ") printed.");

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

        void BillsPrint()
        {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtBills.rpt";

                Application.UseWaitCursor = true;
                CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                AR.Load(Rpath);
                AR.SetDataSource(recset);

                frmRepViewer shw = new frmRepViewer();
                shw.crViewer.ReportSource = AR;

                Audit audb = new Audit();
                audb.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Billings printed.");

                shw.ShowDialog();
            }
            catch (Exception ex)
            {
                Application.UseWaitCursor = false;
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddB_Click(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a record in tenant list!","Add Bills",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            frmAddBills shw = new frmAddBills();
            shw.CID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
            shw.ShowDialog();

        }

        private void cboMode_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lstBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBills.SelectedItems.Count > 0) 
            {
                CIDb = Convert.ToInt32(lstBills.SelectedItems[0].SubItems[1].Text);
                bId = Convert.ToInt32(lstBills.SelectedItems[0].SubItems[0].Text);
                headerTpi();
                Thread th2 = new Thread(() =>
                {
                    Action act = new Action(getfillTpi);
                    this.BeginInvoke(act);
                });
                th2.Start();
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (lstBills.SelectedItems.Count > 0)
            {
                frmBalTrans shw = new frmBalTrans();
                shw.bId = bId;
                shw.cId = CIDb;
                shw.RmNo = RmNo;
                shw.Bdate = lstBills.SelectedItems[0].SubItems[2].Text;
                shw.Amt = lstBills.SelectedItems[0].SubItems[6].Text;
                shw.BilName = lstBills.SelectedItems[0].SubItems[4].Text;
                shw.Tname = Tname;
                
                shw.ShowDialog();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            switch (PrintCateg)
            {
                case "Tenant":
                    if (lstTpi.SelectedItems.Count > 0)
                    {
                        Thread th = new Thread(() =>
                        {
                            Action act = new Action(exportExcelTenant);
                            this.BeginInvoke(act);
                        });
                        th.Start();
                    }
                    break;
                case "Bills":
                    Thread th2 = new Thread(() =>
                    {
                        Action act = new Action(exportExcelAll);
                        this.BeginInvoke(act);
                    });
                    th2.Start();
                    break;
                default:
                    MessageBox.Show("No record to be exported!","Export",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    break;
            }
        }

        void exportExcelAll()
        {
            try
            {
                var sfd = new SaveFileDialog();
                sfd.FileName = "";
                sfd.Filter = "Excel files (*.xlsx,*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    WaitMouse wc = new WaitMouse();
                    wc.WaitCurTrue();

                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook wb = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet ws = null;
                    ws = wb.Sheets["Sheet1"];
                    ws = wb.ActiveSheet;

                    DBconn conn = new DBconn();
                    Recordset rs = new Recordset();
                    object ra;

                    if (conn.ServerConn())
                    {
                        DateTime FrmDt = dtFrom.Value;
                        DateTime ToDt = dtTo.Value;

                        decimal PenaPer = Convert.ToDecimal(Properties.Settings.Default.RentPena);
                        DateTime NowDt = DateTime.Now;

                        rs = conn.MySql.Execute("call exportAllTenantBills('" + FrmDt.ToString("yyyy-MM-dd") + "','" +
                             ToDt.ToString("yyyy-MM-dd") + "','" + cboBcateg.Text + "','" + txtBKeyCode.Text + "','" +
                             cboMode.Text + "'," + PenaPer + ",'" + NowDt.ToString("yyyy-MM-dd") + "')", out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {
                            //cId,Name,RoomNo,Bed,StartDate,EndDate,MoveInDate,MoveOutDate,BedStatus
                            //Id,cId,BillName,Amount,BillingDate,DueDate,Remarks

                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, 1] = "BillingDate";
                            ws.Cells[1, 2] = "DueDate";
                            ws.Cells[1, 3] = "Name";
                            ws.Cells[1, 4] = "RoomNo";
                            ws.Cells[1, 5] = "Bed";
                            ws.Cells[1, 6] = "StartDate";
                            ws.Cells[1, 7] = "EndDate";
                            ws.Cells[1, 8] = "MoveInDate";
                            ws.Cells[1, 9] = "MoveOutDate";
                            ws.Cells[1, 10] = "ContractStatus";
                            ws.Cells[1, 11] = "BillName";
                            ws.Cells[1, 12] = "Period";
                            ws.Cells[1, 13] = "Amount";
                            //ws.Cells[1, 13] = "Penalty";
                            //ws.Cells[1, 14] = "TotalAmt";
                            ws.Cells[1, 14] = "Remarks";

                            int lup = 2;
                            int rc = rs.RecordCount + 1;
                            for (lup = 2; lup <= rc; lup++)
                            {
                                DateTime Bdate = Convert.ToDateTime(rs.Fields["BillingDate"].Value.ToString());
                                DateTime Due = Convert.ToDateTime(rs.Fields["DueDate"].Value.ToString());
                                DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                DateTime dtMveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                                DateTime dtMveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());
                                decimal Amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                                //decimal pAmt = Convert.ToDecimal(rs.Fields["Penalty"].Value.ToString());
                                //decimal tAmt = Convert.ToDecimal(rs.Fields["TotalAmt"].Value.ToString());
                                MakeMoney p = new MakeMoney();
                                string mf = p.Currency(Amt);
                                //string pa = p.Currency(pAmt);
                                //string ta = p.Currency(tAmt);

                                ws.Cells[lup, 1] = Bdate.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 2] = Due.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 3] = rs.Fields["Name"].Value.ToString();
                                ws.Cells[lup, 4] = rs.Fields["RoomNo"].Value.ToString();
                                ws.Cells[lup, 5] = rs.Fields["Bed"].Value.ToString();
                                ws.Cells[lup, 6] = dtStart.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 7] = dtEnd.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 8] = dtMveIn.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 9] = dtMveOut.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 10] = rs.Fields["ContractStatus"].Value.ToString();
                                ws.Cells[lup, 11] = rs.Fields["BillName"].Value.ToString();
                                ws.Cells[lup, 12] = rs.Fields["Period"].Value.ToString();
                                ws.Cells[lup, 13] = mf;
                                //ws.Cells[lup, 13] = pa;
                                //ws.Cells[lup, 14] = ta;
                                ws.Cells[lup, 14] = rs.Fields["Remarks"].Value.ToString();

                                rs.MoveNext();
                            }

                            wb.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            app.Quit();

                            wc.WaitCurFalse();

                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Export Tenant Billings to excel.");

                            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void exportExcelTenant()
        {
            try
            {
                var sfd = new SaveFileDialog();
                sfd.FileName = "";
                sfd.Filter = "Excel files (*.xlsx,*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    WaitMouse wc = new WaitMouse();
                    wc.WaitCurTrue();

                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook wb = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet ws = null;
                    ws = wb.Sheets["Sheet1"];
                    ws = wb.ActiveSheet;

                    DBconn conn = new DBconn();
                    Recordset rs = new Recordset();
                    object ra;

                    if (conn.ServerConn())
                    {
                        decimal PenaPer = Convert.ToDecimal(Properties.Settings.Default.RentPena);
                        DateTime NowDt = DateTime.Now;

                        rs = conn.MySql.Execute("call exportTenantBills(" + CIDb + "," + PenaPer + ",'" + 
                                                NowDt.ToString("yyyy-MM-dd") + "');", out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {
                            //cId,Name,RoomNo,Bed,StartDate,EndDate,MoveInDate,MoveOutDate,BedStatus
                            //Id,cId,BillName,Amount,BillingDate,DueDate,Remarks

                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, 1] = "BillingDate";
                            ws.Cells[1, 2] = "DueDate";
                            ws.Cells[1, 3] = "Name";
                            ws.Cells[1, 4] = "RoomNo";
                            ws.Cells[1, 5] = "Bed";
                            ws.Cells[1, 6] = "StartDate";
                            ws.Cells[1, 7] = "EndDate";
                            ws.Cells[1, 8] = "MoveInDate";
                            ws.Cells[1, 9] = "MoveOutDate";
                            ws.Cells[1, 10] = "ContractStatus";
                            ws.Cells[1, 11] = "BillName";
                            ws.Cells[1, 12] = "Period";
                            ws.Cells[1, 13] = "BillAmt";
                            //ws.Cells[1, 13] = "Penalty";
                            //ws.Cells[1, 14] = "TotalAmt";
                            ws.Cells[1, 14] = "Remarks";

                            int lup = 2;
                            int rc = rs.RecordCount + 1;
                            for (lup = 2; lup <= rc; lup++)
                            {
                                DateTime Bdate = Convert.ToDateTime(rs.Fields["BillingDate"].Value.ToString());
                                DateTime Due = Convert.ToDateTime(rs.Fields["DueDate"].Value.ToString());
                                DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                DateTime dtMveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                                DateTime dtMveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());
                                decimal Amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                                //decimal pAmt = Convert.ToDecimal(rs.Fields["Penalty"].Value.ToString());
                                //decimal tAmt = Convert.ToDecimal(rs.Fields["TotalAmt"].Value.ToString());
                                MakeMoney p = new MakeMoney();
                                string mf = p.Currency(Amt);
                                //string pa = p.Currency(pAmt);
                                //string ta = p.Currency(tAmt);

                                ws.Cells[lup, 1] = Bdate.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 2] = Due.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 3] = rs.Fields["Name"].Value.ToString();
                                ws.Cells[lup, 4] = rs.Fields["RoomNo"].Value.ToString();
                                ws.Cells[lup, 5] = rs.Fields["Bed"].Value.ToString();
                                ws.Cells[lup, 6] = dtStart.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 7] = dtEnd.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 8] = dtMveIn.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 9] = dtMveOut.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 10] = rs.Fields["ContractStatus"].Value.ToString();
                                ws.Cells[lup, 11] = rs.Fields["BillName"].Value.ToString();
                                ws.Cells[lup, 12] = rs.Fields["Period"].Value.ToString();
                                ws.Cells[lup, 13] = mf;
                                //ws.Cells[lup, 13] = pa;
                                //ws.Cells[lup, 14] = ta;
                                ws.Cells[lup, 14] = rs.Fields["Remarks"].Value.ToString();

                                rs.MoveNext();
                            }

                            wb.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            app.Quit();

                            wc.WaitCurFalse();

                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Export Tenant Billings to excel.");

                            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            
        }

        private void cmsBtnEdit_Click(object sender, EventArgs e)
        {
            try 
            {
                if(lstBills.SelectedItems.Count == 0)
                {
                    return;
                }

                frmAddBills shw = new frmAddBills();
                shw.bName = lstBills.SelectedItems[0].SubItems[4].Text;
                shw.bPer = Convert.ToDateTime(lstBills.SelectedItems[0].SubItems[5].Text);
                shw.bAmt = Convert.ToDecimal(lstBills.SelectedItems[0].SubItems[6].Text);
                shw.bBillDate = Convert.ToDateTime(lstBills.SelectedItems[0].SubItems[2].Text);
                shw.bDueDate =  Convert.ToDateTime(lstBills.SelectedItems[0].SubItems[3].Text);
                shw.wLoad = "Edit";
                shw.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
