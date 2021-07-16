namespace prjRMS
{
    partial class frmResReminders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResReminders));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtLeftDays = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalDays = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDays)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Set Reserved Expiration Reminder";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.txtLeftDays);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTotalDays);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(7, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 136);
            this.panel1.TabIndex = 7;
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Silver;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.ForeColor = System.Drawing.Color.Black;
            this.btnSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.Image")));
            this.btnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSet.Location = new System.Drawing.Point(224, 86);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(77, 36);
            this.btnSet.TabIndex = 7;
            this.btnSet.Text = "Set";
            this.btnSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtLeftDays
            // 
            this.txtLeftDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftDays.Location = new System.Drawing.Point(188, 53);
            this.txtLeftDays.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtLeftDays.Name = "txtLeftDays";
            this.txtLeftDays.Size = new System.Drawing.Size(113, 24);
            this.txtLeftDays.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Alert Remainding Days :";
            // 
            // txtTotalDays
            // 
            this.txtTotalDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDays.Location = new System.Drawing.Point(188, 14);
            this.txtTotalDays.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtTotalDays.Name = "txtTotalDays";
            this.txtTotalDays.Size = new System.Drawing.Size(113, 24);
            this.txtTotalDays.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Reserved Days :";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(307, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 6;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // frmResReminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(328, 168);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmResReminders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmResReminders_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmResReminders_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmResReminders_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmResReminders_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.NumericUpDown txtLeftDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtTotalDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSet;
    }
}