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
    public partial class frmViewDocu : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int CID;
        public string tName;

        public frmViewDocu()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewDocu_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmViewDocu_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmViewDocu_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmViewDocu_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(AddSigningList);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void AddSigningList()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                lbTenantName.Text = tName;
                cboCateg.Items.Clear();

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select Id,TenantId,TenantIdStat,TenantSign,TenantSignStat,GuardianId,GuardianIdStat," +
                                            "GuardianSign,GuardianSignStat from vwesigningname where Id = " + CID, out ra, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        if (rs.Fields["TenantIdStat"].Value.ToString() == "1" && rs.Fields["TenantId"].Value.ToString() == "1")
                        {
                            cboCateg.Items.Add("Tenant I.D.");
                        }

                        if (rs.Fields["TenantSignStat"].Value.ToString() == "1" && rs.Fields["TenantSign"].Value.ToString() == "1")
                        {
                            cboCateg.Items.Add("Tenant contract sign");
                        }

                        if (rs.Fields["GuardianIdStat"].Value.ToString() == "1" && rs.Fields["GuardianId"].Value.ToString() == "1")
                        {
                            cboCateg.Items.Add("Parent or guardian I.D.");
                        }

                        if (rs.Fields["GuardianSignStat"].Value.ToString() == "1" && rs.Fields["GuardianSign"].Value.ToString() == "1")
                        {
                            cboCateg.Items.Add("Parent or guardian sign");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void headerId()
        {
            lstDocu.Clear();
            int w = lstDocu.Width / 3;

            //lstDocu.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDocu.Columns.Add("Date", w, HorizontalAlignment.Left);
            lstDocu.Columns.Add("Id Type", w, HorizontalAlignment.Left);
            lstDocu.Columns.Add("Id Number", w, HorizontalAlignment.Left);
        }

        void headerTenantSign()
        {
            lstDocu.Clear();
            int w = lstDocu.Width / 2;

            //lstDocu.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDocu.Columns.Add("Signing Date", w, HorizontalAlignment.Left);
            lstDocu.Columns.Add("Assisted By", w, HorizontalAlignment.Left);
        }

        void headerGuardianSign()
        {
            lstDocu.Clear();
            int w = lstDocu.Width / 3;

            //lstDocu.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDocu.Columns.Add("Signing Date", w, HorizontalAlignment.Left);
            lstDocu.Columns.Add("Guardian Name", w, HorizontalAlignment.Left);
            lstDocu.Columns.Add("Assisted By", w, HorizontalAlignment.Left);
        }

        void fillTenantId()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select IdType,IdNo,RecDate from tblidsubmitted where IdOwner = 'Tenant' and " +
                                            "cId = " + CID, out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstDocu.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);

                            DateTime rd = Convert.ToDateTime(rs.Fields["RecDate"].Value.ToString());

                            viewlst = lstDocu.Items.Add(rd.ToString("yyyy-MM-dd"), lup);
                            viewlst.SubItems.Add(rs.Fields["IdType"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["IdNo"].Value.ToString());
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

        void fillGuardianId()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select IdType,IdNo,RecDate from tblidsubmitted where IdOwner = 'Guardian' and " +
                                            "cId = " + CID, out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstDocu.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);

                            DateTime rd = Convert.ToDateTime(rs.Fields["RecDate"].Value.ToString());

                            viewlst = lstDocu.Items.Add(rd.ToString("yyyy-MM-dd"), lup);
                            viewlst.SubItems.Add(rs.Fields["IdType"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["IdNo"].Value.ToString());
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

        void fillTenantSign()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select RecDate,AssistedBy from tbltenantsign where " +
                                            "cId = " + CID, out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstDocu.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);

                            DateTime rd = Convert.ToDateTime(rs.Fields["RecDate"].Value.ToString());

                            viewlst = lstDocu.Items.Add(rd.ToString("yyyy-MM-dd"), lup);
                            viewlst.SubItems.Add(rs.Fields["AssistedBy"].Value.ToString());
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

        void fillGuardianSign()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select RecDate,GuardianName,AssistedBy from tblguardiansign where " +
                                            "cId = " + CID, out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstDocu.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);

                            DateTime rd = Convert.ToDateTime(rs.Fields["RecDate"].Value.ToString());

                            viewlst = lstDocu.Items.Add(rd.ToString("yyyy-MM-dd"), lup);
                            viewlst.SubItems.Add(rs.Fields["GuardianName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["AssistedBy"].Value.ToString());
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

        private void cboCateg_TextChanged(object sender, EventArgs e)
        {
            switch (cboCateg.Text) 
            {
                case "Tenant I.D.":
                    headerId();
                    Thread th = new Thread(() =>
                    {
                        Action act = new Action(fillTenantId);
                        this.BeginInvoke(act);
                    });
                    th.Start();
                    break;
                case "Tenant contract sign":
                    headerTenantSign();
                    Thread th2 = new Thread(() =>
                    {
                        Action act = new Action(fillTenantSign);
                        this.BeginInvoke(act);
                    });
                    th2.Start();
                    break;
                case "Parent or guardian I.D.":
                    headerId();
                    Thread th3 = new Thread(() =>
                    {
                        Action act = new Action(fillGuardianId);
                        this.BeginInvoke(act);
                    });
                    th3.Start();
                    break;
                case "Parent or guardian sign":
                    headerGuardianSign();
                    Thread th4 = new Thread(() =>
                    {
                        Action act = new Action(fillGuardianSign);
                        this.BeginInvoke(act);
                    });
                    th4.Start();
                    break;
            }
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
