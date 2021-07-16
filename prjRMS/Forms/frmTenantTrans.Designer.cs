namespace prjRMS
{
    partial class frmTenantTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTenantTrans));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnTenantPDC = new System.Windows.Forms.Button();
            this.btnTInv = new System.Windows.Forms.Button();
            this.btnTbills = new System.Windows.Forms.Button();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tenant\'s Transactions";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnRefund);
            this.panel1.Controls.Add(this.btnTenantPDC);
            this.panel1.Controls.Add(this.btnTInv);
            this.panel1.Controls.Add(this.btnTbills);
            this.panel1.Location = new System.Drawing.Point(6, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 245);
            this.panel1.TabIndex = 7;
            // 
            // btnRefund
            // 
            this.btnRefund.BackColor = System.Drawing.Color.Silver;
            this.btnRefund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefund.Image = ((System.Drawing.Image)(resources.GetObject("btnRefund.Image")));
            this.btnRefund.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefund.Location = new System.Drawing.Point(8, 183);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(303, 52);
            this.btnRefund.TabIndex = 5;
            this.btnRefund.Text = "          Tenant Deposits Refund";
            this.btnRefund.UseVisualStyleBackColor = false;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnTenantPDC
            // 
            this.btnTenantPDC.BackColor = System.Drawing.Color.Silver;
            this.btnTenantPDC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTenantPDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenantPDC.Image = ((System.Drawing.Image)(resources.GetObject("btnTenantPDC.Image")));
            this.btnTenantPDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTenantPDC.Location = new System.Drawing.Point(8, 67);
            this.btnTenantPDC.Name = "btnTenantPDC";
            this.btnTenantPDC.Size = new System.Drawing.Size(303, 52);
            this.btnTenantPDC.TabIndex = 4;
            this.btnTenantPDC.Text = "         Tenant\'s PDC List";
            this.btnTenantPDC.UseVisualStyleBackColor = false;
            this.btnTenantPDC.Click += new System.EventHandler(this.btnTenantPDC_Click);
            // 
            // btnTInv
            // 
            this.btnTInv.BackColor = System.Drawing.Color.Silver;
            this.btnTInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTInv.Image = ((System.Drawing.Image)(resources.GetObject("btnTInv.Image")));
            this.btnTInv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTInv.Location = new System.Drawing.Point(8, 125);
            this.btnTInv.Name = "btnTInv";
            this.btnTInv.Size = new System.Drawing.Size(303, 52);
            this.btnTInv.TabIndex = 3;
            this.btnTInv.Text = "        Tenant\'s Paid Bills";
            this.btnTInv.UseVisualStyleBackColor = false;
            this.btnTInv.Click += new System.EventHandler(this.btnTInv_Click);
            // 
            // btnTbills
            // 
            this.btnTbills.BackColor = System.Drawing.Color.Silver;
            this.btnTbills.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTbills.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTbills.Image = ((System.Drawing.Image)(resources.GetObject("btnTbills.Image")));
            this.btnTbills.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTbills.Location = new System.Drawing.Point(8, 9);
            this.btnTbills.Name = "btnTbills";
            this.btnTbills.Size = new System.Drawing.Size(303, 52);
            this.btnTbills.TabIndex = 2;
            this.btnTbills.Text = "      Tenant\'s Billing";
            this.btnTbills.UseVisualStyleBackColor = false;
            this.btnTbills.Click += new System.EventHandler(this.btnTbills_Click);
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(311, -1);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 6;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // frmTenantTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(332, 276);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTenantTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmTenantTrans_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTenantTrans_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmTenantTrans_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTInv;
        private System.Windows.Forms.Button btnTbills;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Button btnTenantPDC;
        private System.Windows.Forms.Button btnRefund;
    }
}