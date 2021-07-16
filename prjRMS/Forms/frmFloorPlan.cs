using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace prjRMS
{
    public partial class frmFloorPlan : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int roomNo;

        public frmFloorPlan()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFloorPlan_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmFloorPlan_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmFloorPlan_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmFloorPlan_Load(object sender, EventArgs e)
        {
            lbTitle.Text = "Room Number " + roomNo.ToString() + " Floor Plan";
            FpPic.Image = ConvertToBitmap();
        }

        Bitmap ConvertToBitmap()
        {
            try
            {
                string path = Properties.Settings.Default.FloorPlan;
                string imgName = roomNo.ToString();
                string FullPath = path + @"\" + imgName + ".jpeg";

                Bitmap bitmap;
                using (Stream bmpStream = System.IO.File.Open(FullPath, System.IO.FileMode.Open))
                {
                    Image image = Image.FromStream(bmpStream);

                    bitmap = new Bitmap(image);

                }
                return bitmap;
            }
            catch 
            {
                try
                {
                    string path = Properties.Settings.Default.FloorPlan;
                    string imgName = roomNo.ToString();
                    string FullPath = path + @"\" + imgName + ".jpg";

                    Bitmap bitmap;
                    using (Stream bmpStream = System.IO.File.Open(FullPath, System.IO.FileMode.Open))
                    {
                        Image image = Image.FromStream(bmpStream);

                        bitmap = new Bitmap(image);

                    }
                    return bitmap;
                }
                catch 
                {
                    string path = Application.StartupPath + @"\NoImg.jpg";

                    Bitmap bitmap;
                    using (Stream bmpStream = System.IO.File.Open(path, System.IO.FileMode.Open))
                    {
                        Image image = Image.FromStream(bmpStream);

                        bitmap = new Bitmap(image);

                    }
                    return bitmap;
                }
            }
        }
    }
}
