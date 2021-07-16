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

namespace prjRMS
{
    

    public partial class frmNewContract : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();


        public string Tag, Btn;
        public string EdtContractName,EdtContractType;
        public decimal EdtContractPeriod, EdtMonthlyFee;
        public decimal EdtRfAmt, EdtRfCoverage;
        public bool EdtChkRf, EdtRfCash, EdtRfOL,EdtRfChek;
        public decimal EdtSdAmt, EdtSdCoverage;
        public bool EdtChkSd, EdtSdCash, EdtSdOL, EdtSdChek;
        public decimal EdtWspAmt;
        public bool EdtWspChk, EdtWspFP, EdtWspPDC;
        public bool EdtWspFPcash, EdtWspFPcheck, EdtWspFPonline;
        public decimal EdtKcdAmt;
        public bool EdtKcdChk, EdtKcdCash, EdtKcdOL, EdtKcdCheck;
        public bool EdtCSchk, EdtTenantSign, EdtGuardianSign, EdtTenantID, EdtGuardianID;

        public frmNewContract()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkRF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRF.Checked == true)
            {
                pRF.Enabled = true;
            }
            else
            {
                txtRfCoverage.Value = 0;
                txtRfAmt.Value = 0;
                chkRfCash.Checked = false;
                chkRfOnline.Checked = false;
                chkRfCheck.Checked = false;
                pRF.Enabled = false;
            }
        }

        private void chkSD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSD.Checked == true)
            {
                pSD.Enabled = true;
            }
            else {
                txtSdCoverage.Value = 0;
                txtSdAmt.Value = 0;
                chkSdCash.Checked = false;
                chkSdOnline.Checked = false;
                chkSdCheck.Checked = false;
                pSD.Enabled = false;
            }
        }

        private void chkWSP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWSP.Checked == true)
            {
                decimal Fee = txtMonthlyFee.Value;
                decimal RfC = txtRfCoverage.Value;
                decimal Cp = txtContractPer.Value;
                decimal WspC = Cp - RfC;

                decimal WspAmt = Fee * WspC;
                txtWspAmt.Value = WspAmt;

                pWSP.Enabled = true;
            }
            else {
                txtWspAmt.Value = 0;
                chkWspFullP.Checked = false;
                chkWspFullPcash.Checked = false;
                chkWspFullPcheck.Checked = false;
                chkWspPDC.Checked = false;
                pWSP.Enabled = false;
            }
        }

        private void chkKeyCard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeyCard.Checked == true)
            {
                pKCD.Enabled = true;
            }
            else {
                txtKCDamt.Value = 0;
                chkKcdCash.Checked = false;
                chkKcdCheck.Checked = false;
                chkKcdOnline.Checked = false;
                pKCD.Enabled = false;
            }
        }

        private void chkSigning_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSigning.Checked == true)
            {
                pCS.Enabled = true;
            }
            else
            {
                chkCsTenantSign.Checked = false;
                chkCsGuardianSign.Checked = false;
                chkCsTenantID.Checked = false;
                chkCsGuardianID.Checked = false;
                pCS.Enabled = false;
            }
        }

        private void chkWspFullP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWspFullP.Checked == true)
            {
                pWspFullP.Enabled = true;
            }
            else {
                chkWspFullPcash.Checked = false;
                chkWspFullPcheck.Checked = false;
                chkWspFullPonline.Checked = false;
                pWspFullP.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (btnSave.Text) { 
                case "Save":
                        DialogResult Res = MessageBox.Show("Are you sure that your entries are correct?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Res == DialogResult.Yes) 
                        {
                            if (chkExist(txtContractName.Text) == false)
                            {
                                if (txtContractName.Text == "")
                                {
                                    MessageBox.Show("Please input contract name!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtContractName.Focus();
                                }
                                else 
                                {
                                    Audit aud = new Audit();
                                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Contract: (" + txtContractName.Text + ") created.");

                                    Save();
                                }
                            }
                            else 
                            {
                                MessageBox.Show("Contract name already exist!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                
                        }
                    break;
                case "Update":
                        DialogResult Upd = MessageBox.Show("Are you sure do you want to save changes?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Upd == DialogResult.Yes) 
                        {
                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Contract: (" + txtContractName.Text + ") updated.");

                            Update();   
                        }
                    break;
            }

             
        }

        private bool chkExist(string ConName) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object rc;
                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select ContractName from tblcontract where ContractName = '" + ConName + "'", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            catch (Exception ex) {
                return false;   
            }
        }

        private void Save()
        {
            try
            {
                DBconn conn = new DBconn();
                if (conn.ServerConn() == true) {
                    Recordset rs = new Recordset();
                    object ra;
                    rs = conn.MySql.Execute("insert into tblcontract(ContractName,ContractType,MonthlyFee,ContractPeriod,ReserveFee," +
                        "ReserveFeeAmt,ReserveCoverageMonth,ReserveCash,ReserveOnline,ReserveCheck,SecurityDepo,SecurityDepoAmt," +
                        "DepoCoverage,DepoCash,DepoOnline,DepoCheck,WholeStayPayment,WholeStayPaymentAmt,wsFullTermPay,wsCash,wsCheck,wsOnline,wsPDC," + 
                        "ContractSigning,TenantSign,GuardianSign,TenantId,GuardianId,KeyCardDepo,KeyCardDepoAmt,kcdCash,kcdCheck,kcdOnline)VALUES(" + 
                        "'" + txtContractName.Text +
                        "','" + cboContractType.Text + 
                        "'," + txtMonthlyFee.Value + 
                        "," + txtContractPer.Value + 

                        "," + Convert.ToInt32(chkRF.Checked) + 
                        "," + txtRfAmt.Value + 
                        "," + txtRfCoverage.Value + 
                        "," + Convert.ToInt32(chkRfCash.Checked) + 
                        "," + Convert.ToInt32(chkRfOnline.Checked) + 
                        "," + Convert.ToInt32(chkRfCheck.Checked) + 

                        "," + Convert.ToInt32(chkSD.Checked) + 
                        "," + txtSdAmt.Value +
                        "," + txtSdCoverage.Value + 
                        "," + Convert.ToInt32(chkSdCash.Checked) +
                        "," + Convert.ToInt32(chkSdOnline.Checked) + 
                        "," + Convert.ToInt32(chkSdCheck.Checked) + 

                        "," + Convert.ToInt32(chkWSP.Checked) +
                        "," + txtWspAmt.Value +
                        "," + Convert.ToInt32(chkWspFullP.Checked) + 
                        "," + Convert.ToInt32(chkWspFullPcash.Checked) + 
                        "," + Convert.ToInt32(chkWspFullPcheck.Checked) +
                        "," + Convert.ToInt32(chkWspFullPonline.Checked) + 
                        "," + Convert.ToInt32(chkWspPDC.Checked) +

                        "," + Convert.ToInt32(chkSigning.Checked) + 
                        "," + Convert.ToInt32(chkCsTenantSign.Checked) + 
                        "," + Convert.ToInt32(chkCsGuardianSign.Checked) +
                        "," + Convert.ToInt32(chkCsTenantID.Checked) + 
                        "," + Convert.ToInt32(chkCsGuardianID.Checked) +

                        "," + Convert.ToInt32(chkKeyCard.Checked) +
                        "," + txtKCDamt.Value +
                        "," + Convert.ToInt32(chkKcdCash.Checked) + 
                        "," + Convert.ToInt32(chkKcdCheck.Checked) +
                        "," + Convert.ToInt32(chkKcdOnline.Checked) + 
                        ")", out ra, (int)CommandTypeEnum.adCmdText);

                    MessageBox.Show("Successfully saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Update()
        {
            try
            {
                DBconn conn = new DBconn();
                if (conn.ServerConn() == true)
                {
                    Recordset rs = new Recordset();
                    object ra;
                    rs = conn.MySql.Execute("call updTblContract('" + EdtContractName + "','" + txtContractName.Text + "','" + cboContractType.Text + "'" +
                        "," + txtMonthlyFee.Value +
                        "," + txtContractPer.Value +

                        "," + Convert.ToInt32(chkRF.Checked) +
                        "," + txtRfAmt.Value +
                        "," + txtRfCoverage.Value +
                        "," + Convert.ToInt32(chkRfCash.Checked) +
                        "," + Convert.ToInt32(chkRfOnline.Checked) +
                        "," + Convert.ToInt32(chkRfCheck.Checked) +

                        "," + Convert.ToInt32(chkSD.Checked) +
                        "," + txtSdAmt.Value +
                        "," + txtSdCoverage.Value +
                        "," + Convert.ToInt32(chkSdCash.Checked) +
                        "," + Convert.ToInt32(chkSdOnline.Checked) +
                        "," + Convert.ToInt32(chkSdCheck.Checked) +

                        "," + Convert.ToInt32(chkWSP.Checked) +
                        "," + txtWspAmt.Value +
                        "," + Convert.ToInt32(chkWspFullP.Checked) +
                        "," + Convert.ToInt32(chkWspFullPcash.Checked) +
                        "," + Convert.ToInt32(chkWspFullPcheck.Checked) +
                        "," + Convert.ToInt32(chkWspPDC.Checked) +

                        "," + Convert.ToInt32(chkSigning.Checked) +
                        "," + Convert.ToInt32(chkCsTenantSign.Checked) +
                        "," + Convert.ToInt32(chkCsGuardianSign.Checked) +
                        "," + Convert.ToInt32(chkCsTenantID.Checked) +
                        "," + Convert.ToInt32(chkCsGuardianID.Checked) +

                        "," + Convert.ToInt32(chkKeyCard.Checked) +
                        "," + txtKCDamt.Value +
                        "," + Convert.ToInt32(chkKcdCash.Checked) +
                        "," + Convert.ToInt32(chkKcdCheck.Checked) +
                        "," + Convert.ToInt32(chkKcdOnline.Checked) +
                        "," + Convert.ToInt32(chkWspFullPonline.Checked) +
                        ")", out ra, (int)CommandTypeEnum.adCmdText);

                    MessageBox.Show("Successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRfCoverage_ValueChanged(object sender, EventArgs e)
        {
            decimal Fee = txtMonthlyFee.Value;
            decimal RfC = txtRfCoverage.Value;
            decimal RfAmt = Fee * RfC;

            txtRfAmt.Value = RfAmt;
        }

        private void txtRfCoverage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                decimal Fee = txtMonthlyFee.Value;
                decimal RfC = txtRfCoverage.Value;
                decimal RfAmt = Fee * RfC;

                txtRfAmt.Value = RfAmt;
            }
        }

        private void txtSdCoverage_ValueChanged(object sender, EventArgs e)
        {
            decimal Fee = txtMonthlyFee.Value;
            decimal SdC = txtSdCoverage.Value;
            decimal SdAmt = Fee * SdC;

            txtSdAmt.Value = SdAmt;

        }

        private void txtSdCoverage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) {
                decimal Fee = txtMonthlyFee.Value;
                decimal SdC = txtSdCoverage.Value;
                decimal SdAmt = Fee * SdC;

                txtSdAmt.Value = SdAmt;
            }
        }

        private void frmNewContract_Load(object sender, EventArgs e)
        {
            if (Tag != null && Btn != null)
            {
                //txtContractName.ReadOnly = false;
                lbTitle.Text = Tag;
                btnSave.Text = Btn;
            }
            else {
                //txtContractName.ReadOnly = true;
                lbTitle.Text = "New Contract Setting";
                btnSave.Text = "Save";
            }

            txtContractName.Text = EdtContractName;
            cboContractType.Text = EdtContractType;
            txtContractPer.Value = EdtContractPeriod;
            txtMonthlyFee.Value = EdtMonthlyFee;

            txtRfCoverage.Value = EdtRfCoverage;
            txtRfAmt.Value = EdtRfAmt;
            chkRF.Checked = EdtChkRf;
            chkRfCash.Checked = EdtRfCash;
            chkRfOnline.Checked = EdtRfOL;
            chkRfCheck.Checked = EdtRfChek;

            txtSdCoverage.Value = EdtSdCoverage;
            txtSdAmt.Value = EdtSdAmt;
            chkSD.Checked = EdtChkSd;
            chkSdCash.Checked = EdtSdCash;
            chkSdOnline.Checked = EdtSdOL;
            chkSdCheck.Checked = EdtSdChek;

            txtWspAmt.Value = EdtWspAmt;
            chkWSP.Checked = EdtWspChk;
            chkWspFullP.Checked = EdtWspFP;
            chkWspFullPcash.Checked = EdtWspFPcash;
            chkWspFullPcheck.Checked = EdtWspFPcheck;
            chkWspFullPonline.Checked = EdtWspFPonline;
            chkWspPDC.Checked = EdtWspPDC;

            txtKCDamt.Value = EdtKcdAmt;
            chkKeyCard.Checked = EdtKcdChk;
            chkKcdCash.Checked = EdtKcdCash;
            chkKcdCheck.Checked = EdtKcdCheck;
            chkKcdOnline.Checked = EdtKcdOL;

            chkSigning.Checked = EdtCSchk;
            chkCsTenantID.Checked = EdtTenantID;
            chkCsGuardianID.Checked = EdtGuardianID;
            chkCsTenantSign.Checked = EdtTenantSign;
            chkCsGuardianSign.Checked = EdtGuardianSign;  
        }

        private void cboContractType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmNewContract_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmNewContract_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmNewContract_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
