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
    public partial class frmNewTenant : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string EventReq;
        public int tId;
        public string tFname, tRem, tLname, tMI, tNickName, tGender, tBdate, tContact, tGcontact, tSchool, tYrLevel, tCourse;

        public frmNewTenant()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstTcr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmInpTenantCont_Load(object sender, EventArgs e)
        {
            switch (EventReq) { 
                case "Save":
                    lbTitle.Text = "New Tenant";
                    btnSave.Text = "Save";
                    break;
                case "Update":
                    lbTitle.Text = "Update Tenant record";
                    btnSave.Text = "Update";

                        txtFname.Text = tFname;
                        txtLname.Text = tLname;
                        txtMI.Text = tMI;
                        txtNickName.Text = tNickName;
                        cboGender.Text = tGender;
                        dtBdate.Value = Convert.ToDateTime(tBdate);
                        txtContact.Text = tContact;
                        txtGcontact.Text = tGcontact;
                        txtSchool.Text = tSchool;
                        txtYrLevel.Text = tYrLevel;
                        txtCourse.Text = tCourse;
                        txtRem.Text = tRem;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (btnSave.Text) 
            { 
                case "Save":
                    DialogResult Ins = MessageBox.Show("Are you sure that your entries are correct?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Ins == DialogResult.Yes)
                    {
                        Thread th = new Thread(() =>
                        {
                            Action act = new Action(insTenant);
                            this.BeginInvoke(act);
                        });
                        th.Start();
                    }
                    break;

                case "Update":
                    DialogResult Upd = MessageBox.Show("Are you sure do you want to save changes?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Upd == DialogResult.Yes)
                    {
                        Thread th = new Thread(() =>
                        {
                            Action act = new Action(updTenant);
                            this.BeginInvoke(act);
                        });
                        th.Start();
                    }
                    break;
            }
        }

        private void insTenant() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime bDate = dtBdate.Value; 

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("call insTblTenantRec('" +
                                            txtFname.Text + "','" +
                                            txtLname.Text + "','" +       
                                            txtMI.Text + "','" +
                                            txtNickName.Text + "','" +
                                            cboGender.Text + "','" +
                                            bDate.ToString("yyyy-MM-dd") + "','" +
                                            txtContact.Text + "','" +
                                            txtGcontact.Text + "','" +
                                            txtSchool.Text + "','" +
                                            txtYrLevel.Text + "','" +
                                            txtCourse.Text + "','" +
                                            txtRem.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    string tName = txtLname.Text + "," + txtFname.Text + " " + txtMI.Text;

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Info of (" + tName + ") is saved.");

                    MessageBox.Show("New Tenant successfully saved!","Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmTenantCont shw = new frmTenantCont();
                    shw.ShowDialog();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updTenant()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                DateTime bDate = dtBdate.Value; 

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call updTblTenantRec(" +
                                            tId + ",'" +
                                            txtFname.Text + "','" +
                                            txtLname.Text + "','" +
                                            txtMI.Text + "','" +
                                            txtNickName.Text + "','" +
                                            cboGender.Text + "','" +
                                            bDate.ToString("yyyy-MM-dd") + "','" +
                                            txtContact.Text + "','" +
                                            txtGcontact.Text + "','" +
                                            txtSchool.Text + "','" +
                                            txtYrLevel.Text + "','" +
                                            txtCourse.Text + "','" +
                                            txtRem.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    string tName = txtLname.Text + "," + txtFname.Text + " " + txtMI.Text;

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Info of (" + tName + ") is updated.");

                    MessageBox.Show("Tenant's record successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmNewTenant_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmNewTenant_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmNewTenant_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
