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
    public partial class frmPayments : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();
        //ReservationFeeAmt,ReserveCash,ReserveOnline,ReserveCheck,SecurityDepoAmt,DepoCash,DepoOnline," + 
        //"DepoCheck,WholeStayPaymentAmt,wsFullTermPay,wsCash,wsCheck,wsPDC

        public int RfCash, RfOl, RfCheck;
        public int ScCash, ScOl, ScCheck;
        public int WspFull, WspfCash, WspfCheck;
        public int WspPDC;
        public string ContTyp,ContStat;
        decimal mrAmt;
        
        public frmPayments()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            headerTpi();
            //fillTpi();

            headerPayments();
        }

        public void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 4;
            int wDt = w / 2;

            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Start Date", wDt, HorizontalAlignment.Left);
            lstTpi.Columns.Add("End Date", wDt, HorizontalAlignment.Left);
            lstTpi.Columns.Add("ContractStatus", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Monthly Fee", wDt, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Contract Type", w, HorizontalAlignment.Left);
        }

        public void headerPayments()
        {
            lstPayments.Clear();
            int w = lstPayments.Width / 2;

            lstPayments.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPayments.Columns.Add("Item", w, HorizontalAlignment.Left);
            lstPayments.Columns.Add("Amount", w, HorizontalAlignment.Left);
            lstPayments.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPayments.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPayments.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPayments.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPayments.Columns.Add("", 0, HorizontalAlignment.Left);
        }

        public void headerPayments2()
        {
            lstPayments.Clear();
            int w = lstPayments.Width / 5;

            lstPayments.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPayments.Columns.Add("", 0, HorizontalAlignment.Left);
            lstPayments.Columns.Add("BillName", w, HorizontalAlignment.Left);
            lstPayments.Columns.Add("Period", w, HorizontalAlignment.Left);
            lstPayments.Columns.Add("Amount", w, HorizontalAlignment.Left);
            lstPayments.Columns.Add("Penalty", w, HorizontalAlignment.Left);
            lstPayments.Columns.Add("Total Amt", w, HorizontalAlignment.Left);
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

                    //rs = conn.MySql.Execute("select Id,Name,StartDate,EndDate,ContractType,MonthlyFee,ContractStatus from vwepaymentname where " + 
                    //                        "(ReservationFeeStat = 0 or SecurityDepositStat = 0 or WholeStayPaymentStat = 0 " +
                    //                        "or KeyCardDepositStat = 0) and (ReservationFee <> ReservationFeeStat or SecurityDeposit <> SecurityDepositStat " +
                    //                        "or WholeStayPayment <> WholeStayPaymentStat or KeyCardDeposit <> KeyCardDepositStat)", out rc, (int)CommandTypeEnum.adCmdText);

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

        public void findTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select Id,Name,StartDate,EndDate,MonthlyFee,ContractType,ContractStatus from vwepaymentname where " + 
                                            cboCateg.Text + " like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
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

        private void ApplyingPayments(int Id) 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn()) 
                {
                    rs = conn.MySql.Execute("select ReservationFee,ReservationFeeAmt,ReserveCash,ReserveOnline,ReserveCheck,ReservationFeeStat,SecurityDeposit,SecurityDepoAmt,DepoCash,DepoOnline," +
                        "DepoCheck,SecurityDepositStat,WholeStayPayment,WholeStayPaymentAmt,wsFullTermPay,wsCash,wsCheck,wsOnline,wsPDC,WholeStayPaymentStat,KeyCardDeposit,KeyCardDepoAmt,kcdCash,kcdCheck,kcdOnline,KeyCardDepositStat from vwetenantcont where " + 
                        "Id = " + Id, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false) {
                        MakeMoney cur = new MakeMoney();

                        if (rs.Fields["ReservationFeeStat"].Value.ToString() == "0" && rs.Fields["ReservationFee"].Value.ToString() == "1")
                        {
                            decimal ResFeeAmt = Convert.ToDecimal(rs.Fields["ReservationFeeAmt"].Value.ToString());

                            decimal PayingAmt = ResFeeAmt - LessPaid("Reservation Fee", Id);

                            addPaymentList(Id.ToString(),"Reservation Fee", cur.Currency(PayingAmt), "", "",
                            rs.Fields["ReserveCash"].Value.ToString(), rs.Fields["ReserveOnline"].Value.ToString(), rs.Fields["ReserveCheck"].Value.ToString());
                        }

                        if (rs.Fields["SecurityDepositStat"].Value.ToString() == "0" && rs.Fields["SecurityDeposit"].Value.ToString() == "1")
                        {
                            decimal PayingAmt = Convert.ToInt32(rs.Fields["SecurityDepoAmt"].Value.ToString()) - LessPaid("Security Deposit",Id);

                            addPaymentList(Id.ToString(), "Security Deposit", cur.Currency(PayingAmt), "", "",
                            rs.Fields["DepoCash"].Value.ToString(), rs.Fields["DepoOnline"].Value.ToString(), rs.Fields["DepoCheck"].Value.ToString());
                        }

                        if (rs.Fields["WholeStayPaymentStat"].Value.ToString() == "0" && rs.Fields["WholeStayPayment"].Value.ToString() == "1")
                        {
                            decimal PayingAmt = Convert.ToInt32(rs.Fields["WholeStayPaymentAmt"].Value.ToString()) - LessPaid("Whole Stay Payment",Id);

                            addPaymentList(Id.ToString(), "Whole Stay Payment", cur.Currency(PayingAmt),
                               rs.Fields["wsFullTermPay"].Value.ToString(), rs.Fields["wsPDC"].Value.ToString(),
                               rs.Fields["wsCash"].Value.ToString(), rs.Fields["wsOnline"].Value.ToString(), rs.Fields["wsCheck"].Value.ToString());
                        }

                        if (rs.Fields["KeyCardDepositStat"].Value.ToString() == "0" && rs.Fields["KeyCardDeposit"].Value.ToString() == "1")
                        {
                            decimal PayingAmt = Convert.ToInt32(rs.Fields["KeyCardDepoAmt"].Value.ToString()) - LessPaid("Key Card Deposit",Id);

                            addPaymentList(Id.ToString(), "Key Card Deposit", cur.Currency(PayingAmt), "", "",
                            rs.Fields["kcdCash"].Value.ToString(), rs.Fields["kcdOnline"].Value.ToString(), rs.Fields["kcdCheck"].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        decimal LessPaid(string Itm, int contId) 
        {
            try
            {
                 DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select SUM(Amount) as PaidAmt from tblsettled where cId = " + contId + " and Item = '" + Itm + "'",out ra,(int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        decimal RetAmt = Convert.ToDecimal(rs.Fields["PaidAmt"].Value.ToString());

                        return RetAmt;
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
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void addPaymentList(string tId,string item,string amt,string WspFull,string WspPdc,string cash,string online,string check) 
        {
            try
            {
                ListViewItem viewlst = new ListViewItem();
                viewlst = lstPayments.Items.Add(tId);
                viewlst.SubItems.Add(item);
                viewlst.SubItems.Add(amt);
                viewlst.SubItems.Add(WspFull);
                viewlst.SubItems.Add(WspPdc);
                viewlst.SubItems.Add(cash);
                viewlst.SubItems.Add(online);
                viewlst.SubItems.Add(check);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (lstPayments.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Please select payments you want to settle!","Settle",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (lstPayments.SelectedItems[0].SubItems[3].Text == "1" || lstPayments.SelectedItems[0].SubItems[4].Text == "1")
            {
                frmWsp wsp = new frmWsp();

                wsp.ContType = ContTyp;
                wsp.cId = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[0].Text);
                wsp.Item = lstPayments.SelectedItems[0].SubItems[1].Text;
                wsp.sAmt = lstPayments.SelectedItems[0].SubItems[2].Text;
                wsp.sFullPay = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[3].Text);
                wsp.sPdc = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[4].Text);
                wsp.sFpCash = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[5].Text);
                wsp.sFpOnline = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[6].Text);
                wsp.sFpCheck = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[7].Text);
                wsp.mRentAmt = mrAmt;
                wsp.Refresh += new frmWsp.frmPaymentEvnt(Fillpays);
                wsp.ShowDialog();
            }
            else 
            {
                try
                {
                    frmSettle shw = new frmSettle();

                    shw.ContType = ContTyp;
                    shw.cId = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[0].Text);
                    shw.item = lstPayments.SelectedItems[0].SubItems[1].Text;
                    shw.Amt = lstPayments.SelectedItems[0].SubItems[2].Text;
                    shw.bCash = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[5].Text);
                    shw.bOnline = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[6].Text);
                    shw.bCheck = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[7].Text);
                    //shw.Refresh += new frmSettle.frmPaymentEvnt(headerPayments);
                    shw.Refresh += new frmSettle.frmPaymentEvnt(Fillpays);
                    shw.ShowDialog();
                }
                catch 
                {
                    frmSettle shw = new frmSettle();

                    if (ContStat == "Move Out")
                    {
                        shw.ContStat = ContStat;
                        shw.ContType = ContTyp;
                        shw.bId = shw.bId = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[0].Text);
                        shw.cId = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[1].Text);
                        shw.item = lstPayments.SelectedItems[0].SubItems[2].Text;
                        shw.Perio = Convert.ToDateTime(lstPayments.SelectedItems[0].SubItems[3].Text);
                        shw.Penalty = Convert.ToDecimal(lstPayments.SelectedItems[0].SubItems[5].Text);
                        shw.Amt = lstPayments.SelectedItems[0].SubItems[6].Text;
                        shw.bCash = 0;
                        shw.bOnline = 0;
                        shw.bCheck = 0;
                        //shw.Refresh += new frmSettle.frmPaymentEvnt(headerPayments2);
                        shw.Refresh += new frmSettle.frmPaymentEvnt(Fillpays);
                        shw.ShowDialog();
                    }
                    else 
                    {
                        shw.ContStat = ContStat;
                        shw.ContType = ContTyp;
                        shw.bId = shw.bId = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[0].Text);
                        shw.cId = Convert.ToInt32(lstPayments.SelectedItems[0].SubItems[1].Text);
                        shw.item = lstPayments.SelectedItems[0].SubItems[2].Text;
                        shw.Perio = Convert.ToDateTime(lstPayments.SelectedItems[0].SubItems[3].Text);
                        shw.Penalty = Convert.ToDecimal(lstPayments.SelectedItems[0].SubItems[5].Text);
                        shw.Amt = lstPayments.SelectedItems[0].SubItems[6].Text;
                        shw.bCash = 1;
                        shw.bOnline = 1;
                        shw.bCheck = 1;
                        //shw.Refresh += new frmSettle.frmPaymentEvnt(headerPayments2);
                        shw.Refresh += new frmSettle.frmPaymentEvnt(Fillpays);
                        shw.ShowDialog();
                    }
                }
            }
        }

        private void lstTpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count > 0)
            {
                Thread th = new Thread(() =>
                {
                    Action act = new Action(Fillpays);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        void Fillpays()
        {
            try
            {
                if (lstTpi.SelectedItems.Count == 0) 
                {
                    return;
                }

                mrAmt = Convert.ToDecimal(lstTpi.SelectedItems[0].SubItems[5].Text);

                switch (lstTpi.SelectedItems[0].SubItems[4].Text)
                {
                    case "Applying":
                        headerPayments();
                        ApplyingPayments(Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text));
                        ContTyp = lstTpi.SelectedItems[0].SubItems[6].Text;

                        break;
                    case "Reserved":
                        headerPayments();
                        ApplyingPayments(Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text));
                        ContTyp = lstTpi.SelectedItems[0].SubItems[6].Text;

                        break;
                    case "Hold":
                        headerPayments();
                        ApplyingPayments(Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text));
                        ContTyp = lstTpi.SelectedItems[0].SubItems[6].Text;

                        break;
                    case "Under Contract":
                        ContStat = "Under Contract";
                        ContTyp = lstTpi.SelectedItems[0].SubItems[6].Text;

                        headerPayments2();
                        decimal Pena = Convert.ToDecimal(Properties.Settings.Default.RentPena);
                        int cID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                        fillBill(cID, Pena);
                        break;
                    case "Move Out":
                        ContStat = "Move Out";
                        ContTyp = lstTpi.SelectedItems[0].SubItems[6].Text;

                        headerPayments2();
                        decimal PenaMO = Convert.ToDecimal(Properties.Settings.Default.RentPena);
                        int cIDmo = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                        fillBill(cIDmo, PenaMO);
                        break;
                    default:
                        headerPayments();
                        break;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void fillBill(int Cid,decimal PenaPer)
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    string dtNow = DateTime.Now.ToString("yyyy-MM-dd");

                    rs = conn.MySql.Execute("call slctTenantBill(" + Cid + ",'" + dtNow + "'," + PenaPer + ");", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstPayments.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            MakeMoney p = new MakeMoney();
                            string Amt = p.Currency(Convert.ToDecimal(rs.Fields["Amount"].Value.ToString()));
                            string Pena = p.Currency(Convert.ToDecimal(rs.Fields["Penalty"].Value.ToString()));
                            int bID = Convert.ToInt32(rs.Fields["Id"].Value.ToString());
                            decimal TtAmt = Convert.ToDecimal(rs.Fields["TotalAmt"].Value.ToString()) - LessBillPaid(bID);
                            string TotalAmt = p.Currency(TtAmt);

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstPayments.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["BillName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Period"].Value.ToString());
                            viewlst.SubItems.Add(Amt);
                            viewlst.SubItems.Add(Pena);
                            viewlst.SubItems.Add(TotalAmt);
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

        decimal LessBillPaid(int billId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    //rs = conn.MySql.Execute("select SUM(Amount) as PaidAmt from tblsettled where bId = " + billId, out ra, (int)CommandTypeEnum.adCmdText);
                    rs = conn.MySql.Execute("call getLessPaid(" + billId + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        decimal RetAmt = Convert.ToDecimal(rs.Fields["PaidAmt"].Value.ToString());

                        return RetAmt;
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
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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

            headerPayments();
        }

        private void frmPayments_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmPayments_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmPayments_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void lstPayments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
