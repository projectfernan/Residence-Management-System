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
    public partial class frmGuardianSigna : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int gsCid;
        public string ContType;

        public delegate void frmContSignaEvnt();
        public event frmContSignaEvnt Refresh;

        public frmGuardianSigna()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGuardianSigna_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmGuardianSigna_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmGuardianSigna_MouseUp(object sender, MouseEventArgs e)
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
                    rs = conn.MySql.Execute("call insReservation(" + gsCid + ")", out ra, (int)CommandTypeEnum.adCmdText);
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
                Action act = new Action(SubmitGsigna);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void SubmitGsigna() 
        {
            DialogResult gs = MessageBox.Show("Are you sure that your entries are correct?", "Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (gs == DialogResult.Yes)
            {
                MessageBox.Show("Parent/Guardian sign is successfully submitted!", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                insGuardianSigna();

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Guardian Signature cId: (" + gsCid + ") submitted.");

                UpdContStat stat = new UpdContStat();
                stat.UpdateStatus(gsCid, "GuardianSignStat", 1);

                if (stat.checkContStat(gsCid))
                {
                    if (ContType != "New")
                    {
                        stat.UpdSecDep(gsCid);
                    }

                    stat.ContStatus(gsCid, "Under Contract");
                    if (ContType == "Renew" || ContType == "Adjustment")
                    {
                        RoomBed b = new RoomBed();
                        if (b.chekBed(gsCid) == false)
                        {
                            insReserve();
                        }

                        if (ContType == "Adjustment")
                        {
                            UpdPdcStat uPdc = new UpdPdcStat();
                            uPdc.TransferPDC(gsCid);
                        }
                    }

                    if (ContType == "Extension")
                    {
                        stat.UpdExtension(gsCid);
                    }
                }

                if (Refresh != null)
                {
                    Refresh();
                }

                this.Close();
            }
        }

        void insGuardianSigna() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn()) 
                {
                    rs = conn.MySql.Execute("call insTblGuardianSign(" +
                                                   gsCid + ",'" +
                                                   txtGuardian.Text + "','" +
                                                   txtAssisted.Text + "')",out ra,(int)CommandTypeEnum.adCmdText);    
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtAssisted_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnSubmit_Click(sender, e);
            }
        }
    }
}
