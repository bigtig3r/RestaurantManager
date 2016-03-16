using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLCF
{
    public partial class frmHoaDon : Form
    {
        BusinessLayer.Ban table = new BusinessLayer.Ban();
        BusinessLayer.HoaDon hoadon = new BusinessLayer.HoaDon();
        BusinessLayer.GoiMon goimon = new BusinessLayer.GoiMon();

        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                string soban = cbbHoaDonBan.Text;
                int sohd = goimon.getHD(soban);
                HoaDonCrystalReport hd = new HoaDonCrystalReport();
                hd.SetDataSource(hoadon.Load_HoaDon(sohd, soban));
                HoaDonCrystalReportViewer.ReportSource = hd;
                HoaDonCrystalReportViewer.Refresh();
                goimon.Update_DaThanhToan(soban);
                //Show_Ban();
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần thanh toán", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhatBan_Click(object sender, EventArgs e)
        {
            cbbHoaDonBan.DataSource = table.Load_DoiTuBan();
            cbbHoaDonBan.DisplayMember = table.Load_DoiTuBan().Columns[0].ToString();
            cbbHoaDonBan.ValueMember = table.Load_DoiTuBan().Columns[0].ToString();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            btnCapNhatBan_Click(sender, e);
        }

        private void cbbHoaDonBan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string soban = cbbHoaDonBan.Text;
                if (table.KT_BanTonTai(soban) == 0 || goimon.TinhTrangBan(soban) == true)
                    cbbHoaDonBan.Text = "";
            }
            catch
            {
            }
        }
    }
}
