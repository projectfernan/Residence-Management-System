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
    public partial class frmSubmitId : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int siCid;
        public string siOwner;
        public string ContType;

        public delegate void frmContSignaEvnt();
        public event frmContSignaEvnt Refresh;

        public frmSubmitId()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSubmitId_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmSubmitId_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmSubmitId_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmSubmitId_Load(object sender, EventArgs e)
        {
            loadIdType(cboIdType);
        }

        void loadIdType(ComboBox cbo)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    cbo.Items.Clear();
                    rs = conn.MySql.Execute("select IdType from tblIdType order by IdType", out ra, (int)CommandTypeEnum.adCmdText);
                    while (rs.EOF == false)
                    {
                        cbo.Items.Add(rs.Fields["IdType"].Value.ToString());
                        rs.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboIdType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
                    rs = conn.MySql.Execute("call insReservation(" + siCid + ")", out ra, (int)CommandTypeEnum.adCmdText);
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
                Action act = new Action(SubmitId);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void SubmitId() 
        {
            DialogResult sub = MessageBox.Show("Are you sure that your entries are correct?", "Sumbmit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sub == DialogResult.Yes)
            {

                MessageBox.Show("ID information successfully submitted!", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                insId();

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, siOwner + " Id submitted cId: (" + siCid + ")");

                UpdContStat stat = new UpdContStat();
                switch (siOwner)
                {
                    case "Tenant":
                        stat.UpdateStatus(siCid, "TenantIdStat", 1);
                        if (stat.checkContStat(siCid))
                        {
                            if (ContType != "New")
                            {
                                stat.UpdSecDep(siCid);
                            }

                            stat.ContStatus(siCid, "Under Contract");
                            if (ContType == "Renew" || ContType == "Adjustment")
                            {
                                RoomBed b = new RoomBed();
                                if (b.chekBed(siCid) == false)
                                {
                                    insReserve(); ;
                                }

                                if (ContType == "Adjustment")
                                {
                                    UpdPdcStat uPdc = new UpdPdcStat();
                                    uPdc.TransferPDC(siCid);
                                }
                            }

                            if (ContType == "Extension")
                            {
                                stat.UpdExtension(siCid);
                            }
                        }
                        break;
                    case "Guardian":
                        stat.UpdateStatus(siCid, "GuardianIdStat", 1);
                        if (stat.checkContStat(siCid))
                        {
                            if (ContType != "New")
                            {
                                stat.UpdSecDep(siCid);
                            }

                            stat.ContStatus(siCid, "Under Contract");
                            if (ContType == "Renew" || ContType == "Adjustment")
                            {
                                RoomBed b = new RoomBed();
                                if (b.chekBed(siCid))
                                {
                                    return;
                                }
                                insReserve();

                                if (ContType == "Adjustment")
                                {
                                    UpdPdcStat uPdc = new UpdPdcStat();
                                    uPdc.TransferPDC(siCid);
                                }
                            }

                            if (ContType == "Extension")
                            {
                                stat.UpdExtension(siCid);
                            }
                        }
                        break;
                }

                if (Refresh != null)
                {
                    Refresh();
                }

                this.Close();
            }
        }

        void insId() 
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if(conn.ServerConn()){
                    rs = conn.MySql.Execute("call insTblIdSubmitted(" +
                                            siCid + ",'" +
                                            siOwner + "','" + 
                                            cboIdType.Text + "','" +
                                            txtIdType.Text + "')",out ra,(int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIdType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnSubmit_Click(sender, e);
            }
        }

        private void frmSubmitId_Shown(object sender, EventArgs e)
        {
            cboIdType.Text = "";
            txtIdType.Text = "";
            cboIdType.Focus();
        }
    }
}
