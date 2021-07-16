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
    public partial class frmTenantSigna : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int tsCid;
        public string ContType;

        public delegate void frmContSignaEvnt();
        public event frmContSignaEvnt Refresh;

        public frmTenantSigna()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTenantSigna_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmTenantSigna_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmTenantSigna_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        void insReserve()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insReservation(" + tsCid + ")", out ra, (int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(SubmitTeSigna);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void SubmitTeSigna() 
        {
            DialogResult ts = MessageBox.Show("Are you sure that your entry is correct?", "Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ts == DialogResult.Yes)
            {

                MessageBox.Show("Tenant signature successfully submitted!", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                insTenantSigna();

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Tenant Signature cId: (" + tsCid + ") submitted.");

                UpdContStat stat = new UpdContStat();
                stat.UpdateStatus(tsCid, "TenantSignStat", 1);
                if (stat.checkContStat(tsCid))
                {
                    if (ContType != "New")
                    {
                        stat.UpdSecDep(tsCid);
                    }

                    stat.ContStatus(tsCid, "Under Contract");
                    if (ContType == "Renew" || ContType == "Adjustment")
                    {
                        RoomBed b = new RoomBed();
                        if (b.chekBed(tsCid) == false)
                        {
                            insReserve();
                        }

                        if (ContType == "Adjustment")
                        {
                            UpdPdcStat uPdc = new UpdPdcStat();
                            uPdc.TransferPDC(tsCid);
                        }
                    }

                    if (ContType == "Extension")
                    {
                        stat.UpdExtension(tsCid);
                    }
                }

                if (Refresh != null)
                {
                    Refresh();
                }

                this.Close();
            }
        }

        void insTenantSigna()
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call insTblTenantSign(" +
                                               tsCid + ",'" +
                                               txtAssisted.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAssisted_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void frmTenantSigna_Load(object sender, EventArgs e)
        {

        }

    }
}
