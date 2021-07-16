using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace prjRMS
{
    public partial class frmUpdMoving : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string wLoad;
        public int mID, cID;
        public DateTime MoveDate;

        public frmUpdMoving()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdMoving_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmUpdMoving_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmUpdMoving_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (wLoad == "MoveIn")
            {
                Thread th = new Thread(() =>
                {
                    Action act = new Action(UpdateMoveIn);
                    this.BeginInvoke(act);
                });
                th.Start();
            }
            else 
            {
                Thread th1 = new Thread(() =>
                {
                    Action act = new Action(UpdateMoveOut);
                    this.BeginInvoke(act);
                });
                th1.Start();
            }
        }

        void UpdateMoveIn() 
        {
            try 
            {
                DialogResult ys = MessageBox.Show("Are you sure do you want to update move in date?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ys != DialogResult.Yes) 
                {
                    return;
                }

                DBconn conn = new DBconn();

                DateTime moveIn = dtDate.Value;

                string UpdMovein = "call updMoveIN(" + mID + "," + cID + ",'" + moveIn.ToString("yyyy-MM-dd HH:mm") +"')";

                conn.rsCUD(UpdMovein);

                MessageBox.Show("Move in date successfully updated!","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void UpdateMoveOut()
        {
            try
            {
                DialogResult ys = MessageBox.Show("Are you sure do you want to update move out date?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ys != DialogResult.Yes)
                {
                    return;
                }

                DBconn conn = new DBconn();

                DateTime moveOut = dtDate.Value;

                string UpdMoveout = "call updMoveOut(" + mID + "," + cID + ",'" + moveOut.ToString("yyyy-MM-dd HH:mm") + "')";

                conn.rsCUD(UpdMoveout);

                MessageBox.Show("Move out date successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUpdMoving_Load(object sender, EventArgs e)
        {
          dtDate.Value = MoveDate;
        }
    }
}
