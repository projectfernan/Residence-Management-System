namespace prjRMS
{
    partial class frmAddContract
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddContract));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbRemarks = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbGender = new System.Windows.Forms.Label();
            this.lbAge = new System.Windows.Forms.Label();
            this.lbTenantName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbParentSign = new System.Windows.Forms.Label();
            this.lbGuardianID = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbTenantID = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lbContPer = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbKeyCardDepo = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbWsp = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbSecDepo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbReserveFee = new System.Windows.Forms.Label();
            this.lbMonthlyFee = new System.Windows.Forms.Label();
            this.cboContract = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(3, 2);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(171, 18);
            this.lbTitle.TabIndex = 2654;
            this.lbTitle.Text = "New Contract Signing";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(684, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2655;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbRemarks);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbGender);
            this.groupBox1.Controls.Add(this.lbAge);
            this.groupBox1.Controls.Add(this.lbTenantName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 95);
            this.groupBox1.TabIndex = 2656;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tenant\'s Personal Information";
            // 
            // lbRemarks
            // 
            this.lbRemarks.AutoSize = true;
            this.lbRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbRemarks.Location = new System.Drawing.Point(389, 62);
            this.lbRemarks.Name = "lbRemarks";
            this.lbRemarks.Size = new System.Drawing.Size(70, 16);
            this.lbRemarks.TabIndex = 41;
            this.lbRemarks.Text = "Remarks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(313, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "Remarks :";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbGender.Location = new System.Drawing.Point(72, 62);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(59, 16);
            this.lbGender.TabIndex = 39;
            this.lbGender.Text = "Gender";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbAge.Location = new System.Drawing.Point(389, 33);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(36, 16);
            this.lbAge.TabIndex = 38;
            this.lbAge.Text = "Age";
            // 
            // lbTenantName
            // 
            this.lbTenantName.AutoSize = true;
            this.lbTenantName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenantName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbTenantName.Location = new System.Drawing.Point(72, 33);
            this.lbTenantName.Name = "lbTenantName";
            this.lbTenantName.Size = new System.Drawing.Size(56, 16);
            this.lbTenantName.TabIndex = 37;
            this.lbTenantName.Text = "Tenant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Gender :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(347, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "Age :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Tenant :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(8, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 595);
            this.panel1.TabIndex = 2657;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(580, 545);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 36);
            this.btnSave.TabIndex = 2658;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbParentSign);
            this.groupBox2.Controls.Add(this.lbGuardianID);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.lbTenantID);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.dtEnd);
            this.groupBox2.Controls.Add(this.dtStart);
            this.groupBox2.Controls.Add(this.lbContPer);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lbKeyCardDepo);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lbWsp);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lbSecDepo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbReserveFee);
            this.groupBox2.Controls.Add(this.lbMonthlyFee);
            this.groupBox2.Controls.Add(this.cboContract);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(13, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 432);
            this.groupBox2.TabIndex = 2657;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contract Form";
            // 
            // lbParentSign
            // 
            this.lbParentSign.AutoSize = true;
            this.lbParentSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParentSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbParentSign.Location = new System.Drawing.Point(211, 325);
            this.lbParentSign.Name = "lbParentSign";
            this.lbParentSign.Size = new System.Drawing.Size(13, 16);
            this.lbParentSign.TabIndex = 60;
            this.lbParentSign.Text = "-";
            // 
            // lbGuardianID
            // 
            this.lbGuardianID.AutoSize = true;
            this.lbGuardianID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGuardianID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbGuardianID.Location = new System.Drawing.Point(211, 292);
            this.lbGuardianID.Name = "lbGuardianID";
            this.lbGuardianID.Size = new System.Drawing.Size(13, 16);
            this.lbGuardianID.TabIndex = 59;
            this.lbGuardianID.Text = "-";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(39, 325);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(164, 16);
            this.label26.TabIndex = 58;
            this.label26.Text = "Parent/Guardian Sign :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(56, 292);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(148, 16);
            this.label25.TabIndex = 57;
            this.label25.Text = "Parent/Guardian ID :";
            // 
            // lbTenantID
            // 
            this.lbTenantID.AutoSize = true;
            this.lbTenantID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenantID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbTenantID.Location = new System.Drawing.Point(211, 259);
            this.lbTenantID.Name = "lbTenantID";
            this.lbTenantID.Size = new System.Drawing.Size(13, 16);
            this.lbTenantID.TabIndex = 56;
            this.lbTenantID.Text = "-";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(122, 259);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 16);
            this.label23.TabIndex = 55;
            this.label23.Text = "Tenant ID :";
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyy-MM-dd";
            this.dtEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(214, 388);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(259, 24);
            this.dtEnd.TabIndex = 2;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyy-MM-dd";
            this.dtStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(214, 355);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(259, 24);
            this.dtStart.TabIndex = 1;
            // 
            // lbContPer
            // 
            this.lbContPer.AutoSize = true;
            this.lbContPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContPer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbContPer.Location = new System.Drawing.Point(211, 65);
            this.lbContPer.Name = "lbContPer";
            this.lbContPer.Size = new System.Drawing.Size(13, 16);
            this.lbContPer.TabIndex = 49;
            this.lbContPer.Text = "-";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(82, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 16);
            this.label20.TabIndex = 48;
            this.label20.Text = "Contract Period :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(121, 390);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 16);
            this.label19.TabIndex = 47;
            this.label19.Text = "End Date :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(117, 358);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 16);
            this.label18.TabIndex = 46;
            this.label18.Text = "Start Date :";
            // 
            // lbKeyCardDepo
            // 
            this.lbKeyCardDepo.AutoSize = true;
            this.lbKeyCardDepo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKeyCardDepo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbKeyCardDepo.Location = new System.Drawing.Point(211, 226);
            this.lbKeyCardDepo.Name = "lbKeyCardDepo";
            this.lbKeyCardDepo.Size = new System.Drawing.Size(36, 16);
            this.lbKeyCardDepo.TabIndex = 45;
            this.lbKeyCardDepo.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(38, 226);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(167, 16);
            this.label16.TabIndex = 44;
            this.label16.Text = "Key Card Deposit Amt :";
            // 
            // lbWsp
            // 
            this.lbWsp.AutoSize = true;
            this.lbWsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWsp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbWsp.Location = new System.Drawing.Point(211, 193);
            this.lbWsp.Name = "lbWsp";
            this.lbWsp.Size = new System.Drawing.Size(36, 16);
            this.lbWsp.TabIndex = 43;
            this.lbWsp.Text = "0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(16, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 16);
            this.label14.TabIndex = 42;
            this.label14.Text = "Whole Stay Payment Amt :";
            // 
            // lbSecDepo
            // 
            this.lbSecDepo.AutoSize = true;
            this.lbSecDepo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecDepo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbSecDepo.Location = new System.Drawing.Point(211, 160);
            this.lbSecDepo.Name = "lbSecDepo";
            this.lbSecDepo.Size = new System.Drawing.Size(36, 16);
            this.lbSecDepo.TabIndex = 41;
            this.lbSecDepo.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(32, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "Sercurity Deposits Amt :";
            // 
            // lbReserveFee
            // 
            this.lbReserveFee.AutoSize = true;
            this.lbReserveFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserveFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbReserveFee.Location = new System.Drawing.Point(211, 130);
            this.lbReserveFee.Name = "lbReserveFee";
            this.lbReserveFee.Size = new System.Drawing.Size(36, 16);
            this.lbReserveFee.TabIndex = 39;
            this.lbReserveFee.Text = "0.00";
            // 
            // lbMonthlyFee
            // 
            this.lbMonthlyFee.AutoSize = true;
            this.lbMonthlyFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonthlyFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbMonthlyFee.Location = new System.Drawing.Point(211, 97);
            this.lbMonthlyFee.Name = "lbMonthlyFee";
            this.lbMonthlyFee.Size = new System.Drawing.Size(36, 16);
            this.lbMonthlyFee.TabIndex = 38;
            this.lbMonthlyFee.Text = "0.00";
            // 
            // cboContract
            // 
            this.cboContract.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboContract.FormattingEnabled = true;
            this.cboContract.Items.AddRange(new object[] {
            "New",
            "Renewal",
            "Extension"});
            this.cboContract.Location = new System.Drawing.Point(212, 29);
            this.cboContract.Name = "cboContract";
            this.cboContract.Size = new System.Drawing.Size(259, 24);
            this.cboContract.TabIndex = 0;
            this.cboContract.SelectedIndexChanged += new System.EventHandler(this.cboContract_SelectedIndexChanged);
            this.cboContract.SelectedValueChanged += new System.EventHandler(this.cboContract_SelectedValueChanged);
            this.cboContract.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboContract_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(105, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 36;
            this.label10.Text = "Monthly Fee :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(74, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "Reservation Fee :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(88, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "Contract Name :";
            // 
            // frmAddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(704, 627);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddContract_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmAddContract_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmAddContract_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmAddContract_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lbTenantName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbContPer;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbKeyCardDepo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbWsp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbSecDepo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbReserveFee;
        private System.Windows.Forms.Label lbMonthlyFee;
        private System.Windows.Forms.ComboBox cboContract;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label lbParentSign;
        private System.Windows.Forms.Label lbGuardianID;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lbTenantID;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbRemarks;
        private System.Windows.Forms.Label label5;
    }
}