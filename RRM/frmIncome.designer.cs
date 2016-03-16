namespace QLCF
{
    partial class frmIncome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIncome));
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnpre = new DevComponents.DotNetBar.ButtonX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.lblStatus = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnLamMoi = new DevComponents.DotNetBar.ButtonX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.btnThongKe = new DevComponents.DotNetBar.ButtonX();
            this.cbbThongKe = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.ThongKeCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel6
            // 
            this.groupPanel6.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.buttonX2);
            this.groupPanel6.Controls.Add(this.btnpre);
            this.groupPanel6.Controls.Add(this.btnExport);
            this.groupPanel6.Controls.Add(this.lblStatus);
            this.groupPanel6.Controls.Add(this.labelX1);
            this.groupPanel6.Controls.Add(this.dtpDate);
            this.groupPanel6.Controls.Add(this.btnLamMoi);
            this.groupPanel6.Controls.Add(this.labelX12);
            this.groupPanel6.Controls.Add(this.btnThongKe);
            this.groupPanel6.Controls.Add(this.cbbThongKe);
            this.groupPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel6.Location = new System.Drawing.Point(0, 0);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(960, 111);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel6.TabIndex = 3;
            this.groupPanel6.Text = "Report";
            // 
            // btnpre
            // 
            this.btnpre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnpre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnpre.Enabled = false;
            this.btnpre.Image = ((System.Drawing.Image)(resources.GetObject("btnpre.Image")));
            this.btnpre.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnpre.Location = new System.Drawing.Point(413, 22);
            this.btnpre.Name = "btnpre";
            this.btnpre.Size = new System.Drawing.Size(103, 35);
            this.btnpre.TabIndex = 34;
            this.btnpre.Text = "Preview";
            this.btnpre.Click += new System.EventHandler(this.btnpre_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnExport.Location = new System.Drawing.Point(639, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(114, 35);
            this.btnExport.TabIndex = 33;
            this.btnExport.Text = "Export Excel ";
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location = new System.Drawing.Point(162, 65);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(550, 22);
            this.lblStatus.TabIndex = 32;
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(15, 27);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(51, 22);
            this.labelX1.TabIndex = 32;
            this.labelX1.Text = "Date :";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(72, 31);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(127, 20);
            this.dtpDate.TabIndex = 31;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(833, 22);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(104, 35);
            this.btnLamMoi.TabIndex = 30;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnLamMoi.Visible = false;
            // 
            // labelX12
            // 
            this.labelX12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            this.labelX12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.Location = new System.Drawing.Point(207, 29);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(51, 22);
            this.labelX12.TabIndex = 29;
            this.labelX12.Text = "Select :";
            this.labelX12.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnThongKe
            // 
            this.btnThongKe.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnThongKe.Location = new System.Drawing.Point(522, 22);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(103, 35);
            this.btnThongKe.TabIndex = 25;
            this.btnThongKe.Text = "    Print";
            this.btnThongKe.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cbbThongKe
            // 
            this.cbbThongKe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbThongKe.DisplayMember = "Text";
            this.cbbThongKe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbThongKe.FormattingEnabled = true;
            this.cbbThongKe.ItemHeight = 17;
            this.cbbThongKe.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbbThongKe.Location = new System.Drawing.Point(262, 30);
            this.cbbThongKe.Name = "cbbThongKe";
            this.cbbThongKe.Size = new System.Drawing.Size(121, 23);
            this.cbbThongKe.TabIndex = 21;
            this.cbbThongKe.SelectionChangeCommitted += new System.EventHandler(this.cbbThongKe_SelectionChangeCommitted);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Menu";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "Bill";
            // 
            // ThongKeCrystalReportViewer
            // 
            this.ThongKeCrystalReportViewer.ActiveViewIndex = -1;
            this.ThongKeCrystalReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThongKeCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThongKeCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ThongKeCrystalReportViewer.DisplayStatusBar = false;
            this.ThongKeCrystalReportViewer.Location = new System.Drawing.Point(0, 114);
            this.ThongKeCrystalReportViewer.Name = "ThongKeCrystalReportViewer";
            this.ThongKeCrystalReportViewer.SelectionFormula = "";
            this.ThongKeCrystalReportViewer.Size = new System.Drawing.Size(958, 374);
            this.ThongKeCrystalReportViewer.TabIndex = 2;
            //this.ThongKeCrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ThongKeCrystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonX2.Image = ((System.Drawing.Image)(resources.GetObject("buttonX2.Image")));
            this.buttonX2.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.buttonX2.Location = new System.Drawing.Point(631, 22);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(103, 35);
            this.buttonX2.TabIndex = 73;
            this.buttonX2.Text = "    &Close";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(960, 490);
            this.Controls.Add(this.groupPanel6);
            this.Controls.Add(this.ThongKeCrystalReportViewer);
            this.Name = "frmIncome";
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIncome_Load);
            this.groupPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        private DevComponents.DotNetBar.ButtonX btnLamMoi;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.ButtonX btnThongKe;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbThongKe;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ThongKeCrystalReportViewer;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.ButtonX btnpre;
        private DevComponents.DotNetBar.LabelX lblStatus;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}