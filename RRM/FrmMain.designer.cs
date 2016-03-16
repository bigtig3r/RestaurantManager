namespace QLCF
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel4 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnNhapHoaDon = new DevComponents.DotNetBar.ButtonItem();
            this.btScreen = new DevComponents.DotNetBar.ButtonItem();
            this.btnDoiBan = new DevComponents.DotNetBar.ButtonItem();
            this.btnMerge = new DevComponents.DotNetBar.ButtonItem();
            this.bnFind = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btDMBan = new DevComponents.DotNetBar.ButtonItem();
            this.btThucDon = new DevComponents.DotNetBar.ButtonItem();
            this.btnMenuType = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel3 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.btnDoanhThu = new DevComponents.DotNetBar.ButtonItem();
            this.btExport = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem4 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem2 = new DevComponents.DotNetBar.RibbonTabItem();
            this.tabReport = new DevComponents.DotNetBar.RibbonTabItem();
            this.office2007StartButton1 = new DevComponents.DotNetBar.Office2007StartButton();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.btTaiKhoan = new DevComponents.DotNetBar.ButtonItem();
            this.btDangXuat = new DevComponents.DotNetBar.ButtonItem();
            this.btTroGiup = new DevComponents.DotNetBar.ButtonItem();
            this.btnThoat = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel4.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.ribbonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel4);
            this.ribbonControl1.Controls.Add(this.ribbonPanel2);
            this.ribbonControl1.Controls.Add(this.ribbonPanel3);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem4,
            this.ribbonTabItem2,
            this.tabReport});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.office2007StartButton1,
            this.buttonItem1,
            this.qatCustomizeItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(1008, 186);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 0;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel4.Controls.Add(this.ribbonBar1);
            this.ribbonPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel4.Location = new System.Drawing.Point(0, 57);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel4.Size = new System.Drawing.Size(1008, 127);
            this.ribbonPanel4.TabIndex = 4;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNhapHoaDon,
            this.btScreen,
            this.btnDoiBan,
            this.btnMerge,
            this.bnFind});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1002, 124);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar1.TabIndex = 0;
            // 
            // btnNhapHoaDon
            // 
            this.btnNhapHoaDon.Image = global::QLCF.Properties.Resources.menu_editor;
            this.btnNhapHoaDon.ImagePaddingHorizontal = 8;
            this.btnNhapHoaDon.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNhapHoaDon.Name = "btnNhapHoaDon";
            this.btnNhapHoaDon.Text = "Input Menu";
            this.btnNhapHoaDon.Visible = false;
            this.btnNhapHoaDon.Click += new System.EventHandler(this.btnNhapHoaDon_Click);
            // 
            // btScreen
            // 
            this.btScreen.Image = global::QLCF.Properties.Resources.furoisu_bath_chair;
            this.btScreen.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btScreen.ImagePaddingHorizontal = 8;
            this.btScreen.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btScreen.Name = "btScreen";
            this.btScreen.Text = "Table Manager";
            this.btScreen.Click += new System.EventHandler(this.btScreen_Click);
            // 
            // btnDoiBan
            // 
            this.btnDoiBan.Image = global::QLCF.Properties.Resources.change;
            this.btnDoiBan.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnDoiBan.ImagePaddingHorizontal = 8;
            this.btnDoiBan.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDoiBan.Name = "btnDoiBan";
            this.btnDoiBan.Text = "Change Table";
            this.btnDoiBan.Click += new System.EventHandler(this.btnDoiBan_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Image = global::QLCF.Properties.Resources.add2;
            this.btnMerge.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnMerge.ImagePaddingHorizontal = 8;
            this.btnMerge.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Text = "Merge Table";
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // bnFind
            // 
            this.bnFind.Image = global::QLCF.Properties.Resources.edit_find;
            this.bnFind.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.bnFind.ImagePaddingHorizontal = 8;
            this.bnFind.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.bnFind.Name = "bnFind";
            this.bnFind.Text = "Find Bill";
            this.bnFind.Click += new System.EventHandler(this.bnFind_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel2.Controls.Add(this.ribbonBar3);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 57);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(1008, 127);
            this.ribbonPanel2.TabIndex = 2;
            this.ribbonPanel2.Visible = false;
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btDMBan,
            this.btThucDon,
            this.btnMenuType});
            this.ribbonBar3.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(1002, 124);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar3.TabIndex = 0;
            // 
            // btDMBan
            // 
            this.btDMBan.Image = global::QLCF.Properties.Resources.furoisu_bath_chair;
            this.btDMBan.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btDMBan.ImagePaddingHorizontal = 8;
            this.btDMBan.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btDMBan.Name = "btDMBan";
            this.btDMBan.Text = "Table";
            this.btDMBan.Click += new System.EventHandler(this.btDMBan_Click);
            // 
            // btThucDon
            // 
            this.btThucDon.Image = global::QLCF.Properties.Resources.clip_300x300;
            this.btThucDon.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btThucDon.ImagePaddingHorizontal = 8;
            this.btThucDon.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btThucDon.Name = "btThucDon";
            this.btThucDon.Text = "Menu";
            this.btThucDon.Click += new System.EventHandler(this.btThucDon_Click);
            // 
            // btnMenuType
            // 
            this.btnMenuType.Image = global::QLCF.Properties.Resources.type_list;
            this.btnMenuType.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnMenuType.ImagePaddingHorizontal = 8;
            this.btnMenuType.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuType.Name = "btnMenuType";
            this.btnMenuType.Text = "Menu Type";
            this.btnMenuType.Click += new System.EventHandler(this.btnMenuType_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel3.Controls.Add(this.ribbonBar4);
            this.ribbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel3.Location = new System.Drawing.Point(0, 57);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel3.Size = new System.Drawing.Size(1008, 127);
            this.ribbonPanel3.TabIndex = 3;
            this.ribbonPanel3.Visible = false;
            // 
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDoanhThu,
            this.btExport});
            this.ribbonBar4.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(1002, 124);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar4.TabIndex = 0;
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Image = global::QLCF.Properties.Resources.report;
            this.btnDoanhThu.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnDoanhThu.ImagePaddingHorizontal = 8;
            this.btnDoanhThu.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Text = "Income";
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // btExport
            // 
            this.btExport.Image = global::QLCF.Properties.Resources.excel;
            this.btExport.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btExport.ImagePaddingHorizontal = 8;
            this.btExport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btExport.Name = "btExport";
            this.btExport.Text = "Daily Report";
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // ribbonTabItem4
            // 
            this.ribbonTabItem4.Checked = true;
            this.ribbonTabItem4.ImagePaddingHorizontal = 8;
            this.ribbonTabItem4.Name = "ribbonTabItem4";
            this.ribbonTabItem4.Panel = this.ribbonPanel4;
            this.ribbonTabItem4.Text = "Bill";
            // 
            // ribbonTabItem2
            // 
            this.ribbonTabItem2.ImagePaddingHorizontal = 8;
            this.ribbonTabItem2.Name = "ribbonTabItem2";
            this.ribbonTabItem2.Panel = this.ribbonPanel2;
            this.ribbonTabItem2.Text = "List";
            // 
            // tabReport
            // 
            this.tabReport.ImagePaddingHorizontal = 8;
            this.tabReport.Name = "tabReport";
            this.tabReport.Panel = this.ribbonPanel3;
            this.tabReport.Text = "Report";
            // 
            // office2007StartButton1
            // 
            this.office2007StartButton1.AutoExpandOnClick = true;
            this.office2007StartButton1.CanCustomize = false;
            this.office2007StartButton1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.office2007StartButton1.Image = global::QLCF.Properties.Resources.logo;
            this.office2007StartButton1.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.office2007StartButton1.ImagePaddingHorizontal = 2;
            this.office2007StartButton1.ImagePaddingVertical = 2;
            this.office2007StartButton1.Name = "office2007StartButton1";
            this.office2007StartButton1.ShowSubItems = false;
            this.office2007StartButton1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.office2007StartButton1.Text = "&File";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.Class = "RibbonFileMenuContainer";
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(0, 0);
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2});
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.itemContainer2.ItemSpacing = 0;
            this.itemContainer2.MinimumSize = new System.Drawing.Size(0, 0);
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3});
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer";
            this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer3.MinimumSize = new System.Drawing.Size(120, 0);
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btTaiKhoan,
            this.btDangXuat,
            this.btTroGiup,
            this.btnThoat});
            // 
            // btTaiKhoan
            // 
            this.btTaiKhoan.BeginGroup = true;
            this.btTaiKhoan.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btTaiKhoan.FontBold = true;
            this.btTaiKhoan.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btTaiKhoan.ImagePaddingHorizontal = 8;
            this.btTaiKhoan.Name = "btTaiKhoan";
            this.btTaiKhoan.SubItemsExpandWidth = 24;
            this.btTaiKhoan.Text = " &Account";
            this.btTaiKhoan.Click += new System.EventHandler(this.btTaiKhoan_Click);
            // 
            // btDangXuat
            // 
            this.btDangXuat.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btDangXuat.FontBold = true;
            this.btDangXuat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btDangXuat.ImagePaddingHorizontal = 8;
            this.btDangXuat.Name = "btDangXuat";
            this.btDangXuat.SubItemsExpandWidth = 24;
            this.btDangXuat.Text = " &Logoff";
            this.btDangXuat.Click += new System.EventHandler(this.btDangXuat_Click);
            // 
            // btTroGiup
            // 
            this.btTroGiup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btTroGiup.FontBold = true;
            this.btTroGiup.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btTroGiup.ImagePaddingHorizontal = 8;
            this.btTroGiup.Name = "btTroGiup";
            this.btTroGiup.SubItemsExpandWidth = 24;
            this.btTroGiup.Text = " &About";
            this.btTroGiup.Click += new System.EventHandler(this.btTroGiup_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BeginGroup = true;
            this.btnThoat.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnThoat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnThoat.ImagePaddingHorizontal = 8;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.SubItemsExpandWidth = 24;
            this.btnThoat.Text = "&Exit";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.ImagePaddingHorizontal = 8;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "System";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Ganges";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel4.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            this.ribbonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem2;
        private DevComponents.DotNetBar.Office2007StartButton office2007StartButton1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.ButtonItem btTaiKhoan;
        private DevComponents.DotNetBar.ButtonItem btDangXuat;
        private DevComponents.DotNetBar.ButtonItem btnThoat;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel3;
        private DevComponents.DotNetBar.RibbonTabItem tabReport;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.ButtonItem btnDoanhThu;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.ButtonItem btDMBan;
        private DevComponents.DotNetBar.ButtonItem btThucDon;
        private DevComponents.DotNetBar.ButtonItem btTroGiup;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel4;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem4;
        private DevComponents.DotNetBar.ButtonItem btnMenuType;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnNhapHoaDon;
        private DevComponents.DotNetBar.ButtonItem btnDoiBan;
        private DevComponents.DotNetBar.ButtonItem bnFind;
        private DevComponents.DotNetBar.ButtonItem btScreen;
        private DevComponents.DotNetBar.ButtonItem btnMerge;
        private DevComponents.DotNetBar.ButtonItem btExport;
        private System.Windows.Forms.Timer timer1;
    }
}