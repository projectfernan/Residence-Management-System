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
    public partial class frmPaidBills : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        int CID,BID;
        string InvNo;
        public Recordset recset = new Recordset();

        string ExportType;

        public frmPaidBills()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPaidBills_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmPaidBills_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmPaidBills_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboBcateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmPaidBills_Load(object sender, EventArgs e)
        {
            headerTpi();
            headerInvoice();
        }

        void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 5;

            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Start Date", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("End Date", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Monthly Fee", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Contract Status", w, HorizontalAlignment.Left);
        }

        void headerInvoice()
        {
            lstPaidBills.Clear();
            int w = lstPaidBills.Width / 8;

            lstPaidBills.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Date Given", w, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Invoice No", w, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Item", w, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Amount", w, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Payment Type", w, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Check No", w, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Bank", w, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Check Date", w, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPaidBills.Columns.Add("Remarks", w, HorizontalAlignment.Left);
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

                    rs = conn.MySql.Execute("select cId,Name,StartDate,EndDate,MonthlyFee,ContractStatus from vweprintinvoice group by cId order by Name", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            MakeMoney p = new MakeMoney();
                            string mf = p.Currency(Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString()));
                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["cId"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(mf);
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
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

        void getfillTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select cId,Name,StartDate,EndDate,MonthlyFee,ContractStatus from " + 
                                            "vweprintinvoice where cId = " + CID + " group by cId order by Name", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            MakeMoney p = new MakeMoney();
                            string mf = p.Currency(Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString()));
                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["cId"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(mf);
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
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

                    rs = conn.MySql.Execute("select cId,Name,StartDate,EndDate,ContractType,MonthlyFee,ContractStatus from vweprintinvoice where " +
                                            cboCateg.Text + " like '%" + txtKeycode.Text + "%' group by cId order by Name", out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            MakeMoney p = new MakeMoney();
                            string mf = p.Currency(Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString()));
                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["cId"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(mf);
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
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

        void fillInvoices()
        {
            try
            {
                ExportType = "Tenant";

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    recset = new Recordset();
                    object rc;

                    recset = conn.MySql.Execute("select * from vweprintinvoice where cId = " + CID, out rc, (int)CommandTypeEnum.adCmdText);

                    if (recset.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= recset.RecordCount; lup++)
                        {
                            lstPaidBills.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            MakeMoney p = new MakeMoney();
                            string tAmt = p.Currency(Convert.ToDecimal(recset.Fields["Amount"].Value.ToString()));
                            DateTime DtGiven = Convert.ToDateTime(recset.Fields["DateGiven"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstPaidBills.Items.Add(recset.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(DtGiven.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(recset.Fields["InvoiceNo"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["Item"].Value.ToString());
                            viewlst.SubItems.Add(tAmt);
                            viewlst.SubItems.Add(recset.Fields["PaymentType"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["CheckNo"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["Bank"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["CheckDate"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["cId"].Value.ToString());
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

        void findInvoices()
        {
            try
            {
                ExportType = "All";

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    recset = new Recordset();
                    object rc;

                    DateTime FromDt = dtFrom.Value;
                    DateTime ToDt = dtTo.Value;

                    recset = conn.MySql.Execute("select * from vweprintinvoice where DateGiven >= '" + FromDt.ToString("yyyy-MM-dd") + "' and DateGiven <= '" + ToDt.ToString("yyyy-MM-dd") + "' and " + 
                                                cboBcateg.Text + " like '%" + txtBKeyCode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);

                    if (recset.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= recset.RecordCount; lup++)
                        {
                            lstPaidBills.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            MakeMoney p = new MakeMoney();
                            string tAmt = p.Currency(Convert.ToDecimal(recset.Fields["Amount"].Value.ToString()));
                            DateTime DtGiven = Convert.ToDateTime(recset.Fields["DateGiven"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstPaidBills.Items.Add(recset.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(DtGiven.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(recset.Fields["InvoiceNo"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["Item"].Value.ToString());
                            viewlst.SubItems.Add(tAmt);
                            viewlst.SubItems.Add(recset.Fields["PaymentType"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["CheckNo"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["Bank"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["CheckDate"].Value.ToString());
                            viewlst.SubItems.Add(recset.Fields["cId"].Value.ToString());
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

        void tenantBillsPrint()
        {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtPringInvoices.rpt";

                Application.UseWaitCursor = true;
                CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                AR.Load(Rpath);
                AR.SetDataSource(recset);

                frmRepViewer shw = new frmRepViewer();
                shw.crViewer.ReportSource = AR;
                shw.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstTpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count > 0)
            {
                CID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                headerInvoice();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(fillInvoices);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        private void btnBref_Click(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count > 0)
            {
                CID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                headerInvoice();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(fillInvoices);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        private void btnBfind_Click(object sender, EventArgs e)
        {
            headerInvoice();
            Thread th = new Thread(() =>
            {
                Action act = new Action(findInvoices);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void txtBKeyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnBfind_Click(sender, e);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count > 0)
            {
                Thread th = new Thread(() =>
                {
                    Action act = new Action(tenantInvoicePrint);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        void tenantInvoicePrint()
        {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtPrintInvoices.rpt";

                WaitMouse wc = new WaitMouse();
                wc.WaitCurTrue();

                CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                AR.Load(Rpath);
                AR.SetDataSource(recset);

                frmRepViewer shw = new frmRepViewer();
                shw.crViewer.ReportSource = AR;

                string cId = lstTpi.SelectedItems[0].SubItems[0].Text;
                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Paid Bills cId: (" + cId + ") printed.");

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

        private void btnRefund_Click(object sender, EventArgs e)
        {
            DialogResult ys = MessageBox.Show("Are you sure do you want to refund this paid bill?","Refund",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if (ys == DialogResult.Yes) 
            {
                Thread th = new Thread(() =>
                {
                    Action act = new Action(MoneyRefund);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        void MoneyRefund() 
        {
            try 
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("update tblsettled set Remarks = 'Refunded' where Id = " + BID,out ra,(int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Invoice No: (" + InvNo + ") is refunded.");

                    MessageBox.Show("Paid bill successfully refunded!","Refund",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstPaidBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstPaidBills.SelectedItems.Count > 0)
            {
                InvNo = lstPaidBills.SelectedItems[0].SubItems[2].Text;
                BID = Convert.ToInt32(lstPaidBills.SelectedItems[0].SubItems[0].Text);
                CID = Convert.ToInt32(lstPaidBills.SelectedItems[0].SubItems[9].Text);
                headerTpi();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(getfillTpi);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if(lstPaidBills.Items.Count == 0)
            {
                MessageBox.Show("No record to be exported!","Export",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            switch(ExportType)
            {
                case "All":
                    Thread th = new Thread(() =>
                    {
                        Action act = new Action(exportExcelAll);
                        this.BeginInvoke(act);
                    });
                    th.Start();
                    break;
                case "Tenant":
                    Thread th2 = new Thread(() =>
                    {
                        Action act = new Action(exportExcelTenant);
                        this.BeginInvoke(act);
                    });
                    th2.Start();
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

                        rs = conn.MySql.Execute("select * from vweprintinvoice where DateGiven >= '" + FrmDt.ToString("yyyy-MM-dd") + "' and DateGiven <= '" + ToDt.ToString("yyyy-MM-dd") + "' and " +
                                                cboBcateg.Text + " like '" + txtBKeyCode.Text + "%'", out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {
                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, 1] = "DateGiven";
                            ws.Cells[1, 2] = "Name";
                            ws.Cells[1, 3] = "ContractName";
                            ws.Cells[1, 4] = "ContractType";
                            ws.Cells[1, 5] = "MonthlyFee";
                            ws.Cells[1, 6] = "StartDate";
                            ws.Cells[1, 7] = "EndDate";
                            ws.Cells[1, 8] = "InvoiceNo";
                            ws.Cells[1, 9] = "Item";
                            ws.Cells[1, 10] = "Amount";
                            ws.Cells[1, 11] = "PaymentType";
                            ws.Cells[1, 12] = "CheckNo";
                            ws.Cells[1, 13] = "Bank";
                            ws.Cells[1, 14] = "CheckDate";
                            ws.Cells[1, 15] = "Remarks";

                            int lup = 2;
                            int rc = rs.RecordCount + 1;
                            for (lup = 2; lup <= rc; lup++)
                            {
                                DateTime dtGiven = Convert.ToDateTime(rs.Fields["DateGiven"].Value.ToString());
                                DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                decimal mfAmt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                                decimal tAmt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                                MakeMoney p = new MakeMoney();
                                string mf = p.Currency(mfAmt);
                                string ta = p.Currency(tAmt);

                                ws.Cells[lup, 1] = dtGiven.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 2] = rs.Fields["Name"].Value.ToString();
                                ws.Cells[lup, 3] = rs.Fields["ContractName"].Value.ToString();
                                ws.Cells[lup, 4] = rs.Fields["ContractType"].Value.ToString();
                                ws.Cells[lup, 5] = mf;
                                ws.Cells[lup, 6] = dtStart.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 7] = dtEnd.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 8] = rs.Fields["InvoiceNo"].Value.ToString();
                                ws.Cells[lup, 9] = rs.Fields["Item"].Value.ToString();
                                ws.Cells[lup, 10] = ta;
                                ws.Cells[lup, 11] = rs.Fields["PaymentType"].Value.ToString();
                                ws.Cells[lup, 12] = rs.Fields["CheckNo"].Value.ToString();
                                ws.Cells[lup, 13] = rs.Fields["Bank"].Value.ToString();
                                ws.Cells[lup, 14] = rs.Fields["CheckDate"].Value.ToString();
                                ws.Cells[lup, 15] = rs.Fields["Remarks"].Value.ToString();

                                rs.MoveNext();
                            }

                            wb.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            app.Quit();

                            wc.WaitCurFalse();

                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Export Paid Bills to excel.");

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
                        DateTime FrmDt = dtFrom.Value;
                        DateTime ToDt = dtTo.Value;

                        rs = conn.MySql.Execute("select * from vweprintinvoice where cId = " + CID, out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {
                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, 1] = "DateGiven";
                            ws.Cells[1, 2] = "Name";
                            ws.Cells[1, 3] = "ContractName";
                            ws.Cells[1, 4] = "ContractType";
                            ws.Cells[1, 5] = "MonthlyFee";
                            ws.Cells[1, 6] = "StartDate";
                            ws.Cells[1, 7] = "EndDate";
                            ws.Cells[1, 8] = "InvoiceNo";
                            ws.Cells[1, 9] = "Item";
                            ws.Cells[1, 10] = "Amount";
                            ws.Cells[1, 11] = "PaymentType";
                            ws.Cells[1, 12] = "CheckNo";
                            ws.Cells[1, 13] = "Bank";
                            ws.Cells[1, 14] = "CheckDate";
                            ws.Cells[1, 15] = "Remarks";

                            int lup = 2;
                            int rc = rs.RecordCount + 1;
                            for (lup = 2; lup <= rc; lup++)
                            {
                                DateTime dtGiven = Convert.ToDateTime(rs.Fields["DateGiven"].Value.ToString());
                                DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                decimal mfAmt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                                decimal tAmt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                                MakeMoney p = new MakeMoney();
                                string mf = p.Currency(mfAmt);
                                string ta = p.Currency(tAmt);

                                ws.Cells[lup, 1] = dtGiven.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 2] = rs.Fields["Name"].Value.ToString();
                                ws.Cells[lup, 3] = rs.Fields["ContractName"].Value.ToString();
                                ws.Cells[lup, 4] = rs.Fields["ContractType"].Value.ToString();
                                ws.Cells[lup, 5] = mf;
                                ws.Cells[lup, 6] = dtStart.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 7] = dtEnd.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 8] = rs.Fields["InvoiceNo"].Value.ToString();
                                ws.Cells[lup, 9] = rs.Fields["Item"].Value.ToString();
                                ws.Cells[lup, 10] = ta;
                                ws.Cells[lup, 11] = rs.Fields["PaymentType"].Value.ToString();
                                ws.Cells[lup, 12] = rs.Fields["CheckNo"].Value.ToString();
                                ws.Cells[lup, 13] = rs.Fields["Bank"].Value.ToString();
                                ws.Cells[lup, 14] = rs.Fields["CheckDate"].Value.ToString();
                                ws.Cells[lup, 15] = rs.Fields["Remarks"].Value.ToString();

                                rs.MoveNext();
                            }

                            wb.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            app.Quit();

                            wc.WaitCurFalse();

                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Export Paid Bills to excel.");

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
    }
}
