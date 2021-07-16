using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace prjRMS
{
    public partial class frmAssignBed : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public string RmNo, Floor;

        public frmAssignBed()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAssignBed_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmAssignBed_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmAssignBed_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmAssignBed_Load(object sender, EventArgs e)
        {
            HeaderBed();
            GetFillBed(Convert.ToInt32(RmNo));

            HeaderAssigned();
        }

        void HeaderBed()
        {
            lstBed.Clear();
            int w = lstBed.Width;

            lstBed.Columns.Add("", 0, HorizontalAlignment.Left);
            lstBed.Columns.Add("", 0, HorizontalAlignment.Left);
            lstBed.Columns.Add("Bed", w, HorizontalAlignment.Left);
        }

        void HeaderAssigned()
        {
            lstAssigned.Clear();
            int w = lstAssigned.Width / 4;

            lstAssigned.Columns.Add("", 0, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("", 0, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("Name", 130, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("Start Date", 120, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("End Date", 120, HorizontalAlignment.Left);
            lstAssigned.Columns.Add("Bed Status", 100, HorizontalAlignment.Left);
        }

        public void GetFillBed(int Room)
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblbeds where RoomNo = " + Room + " order by Bed", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstBed.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstBed.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Bed"].Value.ToString());
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

        private void lstBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HeaderAssigned();
                GetAssignedBed(Convert.ToInt32(RmNo),lstBed.SelectedItems[0].SubItems[2].Text);
            }
            catch { 
            
            }
        }

        void GetAssignedBed(int Room,string Bed)
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

        bool GetExistBed(int Room, string Bed)
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
                        switch (rs.Fields["BedStatus"].Value.ToString())
                        {
                            case "Reserved":
                                DateTime frm = Convert.ToDateTime(rs.Fields["StartDate"].Value.ToString());
                                DateTime Start = Convert.ToDateTime(dtFrm);
                                double diff = (Start - frm).TotalDays;

                                if (diff <= 30)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                                break;
                            case "Hold":
                                return true;
                                break;
                            case "Under Contract":
                                return true;
                                break;
                            default:
                                return false;
                                break;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lstBed.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Please select bed record!","Assign",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            int RmNum = Convert.ToInt32(RmNo);
            string BedLetter = lstBed.SelectedItems[0].SubItems[2].Text;

            if (lstBed.SelectedItems.Count == 0) {
                MessageBox.Show("Please select bed you want to assign!","");
                return;
            }

            if (lstAssigned.Items.Count > 0)
            {
                MessageBox.Show("Bed " + BedLetter + " is already occupied!","Assign",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            frmReserveList shw = new frmReserveList();
            shw.RmNo = RmNum;
            shw.Bed = BedLetter;
            shw.vAssign = true;
            shw.ShowDialog();
        }

        private void btnReAssign_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Action act = new Action(ReAssign);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void ReAssign() 
        {
            if (lstAssigned.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select assigned record that you want the bed to re-assign!", "Re-Assign", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstAssigned.SelectedItems[0].SubItems[5].Text == "Hold")
            {
                MessageBox.Show("Unable to re-assigned this record!", "Re-assign", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string Tname = lstAssigned.SelectedItems[0].SubItems[2].Text;
            DialogResult ins = MessageBox.Show("Are you sure do you want to re-assign the bed of " + Tname + "?", "Re-Assign", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ins == DialogResult.Yes)
            {
                int cId = Convert.ToInt32(lstAssigned.SelectedItems[0].SubItems[1].Text);
                int AsId = Convert.ToInt32(lstAssigned.SelectedItems[0].SubItems[0].Text);

                reInsReservation(cId);
                UpdContStat upd = new UpdContStat();
                upd.UpdBhMoveOut(cId, DateTime.Now);

                if (delAssigned(AsId))
                {
                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Re-assign (" + Tname + ") cId: (" + cId.ToString() + ")");

                    MessageBox.Show(Tname + " is return to reservation list for re-assigning!", "Re-Assign", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    frmReserveList shw = new frmReserveList();
                    shw.ShowDialog();
                    this.Close();
                }
            }
        }

        void reInsReservation(int ContId) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("call insReservation(" + ContId + ")", out ra, (int)CommandTypeEnum.adCmdText);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool delAssigned(int AssId)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("delete from tblreserved where Id = " + AssId, out ra, (int)CommandTypeEnum.adCmdText);

                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (lstBed.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select bed record!", "Assign", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int RmNum = Convert.ToInt32(RmNo);
            string BedLetter = lstBed.SelectedItems[0].SubItems[2].Text;

            if (lstBed.SelectedItems.Count == 0) {
                MessageBox.Show("Please select a bed you want to hold!","Hold",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (lstAssigned.Items.Count > 0)
            {
                MessageBox.Show("Bed " + BedLetter + " is already occupied!", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmContApplyList shw = new frmContApplyList();
            shw.RmNo = RmNum;
            shw.Bed = BedLetter;
            shw.ShowDialog();

        }

        private void btnUnhold_Click(object sender, EventArgs e)
        {
            if (lstAssigned.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select assigned record that you want the bed to unhold!", "Unhold", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstAssigned.SelectedItems[0].SubItems[5].Text != "Hold") {
                MessageBox.Show("Unable to unhold this record!", "Unhold", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string Tname = lstAssigned.SelectedItems[0].SubItems[2].Text;
            DialogResult ins = MessageBox.Show("Are you sure do you want to unhold the bed of " + Tname + "?", "Unhold", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ins == DialogResult.Yes)
            {
                int cId = Convert.ToInt32(lstAssigned.SelectedItems[0].SubItems[1].Text);
                int AsId = Convert.ToInt32(lstAssigned.SelectedItems[0].SubItems[0].Text);

                if (delAssigned(AsId)) {
                    MessageBox.Show("The bed of " + Tname + " is successfully unhold!","Unhold",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    HeaderAssigned();
                }

                UpdContStat upd = new UpdContStat();
                if (ChkHoldStat(cId)) {
                    upd.ContStatus(cId, "Applying");
                }

                Audit aud = new Audit();
                aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Unhold (" + Tname + ") cId: (" + cId.ToString() + ")");
            }
        }

        bool ChkHoldStat(int cId) {
            DBconn conn = new DBconn();
            Recordset rs = new Recordset();
            object ra;

            if (conn.ServerConn())
            {
                rs = conn.MySql.Execute("select ContractStatus from tbltenantcontract where Id = " + cId + " and ContractStatus = 'Hold'", out ra, (int)CommandTypeEnum.adCmdText);
                if (rs.EOF == false)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

    }
}
