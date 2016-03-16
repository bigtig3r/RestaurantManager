namespace QLCF
{
    partial class frmFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFind));
            this.FinddataGridView = new System.Windows.Forms.DataGridView();
            this.btnIn = new DevComponents.DotNetBar.ButtonX();
            this.btnFind = new DevComponents.DotNetBar.ButtonX();
            this.rdoHoaDon = new System.Windows.Forms.RadioButton();
            this.rdoNgay = new System.Windows.Forms.RadioButton();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPre = new DevComponents.DotNetBar.ButtonX();
            this.InCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblIda = new System.Windows.Forms.Label();
            this.btEdit = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.FinddataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FinddataGridView
            // 
            this.FinddataGridView.AllowUserToAddRows = false;
            this.FinddataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FinddataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FinddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FinddataGridView.Location = new System.Drawing.Point(0, 104);
            this.FinddataGridView.Name = "FinddataGridView";
            this.FinddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FinddataGridView.Size = new System.Drawing.Size(512, 233);
            this.FinddataGridView.TabIndex = 0;
            this.FinddataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FinddataGridView_CellClick);
            this.FinddataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.FinddataGridView_DataBindingComplete);
            // 
            // btnIn
            // 
            this.btnIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Enabled = false;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnIn.Location = new System.Drawing.Point(326, 342);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(90, 38);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "Print";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnFind
            // 
            this.btnFind.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnFind.Location = new System.Drawing.Point(182, 61);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(127, 37);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Search";
            this.btnFind.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // rdoHoaDon
            // 
            this.rdoHoaDon.AutoSize = true;
            this.rdoHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoHoaDon.Location = new System.Drawing.Point(70, 12);
            this.rdoHoaDon.Name = "rdoHoaDon";
            this.rdoHoaDon.Size = new System.Drawing.Size(89, 20);
            this.rdoHoaDon.TabIndex = 3;
            this.rdoHoaDon.TabStop = true;
            this.rdoHoaDon.Text = "Find Bill ID";
            this.rdoHoaDon.UseVisualStyleBackColor = true;
            this.rdoHoaDon.CheckedChanged += new System.EventHandler(this.rdoHoaDon_CheckedChanged);
            // 
            // rdoNgay
            // 
            this.rdoNgay.AutoSize = true;
            this.rdoNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNgay.Location = new System.Drawing.Point(70, 35);
            this.rdoNgay.Name = "rdoNgay";
            this.rdoNgay.Size = new System.Drawing.Size(101, 20);
            this.rdoNgay.TabIndex = 4;
            this.rdoNgay.TabStop = true;
            this.rdoNgay.Text = "Find Bill Day";
            this.rdoNgay.UseVisualStyleBackColor = true;
            this.rdoNgay.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(182, 11);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(127, 20);
            this.txtMaHD.TabIndex = 5;
            this.txtMaHD.Visible = false;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(182, 37);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(127, 20);
            this.dtpDate.TabIndex = 6;
            this.dtpDate.Visible = false;
            // 
            // btnPre
            // 
            this.btnPre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPre.Enabled = false;
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnPre.Location = new System.Drawing.Point(230, 342);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(90, 38);
            this.btnPre.TabIndex = 7;
            this.btnPre.Text = "Preview";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // InCrystalReportViewer
            // 
            this.InCrystalReportViewer.ActiveViewIndex = -1;
            this.InCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.InCrystalReportViewer.Location = new System.Drawing.Point(13, 361);
            this.InCrystalReportViewer.Name = "InCrystalReportViewer";
            this.InCrystalReportViewer.SelectionFormula = "";
            this.InCrystalReportViewer.Size = new System.Drawing.Size(18, 19);
            this.InCrystalReportViewer.TabIndex = 8;
            this.InCrystalReportViewer.ViewTimeSelectionFormula = "";
            this.InCrystalReportViewer.Visible = false;
            // 
            // lblIda
            // 
            this.lblIda.AutoSize = true;
            this.lblIda.Location = new System.Drawing.Point(309, 14);
            this.lblIda.Name = "lblIda";
            this.lblIda.Size = new System.Drawing.Size(50, 13);
            this.lblIda.TabIndex = 9;
            this.lblIda.Text = "(in today)";
            this.lblIda.Visible = false;
            // 
            // btEdit
            // 
            this.btEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = ((System.Drawing.Image)(resources.GetObject("btEdit.Image")));
            this.btEdit.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btEdit.Location = new System.Drawing.Point(134, 342);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(90, 38);
            this.btEdit.TabIndex = 7;
            this.btEdit.Text = "Edit";
            this.btEdit.Visible = false;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.Image = ((System.Drawing.Image)(resources.GetObject("buttonX2.Image")));
            this.buttonX2.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.buttonX2.Location = new System.Drawing.Point(422, 342);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(90, 38);
            this.buttonX2.TabIndex = 73;
            this.buttonX2.Text = "    &Close";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(515, 381);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.lblIda);
            this.Controls.Add(this.InCrystalReportViewer);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.rdoNgay);
            this.Controls.Add(this.rdoHoaDon);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.FinddataGridView);
            this.Name = "frmFind";
            this.Text = "Find Bill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FinddataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView FinddataGridView;
        private DevComponents.DotNetBar.ButtonX btnIn;
        private DevComponents.DotNetBar.ButtonX btnFind;
        private System.Windows.Forms.RadioButton rdoHoaDon;
        private System.Windows.Forms.RadioButton rdoNgay;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private DevComponents.DotNetBar.ButtonX btnPre;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer InCrystalReportViewer;
        private System.Windows.Forms.Label lblIda;
        private DevComponents.DotNetBar.ButtonX btEdit;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}