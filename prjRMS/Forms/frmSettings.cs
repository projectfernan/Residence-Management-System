using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjRMS
{
    public partial class frmSettings : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmSettings()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNewContractRec shw = new frmNewContractRec();
            shw.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmServerConn shw = new frmServerConn();
            shw.ShowDialog();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            frmRoomSettings shw = new frmRoomSettings();
            shw.ShowDialog();
        }

        private void frmSettings_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmSettings_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmSettings_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnIdType_Click(object sender, EventArgs e)
        {
            frmIdType shw = new frmIdType();
            shw.ShowDialog();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSetReminders shw = new frmSetReminders();
            shw.ShowDialog();
        }

        private void btnPenalty_Click(object sender, EventArgs e)
        {
            frmPenalty shw = new frmPenalty();
            shw.ShowDialog();
        }

        private void btnFloorPlan_Click(object sender, EventArgs e)
        {
            frmFloorPlanSet shw = new frmFloorPlanSet();
            shw.ShowDialog();
        }

        private void btnSysAcc_Click(object sender, EventArgs e)
        {
            frmSysAccMenu shw = new frmSysAccMenu();
            shw.ShowDialog();
        }

        private void btnBedReq_Click(object sender, EventArgs e)
        {
            frmBedReqDelay shw = new frmBedReqDelay();
            shw.ShowDialog();
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            frmAuditLogs shw = new frmAuditLogs();
            shw.ShowDialog();
        }
    }
}
