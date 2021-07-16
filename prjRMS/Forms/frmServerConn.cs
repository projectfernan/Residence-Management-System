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
    public partial class frmServerConn : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public delegate void MainDbStat(bool DbStat);
        public event MainDbStat RetStat;

        public frmServerConn()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconn conn = new DBconn();
            if (conn.MySqlConn(txtHost.Text, txtUid.Text, txtPwd.Text, txtDb.Text))
            {
                if (RetStat != null)
                {
                    RetStat(true);
                }
                MessageBox.Show("Successfully connected!", "Test Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (RetStat != null)
                {
                    RetStat(false);
                }
                MessageBox.Show("Failed to connect!","Test Connection",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = txtHost.Text;
            Properties.Settings.Default.Uid = txtUid.Text;
            Properties.Settings.Default.Pwd = txtPwd.Text;
            Properties.Settings.Default.Database = txtDb.Text;
            Properties.Settings.Default.Save();

            //Audit aud = new Audit();
            //aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Update Server Connection");

            MessageBox.Show("Successfullt saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmServerConn_Shown(object sender, EventArgs e)
        {
            txtHost.Text = Properties.Settings.Default.Server;
            txtUid.Text = Properties.Settings.Default.Uid;
            txtPwd.Text = Properties.Settings.Default.Pwd;
            txtDb.Text = Properties.Settings.Default.Database;
        }

        private void frmServerConn_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmServerConn_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmServerConn_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

    }
}
