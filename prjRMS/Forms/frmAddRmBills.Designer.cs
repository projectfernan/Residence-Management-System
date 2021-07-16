namespace prjRMS
{
    partial class frmAddRmBills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddRmBills));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtFrm = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPeriod = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmt = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRmNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cboBiller = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.dtFrm);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtPeriod);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.dtDueDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAmt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboRmNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtTo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboBiller);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(7, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 356);
            this.panel1.TabIndex = 561;
            // 
            // dtFrm
            // 
            this.dtFrm.CustomFormat = "yyy-MM-dd";
            this.dtFrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrm.Location = new System.Drawing.Point(128, 189);
            this.dtFrm.Name = "dtFrm";
            this.dtFrm.Size = new System.Drawing.Size(249, 24);
            this.dtFrm.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(35, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 5479;
            this.label4.Text = "From Date :";
            // 
            // dtPeriod
            // 
            this.dtPeriod.CustomFormat = "MMMM yyyy";
            this.dtPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPeriod.Location = new System.Drawing.Point(127, 110);
            this.dtPeriod.Name = "dtPeriod";
            this.dtPeriod.Size = new System.Drawing.Size(250, 24);
            this.dtPeriod.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(275, 304);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtDueDate
            // 
            this.dtDueDate.CustomFormat = "yyy-MM-dd";
            this.dtDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDueDate.Location = new System.Drawing.Point(127, 267);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(249, 24);
            this.dtDueDate.TabIndex = 6;
            this.dtDueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDueDate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(43, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 5473;
            this.label3.Text = "Due Date :";
            // 
            // txtAmt
            // 
            this.txtAmt.DecimalPlaces = 2;
            this.txtAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmt.Location = new System.Drawing.Point(127, 149);
            this.txtAmt.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(249, 24);
            this.txtAmt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 5471;
            this.label1.Text = "Period :";
            // 
            // cboRmNo
            // 
            this.cboRmNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboRmNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRmNo.FormattingEnabled = true;
            this.cboRmNo.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Others"});
            this.cboRmNo.Location = new System.Drawing.Point(127, 33);
            this.cboRmNo.MaxLength = 6;
            this.cboRmNo.Name = "cboRmNo";
            this.cboRmNo.Size = new System.Drawing.Size(249, 24);
            this.cboRmNo.TabIndex = 0;
            this.cboRmNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboRmNo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 2663;
            this.label2.Text = "Room No :";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "yyy-MM-dd";
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(128, 228);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(249, 24);
            this.dtTo.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(51, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 55;
            this.label8.Text = "To Date :";
            // 
            // cboBiller
            // 
            this.cboBiller.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboBiller.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBiller.FormattingEnabled = true;
            this.cboBiller.Items.AddRange(new object[] {
            "Meralco",
            "Water Bill"});
            this.cboBiller.Location = new System.Drawing.Point(127, 72);
            this.cboBiller.MaxLength = 6;
            this.cboBiller.Name = "cboBiller";
            this.cboBiller.Size = new System.Drawing.Size(249, 24);
            this.cboBiller.TabIndex = 1;
            this.cboBiller.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBiller_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(27, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 16);
            this.label7.TabIndex = 53;
            this.label7.Text = "Biller Name :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(57, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 52;
            this.label6.Text = "Amount :";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(3, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(142, 18);
            this.lbTitle.TabIndex = 2656;
            this.lbTitle.Text = "New Room Billing";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(387, -1);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2657;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // frmAddRmBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(407, 388);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddRmBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddRmBills_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmAddRmBills_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmAddRmBills_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmAddRmBills_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboBiller;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboRmNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtAmt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtPeriod;
        private System.Windows.Forms.DateTimePicker dtFrm;
        private System.Windows.Forms.Label label4;
    }
}