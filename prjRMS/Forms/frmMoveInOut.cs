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
    public partial class frmMoveInOut : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmMoveInOut()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMoveInOut_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmMoveInOut_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmMoveInOut_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnContractRem_Click(object sender, EventArgs e)
        {
            frmMovingOut shw = new frmMovingOut();
            shw.ShowDialog();
        }

        private void btnReservedRem_Click(object sender, EventArgs e)
        {
            frmMoveIn shw = new frmMoveIn();
            shw.ShowDialog();
        }
    }
}
