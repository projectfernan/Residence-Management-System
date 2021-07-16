namespace prjRMS
{
    partial class frmDesig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesig));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkTerminate = new System.Windows.Forms.CheckBox();
            this.chkMoveOut = new System.Windows.Forms.CheckBox();
            this.chkContSign = new System.Windows.Forms.CheckBox();
            this.chkPayments = new System.Windows.Forms.CheckBox();
            this.chkTeTrans = new System.Windows.Forms.CheckBox();
            this.chkMisce = new System.Windows.Forms.CheckBox();
            this.txtDesig = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSettings = new System.Windows.Forms.CheckBox();
            this.chkNewTenant = new System.Windows.Forms.CheckBox();
            this.chkRmBill = new System.Windows.Forms.CheckBox();
            this.chkTeCont = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstDesig = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.chkEditRmBill = new System.Windows.Forms.CheckBox();
            this.chkEditTeCont = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(6, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 484);
            this.panel1.TabIndex = 561;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkEditTeCont);
            this.groupBox7.Controls.Add(this.chkEditRmBill);
            this.groupBox7.Controls.Add(this.btnSave);
            this.groupBox7.Controls.Add(this.chkTerminate);
            this.groupBox7.Controls.Add(this.chkMoveOut);
            this.groupBox7.Controls.Add(this.chkContSign);
            this.groupBox7.Controls.Add(this.chkPayments);
            this.groupBox7.Controls.Add(this.chkTeTrans);
            this.groupBox7.Controls.Add(this.chkMisce);
            this.groupBox7.Controls.Add(this.txtDesig);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.chkSettings);
            this.groupBox7.Controls.Add(this.chkNewTenant);
            this.groupBox7.Controls.Add(this.chkRmBill);
            this.groupBox7.Controls.Add(this.chkTeCont);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(13, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(316, 461);
            this.groupBox7.TabIndex = 865;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Set Designation";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(21, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 36);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Add";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkTerminate
            // 
            this.chkTerminate.AutoSize = true;
            this.chkTerminate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTerminate.ForeColor = System.Drawing.Color.White;
            this.chkTerminate.Location = new System.Drawing.Point(21, 366);
            this.chkTerminate.Name = "chkTerminate";
            this.chkTerminate.Size = new System.Drawing.Size(152, 20);
            this.chkTerminate.TabIndex = 12;
            this.chkTerminate.Text = "System Terminate";
            this.chkTerminate.UseVisualStyleBackColor = true;
            // 
            // chkMoveOut
            // 
            this.chkMoveOut.AutoSize = true;
            this.chkMoveOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveOut.ForeColor = System.Drawing.Color.White;
            this.chkMoveOut.Location = new System.Drawing.Point(21, 340);
            this.chkMoveOut.Name = "chkMoveOut";
            this.chkMoveOut.Size = new System.Drawing.Size(92, 20);
            this.chkMoveOut.TabIndex = 11;
            this.chkMoveOut.Text = "Move Out";
            this.chkMoveOut.UseVisualStyleBackColor = true;
            // 
            // chkContSign
            // 
            this.chkContSign.AutoSize = true;
            this.chkContSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContSign.ForeColor = System.Drawing.Color.White;
            this.chkContSign.Location = new System.Drawing.Point(21, 314);
            this.chkContSign.Name = "chkContSign";
            this.chkContSign.Size = new System.Drawing.Size(140, 20);
            this.chkContSign.TabIndex = 10;
            this.chkContSign.Text = "Contract Signing";
            this.chkContSign.UseVisualStyleBackColor = true;
            // 
            // chkPayments
            // 
            this.chkPayments.AutoSize = true;
            this.chkPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPayments.ForeColor = System.Drawing.Color.White;
            this.chkPayments.Location = new System.Drawing.Point(21, 288);
            this.chkPayments.Name = "chkPayments";
            this.chkPayments.Size = new System.Drawing.Size(95, 20);
            this.chkPayments.TabIndex = 9;
            this.chkPayments.Text = "Payments";
            this.chkPayments.UseVisualStyleBackColor = true;
            // 
            // chkTeTrans
            // 
            this.chkTeTrans.AutoSize = true;
            this.chkTeTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTeTrans.ForeColor = System.Drawing.Color.White;
            this.chkTeTrans.Location = new System.Drawing.Point(21, 262);
            this.chkTeTrans.Name = "chkTeTrans";
            this.chkTeTrans.Size = new System.Drawing.Size(173, 20);
            this.chkTeTrans.TabIndex = 8;
            this.chkTeTrans.Text = "Tenant\'s Transaction";
            this.chkTeTrans.UseVisualStyleBackColor = true;
            // 
            // chkMisce
            // 
            this.chkMisce.AutoSize = true;
            this.chkMisce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMisce.ForeColor = System.Drawing.Color.White;
            this.chkMisce.Location = new System.Drawing.Point(21, 236);
            this.chkMisce.Name = "chkMisce";
            this.chkMisce.Size = new System.Drawing.Size(166, 20);
            this.chkMisce.TabIndex = 7;
            this.chkMisce.Text = "Miscellaneous Fees";
            this.chkMisce.UseVisualStyleBackColor = true;
            // 
            // txtDesig
            // 
            this.txtDesig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesig.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesig.Location = new System.Drawing.Point(21, 49);
            this.txtDesig.Name = "txtDesig";
            this.txtDesig.Size = new System.Drawing.Size(273, 24);
            this.txtDesig.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Contract Name :";
            // 
            // chkSettings
            // 
            this.chkSettings.AutoSize = true;
            this.chkSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSettings.ForeColor = System.Drawing.Color.White;
            this.chkSettings.Location = new System.Drawing.Point(21, 80);
            this.chkSettings.Name = "chkSettings";
            this.chkSettings.Size = new System.Drawing.Size(83, 20);
            this.chkSettings.TabIndex = 1;
            this.chkSettings.Text = "Settings";
            this.chkSettings.UseVisualStyleBackColor = true;
            // 
            // chkNewTenant
            // 
            this.chkNewTenant.AutoSize = true;
            this.chkNewTenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNewTenant.ForeColor = System.Drawing.Color.White;
            this.chkNewTenant.Location = new System.Drawing.Point(21, 106);
            this.chkNewTenant.Name = "chkNewTenant";
            this.chkNewTenant.Size = new System.Drawing.Size(109, 20);
            this.chkNewTenant.TabIndex = 2;
            this.chkNewTenant.Text = "New Tenant";
            this.chkNewTenant.UseVisualStyleBackColor = true;
            // 
            // chkRmBill
            // 
            this.chkRmBill.AutoSize = true;
            this.chkRmBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRmBill.ForeColor = System.Drawing.Color.White;
            this.chkRmBill.Location = new System.Drawing.Point(21, 184);
            this.chkRmBill.Name = "chkRmBill";
            this.chkRmBill.Size = new System.Drawing.Size(115, 20);
            this.chkRmBill.TabIndex = 5;
            this.chkRmBill.Text = "Room Billing";
            this.chkRmBill.UseVisualStyleBackColor = true;
            // 
            // chkTeCont
            // 
            this.chkTeCont.AutoSize = true;
            this.chkTeCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTeCont.ForeColor = System.Drawing.Color.White;
            this.chkTeCont.Location = new System.Drawing.Point(21, 132);
            this.chkTeCont.Name = "chkTeCont";
            this.chkTeCont.Size = new System.Drawing.Size(148, 20);
            this.chkTeCont.TabIndex = 3;
            this.chkTeCont.Text = "Tenant\'s Contract";
            this.chkTeCont.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(344, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 461);
            this.groupBox1.TabIndex = 2626;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Designation List";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.lstDesig);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Location = new System.Drawing.Point(6, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 433);
            this.panel2.TabIndex = 2655;
            // 
            // lstDesig
            // 
            this.lstDesig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDesig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstDesig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstDesig.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDesig.FullRowSelect = true;
            this.lstDesig.GridLines = true;
            this.lstDesig.Location = new System.Drawing.Point(6, 42);
            this.lstDesig.MultiSelect = false;
            this.lstDesig.Name = "lstDesig";
            this.lstDesig.Size = new System.Drawing.Size(332, 385);
            this.lstDesig.TabIndex = 5465;
            this.lstDesig.UseCompatibleStateImageBehavior = false;
            this.lstDesig.View = System.Windows.Forms.View.Details;
            this.lstDesig.SelectedIndexChanged += new System.EventHandler(this.lstDesig_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.btnReset,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(344, 36);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(63, 33);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(78, 33);
            this.toolStripButton1.Text = "Delete";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(73, 33);
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(3, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(163, 18);
            this.lbTitle.TabIndex = 2663;
            this.lbTitle.Text = "Designation Settings";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(704, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2664;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // chkEditRmBill
            // 
            this.chkEditRmBill.AutoSize = true;
            this.chkEditRmBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEditRmBill.ForeColor = System.Drawing.Color.White;
            this.chkEditRmBill.Location = new System.Drawing.Point(21, 210);
            this.chkEditRmBill.Name = "chkEditRmBill";
            this.chkEditRmBill.Size = new System.Drawing.Size(146, 20);
            this.chkEditRmBill.TabIndex = 6;
            this.chkEditRmBill.Text = "Edit Room Billing";
            this.chkEditRmBill.UseVisualStyleBackColor = true;
            // 
            // chkEditTeCont
            // 
            this.chkEditTeCont.AutoSize = true;
            this.chkEditTeCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEditTeCont.ForeColor = System.Drawing.Color.White;
            this.chkEditTeCont.Location = new System.Drawing.Point(21, 158);
            this.chkEditTeCont.Name = "chkEditTeCont";
            this.chkEditTeCont.Size = new System.Drawing.Size(115, 20);
            this.chkEditTeCont.TabIndex = 4;
            this.chkEditTeCont.Text = "Edit Contract";
            this.chkEditTeCont.UseVisualStyleBackColor = true;
            // 
            // frmDesig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(726, 515);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDesig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDesig_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmDesig_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmDesig_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmDesig_MouseUp);
            this.panel1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lstDesig;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox chkSettings;
        private System.Windows.Forms.CheckBox chkNewTenant;
        private System.Windows.Forms.CheckBox chkRmBill;
        private System.Windows.Forms.CheckBox chkTeCont;
        private System.Windows.Forms.TextBox txtDesig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.CheckBox chkTerminate;
        private System.Windows.Forms.CheckBox chkMoveOut;
        private System.Windows.Forms.CheckBox chkContSign;
        private System.Windows.Forms.CheckBox chkPayments;
        private System.Windows.Forms.CheckBox chkTeTrans;
        private System.Windows.Forms.CheckBox chkMisce;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.CheckBox chkEditTeCont;
        private System.Windows.Forms.CheckBox chkEditRmBill;
    }
}