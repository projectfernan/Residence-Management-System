using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjRMS
{
    public partial class frmDesig : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmDesig()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDesig_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmDesig_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmDesig_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmDesig_Load(object sender, EventArgs e)
        {
            headerDesig();
            fillDesig();

            ClearDesig();
        }

        void headerDesig()
        {
            lstDesig.Clear();
            int w = lstDesig.Width;

            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("Designation", w, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
            lstDesig.Columns.Add("", 0, HorizontalAlignment.Left);
        }

        void fillDesig()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tbldesig", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {

                        Application.UseWaitCursor = true;
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            lstDesig.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst.Font = new Font(viewlst.Font, FontStyle.Regular);
                            viewlst = lstDesig.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["Designation"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Settings"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["NewTenant"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["TenantContract"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["EditContract"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["RoomBilling"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["EditRmBill"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Miscellaneous"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["tTransaction"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Payments"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["ContractSign"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["MoveOut"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Terminate"].Value.ToString());
                            rs.MoveNext();
                        }
                    }
                }
                Application.UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(btnSave.Text)
            {
                case "Add":
                    AddDesig();
                    btnSave.Text = "Save";
                    break;
                case "Save":

                    if (txtDesig.Text == "")
                    {
                        MessageBox.Show("Please enter the designation you want!","Save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        txtDesig.Focus();
                        return;
                    }

                    DialogResult ys = MessageBox.Show("Are you sure that all of your entries are correct?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (ys == DialogResult.Yes)
                    {
                        if (insDesig())
                        {
                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Designation: (" + txtDesig.Text + ") created.");

                            ClearDesig();
                            MessageBox.Show("Designation successfully saved!","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            headerDesig();
                            fillDesig();
                            btnSave.Text = "Add";
                        }
                    }
                    break;
                case "Update":
                     if (txtDesig.Text == "")
                    {
                        MessageBox.Show("Please enter the designation you want!","Save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        txtDesig.Focus();
                        return;
                    }

                    DialogResult uys = MessageBox.Show("Are you sure do you want to save changes?","Update",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (uys == DialogResult.Yes)
                    {
                        if (updDesig())
                        {
                            Audit aud = new Audit();
                            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Designation: (" + txtDesig.Text + ") updated.");

                            ClearDesig();
                            MessageBox.Show("Designation successfully updated!","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            headerDesig();
                            fillDesig();
                            btnSave.Text = "Add";
                        }
                    }
                    break;
            }
        }

        bool insDesig() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblDesig('" + txtDesig.Text + "'," +
                                                                   Convert.ToInt32(chkSettings.Checked) +
                                                             "," + Convert.ToInt32(chkNewTenant.Checked) +
                                                             "," + Convert.ToInt32(chkTeCont.Checked) +
                                                             "," + Convert.ToInt32(chkEditTeCont.Checked) +
                                                             "," + Convert.ToInt32(chkRmBill.Checked) +
                                                             "," + Convert.ToInt32(chkEditRmBill.Checked) +
                                                             "," + Convert.ToInt32(chkMisce.Checked) +
                                                             "," + Convert.ToInt32(chkTeTrans.Checked) +
                                                             "," + Convert.ToInt32(chkPayments.Checked) +
                                                             "," + Convert.ToInt32(chkContSign.Checked) +
                                                             "," + Convert.ToInt32(chkMoveOut.Checked) +
                                                             "," + Convert.ToInt32(chkTerminate.Checked) + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    return true;
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

        bool updDesig()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updTblDesig(" + Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[0].Text) + 
                                                             ",'" + txtDesig.Text + 
                                                             "'," + Convert.ToInt32(chkSettings.Checked) +
                                                             "," + Convert.ToInt32(chkNewTenant.Checked) +
                                                             "," + Convert.ToInt32(chkTeCont.Checked) +
                                                             "," + Convert.ToInt32(chkEditTeCont.Checked) +
                                                             "," + Convert.ToInt32(chkRmBill.Checked) +
                                                             "," + Convert.ToInt32(chkEditRmBill.Checked) +
                                                             "," + Convert.ToInt32(chkMisce.Checked) +
                                                             "," + Convert.ToInt32(chkTeTrans.Checked) +
                                                             "," + Convert.ToInt32(chkPayments.Checked) +
                                                             "," + Convert.ToInt32(chkContSign.Checked) +
                                                             "," + Convert.ToInt32(chkMoveOut.Checked) +
                                                             "," + Convert.ToInt32(chkTerminate.Checked) + ")", out ra, (int)CommandTypeEnum.adCmdText);
                    return true;
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

        bool delDesig()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    int Id = Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[0].Text);
                    rs = conn.MySql.Execute("delete from tbldesig where Id = " + Id, out ra, (int)CommandTypeEnum.adCmdText);
                    return true;
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

        void ClearDesig()
        {
             txtDesig.Text = "";
             txtDesig.Enabled = false;

             chkSettings.Checked = false;
             chkNewTenant.Checked = false;
             chkTeCont.Checked = false;
             chkEditTeCont.Checked = false;
             chkRmBill.Checked = false;
             chkEditRmBill.Checked = false;
             chkMisce.Checked = false;
             chkTeTrans.Checked = false;
             chkPayments.Checked = false;
             chkContSign.Checked = false;
             chkMoveOut.Checked = false;
             chkTerminate.Checked = false;

             chkSettings.Enabled = false;
             chkNewTenant.Enabled = false;
             chkTeCont.Enabled = false;
             chkEditTeCont.Enabled = false;
             chkRmBill.Enabled = false;
             chkEditRmBill.Enabled = false;
             chkMisce.Enabled = false;
             chkTeTrans.Enabled = false;
             chkPayments.Enabled = false;
             chkContSign.Enabled = false;
             chkMoveOut.Enabled = false;
             chkTerminate.Enabled = false;

        }

        void AddDesig()
        {
            txtDesig.Text = "";
            txtDesig.Enabled = true;

            chkSettings.Checked = false;
            chkNewTenant.Checked = false;
            chkTeCont.Checked = false;
            chkEditTeCont.Checked = false;
            chkRmBill.Checked = false;
            chkEditRmBill.Checked = false;
            chkMisce.Checked = false;
            chkTeTrans.Checked = false;
            chkPayments.Checked = false;
            chkContSign.Checked = false;
            chkMoveOut.Checked = false;
            chkTerminate.Checked = false;

            chkSettings.Enabled = true;
            chkNewTenant.Enabled = true;
            chkTeCont.Enabled = true;
            chkEditTeCont.Enabled = true;
            chkRmBill.Enabled = true;
            chkEditRmBill.Enabled = true;
            chkMisce.Enabled = true;
            chkTeTrans.Enabled = true;
            chkPayments.Enabled = true;
            chkContSign.Enabled = true;
            chkMoveOut.Enabled = true;
            chkTerminate.Enabled = true;

            txtDesig.Focus();
        }

        void EditDesig()
        {
            txtDesig.Enabled = true;

            chkSettings.Enabled = true;
            chkNewTenant.Enabled = true;
            chkTeCont.Enabled = true;
            chkEditTeCont.Enabled = true;
            chkRmBill.Enabled = true;
            chkEditRmBill.Enabled = true;
            chkMisce.Enabled = true;
            chkTeTrans.Enabled = true;
            chkPayments.Enabled = true;
            chkContSign.Enabled = true;
            chkMoveOut.Enabled = true;
            chkTerminate.Enabled = true;

            txtDesig.Focus();
        }

        private void lstDesig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDesig.SelectedItems.Count > 0) 
            {
                txtDesig.Text = lstDesig.SelectedItems[0].SubItems[1].Text;
                chkSettings.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[2].Text));
                chkNewTenant.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[3].Text));
                chkTeCont.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[4].Text));
                chkEditTeCont.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[5].Text));
                chkRmBill.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[6].Text));
                chkEditRmBill.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[7].Text));
                chkMisce.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[8].Text));
                chkTeTrans.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[9].Text));
                chkPayments.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[10].Text));
                chkContSign.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[11].Text));
                chkMoveOut.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[12].Text));
                chkTerminate.Checked = Convert.ToBoolean(Convert.ToInt32(lstDesig.SelectedItems[0].SubItems[13].Text));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstDesig.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Please select designation record that you want to edit!","Edit",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            btnSave.Text = "Update";
            EditDesig();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (lstDesig.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Please select designation record that you want to delete!","Delete",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DialogResult dys = MessageBox.Show("If you delete this designation the system account that using this designation will get an error! Are you sure do you want to continue?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (dys == DialogResult.Yes) 
            {
                if (delDesig())
                {
                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Designation: (" + txtDesig.Text + ") deleted.");

                    MessageBox.Show("Designation record is successfully deleted!","Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    headerDesig();
                    fillDesig();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            headerDesig();
            fillDesig();

            ClearDesig();
            btnSave.Text = "Add";
        }
    }
}
