using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCF
{
    public partial class FrmIn : Form
    {
       private BusinessLayer.GoiMon goimon = new BusinessLayer.GoiMon();
		private BusinessLayer.HoaDon hoadon = new BusinessLayer.HoaDon();
		private string mahd;
		private string soban;
		private string trangthai;
		private DateTime _ngay = DateTime.MinValue;
		public FrmIn()
		{
			InitializeComponent();
		}
		public FrmIn(string ma, string ban, string stt)
		{
			InitializeComponent();
			mahd = ma;
			soban = ban;
			trangthai = stt;
		}
        public FrmIn(string ma, string ban, string stt, DateTime ngay)
		{
			InitializeComponent();
			mahd = ma;
			soban = ban;
			trangthai = stt;
			_ngay = ngay;
		}
        private void FrmIn_Load(object sender, EventArgs e)
		{
			try
			{
				DataTable dataSource = new DataTable();
				if (_ngay == DateTime.MinValue)
				{
					dataSource = hoadon.Load_HoaDon(int.Parse(mahd), soban);
				}
				else
				{
					dataSource = hoadon.Load_HoaDon(int.Parse(mahd), soban, _ngay);
				}
				HoaDonCrystalReport hoaDonCrystalReport = new HoaDonCrystalReport();
				hoaDonCrystalReport.SetDataSource(dataSource);
                crystalReportViewer1.ReportSource = hoaDonCrystalReport;
                crystalReportViewer1.Refresh();
				if (trangthai == "print")
				{
					hoaDonCrystalReport.PrintToPrinter(1, false, 0, 0);
					hoaDonCrystalReport.PrintToPrinter(1, false, 0, 0);
					goimon.Update_DaThanhToan(soban);
				}
				else
				{
                    crystalReportViewer1.ShowPrintButton = false;
                    crystalReportViewer1.ShowExportButton = false;
				}
			}
			catch (Exception var_2_EE)
			{
			}
		}
    }
}
