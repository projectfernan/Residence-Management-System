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
    public partial class frmSysAccMenu : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmSysAccMenu()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSysAccMenu_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmSysAccMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmSysAccMenu_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnDesig_Click(object sender, EventArgs e)
        {
            frmDesig shw = new frmDesig();
            shw.ShowDialog();
        }

        private void btnSysAcc_Click(object sender, EventArgs e)
        {
            frmSysAcc shw = new frmSysAcc();
            shw.ShowDialog();
        }
    }
}
