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
    public partial class frmAddBills : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string wLoad;
        public int CID;
        public string bName;
        public decimal bAmt;
        public DateTime bPer, bBillDate, bDueDate;

        public frmAddBills()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddBills_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmAddBills_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmAddBills_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmAddBills_Load(object sender, EventArgs e)
        {
            //if (wLoad == "Edit")
            //{
            //    cboBiller.Enabled = false;
            //    cboBiller.Text = bName;
            //    txtAmt.Value = bAmt;
            //    dtPeriod.Value = bPer;
            //    dtBillDate.Value = bBillDate;
            //    dtDueDate.Value = bDueDate;
            //}
            //else 
            //{
                loadCont(cboBiller);

                DateTime now = DateTime.Now;
                dtPeriod.Value = now.AddDays(1 - now.Day);
            //}
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
                    rs = conn.MySql.Execute("select Miscellaneous,Amount from tblmiscellaneous where Status = 'Active' order by Miscellaneous", out ra, (int)CommandTypeEnum.adCmdText);
                    while (rs.EOF == false)
                    {
                        cbo.Items.Add(rs.Fields["Miscellaneous"].Value.ToString());
                        rs.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboBiller_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAmt.Value = MisceAmt(cboBiller.Text);
        }

        decimal MisceAmt(string Misce) 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select Amount from tblmiscellaneous where Miscellaneous = '" + Misce + "'", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        decimal amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                        return amt;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult s = MessageBox.Show("Are you sure that your entries are correct?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (s != DialogResult.Yes)
            {
                return;
            }

            Thread th = new Thread(() =>
            {
                Action act = new Action(NewTenantBill);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void NewTenantBill() 
        {
            DateTime BillDt = dtBillDate.Value;

            //if (chkTenantBill(CID, cboBiller.Text, BillDt.ToString("yyyy-MM-dd")) == true)
            //{
            //    MessageBox.Show("This billing is already added!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            DateTime DueDt = dtDueDate.Value;

            insTenantBill(CID, cboBiller.Text, txtAmt.Value, DueDt.ToString("yyyy-MM-dd"));
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

        void insTenantBill(int cId, string Biller, decimal Amt, string bDue)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime Per = dtPeriod.Value;
                DateTime bilDate = dtBillDate.Value;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblTenantBills(" +
                                            cId + ",'" +
                                            Biller + "','" +
                                            Per.ToString("MMMM yyyy") + "'," +
                                            Amt + ",'" +
                                            bilDate.ToString("yyyy-MM-dd") + "','" +
                                            bDue + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Billing Miscellaneous: (" + Biller + ") added to cId: (" + cId.ToString() + ")");

                    MessageBox.Show("New billing successfully added!","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
