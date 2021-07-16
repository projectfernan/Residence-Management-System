namespace prjRMS
{
    partial class frmBalTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalTrans));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTransAmt = new System.Windows.Forms.NumericUpDown();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtTenant = new System.Windows.Forms.Label();
            this.txtBillName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lstBills = new System.Windows.Forms.ListView();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransAmt)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(3, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(136, 18);
            this.lbTitle.TabIndex = 2663;
            this.lbTitle.Text = "Balance Transfer";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(471, -1);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2664;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTransAmt);
            this.panel1.Controls.Add(this.btnTransfer);
            this.panel1.Controls.Add(this.txtTenant);
            this.panel1.Controls.Add(this.txtBillName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.lstBills);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtAmt);
            this.panel1.Location = new System.Drawing.Point(6, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 344);
            this.panel1.TabIndex = 2665;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 16);
            this.label1.TabIndex = 5476;
            this.label1.Text = "Enter the amount that you will transfer :";
            // 
            // txtTransAmt
            // 
            this.txtTransAmt.DecimalPlaces = 2;
            this.txtTransAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransAmt.Location = new System.Drawing.Point(8, 311);
            this.txtTransAmt.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtTransAmt.Name = "txtTransAmt";
            this.txtTransAmt.Size = new System.Drawing.Size(289, 24);
            this.txtTransAmt.TabIndex = 5475;
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.Silver;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.Color.Black;
            this.btnTransfer.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfer.Image")));
            this.btnTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransfer.Location = new System.Drawing.Point(303, 300);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(170, 36);
            this.btnTransfer.TabIndex = 5474;
            this.btnTransfer.Text = "Transfer Balance";
            this.btnTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtTenant
            // 
            this.txtTenant.AutoSize = true;
            this.txtTenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTenant.Location = new System.Drawing.Point(98, 102);
            this.txtTenant.Name = "txtTenant";
            this.txtTenant.Size = new System.Drawing.Size(13, 16);
            this.txtTenant.TabIndex = 5473;
            this.txtTenant.Text = "-";
            // 
            // txtBillName
            // 
            this.txtBillName.AutoSize = true;
            this.txtBillName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBillName.Location = new System.Drawing.Point(98, 77);
            this.txtBillName.Name = "txtBillName";
            this.txtBillName.Size = new System.Drawing.Size(13, 16);
            this.txtBillName.TabIndex = 5472;
            this.txtBillName.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 5471;
            this.label7.Text = "Bill Name :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(28, 102);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 5470;
            this.label17.Text = "Tenant :";
            // 
            // lstBills
            // 
            this.lstBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstBills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBills.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBills.FullRowSelect = true;
            this.lstBills.GridLines = true;
            this.lstBills.Location = new System.Drawing.Point(8, 126);
            this.lstBills.MultiSelect = false;
            this.lstBills.Name = "lstBills";
            this.lstBills.Size = new System.Drawing.Size(463, 162);
            this.lstBills.TabIndex = 5469;
            this.lstBills.UseCompatibleStateImageBehavior = false;
            this.lstBills.View = System.Windows.Forms.View.Details;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(7, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 16);
            this.label18.TabIndex = 5468;
            this.label18.Text = "Balance Amount :";
            // 
            // txtAmt
            // 
            this.txtAmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmt.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmt.Location = new System.Drawing.Point(8, 28);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.ReadOnly = true;
            this.txtAmt.Size = new System.Drawing.Size(463, 37);
            this.txtAmt.TabIndex = 5467;
            this.txtAmt.TabStop = false;
            this.txtAmt.Text = "0.00";
            // 
            // frmBalTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(491, 374);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBalTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBalTrans_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBalTrans_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmBalTrans_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmBalTrans_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransAmt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lstBills;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtAmt;
        private System.Windows.Forms.Label txtTenant;
        private System.Windows.Forms.Label txtBillName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.NumericUpDown txtTransAmt;
        private System.Windows.Forms.Label label1;
    }
}