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
using System.Threading.Tasks;

namespace prjRMS
{
    public partial class frmAddContract : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string wLoad;
        public string ContType,ContName;
        public int tId,cId;
        public string tName, tGender, tAge, tRem, tStartDt,tEndDt,tMoveInDt;
        public int RF,SC,WSP,KCD,ContSigning;
        public decimal oldSecDepo;
        decimal secDepoAmt;

        public frmAddContract()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddContract_Load(object sender, EventArgs e)
        {
            lbTenantName.Text = tName;
            lbGender.Text = tGender;
            lbAge.Text = tAge + " y/o";
            lbRemarks.Text = tRem;

            if (wLoad == "Edit")
            {
                btnSave.Text = "Update";
                lbTitle.Text = "Update Tenant's Contract";
                dtStart.Value = Convert.ToDateTime(tStartDt);
                dtEnd.Value = Convert.ToDateTime(tEndDt);
                cboContract.Text = ContName;
                GetContract(ContName);
            }

            if (ContType == "Extension")
            {
                dtStart.Value = Convert.ToDateTime(tStartDt);
                dtStart.Enabled = false;
                //dtMoveIn.Value = Convert.ToDateTime(tStartDt);
                //dtMoveIn.Enabled = false;
                dtEnd.Value = Convert.ToDateTime(tEndDt);
            }
            else 
            {
                dtStart.Enabled = true;
                //dtMoveIn.Enabled = true;
            }

            loadCont(cboContract);
        }

        public void loadCont(ComboBox cbo){
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    cbo.Items.Clear();
                    rs = conn.MySql.Execute("select ContractName from tblcontract where ContractType = '" + ContType + "' and Status = 'Active' order by ContractName", out ra, (int)CommandTypeEnum.adCmdText);
                    while (rs.EOF == false)
                    {
                        cbo.Items.Add(rs.Fields["ContractName"].Value.ToString());
                        rs.MoveNext();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cboContract_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void GetContract(string Cont) 
        {
            try {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;
                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("select ContractPeriod,MonthlyFee,ReserveFeeAmt,SecurityDepoAmt,WholeStayPaymentAmt,KeyCardDepoAmt," +
                                        "TenantId,GuardianId,GuardianSign,ReserveFee,SecurityDepo,WholeStayPayment,KeyCardDepo," + 
                                        "ContractSigning from tblcontract where ContractName = '" + Cont + "'", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        MakeMoney cur = new MakeMoney();
                        lbContPer.Text = rs.Fields["ContractPeriod"].Value.ToString() + " Months";
                        lbMonthlyFee.Text = cur.Currency(Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString()));
                        lbReserveFee.Text = cur.Currency(Convert.ToDecimal(rs.Fields["ReserveFeeAmt"].Value.ToString()));
                        lbSecDepo.Text = cur.Currency(Convert.ToDecimal(rs.Fields["SecurityDepoAmt"].Value.ToString()));
                        lbWsp.Text = cur.Currency(Convert.ToDecimal(rs.Fields["WholeStayPaymentAmt"].Value.ToString()));
                        lbKeyCardDepo.Text = cur.Currency(Convert.ToDecimal(rs.Fields["KeyCardDepoAmt"].Value.ToString()));
                        RF = Convert.ToInt32(rs.Fields["ReserveFee"].Value.ToString());
                        SC = Convert.ToInt32(rs.Fields["SecurityDepo"].Value.ToString());
                        WSP = Convert.ToInt32(rs.Fields["WholeStayPayment"].Value.ToString());
                        KCD = Convert.ToInt32(rs.Fields["KeyCardDepo"].Value.ToString());
                        ContSigning = Convert.ToInt32(rs.Fields["ContractSigning"].Value.ToString());

                        if (rs.Fields["TenantId"].Value.ToString() == "1")
                        {
                            lbTenantID.Text = "Required";
                        }
                        else {
                            lbTenantID.Text = "Not Required";
                        }

                        if (rs.Fields["GuardianId"].Value.ToString() == "1")
                        {
                            lbGuardianID.Text = "Required";
                        }
                        else
                        {
                            lbGuardianID.Text = "Not Required";
                        }

                        if (rs.Fields["GuardianSign"].Value.ToString() == "1")
                        {
                            lbParentSign.Text = "Required";
                        }
                        else
                        {
                            lbParentSign.Text = "Not Required";
                        }

                        if (ContType == "Extension" || ContType == "Adjustment")
                        {
                            int M = Convert.ToInt32(rs.Fields["ContractPeriod"].Value.ToString());
                            DateTime StartDate = Convert.ToDateTime(tEndDt);
                            StartDate = StartDate.AddMonths(M);
                            dtEnd.Value = StartDate;
                        }
                        else 
                        {
                            int M = Convert.ToInt32(rs.Fields["ContractPeriod"].Value.ToString());
                            DateTime StartDate = dtStart.Value;
                            StartDate = StartDate.AddMonths(M);
                            dtEnd.Value = StartDate;
                        }

                        
                    }
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboContract_SelectedValueChanged(object sender, EventArgs e)
        {
            GetContract(cboContract.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(wLoad)
            {
                case "Add":
                    DialogResult N = MessageBox.Show("Are you sure your entries are correct?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (N == DialogResult.Yes) 
                    {
                        Thread th = new Thread(() =>
                        {
                            Action act = new Action(insNewContract);
                            this.BeginInvoke(act);
                        });
                        th.Start();
                    }
                    break;
                case "Edit":
                    DialogResult U = MessageBox.Show("Are you sure do you want to save changes?","Update",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                    if (U == DialogResult.Yes) 
                    {
                        Thread th = new Thread(() =>
                        {
                            Action act = new Action(updContract);
                            this.BeginInvoke(act);
                        });
                        th.Start();
                    }
                    break;
            }    
        }

        void insNewContract() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime StartDt = dtStart.Value;
                DateTime EndDt = dtEnd.Value;
                DateTime MoveInDt = dtEnd.Value;

                switch (ContType) 
                {
                    case "New":
                        secDepoAmt = Convert.ToDecimal(lbSecDepo.Text);
                        MoveInDt = EndDt;
                        break;
                    case "Renew":
                        secDepoAmt = oldSecDepo + Convert.ToDecimal(lbSecDepo.Text);
                        MoveInDt = EndDt;
                        break;
                    case "Extension":
                        secDepoAmt = oldSecDepo + Convert.ToDecimal(lbSecDepo.Text);
                        MoveInDt = Convert.ToDateTime(tMoveInDt);
                        break;
                    case "Adjustment":
                        secDepoAmt = oldSecDepo + Convert.ToDecimal(lbSecDepo.Text);
                        MoveInDt = Convert.ToDateTime(tMoveInDt);
                        UpdContStat upd = new UpdContStat();
                        upd.UpdBhMoveOut(cId, DateTime.Now);
                        break;
                }

                if (conn.ServerConn()) 
                {
                    rs = conn.MySql.Execute("call insTblTenantContract(" +
                                            tId + ",'" +
                                            cboContract.Text + "','" +
                                            StartDt.ToString("yyyy-MM-dd") + "','" +
                                            EndDt.ToString("yyyy-MM-dd") + "','" +
                                            MoveInDt.ToString("yyyy-MM-dd") + "','" +
                                            EndDt.ToString("yyyy-MM-dd") + "'," +
                                            RF + "," +
                                            SC + "," +
                                            WSP + "," +
                                            KCD + "," +
                                            cId + ",'" + ContType + "'," + secDepoAmt + ")", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Contract (" + cboContract.Text + ") added to tenant (" + tName + ")");

                    MessageBox.Show("New contract succefully added!","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void updContract()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime StartDt = dtStart.Value;
                DateTime EndDt = dtEnd.Value;
                //DateTime MoveInDt = dtMoveIn.Value;

                switch (ContType)
                {
                    case "New":
                        secDepoAmt = Convert.ToDecimal(lbSecDepo.Text);
                        break;
                    case "Renew":
                        secDepoAmt = oldSecDepo + Convert.ToDecimal(lbSecDepo.Text);
                        break;
                    case "Extension":
                        secDepoAmt = oldSecDepo + Convert.ToDecimal(lbSecDepo.Text);
                        break;
                    case "Adjustment":
                        secDepoAmt = oldSecDepo + Convert.ToDecimal(lbSecDepo.Text);
                        break;
                }

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updTblTenantContract(" +
                                            cId + ",'" +
                                            cboContract.Text + "','" +
                                            StartDt.ToString("yyyy-MM-dd") + "','" +
                                            EndDt.ToString("yyyy-MM-dd") + "'," +
                                            RF + "," +
                                            SC + "," +
                                            WSP + "," +
                                            KCD + "," +
                                            cId + "," + secDepoAmt + ")", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Contract (" + cboContract.Text + ") updated for tenant (" + tName + ")");

                    MessageBox.Show("Contract succefully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddContract_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmAddContract_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmAddContract_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void cboContract_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
