namespace prjRMS
{
    partial class frmTenantCont
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTenantCont));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstTcr = new System.Windows.Forms.ListView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnEditCont = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRenew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExtendCont = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdjust = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelCont = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnContFind = new System.Windows.Forms.ToolStripButton();
            this.txtContKeyCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cboContCateg = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportEx = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnContRef = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstTpi = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddContract = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.txtKeycode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cboCateg = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClose = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(7, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 700);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(10, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1145, 341);
            this.groupBox2.TabIndex = 2656;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tenant\'s Contract Records";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.lstTcr);
            this.panel3.Controls.Add(this.toolStrip2);
            this.panel3.Location = new System.Drawing.Point(6, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1133, 313);
            this.panel3.TabIndex = 2655;
            // 
            // lstTcr
            // 
            this.lstTcr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTcr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstTcr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTcr.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTcr.FullRowSelect = true;
            this.lstTcr.GridLines = true;
            this.lstTcr.Location = new System.Drawing.Point(7, 42);
            this.lstTcr.MultiSelect = false;
            this.lstTcr.Name = "lstTcr";
            this.lstTcr.Size = new System.Drawing.Size(1118, 263);
            this.lstTcr.TabIndex = 5465;
            this.lstTcr.UseCompatibleStateImageBehavior = false;
            this.lstTcr.View = System.Windows.Forms.View.Details;
            this.lstTcr.SelectedIndexChanged += new System.EventHandler(this.lstTcr_SelectedIndexChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditCont,
            this.toolStripSeparator10,
            this.btnRenew,
            this.toolStripSeparator1,
            this.btnExtendCont,
            this.toolStripSeparator6,
            this.btnAdjust,
            this.toolStripSeparator3,
            this.btnCancelCont,
            this.toolStripSeparator7,
            this.btnContFind,
            this.txtContKeyCode,
            this.toolStripLabel4,
            this.cboContCateg,
            this.toolStripLabel5,
            this.btnPrint,
            this.toolStripSeparator9,
            this.btnExportEx,
            this.toolStripSeparator5,
            this.btnContRef});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1133, 36);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnEditCont
            // 
            this.btnEditCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditCont.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCont.ForeColor = System.Drawing.Color.White;
            this.btnEditCont.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCont.Image")));
            this.btnEditCont.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditCont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditCont.Name = "btnEditCont";
            this.btnEditCont.Size = new System.Drawing.Size(63, 33);
            this.btnEditCont.Text = "Edit";
            this.btnEditCont.Click += new System.EventHandler(this.btnEditCont_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 36);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRenew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.ForeColor = System.Drawing.Color.White;
            this.btnRenew.Image = ((System.Drawing.Image)(resources.GetObject("btnRenew.Image")));
            this.btnRenew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRenew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(79, 33);
            this.btnRenew.Text = "Renew";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // btnExtendCont
            // 
            this.btnExtendCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExtendCont.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtendCont.ForeColor = System.Drawing.Color.White;
            this.btnExtendCont.Image = ((System.Drawing.Image)(resources.GetObject("btnExtendCont.Image")));
            this.btnExtendCont.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExtendCont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExtendCont.Name = "btnExtendCont";
            this.btnExtendCont.Size = new System.Drawing.Size(80, 33);
            this.btnExtendCont.Text = "Extend";
            this.btnExtendCont.Click += new System.EventHandler(this.btnExtendCont_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 36);
            // 
            // btnAdjust
            // 
            this.btnAdjust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdjust.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjust.ForeColor = System.Drawing.Color.White;
            this.btnAdjust.Image = ((System.Drawing.Image)(resources.GetObject("btnAdjust.Image")));
            this.btnAdjust.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdjust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(106, 33);
            this.btnAdjust.Text = "Adjustment";
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
            // 
            // btnCancelCont
            // 
            this.btnCancelCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelCont.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelCont.ForeColor = System.Drawing.Color.White;
            this.btnCancelCont.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelCont.Image")));
            this.btnCancelCont.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancelCont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelCont.Name = "btnCancelCont";
            this.btnCancelCont.Size = new System.Drawing.Size(79, 33);
            this.btnCancelCont.Text = "Cancel";
            this.btnCancelCont.Click += new System.EventHandler(this.btnCancelCont_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 36);
            // 
            // btnContFind
            // 
            this.btnContFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnContFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnContFind.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContFind.ForeColor = System.Drawing.Color.White;
            this.btnContFind.Image = ((System.Drawing.Image)(resources.GetObject("btnContFind.Image")));
            this.btnContFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnContFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContFind.Name = "btnContFind";
            this.btnContFind.Size = new System.Drawing.Size(80, 33);
            this.btnContFind.Text = "Search";
            this.btnContFind.Click += new System.EventHandler(this.btnContFind_Click);
            // 
            // txtContKeyCode
            // 
            this.txtContKeyCode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtContKeyCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContKeyCode.ForeColor = System.Drawing.Color.Black;
            this.txtContKeyCode.Name = "txtContKeyCode";
            this.txtContKeyCode.Size = new System.Drawing.Size(100, 36);
            this.txtContKeyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContKeyCode_KeyDown);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(65, 33);
            this.toolStripLabel4.Text = "Keycode :";
            // 
            // cboContCateg
            // 
            this.cboContCateg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboContCateg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboContCateg.Items.AddRange(new object[] {
            "ContractName",
            "ContractType",
            "ContractStatus",
            "DateCreated",
            "StartDate",
            "EndDate",
            "MoveInDate",
            "MoveOutDate"});
            this.cboContCateg.Name = "cboContCateg";
            this.cboContCateg.Size = new System.Drawing.Size(110, 36);
            this.cboContCateg.Text = "ContractName";
            this.cboContCateg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboContCateg_KeyPress);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel5.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(68, 33);
            this.toolStripLabel5.Text = "Category :";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(67, 33);
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 36);
            // 
            // btnExportEx
            // 
            this.btnExportEx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExportEx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportEx.ForeColor = System.Drawing.Color.White;
            this.btnExportEx.Image = ((System.Drawing.Image)(resources.GetObject("btnExportEx.Image")));
            this.btnExportEx.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportEx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportEx.Name = "btnExportEx";
            this.btnExportEx.Size = new System.Drawing.Size(79, 33);
            this.btnExportEx.Text = "Export";
            this.btnExportEx.Click += new System.EventHandler(this.btnExportEx_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 36);
            // 
            // btnContRef
            // 
            this.btnContRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnContRef.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContRef.ForeColor = System.Drawing.Color.White;
            this.btnContRef.Image = ((System.Drawing.Image)(resources.GetObject("btnContRef.Image")));
            this.btnContRef.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnContRef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContRef.Name = "btnContRef";
            this.btnContRef.Size = new System.Drawing.Size(80, 33);
            this.btnContRef.Text = "Refresh";
            this.btnContRef.Click += new System.EventHandler(this.btnContRef_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1145, 341);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tenant\'s Personal Information";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.lstTpi);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Location = new System.Drawing.Point(6, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1133, 313);
            this.panel2.TabIndex = 2655;
            // 
            // lstTpi
            // 
            this.lstTpi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstTpi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTpi.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTpi.FullRowSelect = true;
            this.lstTpi.GridLines = true;
            this.lstTpi.Location = new System.Drawing.Point(7, 42);
            this.lstTpi.MultiSelect = false;
            this.lstTpi.Name = "lstTpi";
            this.lstTpi.Size = new System.Drawing.Size(1119, 264);
            this.lstTpi.TabIndex = 5465;
            this.lstTpi.UseCompatibleStateImageBehavior = false;
            this.lstTpi.View = System.Windows.Forms.View.Details;
            this.lstTpi.SelectedIndexChanged += new System.EventHandler(this.lstTpi_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddContract,
            this.toolStripSeparator4,
            this.btnEdit,
            this.toolStripSeparator2,
            this.btnSearch,
            this.txtKeycode,
            this.toolStripLabel2,
            this.cboCateg,
            this.toolStripLabel1,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1133, 36);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddContract
            // 
            this.btnAddContract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddContract.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContract.ForeColor = System.Drawing.Color.White;
            this.btnAddContract.Image = ((System.Drawing.Image)(resources.GetObject("btnAddContract.Image")));
            this.btnAddContract.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddContract.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddContract.Name = "btnAddContract";
            this.btnAddContract.Size = new System.Drawing.Size(132, 33);
            this.btnAddContract.Text = "Create Contract";
            this.btnAddContract.Click += new System.EventHandler(this.btnAddContract_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 36);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 33);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeycode
            // 
            this.txtKeycode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtKeycode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeycode.ForeColor = System.Drawing.Color.Black;
            this.txtKeycode.Name = "txtKeycode";
            this.txtKeycode.Size = new System.Drawing.Size(100, 36);
            this.txtKeycode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeycode_KeyDown);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(65, 33);
            this.toolStripLabel2.Text = "Keycode :";
            // 
            // cboCateg
            // 
            this.cboCateg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboCateg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCateg.Items.AddRange(new object[] {
            "Name",
            "NickName",
            "Gender",
            "BirthDate",
            "ContactNo",
            "GuardianNo",
            "School",
            "YearLevel",
            "Course"});
            this.cboCateg.Name = "cboCateg";
            this.cboCateg.Size = new System.Drawing.Size(110, 36);
            this.cboCateg.Text = "Name";
            this.cboCateg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCateg_KeyPress);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 33);
            this.toolStripLabel1.Text = "Category :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(2, 2);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(198, 18);
            this.lbTitle.TabIndex = 2652;
            this.lbTitle.Text = "Tenant Contract Records";
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(1157, -1);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 22);
            this.lbClose.TabIndex = 2653;
            this.lbClose.Text = "x";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // frmTenantCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1178, 731);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTenantCont";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTenantCont_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmTenantCont_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTenantCont_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmTenantCont_MouseUp);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lstTpi;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtKeycode;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cboCateg;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lstTcr;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnExtendCont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnCancelCont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnContFind;
        private System.Windows.Forms.ToolStripTextBox txtContKeyCode;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cboContCateg;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripButton btnContRef;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnRenew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddContract;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnEditCont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnExportEx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.ToolStripButton btnAdjust;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}