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
    public partial class frmTenantTrans : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmTenantTrans()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTbills_Click(object sender, EventArgs e)
        {
            frmTenantBills shw = new frmTenantBills();
            shw.ShowDialog();
        }

        private void frmTenantTrans_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmTenantTrans_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmTenantTrans_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnTenantPDC_Click(object sender, EventArgs e)
        {
            try
            {
                frmPDClist shw = new frmPDClist();
                shw.ShowDialog();
            }
            catch { }
        }

        private void btnTInv_Click(object sender, EventArgs e)
        {
            frmPaidBills shw = new frmPaidBills();
            shw.ShowDialog();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            frmRefund shw = new frmRefund();
            shw.ShowDialog();
        }
    }
}
