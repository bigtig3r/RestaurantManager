namespace QLCF
{
    partial class frmHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDon));
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnCapNhatBan = new DevComponents.DotNetBar.ButtonX();
            this.btnTinhTien = new DevComponents.DotNetBar.ButtonX();
            this.cbbHoaDonBan = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.HoaDonCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel5
            // 
            this.groupPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.pictureBox4);
            this.groupPanel5.Controls.Add(this.labelX2);
            this.groupPanel5.Controls.Add(this.btnCapNhatBan);
            this.groupPanel5.Controls.Add(this.btnTinhTien);
            this.groupPanel5.Controls.Add(this.cbbHoaDonBan);
            this.groupPanel5.Location = new System.Drawing.Point(0, 0);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(950, 108);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel5.TabIndex = 3;
            this.groupPanel5.Text = "Hoá Đơn Tính Tiền";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(796, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(125, 78);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(16, 13);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(137, 19);
            this.labelX2.TabIndex = 15;
            this.labelX2.Text = "Chọn Bàn";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCapNhatBan
            // 
            this.btnCapNhatBan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCapNhatBan.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhatBan.Image")));
            this.btnCapNhatBan.Location = new System.Drawing.Point(298, 34);
            this.btnCapNhatBan.Name = "btnCapNhatBan";
            this.btnCapNhatBan.Size = new System.Drawing.Size(101, 31);
            this.btnCapNhatBan.TabIndex = 14;
            this.btnCapNhatBan.Text = "Cập Nhật";
            this.btnCapNhatBan.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCapNhatBan.Click += new System.EventHandler(this.btnCapNhatBan_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTinhTien.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhTien.Image")));
            this.btnTinhTien.Location = new System.Drawing.Point(185, 34);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(94, 31);
            this.btnTinhTien.TabIndex = 13;
            this.btnTinhTien.Text = "Tính Tiền";
            this.btnTinhTien.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // cbbHoaDonBan
            // 
            this.cbbHoaDonBan.DisplayMember = "Text";
            this.cbbHoaDonBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbHoaDonBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbHoaDonBan.FormattingEnabled = true;
            this.cbbHoaDonBan.ItemHeight = 17;
            this.cbbHoaDonBan.Location = new System.Drawing.Point(16, 38);
            this.cbbHoaDonBan.Name = "cbbHoaDonBan";
            this.cbbHoaDonBan.Size = new System.Drawing.Size(137, 23);
            this.cbbHoaDonBan.TabIndex = 12;
            this.cbbHoaDonBan.TextChanged += new System.EventHandler(this.cbbHoaDonBan_TextChanged);
            // 
            // HoaDonCrystalReportViewer
            // 
            this.HoaDonCrystalReportViewer.ActiveViewIndex = -1;
            this.HoaDonCrystalReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HoaDonCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HoaDonCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.HoaDonCrystalReportViewer.DisplayStatusBar = false;
            this.HoaDonCrystalReportViewer.Location = new System.Drawing.Point(0, 109);
            this.HoaDonCrystalReportViewer.Name = "HoaDonCrystalReportViewer";
            this.HoaDonCrystalReportViewer.SelectionFormula = "";
            this.HoaDonCrystalReportViewer.Size = new System.Drawing.Size(950, 373);
            this.HoaDonCrystalReportViewer.TabIndex = 2;
            //this.HoaDonCrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.HoaDonCrystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(950, 482);
            this.Controls.Add(this.groupPanel5);
            this.Controls.Add(this.HoaDonCrystalReportViewer);
            this.Name = "frmHoaDon";
            this.Text = "Xuất hóa đơn";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.groupPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnCapNhatBan;
        private DevComponents.DotNetBar.ButtonX btnTinhTien;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbHoaDonBan;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer HoaDonCrystalReportViewer;
    }
}