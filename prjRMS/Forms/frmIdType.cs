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
    public partial class frmIdType : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmIdType()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIdType_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmIdType_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmIdType_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmIdType_Load(object sender, EventArgs e)
        {
            HeaderIdType();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillId);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void HeaderIdType()
        {
            lstIdType.Clear();
            int w = lstIdType.Width;

            lstIdType.Columns.Add("", 0, HorizontalAlignment.Left);
            lstIdType.Columns.Add("IdType", w, HorizontalAlignment.Left);
        }

        public void FillId()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblidtype order by Id desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstIdType.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstIdType.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["IdType"].Value.ToString());
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

        public void FindId()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblidtype where IdType like '%" + txtKeycode.Text + "%' order by Id desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstIdType.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstIdType.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["IdType"].Value.ToString());
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtIdType.Text == "") {
                txtIdType.Focus();
                return;
            }

            if (existIdType(txtIdType.Text))
            {
                txtIdType.Text = "";
                txtIdType.Focus();
                return;
            }

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Id Type: (" + txtIdType.Text + ") created.");

            insIdType();
        }

        void insIdType() { 
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    string idTyp = txtIdType.Text;
                    string insIdTyp = idTyp.Replace("'","");
                    rs = conn.MySql.Execute("insert into tblidtype(IdType)VALUES('" + insIdTyp + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    txtIdType.Text = null;
                    txtIdType.Focus();

                    HeaderIdType();
                    Thread th = new Thread(() =>
                    {
                        Action act = new Action(FillId);
                        this.BeginInvoke(act);
                    });
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool existIdType(string idType) 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    string idt = idType;
                    string getid = idt.Replace("'", "");
                    rs = conn.MySql.Execute("select IdType from tblidtype where IdType = '" + getid + "'", out ra, (int)CommandTypeEnum.adCmdText);
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
        }

        private void txtIdType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnAdd_Click(sender, e);
            }
        }
    
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            HeaderIdType();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillId);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void txtKeycode_TextChanged(object sender, EventArgs e)
        {
            HeaderIdType();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FindId);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstIdType.SelectedItems.Count > 0)
            {
                DialogResult del = MessageBox.Show("Are you sure do you want to delete this ID type?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (del == DialogResult.Yes) {
                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Id Type: (" + lstIdType.SelectedItems[0].SubItems[1].Text + ") deleted.");

                    delIdType(lstIdType.SelectedItems[0].SubItems[1].Text);
                }
            }
            else 
            {
                MessageBox.Show("Please select ID type that you want to delete!","Delete",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                    rs = conn.MySql.Execute("delete from tblidtype where IdType = '" + Idtype + "'", out ra, (int)CommandTypeEnum.adCmdText);

                    HeaderIdType();
                    Thread th = new Thread(() =>
                    {
                        Action act = new Action(FillId);
                        this.BeginInvoke(act);
                    });
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
