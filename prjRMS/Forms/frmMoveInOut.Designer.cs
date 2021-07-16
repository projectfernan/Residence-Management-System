namespace prjRMS
{
    partial class frmMoveInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoveInOut));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContractRem = new System.Windows.Forms.Button();
            this.btnReservedRem = new System.Windows.Forms.Button();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Move In / Move Out";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnContractRem);
            this.panel1.Controls.Add(this.btnReservedRem);
            this.panel1.Location = new System.Drawing.Point(6, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 126);
            this.panel1.TabIndex = 7;
            // 
            // btnContractRem
            // 
            this.btnContractRem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContractRem.BackColor = System.Drawing.Color.Silver;
            this.btnContractRem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContractRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContractRem.Image = ((System.Drawing.Image)(resources.GetObject("btnContractRem.Image")));
            this.btnContractRem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContractRem.Location = new System.Drawing.Point(8, 66);
            this.btnContractRem.Name = "btnContractRem";
            this.btnContractRem.Size = new System.Drawing.Size(302, 52);
            this.btnContractRem.TabIndex = 3;
            this.btnContractRem.Text = "      Move Out";
            this.btnContractRem.UseVisualStyleBackColor = false;
            this.btnContractRem.Click += new System.EventHandler(this.btnContractRem_Click);
            // 
            // btnReservedRem
            // 
            this.btnReservedRem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReservedRem.BackColor = System.Drawing.Color.Silver;
            this.btnReservedRem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservedRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservedRem.Image = ((System.Drawing.Image)(resources.GetObject("btnReservedRem.Image")));
            this.btnReservedRem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservedRem.Location = new System.Drawing.Point(8, 8);
            this.btnReservedRem.Name = "btnReservedRem";
            this.btnReservedRem.Size = new System.Drawing.Size(302, 52);
            this.btnReservedRem.TabIndex = 2;
            this.btnReservedRem.Text = "     Move In";
            this.btnReservedRem.UseVisualStyleBackColor = false;
            this.btnReservedRem.Click += new System.EventHandler(this.btnReservedRem_Click);
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(310, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 6;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // frmMoveInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(330, 158);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMoveInOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMoveInOut_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMoveInOut_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMoveInOut_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnContractRem;
        private System.Windows.Forms.Button btnReservedRem;
        private System.Windows.Forms.Label lbClose;
    }
}