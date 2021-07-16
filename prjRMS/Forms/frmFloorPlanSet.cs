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
    public partial class frmFloorPlanSet : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmFloorPlanSet()
        {
            InitializeComponent();
        }

        private void frmFloorPlanSet_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmFloorPlanSet_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmFloorPlanSet_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            browse();
            btnOpen.Visible = false;
        }

        void browse()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Floor Plan Pictures Path";
            FBD.ShowNewFolderButton = true;
            FBD.SelectedPath = @"C:\";
            FBD.ShowDialog();
            txtPath.Text = FBD.SelectedPath;
            FBD = null/* TODO Change to default(_) if this is not a reference type */;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FloorPlan = txtPath.Text;
            Properties.Settings.Default.Save();

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Floor plan pictures path updated.");

            MessageBox.Show("Floor plan pictures path succeesfully saved!","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
            btnOpen.Visible = true;
            this.Close();
        }

        private void frmFloorPlanSet_Load(object sender, EventArgs e)
        {
            txtPath.Text = Properties.Settings.Default.FloorPlan;
        }

    }
}
