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
    public partial class frmSettle : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int cId,bId;
        public string item, Amt ,ContType,ContStat;
        public DateTime Perio;
        public int bCash, bOnline, bCheck;
        public decimal Penalty;

        public delegate void frmPaymentEvnt();
        public event frmPaymentEvnt Refresh;

        public delegate void frmVoidEvnt();
        public event frmVoidEvnt Voiding;

        string ItemName;

        public frmSettle()
        {
            InitializeComponent();
        }

        private void frmSettle_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag) {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmSettle_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmSettle_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettle_Load(object sender, EventArgs e)
        {
            if (bCash == 0)
            {
                tabControl.TabPages.Remove(tabCash);
            }
            else {
                txtAmtCash.Text = Amt;
                txtCashTender.Value = Convert.ToDecimal( Amt);
            }

            if (bOnline == 0)
            {
                tabControl.TabPages.Remove(tabOnline);
            }
            else {
                txtAmtOnline.Text = Amt;
                txtOnlineTender.Value = Convert.ToDecimal(Amt);
            }

            if (bCheck == 0)
            {
                tabControl.TabPages.Remove(tabCheck);
            }
            else {
                txtAmtCheck.Text = Amt;
                txtCheckAmt.Value = Convert.ToDecimal(Amt);
            }

            if (item != "Monthly Rent") 
            {
                tabControl.TabPages.Remove(tabPDC);
            } 
            else
            {
                txtPDCamt.Text = Amt;
                HeaderPDC();
                GetFillPdc(cId);
            }

            if (ContStat != "Move Out")
            {
                tabControl.TabPages.Remove(tabDepo);
            }
            else 
            {

                txtDepoAmt.Text = Amt;
                decimal LesDepoAmt = LessDepoBal(cId);
                MakeMoney cur = new MakeMoney();

                if (LesDepoAmt == 0)
                {
                    decimal DepoAmt = DepoBal(cId);
                    txtBalDepo.Text = cur.Currency(DepoAmt);
                }
                else 
                {
                    txtBalDepo.Text = cur.Currency(LesDepoAmt);
                }
            }

            AutoSelect();
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
                    rs = conn.MySql.Execute("call getBalDepo(" + cid + ")",out ra,(int)CommandTypeEnum.adCmdText);
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

        void HeaderPDC()
        {
            lstPDC.Clear();
            int w = lstPDC.Width / 6;

            lstPDC.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPDC.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Cash", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Invoice No", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Period", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Amount", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Check No", 90, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Bank", w, HorizontalAlignment.Left);
            lstPDC.Columns.Add("Check Date", 90, HorizontalAlignment.Left);
        }

        void GetFillPdc(int cID)
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblpdc where cId = " + cID + " and UsedStat = 0 order by Id", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            DateTime ChkDt = Convert.ToDateTime(rs.Fields["CheckDate"].Value.ToString());

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
                            viewlst.SubItems.Add(ChkDt.ToString("yyyy-MM-dd"));
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

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    AutoSelect();
                    break;
                case 1:
                    AutoSelect();
                    break;
                case 2:
                    AutoSelect();
                    break;
            }
        }

        private void AutoSelect() {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabCash":
                    txtInvCash.Focus();
                    break;
                case "tabOnline":
                    txtInvOnline.Focus();
                    break;
                case "tabCheck":
                    txtBank.Focus();
                    break;
            }
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(CashSettle);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void CashSettle() 
        {
            DialogResult cash = MessageBox.Show("Are you sure that your entries are correct?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cash == DialogResult.Yes)
            {
                if (txtInvCash.Text == "")
                {
                    MessageBox.Show("Please don't leave a blank!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvCash.Focus();
                    return;
                }

                if (txtCashTender.Value == 0) 
                {
                    MessageBox.Show("You can't settle with 0 tendered amount!","Settle",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                DateTime CashGiven = dtCashGiven.Value;

                if (chkInv(txtInvCash.Text) == true)
                {
                    MessageBox.Show("The invoice number is already used!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvCash.Text = "";
                    txtInvCash.Focus();
                    return;
                }

                decimal pAmt = Convert.ToDecimal(txtAmtCash.Text);

                if (pAmt > txtCashTender.Value)
                {
                    DialogResult par = MessageBox.Show("Your tendered amount is not enough! Are you sure do want to continue this settlement?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (par != DialogResult.Yes)
                    {
                        return;
                    }
                }


                if (item == "Reservation Fee" || item == "Security Deposit" || item == "Key Card Deposit")
                {
                    ItemName = item;
                }
                else
                {
                    ItemName = item + " " + Perio.ToString("MMM yyyy");
                }

                insPayment(txtInvCash.Text, ItemName, txtCashTender.Value, "Cash", "None", "None", "None", CashGiven.ToString("yyyy-MM-dd"),bId);

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + txtInvCash.Text + ")");

                switch (item)
                {
                    case "Reservation Fee":
                        if (pAmt > txtCashTender.Value) 
                        {
                            MessageBox.Show("The reservation fee is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();
                            return;
                        }

                        UpdContStat updRF = new UpdContStat();
                        updRF.UpdateStatus(cId, "ReservationFeeStat", 1);
                        updRF.ContStatus(cId, "Reserved");
                        if (updRF.checkContStat(cId))
                        {
                            if (ContType != "New") 
                            {
                                updRF.UpdSecDep(cId);
                            }

                            updRF.ContStatus(cId, "Under Contract");
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
                                updRF.UpdExtension(cId);
                            }
                        }

                        RoomBed rb = new RoomBed();
                        if (rb.chekBed(cId) == false)
                        {
                            insReserve();
                        }

                        MessageBox.Show("The reservation fee is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    case "Security Deposit":
                        insDepo(item, Convert.ToDecimal(Amt));

                        if (pAmt > txtCashTender.Value)
                        {
                            MessageBox.Show("The security deposit is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdContStat updSC = new UpdContStat();
                        updSC.UpdateStatus(cId, "SecurityDepositStat", 1);
                        if (updSC.checkContStat(cId))
                        {
                            if (ContType != "New")
                            {
                                updSC.UpdSecDep(cId);
                            }

                            updSC.ContStatus(cId, "Under Contract");
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
                                updSC.UpdExtension(cId);
                            }
                        }
                        //updSC.ContStatus(cId, "Reserved");
                        MessageBox.Show("The security deposit is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    case "Key Card Deposit":
                        insDepo(item, Convert.ToDecimal(Amt));

                        if (pAmt > txtCashTender.Value)
                        {
                            MessageBox.Show("The key card deposit is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdContStat updKC = new UpdContStat();
                        updKC.UpdateStatus(cId, "KeyCardDepositStat", 1);
                        if (updKC.checkContStat(cId))
                        {
                            if (ContType != "New")
                            {
                                updKC.UpdSecDep(cId);
                            }

                            updKC.ContStatus(cId, "Under Contract");
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
                                updKC.UpdExtension(cId);
                            }
                        }
                        //updSC.ContStatus(cId, "Reserved");
                        MessageBox.Show("The key card deposit is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    default:
                        if (pAmt > txtCashTender.Value)
                        {
                            MessageBox.Show("The " + item +" billing is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdBillStat Bstat = new UpdBillStat();
                        //Bstat.BillsInv(bId, txtInvCash.Text);

                        if (Penalty > 0)
                        {
                            if (Bstat.BillPaid(bId, "Late"))
                            {
                                MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (Refresh != null)
                                {
                                    Refresh();
                                }
                                this.Close();
                            }
                        }
                        else
                        {
                            if (Bstat.BillPaid(bId, "On Time"))
                            {
                                MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (Refresh != null)
                                {
                                    Refresh();
                                }
                                this.Close();
                            }
                        }
                        break;
                }
            }
        }

        private void txtInvCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCash_Click(sender, e);
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
                //    rs = conn.MySql.Execute("select InvoiceNo from tblsettled where InvoiceNo = '" + Inv + "'",out ra,(int)CommandTypeEnum.adCmdText);
                //    if (rs.EOF == false)
                //    {
                //        return true;
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void insPayment(string pInvNo,string pItem,decimal pAmt,string pType,string pBank,string pChekNo, string pChekDt,string pDtGiven,int bilId) 
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
                                            "'" + pDtGiven + "'," + bilId + ")",
                                            out ra,(int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void insDepo(string dName, decimal dAmt)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblDeposits(" +
                                            cId + ",'" +
                                            dName + "','" +
                                            dAmt + "')",
                                            out ra, (int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insReserve() {
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(OnlineSettle);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void OnlineSettle() 
        {
            DialogResult cash = MessageBox.Show("Are you sure that your entries are correct?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cash == DialogResult.Yes)
            {
                if (txtInvOnline.Text == "")
                {
                    MessageBox.Show("Please don't leave a blank!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvOnline.Focus();
                    return;
                }

                if (txtOnlineTender.Value == 0)
                {
                    MessageBox.Show("You can't settle with 0 tendered amount!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime OnlineGiven = dtOnlineGiven.Value;

                if (chkInv(txtInvOnline.Text) == true)
                {
                    MessageBox.Show("The invoice number is already used!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvOnline.Text = "";
                    txtInvOnline.Focus();
                    return;
                }


                decimal pAmt = Convert.ToDecimal(txtAmtOnline.Text);

                if (pAmt > txtOnlineTender.Value)
                {
                    DialogResult par = MessageBox.Show("Your tendered amount is not enough! Are you sure do want to continue this settlement?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (par != DialogResult.Yes)
                    {
                        return;
                    }
                }


                if (item == "Reservation Fee" || item == "Security Deposit" || item == "Key Card Deposit")
                {
                    ItemName = item;
                }
                else
                {
                    ItemName = item + " " + Perio.ToString("MMM yyyy");
                }

                insPayment(txtInvOnline.Text, ItemName,txtOnlineTender.Value, "Online", "None", "None", "None", OnlineGiven.ToString("yyyy-MM-dd"),bId);

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + txtInvOnline.Text + ")");

                switch (item)
                {
                    case "Reservation Fee":
                        if (pAmt > txtOnlineTender.Value)
                        {
                            MessageBox.Show("The reservation fee is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdContStat upd = new UpdContStat();
                        upd.UpdateStatus(cId, "ReservationFeeStat", 1);
                        upd.ContStatus(cId, "Reserved");
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

                        insReserve();
                        MessageBox.Show("The reservation fee is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    case "Security Deposit":
                        insDepo(item, Convert.ToDecimal(Amt));

                        if (pAmt > txtOnlineTender.Value)
                        {
                            MessageBox.Show("The security deposit is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdContStat updSC = new UpdContStat();
                        updSC.UpdateStatus(cId, "SecurityDepositStat", 1);
                        if (updSC.checkContStat(cId))
                        {
                            if (ContType != "New")
                            {
                                updSC.UpdSecDep(cId);
                            }

                            updSC.ContStatus(cId, "Under Contract");
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
                                updSC.UpdExtension(cId);
                            }
                        }
                        //updSC.ContStatus(cId, "Reserved");
                        MessageBox.Show("The security deposit is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    case "Key Card Deposit":
                        insDepo(item, Convert.ToDecimal(Amt));

                        if (pAmt > txtOnlineTender.Value)
                        {
                            MessageBox.Show("The key card deposit is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdContStat updKC = new UpdContStat();
                        updKC.UpdateStatus(cId, "KeyCardDepositStat", 1);
                        if (updKC.checkContStat(cId))
                        {
                            if (ContType != "New")
                            {
                                updKC.UpdSecDep(cId);
                            }

                            updKC.ContStatus(cId, "Under Contract");
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
                                updKC.UpdExtension(cId);
                            }
                        }
                        //updSC.ContStatus(cId, "Reserved");
                        MessageBox.Show("The key card deposit is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    default:
                        if (pAmt > txtOnlineTender.Value)
                        {
                            MessageBox.Show("The " + item + " billing is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdBillStat Bstat = new UpdBillStat();
                        //Bstat.BillsInv(bId, txtInvOnline.Text);

                        if (Penalty > 0)
                        {
                            if (Bstat.BillPaid(bId, "Late"))
                            {
                                MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (Refresh != null)
                                {
                                    Refresh();
                                }
                                this.Close();
                            }
                        }
                        else
                        {
                            if (Bstat.BillPaid(bId, "On Time"))
                            {
                                MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (Refresh != null)
                                {
                                    Refresh();
                                }
                                this.Close();
                            }
                        }
                        break;
                }
            }
        }

        private void txtInvOnline_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnOnline_Click(sender, e);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(CheckSettle);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void CheckSettle() 
        {
            DialogResult cash = MessageBox.Show("Are you sure that your entries are correct?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cash == DialogResult.Yes)
            {
                if (txtInvCheck.Text == "")
                {
                    MessageBox.Show("Please don't leave a blank!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvCheck.Focus();
                    return;
                }

                if (txtCheckAmt.Value == 0)
                {
                    MessageBox.Show("You can't settle with check with the 0 balance amount!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime cDte = dtCheck.Value;
                string chkDt = cDte.ToString("yyyy-MM-dd");
                DateTime ChekGiven = dtCheckGiven.Value;

                decimal PayAmt = Convert.ToDecimal(txtAmtCheck.Text);
                decimal ChekAmt = txtCheckAmt.Value;

                if (chkInv(txtInvCheck.Text) == true)
                {
                    MessageBox.Show("The invoice number is already used!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvCheck.Text = "";
                    txtInvCheck.Focus();
                    return;
                }

                if (PayAmt > ChekAmt)
                {
                    DialogResult par = MessageBox.Show("Your check amount is not enough! Are you sure do want to continue this settlement?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (par != DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (item == "Reservation Fee" || item == "Security Deposit" || item == "Key Card Deposit")
                {
                    ItemName = item;
                }
                else 
                {
                    ItemName = item + " " + Perio.ToString("MMM yyyy");
                }

                insPayment(txtInvCheck.Text, ItemName, ChekAmt, "Check", txtBank.Text, txtChekNo.Text, chkDt, ChekGiven.ToString("yyyy-MM-dd"), bId);

                if (ChekAmt > PayAmt)
                {
                    decimal ChekDiff = ChekAmt - PayAmt;
                    insDepo(item, ChekDiff);
                }

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + txtInvCheck.Text + ")");

                switch (item)
                {
                    case "Reservation Fee":
                        if (PayAmt > ChekAmt)
                        {
                            MessageBox.Show("The reservation fee is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdContStat upd = new UpdContStat();
                        upd.UpdateStatus(cId, "ReservationFeeStat", 1);
                        upd.ContStatus(cId, "Reserved");
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
                        insReserve();
                        MessageBox.Show("The reservation fee is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    case "Security Deposit":
                        insDepo(item, Convert.ToDecimal(Amt));

                        if (PayAmt > ChekAmt)
                        {
                            MessageBox.Show("The security deposit is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdContStat updSC = new UpdContStat();
                        updSC.UpdateStatus(cId, "SecurityDepositStat", 1);
                        if (updSC.checkContStat(cId))
                        {
                            if (ContType != "New")
                            {
                                updSC.UpdSecDep(cId);
                            }

                            updSC.ContStatus(cId, "Under Contract");
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
                                updSC.UpdExtension(cId);
                            }
                        }
                        //updSC.ContStatus(cId, "Reserved");
                        MessageBox.Show("The security deposit is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    case "Key Card Deposit":
                        insDepo(item, Convert.ToDecimal(Amt));

                        if (PayAmt > ChekAmt)
                        {
                            MessageBox.Show("The key card deposit is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdContStat updKC = new UpdContStat();
                        updKC.UpdateStatus(cId, "KeyCardDepositStat", 1);
                        if (updKC.checkContStat(cId))
                        {
                            if (ContType != "New")
                            {
                                updKC.UpdSecDep(cId);
                            }

                            updKC.ContStatus(cId, "Under Contract");
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
                                updKC.UpdExtension(cId);
                            }
                        }
                        //updSC.ContStatus(cId, "Reserved");
                        MessageBox.Show("The key card deposit is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                        break;
                    default:
                        if (PayAmt > txtCheckAmt.Value)
                        {
                            MessageBox.Show("The " + item + " billing is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Refresh != null)
                            {
                                Refresh();
                            }
                            this.Close();

                            return;
                        }

                        UpdBillStat Bstat = new UpdBillStat();
                        //Bstat.BillsInv(bId, txtInvCheck.Text);

                        if (Penalty > 0)
                        {
                            if (Bstat.BillPaid(bId, "Late"))
                            {
                                MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (Refresh != null)
                                {
                                    Refresh();
                                }
                                this.Close();
                            }
                        }
                        else
                        {
                            if (Bstat.BillPaid(bId, "On Time"))
                            {
                                MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (Refresh != null)
                                {
                                    Refresh();
                                }
                                this.Close();
                            }
                        }
                        break;
                }
            }
        }

        private void txtInvCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCheck_Click(sender, e);
            }
        }

        private void frmSettle_Shown(object sender, EventArgs e)
        {
            txtInvCash.Text = "";
            txtInvOnline.Text = "";

            txtInvCheck.Text = "";
            txtChekNo.Text = "";
            txtBank.Text = "";
        }

        private void btnPDC_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(PDCSettle);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void PDCSettle() 
        {
            if (lstPDC.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select PDC record that you want to use!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtInvPDC.Text == "") 
            {
                MessageBox.Show("Please don't leave a blank!","Settle",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DialogResult ys = MessageBox.Show("Are you sure that your selected PDC record is confirmed?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ys != DialogResult.Yes)
            {
                return;
            }

            int PdcId = Convert.ToInt32(lstPDC.SelectedItems[0].SubItems[0].Text);
            string Inv = txtInvPDC.Text;
            decimal Amt = txtAdjustAmt.Value;
            string BankB = lstPDC.SelectedItems[0].SubItems[7].Text;
            string chkNo = lstPDC.SelectedItems[0].SubItems[6].Text;
            DateTime chkDt = Convert.ToDateTime(lstPDC.SelectedItems[0].SubItems[8].Text);
            DateTime dtnow = DateTime.Now;
            decimal PdcChekAmt = Convert.ToDecimal(lstPDC.SelectedItems[0].SubItems[5].Text);
            decimal BillAmt = Convert.ToDecimal(txtPDCamt.Text);

            if (BillAmt > Amt) 
            {
                DialogResult par = MessageBox.Show("Your PDC amount is not enough! Are you sure do want to continue this settlement?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (par != DialogResult.Yes)
                {
                    return;
                }
            }

            if (chkInv(Inv) == true) 
            {
                MessageBox.Show("The invoice number is already used!","Settle",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtInvPDC.Text = "";
                txtInvPDC.Focus();
                return;
            }

            insPayment(Inv, "Monthly Rent " + Perio.ToString("MMM yyyy"), Amt, "PDC", BankB, chkNo, chkDt.ToString("yyyy-MM-dd"), dtnow.ToString("yyyy-MM-dd"),bId);

            if (Amt > BillAmt)
            {
                decimal PdcDiff = Amt - BillAmt;
                insDepo(item, PdcDiff);
            }

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + Inv + ")");

            UpdPdcStat upd = new UpdPdcStat();
            if (upd.PdcUsed(PdcId))
            {
                if (BillAmt > Amt)
                {
                    MessageBox.Show("The monthly rent is partially settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    this.Close();
                    if (Refresh != null)
                    {
                        Refresh();
                    }

                    return;
                }

                UpdBillStat Bstat = new UpdBillStat();
                //Bstat.BillsInv(bId, txtInvPDC.Text);

                if (Penalty > 0)
                {
                    if (Bstat.BillPaid(bId, "Late"))
                    {
                        MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        this.Close();

                        if (Refresh != null)
                        {
                            Refresh();
                        }
                    }
                }
                else
                {
                    if (Bstat.BillPaid(bId, "On Time"))
                    {
                        MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Close();

                        if (Refresh != null)
                        {
                            Refresh();
                        }
                    }
                }
            }
        }

        private void btnDepoSettle_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(DepoSettle);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void DepoSettle() 
        {
            decimal BillAmt = Convert.ToDecimal(txtDepoAmt.Text);
            decimal DepoBal = Convert.ToDecimal(txtBalDepo.Text);

            if(txtDepoInv.Text == "")
            {
                MessageBox.Show("Please don't leave a blank!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepoInv.Focus();
                return;
            }

             DialogResult Depo = MessageBox.Show("Are you sure that your entries are correct?", "Settle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (Depo != DialogResult.Yes)
             {
                 return;
             }

            if (BillAmt > DepoBal) 
            {
                MessageBox.Show("Insufficient deposit balance!","Settle",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DateTime DepoGiven = DateTime.Now;

            if (chkInv(txtDepoInv.Text) == true)
            {
                MessageBox.Show("The invoice number is already used!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepoInv.Text = "";
                txtDepoInv.Focus();
                return;
            }

            insPayment(txtDepoInv.Text, item + " " + Perio.ToString("MMM yyyy"), Convert.ToDecimal(txtDepoAmt.Text), "Deposits", "None", "None", "None", DepoGiven.ToString("yyyy-MM-dd"),bId);

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + txtDepoInv.Text + ")");

            UpdBillStat Bstat = new UpdBillStat();
            //Bstat.BillsInv(bId, txtDepoInv.Text);

            if (Penalty > 0)
            {
                if (Bstat.BillPaid(bId, "Deposits"))
                {
                    MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    this.Close();
                }
            }
            else
            {
                if (Bstat.BillPaid(bId, "Deposits"))
                {
                    MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    this.Close();
                }
            }
        }

        void VoidSettle()
        {
            DateTime DtGiven = DateTime.Now;

            insPayment("VOIDED", item,Convert.ToDecimal(Amt), "Void", "None", "None", "None", DtGiven.ToString("yyyy-MM-dd"), bId);

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Settle Payment cId: (" + cId + ") Invoice: (" + txtInvCash.Text + ")");

            switch (item)
            {
                case "Reservation Fee":
                    UpdContStat updRF = new UpdContStat();
                    updRF.UpdateStatus(cId, "ReservationFeeStat", 1);
                    updRF.ContStatus(cId, "Reserved");
                    if (updRF.checkContStat(cId))
                    {
                        if (ContType != "New")
                        {
                            updRF.UpdSecDep(cId);
                        }

                        updRF.ContStatus(cId, "Under Contract");
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
                            updRF.UpdExtension(cId);
                        }
                    }

                    RoomBed rb = new RoomBed();
                    if (rb.chekBed(cId) == false)
                    {
                        insReserve();
                    }

                    MessageBox.Show("The reservation fee is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    this.Close();
                    break;
                case "Security Deposit":
                    UpdContStat updSC = new UpdContStat();
                    updSC.UpdateStatus(cId, "SecurityDepositStat", 1);
                    if (updSC.checkContStat(cId))
                    {
                        if (ContType != "New")
                        {
                            updSC.UpdSecDep(cId);
                        }

                        updSC.ContStatus(cId, "Under Contract");
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
                            updSC.UpdExtension(cId);
                        }
                    }
                    //updSC.ContStatus(cId, "Reserved");
                    MessageBox.Show("The security deposit is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    this.Close();
                    break;
                case "Key Card Deposit":
                    UpdContStat updKC = new UpdContStat();
                    updKC.UpdateStatus(cId, "KeyCardDepositStat", 1);
                    if (updKC.checkContStat(cId))
                    {
                        if (ContType != "New")
                        {
                            updKC.UpdSecDep(cId);
                        }

                        updKC.ContStatus(cId, "Under Contract");
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
                            updKC.UpdExtension(cId);
                        }
                    }
                    //updSC.ContStatus(cId, "Reserved");
                    MessageBox.Show("The key card deposit is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    this.Close();
                    break;
                default:
                    UpdBillStat Bstat = new UpdBillStat();
                    //Bstat.BillsInv(bId, txtInvCash.Text);
                    if (Bstat.BillPaid(bId, "On Time"))
                    {
                        MessageBox.Show("The " + item + " billing is successfully settled!", "Settle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        this.Close();
                    }
                    break;
            }
        }

        private void txtDepoInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDepoSettle_Click(sender, e);
            }
        }

        private void txtInvPDC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnPDC_Click(sender, e);
            }
        }

        private void lstPDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPDC.SelectedItems.Count > 0)
            {
                txtAdjustAmt.Value = Convert.ToDecimal(lstPDC.SelectedItems[0].SubItems[5].Text);
            }
        }

        private void lstPDC_MouseUp(object sender, MouseEventArgs e)
        {
            txtAdjustAmt.Focus();
        }

        private void txtCheckAmt_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void frmSettle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.Shift == true && e.KeyCode == Keys.V) 
            {
                frmVoid shw = new frmVoid();
                shw.VoidTrans += new frmVoid.frmSettleEvnt(VoidSettle);
                shw.ShowDialog();
            }
        }
    }
}
