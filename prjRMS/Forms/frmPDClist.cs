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
    public partial class frmPDClist : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        int CIDp; 

        string PrintType;

        public frmPDClist()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPDClist_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmPDClist_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmPDClist_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmPDClist_Load(object sender, EventArgs e)
        {
            headerTpi();
            HeaderPDC();

            DateTime now = DateTime.Now;
            dtPeriod.Value = now.AddDays(1 - now.Day);
        }

        void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 4;

            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Start Date", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("End Date", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Monthly Fee", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Contract Type", w, HorizontalAlignment.Left);
        }

        void HeaderPDC()
        {
            lstPDC.Clear();
            int w = lstPDC.Width / 6;

            lstPDC.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPDC.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Room No", w, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Invoice No", w, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Period", w, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Amount", w, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Check No", w, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Bank", w, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Check Date", w, HorizontalAlignment.Left);
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

                    rs = conn.MySql.Execute("select Id,Name,StartDate,EndDate,ContractType,MonthlyFee,ContractStatus from vwepaymentname", out rc, (int)CommandTypeEnum.adCmdText);

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
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
                            viewlst.SubItems.Add(mf);
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
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

                    rs = conn.MySql.Execute("select Id,Name,StartDate,EndDate,ContractType,MonthlyFee,ContractStatus from vwepaymentname where " +
                                            cboCateg.Text + " like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);

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
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
                            viewlst.SubItems.Add(mf);
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
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

        void GetFillPdc()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select Id,cId,RoomNo,InvoiceNo,Period,Amount,CheckNo,Bank,CheckDate from vwearprint where cId = " + CIDp + " order by Id", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstPDC.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            DateTime chkDt = Convert.ToDateTime(rs.Fields["CheckDate"].Value.ToString());
                            decimal Amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string a = p.Currency(Amt);

                            viewlst = lstPDC.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["InvoiceNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Period"].Value.ToString());
                            viewlst.SubItems.Add(a);
                            viewlst.SubItems.Add(rs.Fields["CheckNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bank"].Value.ToString());
                            viewlst.SubItems.Add(chkDt.ToString("yyyy-MM-dd"));
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

        void FindPdc()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    DateTime Per = dtPeriod.Value;

                    rs = conn.MySql.Execute("select Id,cId,RoomNo,InvoiceNo,Period,Amount,CheckNo,Bank,CheckDate from " + 
                                            "vwearprint where Period = '" + Per.ToString("MMMM yyyy") + "' " +  
                                            "order by RoomNo,Id", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstPDC.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            DateTime chkDt = Convert.ToDateTime(rs.Fields["CheckDate"].Value.ToString());
                            decimal Amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string a = p.Currency(Amt);

                            viewlst = lstPDC.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["InvoiceNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Period"].Value.ToString());
                            viewlst.SubItems.Add(a);
                            viewlst.SubItems.Add(rs.Fields["CheckNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bank"].Value.ToString());
                            viewlst.SubItems.Add(chkDt.ToString("yyyy-MM-dd"));
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

        private void lstTpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count > 0) 
            {
                CIDp = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                HeaderPDC();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(GetFillPdc);
                    this.BeginInvoke(act);
                });
                th.Start();

                this.PrintType = "Tenant";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            switch (PrintType) 
            {
                case "Period":
                    
                    Thread th = new Thread(() =>
                    {
                        Action act = new Action(pdcPerPrint);
                        this.BeginInvoke(act);
                    });
                    th.Start();

                    DateTime Per = dtPeriod.Value;

                    Audit aud1 = new Audit();
                    aud1.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "PDC Period: (" + Per.ToString("MMMM yyyy") + ") printed.");
                    break;
                case "Tenant":
                    Thread th2 = new Thread(() =>
                    {
                        Action act = new Action(pdcPrint);
                        this.BeginInvoke(act);
                    });
                    th2.Start();

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant PDC cId: (" + CIDp.ToString() + ") printed.");
                    break;
            }
        }

        void pdcPrint()
        {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtPrintAR.rpt";
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {

                    rs = conn.MySql.Execute("select * from vwearprint where cId = " + CIDp, out ra, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        AR.Load(Rpath);
                        AR.SetDataSource(rs);

                        frmRepViewer shw = new frmRepViewer();
                        shw.crViewer.ReportSource = AR;

                        wc.WaitCurFalse();

                        shw.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Failed to print!", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                WaitMouse wc = new WaitMouse();
                wc.WaitCurFalse();

                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void pdcPerPrint()
        {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtArPerPrint.rpt";
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    DateTime Per = dtPeriod.Value;
                    rs = conn.MySql.Execute("select Id,cId,RoomNo,InvoiceNo,Period,Amount,CheckNo,Bank,CheckDate " + 
                                            "from vwearprint where Period = '" + Per.ToString("MMMM yyyy") + "' and ContractStatus = 'Under Contract' " + 
                                            "order by RoomNo,Id", out ra, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        AR.Load(Rpath);
                        AR.SetDataSource(rs);

                        frmRepViewer shw = new frmRepViewer();
                        shw.crViewer.ReportSource = AR;

                        wc.WaitCurFalse();

                        shw.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Failed to print!", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                WaitMouse wc = new WaitMouse();
                wc.WaitCurFalse();

                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBfind_Click(object sender, EventArgs e)
        {
            HeaderPDC();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FindPdc);
                this.BeginInvoke(act);
            });
            th.Start();

            this.PrintType = "Period";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pdcEdit();
        }

        void pdcEdit()
        {
            try
            {
                if (lstPDC.SelectedItems.Count > 0)
                {
                    frmEditPDC shw = new frmEditPDC();
                    shw.ePeriod = Convert.ToDateTime(lstPDC.SelectedItems[0].SubItems[4].Text);
                    shw.eBank = lstPDC.SelectedItems[0].SubItems[7].Text;
                    shw.eCheckNo = lstPDC.SelectedItems[0].SubItems[6].Text;
                    shw.eAmt = Convert.ToDecimal(lstPDC.SelectedItems[0].SubItems[5].Text);
                    shw.eCheckDt = Convert.ToDateTime(lstPDC.SelectedItems[0].SubItems[8].Text);
                    shw.eInv = lstPDC.SelectedItems[0].SubItems[3].Text;
                    shw.PdcId = Convert.ToInt32(lstPDC.SelectedItems[0].SubItems[0].Text);
                    shw.ContId = Convert.ToInt32(lstPDC.SelectedItems[0].SubItems[1].Text);
                    shw.wLoad = "Edit";
                    shw.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select PDC record that you want to edit!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (lstPDC.Items.Count == 0)
            {
                MessageBox.Show("No record to be exported!","Export",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            switch (PrintType)
            {
                case "Period":

                    Thread th = new Thread(() =>
                    {
                        Action act = new Action(exportExcelAll);
                        this.BeginInvoke(act);
                    });
                    th.Start();

                    DateTime Per = dtPeriod.Value;

                    Audit aud1 = new Audit();
                    aud1.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "PDC Period: (" + Per.ToString("MMMM yyyy") + ") exported to excel.");
                    break;
                case "Tenant":
                    Thread th2 = new Thread(() =>
                    {
                        Action act = new Action(exportExcelTenant);
                        this.BeginInvoke(act);
                    });
                    th2.Start();

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant PDC cId: (" + CIDp.ToString() + ") exported to excel.");
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
                        DateTime PerDt = dtPeriod.Value;

                        rs = conn.MySql.Execute("call exportAllPDC('" + PerDt.ToString("MMMM yyyy") + "');", out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {
                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, 1] = "Name";
                            ws.Cells[1, 2] = "StartDate";
                            ws.Cells[1, 3] = "EndDate";
                            ws.Cells[1, 4] = "ContractType";
                            ws.Cells[1, 5] = "MonthlyFee";
                            ws.Cells[1, 6] = "RoomNo";
                            ws.Cells[1, 7] = "InvoiceNo";
                            ws.Cells[1, 8] = "Period";
                            ws.Cells[1, 9] = "CheckNo";
                            ws.Cells[1, 10] = "Amount";
                            ws.Cells[1, 11] = "Bank";
                            ws.Cells[1, 12] = "CheckDate";

                            int lup = 2;
                            int rc = rs.RecordCount + 1;
                            for (lup = 2; lup <= rc; lup++)
                            {
                                DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                DateTime dtCheck = Convert.ToDateTime(rs.Fields["CheckDate"].Value.ToString());
                                decimal mfAmt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                                decimal Amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());

                                MakeMoney p = new MakeMoney();
                                string mf = p.Currency(mfAmt);
                                string a = p.Currency(Amt);

                                ws.Cells[lup, 1] = rs.Fields["Name"].Value.ToString();
                                ws.Cells[lup, 2] = dtStart;
                                ws.Cells[lup, 3] = dtEnd;
                                ws.Cells[lup, 4] = rs.Fields["ContractType"].Value.ToString();
                                ws.Cells[lup, 5] = mf;
                                ws.Cells[lup, 6] = rs.Fields["RoomNo"].Value.ToString();
                                ws.Cells[lup, 7] = rs.Fields["InvoiceNo"].Value.ToString();
                                ws.Cells[lup, 8] = rs.Fields["Period"].Value.ToString();
                                ws.Cells[lup, 9] = rs.Fields["CheckNo"].Value.ToString();
                                ws.Cells[lup, 10] = a;
                                ws.Cells[lup, 11] = rs.Fields["Bank"].Value.ToString();
                                ws.Cells[lup, 12] = dtCheck.ToString("yyyy-MM-dd");

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
                        rs = conn.MySql.Execute("call exportTenantPDC(" + CIDp + ");", out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {
                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, 1] = "Name";
                            ws.Cells[1, 2] = "StartDate";
                            ws.Cells[1, 3] = "EndDate";
                            ws.Cells[1, 4] = "ContractType";
                            ws.Cells[1, 5] = "MonthlyFee";
                            ws.Cells[1, 6] = "RoomNo";
                            ws.Cells[1, 7] = "InvoiceNo";
                            ws.Cells[1, 8] = "Period";
                            ws.Cells[1, 9] = "CheckNo";
                            ws.Cells[1, 10] = "Amount";
                            ws.Cells[1, 11] = "Bank";
                            ws.Cells[1, 12] = "CheckDate";

                            int lup = 2;
                            int rc = rs.RecordCount + 1;
                            for (lup = 2; lup <= rc; lup++)
                            {
                                DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                DateTime dtCheck = Convert.ToDateTime(rs.Fields["CheckDate"].Value.ToString());
                                decimal mfAmt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                                decimal Amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());

                                MakeMoney p = new MakeMoney();
                                string mf = p.Currency(mfAmt);
                                string a = p.Currency(Amt);

                                ws.Cells[lup, 1] = rs.Fields["Name"].Value.ToString();
                                ws.Cells[lup, 2] = dtStart;
                                ws.Cells[lup, 3] = dtEnd;
                                ws.Cells[lup, 4] = rs.Fields["ContractType"].Value.ToString();
                                ws.Cells[lup, 5] = mf;
                                ws.Cells[lup, 6] = rs.Fields["RoomNo"].Value.ToString();
                                ws.Cells[lup, 7] = rs.Fields["InvoiceNo"].Value.ToString();
                                ws.Cells[lup, 8] = rs.Fields["Period"].Value.ToString();
                                ws.Cells[lup, 9] = rs.Fields["CheckNo"].Value.ToString();
                                ws.Cells[lup, 10] = a;
                                ws.Cells[lup, 11] = rs.Fields["Bank"].Value.ToString();
                                ws.Cells[lup, 12] = dtCheck.ToString("yyyy-MM-dd");

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

        private void btnAddPDC_Click(object sender, EventArgs e)
        {
            if(lstTpi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select tenant record that you want to add new PDC!","Add PDC",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;            
            }

            int cID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
            frmEditPDC shw = new frmEditPDC();
            shw.ContId = cID;
            shw.wLoad = "Add";
            shw.ShowDialog();
        }
    }
}
