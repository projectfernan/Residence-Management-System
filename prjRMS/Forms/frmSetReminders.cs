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
    public partial class frmSetReminders : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmSetReminders()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetReminders_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmSetReminders_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmSetReminders_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnReservedRem_Click(object sender, EventArgs e)
        {
            frmResReminders shw = new frmResReminders();
            shw.ShowDialog();
        }

        private void btnContractRem_Click(object sender, EventArgs e)
        {
            frmContReminders shw = new frmContReminders();
            shw.ShowDialog();
        }
    }
}
