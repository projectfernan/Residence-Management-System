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
    public partial class frmContReminders : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmContReminders()
        {
            InitializeComponent();
        }

        private void frmContReminders_Load(object sender, EventArgs e)
        {
            txtLeftDays.Value = Properties.Settings.Default.ContLeftDays;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContReminders_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmContReminders_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmContReminders_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ContLeftDays = txtLeftDays.Value;
            Properties.Settings.Default.Save();

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Contract expiration reminder updated.");

            MessageBox.Show("Contract expiration reminder is successfully set!","Set",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }
    }
}
