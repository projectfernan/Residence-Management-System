namespace prjRMS
{
    partial class frmWsp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWsp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabFullPay = new System.Windows.Forms.TabPage();
            this.tabFp = new System.Windows.Forms.TabControl();
            this.tabFpCash = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCashTender = new System.Windows.Forms.NumericUpDown();
            this.btnFpCash = new System.Windows.Forms.Button();
            this.txtInvFpCash = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFpCashGiven = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAmtFpCash = new System.Windows.Forms.TextBox();
            this.tabFpCheck = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCheckAmt = new System.Windows.Forms.NumericUpDown();
            this.btnFpCheck = new System.Windows.Forms.Button();
            this.txtInvFpCheck = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFpCheckGiven = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFpCheck = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFpChekNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFpChkBank = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmtFpCheck = new System.Windows.Forms.TextBox();
            this.tabPdc = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.cboPtype = new System.Windows.Forms.ComboBox();
            this.dtPeriod = new System.Windows.Forms.DateTimePicker();
            this.txtAmt = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEditPdc = new System.Windows.Forms.Button();
            this.btnPrintPdc = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalPdc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddPdc = new System.Windows.Forms.Button();
            this.lstPDC = new System.Windows.Forms.ListView();
            this.btnSettlePdc = new System.Windows.Forms.Button();
            this.txtInvPdc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtPdcCheck = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPdcCheckNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPdcBank = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPdcAmt = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.tabOnline = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.txtOnlineTender = new System.Windows.Forms.NumericUpDown();
            this.btnFpOnline = new System.Windows.Forms.Button();
            this.txtInvFpOnline = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtFpOnlineGiven = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtAmtFpOnline = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabFullPay.SuspendLayout();
            this.tabFp.SuspendLayout();
            this.tabFpCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashTender)).BeginInit();
            this.tabFpCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckAmt)).BeginInit();
            this.tabPdc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmt)).BeginInit();
            this.tabOnline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnlineTender)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.tabControlMain);
            this.panel1.Location = new System.Drawing.Point(7, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 599);
            this.panel1.TabIndex = 2663;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabFullPay);
            this.tabControlMain.Controls.Add(this.tabPdc);
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(7, 7);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(397, 584);
            this.tabControlMain.TabIndex = 4555;
            this.tabControlMain.TabStop = false;
            // 
            // tabFullPay
            // 
            this.tabFullPay.BackColor = System.Drawing.Color.Gray;
            this.tabFullPay.Controls.Add(this.tabFp);
            this.tabFullPay.Location = new System.Drawing.Point(4, 25);
            this.tabFullPay.Name = "tabFullPay";
            this.tabFullPay.Padding = new System.Windows.Forms.Padding(3);
            this.tabFullPay.Size = new System.Drawing.Size(389, 555);
            this.tabFullPay.TabIndex = 0;
            this.tabFullPay.Text = "Full Payment";
            // 
            // tabFp
            // 
            this.tabFp.Controls.Add(this.tabFpCash);
            this.tabFp.Controls.Add(this.tabOnline);
            this.tabFp.Controls.Add(this.tabFpCheck);
            this.tabFp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFp.Location = new System.Drawing.Point(-4, 1);
            this.tabFp.Name = "tabFp";
            this.tabFp.SelectedIndex = 0;
            this.tabFp.Size = new System.Drawing.Size(397, 558);
            this.tabFp.TabIndex = 4554;
            this.tabFp.TabStop = false;
            // 
            // tabFpCash
            // 
            this.tabFpCash.BackColor = System.Drawing.Color.Gray;
            this.tabFpCash.Controls.Add(this.label20);
            this.tabFpCash.Controls.Add(this.txtCashTender);
            this.tabFpCash.Controls.Add(this.btnFpCash);
            this.tabFpCash.Controls.Add(this.txtInvFpCash);
            this.tabFpCash.Controls.Add(this.label9);
            this.tabFpCash.Controls.Add(this.dtFpCashGiven);
            this.tabFpCash.Controls.Add(this.label10);
            this.tabFpCash.Controls.Add(this.label11);
            this.tabFpCash.Controls.Add(this.txtAmtFpCash);
            this.tabFpCash.Location = new System.Drawing.Point(4, 25);
            this.tabFpCash.Name = "tabFpCash";
            this.tabFpCash.Padding = new System.Windows.Forms.Padding(3);
            this.tabFpCash.Size = new System.Drawing.Size(389, 529);
            this.tabFpCash.TabIndex = 0;
            this.tabFpCash.Text = "Cash";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 69);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 16);
            this.label20.TabIndex = 5489;
            this.label20.Text = "Amount Tendered :";
            // 
            // txtCashTender
            // 
            this.txtCashTender.DecimalPlaces = 2;
            this.txtCashTender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashTender.Location = new System.Drawing.Point(11, 86);
            this.txtCashTender.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtCashTender.Name = "txtCashTender";
            this.txtCashTender.Size = new System.Drawing.Size(367, 24);
            this.txtCashTender.TabIndex = 5488;
            // 
            // btnFpCash
            // 
            this.btnFpCash.BackColor = System.Drawing.Color.Silver;
            this.btnFpCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFpCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFpCash.ForeColor = System.Drawing.Color.Black;
            this.btnFpCash.Image = ((System.Drawing.Image)(resources.GetObject("btnFpCash.Image")));
            this.btnFpCash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFpCash.Location = new System.Drawing.Point(288, 180);
            this.btnFpCash.Name = "btnFpCash";
            this.btnFpCash.Size = new System.Drawing.Size(90, 36);
            this.btnFpCash.TabIndex = 1;
            this.btnFpCash.Text = "Settle";
            this.btnFpCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFpCash.UseVisualStyleBackColor = false;
            this.btnFpCash.Click += new System.EventHandler(this.btnFpCash_Click);
            // 
            // txtInvFpCash
            // 
            this.txtInvFpCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvFpCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvFpCash.Location = new System.Drawing.Point(128, 149);
            this.txtInvFpCash.MaxLength = 40;
            this.txtInvFpCash.Name = "txtInvFpCash";
            this.txtInvFpCash.Size = new System.Drawing.Size(250, 24);
            this.txtInvFpCash.TabIndex = 0;
            this.txtInvFpCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvFpCash_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 5485;
            this.label9.Text = "Invoice # :";
            // 
            // dtFpCashGiven
            // 
            this.dtFpCashGiven.CustomFormat = "yyy-MM-dd";
            this.dtFpCashGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFpCashGiven.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFpCashGiven.Location = new System.Drawing.Point(128, 118);
            this.dtFpCashGiven.Name = "dtFpCashGiven";
            this.dtFpCashGiven.Size = new System.Drawing.Size(250, 24);
            this.dtFpCashGiven.TabIndex = 5484;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 16);
            this.label10.TabIndex = 5483;
            this.label10.Text = "Date Given :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 5482;
            this.label11.Text = "Amount :";
            // 
            // txtAmtFpCash
            // 
            this.txtAmtFpCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAmtFpCash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmtFpCash.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtFpCash.Location = new System.Drawing.Point(11, 26);
            this.txtAmtFpCash.Name = "txtAmtFpCash";
            this.txtAmtFpCash.ReadOnly = true;
            this.txtAmtFpCash.Size = new System.Drawing.Size(367, 37);
            this.txtAmtFpCash.TabIndex = 5481;
            this.txtAmtFpCash.TabStop = false;
            this.txtAmtFpCash.Text = "0.00";
            // 
            // tabFpCheck
            // 
            this.tabFpCheck.BackColor = System.Drawing.Color.Gray;
            this.tabFpCheck.Controls.Add(this.label14);
            this.tabFpCheck.Controls.Add(this.txtCheckAmt);
            this.tabFpCheck.Controls.Add(this.btnFpCheck);
            this.tabFpCheck.Controls.Add(this.txtInvFpCheck);
            this.tabFpCheck.Controls.Add(this.label6);
            this.tabFpCheck.Controls.Add(this.dtFpCheckGiven);
            this.tabFpCheck.Controls.Add(this.label5);
            this.tabFpCheck.Controls.Add(this.dtFpCheck);
            this.tabFpCheck.Controls.Add(this.label4);
            this.tabFpCheck.Controls.Add(this.txtFpChekNo);
            this.tabFpCheck.Controls.Add(this.label3);
            this.tabFpCheck.Controls.Add(this.txtFpChkBank);
            this.tabFpCheck.Controls.Add(this.label2);
            this.tabFpCheck.Controls.Add(this.label1);
            this.tabFpCheck.Controls.Add(this.txtAmtFpCheck);
            this.tabFpCheck.Location = new System.Drawing.Point(4, 25);
            this.tabFpCheck.Name = "tabFpCheck";
            this.tabFpCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabFpCheck.Size = new System.Drawing.Size(389, 529);
            this.tabFpCheck.TabIndex = 2;
            this.tabFpCheck.Text = "Check";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 16);
            this.label14.TabIndex = 63;
            this.label14.Text = "Check Amount :";
            // 
            // txtCheckAmt
            // 
            this.txtCheckAmt.DecimalPlaces = 2;
            this.txtCheckAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckAmt.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtCheckAmt.Location = new System.Drawing.Point(128, 204);
            this.txtCheckAmt.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtCheckAmt.Name = "txtCheckAmt";
            this.txtCheckAmt.Size = new System.Drawing.Size(250, 24);
            this.txtCheckAmt.TabIndex = 4;
            // 
            // btnFpCheck
            // 
            this.btnFpCheck.BackColor = System.Drawing.Color.Silver;
            this.btnFpCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFpCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFpCheck.ForeColor = System.Drawing.Color.Black;
            this.btnFpCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnFpCheck.Image")));
            this.btnFpCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFpCheck.Location = new System.Drawing.Point(288, 266);
            this.btnFpCheck.Name = "btnFpCheck";
            this.btnFpCheck.Size = new System.Drawing.Size(90, 36);
            this.btnFpCheck.TabIndex = 6;
            this.btnFpCheck.Text = "Settle";
            this.btnFpCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFpCheck.UseVisualStyleBackColor = false;
            this.btnFpCheck.Click += new System.EventHandler(this.btnFpCheck_Click);
            // 
            // txtInvFpCheck
            // 
            this.txtInvFpCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvFpCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvFpCheck.Location = new System.Drawing.Point(128, 236);
            this.txtInvFpCheck.MaxLength = 40;
            this.txtInvFpCheck.Name = "txtInvFpCheck";
            this.txtInvFpCheck.Size = new System.Drawing.Size(250, 24);
            this.txtInvFpCheck.TabIndex = 5;
            this.txtInvFpCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvFpCheck_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 59;
            this.label6.Text = "Invoice # :";
            // 
            // dtFpCheckGiven
            // 
            this.dtFpCheckGiven.CustomFormat = "yyy-MM-dd";
            this.dtFpCheckGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFpCheckGiven.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFpCheckGiven.Location = new System.Drawing.Point(128, 172);
            this.dtFpCheckGiven.Name = "dtFpCheckGiven";
            this.dtFpCheckGiven.Size = new System.Drawing.Size(250, 24);
            this.dtFpCheckGiven.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Date Given :";
            // 
            // dtFpCheck
            // 
            this.dtFpCheck.CustomFormat = "yyy-MM-dd";
            this.dtFpCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFpCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFpCheck.Location = new System.Drawing.Point(128, 140);
            this.dtFpCheck.Name = "dtFpCheck";
            this.dtFpCheck.Size = new System.Drawing.Size(250, 24);
            this.dtFpCheck.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 55;
            this.label4.Text = "Check Date :";
            // 
            // txtFpChekNo
            // 
            this.txtFpChekNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFpChekNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFpChekNo.Location = new System.Drawing.Point(128, 109);
            this.txtFpChekNo.MaxLength = 40;
            this.txtFpChekNo.Name = "txtFpChekNo";
            this.txtFpChekNo.Size = new System.Drawing.Size(250, 24);
            this.txtFpChekNo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 53;
            this.label3.Text = "Check # :";
            // 
            // txtFpChkBank
            // 
            this.txtFpChkBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFpChkBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFpChkBank.Location = new System.Drawing.Point(128, 78);
            this.txtFpChkBank.MaxLength = 40;
            this.txtFpChkBank.Name = "txtFpChkBank";
            this.txtFpChkBank.Size = new System.Drawing.Size(250, 24);
            this.txtFpChkBank.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bank / Branch :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount :";
            // 
            // txtAmtFpCheck
            // 
            this.txtAmtFpCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAmtFpCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmtFpCheck.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtFpCheck.Location = new System.Drawing.Point(11, 26);
            this.txtAmtFpCheck.Name = "txtAmtFpCheck";
            this.txtAmtFpCheck.ReadOnly = true;
            this.txtAmtFpCheck.Size = new System.Drawing.Size(367, 37);
            this.txtAmtFpCheck.TabIndex = 0;
            this.txtAmtFpCheck.TabStop = false;
            this.txtAmtFpCheck.Text = "0.00";
            // 
            // tabPdc
            // 
            this.tabPdc.BackColor = System.Drawing.Color.Gray;
            this.tabPdc.Controls.Add(this.label19);
            this.tabPdc.Controls.Add(this.cboPtype);
            this.tabPdc.Controls.Add(this.dtPeriod);
            this.tabPdc.Controls.Add(this.txtAmt);
            this.tabPdc.Controls.Add(this.label12);
            this.tabPdc.Controls.Add(this.btnEditPdc);
            this.tabPdc.Controls.Add(this.btnPrintPdc);
            this.tabPdc.Controls.Add(this.label8);
            this.tabPdc.Controls.Add(this.txtTotalPdc);
            this.tabPdc.Controls.Add(this.label7);
            this.tabPdc.Controls.Add(this.btnAddPdc);
            this.tabPdc.Controls.Add(this.lstPDC);
            this.tabPdc.Controls.Add(this.btnSettlePdc);
            this.tabPdc.Controls.Add(this.txtInvPdc);
            this.tabPdc.Controls.Add(this.label13);
            this.tabPdc.Controls.Add(this.dtPdcCheck);
            this.tabPdc.Controls.Add(this.label15);
            this.tabPdc.Controls.Add(this.txtPdcCheckNo);
            this.tabPdc.Controls.Add(this.label16);
            this.tabPdc.Controls.Add(this.txtPdcBank);
            this.tabPdc.Controls.Add(this.label17);
            this.tabPdc.Controls.Add(this.label18);
            this.tabPdc.Controls.Add(this.txtPdcAmt);
            this.tabPdc.Location = new System.Drawing.Point(4, 25);
            this.tabPdc.Name = "tabPdc";
            this.tabPdc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPdc.Size = new System.Drawing.Size(389, 555);
            this.tabPdc.TabIndex = 2;
            this.tabPdc.Text = "Post Dated Check";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(6, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 16);
            this.label19.TabIndex = 5478;
            this.label19.Text = "Payment Type :";
            // 
            // cboPtype
            // 
            this.cboPtype.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboPtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPtype.FormattingEnabled = true;
            this.cboPtype.Items.AddRange(new object[] {
            "Check",
            "Cash"});
            this.cboPtype.Location = new System.Drawing.Point(128, 73);
            this.cboPtype.MaxLength = 6;
            this.cboPtype.Name = "cboPtype";
            this.cboPtype.Size = new System.Drawing.Size(249, 24);
            this.cboPtype.TabIndex = 0;
            this.cboPtype.Text = "Check";
            this.cboPtype.SelectedValueChanged += new System.EventHandler(this.cboPtype_SelectedValueChanged);
            // 
            // dtPeriod
            // 
            this.dtPeriod.CustomFormat = "MMMM yyyy";
            this.dtPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPeriod.Location = new System.Drawing.Point(128, 105);
            this.dtPeriod.Name = "dtPeriod";
            this.dtPeriod.Size = new System.Drawing.Size(250, 24);
            this.dtPeriod.TabIndex = 1;
            // 
            // txtAmt
            // 
            this.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmt.Location = new System.Drawing.Point(129, 232);
            this.txtAmt.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(248, 24);
            this.txtAmt.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(55, 235);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 16);
            this.label12.TabIndex = 5475;
            this.label12.Text = "Amount :";
            // 
            // btnEditPdc
            // 
            this.btnEditPdc.BackColor = System.Drawing.Color.Silver;
            this.btnEditPdc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPdc.ForeColor = System.Drawing.Color.Black;
            this.btnEditPdc.Image = ((System.Drawing.Image)(resources.GetObject("btnEditPdc.Image")));
            this.btnEditPdc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditPdc.Location = new System.Drawing.Point(101, 296);
            this.btnEditPdc.Name = "btnEditPdc";
            this.btnEditPdc.Size = new System.Drawing.Size(90, 36);
            this.btnEditPdc.TabIndex = 8;
            this.btnEditPdc.Text = "Edit";
            this.btnEditPdc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditPdc.UseVisualStyleBackColor = false;
            this.btnEditPdc.Click += new System.EventHandler(this.btnEditPdc_Click);
            // 
            // btnPrintPdc
            // 
            this.btnPrintPdc.BackColor = System.Drawing.Color.Silver;
            this.btnPrintPdc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPdc.ForeColor = System.Drawing.Color.Black;
            this.btnPrintPdc.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPdc.Image")));
            this.btnPrintPdc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintPdc.Location = new System.Drawing.Point(197, 296);
            this.btnPrintPdc.Name = "btnPrintPdc";
            this.btnPrintPdc.Size = new System.Drawing.Size(90, 36);
            this.btnPrintPdc.TabIndex = 9;
            this.btnPrintPdc.Text = "Print";
            this.btnPrintPdc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintPdc.UseVisualStyleBackColor = false;
            this.btnPrintPdc.Click += new System.EventHandler(this.btnPrintPdc_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 521);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 16);
            this.label8.TabIndex = 5471;
            this.label8.Text = "PDC Total Amout :";
            // 
            // txtTotalPdc
            // 
            this.txtTotalPdc.BackColor = System.Drawing.Color.White;
            this.txtTotalPdc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPdc.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPdc.ForeColor = System.Drawing.Color.Red;
            this.txtTotalPdc.Location = new System.Drawing.Point(149, 510);
            this.txtTotalPdc.Name = "txtTotalPdc";
            this.txtTotalPdc.ReadOnly = true;
            this.txtTotalPdc.Size = new System.Drawing.Size(233, 37);
            this.txtTotalPdc.TabIndex = 5470;
            this.txtTotalPdc.TabStop = false;
            this.txtTotalPdc.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(60, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 5469;
            this.label7.Text = "Period :";
            // 
            // btnAddPdc
            // 
            this.btnAddPdc.BackColor = System.Drawing.Color.Silver;
            this.btnAddPdc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPdc.ForeColor = System.Drawing.Color.Black;
            this.btnAddPdc.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPdc.Image")));
            this.btnAddPdc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPdc.Location = new System.Drawing.Point(6, 296);
            this.btnAddPdc.Name = "btnAddPdc";
            this.btnAddPdc.Size = new System.Drawing.Size(90, 36);
            this.btnAddPdc.TabIndex = 7;
            this.btnAddPdc.Text = "Add";
            this.btnAddPdc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPdc.UseVisualStyleBackColor = false;
            this.btnAddPdc.Click += new System.EventHandler(this.btnAddPdc_Click);
            // 
            // lstPDC
            // 
            this.lstPDC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPDC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstPDC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPDC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPDC.FullRowSelect = true;
            this.lstPDC.GridLines = true;
            this.lstPDC.Location = new System.Drawing.Point(6, 337);
            this.lstPDC.MultiSelect = false;
            this.lstPDC.Name = "lstPDC";
            this.lstPDC.Size = new System.Drawing.Size(377, 167);
            this.lstPDC.TabIndex = 5466;
            this.lstPDC.UseCompatibleStateImageBehavior = false;
            this.lstPDC.View = System.Windows.Forms.View.Details;
            // 
            // btnSettlePdc
            // 
            this.btnSettlePdc.BackColor = System.Drawing.Color.Silver;
            this.btnSettlePdc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettlePdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettlePdc.ForeColor = System.Drawing.Color.Black;
            this.btnSettlePdc.Image = ((System.Drawing.Image)(resources.GetObject("btnSettlePdc.Image")));
            this.btnSettlePdc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettlePdc.Location = new System.Drawing.Point(293, 296);
            this.btnSettlePdc.Name = "btnSettlePdc";
            this.btnSettlePdc.Size = new System.Drawing.Size(90, 36);
            this.btnSettlePdc.TabIndex = 10;
            this.btnSettlePdc.Text = "Settle";
            this.btnSettlePdc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettlePdc.UseVisualStyleBackColor = false;
            this.btnSettlePdc.Click += new System.EventHandler(this.btnSettlePdc_Click);
            // 
            // txtInvPdc
            // 
            this.txtInvPdc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvPdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvPdc.Location = new System.Drawing.Point(128, 265);
            this.txtInvPdc.MaxLength = 40;
            this.txtInvPdc.Name = "txtInvPdc";
            this.txtInvPdc.Size = new System.Drawing.Size(250, 24);
            this.txtInvPdc.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 268);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 16);
            this.label13.TabIndex = 59;
            this.label13.Text = "Invoice # :";
            // 
            // dtPdcCheck
            // 
            this.dtPdcCheck.CustomFormat = "yyy-MM-dd";
            this.dtPdcCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPdcCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPdcCheck.Location = new System.Drawing.Point(128, 199);
            this.dtPdcCheck.Name = "dtPdcCheck";
            this.dtPdcCheck.Size = new System.Drawing.Size(250, 24);
            this.dtPdcCheck.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(73, 202);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 16);
            this.label15.TabIndex = 55;
            this.label15.Text = "Date :";
            // 
            // txtPdcCheckNo
            // 
            this.txtPdcCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPdcCheckNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPdcCheckNo.Location = new System.Drawing.Point(128, 168);
            this.txtPdcCheckNo.MaxLength = 40;
            this.txtPdcCheckNo.Name = "txtPdcCheckNo";
            this.txtPdcCheckNo.Size = new System.Drawing.Size(250, 24);
            this.txtPdcCheckNo.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(51, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 16);
            this.label16.TabIndex = 53;
            this.label16.Text = "Check # :";
            // 
            // txtPdcBank
            // 
            this.txtPdcBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPdcBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPdcBank.Location = new System.Drawing.Point(128, 137);
            this.txtPdcBank.MaxLength = 40;
            this.txtPdcBank.Name = "txtPdcBank";
            this.txtPdcBank.Size = new System.Drawing.Size(250, 24);
            this.txtPdcBank.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 16);
            this.label17.TabIndex = 2;
            this.label17.Text = "Bank / Branch :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 16);
            this.label18.TabIndex = 1;
            this.label18.Text = "Amount :";
            // 
            // txtPdcAmt
            // 
            this.txtPdcAmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPdcAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPdcAmt.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPdcAmt.Location = new System.Drawing.Point(11, 24);
            this.txtPdcAmt.Name = "txtPdcAmt";
            this.txtPdcAmt.ReadOnly = true;
            this.txtPdcAmt.Size = new System.Drawing.Size(367, 37);
            this.txtPdcAmt.TabIndex = 0;
            this.txtPdcAmt.TabStop = false;
            this.txtPdcAmt.Text = "0.00";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(4, 4);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(88, 18);
            this.lbTitle.TabIndex = 2661;
            this.lbTitle.Text = "Settlement";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(405, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2662;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click_1);
            // 
            // tabOnline
            // 
            this.tabOnline.BackColor = System.Drawing.Color.Gray;
            this.tabOnline.Controls.Add(this.label21);
            this.tabOnline.Controls.Add(this.txtOnlineTender);
            this.tabOnline.Controls.Add(this.btnFpOnline);
            this.tabOnline.Controls.Add(this.txtInvFpOnline);
            this.tabOnline.Controls.Add(this.label22);
            this.tabOnline.Controls.Add(this.dtFpOnlineGiven);
            this.tabOnline.Controls.Add(this.label23);
            this.tabOnline.Controls.Add(this.label24);
            this.tabOnline.Controls.Add(this.txtAmtFpOnline);
            this.tabOnline.Location = new System.Drawing.Point(4, 25);
            this.tabOnline.Name = "tabOnline";
            this.tabOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tabOnline.Size = new System.Drawing.Size(389, 529);
            this.tabOnline.TabIndex = 3;
            this.tabOnline.Text = "Online";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(139, 16);
            this.label21.TabIndex = 5498;
            this.label21.Text = "Amount Tendered :";
            // 
            // txtOnlineTender
            // 
            this.txtOnlineTender.DecimalPlaces = 2;
            this.txtOnlineTender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnlineTender.Location = new System.Drawing.Point(11, 86);
            this.txtOnlineTender.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtOnlineTender.Name = "txtOnlineTender";
            this.txtOnlineTender.Size = new System.Drawing.Size(367, 24);
            this.txtOnlineTender.TabIndex = 5497;
            // 
            // btnFpOnline
            // 
            this.btnFpOnline.BackColor = System.Drawing.Color.Silver;
            this.btnFpOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFpOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFpOnline.ForeColor = System.Drawing.Color.Black;
            this.btnFpOnline.Image = ((System.Drawing.Image)(resources.GetObject("btnFpOnline.Image")));
            this.btnFpOnline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFpOnline.Location = new System.Drawing.Point(288, 180);
            this.btnFpOnline.Name = "btnFpOnline";
            this.btnFpOnline.Size = new System.Drawing.Size(90, 36);
            this.btnFpOnline.TabIndex = 5491;
            this.btnFpOnline.Text = "Settle";
            this.btnFpOnline.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFpOnline.UseVisualStyleBackColor = false;
            this.btnFpOnline.Click += new System.EventHandler(this.btnFpOnline_Click);
            // 
            // txtInvFpOnline
            // 
            this.txtInvFpOnline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvFpOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvFpOnline.Location = new System.Drawing.Point(128, 149);
            this.txtInvFpOnline.MaxLength = 40;
            this.txtInvFpOnline.Name = "txtInvFpOnline";
            this.txtInvFpOnline.Size = new System.Drawing.Size(250, 24);
            this.txtInvFpOnline.TabIndex = 5490;
            this.txtInvFpOnline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvFpOnline_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(44, 152);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 16);
            this.label22.TabIndex = 5496;
            this.label22.Text = "Invoice # :";
            // 
            // dtFpOnlineGiven
            // 
            this.dtFpOnlineGiven.CustomFormat = "yyy-MM-dd";
            this.dtFpOnlineGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFpOnlineGiven.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFpOnlineGiven.Location = new System.Drawing.Point(128, 118);
            this.dtFpOnlineGiven.Name = "dtFpOnlineGiven";
            this.dtFpOnlineGiven.Size = new System.Drawing.Size(250, 24);
            this.dtFpOnlineGiven.TabIndex = 5495;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(29, 121);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 16);
            this.label23.TabIndex = 5494;
            this.label23.Text = "Date Given :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 16);
            this.label24.TabIndex = 5493;
            this.label24.Text = "Amount :";
            // 
            // txtAmtFpOnline
            // 
            this.txtAmtFpOnline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAmtFpOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmtFpOnline.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtFpOnline.Location = new System.Drawing.Point(11, 26);
            this.txtAmtFpOnline.Name = "txtAmtFpOnline";
            this.txtAmtFpOnline.ReadOnly = true;
            this.txtAmtFpOnline.Size = new System.Drawing.Size(367, 37);
            this.txtAmtFpOnline.TabIndex = 5492;
            this.txtAmtFpOnline.TabStop = false;
            this.txtAmtFpOnline.Text = "0.00";
            // 
            // frmWsp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(426, 632);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWsp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmWsp_Load);
            this.Shown += new System.EventHandler(this.frmWsp_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmWsp_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmWsp_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmWsp_MouseUp);
            this.panel1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabFullPay.ResumeLayout(false);
            this.tabFp.ResumeLayout(false);
            this.tabFpCash.ResumeLayout(false);
            this.tabFpCash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashTender)).EndInit();
            this.tabFpCheck.ResumeLayout(false);
            this.tabFpCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckAmt)).EndInit();
            this.tabPdc.ResumeLayout(false);
            this.tabPdc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmt)).EndInit();
            this.tabOnline.ResumeLayout(false);
            this.tabOnline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnlineTender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabFp;
        private System.Windows.Forms.TabPage tabFpCash;
        private System.Windows.Forms.Button btnFpCash;
        private System.Windows.Forms.TextBox txtInvFpCash;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFpCashGiven;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAmtFpCash;
        private System.Windows.Forms.TabPage tabFpCheck;
        private System.Windows.Forms.Button btnFpCheck;
        private System.Windows.Forms.TextBox txtInvFpCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtFpCheckGiven;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtFpCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFpChekNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFpChkBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmtFpCheck;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabFullPay;
        private System.Windows.Forms.TabPage tabPdc;
        private System.Windows.Forms.Button btnSettlePdc;
        private System.Windows.Forms.TextBox txtInvPdc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtPdcCheck;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPdcCheckNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPdcBank;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPdcAmt;
        private System.Windows.Forms.Button btnAddPdc;
        private System.Windows.Forms.ListView lstPDC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalPdc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditPdc;
        private System.Windows.Forms.Button btnPrintPdc;
        private System.Windows.Forms.NumericUpDown txtAmt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtPeriod;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown txtCashTender;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown txtCheckAmt;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboPtype;
        private System.Windows.Forms.TabPage tabOnline;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown txtOnlineTender;
        private System.Windows.Forms.Button btnFpOnline;
        private System.Windows.Forms.TextBox txtInvFpOnline;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtFpOnlineGiven;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtAmtFpOnline;
    }
}