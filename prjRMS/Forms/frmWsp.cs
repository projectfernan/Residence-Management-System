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
    public partial class frmWsp : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int cId;
        public string sAmt,Item,ContType;
        public int sFullPay, sFpCash,sFpOnline, sFpCheck;
        public int sPdc;
        public decimal tAmt;
        public decimal mRentAmt;
        DateTime ePerio;

        public delegate void frmPaymentEvnt();
        public event frmPaymentEvnt Refresh;

        public frmWsp()
        {
            InitializeComponent();
        }

        private void lbClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWsp_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmWsp_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmWsp_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmWsp_Load(object sender, EventArgs e)
        {
            FullPay();
            Pdc();

            DateTime now = DateTime.Now;
            dtPeriod.Value = now.AddDays(1 - now.Day);
        }

        void FullPay() {
            if (sFullPay == 0)
            {
                tabControlMain.TabPages.Remove(tabFullPay);
            }
            else
            {
                if (sFpCash == 0)
                {
                    tabFp.TabPages.Remove(tabFpCash);
                }
                else 
                {
                    txtAmtFpCash.Text = sAmt;
                    txtCashTender.Value = Convert.ToDecimal(sAmt);
                }

                if (sFpOnline == 0)
                {
                    tabFp.TabPages.Remove(tabOnline);
                }
                else 
                {
                    txtAmtFpOnline.Text = sAmt;
                    txtOnlineTender.Value = Convert.ToDecimal(sAmt);
                }

                if (sFpCheck == 0)
                {
                    tabFp.TabPages.Remove(tabFpCheck);
                }
                else 
                {
                    txtAmtFpCheck.Text = sAmt;
                    txtCheckAmt.Value = Convert.ToDecimal(sAmt);
                }
            }
        }

        void Pdc() 
        {
            if (sPdc == 0)
            {
                tabControlMain.TabPages.Remove(tabPdc);
            }
            else 
            {
                txtPdcAmt.Text = sAmt;
                HeaderPDC();
                GetFillPdc();
                MakeMoney cur = new MakeMoney();
                decimal pdcTA = pdcTotalAmt(cId);
                txtTotalPdc.Text = cur.Currency(pdcTA);
                txtAmt.Value = mRentAmt;
                if (Convert.ToDecimal(txtTotalPdc.Text) >= Convert.ToDecimal(txtPdcAmt.Text))
                {
                    txtTotalPdc.ForeColor = Color.Blue;
                    //btnAddPdc.Enabled = false;
                }
            }
        }

        void HeaderPDC()
        {
            lstPDC.Clear();
            int w = lstPDC.Width / 6;

            lstPDC.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPDC.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPDC.Columns.Add("PaymentType", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Invoice No", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Period", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Amount", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Check No", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Bank", w, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Date", 90, HorizontalAlignment.Left);
        }

        private void cboFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAddPdc_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(AddPdc);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void AddPdc() 
        {
            if (CheckFileds() == false)
            {
                MessageBox.Show("Please don't leave a blank!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTotalPdc.Text == txtPdcAmt.Text)
            {
                return;
            }

            DialogResult pdc = MessageBox.Show("Are you sure that your entries are correct?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pdc == DialogResult.Yes)
            {

                DateTime Period = dtPeriod.Value;

                if (chkPdcInput(cId, Period.ToString("MMMM yyyy"), dtPdcCheck.Value))
                {
                    MessageBox.Show("Duplicate input! Please check your inputs if already added!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime dtNow = DateTime.Now;
                DateTime M = dtPeriod.Value;
                string d = Properties.Settings.Default.billDay;
                string mfDue = M.ToString("yyyy") + "-" + M.ToString("MM") + "-" + d;
                int RentStat;
                string RentRema;

                //if (cboPtype.Text == "Cash")
                //{
                //    RentStat = 1;
                //    RentRema = "On Time";                }
                //else
                //{
                    RentStat = 0;
                    RentRema = "Unsettled";
                //}

                insPdc(RentStat);
                insTenantRent(cId, "Monthly Rent", mRentAmt, mfDue, RentStat, RentRema);
               
                HeaderPDC();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(GetFillPdc);
                    this.BeginInvoke(act);
                });
                th.Start();

                MakeMoney cur = new MakeMoney();
                txtTotalPdc.Text = cur.Currency(pdcTotalAmt(cId));

                if (Convert.ToDecimal(txtTotalPdc.Text) >= Convert.ToDecimal(txtPdcAmt.Text))
                {
                    txtTotalPdc.ForeColor = Color.Blue;
                }
            }
        }

        bool chkPdcInput(int contId,string Per,DateTime BillDt)
        {
            try 
            {
                  DBconn conn = new DBconn();
                  Recordset rs = new Recordset();
                  object ra;

                  if (conn.ServerConn())
                  {
                      rs = conn.MySql.Execute("call chkPdc('" + contId +
                                                          "','" + Per + 
                                                          "','" + BillDt.ToString("yyyy-MM-dd") + "')", out ra, (int)CommandTypeEnum.adCmdText);

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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void insTenantRent(int cId, string Biller, decimal Amt, string bDue,int Bstat,string Rema)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime Per = dtPeriod.Value;
                DateTime BilDt = dtPeriod.Value;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblTenantRent(" +
                                            cId + ",'" +
                                            Biller + "','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            Amt + ",'" +
                                            BilDt.ToString("yyyy-MM-dd") + "','" +
                                            bDue + "'," + Bstat + ",'" + Rema + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Billing: (" + Biller + ") added to cId: (" + cId.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool CheckFileds() {
            if (txtPdcBank.Text == "" || txtPdcCheckNo.Text == "" || txtAmt.Value == 0 || txtInvPdc.Text == "")
            {
                return false;
            }
            else {
                return true;
            }
        }

        void insPdc(int uStat)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime Per = dtPeriod.Value;
                DateTime PdcChek = dtPdcCheck.Value;

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("call insTblPdc(" + 
                                            cId + ",'" +
                                            txtInvPdc.Text + "','" +
                                            Per.ToString("MMMM yyyy") + "'," + 
                                            txtAmt.Value + ",'" +
                                            txtPdcCheckNo.Text + "','" +
                                            txtPdcBank.Text + "','" +
                                            PdcChek.ToString("yyyy-MM-dd") + "','" + cboPtype.Text + "'," + uStat + ");", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment PDC cId: (" + cId + ") Invoice: (" + txtInvPdc.Text + ") added.");
                }
            }
            catch (Exception ex) {
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

                    rs = conn.MySql.Execute("select * from tblpdc where cId = " + cId + " order by Id desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            DateTime CheckDt = Convert.ToDateTime(rs.Fields["CheckDate"].Value.ToString());

                            lstPDC.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstPDC.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["PaymentType"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["InvoiceNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Period"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Amount"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["CheckNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bank"].Value.ToString());
                            viewlst.SubItems.Add(CheckDt.ToString("yyyy-MM-dd"));
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

        decimal pdcTotalAmt(int cID) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getPdcTotal(" + cID + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return Convert.ToDecimal(rs.Fields["TotalPdc"].Value.ToString());
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void btnEditPdc_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(UpdatePDC);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void UpdatePDC() 
        {
            switch (btnEditPdc.Text)
            {
                case "Edit":
                    DialogResult EdtPdc = MessageBox.Show("Are you sure do you want to edit this PDC record?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (EdtPdc == DialogResult.Yes)
                    {
                        pdcEdit();
                    }
                    break;
                case "Update":
                    DialogResult UpdPdc = MessageBox.Show("Are you sure do you want to save changes?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (UpdPdc == DialogResult.Yes)
                    {
                        int PdcId = Convert.ToInt32(lstPDC.SelectedItems[0].SubItems[0].Text);
                        pdcUpdate(PdcId);
                    }
                    break;
            }
        }

        void pdcEdit() {
            try
            {
                if (lstPDC.SelectedItems.Count > 0)
                {
                    dtPeriod.Value = Convert.ToDateTime(lstPDC.SelectedItems[0].SubItems[4].Text);
                    ePerio = Convert.ToDateTime(lstPDC.SelectedItems[0].SubItems[4].Text);
                    txtPdcBank.Text = lstPDC.SelectedItems[0].SubItems[7].Text;
                    txtPdcCheckNo.Text = lstPDC.SelectedItems[0].SubItems[6].Text;
                    txtAmt.Value = Convert.ToDecimal(lstPDC.SelectedItems[0].SubItems[5].Text);
                    dtPdcCheck.Value = Convert.ToDateTime(lstPDC.SelectedItems[0].SubItems[8].Text);
                    txtInvPdc.Text = lstPDC.SelectedItems[0].SubItems[3].Text;
                    cboPtype.Text = lstPDC.SelectedItems[0].SubItems[2].Text;

                    btnEditPdc.Text = "Update";
                    btnAddPdc.Enabled = false;
                    btnSettlePdc.Enabled = false;
                    btnPrintPdc.Enabled = false;
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

        void pdcUpdate(int pdcID) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    DateTime Per = dtPeriod.Value;
                    DateTime Pdchek = dtPdcCheck.Value;

                    rs = conn.MySql.Execute("call updTblPdc(" +
                                            pdcID + ",'" +
                                            txtInvPdc.Text + "','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            txtAmt.Value + ",'" +
                                            txtPdcCheckNo.Text + "','" +
                                            txtPdcBank.Text + "','" +
                                            Pdchek.ToString("yyyy-MM-dd") + "');", out ra, (int)CommandTypeEnum.adCmdText);

                    updTenantRent(cId,"Monthly Rent", txtAmt.Value);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment PDC cId: (" + pdcID + ") Invoice: (" + txtInvPdc.Text + ") updated.");

                    MessageBox.Show("PDC record successfully updated!","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    
                    txtInvPdc.Text = "";
                    txtPdcCheckNo.Text = "";
                    txtPdcBank.Text = "";
                    dtPdcCheck.Value = DateTime.Now;

                    HeaderPDC();
                    GetFillPdc();

                    btnEditPdc.Text = "Edit";
                    btnAddPdc.Enabled = true;
                    btnSettlePdc.Enabled = true;
                    btnPrintPdc.Enabled = true;

                    MakeMoney cur = new MakeMoney();
                    txtTotalPdc.Text = cur.Currency(pdcTotalAmt(cId));

                    if (txtTotalPdc.Text == txtPdcAmt.Text)
                    {
                        txtTotalPdc.ForeColor = Color.Blue;
                        btnAddPdc.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void updTenantRent(int cId, string Biller, decimal Amt)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime Per = dtPeriod.Value;

                DateTime M = dtPeriod.Value;
                string d = Properties.Settings.Default.billDay;
                string mfDue = M.ToString("yyyy") + "-" + M.ToString("MM") + "-" + d;

                DateTime eM = ePerio;
                string eDueDt = eM.ToString("yyyy") + "-" + eM.ToString("MM") + "-" + d;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updTblTenantBills(" +
                                            cId + ",'" +
                                            Biller + "','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            Amt + ",'" +
                                            Per.ToString("yyyy-MM-dd") + "','" +
                                            mfDue + "','" +
                                            ePerio.ToString("yyyy-MM-dd") + "','" +
                                            eDueDt + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Billing: (" + Biller + ") updated for cId: (" + cId.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettlePdc_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(SettlePDC);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void SettlePDC() 
        {
            if (Convert.ToDecimal(txtTotalPdc.Text) >= Convert.ToDecimal(txtPdcAmt.Text))
            {
                MessageBox.Show("Whole stay payment is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdContStat upd = new UpdContStat();
                upd.UpdateStatus(cId, "WholeStayPaymentStat", 1);
                if (upd.checkContStat(cId))
                {
                    if (ContType != "New")
                    {
                        upd.UpdSecDep(cId);
                    }

                    upd.ContStatus(cId, "Under Contract");
                    if (ContType == "Renew" || ContType == "Adjustment")
                    {
                        RoomBed b = new RoomBed();
                        if (b.chekBed(cId) == false)
                        {
                            insReserve();
                        }

                        if (ContType == "Adjustment")
                        {
                            UpdPdcStat uPdc = new UpdPdcStat();
                            uPdc.TransferPDC(cId);
                        }
                    }

                    if (ContType == "Extension")
                    {
                        upd.UpdExtension(cId);
                    }
                }

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment PDC cId: (" + cId + ") completed.");

                if (Refresh != null)
                {
                    Refresh();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Settlement cannot proceed because the total PDC amount is not enough!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrintPdc_Click(object sender, EventArgs e)
        {
            decimal PdcTotal = Convert.ToDecimal(txtTotalPdc.Text);
            decimal PdcAmt = Convert.ToDecimal(txtPdcAmt.Text);
            if (PdcTotal >= PdcAmt)
            {
                Thread th = new Thread(() =>
                {
                    Action act = new Action(pdcPrint);
                    this.BeginInvoke(act);
                });
                th.Start();

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment PDC cId: (" + cId + ") printed.");
            }
            else
            {
                MessageBox.Show("PDC AR printing cannot proceed because the total PDC amount is not enough!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void pdcPrint() {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtPrintAR.rpt";
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {

                    rs = conn.MySql.Execute("select * from vwearprint where cId = " + cId,out ra,(int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        Application.UseWaitCursor = true;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        AR.Load(Rpath);
                        AR.SetDataSource(rs);

                        frmRepViewer shw = new frmRepViewer();
                        shw.crViewer.ReportSource = AR;
                        shw.ShowDialog();
                    }
                    else {
                        MessageBox.Show("This process needs to have an assigned room and bed!","Print",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFpCash_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(SettleFpCash);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void SettleFpCash() 
        {
            DialogResult cash = MessageBox.Show("Are you sure that your entries are correct?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cash == DialogResult.Yes)
            {
                if (txtInvFpCash.Text == "")
                {
                    MessageBox.Show("Please don't leave a blank!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvFpCash.Focus();
                    return;
                }

                if (txtCashTender.Value == 0)
                {
                    MessageBox.Show("You can't settle with 0 tendered amount!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime FpCashGiven = dtFpCashGiven.Value;

                if (chkInv(txtInvFpCash.Text) == true)
                {
                    MessageBox.Show("The invoice number is already used!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvFpCash.Text = "";
                    txtInvFpCash.Focus();
                    return;
                }

                decimal pAmt = Convert.ToDecimal(txtAmtFpCash.Text);

                if (pAmt > txtCashTender.Value)
                {
                    DialogResult par = MessageBox.Show("Your tendered amount is not enough! Are you sure do want to continue this settlement?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (par != DialogResult.Yes)
                    {
                        return;
                    }
                }

                insPayment(txtInvFpCash.Text, Item, txtCashTender.Value, "Cash", "None", "None", "None", FpCashGiven.ToString("yyyy-MM-dd"));

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + txtInvFpCash.Text + ")");

                if (pAmt > txtCashTender.Value)
                {
                    MessageBox.Show("The whole stay payment is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    this.Close();
                    return;
                }

                UpdContStat upd = new UpdContStat();
                upd.UpdateStatus(cId, "WholeStayPaymentStat", 1);
                if (upd.checkContStat(cId))
                {
                    if (ContType != "New")
                    {
                        upd.UpdSecDep(cId);
                    }

                    upd.ContStatus(cId, "Under Contract");
                    if (ContType == "Renew" || ContType == "Adjustment")
                    {
                        RoomBed b = new RoomBed();
                        if (b.chekBed(cId) == false)
                        {
                            insReserve();
                        }

                        if (ContType == "Adjustment")
                        {
                            UpdPdcStat uPdc = new UpdPdcStat();
                            uPdc.TransferPDC(cId);
                        }
                    }

                    if (ContType == "Extension")
                    {
                        upd.UpdExtension(cId);
                    }
                }

                MessageBox.Show("Whole stay payment is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Refresh != null)
                {
                    Refresh();
                }

                this.Close();
            }
        }

        bool chkInv(string Inv)
        {
            try
            {
                //DBconn conn = new DBconn();
                //Recordset rs = new Recordset();
                //object ra;

                //if (conn.ServerConn())
                //{
                //    rs = conn.MySql.Execute("select InvoiceNo from tblsettled where InvoiceNo = '" + Inv + "'", out ra, (int)CommandTypeEnum.adCmdText);
                //    if (rs.EOF == false)
                //    {
                //        return false;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //else
                //{
                //    return false;
                //}
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void insPayment(string pInvNo, string pItem, decimal pAmt, string pType, string pBank, string pChekNo, string pChekDt, string pDtGiven)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insPayment(" +
                                            cId + "," +
                                            "'" + pInvNo + "'," +
                                            "'" + pItem + "'," +
                                            pAmt + "," +
                                            "'" + pType + "'," +
                                            "'" + pChekNo + "'," +
                                            "'" + pBank + "'," +
                                            "'" + pChekDt + "'," +
                                            "'" + pDtGiven + "',0)",
                                            out ra, (int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void insReserve()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insReservation(" + cId + ")", out ra, (int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInvFpCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnFpCash_Click(sender,e);
            }
        }

        private void btnFpCheck_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(SettleFpCheck);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void SettleFpCheck() 
        {
            DialogResult cash = MessageBox.Show("Are you sure that your entries are correct?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cash == DialogResult.Yes)
            {
                if (txtInvFpCheck.Text == "")
                {
                    MessageBox.Show("Please don't leave a blank!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvFpCheck.Focus();
                    return;
                }

                if (txtCheckAmt.Value == 0)
                {
                    MessageBox.Show("You can't settle with 0 check amount!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime cDte = dtFpCheck.Value;
                string chkDt = cDte.ToString("yyyy-MM-dd");
                DateTime FpChekGiven = dtFpCheckGiven.Value;

                if (chkInv(txtInvFpCheck.Text) == true)
                {
                    MessageBox.Show("The invoice number is already used!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvFpCheck.Text = "";
                    txtInvFpCheck.Focus();
                    return;
                }

                decimal pAmt = Convert.ToDecimal(txtAmtFpCheck.Text);

                if (pAmt > txtCheckAmt.Value)
                {
                    DialogResult par = MessageBox.Show("Your check amount is not enough! Are you sure do want to continue this settlement?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (par != DialogResult.Yes)
                    {
                        return;
                    }
                }

                insPayment(txtInvFpCheck.Text, Item, txtCheckAmt.Value, "Check", txtFpChkBank.Text, txtFpChekNo.Text, chkDt, FpChekGiven.ToString("yyyy-MM-dd"));

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + txtInvFpCheck.Text + ")");

                if (pAmt > txtCheckAmt.Value)
                {
                    MessageBox.Show("The whole stay payment is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    this.Close();
                    return;
                }

                UpdContStat upd = new UpdContStat();
                upd.UpdateStatus(cId, "WholeStayPaymentStat", 1);
                if (upd.checkContStat(cId))
                {
                    if (ContType != "New")
                    {
                        upd.UpdSecDep(cId);
                    }

                    upd.ContStatus(cId, "Under Contract");
                    if (ContType == "Renew" || ContType == "Adjustment")
                    {
                        RoomBed b = new RoomBed();
                        if (b.chekBed(cId) == false)
                        {
                            insReserve();
                        }

                        if (ContType == "Adjustment")
                        {
                            UpdPdcStat uPdc = new UpdPdcStat();
                            uPdc.TransferPDC(cId);
                        }
                    }

                    if (ContType == "Extension")
                    {
                        upd.UpdExtension(cId);
                    }
                }

                MessageBox.Show("Whole stay payment is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Refresh != null)
                {
                    Refresh();
                }
                this.Close();
            }
        }

        private void txtInvFpCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnFpCheck_Click(sender, e);
            }
        }

        private void frmWsp_Shown(object sender, EventArgs e)
        {
            txtInvFpCash.Text = "";
            txtInvFpCheck.Text = "";
            txtFpChekNo.Text = "";
            txtFpChkBank.Text = "";

            txtPdcBank.Text = "";
            txtPdcCheckNo.Text = "";
            txtInvPdc.Text = "";
            //txtAmt.Value = 0;
        }

        private void cboPtype_SelectedValueChanged(object sender, EventArgs e)
        {
            switch(cboPtype.Text)
            {
                case "Check":
                    txtPdcBank.Enabled = true;
                    txtPdcBank.Text = "";
                    txtPdcCheckNo.Enabled = true;
                    txtPdcCheckNo.Text = "";
                    //dtPdcCheck.Enabled = true;
                    break;
                case "Cash":
                    txtPdcBank.Enabled = false;
                    txtPdcBank.Text = "None";
                    txtPdcCheckNo.Enabled = false;
                    txtPdcCheckNo.Text = "None";
                    //dtPdcCheck.Enabled = false;
                    break;
            }
        }

        private void btnFpOnline_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(SettleFpOnline);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void SettleFpOnline()
        {
            DialogResult online = MessageBox.Show("Are you sure that your entries are correct?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (online == DialogResult.Yes)
            {
                if (txtInvFpOnline.Text == "")
                {
                    MessageBox.Show("Please don't leave a blank!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvFpOnline.Focus();
                    return;
                }

                if (txtOnlineTender.Value == 0)
                {
                    MessageBox.Show("You can't settle with 0 tendered amount!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime FpOnlineGiven = dtFpOnlineGiven.Value;

                if (chkInv(txtInvFpOnline.Text) == true)
                {
                    MessageBox.Show("The invoice number is already used!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvFpOnline.Text = "";
                    txtInvFpOnline.Focus();
                    return;
                }

                decimal pAmt = Convert.ToDecimal(txtAmtFpOnline.Text);

                if (pAmt > txtOnlineTender.Value)
                {
                    DialogResult par = MessageBox.Show("Your tendered amount is not enough! Are you sure do want to continue this settlement?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (par != DialogResult.Yes)
                    {
                        return;
                    }
                }

                insPayment(txtInvFpOnline.Text, Item, txtOnlineTender.Value, "Online", "None", "None", "None", FpOnlineGiven.ToString("yyyy-MM-dd"));

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + txtInvFpOnline.Text + ")");

                if (pAmt > txtOnlineTender.Value)
                {
                    MessageBox.Show("The whole stay payment is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    this.Close();
                    return;
                }

                UpdContStat upd = new UpdContStat();
                upd.UpdateStatus(cId, "WholeStayPaymentStat", 1);
                if (upd.checkContStat(cId))
                {
                    if (ContType != "New")
                    {
                        upd.UpdSecDep(cId);
                    }

                    upd.ContStatus(cId, "Under Contract");
                    if (ContType == "Renew" || ContType == "Adjustment")
                    {
                        RoomBed b = new RoomBed();
                        if (b.chekBed(cId) == false)
                        {
                            insReserve();
                        }

                        if (ContType == "Adjustment")
                        {
                            UpdPdcStat uPdc = new UpdPdcStat();
                            uPdc.TransferPDC(cId);
                        }
                    }

                    if (ContType == "Extension")
                    {
                        upd.UpdExtension(cId);
                    }
                }

                MessageBox.Show("Whole stay payment is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Refresh != null)
                {
                    Refresh();
                }

                this.Close();
            }
        }

        private void txtInvFpOnline_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnFpOnline_Click(sender, e);
            }
        }
    }
}
