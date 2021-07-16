using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Threading;

namespace prjRMS
{
    public partial class frmStatistics : Form
    {
        public string contStat;

        public frmStatistics()
        {
            InitializeComponent();
            
        }

        private void btnSearchRm_Click(object sender, EventArgs e)
        {
            HeaderPDC();

            Thread th = new Thread(() =>
            {
                Action act = new Action(LoadRoooms);
                this.BeginInvoke(act);
            });
            th.Start();   
        }

        void HeaderPDC()
        {
            Application.UseWaitCursor = true;
            lstStat.Clear();

            DateTime frmDt = dtFrom.Value;
            DateTime fromDte = Convert.ToDateTime(frmDt.ToString("MMM yyyy"));
            DateTime toDt = dtTo.Value;
            DateTime toDte = Convert.ToDateTime(toDt.ToString("MMM yyyy"));

            if (fromDte < toDte)
            {
                lstStat.Columns.Add("Room No", 80, HorizontalAlignment.Left);
                lstStat.Columns.Add("Bed", 40, HorizontalAlignment.Left);
                lstStat.Columns.Add("Tenant", 150, HorizontalAlignment.Left);

                while (fromDte <= toDte)
                {
                    string hn = fromDte.ToString("MMM yyyy");

                    lstStat.Columns.Add(hn, 90, HorizontalAlignment.Left);

                    fromDte = fromDte.AddMonths(1);
                }
            }
            else 
            {
                MessageBox.Show("Date To: must be greater than Date From: !","Search",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public void 
            LoadRoooms()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;
                DateTime toDte = dtTo.Value;
                DateTime frmDte = dtFrom.Value;
                int lup = 0;
                int itm = 0;

                if (conn.ServerConn())
                {

                    rs = conn.MySql.Execute("call slctvwestat('" + cboFloor.Text + "','" + frmDte.ToString("yyyy-MM-dd") + "','" + toDte.ToString("yyyy-MM-dd") + "')", out ra, (int)CommandTypeEnum.adCmdText);
            
                    while (rs.EOF == false)
                    {
                        ListViewItem viewlst = new ListViewItem();

                        viewlst = lstStat.Items.Add(rs.Fields["RoomNo"].Value.ToString());
                        viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                        viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());

                        string BedStat = rs.Fields["BedStatus"].Value.ToString();

                        lup = 3;
                        
                        foreach (ColumnHeader header in lstStat.Columns)
                        {
                            if (header.Text != "Room No" && header.Text != "Bed" && header.Text != "Tenant") 
                            {
                                frmDte = Convert.ToDateTime(header.Text);
                                DateTime strDte = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime startDte = Convert.ToDateTime(strDte.ToString("MMM yyyy"));

                                DateTime enDte = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                DateTime EndDte = Convert.ToDateTime(enDte.ToString("MMM yyyy"));

                                if (frmDte >= startDte)
                                {
                                    if (frmDte == EndDte)
                                    {
                                        viewlst.SubItems.Add(enDte.ToString("yyyy-MM-dd"));
                                        switch (BedStat)
                                        {
                                            case "Reserved":
                                                lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                lstStat.Items[itm].SubItems[lup].BackColor = Color.Yellow;
                                                break;
                                            case "Hold":
                                                lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                lstStat.Items[itm].SubItems[lup].BackColor = Color.Pink;
                                                break;
                                            case "Under Contract":
                                                lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                lstStat.Items[itm].SubItems[lup].BackColor = Color.Red;
                                                lstStat.Items[itm].SubItems[lup].ForeColor = Color.White;
                                                break;
                                        }
                                        lup = lup + 1;
                                    }
                                    else
                                    {
                                        if (frmDte > EndDte)
                                        {
                                            viewlst.SubItems.Add("");
                                            //lstStat.Items[itm].UseItemStyleForSubItems = false;
                                            //lstStat.Items[itm].SubItems[lup].BackColor = Color.Green;
                                            lup = lup + 1;
                                        }
                                        else 
                                        {
                                            if (frmDte == startDte)
                                            {
                                                viewlst.SubItems.Add(strDte.ToString("yyyy-MM-dd"));
                                                switch(BedStat)
                                                {
                                                    case "Reserved":
                                                        lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                        lstStat.Items[itm].SubItems[lup].BackColor = Color.Yellow;
                                                        break;
                                                    case "Hold":
                                                        lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                        lstStat.Items[itm].SubItems[lup].BackColor = Color.Pink;
                                                        break;
                                                    case "Under Contract":
                                                        lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                        lstStat.Items[itm].SubItems[lup].BackColor = Color.Red;
                                                        lstStat.Items[itm].SubItems[lup].ForeColor = Color.White;
                                                        break;
                                                }
                                                lup = lup + 1;
                                            }
                                            else 
                                            {
                                                viewlst.SubItems.Add("");
                                                switch (BedStat)
                                                {
                                                    case "Reserved":
                                                         lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                         lstStat.Items[itm].SubItems[lup].BackColor = Color.Yellow;
                                                        break;
                                                    case "Hold":
                                                        lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                        lstStat.Items[itm].SubItems[lup].BackColor = Color.Pink;
                                                        break;
                                                    case "Under Contract":
                                                        lstStat.Items[itm].UseItemStyleForSubItems = false;
                                                        lstStat.Items[itm].SubItems[lup].BackColor = Color.Red;
                                                        break;
                                                }
                                                lup = lup + 1;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    viewlst.SubItems.Add("");
                                    //lstStat.Items[itm].UseItemStyleForSubItems = false;
                                    //lstStat.Items[itm].SubItems[lup].BackColor = Color.Green;
                                    lup = lup + 1;
                                }
                            }
                        }
                        itm = itm + 1;
                        rs.MoveNext();
                    }
                }
                Application.UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();

            //pd.PrintPage += new PrintPage(printing);
            pd.PrintPage += new PrintPageEventHandler(printing);
            pd.Print();
        }

        void printing(object sender, PrintPageEventArgs
 e)
        {
            Bitmap bitmap =
             new Bitmap(lstStat.Width, lstStat.Height);

            lstStat.DrawToBitmap(bitmap, lstStat.ClientRectangle);

            e.Graphics.DrawImage(bitmap, new
             Point(50, 50));
        }

        private void cboFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
                    DateTime toDte = dtTo.Value;
                    DateTime frmDte = dtFrom.Value;
                    int lup = 0;
                    int itm = 0;
                    int hd = 1;
                    int col = 2;

                    if (conn.ServerConn())
                    {
                        foreach (ColumnHeader header in lstStat.Columns)
                        {
                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, hd] = header.Text;
                            hd = hd + 1;
                        }

                        rs = conn.MySql.Execute("call slctvwestat('" + cboFloor.Text + "','" + frmDte.ToString("yyyy-MM-dd") + "','" + toDte.ToString("yyyy-MM-dd") + "')", out ra, (int)CommandTypeEnum.adCmdText);

                        while (rs.EOF == false)
                        {
                            ws.Cells[col, 1] = rs.Fields["RoomNo"].Value.ToString();
                            ws.Cells[col, 2] = rs.Fields["Bed"].Value.ToString();
                            ws.Cells[col, 3] = rs.Fields["Name"].Value.ToString();

                            string BedStat = rs.Fields["BedStatus"].Value.ToString();

                            lup = 4;

                            foreach (ColumnHeader header in lstStat.Columns)
                            {
                                if (header.Text != "Room No" && header.Text != "Bed" && header.Text != "Tenant")
                                {
                                    frmDte = Convert.ToDateTime(header.Text);
                                    DateTime strDte = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                    DateTime startDte = Convert.ToDateTime(strDte.ToString("MMM yyyy"));

                                    DateTime enDte = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                    DateTime EndDte = Convert.ToDateTime(enDte.ToString("MMM yyyy"));

                                    if (frmDte >= startDte)
                                    {
                                        if (frmDte == EndDte)
                                        {
                                            ws.Cells[col, lup] = enDte.ToString("yyyy-MM-dd");
                                            switch (BedStat)
                                            {
                                                case "Reserved":
                                                    ws.Cells[col, lup].Interior.Color = Color.Yellow;
                                                    break;
                                                case "Hold":
                                                    ws.Cells[col, lup].Interior.Color = Color.Pink;
                                                    break;
                                                case "Under Contract":
                                                    ws.Cells[col, lup].Interior.Color = Color.Red;
                                                    break;
                                            }
                                            lup = lup + 1;
                                        }
                                        else
                                        {
                                            if (frmDte > EndDte)
                                            {
                                                lup = lup + 1;
                                            }
                                            else
                                            {
                                                if (frmDte == startDte)
                                                {
                                                    ws.Cells[col, lup] = strDte.ToString("yyyy-MM-dd");
                                                    switch (BedStat)
                                                    {
                                                        case "Reserved":
                                                            ws.Cells[col, lup].Interior.Color = Color.Yellow;
                                                            break;
                                                        case "Hold":
                                                            ws.Cells[col, lup].Interior.Color = Color.Pink;
                                                            break;
                                                        case "Under Contract":
                                                            ws.Cells[col, lup].Interior.Color = Color.Red;
                                                            break;
                                                    }
                                                    lup = lup + 1;
                                                }
                                                else
                                                {
                                                    switch (BedStat)
                                                    {
                                                        case "Reserved":
                                                            ws.Cells[col, lup].Interior.Color = Color.Yellow;
                                                            break;
                                                        case "Hold":
                                                            ws.Cells[col, lup].Interior.Color = Color.Pink;
                                                            break;
                                                        case "Under Contract":
                                                            ws.Cells[col, lup].Interior.Color = Color.Red;
                                                            break;
                                                    }
                                                    lup = lup + 1;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lup = lup + 1;
                                    }
                                }
                            }
                            itm = itm + 1;
                            col = col + 1;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (lstStat.Items.Count == 0) 
            {
                MessageBox.Show("No record to be exported!","Export",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            Thread th = new Thread(() =>
            {
                Action act = new Action(exportExcelTenant);
                this.BeginInvoke(act);
            });
            th.Start();
        }
    }
}
