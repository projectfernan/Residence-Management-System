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
    public partial class frmContractSigning : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        frmSubmitId shw = new frmSubmitId();
        frmTenantSigna ts = new frmTenantSigna();
        frmGuardianSigna gs = new frmGuardianSigna();

        int CID;
        string tName;

        public frmContractSigning()
        {
            InitializeComponent();
        }

        private void frmContractSigning_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmContractSigning_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmContractSigning_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContractSigning_Load(object sender, EventArgs e)
        {
            headerTpi();
            //fillTpi();

            headerSigning();
        }

        public void headerTpi()
        {
            lstTpi.Clear();
            int w = lstTpi.Width / 4;

            lstTpi.Columns.Add("", 0, HorizontalAlignment.Left);
            lstTpi.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("ContractName", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("ContractType", w, HorizontalAlignment.Left);
            lstTpi.Columns.Add("ContractStatus", w, HorizontalAlignment.Left);
        }

        void headerSigning()
        {
            lstSigning.Clear();
            int w = lstSigning.Width;

            lstSigning.Columns.Add("", 0, HorizontalAlignment.Left);
            lstSigning.Columns.Add("Item", w, HorizontalAlignment.Left);
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

                    //rs = conn.MySql.Execute("select Id,Name,ContractName,ContractType,ContractStatus from vwesigningname where " +
                    //                        "(TenantIdStat = 0 or TenantSignStat = 0 or GuardianIdStat = 0 or GuardianSignStat = 0) " +
                    //                        "and (GuardianSign <> GuardianSignStat or GuardianId <> GuardianIdStat or TenantSign <> TenantSignStat or " +
                    //                        "TenantId <> TenantIdStat)", out rc, (int)CommandTypeEnum.adCmdText);

                    rs = conn.MySql.Execute("select Id,Name,ContractName,ContractType,ContractStatus from vwesigningname where " + 
                                            "GuardianSign = 1 or GuardianId = 1 or TenantSign = 1 or " +
                                            "TenantId = 1", out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
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

        public void findTpi()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    //rs = conn.MySql.Execute("select Id,Name,ContractName,ContractType,ContractStatus from vwesigningname where " 
                    //                        + cboCateg.Text + " like '" + txtKeycode.Text +
                    //                        "%' and (TenantIdStat = 0 or TenantSignStat = 0 or GuardianIdStat = 0 or GuardianSignStat = 0) " + 
                    //                        "and (GuardianSign <> GuardianSignStat or GuardianId <> GuardianIdStat or TenantSign <> TenantSignStat or " +
                    //                        "TenantId <> TenantIdStat)", out rc, (int)CommandTypeEnum.adCmdText);

                    rs = conn.MySql.Execute("select Id,Name,ContractName,ContractType,ContractStatus from vwesigningname where "
                                            + cboCateg.Text + " like '%" + txtKeycode.Text + "%' and (GuardianSign = 1 or GuardianId = 1 or TenantSign = 1 or " +
                                            "TenantId = 1)", out rc, (int)CommandTypeEnum.adCmdText);

                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstTpi.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstTpi.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractName"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractType"].Value.ToString());
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

        void AddSigningList(int cId) 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("select Id,TenantId,TenantIdStat,TenantSign,TenantSignStat,GuardianId,GuardianIdStat," + 
                                            "GuardianSign,GuardianSignStat from vwesigningname where Id = " + cId, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false) 
                    {
                        headerSigning();
                        string Id = rs.Fields["Id"].Value.ToString();

                        if (rs.Fields["TenantIdStat"].Value.ToString() == "0" && rs.Fields["TenantId"].Value.ToString() == "1")
                        {
                            addScList(Id, "Tenant I.D.");
                        }

                        if (rs.Fields["TenantSignStat"].Value.ToString() == "0" && rs.Fields["TenantSign"].Value.ToString() == "1")
                        {
                            addScList(Id, "Tenant contract sign");
                        }

                        if (rs.Fields["GuardianIdStat"].Value.ToString() == "0" && rs.Fields["GuardianId"].Value.ToString() == "1")
                        {
                            addScList(Id, "Parent or guardian I.D.");
                        }

                        if (rs.Fields["GuardianSignStat"].Value.ToString() == "0" && rs.Fields["GuardianSign"].Value.ToString() == "1")
                        {
                            addScList(Id, "Parent or guardian sign");
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void addScList(string Id,string item)
        {
            try
            {
                ListViewItem viewlst = new ListViewItem();
                viewlst = lstSigning.Items.Add(Id);
                viewlst.SubItems.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void lstTpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(FillDocu);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void FillDocu() 
        {
            try
            {
                if (lstTpi.SelectedItems.Count > 0)
                {
                    CID = Convert.ToInt32(lstTpi.SelectedItems[0].SubItems[0].Text);
                    tName = lstTpi.SelectedItems[0].SubItems[1].Text;
                    shw.ContType = lstTpi.SelectedItems[0].SubItems[3].Text;
                    gs.ContType = lstTpi.SelectedItems[0].SubItems[3].Text;
                    ts.ContType = lstTpi.SelectedItems[0].SubItems[3].Text;
                    AddSigningList(CID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            headerSigning();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submit();
        }

        void submit() {
            try
            {
                if (lstSigning.SelectedItems.Count > 0)
                {
                    int cId = Convert.ToInt32(lstSigning.SelectedItems[0].SubItems[0].Text);
                    string itm = lstSigning.SelectedItems[0].SubItems[1].Text;
                    
                    switch (itm)
                    {
                        case "Tenant I.D.":
                            shw.siCid = cId;
                            shw.siOwner = "Tenant";
                            shw.Refresh += new frmSubmitId.frmContSignaEvnt(FillDocu);
                            shw.ShowDialog();
                            break;
                        case "Parent or guardian I.D.":
                            shw.siCid = cId;
                            shw.siOwner = "Guardian";
                            shw.Refresh += new frmSubmitId.frmContSignaEvnt(FillDocu);
                            shw.ShowDialog();
                            break;
                        case "Tenant contract sign":
                            ts.tsCid = cId;
                            ts.Refresh += new frmTenantSigna.frmContSignaEvnt(FillDocu);
                            ts.ShowDialog();
                            break;
                        case "Parent or guardian sign":
                            gs.gsCid = cId;
                            gs.Refresh += new frmGuardianSigna.frmContSignaEvnt(FillDocu);
                            gs.ShowDialog();
                            break;
                    }
                }
                else {
                    MessageBox.Show("Please select required document that you want to submit!","Submit",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewDoc_Click(object sender, EventArgs e)
        {
            frmViewDocu shw = new frmViewDocu();
            shw.CID = CID;
            shw.tName = tName;
            shw.ShowDialog();
        }
    }
}
