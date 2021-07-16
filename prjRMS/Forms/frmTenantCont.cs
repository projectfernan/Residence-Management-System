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
    public partial class frmTenantCont : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        int tId,cID;

        string ExportType;

        public frmTenantCont()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTenantCont_Load(object sender, EventArgs e)
        {
            headerTpi();
            headerTcr();

            btnEditCont.Enabled = Properties.Settings.Default.EditCont;
        }

        public void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 10;

            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("DateRegistered", 125, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Remarks", 150, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", 150, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Nickname", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Gender", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("BirthDate", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Age", 40, HorizontalAlignment.Left);
            lstTpi.Columns.Add("ContactNo", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("GuardianNo", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("School", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("YearLevel", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Course", w, HorizontalAlignment.Left);
        }

        public void headerTcr()
        {
            lstTcr.Clear();
            int w = lstTpi.Width / 12;

            lstTcr.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTcr.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTcr.Columns.Add("DateCreated", 125, HorizontalAlignment.Left);
            lstTcr.Columns.Add("ContractName", 150, HorizontalAlignment.Left);
            lstTcr.Columns.Add("ContractType", 130, HorizontalAlignment.Left);
            lstTcr.Columns.Add("SecurityDepo", 130, HorizontalAlignment.Left);
            lstTcr.Columns.Add("MonthlyFee", 130, HorizontalAlignment.Left);
            lstTcr.Columns.Add("ContractPeriod", 130, HorizontalAlignment.Left);
            lstTcr.Columns.Add("StartDate", 110, HorizontalAlignment.Left);
            lstTcr.Columns.Add("EndDate", 110, HorizontalAlignment.Left);
            lstTcr.Columns.Add("MoveInDate", 110, HorizontalAlignment.Left);
            lstTcr.Columns.Add("MoveOutDate", 110, HorizontalAlignment.Left);
            lstTcr.Columns.Add("ContractStatus", 130, HorizontalAlignment.Left);
        }

        public void fillTpi()
        {
            try
            {
                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from vwetenantrec", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                          
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            DateTime RegDate = Convert.ToDateTime(rs.Fields["DateReg"].Value.ToString());
                            DateTime bDate = Convert.ToDateTime(rs.Fields["BirthDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(RegDate.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["Remarks"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["NickName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Gender"].Value.ToString());
                            viewlst.SubItems.Add(bDate.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["Age"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContactNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["GuardianNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["School"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["YearLevel"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Course"].Value.ToString());

                            rs.MoveNext();
                        }

                        wc.WaitCurFalse();
                    }
                }
                Application.UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void findTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from vwetenantrec where " + cboCateg.Text + " like '%" + txtKeycode.Text + "%'", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            DateTime RegDate = Convert.ToDateTime(rs.Fields["DateReg"].Value.ToString());
                            DateTime bDate = Convert.ToDateTime(rs.Fields["BirthDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(RegDate.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["Remarks"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["NickName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Gender"].Value.ToString());
                            viewlst.SubItems.Add(bDate.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["Age"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContactNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["GuardianNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["School"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["YearLevel"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Course"].Value.ToString());
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

        public void GetFillTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from vwetenantrec where Id = " + tId, out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            DateTime RegDate = Convert.ToDateTime(rs.Fields["DateReg"].Value.ToString());
                            DateTime bDate = Convert.ToDateTime(rs.Fields["BirthDate"].Value.ToString());

                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(RegDate.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["Remarks"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["NickName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Gender"].Value.ToString());
                            viewlst.SubItems.Add(bDate.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["Age"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContactNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["GuardianNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["School"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["YearLevel"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Course"].Value.ToString());
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

        public void FillTcr()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("call slctAllTenantCont('" + cboContCateg.Text + "','" + txtContKeyCode.Text + "');", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            DateTime DtCreated = Convert.ToDateTime(rs.Fields["DateCreated"].Value.ToString());
                            DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                            DateTime dtMveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime dtMveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());
                            decimal Amt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                            decimal SecDepAmt = Convert.ToDecimal(rs.Fields["SecDep"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string mf = p.Currency(Amt);
                            string sd = p.Currency(SecDepAmt);

                            lstTcr.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTcr.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["tId"].Value.ToString());
                            viewlst.SubItems.Add(DtCreated.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
                            viewlst.SubItems.Add(sd);
                            viewlst.SubItems.Add(mf);
                            viewlst.SubItems.Add(rs.Fields["ContractPeriod"].Value.ToString());
                            viewlst.SubItems.Add(dtStart.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtEnd.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtMveIn.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtMveOut.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
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

        public void FindTcr()
        {
            try
            {
                ExportType = "All";

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("call slctAllTenantCont('" + cboContCateg.Text + "','" + txtContKeyCode.Text + "');", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            DateTime DtCreated = Convert.ToDateTime(rs.Fields["DateCreated"].Value.ToString());
                            DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                            DateTime dtMveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime dtMveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());
                            decimal Amt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                            decimal SecDepAmt = Convert.ToDecimal(rs.Fields["SecDep"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string mf = p.Currency(Amt);
                            string sd = p.Currency(SecDepAmt);

                            lstTcr.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTcr.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["tId"].Value.ToString());
                            viewlst.SubItems.Add(DtCreated.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
                            viewlst.SubItems.Add(sd);
                            viewlst.SubItems.Add(mf);
                            viewlst.SubItems.Add(rs.Fields["ContractPeriod"].Value.ToString());
                            viewlst.SubItems.Add(dtStart.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtEnd.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtMveIn.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtMveOut.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
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

        public void GetTcr()
        {
            try
            {
                ExportType = "Tenant";

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("call slctTenantCont(" + tId + ")", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            DateTime DtCreated = Convert.ToDateTime(rs.Fields["DateCreated"].Value.ToString());
                            DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                            DateTime dtMveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                            DateTime dtMveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());
                            decimal Amt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                            decimal SecDepAmt = Convert.ToDecimal(rs.Fields["SecDep"].Value.ToString());
                            MakeMoney p = new MakeMoney();
                            string mf = p.Currency(Amt);
                            string sd = p.Currency(SecDepAmt);

                            lstTcr.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTcr.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["tId"].Value.ToString());
                            viewlst.SubItems.Add(DtCreated.ToString("yyyy-MM-dd HH:mm"));
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
                            viewlst.SubItems.Add(sd);
                            viewlst.SubItems.Add(mf);
                            viewlst.SubItems.Add(rs.Fields["ContractPeriod"].Value.ToString());
                            viewlst.SubItems.Add(dtStart.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtEnd.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtMveIn.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(dtMveOut.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["ContractStatus"].Value.ToString());
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

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            headerTpi();

            Thread th = new Thread(() =>
            {
                Action act = new Action(fillTpi);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnSearch_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            headerTpi();

            Thread th = new Thread(() =>
            {
                Action act = new Action(findTpi);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count == 0) {
                MessageBox.Show("Please select tenant record that you want to update!","Edit",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            UpdTenant(Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text));
        }

        private void UpdTenant(int Id) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("select * from tbltenantrec where Id = " + Id, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false) {
                        frmNewTenant x = new frmNewTenant();
                        x.tId = Id;
                        x.tFname = rs.Fields["FirstName"].Value.ToString();
                        x.tLname = rs.Fields["LastName"].Value.ToString();
                        x.tMI = rs.Fields["MI"].Value.ToString();
                        x.tNickName = rs.Fields["NickName"].Value.ToString();
                        x.tGender = rs.Fields["Gender"].Value.ToString();
                        x.tBdate = rs.Fields["BirthDate"].Value.ToString();
                        x.tContact = rs.Fields["ContactNo"].Value.ToString();
                        x.tGcontact = rs.Fields["GuardianNo"].Value.ToString();
                        x.tSchool = rs.Fields["School"].Value.ToString();
                        x.tYrLevel = rs.Fields["YearLevel"].Value.ToString();
                        x.tCourse = rs.Fields["Course"].Value.ToString();
                        x.tRem = rs.Fields["Remarks"].Value.ToString();
                        x.EventReq = "Update";
                        x.ShowDialog();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool chkCont(int tId) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select tId from tbltenantcontract where tId = " + tId, out ra, (int)CommandTypeEnum.adCmdText);
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

            catch {
                return false;
            }
        }

        private void lstTpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lstTpi.SelectedItems.Count > 0) 
            {
                headerTcr();
                this.tId = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                Thread th = new Thread(() =>
                {
                    Action act = new Action(GetTcr);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
        }

        private void btnContRef_Click(object sender, EventArgs e)
        {
            ExportType = "All";
            headerTcr();
            cboContCateg.Text = "ContractName";
            txtContKeyCode.Text = "";

            Thread th = new Thread(() =>
            {
                Action act = new Action(FillTcr);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void cboContCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtContKeyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnContFind_Click(sender, e);
            }
        }

        private void btnContFind_Click(object sender, EventArgs e)
        {
            headerTcr();
            Thread th = new Thread(() =>
            {
                Action act = new Action(FindTcr);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        private void lstTcr_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(lstTcr.SelectedItems.Count > 0)
            {
                headerTpi();
                this.tId = Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[1].Text);
                Thread th = new Thread(() =>
                {
                    Action act = new Action(GetFillTpi);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
            
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            if (lstTpi.SelectedItems.Count > 0)
            {
                if (chkCont(Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text)))
                {
                    MessageBox.Show("Tenant already has a contract!", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    frmAddContract shw = new frmAddContract();
                    shw.tId = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                    shw.cId = 0;
                    shw.wLoad = "Add";
                    shw.ContType = "New";
                    shw.tRem = lstTpi.SelectedItems[0].SubItems[2].Text;
                    shw.tName = lstTpi.SelectedItems[0].SubItems[3].Text;
                    shw.tGender = lstTpi.SelectedItems[0].SubItems[5].Text;
                    shw.tAge = lstTpi.SelectedItems[0].SubItems[7].Text;

                    shw.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select one tenant record first!", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmTenantCont_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmTenantCont_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmTenantCont_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (lstTcr.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Please select contract that you want to renew!","Renew",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DateTime nowDt = DateTime.Now;
            DateTime endDt = Convert.ToDateTime(lstTcr.SelectedItems[0].SubItems[9].Text);
            string ContStat = lstTcr.SelectedItems[0].SubItems[12].Text;

            if (ContStat == "Reserved" || ContStat == "Hold")
            {
                MessageBox.Show("Failed to renew the contract!", "Renew", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(ContStat == "Terminated")
            {
                MessageBox.Show("This contract is already renewed!", "Renew", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (ContStat == "Extend")
            {
                MessageBox.Show("You can't renew extended contract!", "Renew", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string StartDte = lstTcr.SelectedItems[0].SubItems[7].Text;
            int ContId = Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[0].Text);
            decimal SecDepAmt = Convert.ToDecimal(lstTcr.SelectedItems[0].SubItems[5].Text);

            shwRenew(Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[1].Text), SecDepAmt, StartDte, endDt.ToString(), "Renew", ContId);            
        }

        void shwRenew(int tId,decimal SecDep,string StartDt,string EndDt,string ConTyp,int cId) 
        {
            try 
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if(conn.ServerConn()){
                    rs = conn.MySql.Execute("select Name,Gender,Age from vwetenantrec where Id = " + tId,out ra,(int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false){

                        frmAddContract shw = new frmAddContract();
                        shw.tId = tId;
                        shw.ContType = ConTyp;
                        shw.oldSecDepo = SecDep;
                        shw.tName = rs.Fields["Name"].Value.ToString();
                        shw.tGender = rs.Fields["Gender"].Value.ToString();
                        shw.tAge = rs.Fields["Age"].Value.ToString();
                        shw.tStartDt = StartDt;
                        shw.tMoveInDt = lstTcr.SelectedItems[0].SubItems[9].Text;
                        shw.tEndDt = EndDt;
                        shw.cId = cId;
                        shw.wLoad = "Add";
                        shw.ShowDialog();
                    }
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCancelCont_Click(object sender, EventArgs e)
        {
            if (lstTcr.SelectedItems.Count == 0) {
                MessageBox.Show("Please select contract record that you want to cancel!","Cancel",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DialogResult can = MessageBox.Show("Are you sure do you want to cancel this contract?","Cancel",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (can != DialogResult.Yes) {
                return;
            }

            DialogResult lw = MessageBox.Show("If you cancel this contract the tenant assigned bed will be loose, are you sure do you want to continue?","Cancel",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
            if (lw == DialogResult.Yes) 
            {
                int cId = Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[0].Text);
                UpdContStat stat = new UpdContStat();
                stat.ContStatus(cId, "Cancelled");

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "cId: (" + cId.ToString() + ") cancelled.");
            }
        }

        private void btnExtendCont_Click(object sender, EventArgs e)
        {
            if (lstTcr.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select contract that you want to extend!", "Extend", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string ContStat = lstTcr.SelectedItems[0].SubItems[12].Text;

            if (ContStat == "Cancelled" || ContStat == "Reserved" || ContStat == "Hold" || ContStat == "Extend" || ContStat == "Forfeited" || ContStat == "Terminated")
            {
                MessageBox.Show("You can't extend this contract!", "Extend", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string StartDte = lstTcr.SelectedItems[0].SubItems[8].Text;
            string endDt = lstTcr.SelectedItems[0].SubItems[9].Text;
            int ContId = Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[0].Text);
            decimal SecDepAmt = Convert.ToDecimal(lstTcr.SelectedItems[0].SubItems[5].Text);

            shwRenew(Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[1].Text), SecDepAmt, StartDte, endDt, "Extension", ContId);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lstTcr.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select contract that you want to print!", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cid = Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[0].Text);
            contPrint(cid);

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "cId: (" + cid.ToString() + ") printed.");
        }

        void contPrint(int cID)
        {
            try
            {
                string Rpath = Application.StartupPath + @"\Reports\crtPrintContract.rpt";
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select * from vweprintcontract where Id = " + cID, out ra, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        WaitMouse wc = new WaitMouse();
                        wc.WaitCurTrue();

                        CrystalDecisions.CrystalReports.Engine.ReportDocument AR = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        AR.Load(Rpath);
                        AR.SetDataSource(rs);

                        frmRepViewer shw = new frmRepViewer();
                        shw.crViewer.ReportSource = AR;
                        shw.ShowDialog();

                        wc.WaitCurFalse();
                    }
                    else
                    {
                        MessageBox.Show("Failed to print", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                WaitMouse wc = new WaitMouse();
                wc.WaitCurFalse();
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCont_Click(object sender, EventArgs e)
        {
            if (lstTcr.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select contract record that you want to edit!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime endDt = Convert.ToDateTime(lstTcr.SelectedItems[0].SubItems[9].Text);
            string ContStat = lstTcr.SelectedItems[0].SubItems[12].Text;

            string StartDte = lstTcr.SelectedItems[0].SubItems[8].Text;
            int ContId = Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[0].Text);
            string ContType = lstTcr.SelectedItems[0].SubItems[4].Text;
            string ContName = lstTcr.SelectedItems[0].SubItems[3].Text;

            shwEdit(Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[1].Text), StartDte, endDt.ToString(), ContType, ContName, ContId);            
        }

        void shwEdit(int tId, string StartDt, string EndDt, string ConTyp,string ConName, int cId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select Name,Gender,Age,Remarks from vwetenantrec where Id = " + tId, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {

                        frmAddContract shw = new frmAddContract();
                        shw.ContType = ConTyp;
                        shw.tName = rs.Fields["Name"].Value.ToString();
                        shw.tGender = rs.Fields["Gender"].Value.ToString();
                        shw.tAge = rs.Fields["Age"].Value.ToString();
                        shw.tRem = rs.Fields["Remarks"].Value.ToString();
                        shw.ContName = ConName;
                        shw.tStartDt = StartDt;
                        shw.tEndDt = EndDt;
                        shw.cId = cId;
                        shw.wLoad = "Edit";
                        shw.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportEx_Click(object sender, EventArgs e)
        {
            if(lstTcr.Items.Count == 0)
            {
                MessageBox.Show("No records to be exported!","Export",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            switch (ExportType) 
            {
                case "All":
                    Thread th = new Thread(() =>
                    {
                        Action act = new Action(exportExcelAll);
                        this.BeginInvoke(act);
                    });
                    th.Start();
                    break;
                case "Tenant":
                    Thread th2 = new Thread(() =>
                    {
                        Action act = new Action(exportExcelTenant);
                        this.BeginInvoke(act);
                    });
                    th2.Start();
                    break;
            }
        }

        void exportExcelAll() 
        {
            try
            {
                sfd.FileName = "";
                sfd.Filter = "Excel files (*.xlsx,*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    WaitMouse wc = new WaitMouse();
                    wc.WaitCurTrue();

                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook wb = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet ws = null;
                    ws = wb.Sheets["Sheet1"];
                    ws = wb.ActiveSheet;

                    DBconn conn = new DBconn();
                    Recordset rs = new Recordset();
                    object ra;

                    if (conn.ServerConn())
                    {
                        rs = conn.MySql.Execute("call exportAllCont('" + cboContCateg.Text + "','" + txtContKeyCode.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {

                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, 1] = "Date Created";
                            ws.Cells[1, 2] = "Remarks";
                            ws.Cells[1, 3] = "Name";
                            ws.Cells[1, 4] = "NickName";
                            ws.Cells[1, 5] = "Gender";
                            ws.Cells[1, 6] = "BirthDate";
                            ws.Cells[1, 7] = "Age";
                            ws.Cells[1, 8] = "Contact No";
                            ws.Cells[1, 9] = "Guardian No";
                            ws.Cells[1, 10] = "School";
                            ws.Cells[1, 11] = "Year Level";
                            ws.Cells[1, 12] = "Course";
                            ws.Cells[1, 13] = "Contract Name";
                            ws.Cells[1, 14] = "Contract Type";
                            ws.Cells[1, 15] = "Monthly Fee";
                            ws.Cells[1, 16] = "Contract Period";
                            ws.Cells[1, 17] = "Start Date";
                            ws.Cells[1, 18] = "End Date";
                            ws.Cells[1, 19] = "Move In Date";
                            ws.Cells[1, 20] = "Move Out Date";
                            ws.Cells[1, 21] = "Contract Status";

                            int lup = 2;
                            int rc = rs.RecordCount + 1;
                            for (lup = 2; lup <= rc; lup++)
                            {
                                DateTime Bdate = Convert.ToDateTime(rs.Fields["BirthDate"].Value.ToString());
                                DateTime DtCreated = Convert.ToDateTime(rs.Fields["DateCreated"].Value.ToString());
                                DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                DateTime dtMveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                                DateTime dtMveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());
                                decimal Amt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                                MakeMoney p = new MakeMoney();
                                string mf = p.Currency(Amt);

                                ws.Cells[lup, 1] = DtCreated.ToString("yyyy-MM-dd HH:mm");
                                ws.Cells[lup, 2] = rs.Fields["Remarks"].Value.ToString();
                                ws.Cells[lup, 3] = rs.Fields["Name"].Value.ToString();
                                ws.Cells[lup, 4] = rs.Fields["NickName"].Value.ToString();
                                ws.Cells[lup, 5] = rs.Fields["Gender"].Value.ToString();
                                ws.Cells[lup, 6] = Bdate.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 7] = rs.Fields["Age"].Value.ToString();
                                ws.Cells[lup, 8] = rs.Fields["ContactNo"].Value.ToString();
                                ws.Cells[lup, 9] = rs.Fields["GuardianNo"].Value.ToString();
                                ws.Cells[lup, 10] = rs.Fields["School"].Value.ToString();
                                ws.Cells[lup, 11] = rs.Fields["YearLevel"].Value.ToString();
                                ws.Cells[lup, 12] = rs.Fields["Course"].Value.ToString();
                                ws.Cells[lup, 13] = rs.Fields["ContractName"].Value.ToString();
                                ws.Cells[lup, 14] = rs.Fields["ContractType"].Value.ToString();
                                ws.Cells[lup, 15] = mf;
                                ws.Cells[lup, 16] = rs.Fields["ContractPeriod"].Value.ToString();
                                ws.Cells[lup, 17] = dtStart.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 18] = dtEnd.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 19] = dtMveIn.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 20] = dtMveOut.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 21] = rs.Fields["ContractStatus"].Value.ToString();

                                rs.MoveNext();
                            }

                            wb.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            app.Quit();

                            wc.WaitCurFalse();

                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Export contracts to excel.");

                            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void exportExcelTenant()
        {
            try
            {
                sfd.FileName = "";
                sfd.Filter = "Excel files (*.xlsx,*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    WaitMouse wc = new WaitMouse();
                    wc.WaitCurTrue();

                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook wb = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet ws = null;
                    ws = wb.Sheets["Sheet1"];
                    ws = wb.ActiveSheet;

                    DBconn conn = new DBconn();
                    Recordset rs = new Recordset();
                    object ra;

                    if (conn.ServerConn())
                    {
                        rs = conn.MySql.Execute("call exportTenantCont(" + tId + ")", out ra, (int)CommandTypeEnum.adCmdText);
                        if (rs.EOF == false)
                        {

                            ws.Range["A1", "XFD1"].Font.Bold = true;

                            ws.Cells[1, 1] = "Date Created";
                            ws.Cells[1, 2] = "Remarks";
                            ws.Cells[1, 3] = "Name";
                            ws.Cells[1, 4] = "NickName";
                            ws.Cells[1, 5] = "Gender";
                            ws.Cells[1, 6] = "BirthDate";
                            ws.Cells[1, 7] = "Age";
                            ws.Cells[1, 8] = "Contact No";
                            ws.Cells[1, 9] = "Guardian No";
                            ws.Cells[1, 10] = "School";
                            ws.Cells[1, 11] = "Year Level";
                            ws.Cells[1, 12] = "Course";
                            ws.Cells[1, 13] = "Contract Name";
                            ws.Cells[1, 14] = "Contract Type";
                            ws.Cells[1, 15] = "Monthly Fee";
                            ws.Cells[1, 16] = "Contract Period";
                            ws.Cells[1, 17] = "Start Date";
                            ws.Cells[1, 18] = "End Date";
                            ws.Cells[1, 19] = "Move In Date";
                            ws.Cells[1, 20] = "Move Out Date";
                            ws.Cells[1, 21] = "Contract Status";

                            int lup = 2;
                            int rc = rs.RecordCount + 1;
                            for (lup = 2; lup <= rc; lup++)
                            {
                                DateTime Bdate = Convert.ToDateTime(rs.Fields["BirthDate"].Value.ToString());
                                DateTime DtCreated = Convert.ToDateTime(rs.Fields["DateCreated"].Value.ToString());
                                DateTime dtStart = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime dtEnd = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());
                                DateTime dtMveIn = Convert.ToDateTime(rs.Fields["MoveInDate"].Value.ToString());
                                DateTime dtMveOut = Convert.ToDateTime(rs.Fields["MoveOutDate"].Value.ToString());
                                decimal Amt = Convert.ToDecimal(rs.Fields["MonthlyFee"].Value.ToString());
                                MakeMoney p = new MakeMoney();
                                string mf = p.Currency(Amt);

                                ws.Cells[lup, 1] = DtCreated.ToString("yyyy-MM-dd HH:mm");
                                ws.Cells[lup, 2] = rs.Fields["Remarks"].Value.ToString();
                                ws.Cells[lup, 3] = rs.Fields["Name"].Value.ToString();
                                ws.Cells[lup, 4] = rs.Fields["NickName"].Value.ToString();
                                ws.Cells[lup, 5] = rs.Fields["Gender"].Value.ToString();
                                ws.Cells[lup, 6] = Bdate.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 7] = rs.Fields["Age"].Value.ToString();
                                ws.Cells[lup, 8] = rs.Fields["ContactNo"].Value.ToString();
                                ws.Cells[lup, 9] = rs.Fields["GuardianNo"].Value.ToString();
                                ws.Cells[lup, 10] = rs.Fields["School"].Value.ToString();
                                ws.Cells[lup, 11] = rs.Fields["YearLevel"].Value.ToString();
                                ws.Cells[lup, 12] = rs.Fields["Course"].Value.ToString();
                                ws.Cells[lup, 13] = rs.Fields["ContractName"].Value.ToString();
                                ws.Cells[lup, 14] = rs.Fields["ContractType"].Value.ToString();
                                ws.Cells[lup, 15] = mf;
                                ws.Cells[lup, 16] = rs.Fields["ContractPeriod"].Value.ToString();
                                ws.Cells[lup, 17] = dtStart.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 18] = dtEnd.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 19] = dtMveIn.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 20] = dtMveOut.ToString("yyyy-MM-dd");
                                ws.Cells[lup, 21] = rs.Fields["ContractStatus"].Value.ToString();

                                rs.MoveNext();
                            }

                            wb.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            app.Quit();

                            wc.WaitCurFalse();

                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Export contracts to excel.");

                            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            if (lstTcr.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select contract that you want to adjust!", "Extend", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string ContStat = lstTcr.SelectedItems[0].SubItems[12].Text;

            if (ContStat == "Cancelled" || ContStat == "Reserved" || ContStat == "Hold" || ContStat == "Extend" || ContStat == "Forfeited" || ContStat == "Terminated")
            {
                MessageBox.Show("You can't adjust this contract!", "Adjustment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string StartDte = lstTcr.SelectedItems[0].SubItems[8].Text;
            string endDt = lstTcr.SelectedItems[0].SubItems[9].Text;
            int ContId = Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[0].Text);
            decimal SecDepAmt = Convert.ToDecimal(lstTcr.SelectedItems[0].SubItems[5].Text);

            shwRenew(Convert.ToInt32(lstTcr.SelectedItems[0].SubItems[1].Text), SecDepAmt, StartDte, endDt, "Adjustment", ContId);
        }
    }
}
