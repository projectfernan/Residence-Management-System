using ADODB;
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
    public partial class frmBedDetails : Form
    {
        public int RmNo;
        public string BedL;

        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public frmBedDetails()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBedDetails_Load(object sender, EventArgs e)
        {
            lbTitle.Text = "Bed " + BedL + " Details";

            HeaderAssigned();
            GetAssignedBed(RmNo,BedL);
        }

        void HeaderAssigned()
        {
            lstAssigned.Clear();
            int w = lstAssigned.Width / 4;


            lstAssigned.Columns.Add("", 0, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("", 0, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("Name", w, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("Start Date", w, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("End Date", w, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("Bed Status", w, HorizontalAlignment.Left);
        }

        void GetAssignedBed(int Room, string Bed)
        {
            try
            {
                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {
                    string dtFrm = Properties.Settings.Default.rmDtFrm;
                    string dtTo = Properties.Settings.Default.rmDtTo;

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("call slctAssignBed('" + dtFrm + "','" + dtTo + "'," + Room + ",'" + Bed + "')", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {
                            switch (rs.Fields["BedStatus"].Value.ToString())
                            {
                                case "Reserved":
                                    DateTime frm = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                    DateTime Start = Convert.ToDateTime(dtFrm);
                                    double diff = (Start - frm).TotalDays;

                                    if (diff <= 30)
                                    {
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                    break;
                                case "Cancelled":
                                    continue;
                                    break;
                                case "Extend":
                                    continue;
                                    break;
                                case "Forfeited":
                                    continue;
                                    break;
                            }

                            lstAssigned.Refresh();
                            ListViewItem viewlst = new ListViewItem();

                            DateTime StartDt = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                            DateTime EndDt = Convert.ToDateTime(rs.Fields["EndDate"].Value.ToString());

                            viewlst = lstAssigned.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["cId"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Name"].Value.ToString());
                            viewlst.SubItems.Add(StartDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(EndDt.ToString("yyyy-MM-dd"));
                            viewlst.SubItems.Add(rs.Fields["BedStatus"].Value.ToString());
                            rs.MoveNext();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBedDetails_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmBedDetails_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmBedDetails_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
