using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace prjRMS
{
    public partial class uCtrlRoom : UserControl
    {
        public int ucRoomNo;
        public string ucFloor;

        public string ucAstat,ucBstat,ucCstat,ucDstat;
        public bool ucA, ucB, ucC, ucD;


        public uCtrlRoom()
        {
            InitializeComponent();
        }

        private void uCtrlRoom_Load(object sender, EventArgs e)
        {
            lbFloor.Text = ucFloor;
            lbRmNo.Text = ucRoomNo.ToString();

            Thread th = new Thread(() =>
            {
                Action act = new Action(loadA);
                this.BeginInvoke(act);
            });
            th.Start();

            Thread th2 = new Thread(() =>
            {
                Action act = new Action(loadB);
                this.BeginInvoke(act);
            });
            th2.Start();

            Thread th3 = new Thread(() =>
            {
                Action act = new Action(loadC);
                this.BeginInvoke(act);
            });
            th3.Start();

            Thread th4 = new Thread(() =>
            {
                Action act = new Action(loadD);
                this.BeginInvoke(act);
            });
            th4.Start();
        }

        void loadA() { 
            switch(ucAstat)
            {
                case "Hold":
                    BedA.BackColor = Color.Pink;
                    break;
                case "Reserved":
                    BedA.BackColor = Color.Yellow;
                    break;
                case "Under Contract":
                    BedA.BackColor = Color.Red;
                    break;
                default:
                    BedA.BackColor = Color.Lime;
                    break;
            }

            BedA.Visible = ucA;
            lbA.Visible = ucA;
        }

        void loadB() {
            switch (ucBstat)
            {
                case "Hold":
                    BedB.BackColor = Color.Pink;
                    break;
                case "Reserved":
                    BedB.BackColor = Color.Yellow;
                    break;
                case "Under Contract":
                    BedB.BackColor = Color.Red;
                    break;
                default:
                    BedB.BackColor = Color.Lime;
                    break;
            }

            BedB.Visible = ucB;
            lbB.Visible = ucB;
        }

        void loadC() {
            switch (ucCstat)
            {
                case "Hold":
                    BedC.BackColor = Color.Pink;
                    break;
                case "Reserved":
                    BedC.BackColor = Color.Yellow;
                    break;
                case "Under Contract":
                    BedC.BackColor = Color.Red;
                    break;
                default:
                    BedC.BackColor = Color.Lime;
                    break;
            }

            BedC.Visible = ucC;
            lbC.Visible = ucC;
        }

        void loadD() {
            switch (ucDstat)
            {
                case "Hold":
                    BedD.BackColor = Color.Pink;
                    break;
                case "Reserved":
                    BedD.BackColor = Color.Yellow;
                    break;
                case "Under Contract":
                    BedD.BackColor = Color.Red;
                    break;
                default:
                    BedD.BackColor = Color.Lime;
                    break;
            }

            BedD.Visible = ucD;
            lbD.Visible = ucD;
        }

        private void reserveBedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssignBed shw = new frmAssignBed();
            shw.RmNo = lbRmNo.Text;
            shw.Floor = lbFloor.Text;
            shw.ShowDialog();
        }

        private void viewFloorPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFloorPlan shw = new frmFloorPlan();
            shw.roomNo = ucRoomNo;
            shw.ShowDialog();
        }

        private void BedA_Click(object sender, EventArgs e)
        {
            frmBedDetails shw = new frmBedDetails();
            shw.BedL = "A";
            shw.RmNo = Convert.ToInt32(lbRmNo.Text);
            shw.ShowDialog();
        }

        private void BedB_Click(object sender, EventArgs e)
        {
            frmBedDetails shw = new frmBedDetails();
            shw.BedL = "B";
            shw.RmNo = Convert.ToInt32(lbRmNo.Text);
            shw.ShowDialog();
        }

        private void BedC_Click(object sender, EventArgs e)
        {
            frmBedDetails shw = new frmBedDetails();
            shw.BedL = "C";
            shw.RmNo = Convert.ToInt32(lbRmNo.Text);
            shw.ShowDialog();
        }

        private void BedD_Click(object sender, EventArgs e)
        {
            frmBedDetails shw = new frmBedDetails();
            shw.BedL = "D";
            shw.RmNo = Convert.ToInt32(lbRmNo.Text);
            shw.ShowDialog();
        }

        private void lbA_Click(object sender, EventArgs e)
        {
            frmBedDetails shw = new frmBedDetails();
            shw.BedL = "A";
            shw.RmNo = Convert.ToInt32(lbRmNo.Text);
            shw.ShowDialog();
        }

        private void lbB_Click(object sender, EventArgs e)
        {
            frmBedDetails shw = new frmBedDetails();
            shw.BedL = "B";
            shw.RmNo = Convert.ToInt32(lbRmNo.Text);
            shw.ShowDialog();
        }

        private void lbC_Click(object sender, EventArgs e)
        {
            frmBedDetails shw = new frmBedDetails();
            shw.BedL = "C";
            shw.RmNo = Convert.ToInt32(lbRmNo.Text);
            shw.ShowDialog();
        }

        private void lbD_Click(object sender, EventArgs e)
        {
            frmBedDetails shw = new frmBedDetails();
            shw.BedL = "D";
            shw.RmNo = Convert.ToInt32(lbRmNo.Text);
            shw.ShowDialog();
        }
    }
}
