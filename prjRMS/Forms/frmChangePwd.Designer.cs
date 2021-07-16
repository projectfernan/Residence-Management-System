namespace prjRMS
{
    partial class frmChangePwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePwd));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.Label();
            this.btnCon = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(3, 4);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(145, 18);
            this.lbTitle.TabIndex = 2668;
            this.lbTitle.Text = "Change Password";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(418, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2669;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.txtOldPass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUid);
            this.panel1.Controls.Add(this.btnCon);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(7, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 168);
            this.panel1.TabIndex = 2667;
            // 
            // txtOldPass
            // 
            this.txtOldPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.Location = new System.Drawing.Point(160, 70);
            this.txtOldPass.MaxLength = 30;
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(247, 24);
            this.txtOldPass.TabIndex = 0;
            this.txtOldPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOldPass_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 5481;
            this.label1.Text = "Old Password :";
            // 
            // txtUid
            // 
            this.txtUid.AutoSize = true;
            this.txtUid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtUid.Location = new System.Drawing.Point(159, 36);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(56, 16);
            this.txtUid.TabIndex = 5474;
            this.txtUid.Text = "Fernan";
            // 
            // btnCon
            // 
            this.btnCon.BackColor = System.Drawing.Color.Silver;
            this.btnCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCon.ForeColor = System.Drawing.Color.Black;
            this.btnCon.Image = ((System.Drawing.Image)(resources.GetObject("btnCon.Image")));
            this.btnCon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCon.Location = new System.Drawing.Point(296, 109);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(111, 36);
            this.btnCon.TabIndex = 5;
            this.btnCon.Text = "Continue";
            this.btnCon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCon.UseVisualStyleBackColor = false;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(67, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 53;
            this.label7.Text = "Username :";
            // 
            // frmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(439, 200);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmChangePwd_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmChangePwd_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmChangePwd_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmChangePwd_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtUid;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label label1;
    }
}