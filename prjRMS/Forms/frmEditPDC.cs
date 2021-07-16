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
    public partial class frmEditPDC : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string wLoad;
        public int ContId,PdcId;
        public DateTime ePeriod,eCheckDt;
        public string eBank, eCheckNo, eInv;
        public decimal eAmt;
        
        public frmEditPDC()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditPDC_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmEditPDC_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmEditPDC_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmEditPDC_Load(object sender, EventArgs e)
        {
            if (wLoad == "Edit")
            {
                dtPeriod.Value = ePeriod;
                txtPdcBank.Text = eBank;
                txtPdcCheckNo.Text = eCheckNo;
                txtAmt.Value = eAmt;
                dtPdcCheck.Value = eCheckDt;
                txtInvPdc.Text = eInv;
            }
            else 
            {
                lbTitle.Text = "Add PDC";
                btnSubmit.Text = "Save";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (wLoad == "Edit")
            {
                DialogResult upd = MessageBox.Show("Are you sure do you want to save changes?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (upd != DialogResult.Yes)
                {
                    return;
                }

                Thread th2 = new Thread(() =>
                {
                    Action act = new Action(updTenantRent);
                    this.BeginInvoke(act);
                });
                th2.Start();

                Thread th = new Thread(() =>
                {
                    Action act = new Action(pdcUpdate);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
            else 
            {
                DialogResult Add = MessageBox.Show("Are you sure that all of your entries are correct?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Add != DialogResult.Yes)
                {
                    return;
                }

                Thread th = new Thread(() =>
                {
                    Action act = new Action(AddPDC);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        void pdcUpdate()
        {
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
                                            PdcId + ",'" +
                                            txtInvPdc.Text + "','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            txtAmt.Value + ",'" +
                                            txtPdcCheckNo.Text + "','" +
                                            txtPdcBank.Text + "','" +
                                            Pdchek.ToString("yyyy-MM-dd") + "');", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Update PDC Id: (" + PdcId.ToString() + ")");

                    MessageBox.Show("PDC record successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void updTenantRent()
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

                DateTime eM = ePeriod;
                string eDueDt = eM.ToString("yyyy") + "-" + eM.ToString("MM") + "-" + d;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updTblTenantBills(" +
                                            ContId + ",'" +
                                            "Monthly Rent','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            eAmt + ",'" +
                                            Per.ToString("yyyy-MM-dd") + "','" +
                                            mfDue + "','" +
                                            ePeriod.ToString("yyyy-MM-dd") + "','" +
                                            eDueDt + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Billing: (Monthly Rent) updated for cId: (" + ContId.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AddPDC() 
        {
            try
            {
                DateTime Per = dtPeriod.Value;
                DateTime PdcChek = dtPdcCheck.Value;

                string AddQuery = "call insTblPdc(" +
                                            ContId + ",'" +
                                            txtInvPdc.Text + "','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            txtAmt.Value + ",'" +
                                            txtPdcCheckNo.Text + "','" +
                                            txtPdcBank.Text + "','" +
                                            PdcChek.ToString("yyyy-MM-dd") + "','Check',0);";

                DBconn conn = new DBconn();
                if (conn.rsCUD(AddQuery)) 
                {
                    MessageBox.Show("New PDC successfully added!","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
