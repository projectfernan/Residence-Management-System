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
    public partial class frmBalTrans : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int cId, bId, RmNo;
        public string BilName, Tname, Amt, Bdate;

        public frmBalTrans()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBalTrans_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmBalTrans_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmBalTrans_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmBalTrans_Load(object sender, EventArgs e)
        {
            txtAmt.Text = Amt;
            txtBillName.Text = BilName;
            txtTenant.Text = Tname;

            HeaderPDC();
            GetFillPdc();
        }

        void HeaderPDC()
        {
            lstBills.Clear();
            int w = lstBills.Width / 3;
            int w2 = w / 2;
            int w3 = w2 / 2;
            int wN = w + w3;

            lstBills.Columns.Add("", 0, HorizontalAlignment.Left);
            lstBills.Columns.Add("Name", wN, HorizontalAlignment.Left);
            lstBills.Columns.Add("Bed", w3, HorizontalAlignment.Left);
            lstBills.Columns.Add("BillName", w, HorizontalAlignment.Left);
            lstBills.Columns.Add("Amount", w2, HorizontalAlignment.Left);
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

                    rs = conn.MySql.Execute("call slctBillTrans(" + cId + "," + RmNo + ",'" + BilName + "','" + Bdate + "')", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstBills.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstBills.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["BillName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Amount"].Value.ToString());
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

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            switch(btnTransfer.Text)
            {   
                case "Transfer Balance":
                        Thread th = new Thread(() =>
                        {
                            Action act = new Action(TranferAmt);
                            this.BeginInvoke(act);
                        });
                        th.Start();
                    break;
                case "Finish":
                    this.Close();
                    break;
            }
        }

        void updAmt(int bId, decimal TransAmt)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("update tbltenantbills set Amount = " + TransAmt + " where Id = " + bId, out ra, (int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void TranferAmt()
        {
            try
            {
                if (lstBills.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a record that you want to transfer your balance amount!", "Transfer Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTransAmt.Value == 0)
                {
                    MessageBox.Show("Please enter your desired amount to transfer!", "Transfer Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTransAmt.Focus();
                    return;
                }

                MakeMoney cur = new MakeMoney();
                string Tname = lstBills.SelectedItems[0].SubItems[1].Text;

                decimal transAmt = Convert.ToDecimal(txtAmt.Text);
                decimal frmAmt = txtTransAmt.Value;
                decimal toAmt = Convert.ToDecimal(lstBills.SelectedItems[0].SubItems[4].Text);

                DialogResult ys = MessageBox.Show("Are you sure that you want to transfer to " + Tname + " the total amount of " + cur.Currency(frmAmt) + " from your balance amount?", "Trasfer Balance", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ys != DialogResult.Yes)
                {
                    return;
                }

                if (transAmt < frmAmt) 
                {
                    MessageBox.Show("The entered amount is exceeded in your balance amount!","Transfer Amount",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtTransAmt.Focus();
                    return;
                }

                decimal Diff = transAmt - frmAmt;
                decimal Sum = frmAmt + toAmt;

                updAmt(bId, Diff);
                int bId2 = Convert.ToInt32(lstBills.SelectedItems[0].SubItems[0].Text);
                updAmt(bId2, Sum);

                MessageBox.Show("Balance amount successully transferred!","Transfer Balance",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                Audit audb = new Audit();
                audb.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, txtTenant.Text + " transfer balance to " + Tname + "w/ amt of " + cur.Currency(frmAmt));
                
                txtAmt.Text = cur.Currency(Diff);
                HeaderPDC();
                GetFillPdc();
                btnTransfer.Text = "Finish";
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
