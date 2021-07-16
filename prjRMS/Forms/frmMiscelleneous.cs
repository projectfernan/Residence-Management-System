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
    public partial class frmMiscelleneous : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        int mId;

        public frmMiscelleneous()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMiscelleneous_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmMiscelleneous_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmMiscelleneous_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        void HeaderIdMisce()
        {
            lstMisce.Clear();
            int w = lstMisce.Width / 2;
            int s = w / 2;

            lstMisce.Columns.Add("", 0, HorizontalAlignment.Left);
            lstMisce.Columns.Add("Miscellaneous", w, HorizontalAlignment.Left);
            lstMisce.Columns.Add("Amount", s, HorizontalAlignment.Left);
            lstMisce.Columns.Add("Status", s, HorizontalAlignment.Left);
        }

        public void FillMisce()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblmiscellaneous order by Id desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstMisce.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            decimal Amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string mAmt = p.Currency(Amt);

                            viewlst = lstMisce.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Miscellaneous"].Value.ToString());
                            viewlst.SubItems.Add(mAmt);
                            viewlst.SubItems.Add(rs.Fields["Status"].Value.ToString());

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

        public void FindMisce()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblmiscellaneous where Miscellaneous like '%" + txtKeycode.Text + "%' order by Id desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstMisce.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            decimal Amt = Convert.ToDecimal(rs.Fields["Amount"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string mAmt = p.Currency(Amt);

                            viewlst = lstMisce.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Miscellaneous"].Value.ToString());
                            viewlst.SubItems.Add(mAmt);
                            viewlst.SubItems.Add(rs.Fields["Status"].Value.ToString());

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

        private void frmMiscelleneous_Load(object sender, EventArgs e)
        {
            HeaderIdMisce();

            Thread th = new Thread(() =>
            {
                Action act = new Action(FillMisce);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                HeaderIdMisce();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(FindMisce);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMisce.Text == "")
            {
                txtMisce.Focus();
                return;
            }

            if (existMisce(txtMisce.Text))
            {
                txtMisce.Text = "";
                txtMisce.Focus();
                return;
            }

            Thread th = new Thread(() =>
            {
                Action act = new Action(insMisce);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        bool existMisce(string Misce)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    string idt = Misce;
                    string getid = idt.Replace("'", "");
                    rs = conn.MySql.Execute("select Miscellaneous from tblmiscellaneous where Miscellaneous = '" + Misce + "'", out ra, (int)CommandTypeEnum.adCmdText);
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
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        void insMisce()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    string idTyp = txtMisce.Text;
                    string insIdTyp = idTyp.Replace("'", "");
                    rs = conn.MySql.Execute("call insMiscellaneous('" + insIdTyp + "'," + txtAmt.Value + ")", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Miscellaneous: (" + insIdTyp + ") created.");

                    txtMisce.Text = "";
                    txtAmt.Value = 0;
                    txtMisce.Focus();

                    HeaderIdMisce();
                    FillMisce();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            HeaderIdMisce();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillMisce);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstMisce.SelectedItems.Count > 0)
            {
                DialogResult del = MessageBox.Show("Are you sure do you want to delete this miscellaneous?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (del == DialogResult.Yes)
                {
                    delIdType(lstMisce.SelectedItems[0].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Please select miscellaneous that you want to delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void delIdType(string Idtype)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("delete from tblmiscellaneous where Miscellaneous = '" + Idtype + "'", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Miscellaneous: (" + Idtype + ") deleted.");

                    HeaderIdMisce();
                    FillMisce();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mActivate_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(ActiveMisce);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void ActiveMisce() 
        {
            try
            {
                if (lstMisce.SelectedItems.Count > 0)
                {
                    mId = Convert.ToInt32(lstMisce.SelectedItems[0].SubItems[0].Text);
                    string mName = lstMisce.SelectedItems[0].SubItems[1].Text;

                    DBconn conn = new DBconn();
                    string ActiMisce = "update tblmiscellaneous set Status = 'Active' where Id = " + mId;

                    if (conn.rsCUD(ActiMisce)) 
                    {
                        MessageBox.Show(mName +" is activated!","Activate",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mHide_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(HideMisce);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void HideMisce() 
        {
            try
            {
                if (lstMisce.SelectedItems.Count > 0)
                {
                    mId = Convert.ToInt32(lstMisce.SelectedItems[0].SubItems[0].Text);
                    string mName = lstMisce.SelectedItems[0].SubItems[1].Text;

                    DBconn conn = new DBconn();
                    string ActiMisce = "update tblmiscellaneous set Status = 'Hidden' where Id = " + mId;

                    if (conn.rsCUD(ActiMisce))
                    {
                        MessageBox.Show(mName + " is hidden!", "Hide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
