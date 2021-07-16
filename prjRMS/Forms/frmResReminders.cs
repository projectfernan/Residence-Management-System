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
    public partial class frmResReminders : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmResReminders()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmResReminders_Load(object sender, EventArgs e)
        {
            txtTotalDays.Value = Properties.Settings.Default.ResTotalDays;
            txtLeftDays.Value = Properties.Settings.Default.ResLeftDays;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResTotalDays = txtTotalDays.Value;
            Properties.Settings.Default.ResLeftDays = txtLeftDays.Value;
            Properties.Settings.Default.Save();

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Reserved expiration reminder updated.");

            MessageBox.Show("Reserved expiration reminder is successfully set!","Set",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void frmResReminders_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmResReminders_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmResReminders_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }

}
