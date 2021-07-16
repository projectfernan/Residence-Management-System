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
    public partial class frmNewContractRec : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        int Id;

        public frmNewContractRec()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewContract shw = new frmNewContract();
            shw.ShowDialog();
        }

        private void frmNewContractRec_Load(object sender, EventArgs e)
        {
            header();
            Thread th = new Thread(() =>
            {
                Action act = new Action(fill);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        public void header()
        {
            lstRec.Clear();
            lstRec.Columns.Add("Id", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("ContractName", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("ContractType", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("MonhtlyFee", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("ContractPeriod", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("ReserveFee", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("ReserveFeeAmt", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("ReserveCoverageMonth", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("SecurityDeposit", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("SecurityDepositAmt", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("DepositCoverageMonth", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("WholeStayPayment", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("WholeStayPaymentAmt", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("FullTermPayment", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("", 0, HorizontalAlignment.Left);
            lstRec.Columns.Add("PostDatedCheck", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("ContractSigning", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("TenantSign", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("GuardianSign", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("TenantId", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("GuardianId", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("KeyCardDeposit", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("KeyCardDepositAmt", 90, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("",0, HorizontalAlignment.Left);
            lstRec.Columns.Add("", 0, HorizontalAlignment.Left);
            lstRec.Columns.Add("Status", 90, HorizontalAlignment.Left);
        }

        public void fill()
        {
            try
            {
                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblcontract", out rc, (int)CommandTypeEnum.adCmdText);
                    //rs.Open("select * from tblcontract", conn.MySql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
                    if (rs.EOF == false)
                    {

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstRec.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstRec.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["MonthlyFee"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractPeriod"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveFee"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveFeeAmt"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveCoverageMonth"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveCash"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveOnline"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveCheck"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["SecurityDepo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["SecurityDepoAmt"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DepoCoverage"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DepoCash"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DepoOnline"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DepoCheck"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["WholeStayPayment"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["WholeStayPaymentAmt"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsFullTermPay"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsCash"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsCheck"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsOnline"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsPDC"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractSigning"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["TenantSign"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["GuardianSign"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["TenantId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["GuardianId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["KeyCardDepo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["KeyCardDepoAmt"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["kcdCash"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["kcdCheck"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["kcdOnline"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Status"].Value.ToString());

                            rs.MoveNext();
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void find()
        {
            try
            {
                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblcontract where " + cboCateg.Text + " like '" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
                    //rs.Open("select * from tblcontract", conn.MySql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstRec.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstRec.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["MonthlyFee"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractPeriod"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveFee"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveFeeAmt"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveCoverageMonth"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveCash"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveOnline"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ReserveCheck"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["SecurityDepo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["SecurityDepoAmt"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DepoCoverage"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DepoCash"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DepoOnline"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["DepoCheck"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["WholeStayPayment"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["WholeStayPaymentAmt"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsFullTermPay"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsCash"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsCheck"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsOnline"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["wsPDC"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractSigning"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["TenantSign"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["GuardianSign"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["TenantId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["GuardianId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["KeyCardDepo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["KeyCardDepoAmt"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["kcdCash"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["kcdCheck"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["kcdOnline"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Status"].Value.ToString());

                            rs.MoveNext();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            header();
            fill();
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            header();

            Thread th = new Thread(() =>
            {
                Action act = new Action(find);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {   
            frmNewContract shw = new frmNewContract();
            BoolConvert Bool = new BoolConvert();

            shw.Tag = "Update Contract Setting";
            shw.Btn = "Update";

            shw.EdtContractName = lstRec.SelectedItems[0].SubItems[1].Text;
            shw.EdtContractType = lstRec.SelectedItems[0].SubItems[2].Text;
            shw.EdtMonthlyFee = Convert.ToDecimal(lstRec.SelectedItems[0].SubItems[3].Text);
            shw.EdtContractPeriod = Convert.ToDecimal(lstRec.SelectedItems[0].SubItems[4].Text);
        
            shw.EdtChkRf = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[5].Text);
            shw.EdtRfAmt = Convert.ToDecimal(lstRec.SelectedItems[0].SubItems[6].Text);
            shw.EdtRfCoverage = Convert.ToDecimal(lstRec.SelectedItems[0].SubItems[7].Text);
            shw.EdtRfCash = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[8].Text);
            shw.EdtRfOL = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[9].Text);
            shw.EdtRfChek = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[10].Text);

            shw.EdtChkSd = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[11].Text);
            shw.EdtSdAmt = Convert.ToDecimal(lstRec.SelectedItems[0].SubItems[12].Text);
            shw.EdtSdCoverage = Convert.ToDecimal(lstRec.SelectedItems[0].SubItems[13].Text);
            shw.EdtSdCash = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[14].Text);
            shw.EdtSdOL = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[15].Text);
            shw.EdtSdChek = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[16].Text);

            shw.EdtWspChk = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[17].Text);
            shw.EdtWspAmt = Convert.ToDecimal(lstRec.SelectedItems[0].SubItems[18].Text);
            shw.EdtWspFP = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[19].Text);
            shw.EdtWspFPcash = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[20].Text);
            shw.EdtWspFPcheck = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[21].Text);
            shw.EdtWspFPonline = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[22].Text);
            shw.EdtWspPDC = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[23].Text);

            shw.EdtCSchk = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[24].Text);
            shw.EdtTenantID = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[25].Text);
            shw.EdtGuardianID = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[26].Text);
            shw.EdtTenantSign = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[27].Text);
            shw.EdtGuardianSign = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[28].Text);

            shw.EdtKcdChk = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[29].Text);
            shw.EdtKcdAmt = Convert.ToDecimal(lstRec.SelectedItems[0].SubItems[30].Text);
            shw.EdtKcdCash = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[31].Text);
            shw.EdtKcdCheck = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[32].Text);
            shw.EdtKcdOL = Bool.BoolConv(lstRec.SelectedItems[0].SubItems[33].Text);
            
            shw.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure do you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (del == DialogResult.Yes) {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object d;

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("call delTblContract('" + lstRec.SelectedItems[0].SubItems[1].Text + "')", out d, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Contract: (" + lstRec.SelectedItems[0].SubItems[1].Text + ") deleted.");
                    
                    header();
                    fill();
                }
               
            }
        }

        private void frmNewContractRec_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmNewContractRec_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmNewContractRec_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(HideCont);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void HideCont() 
        {
            try
            {   
                if (lstRec.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select the contract record setting that you want to hide!","Hide",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                DialogResult ys = MessageBox.Show("Are you sure do you want to hide this contract setting?","Hide",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != ys)
                {
                    return;
                }

                string Stat = lstRec.SelectedItems[0].SubItems[34].Text;
                if (Stat == "Hidden")
                {
                    MessageBox.Show("This contract setting is already hidden!", "Hide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Id = Convert.ToInt32(  lstRec.SelectedItems[0].SubItems[0].Text);

                DBconn conn = new DBconn();
                string Hide = "call updHideCont(" + Id + ",'Hidden')";
                if (conn.rsCUD(Hide)) 
                {
                    string ContName = lstRec.SelectedItems[0].SubItems[1].Text;
                    MessageBox.Show("Contract setting: " + ContName + " is successfully hidden!","Hide",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(ActivateCont);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void ActivateCont()
        {
            try
            {
                if (lstRec.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select the contract record setting that you want to activate!", "Activate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult ys = MessageBox.Show("Are you sure do you want to activate this contract setting?", "Activate", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != ys)
                {
                    return;
                }

                string Stat = lstRec.SelectedItems[0].SubItems[34].Text;
                if (Stat == "Active") 
                {
                    MessageBox.Show("This contract setting is already active!","Activate",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                Id = Convert.ToInt32(lstRec.SelectedItems[0].SubItems[0].Text);

                DBconn conn = new DBconn();
                string Hide = "call updHideCont(" + Id + ",'Active')";
                if (conn.rsCUD(Hide))
                {
                    string ContName = lstRec.SelectedItems[0].SubItems[1].Text;
                    MessageBox.Show("Contract setting: " + ContName + " is successfully activated!", "Activate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
