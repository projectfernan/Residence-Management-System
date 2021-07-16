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
    public partial class frmBedReqDelay : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmBedReqDelay()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBedReqDelay_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmBedReqDelay_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmBedReqDelay_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmBedReqDelay_Load(object sender, EventArgs e)
        {
            txtDelay.Value = Properties.Settings.Default.bReqDelay;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.bReqDelay = txtDelay.Value;
            Properties.Settings.Default.Save();

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Bed request delay updated.");

            MessageBox.Show("Bed request delay successfully set!","Set",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void txtDelay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnSet_Click(sender, e);
            }
        }
    }
}
