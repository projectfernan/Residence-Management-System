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
    public partial class frmHelp : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmHelp()
        {
            InitializeComponent();
        }

        private void btnSearchRm_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("https://www.teamviewer.com/en/");
            System.Diagnostics.Process.Start("https://www.teamviewer.com/en/teamviewer-automatic-download/"); 
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHelp_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmHelp_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmHelp_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
