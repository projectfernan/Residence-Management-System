namespace prjRMS
{
    partial class frmSysAccMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysAccMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSysAcc = new System.Windows.Forms.Button();
            this.btnDesig = new System.Windows.Forms.Button();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "System Account Settings";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnSysAcc);
            this.panel1.Controls.Add(this.btnDesig);
            this.panel1.Location = new System.Drawing.Point(6, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 128);
            this.panel1.TabIndex = 10;
            // 
            // btnSysAcc
            // 
            this.btnSysAcc.BackColor = System.Drawing.Color.Silver;
            this.btnSysAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSysAcc.Image = ((System.Drawing.Image)(resources.GetObject("btnSysAcc.Image")));
            this.btnSysAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSysAcc.Location = new System.Drawing.Point(8, 67);
            this.btnSysAcc.Name = "btnSysAcc";
            this.btnSysAcc.Size = new System.Drawing.Size(304, 52);
            this.btnSysAcc.TabIndex = 4;
            this.btnSysAcc.Text = "         System Accounts";
            this.btnSysAcc.UseVisualStyleBackColor = false;
            this.btnSysAcc.Click += new System.EventHandler(this.btnSysAcc_Click);
            // 
            // btnDesig
            // 
            this.btnDesig.BackColor = System.Drawing.Color.Silver;
            this.btnDesig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesig.Image = ((System.Drawing.Image)(resources.GetObject("btnDesig.Image")));
            this.btnDesig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesig.Location = new System.Drawing.Point(8, 9);
            this.btnDesig.Name = "btnDesig";
            this.btnDesig.Size = new System.Drawing.Size(304, 52);
            this.btnDesig.TabIndex = 2;
            this.btnDesig.Text = "         Designation Settings";
            this.btnDesig.UseVisualStyleBackColor = false;
            this.btnDesig.Click += new System.EventHandler(this.btnDesig_Click);
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(312, -1);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 9;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // frmSysAccMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(332, 158);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSysAccMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSysAccMenu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSysAccMenu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmSysAccMenu_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSysAcc;
        private System.Windows.Forms.Button btnDesig;
        private System.Windows.Forms.Label lbClose;
    }
}