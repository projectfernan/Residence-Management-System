namespace prjRMS
{
    partial class frmEditPDC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPDC));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dtPeriod = new System.Windows.Forms.DateTimePicker();
            this.txtAmt = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvPdc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtPdcCheck = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPdcCheckNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPdcBank = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.dtPeriod);
            this.panel1.Controls.Add(this.txtAmt);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtInvPdc);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dtPdcCheck);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtPdcCheckNo);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtPdcBank);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(6, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 271);
            this.panel1.TabIndex = 564;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Silver;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(271, 216);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 36);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Update";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dtPeriod
            // 
            this.dtPeriod.CustomFormat = "MMMM yyyy";
            this.dtPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPeriod.Location = new System.Drawing.Point(126, 24);
            this.dtPeriod.Name = "dtPeriod";
            this.dtPeriod.Size = new System.Drawing.Size(250, 24);
            this.dtPeriod.TabIndex = 0;
            // 
            // txtAmt
            // 
            this.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmt.Location = new System.Drawing.Point(127, 151);
            this.txtAmt.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(248, 24);
            this.txtAmt.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(53, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 16);
            this.label12.TabIndex = 5487;
            this.label12.Text = "Amount :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(58, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 5486;
            this.label7.Text = "Period :";
            // 
            // txtInvPdc
            // 
            this.txtInvPdc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvPdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvPdc.Location = new System.Drawing.Point(126, 184);
            this.txtInvPdc.MaxLength = 40;
            this.txtInvPdc.Name = "txtInvPdc";
            this.txtInvPdc.Size = new System.Drawing.Size(250, 24);
            this.txtInvPdc.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(42, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 16);
            this.label13.TabIndex = 5485;
            this.label13.Text = "Invoice # :";
            // 
            // dtPdcCheck
            // 
            this.dtPdcCheck.CustomFormat = "yyy-MM-dd";
            this.dtPdcCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPdcCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPdcCheck.Location = new System.Drawing.Point(126, 118);
            this.dtPdcCheck.Name = "dtPdcCheck";
            this.dtPdcCheck.Size = new System.Drawing.Size(250, 24);
            this.dtPdcCheck.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(24, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 5484;
            this.label15.Text = "Check Date :";
            // 
            // txtPdcCheckNo
            // 
            this.txtPdcCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPdcCheckNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPdcCheckNo.Location = new System.Drawing.Point(126, 87);
            this.txtPdcCheckNo.MaxLength = 40;
            this.txtPdcCheckNo.Name = "txtPdcCheckNo";
            this.txtPdcCheckNo.Size = new System.Drawing.Size(250, 24);
            this.txtPdcCheckNo.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(49, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 16);
            this.label16.TabIndex = 5483;
            this.label16.Text = "Check # :";
            // 
            // txtPdcBank
            // 
            this.txtPdcBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPdcBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPdcBank.Location = new System.Drawing.Point(126, 56);
            this.txtPdcBank.MaxLength = 40;
            this.txtPdcBank.Name = "txtPdcBank";
            this.txtPdcBank.Size = new System.Drawing.Size(250, 24);
            this.txtPdcBank.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(8, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 16);
            this.label17.TabIndex = 5479;
            this.label17.Text = "Bank / Branch :";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(3, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(101, 18);
            this.lbTitle.TabIndex = 2661;
            this.lbTitle.Text = "Update PDC";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(381, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2662;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // frmEditPDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(403, 301);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditPDC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmEditPDC_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEditPDC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmEditPDC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmEditPDC_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.DateTimePicker dtPeriod;
        private System.Windows.Forms.NumericUpDown txtAmt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInvPdc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtPdcCheck;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPdcCheckNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPdcBank;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSubmit;
    }
}