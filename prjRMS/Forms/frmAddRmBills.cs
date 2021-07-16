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
    public partial class frmAddRmBills : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string wLoad;
        public int rId;
        public string eRmNo, eBname;
        public decimal eAmt;
        public DateTime ePer,eFromDt, eToDt, eDueDt;

        decimal TenantTotalDays = 0;

        public frmAddRmBills()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddRmBills_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmAddRmBills_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmAddRmBills_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void cboRmNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void cboBiller_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmAddRmBills_Load(object sender, EventArgs e)
        {
            loadCont(cboRmNo);
            DateTime now = DateTime.Now;
            dtPeriod.Value = now.AddDays(1 - now.Day);

            if (wLoad == "Edit")
            {
                lbTitle.Text = "Update Room Billing";
                btnSave.Text = "Update";
                cboRmNo.Text = eRmNo;
                cboRmNo.Enabled = false;
                cboBiller.Text = eBname;
                cboBiller.Enabled = false;
                dtPeriod.Value = ePer;
                txtAmt.Value = eAmt;
                dtFrm.Value = eFromDt;
                dtTo.Value = eToDt;
                dtDueDate.Value = eDueDt;
            }
        }

        void loadCont(ComboBox cbo)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    cbo.Items.Clear();
                    rs = conn.MySql.Execute("select RoomNo from vwebedreserved where BedStatus <> 'Cancelled' and BedStatus <> 'Forfeited' and BedStatus <> 'Reserved' and " +
	                                        "BedStatus <> 'Hold' and BedStatus <> 'Applying' group by RoomNo order by RoomNo", out ra, (int)CommandTypeEnum.adCmdText);
                    while (rs.EOF == false)
                    {
                        cbo.Items.Add(rs.Fields["RoomNo"].Value.ToString());
                        rs.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (wLoad == "Edit")
            {
                if (chkFields() == false)
                {
                    MessageBox.Show("Please complete the fields!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboRmNo.Focus();
                    return;
                }

                //int RmNo = Convert.ToInt32(cboRmNo.Text);
                //DateTime billDt = dtTo.Value;

                //if (chkRmBill(RmNo, cboBiller.Text, billDt.ToString("yyyy-MM-dd")) == true)
                //{
                //    MessageBox.Show("Billing of " + cboBiller.Text + " in this period is already entered!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                DialogResult s = MessageBox.Show("Are you sure do you want to save changes?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                if (s != DialogResult.Yes)
                {
                    return;
                }

                Thread th = new Thread(() =>
                {
                    Action act = new Action(updMonthlyBill);
                    this.BeginInvoke(act);
                });
                th.Start();

                Thread th2 = new Thread(() =>
                {
                    Action act = new Action(GetUpdRmTenant);
                    this.BeginInvoke(act);
                });
                th2.Start();
            }
            else 
            {
                if (chkFields() == false)
                {
                    MessageBox.Show("Please complete the fields!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboRmNo.Focus();
                    return;
                }

                int RmNo = Convert.ToInt32(cboRmNo.Text);
                DateTime billDt = dtTo.Value;

                if (chkRmBill(RmNo, cboBiller.Text, billDt.ToString("yyyy-MM-dd")) == true)
                {
                    MessageBox.Show("Billing of " + cboBiller.Text + " in this period is already entered!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult s = MessageBox.Show("Are you sure that all of your entries are correct?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (s != DialogResult.Yes)
                {
                    return;
                }

                Thread th = new Thread(() =>
                {
                    Action act = new Action(insMonthlyBill);
                    this.BeginInvoke(act);
                });
                th.Start();

                Thread th2 = new Thread(() =>
                {
                    Action act = new Action(GetRmTenant);
                    this.BeginInvoke(act);
                });
                th2.Start();
            }
        }

        bool chkFields() 
        {
            if (cboRmNo.Text == "" || cboBiller.Text == "" || txtAmt.Value == 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        bool chkRmBill(int RmNo,string bName,string bDate) 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getRmBill(" +
                                            RmNo + ",'" +
                                            bName + "','" +
                                            bDate +
                                            "')", out ra, (int)CommandTypeEnum.adCmdText);
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

        bool chkTenantBill(int cId, string bName, string bDate)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getTenantBills(" +
                                            cId + ",'" +
                                            bName + "','" +
                                            bDate +
                                            "')", out ra, (int)CommandTypeEnum.adCmdText);
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

        void insMonthlyBill() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime FrmDt = dtFrm.Value;
                DateTime BilDt = dtTo.Value;
                DateTime DueDt = dtDueDate.Value;

                if (conn.ServerConn())
                {
                    DateTime per = dtPeriod.Value;
                    int RmNo = Convert.ToInt32(cboRmNo.Text);
                    rs = conn.MySql.Execute("call insTblMonthlyBill(" +
                                            RmNo + ",'" +
                                            cboBiller.Text + "','" +
                                            per.ToString("MMMM yyyy") + "'," +
                                            txtAmt.Value + ",'" +
                                            FrmDt.ToString("yyyy-MM-dd") + "','" +
                                            BilDt.ToString("yyyy-MM-dd") + "','" +
                                            DueDt.ToString("yyyy-MM-dd") + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Room Billing: (" + cboBiller.Text + ") added to Room No: (" + RmNo.ToString() + ")");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void updMonthlyBill()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime FrmDt = dtFrm.Value;
                DateTime BilDt = dtTo.Value;
                DateTime DueDt = dtDueDate.Value;

                if (conn.ServerConn())
                {
                    DateTime per = dtPeriod.Value;
                    int RmNo = Convert.ToInt32(cboRmNo.Text);
                    rs = conn.MySql.Execute("call updTblMonthlyBill(" +
                                            rId + ",'" +
                                            per.ToString("MMMM yyyy") + "'," +
                                            txtAmt.Value + ",'" +
                                            FrmDt.ToString("yyyy-MM-dd") + "','" +
                                            BilDt.ToString("yyyy-MM-dd") + "','" +
                                            DueDt.ToString("yyyy-MM-dd") + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Room Billing: (" + cboBiller.Text + ") added to Room No: (" + RmNo.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void insTenantBill(int cId,string Biller,decimal Amt,string bDue) 
        {
            try 
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime Per = dtPeriod.Value;
                DateTime BilDt = dtTo.Value;

                if (conn.ServerConn()) 
                {
                    rs = conn.MySql.Execute("call insTblTenantBills(" +
                                            cId + ",'" +
                                            Biller + "','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            Amt + ",'" +
                                            BilDt.ToString("yyyy-MM-dd") + "','" +
                                            bDue + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Billing: (" + Biller + ") added to cId: (" + cId.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void updTenantBill(int cId, string Biller, decimal Amt, string bDue)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime Per = dtPeriod.Value;
                DateTime BilDt = dtTo.Value;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updTblTenantBills(" +
                                            cId + ",'" +
                                            Biller + "','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            Amt + ",'" +
                                            BilDt.ToString("yyyy-MM-dd") + "','" +
                                            bDue + "','" +
                                            eToDt.ToString("yyyy-MM-dd") + "','" +
                                            eDueDt.ToString("yyyy-MM-dd") + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Billing: (" + Biller + ") updated for cId: (" + cId.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void GetRmTenant() 
        {
            try
            {
                int RmNo = Convert.ToInt32(cboRmNo.Text);

                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;
                decimal BedCnt;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getRmTenant(" + RmNo + ")", out ra, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        GetTeTotalDays();
                        decimal BillAmt = txtAmt.Value;
                        BedCnt = rs.RecordCount;

                        while (BedCnt != 0)
                        {

                            int ContId = Convert.ToInt32(rs.Fields["cId"].Value.ToString());
                            decimal Mfee = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                            DateTime MoveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime MoveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());

                            DateTime DtFrm = dtFrm.Value;
                            DateTime DtTo = dtTo.Value;
                            decimal BillTotalDay = Convert.ToDecimal((DtTo - DtFrm).TotalDays);
                            decimal InTotalDays = Convert.ToDecimal((DtTo - MoveIn).TotalDays);
                            decimal OutTotalDays = Convert.ToDecimal((MoveOut - DtFrm).TotalDays);

                            //if (MoveIn > DtFrm && BedCnt > 1)
                            if (MoveIn >= DtFrm && MoveIn < DtTo)
                            {
                                //decimal tBill = BillAmt / BedCnt;
                                //decimal tBillpd = tBill / BillTotalDay;

                                //decimal tBillAmt = tBillpd * InTotalDays;
                                decimal tBill = BillAmt / TenantTotalDays;
                                decimal tBillAmt = tBill * InTotalDays;
                                
                                if (tBillAmt <= 0) { }
                                else
                                {
                                    DateTime Duedt = dtDueDate.Value;
                                    insTenantBill(ContId, cboBiller.Text, tBillAmt, Duedt.ToString("yyyy-MM-dd"));
                                    //BillAmt = BillAmt - tBillAmt;
                                    BedCnt = BedCnt - 1;
                                }
                            }
                            else
                            {
                                //if (MoveOut < DtTo && BedCnt > 1)
                                if (MoveOut < DtTo && MoveOut > DtFrm)
                                {
                                    decimal tBill = BillAmt / TenantTotalDays;
                                    decimal tBillAmt = tBill * OutTotalDays;
                                    if (tBillAmt <= 0) { }
                                    else
                                    {
                                        DateTime Duedt = dtDueDate.Value;
                                        insTenantBill(ContId, cboBiller.Text, tBillAmt, Duedt.ToString("yyyy-MM-dd"));
                                        //BillAmt = BillAmt - tBillAmt;
                                        BedCnt = BedCnt - 1;
                                    }
                                }
                                else 
                                {
                                    if (MoveIn < DtTo && MoveIn <= DtFrm && MoveOut > DtTo && MoveOut > DtFrm)
                                    {
                                        //decimal tBill = BillAmt / BedCnt;
                                        decimal tBill = BillAmt / TenantTotalDays;
                                        decimal tBillAmt = tBill * BillTotalDay;
                                        DateTime Duedt = dtDueDate.Value;

                                        //insTenantBill(ContId, cboBiller.Text, tBill, Duedt.ToString("yyyy-MM-dd"));
                                        insTenantBill(ContId, cboBiller.Text, tBillAmt, Duedt.ToString("yyyy-MM-dd"));
                                        //BillAmt = BillAmt - tBill;
                                        BedCnt = BedCnt - 1;
                                    }
                                    else 
                                    {
                                        BedCnt = BedCnt - 1;
                                    }
                                }
                            }

                            rs.MoveNext();
                        }

                        wc.WaitCurFalse();

                        MessageBox.Show("Room billing is successfully saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void GetTeTotalDays() 
        {
            try
            {
                int RmNo = Convert.ToInt32(cboRmNo.Text);

                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;
                decimal BedCnt;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getRmTenant(" + RmNo + ")", out ra, (int)CommandTypeEnum.adCmdText);

                    
                    if (rs.EOF == false)
                    {
                        decimal BillAmt = txtAmt.Value;
                        BedCnt = rs.RecordCount;

                        while (BedCnt != 0)
                        {

                            int ContId = Convert.ToInt32(rs.Fields["cId"].Value.ToString());
                            DateTime MoveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime MoveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());

                            DateTime DtFrm = dtFrm.Value;
                            DateTime DtTo = dtTo.Value;

                            decimal BillTotalDay = Convert.ToDecimal((DtTo - DtFrm).TotalDays);
                            decimal InTotalDays = Convert.ToDecimal((DtTo - MoveIn).TotalDays);
                            decimal OutTotalDays = Convert.ToDecimal((MoveOut - DtFrm).TotalDays);

                            if (MoveIn >= DtFrm && MoveIn < DtTo)
                            {
                                TenantTotalDays = TenantTotalDays + InTotalDays;
                                BedCnt = BedCnt - 1;
                            }
                            else
                            {
                                //if (MoveOut < DtTo && BedCnt > 1)
                                if (MoveOut < DtTo && MoveOut > DtFrm) 
                                {
                                    TenantTotalDays = TenantTotalDays + OutTotalDays;
                                    BedCnt = BedCnt - 1;
                                }
                                else
                                {
                                    if (MoveIn < DtTo && MoveIn <= DtFrm && MoveOut > DtTo && MoveOut > DtFrm) 
                                    {
                                        TenantTotalDays = TenantTotalDays + BillTotalDay;
                                        BedCnt = BedCnt - 1;
                                    }
                                    else
                                    {
                                        BedCnt = BedCnt - 1;
                                    }
                                }
                            }
                            rs.MoveNext();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void GetUpdRmTenant()
        {
            try
            {
                int RmNo = Convert.ToInt32(cboRmNo.Text);

                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;
                decimal BedCnt;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call getRmTenant(" + RmNo + ")", out ra, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        GetTeTotalDays();
                        decimal BillAmt = txtAmt.Value;
                        BedCnt = rs.RecordCount;

                        while (BedCnt != 0)
                        {

                            int ContId = Convert.ToInt32(rs.Fields["cId"].Value.ToString());
                            DateTime MoveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime MoveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());

                            DateTime DtFrm = dtFrm.Value;
                            DateTime DtTo = dtTo.Value;
                            decimal BillTotalDay = Convert.ToDecimal((DtTo - DtFrm).TotalDays);
                            decimal InTotalDays = Convert.ToDecimal((DtTo - MoveIn).TotalDays);
                            decimal OutTotalDays = Convert.ToDecimal((MoveOut - DtFrm).TotalDays);

                            if (MoveIn >= DtFrm && MoveIn < DtTo)
                            {
                                //decimal tBill = BillAmt / BedCnt;
                                //decimal tBillpd = tBill / BillTotalDay;

                                //decimal tBillAmt = tBillpd * InTotalDays;
                                decimal tBill = BillAmt / TenantTotalDays;
                                decimal tBillAmt = tBill * InTotalDays;

                                if (tBillAmt <= 0) { }
                                else
                                {
                                    DateTime Duedt = dtDueDate.Value;
                                    updTenantBill(ContId, cboBiller.Text, tBillAmt, Duedt.ToString("yyyy-MM-dd"));
                                    //BillAmt = BillAmt - tBillAmt;
                                    BedCnt = BedCnt - 1;
                                }
                            }
                            else
                            {
                                //if (MoveOut < DtTo && BedCnt > 1)
                                if (MoveOut < DtTo && MoveOut > DtFrm)
                                {
                                    decimal tBill = BillAmt / TenantTotalDays;
                                    decimal tBillAmt = tBill * OutTotalDays;
                                    if (tBillAmt <= 0) { }
                                    else
                                    {
                                        DateTime Duedt = dtDueDate.Value;
                                        updTenantBill(ContId, cboBiller.Text, tBillAmt, Duedt.ToString("yyyy-MM-dd"));
                                        //BillAmt = BillAmt - tBillAmt;
                                        BedCnt = BedCnt - 1;
                                    }
                                }
                                else
                                {
                                    if (MoveIn < DtTo && MoveIn <= DtFrm && MoveOut > DtTo && MoveOut > DtFrm)
                                    {
                                        //decimal tBill = BillAmt / BedCnt;
                                        decimal tBill = BillAmt / TenantTotalDays;
                                        decimal tBillAmt = tBill * BillTotalDay;
                                        DateTime Duedt = dtDueDate.Value;

                                        //insTenantBill(ContId, cboBiller.Text, tBill, Duedt.ToString("yyyy-MM-dd"));
                                        updTenantBill(ContId, cboBiller.Text, tBillAmt, Duedt.ToString("yyyy-MM-dd"));
                                        //BillAmt = BillAmt - tBill;
                                        BedCnt = BedCnt - 1;
                                    }
                                    else
                                    {
                                        BedCnt = BedCnt - 1;
                                    }
                                }
                            }

                            rs.MoveNext();
                        }

                        wc.WaitCurFalse();

                        MessageBox.Show("Room billing is successfully updated!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
