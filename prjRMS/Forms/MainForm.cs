using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjRMS
{
    public partial class MainForm : Form
    {
        public System.Threading.Timer tmerReq;
        public System.Threading.TimerCallback tmerReqDele; 

        public string LoginAcc;
        public string contStat;
        public bool termi;
        public bool termiFlag = false;
        bool ContExist;
        int RmNo;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LockMain();

            int ReqInt = Convert.ToInt32(Properties.Settings.Default.bReqDelay);
            long ReqPer = Convert.ToInt64(ReqInt);

            tmerReqDele = ReqCount;

            tmerReq = new System.Threading.Timer(tmerReqDele, 1, 0, ReqInt);
            tmerReq.Change(0, ReqPer);

            DashBoardRem rem = new DashBoardRem();
            txtResReminder.Text = rem.ReservedRem();
            txtContReminder.Text = rem.ContractRem();

            DBconn conn = new DBconn();
            conn.RetStat += new DBconn.MainDbStat(DbStat);
            if (conn.ServerConn() == false)
            {
                frmServerConn db = new frmServerConn();
                db.RetStat += new frmServerConn.MainDbStat(DbStat);
                db.ShowDialog();
            }


        }

        void DbStat(bool stat)
        {
            if (stat)
            {
                txtServer.Text = "Connected";
                txtServer.ForeColor = Color.Blue;
            }
            else 
            {
                txtServer.Text = "Disconnected";
                txtServer.ForeColor = Color.Red;
            }
        }

        void LockMain() 
        {
            lbDesig.Text = "System:";
            lbUser.Text = "Locked";

            PanelMain.Enabled = false;

            btnSettings.Enabled = false;
            btnNewTenant.Enabled = false;
            btnNewContract.Enabled = false;
            btnRoomBills.Enabled = false;
            btnMiscellaneous.Enabled = false;
            btnTenantBills.Enabled = false;
            btnPayments.Enabled = false;
            btnContractSigning.Enabled = false;
            btnMoveOut.Enabled = false;
            btnTerminate.Enabled = false;
        }

        void UnlockedMain(string Desig,string Uid,bool Pmain,bool Setting,bool NewTenant,bool TenantCont,bool RmBill,bool Misce,bool TeBill,
                         bool Payments,bool ContSign,bool MoveOut,bool Terminate) 
        {
            lbDesig.Text = Desig + ":";
            lbUser.Text = Uid;

            PanelMain.Enabled = Pmain;

            btnSettings.Enabled = Setting;
            btnNewTenant.Enabled = NewTenant;
            btnNewContract.Enabled = TenantCont;
            btnRoomBills.Enabled = RmBill;
            btnMiscellaneous.Enabled = Misce;
            btnTenantBills.Enabled = TeBill;
            btnPayments.Enabled = Payments;
            btnContractSigning.Enabled = ContSign;
            btnMoveOut.Enabled = MoveOut;
            btnTerminate.Enabled = Terminate;
        }

        void LoadRoooms(string Mode, string Floors,string dtFrm,string dtTo) {
            try
            {
                RoomsPanel.Controls.Clear();

                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Recordset rsB = new Recordset();
                object ra;
                object rb;

                int Arm = 0;
                txtTotalRms.Text = "0";
                txtAvailableA.Text = "0";

                if (conn.ServerConn()) {
                    rs = conn.MySql.Execute("call GetRoomList('" + Floors + "')", out ra, (int)CommandTypeEnum.adCmdText);
                    txtTotalRms.Text = rs.RecordCount.ToString();
                    ProgBar.Maximum = rs.RecordCount;
                    ProgBar.Visible = true;

                    while (rs.EOF == false){
                        uCtrlRoom uc = new uCtrlRoom();
                        int RmNo = Convert.ToInt32(rs.Fields["RoomNo"].Value.ToString());
                        
                                rsB = conn.MySql.Execute("select Bed from tblbeds where RoomNo = " + RmNo, out rb, (int)CommandTypeEnum.adCmdText);
                                    while (rsB.EOF == false) 
                                    { 
                                        string Bed = rsB.Fields["Bed"].Value.ToString();
                                        switch(Bed)
                                        {
                                            case "A":
                                                    if(existCont(RmNo,Bed,dtFrm,dtTo)){
                                                        uc.ucAstat = contStat;
                                                        uc.ucA = true;
                                                    }
                                                    else{
                                                        uc.ucAstat = "";
                                                        uc.ucA = true;
                                                    }
                                                break;
                                            case "B":
                                                    if(existCont(RmNo,Bed,dtFrm,dtTo)){
                                                        uc.ucBstat = contStat;
                                                        uc.ucB = true;
                                                    }
                                                    else{
                                                        uc.ucBstat = "";
                                                        uc.ucB = true;
                                                    }
                                                break;
                                            case "C":
                                                    if(existCont(RmNo,Bed,dtFrm,dtTo)){
                                                        uc.ucCstat = contStat;
                                                        uc.ucC = true;
                                                    }
                                                    else{
                                                        uc.ucCstat = "";
                                                        uc.ucC = true;
                                                    }
                                                break;
                                            case "D":
                                                    if(existCont(RmNo,Bed,dtFrm,dtTo)){
                                                        uc.ucDstat = contStat;
                                                        uc.ucD = true;
                                                    }
                                                    else{
                                                        uc.ucDstat = "";
                                                        uc.ucD = true;
                                                    }
                                                break;
                                        }
                                        rsB.MoveNext();
                                    }
                             
                        switch (Mode)
                        {
                            case "All":
                                if (uc.ucAstat == "" || uc.ucBstat == "" || uc.ucCstat == "" || uc.ucDstat == "")
                                {
                                    Arm = Arm + 1;
                                    ProgBar.Value = Arm;
                                    txtAvailableA.Text = Arm.ToString();
                                }

                                uc.ucRoomNo = Convert.ToInt32(rs.Fields["RoomNo"].Value.ToString());
                                uc.ucFloor = rs.Fields["Floor"].Value.ToString();
                                RoomsPanel.Controls.Add(uc);
                                break;
                            case "Available Only":
                                if (uc.ucAstat == "" || uc.ucBstat == "" || uc.ucCstat == "" || uc.ucDstat == "")
                                {
                                    Arm = Arm + 1;
                                    ProgBar.Value = Arm;
                                    txtAvailableA.Text = Arm.ToString();

                                    uc.ucRoomNo = Convert.ToInt32(rs.Fields["RoomNo"].Value.ToString());
                                    uc.ucFloor = rs.Fields["Floor"].Value.ToString();
                                    RoomsPanel.Controls.Add(uc);
                                }
                                break;
                        }

                        rs.MoveNext();
                    }
                }
                ProgBar.Visible = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }



        bool existHold(int Rm,string Bed,string dtFrm,string dtTo) {
            DBconn conn = new DBconn();
            Recordset rs = new Recordset();
            object ra;

            if (conn.ServerConn())
            {
                rs = conn.MySql.Execute("call GetHoldExp('" + dtFrm + "','" + dtTo + "'," + Rm + ",'" + Bed + "')", out ra, (int)CommandTypeEnum.adCmdText);
                if (rs.EOF == false)
                {
                    return true;
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

        bool existCont(int Rm, string Bed, string dtFrm, string dtTo)
        {
            DBconn conn = new DBconn();
            Recordset rs = new Recordset();
            object ra;

            if (conn.ServerConn())
            {
                rs = conn.MySql.Execute("call GetContPer('" + dtFrm + "','" + dtTo + "'," + Rm + ",'" + Bed + "')"
                                        ,out ra, (int)CommandTypeEnum.adCmdText);
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
                                contStat = rs.Fields["BedStatus"].Value.ToString();
                                return true;     
                            }
                            else {
                                contStat = "";
                                return false;
                            }
                            break;
                        case "Hold":
                            contStat = rs.Fields["BedStatus"].Value.ToString();
                            return true;
                            break;
                        case "Under Contract":
                            contStat = rs.Fields["BedStatus"].Value.ToString();
                            return true;
                            break;
                        default:
                            contStat = "";
                            return false;
                            break;
                    }
                }
                else
                {
                    contStat = "";
                    return false;
                }
            }
            else
            {
                contStat = "";
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconn conn = new DBconn();
            if (conn.MySqlConn("localhost", "root", "gg", "rmsomdb"))
            {
                MessageBox.Show("Connected!", "Test Connect", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Failed to connect!", "Test Connect", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void tmeDT_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            lbDate.Text = date.ToString("D") + "  " + date.ToString("HH:mm:ss tt");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings shw = new frmSettings();
            shw.ShowDialog();
        }

        private void btnNewContract_Click(object sender, EventArgs e)
        {
            frmTenantCont shw = new frmTenantCont();
            shw.ShowDialog();
        }

        private void btnExtension_Click(object sender, EventArgs e)
        {
            frmNewTenant shw = new frmNewTenant();
            shw.EventReq = "Save";
            shw.ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            frmPayments shw = new frmPayments();
            shw.ShowDialog();
        }

        private void tmeGetRooms_Tick(object sender, EventArgs e)
        {
            
        }

        void ReqCount(object args) {
            try
            {
                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                object ra;

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("select COUNT(Id) as ReqCount from tblreservation", out ra, (int)CommandTypeEnum.adCmdText);
                    if (rs.EOF == false)
                    {
                       txtReqCount.Text = rs.Fields["ReqCount"].Value.ToString();
                    }
                    else
                    {
                        txtReqCount.Text = "0";
                    }
                }
                else {
                    txtReqCount.Text = "0";
                }
            }
            catch {
                txtReqCount.Text = "0";
            }
        }

        private void btnSearchRm_Click(object sender, EventArgs e)
        {
            WaitMouse wc = new WaitMouse();
            wc.WaitCurTrue();

            DateTime frm = dtFrom.Value;
            DateTime to = dtTo.Value;

            Properties.Settings.Default.rmMode = cboMode.Text;
            Properties.Settings.Default.rmFloor = cboFloor.Text;
            Properties.Settings.Default.rmDtFrm = frm.ToString("yyyy-MM-dd");
            Properties.Settings.Default.rmDtTo = to.ToString("yyyy-MM-dd");
            Properties.Settings.Default.Save();

            Thread th = new Thread(() =>
            {
                Action act = new Action(FindRoom);
                this.BeginInvoke(act);
            });
            th.Start();
        }

        void FindRoom()
        {
            try 
            {
                DateTime frm = dtFrom.Value;
                DateTime to = dtTo.Value;

                RoomsPanel.Controls.Clear();

                DBconn conn = new DBconn();
                Recordset rs = new Recordset();
                Recordset rsB = new Recordset();
                object ra;
                object rb;

                int Arm = 0;
                txtTotalRms.Text = "0";
                txtAvailableA.Text = "0";
                

                if (conn.ServerConn())
                {
                    rs = conn.MySql.Execute("call GetRoomList('" + cboFloor.Text + "')", out ra, (int)CommandTypeEnum.adCmdText);
                    //txtTotalRms.Text = rs.RecordCount.ToString();
                    int TotalSlots = 0;
                    int SlotA = 0;
                    int SlotB = 0;
                    int SlotC = 0;
                    int SlotD = 0;

                    ProgBar.Maximum = rs.RecordCount;
                    ProgBar.Visible = true;

                    

                    while (rs.EOF == false)
                    {
                        uCtrlRoom uc = new uCtrlRoom();

                        RmNo = Convert.ToInt32(rs.Fields["RoomNo"].Value.ToString());
                        
                        rsB = conn.MySql.Execute("select Bed from tblbeds where RoomNo = " + RmNo, out rb, (int)CommandTypeEnum.adCmdText);
                        while (rsB.EOF == false)
                        {
                            string Bed = rsB.Fields["Bed"].Value.ToString();
                            switch (Bed)
                            {
                                case "A":
                                    TotalSlots = TotalSlots + 1;
                                    if (existCont(RmNo, Bed, frm.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd")))
                                    {
                                        uc.ucAstat = contStat;
                                        uc.ucA = true;
                                    }
                                    else
                                    {
                                        uc.ucAstat = "";
                                        uc.ucA = true;
                                        SlotA = SlotA + 1;
                                    }
                                    break;
                                case "B":
                                    TotalSlots = TotalSlots + 1;
                                    if (existCont(RmNo, Bed, frm.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd")))
                                    {
                                        uc.ucBstat = contStat;
                                        uc.ucB = true;
                                    }
                                    else
                                    {
                                        uc.ucBstat = "";
                                        uc.ucB = true;
                                        SlotB = SlotB + 1;
                                    }
                                    break;
                                case "C":
                                    TotalSlots = TotalSlots + 1;
                                    if (existCont(RmNo, Bed, frm.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd")))
                                    {
                                        uc.ucCstat = contStat;
                                        uc.ucC = true;
                                    }
                                    else
                                    {
                                        uc.ucCstat = "";
                                        uc.ucC = true;
                                        SlotC = SlotC + 1;
                                    }
                                    break;
                                case "D":
                                    TotalSlots = TotalSlots + 1;
                                    if (existCont(RmNo, Bed, frm.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd")))
                                    {
                                        uc.ucDstat = contStat;
                                        uc.ucD = true;
                                    }
                                    else
                                    {
                                        uc.ucDstat = "";
                                        uc.ucD = true;
                                        SlotD = SlotD + 1;
                                    }
                                    break;
                            }
                            rsB.MoveNext();
                        }

                        txtTotalRms.Text = TotalSlots.ToString();
                        txtAvailableA.Text = SlotA.ToString();
                        txtAvailableB.Text = SlotB.ToString();
                        txtAvailableC.Text = SlotC.ToString();
                        txtAvailableD.Text = SlotD.ToString();

                        switch (cboMode.Text)
                        {
                            case "All":
                                if (uc.ucAstat == "" || uc.ucBstat == "" || uc.ucCstat == "" || uc.ucDstat == "")
                                {
                                    Arm = Arm + 1;
                                    ProgBar.Value = Arm;
                                    //txtAvailableA.Text = Arm.ToString();
                                }

                                uc.ucRoomNo = Convert.ToInt32(rs.Fields["RoomNo"].Value.ToString());
                                uc.ucFloor = rs.Fields["Floor"].Value.ToString();
                                RoomsPanel.Controls.Add(uc);
                                break;
                            case "Available Only":
                                if (uc.ucAstat == "" || uc.ucBstat == "" || uc.ucCstat == "" || uc.ucDstat == "")
                                {
                                    Arm = Arm + 1;
                                    ProgBar.Value = Arm;
                                    //txtAvailableA.Text = Arm.ToString();

                                    uc.ucRoomNo = Convert.ToInt32(rs.Fields["RoomNo"].Value.ToString());
                                    uc.ucFloor = rs.Fields["Floor"].Value.ToString();
                                    RoomsPanel.Controls.Add(uc);
                                }
                                break;
                        }

                        //Thread.Sleep(300);

                        rs.MoveNext();
                    }
                }

                ProgBar.Visible = false;

                WaitMouse wc = new WaitMouse();
                wc.WaitCurFalse();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
            //catch (Exception ex) {
            //    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
        

        private void cboMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void viewRequestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReserveList shw = new frmReserveList();
            shw.ShowDialog();
        }

        private void btnContractSigning_Click(object sender, EventArgs e)
        {
            frmContractSigning shw = new frmContractSigning();
            shw.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmResRemList shw = new frmResRemList();
            shw.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmContRemList shw = new frmContRemList();
            shw.ShowDialog();
        }

        private void btnRoomBills_Click(object sender, EventArgs e)
        {
            frmRmBills shw = new frmRmBills();
            shw.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMoveInOut shw = new frmMoveInOut();
            shw.ShowDialog();
        }

        private void btnTenantBills_Click(object sender, EventArgs e)
        {
            frmTenantTrans shw = new frmTenantTrans();
            shw.ShowDialog();
        }

        private void btnMiscellaneous_Click(object sender, EventArgs e)
        {
            frmMiscelleneous shw = new frmMiscelleneous();
            shw.ShowDialog();
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            DialogResult t = MessageBox.Show("Are you sure do you want to terminate the system?","System Terminate",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (t == DialogResult.Yes) 
            {
                //Audit aud = new Audit();
                //aud.AuditLogs(Properties.Settings.Default.Username, Properties.Settings.Default.Desig, "System Terminated.");


                //termiFlag = true;
                Application.Exit();
            }
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            frmStatistics shw = new frmStatistics();
            shw.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter) 
            {
                frmLogin shw = new frmLogin();
                shw.unlocked += new frmLogin.frmMainEvnt(UnlockedMain);
                shw.ShowDialog();
            }

            if (e.KeyCode == Keys.Escape) 
            {
                if (PanelMain.Enabled == false) 
                {
                    return; 
                }

                DialogResult ys = MessageBox.Show("Are you sure do you want to logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

                if (ys == DialogResult.Yes) 
                {
                    Audit aud = new Audit();
                    aud.AuditLogs(Properties.Settings.Default.Uid, Properties.Settings.Default.Desig, "Account Logout");

                    LockMain();
                }
            }

            if (e.KeyCode == Keys.F1) 
            {
                frmHelp shw = new frmHelp();
                shw.ShowDialog();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //switch (termiFlag) 
            //{
            //    case true:
            //        e.Cancel = false;
            //        break;
            //    case false:
            //        e.Cancel = true;
            //        break;
            //}
        }
    }
}
