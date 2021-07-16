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
    public partial class frmRmBills : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        string bName, FrmDt, ToDt;

        public frmRmBills()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmRmBills_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmRmBills_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmRmBills_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            frmAddRmBills shw = new frmAddRmBills();
            shw.ShowDialog();
        }

        private void frmRmBills_Load(object sender, EventArgs e)
        {
            headerRoomBill();
            FillRmBills();

            btnEdit.Enabled = Properties.Settings.Default.EditRmBill;
        }

        void headerRoomBill()
        {
            lstResList.Clear();
            int w = lstResList.Width / 7;

            lstResList.Columns.Add("", 0, HorizontalAlignment.Left);
            lstResList.Columns.Add("Room No", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Biller Name", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Period", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Amount", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("From Date", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("To Date", w, HorizontalAlignment.Left);
            lstResList.Columns.Add("Due Date", w, HorizontalAlignment.Left);
        }

        void FillRmBills()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblmonthlybill order by Id desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            decimal fAmt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string Amt = p.Currency(fAmt);

                            DateTime frmDt = Convert.ToDateTime(rs.Fields["FromDate"].Value.ToString());
                            DateTime BillDt = Convert.ToDateTime(rs.Fields["ToDate"].Value.ToString());
                            DateTime DueDt = Convert.ToDateTime(rs.Fields["DueDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstResList.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["BillerName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Period"].Value.ToString());
                            viewlst.SubItems.Add(Amt);
                            viewlst.SubItems.Add(frmDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(BillDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(DueDt.ToString("yyyy-MM-dd"));
                            rs.MoveNext();
                        }
                        wc.WaitCurFalse();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void FindRmBills()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblmonthlybill where " + cboCateg.Text + " like '%" + txtKeycode.Text + "%' order by Id desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstResList.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            decimal fAmt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string Amt = p.Currency(fAmt);

                            DateTime frmDt = Convert.ToDateTime(rs.Fields["FromDate"].Value.ToString());
                            DateTime BillDt = Convert.ToDateTime(rs.Fields["ToDate"].Value.ToString());
                            DateTime DueDt = Convert.ToDateTime(rs.Fields["DueDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstResList.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["BillerName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Period"].Value.ToString());
                            viewlst.SubItems.Add(Amt);
                            viewlst.SubItems.Add(frmDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(BillDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(DueDt.ToString("yyyy-MM-dd"));
                            rs.MoveNext();
                        }

                        wc.WaitCurFalse();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            headerRoomBill();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillRmBills);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            headerRoomBill();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FindRmBills);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnSearch_Click(sender,e);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstResList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select billing record that you want to edit!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            updRmBill();
        }

        void updRmBill() 
        {
            try
            {
                frmAddRmBills shw = new frmAddRmBills();
                shw.rId = Convert.ToInt32(lstResList.SelectedItems[0].SubItems[0].Text);
                shw.eRmNo = lstResList.SelectedItems[0].SubItems[1].Text;
                shw.eBname = lstResList.SelectedItems[0].SubItems[2].Text;
                shw.ePer = Convert.ToDateTime(lstResList.SelectedItems[0].SubItems[3].Text);
                shw.eAmt = Convert.ToDecimal(lstResList.SelectedItems[0].SubItems[4].Text);
                shw.eFromDt = Convert.ToDateTime(lstResList.SelectedItems[0].SubItems[5].Text);
                shw.eToDt = Convert.ToDateTime(lstResList.SelectedItems[0].SubItems[6].Text);
                shw.eDueDt = Convert.ToDateTime(lstResList.SelectedItems[0].SubItems[7].Text);
                shw.wLoad = "Edit";
                shw.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
