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
    public partial class frmPenalty : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmPenalty()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPenalty_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmPenalty_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmPenalty_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.billDay = txtDateM.Value.ToString();
            Properties.Settings.Default.RentPena = txtPenalty.Value.ToString();
            Properties.Settings.Default.Save();

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Penalty settings updated.");

            MessageBox.Show("Penalty settings successfully set!","Set",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void frmPenalty_Load(object sender, EventArgs e)
        {
            txtDateM.Value = Convert.ToDecimal(Properties.Settings.Default.billDay);
            txtPenalty.Value = Convert.ToDecimal(Properties.Settings.Default.RentPena);
        }

        
    }
}
