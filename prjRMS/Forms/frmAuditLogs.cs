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
    public partial class frmAuditLogs : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmAuditLogs()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAuditLogs_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmAuditLogs_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmAuditLogs_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmAuditLogs_Load(object sender, EventArgs e)
        {
            headerAudit();
        }

        void headerAudit()
        {
            lstAudit.Clear();
            int w = lstAudit.Width / 4;
            int w1 = w / 2;
            int w2 = w1 / 4;
            int wEt = w1 + w2;
            int wEv = w + wEt + w2;

            lstAudit.Columns.Add("Event Time", wEt, HorizontalAlignment.Left);
            lstAudit.Columns.Add("Username", w, HorizontalAlignment.Left);
            lstAudit.Columns.Add("Designation", wEt, HorizontalAlignment.Left);
            lstAudit.Columns.Add("Event", wEv, HorizontalAlignment.Left);
        }

        void FillAudit()
        {
            try
            {
                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    txtRecCount.Text = "0";
                    ProgBar.Value = 0;

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblauditlogs order by EventTime desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        txtTotalCnt.Text = rs.RecordCount.ToString();
                        ProgBar.Maximum = rs.RecordCount;
                        ProgBar.Visible = true;

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstAudit.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            DateTime et = Convert.ToDateTime(rs.Fields["EventTime"].Value.ToString());
                            viewlst = lstAudit.Items.Add(et.ToString("yyyy-MM-dd HH:mm"), lup);
                            viewlst.SubItems.Add(rs.Fields["Username"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Designation"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Event"].Value.ToString());
                            rs.MoveNext();

                            ProgBar.Value = lup;
                            txtRecCount.Text = lup.ToString();
                        }
                        ProgBar.Visible = false;

                        wc.WaitCurFalse();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void FindAudit()
        {
            try
            {
                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    txtRecCount.Text = "0";
                    ProgBar.Value = 0;

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblauditlogs where " + cboCateg.Text + " like '%" + txtKeycode.Text + "%' order by EventTime desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        txtTotalCnt.Text = rs.RecordCount.ToString();
                        ProgBar.Maximum = rs.RecordCount;
                        ProgBar.Visible = true;

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstAudit.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            DateTime et = Convert.ToDateTime(rs.Fields["EventTime"].Value.ToString());
                            viewlst = lstAudit.Items.Add(et.ToString("yyyy-MM-dd HH:mm"), lup);
                            viewlst.SubItems.Add(rs.Fields["Username"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Designation"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Event"].Value.ToString());
                            rs.MoveNext();

                            ProgBar.Value = lup;
                            txtRecCount.Text = lup.ToString();
                        }
                        ProgBar.Visible = false;

                        wc.WaitCurFalse();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCateg_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            headerAudit();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FindAudit);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            headerAudit();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillAudit);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
