namespace prjRMS
{
    partial class frmSettle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettle));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPDC = new System.Windows.Forms.TabPage();
            this.txtAdjustAmt = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.txtInvPDC = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPDCamt = new System.Windows.Forms.TextBox();
            this.btnPDC = new System.Windows.Forms.Button();
            this.lstPDC = new System.Windows.Forms.ListView();
            this.tabCash = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCashTender = new System.Windows.Forms.NumericUpDown();
            this.btnCash = new System.Windows.Forms.Button();
            this.txtInvCash = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtCashGiven = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAmtCash = new System.Windows.Forms.TextBox();
            this.tabOnline = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.txtOnlineTender = new System.Windows.Forms.NumericUpDown();
            this.btnOnline = new System.Windows.Forms.Button();
            this.txtInvOnline = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtOnlineGiven = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAmtOnline = new System.Windows.Forms.TextBox();
            this.tabCheck = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCheckAmt = new System.Windows.Forms.NumericUpDown();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtInvCheck = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtCheckGiven = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtCheck = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChekNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmtCheck = new System.Windows.Forms.TextBox();
            this.tabDepo = new System.Windows.Forms.TabPage();
            this.txtBalDepo = new System.Windows.Forms.TextBox();
            this.btnDepoSettle = new System.Windows.Forms.Button();
            this.txtDepoInv = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDepoAmt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdjustAmt)).BeginInit();
            this.tabCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashTender)).BeginInit();
            this.tabOnline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnlineTender)).BeginInit();
            this.tabCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckAmt)).BeginInit();
            this.tabDepo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(3, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(88, 18);
            this.lbTitle.TabIndex = 2658;
            this.lbTitle.Text = "Settlement";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(406, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2659;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Location = new System.Drawing.Point(6, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 413);
            this.panel1.TabIndex = 2660;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPDC);
            this.tabControl.Controls.Add(this.tabCash);
            this.tabControl.Controls.Add(this.tabOnline);
            this.tabControl.Controls.Add(this.tabCheck);
            this.tabControl.Controls.Add(this.tabDepo);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(9, 9);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(397, 393);
            this.tabControl.TabIndex = 4554;
            this.tabControl.TabStop = false;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPDC
            // 
            this.tabPDC.BackColor = System.Drawing.Color.Gray;
            this.tabPDC.Controls.Add(this.txtAdjustAmt);
            this.tabPDC.Controls.Add(this.label19);
            this.tabPDC.Controls.Add(this.txtInvPDC);
            this.tabPDC.Controls.Add(this.label18);
            this.tabPDC.Controls.Add(this.label13);
            this.tabPDC.Controls.Add(this.txtPDCamt);
            this.tabPDC.Controls.Add(this.btnPDC);
            this.tabPDC.Controls.Add(this.lstPDC);
            this.tabPDC.Location = new System.Drawing.Point(4, 25);
            this.tabPDC.Name = "tabPDC";
            this.tabPDC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPDC.Size = new System.Drawing.Size(389, 364);
            this.tabPDC.TabIndex = 3;
            this.tabPDC.Text = "PDC";
            // 
            // txtAdjustAmt
            // 
            this.txtAdjustAmt.DecimalPlaces = 2;
            this.txtAdjustAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustAmt.Location = new System.Drawing.Point(85, 289);
            this.txtAdjustAmt.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.txtAdjustAmt.Name = "txtAdjustAmt";
            this.txtAdjustAmt.Size = new System.Drawing.Size(298, 24);
            this.txtAdjustAmt.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(15, 293);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 16);
            this.label19.TabIndex = 5489;
            this.label19.Text = "Amount :";
            // 
            // txtInvPDC
            // 
            this.txtInvPDC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvPDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvPDC.Location = new System.Drawing.Point(85, 327);
            this.txtInvPDC.MaxLength = 40;
            this.txtInvPDC.Name = "txtInvPDC";
            this.txtInvPDC.Size = new System.Drawing.Size(198, 24);
            this.txtInvPDC.TabIndex = 1;
            this.txtInvPDC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvPDC_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 330);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 16);
            this.label18.TabIndex = 5487;
            this.label18.Text = "Invoice # :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 5484;
            this.label13.Text = "Amount :";
            // 
            // txtPDCamt
            // 
            this.txtPDCamt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPDCamt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPDCamt.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDCamt.Location = new System.Drawing.Point(11, 25);
            this.txtPDCamt.Name = "txtPDCamt";
            this.txtPDCamt.ReadOnly = true;
            this.txtPDCamt.Size = new System.Drawing.Size(367, 37);
            this.txtPDCamt.TabIndex = 5483;
            this.txtPDCamt.TabStop = false;
            this.txtPDCamt.Text = "0.00";
            // 
            // btnPDC
            // 
            this.btnPDC.BackColor = System.Drawing.Color.Silver;
            this.btnPDC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDC.ForeColor = System.Drawing.Color.Black;
            this.btnPDC.Image = ((System.Drawing.Image)(resources.GetObject("btnPDC.Image")));
            this.btnPDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDC.Location = new System.Drawing.Point(293, 321);
            this.btnPDC.Name = "btnPDC";
            this.btnPDC.Size = new System.Drawing.Size(90, 36);
            this.btnPDC.TabIndex = 2;
            this.btnPDC.Text = "Settle";
            this.btnPDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDC.UseVisualStyleBackColor = false;
            this.btnPDC.Click += new System.EventHandler(this.btnPDC_Click);
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
            this.lstPDC.Location = new System.Drawing.Point(6, 68);
            this.lstPDC.MultiSelect = false;
            this.lstPDC.Name = "lstPDC";
            this.lstPDC.Size = new System.Drawing.Size(377, 214);
            this.lstPDC.TabIndex = 5467;
            this.lstPDC.UseCompatibleStateImageBehavior = false;
            this.lstPDC.View = System.Windows.Forms.View.Details;
            this.lstPDC.SelectedIndexChanged += new System.EventHandler(this.lstPDC_SelectedIndexChanged);
            this.lstPDC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstPDC_MouseUp);
            // 
            // tabCash
            // 
            this.tabCash.BackColor = System.Drawing.Color.Gray;
            this.tabCash.Controls.Add(this.label20);
            this.tabCash.Controls.Add(this.txtCashTender);
            this.tabCash.Controls.Add(this.btnCash);
            this.tabCash.Controls.Add(this.txtInvCash);
            this.tabCash.Controls.Add(this.label9);
            this.tabCash.Controls.Add(this.dtCashGiven);
            this.tabCash.Controls.Add(this.label10);
            this.tabCash.Controls.Add(this.label11);
            this.tabCash.Controls.Add(this.txtAmtCash);
            this.tabCash.Location = new System.Drawing.Point(4, 25);
            this.tabCash.Name = "tabCash";
            this.tabCash.Padding = new System.Windows.Forms.Padding(3);
            this.tabCash.Size = new System.Drawing.Size(389, 364);
            this.tabCash.TabIndex = 0;
            this.tabCash.Text = "Cash";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 16);
            this.label20.TabIndex = 5487;
            this.label20.Text = "Amount Tendered :";
            // 
            // txtCashTender
            // 
            this.txtCashTender.DecimalPlaces = 2;
            this.txtCashTender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashTender.Location = new System.Drawing.Point(11, 85);
            this.txtCashTender.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtCashTender.Name = "txtCashTender";
            this.txtCashTender.Size = new System.Drawing.Size(367, 24);
            this.txtCashTender.TabIndex = 0;
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.Silver;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.ForeColor = System.Drawing.Color.Black;
            this.btnCash.Image = ((System.Drawing.Image)(resources.GetObject("btnCash.Image")));
            this.btnCash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCash.Location = new System.Drawing.Point(288, 179);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(90, 36);
            this.btnCash.TabIndex = 3;
            this.btnCash.Text = "Settle";
            this.btnCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // txtInvCash
            // 
            this.txtInvCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvCash.Location = new System.Drawing.Point(128, 148);
            this.txtInvCash.MaxLength = 40;
            this.txtInvCash.Name = "txtInvCash";
            this.txtInvCash.Size = new System.Drawing.Size(250, 24);
            this.txtInvCash.TabIndex = 2;
            this.txtInvCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvCash_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 5485;
            this.label9.Text = "Invoice # :";
            // 
            // dtCashGiven
            // 
            this.dtCashGiven.CustomFormat = "yyy-MM-dd";
            this.dtCashGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCashGiven.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCashGiven.Location = new System.Drawing.Point(128, 117);
            this.dtCashGiven.Name = "dtCashGiven";
            this.dtCashGiven.Size = new System.Drawing.Size(250, 24);
            this.dtCashGiven.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 120);
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
            // txtAmtCash
            // 
            this.txtAmtCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAmtCash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmtCash.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtCash.Location = new System.Drawing.Point(11, 26);
            this.txtAmtCash.Name = "txtAmtCash";
            this.txtAmtCash.ReadOnly = true;
            this.txtAmtCash.Size = new System.Drawing.Size(367, 37);
            this.txtAmtCash.TabIndex = 5481;
            this.txtAmtCash.TabStop = false;
            this.txtAmtCash.Text = "0.00";
            // 
            // tabOnline
            // 
            this.tabOnline.BackColor = System.Drawing.Color.Gray;
            this.tabOnline.Controls.Add(this.label21);
            this.tabOnline.Controls.Add(this.txtOnlineTender);
            this.tabOnline.Controls.Add(this.btnOnline);
            this.tabOnline.Controls.Add(this.txtInvOnline);
            this.tabOnline.Controls.Add(this.label7);
            this.tabOnline.Controls.Add(this.dtOnlineGiven);
            this.tabOnline.Controls.Add(this.label8);
            this.tabOnline.Controls.Add(this.label12);
            this.tabOnline.Controls.Add(this.txtAmtOnline);
            this.tabOnline.Location = new System.Drawing.Point(4, 25);
            this.tabOnline.Name = "tabOnline";
            this.tabOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tabOnline.Size = new System.Drawing.Size(389, 364);
            this.tabOnline.TabIndex = 1;
            this.tabOnline.Text = "Online";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 68);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(139, 16);
            this.label21.TabIndex = 5489;
            this.label21.Text = "Amount Tendered :";
            // 
            // txtOnlineTender
            // 
            this.txtOnlineTender.DecimalPlaces = 2;
            this.txtOnlineTender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnlineTender.Location = new System.Drawing.Point(11, 85);
            this.txtOnlineTender.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtOnlineTender.Name = "txtOnlineTender";
            this.txtOnlineTender.Size = new System.Drawing.Size(367, 24);
            this.txtOnlineTender.TabIndex = 0;
            // 
            // btnOnline
            // 
            this.btnOnline.BackColor = System.Drawing.Color.Silver;
            this.btnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnline.ForeColor = System.Drawing.Color.Black;
            this.btnOnline.Image = ((System.Drawing.Image)(resources.GetObject("btnOnline.Image")));
            this.btnOnline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOnline.Location = new System.Drawing.Point(288, 179);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(90, 36);
            this.btnOnline.TabIndex = 3;
            this.btnOnline.Text = "Settle";
            this.btnOnline.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOnline.UseVisualStyleBackColor = false;
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // txtInvOnline
            // 
            this.txtInvOnline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvOnline.Location = new System.Drawing.Point(128, 148);
            this.txtInvOnline.MaxLength = 40;
            this.txtInvOnline.Name = "txtInvOnline";
            this.txtInvOnline.Size = new System.Drawing.Size(250, 24);
            this.txtInvOnline.TabIndex = 2;
            this.txtInvOnline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvOnline_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 5478;
            this.label7.Text = "Invoice # :";
            // 
            // dtOnlineGiven
            // 
            this.dtOnlineGiven.CustomFormat = "yyy-MM-dd";
            this.dtOnlineGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtOnlineGiven.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOnlineGiven.Location = new System.Drawing.Point(128, 117);
            this.dtOnlineGiven.Name = "dtOnlineGiven";
            this.dtOnlineGiven.Size = new System.Drawing.Size(250, 24);
            this.dtOnlineGiven.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 5476;
            this.label8.Text = "Date Given :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 16);
            this.label12.TabIndex = 5469;
            this.label12.Text = "Amount :";
            // 
            // txtAmtOnline
            // 
            this.txtAmtOnline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAmtOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmtOnline.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtOnline.Location = new System.Drawing.Point(11, 26);
            this.txtAmtOnline.Name = "txtAmtOnline";
            this.txtAmtOnline.ReadOnly = true;
            this.txtAmtOnline.Size = new System.Drawing.Size(367, 37);
            this.txtAmtOnline.TabIndex = 5468;
            this.txtAmtOnline.TabStop = false;
            this.txtAmtOnline.Text = "0.00";
            // 
            // tabCheck
            // 
            this.tabCheck.BackColor = System.Drawing.Color.Gray;
            this.tabCheck.Controls.Add(this.label14);
            this.tabCheck.Controls.Add(this.txtCheckAmt);
            this.tabCheck.Controls.Add(this.btnCheck);
            this.tabCheck.Controls.Add(this.txtInvCheck);
            this.tabCheck.Controls.Add(this.label6);
            this.tabCheck.Controls.Add(this.dtCheckGiven);
            this.tabCheck.Controls.Add(this.label5);
            this.tabCheck.Controls.Add(this.dtCheck);
            this.tabCheck.Controls.Add(this.label4);
            this.tabCheck.Controls.Add(this.txtChekNo);
            this.tabCheck.Controls.Add(this.label3);
            this.tabCheck.Controls.Add(this.txtBank);
            this.tabCheck.Controls.Add(this.label2);
            this.tabCheck.Controls.Add(this.label1);
            this.tabCheck.Controls.Add(this.txtAmtCheck);
            this.tabCheck.Location = new System.Drawing.Point(4, 25);
            this.tabCheck.Name = "tabCheck";
            this.tabCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheck.Size = new System.Drawing.Size(389, 364);
            this.tabCheck.TabIndex = 2;
            this.tabCheck.Text = "Check";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 16);
            this.label14.TabIndex = 61;
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
            this.txtCheckAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheckAmt_KeyDown);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Silver;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.Black;
            this.btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck.Image")));
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(288, 267);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(90, 36);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Settle";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtInvCheck
            // 
            this.txtInvCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvCheck.Location = new System.Drawing.Point(128, 236);
            this.txtInvCheck.MaxLength = 40;
            this.txtInvCheck.Name = "txtInvCheck";
            this.txtInvCheck.Size = new System.Drawing.Size(250, 24);
            this.txtInvCheck.TabIndex = 5;
            this.txtInvCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvCheck_KeyDown);
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
            // dtCheckGiven
            // 
            this.dtCheckGiven.CustomFormat = "yyy-MM-dd";
            this.dtCheckGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCheckGiven.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCheckGiven.Location = new System.Drawing.Point(128, 172);
            this.dtCheckGiven.Name = "dtCheckGiven";
            this.dtCheckGiven.Size = new System.Drawing.Size(250, 24);
            this.dtCheckGiven.TabIndex = 3;
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
            // dtCheck
            // 
            this.dtCheck.CustomFormat = "yyy-MM-dd";
            this.dtCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCheck.Location = new System.Drawing.Point(128, 140);
            this.dtCheck.Name = "dtCheck";
            this.dtCheck.Size = new System.Drawing.Size(250, 24);
            this.dtCheck.TabIndex = 2;
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
            // txtChekNo
            // 
            this.txtChekNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChekNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChekNo.Location = new System.Drawing.Point(128, 109);
            this.txtChekNo.MaxLength = 40;
            this.txtChekNo.Name = "txtChekNo";
            this.txtChekNo.Size = new System.Drawing.Size(250, 24);
            this.txtChekNo.TabIndex = 1;
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
            // txtBank
            // 
            this.txtBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(128, 78);
            this.txtBank.MaxLength = 40;
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(250, 24);
            this.txtBank.TabIndex = 0;
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
            // txtAmtCheck
            // 
            this.txtAmtCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAmtCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmtCheck.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtCheck.Location = new System.Drawing.Point(11, 26);
            this.txtAmtCheck.Name = "txtAmtCheck";
            this.txtAmtCheck.ReadOnly = true;
            this.txtAmtCheck.Size = new System.Drawing.Size(367, 37);
            this.txtAmtCheck.TabIndex = 0;
            this.txtAmtCheck.TabStop = false;
            this.txtAmtCheck.Text = "0.00";
            // 
            // tabDepo
            // 
            this.tabDepo.BackColor = System.Drawing.Color.Gray;
            this.tabDepo.Controls.Add(this.txtBalDepo);
            this.tabDepo.Controls.Add(this.btnDepoSettle);
            this.tabDepo.Controls.Add(this.txtDepoInv);
            this.tabDepo.Controls.Add(this.label16);
            this.tabDepo.Controls.Add(this.label17);
            this.tabDepo.Controls.Add(this.label15);
            this.tabDepo.Controls.Add(this.txtDepoAmt);
            this.tabDepo.Location = new System.Drawing.Point(4, 25);
            this.tabDepo.Name = "tabDepo";
            this.tabDepo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepo.Size = new System.Drawing.Size(389, 364);
            this.tabDepo.TabIndex = 4;
            this.tabDepo.Text = "Deposits";
            // 
            // txtBalDepo
            // 
            this.txtBalDepo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBalDepo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBalDepo.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalDepo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtBalDepo.Location = new System.Drawing.Point(11, 86);
            this.txtBalDepo.Name = "txtBalDepo";
            this.txtBalDepo.ReadOnly = true;
            this.txtBalDepo.Size = new System.Drawing.Size(367, 37);
            this.txtBalDepo.TabIndex = 5484;
            this.txtBalDepo.TabStop = false;
            this.txtBalDepo.Text = "0.00";
            // 
            // btnDepoSettle
            // 
            this.btnDepoSettle.BackColor = System.Drawing.Color.Silver;
            this.btnDepoSettle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepoSettle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepoSettle.ForeColor = System.Drawing.Color.Black;
            this.btnDepoSettle.Image = ((System.Drawing.Image)(resources.GetObject("btnDepoSettle.Image")));
            this.btnDepoSettle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepoSettle.Location = new System.Drawing.Point(288, 176);
            this.btnDepoSettle.Name = "btnDepoSettle";
            this.btnDepoSettle.Size = new System.Drawing.Size(90, 36);
            this.btnDepoSettle.TabIndex = 1;
            this.btnDepoSettle.Text = "Settle";
            this.btnDepoSettle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDepoSettle.UseVisualStyleBackColor = false;
            this.btnDepoSettle.Click += new System.EventHandler(this.btnDepoSettle_Click);
            // 
            // txtDepoInv
            // 
            this.txtDepoInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepoInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepoInv.Location = new System.Drawing.Point(128, 145);
            this.txtDepoInv.MaxLength = 40;
            this.txtDepoInv.Name = "txtDepoInv";
            this.txtDepoInv.Size = new System.Drawing.Size(250, 24);
            this.txtDepoInv.TabIndex = 0;
            this.txtDepoInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepoInv_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 16);
            this.label16.TabIndex = 5483;
            this.label16.Text = "Invoice # :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 16);
            this.label17.TabIndex = 5481;
            this.label17.Text = "Balance Deposit :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 16);
            this.label15.TabIndex = 362;
            this.label15.Text = "Amount :";
            // 
            // txtDepoAmt
            // 
            this.txtDepoAmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDepoAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepoAmt.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepoAmt.Location = new System.Drawing.Point(11, 26);
            this.txtDepoAmt.Name = "txtDepoAmt";
            this.txtDepoAmt.ReadOnly = true;
            this.txtDepoAmt.Size = new System.Drawing.Size(367, 37);
            this.txtDepoAmt.TabIndex = 2;
            this.txtDepoAmt.TabStop = false;
            this.txtDepoAmt.Text = "0.00";
            // 
            // frmSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(427, 444);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSettle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSettle_Load);
            this.Shown += new System.EventHandler(this.frmSettle_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSettle_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSettle_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSettle_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmSettle_MouseUp);
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPDC.ResumeLayout(false);
            this.tabPDC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdjustAmt)).EndInit();
            this.tabCash.ResumeLayout(false);
            this.tabCash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashTender)).EndInit();
            this.tabOnline.ResumeLayout(false);
            this.tabOnline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnlineTender)).EndInit();
            this.tabCheck.ResumeLayout(false);
            this.tabCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckAmt)).EndInit();
            this.tabDepo.ResumeLayout(false);
            this.tabDepo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCash;
        private System.Windows.Forms.TabPage tabOnline;
        private System.Windows.Forms.TabPage tabCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmtCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChekNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.TextBox txtInvCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtCheckGiven;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtCheck;
        private System.Windows.Forms.Button btnOnline;
        private System.Windows.Forms.TextBox txtInvOnline;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtOnlineGiven;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAmtOnline;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.TextBox txtInvCash;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtCashGiven;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAmtCash;
        private System.Windows.Forms.TabPage tabPDC;
        private System.Windows.Forms.ListView lstPDC;
        private System.Windows.Forms.Button btnPDC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPDCamt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown txtCheckAmt;
        private System.Windows.Forms.TabPage tabDepo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDepoAmt;
        private System.Windows.Forms.Button btnDepoSettle;
        private System.Windows.Forms.TextBox txtDepoInv;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBalDepo;
        private System.Windows.Forms.TextBox txtInvPDC;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown txtAdjustAmt;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown txtCashTender;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown txtOnlineTender;
    }
}