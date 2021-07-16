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
    public partial class frmFindBed : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmFindBed()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFindBed_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmFindBed_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmFindBed_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void cboMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindRoom();
        }

        void FindRoom() {
            MainForm f = new MainForm();
            string frm = dtFrom.Value.ToString();
            string to = dtTo.Value.ToString();

            Properties.Settings.Default.rmMode = cboMode.Text;
            Properties.Settings.Default.rmFloor = cboFloor.Text;
            Properties.Settings.Default.rmDtFrm = frm;
            Properties.Settings.Default.rmDtTo = to;
            Properties.Settings.Default.Save();

            f.tmeReqList.Enabled = true;

            this.Close();
        }

        private void frmFindBed_Load(object sender, EventArgs e)
        {

        }

    }
}
