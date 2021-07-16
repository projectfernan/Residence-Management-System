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
    public partial class frmRoomSettings : Form
    {
        Boolean drag = new Boolean();
        int mouseX = new int();
        int mouseY = new int();

        public int RmNum;

        public frmRoomSettings()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRoomSettings_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void frmRoomSettings_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void frmRoomSettings_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void cboFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmRoomSettings_Load(object sender, EventArgs e)
        {
            HeaderRoom();
            Thread th = new Thread(() =>
            {
                Action act = new Action(fillRoom);
                this.BeginInvoke(act);
            });
            th.Start();

            HeaderBed();
        }

        void HeaderRoom() {
            lstRoom.Clear();
            int w = lstRoom.Width / 2;

            lstRoom.Columns.Add("", 0, HorizontalAlignment.Left);
            lstRoom.Columns.Add("RoomNo", w, HorizontalAlignment.Left);
            lstRoom.Columns.Add("Floor", w, HorizontalAlignment.Left);
        }

        void HeaderBed()
        {
            lstBed.Clear();
            int w = lstBed.Width;

            lstBed.Columns.Add("", 0, HorizontalAlignment.Left);
            lstBed.Columns.Add("", 0, HorizontalAlignment.Left);
            lstBed.Columns.Add("Bed", w, HorizontalAlignment.Left);
        }

        public void fillRoom()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    rs = conn.MySql.Execute("select * from tblrooms order by RoomNo desc", out rc, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstRoom.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstRoom.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Floor"].Value.ToString());
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

        public void findRoom()
        {
            try
            {

                DBconn conn = new DBconn();
                if (conn.ServerConn())
                {

                    Recordset rs = new Recordset();
                    object rc;

                    switch (cboCateg.Text) { 
                        case "RoomNo":
                            rs = conn.MySql.Execute("select * from tblrooms where CAST(" + cboCateg.Text + " as CHAR) like '%" + txtKeycode.Text + "%' order by RoomNo desc", out rc, (int)CommandTypeEnum.adCmdText);
                            break;
                        case "Floor":
                            rs = conn.MySql.Execute("select * from tblrooms where " + cboCateg.Text + " like '%" + txtKeycode.Text + "%' order by RoomNo desc", out rc, (int)CommandTypeEnum.adCmdText);
                            break;
                    }
                    if (rs.EOF == false)
                    {
                        int lup = 1;
                        for (lup = 1; lup <= rs.RecordCount; lup++)
                        {

                            lstRoom.Refresh();
                            ListViewItem viewlst = new ListViewItem();
                            viewlst = lstRoom.Items.Add(rs.Fields["Id"].Value.ToString(), lup);
                            viewlst.SubItems.Add(rs.Fields["RoomNo"].Value.ToString());
                            viewlst.SubItems.Add(rs.Fields["Floor"].Value.ToString());
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

        private void lstRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HeaderBed();
                GetFillBed(Convert.ToInt32(lstRoom.SelectedItems[0].SubItems[1].Text));
                RmNum = Convert.ToInt32(lstRoom.SelectedItems[0].SubItems[1].Text);
            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Value == 0 || cboFloor.Text == "") {
                MessageBox.Show("Please fill up the blanks!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ExistRm(Convert.ToInt32(txtRoomNo.Value))) {
                MessageBox.Show("Room number " + txtRoomNo.Value.ToString() + " is already exist!", "Add",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            insRoom();

            Audit aud = new Audit();
            aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Room No: (" + txtRoomNo.Value.ToString() + ") created.");

            HeaderRoom();
            fillRoom();
        }

        bool ExistRm(int RmNo)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select RoomNo from tblrooms where RoomNo = " +
                                            RmNo, out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        void insRoom() {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("insert into tblrooms(RoomNo,Floor)VALUES(" + 
                                            txtRoomNo.Value + ",'" +
                                            cboFloor.Text + "')",out ra,(int)CommandTypeEnum.adCmdText);

                    MessageBox.Show("New room successfully added!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddBed_Click(object sender, EventArgs e)
        {
            if (lstRoom.SelectedItems.Count > 0) 
            { 
                AddBed(Convert.ToInt32(lstRoom.SelectedItems[0].SubItems[1].Text));

               }
        }

        bool DelRm(int RmNo)
        {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("delete from tblrooms where RoomNo = " +
                                            RmNo, out ra, (int)CommandTypeEnum.adCmdText);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void AddBed(int RmNo) { 
            try{
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn()) {
                    if (GetBed(RmNo) == "Exceed") {
                        MessageBox.Show("Room bed capacity is reach the limit!","Add",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }

                    string bed = GetBed(RmNo);

                    rs = conn.MySql.Execute("insert into tblbeds(RoomNo,Bed)VALUES(" + 
                                            RmNo + ",'" +
                                            bed + "')", out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Bed: (" + bed + ") created for Room No: (" + RmNo.ToString() + ")");

                    HeaderBed();
                    GetFillBed(RmNo);
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string GetBed(int RmNo) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select Bed from tblbeds where RoomNo = " +
                                            RmNo + " order by Bed desc limit 1", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                        switch (rs.Fields["Bed"].Value.ToString())
                        {
                            case "A":
                                return "B";
                                break;
                            case "B":
                                return "C";
                                break;
                            case "C":
                                return "D";
                                break;
                            default:
                                return "Exceed";
                                break;
                        }
                    }
                    else {
                        return "A";
                    }
                }
                else {
                    return "A";
                }
            }
            catch (Exception ex)
            {
                return "A";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                HeaderRoom();
                Thread th = new Thread(() =>
                {
                    Action act = new Action(findRoom);
                    this.BeginInvoke(act);
                });
                th.Start();
            } 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            HeaderRoom();
            Thread th = new Thread(() =>
            {
                Action act = new Action(fillRoom);
                this.BeginInvoke(act);
            });
            th.Start();

            HeaderBed();
        }

        private void btnRemoveBed_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure do you want to remove this bed?", "Remove Bed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (del == DialogResult.Yes)
            {
                RemoveBed(Convert.ToInt32(lstBed.SelectedItems[0].SubItems[0].Text), RmNum);
            }
        }

        void RemoveBed(int bId,int RmNo) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("delete from tblbeds where Id = " + bId, out ra, (int)CommandTypeEnum.adCmdText);

                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Bed: (" + lstBed.SelectedItems[0].SubItems[2].Text + ") removed from Room No: (" + RmNo.ToString() + ")");

                    HeaderBed();
                    GetFillBed(RmNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelRoom_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure do you want to delete this room?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (del == DialogResult.Yes) {
                if (DelRm(Convert.ToInt32(lstRoom.SelectedItems[0].SubItems[1].Text))) 
                {
                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "Room No: (" + lstRoom.SelectedItems[0].SubItems[1].Text + ") deleted.");

                    MessageBox.Show("Room number " + lstRoom.SelectedItems[0].SubItems[1].Text + " is successfully deleted!","Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    HeaderRoom();
                    fillRoom();
                }
            }
        }

    }
}
