namespace prjRMS
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAuditLogs = new System.Windows.Forms.Button();
            this.btnBedReq = new System.Windows.Forms.Button();
            this.btnSysAcc = new System.Windows.Forms.Button();
            this.btnFloorPlan = new System.Windows.Forms.Button();
            this.btnPenalty = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnIdType = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(312, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 0;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnAuditLogs);
            this.panel1.Controls.Add(this.btnBedReq);
            this.panel1.Controls.Add(this.btnSysAcc);
            this.panel1.Controls.Add(this.btnFloorPlan);
            this.panel1.Controls.Add(this.btnPenalty);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnIdType);
            this.panel1.Controls.Add(this.btnRooms);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Location = new System.Drawing.Point(8, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 589);
            this.panel1.TabIndex = 1;
            // 
            // btnAuditLogs
            // 
            this.btnAuditLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuditLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAuditLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditLogs.Image = ((System.Drawing.Image)(resources.GetObject("btnAuditLogs.Image")));
            this.btnAuditLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditLogs.Location = new System.Drawing.Point(7, 529);
            this.btnAuditLogs.Name = "btnAuditLogs";
            this.btnAuditLogs.Size = new System.Drawing.Size(302, 52);
            this.btnAuditLogs.TabIndex = 10;
            this.btnAuditLogs.Text = "         System Audit Logs";
            this.btnAuditLogs.UseVisualStyleBackColor = false;
            this.btnAuditLogs.Click += new System.EventHandler(this.btnAuditLogs_Click);
            // 
            // btnBedReq
            // 
            this.btnBedReq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBedReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBedReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBedReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBedReq.Image = ((System.Drawing.Image)(resources.GetObject("btnBedReq.Image")));
            this.btnBedReq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBedReq.Location = new System.Drawing.Point(7, 471);
            this.btnBedReq.Name = "btnBedReq";
            this.btnBedReq.Size = new System.Drawing.Size(302, 52);
            this.btnBedReq.TabIndex = 9;
            this.btnBedReq.Text = "          Bed Request Delay";
            this.btnBedReq.UseVisualStyleBackColor = false;
            this.btnBedReq.Click += new System.EventHandler(this.btnBedReq_Click);
            // 
            // btnSysAcc
            // 
            this.btnSysAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSysAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSysAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSysAcc.Image = ((System.Drawing.Image)(resources.GetObject("btnSysAcc.Image")));
            this.btnSysAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSysAcc.Location = new System.Drawing.Point(7, 65);
            this.btnSysAcc.Name = "btnSysAcc";
            this.btnSysAcc.Size = new System.Drawing.Size(302, 52);
            this.btnSysAcc.TabIndex = 8;
            this.btnSysAcc.Text = "          System Account Settings";
            this.btnSysAcc.UseVisualStyleBackColor = false;
            this.btnSysAcc.Click += new System.EventHandler(this.btnSysAcc_Click);
            // 
            // btnFloorPlan
            // 
            this.btnFloorPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFloorPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFloorPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloorPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFloorPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnFloorPlan.Image")));
            this.btnFloorPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFloorPlan.Location = new System.Drawing.Point(7, 413);
            this.btnFloorPlan.Name = "btnFloorPlan";
            this.btnFloorPlan.Size = new System.Drawing.Size(302, 52);
            this.btnFloorPlan.TabIndex = 7;
            this.btnFloorPlan.Text = "        Room Floor Plan Path";
            this.btnFloorPlan.UseVisualStyleBackColor = false;
            this.btnFloorPlan.Click += new System.EventHandler(this.btnFloorPlan_Click);
            // 
            // btnPenalty
            // 
            this.btnPenalty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPenalty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPenalty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPenalty.Image = ((System.Drawing.Image)(resources.GetObject("btnPenalty.Image")));
            this.btnPenalty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPenalty.Location = new System.Drawing.Point(7, 355);
            this.btnPenalty.Name = "btnPenalty";
            this.btnPenalty.Size = new System.Drawing.Size(302, 52);
            this.btnPenalty.TabIndex = 6;
            this.btnPenalty.Text = "       Penalty Settings";
            this.btnPenalty.UseVisualStyleBackColor = false;
            this.btnPenalty.Click += new System.EventHandler(this.btnPenalty_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(7, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(302, 52);
            this.button2.TabIndex = 5;
            this.button2.Text = "         Dashboard Reminders";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnIdType
            // 
            this.btnIdType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIdType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnIdType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdType.Image = ((System.Drawing.Image)(resources.GetObject("btnIdType.Image")));
            this.btnIdType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIdType.Location = new System.Drawing.Point(7, 239);
            this.btnIdType.Name = "btnIdType";
            this.btnIdType.Size = new System.Drawing.Size(302, 52);
            this.btnIdType.TabIndex = 4;
            this.btnIdType.Text = "       ID Type Settings";
            this.btnIdType.UseVisualStyleBackColor = false;
            this.btnIdType.Click += new System.EventHandler(this.btnIdType_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRooms.Image = ((System.Drawing.Image)(resources.GetObject("btnRooms.Image")));
            this.btnRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRooms.Location = new System.Drawing.Point(7, 181);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(302, 52);
            this.btnRooms.TabIndex = 3;
            this.btnRooms.Text = "      Room Settings";
            this.btnRooms.UseVisualStyleBackColor = false;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(7, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "      Contract Settings";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(7, 7);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(302, 52);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "       Server Connection";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(332, 623);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSettings_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSettings_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmSettings_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnIdType;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPenalty;
        private System.Windows.Forms.Button btnFloorPlan;
        private System.Windows.Forms.Button btnSysAcc;
        private System.Windows.Forms.Button btnBedReq;
        private System.Windows.Forms.Button btnAuditLogs;
    }
}