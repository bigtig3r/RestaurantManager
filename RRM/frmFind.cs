using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QLCF
{
    public partial class frmFind : Form
    {
        BusinessLayer.ThongKe thongke = new BusinessLayer.ThongKe();
        BusinessLayer.HoaDon hoadon = new BusinessLayer.HoaDon();
        BusinessLayer.GoiMon goimon = new BusinessLayer.GoiMon();
        string mahd = "", soban = "", quyen = "";
        public frmFind()
        {
            InitializeComponent();
        }
        public frmFind(string ro)
        {
            InitializeComponent();
            quyen = ro;
        }

        private void rdoHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHoaDon.Checked == true)
            {
                txtMaHD.Visible = true;
                lblIda.Visible = true;
            }
            else
            {
                txtMaHD.Visible = false;
                lblIda.Visible = false;
            }
        }
        private bool IsNumber(string s)
        {
            Regex regex = new Regex(@"^[0-9]{1,45}$");
            return regex.IsMatch(s);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNgay.Checked == true)
                dtpDate.Visible = true;
            else
                dtpDate.Visible = false;
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            //if (quyen == "0")
            //    btEdit.Visible = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (mahd == "" || soban == "")
            {
                MessageBox.Show("Please ! select bill ! ", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (rdoHoaDon.Checked)
                    Print(int.Parse(mahd), soban);
                else if (rdoNgay.Checked)
                    Print(int.Parse(mahd), soban, dtpDate.Value);
            }
            catch
            {
                MessageBox.Show("Please ! select bill !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (rdoHoaDon.Checked && !IsNumber(txtMaHD.Text))
            {
                MessageBox.Show("Bill number is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rdoHoaDon.Checked)
            {
                FinddataGridView.DataSource = thongke.LoadHD_mahd(txtMaHD.Text);
            }
            if (rdoNgay.Checked)
            {
                string n = dtpDate.Text.Substring(0, 2);
                string t = dtpDate.Text.Substring(3, 2);
                string nm = dtpDate.Text.Substring(6, 4);
                FinddataGridView.DataSource = thongke.LoadHD_ngaylap(n, t, nm);
            }
            btnPre.Enabled = true;
            btnIn.Enabled = true;
        }
        public void Print(int id, string number)
        {
            try
            {

                HoaDonCrystalReport hd = new HoaDonCrystalReport();
                hd.SetDataSource(hoadon.Load_HoaDon(id, number));
                InCrystalReportViewer.ReportSource = hd;
                InCrystalReportViewer.Refresh();

                PrinterSettings settings = new PrinterSettings();
                hd.PrintOptions.PrinterName = settings.PrinterName;

                hd.PrintToPrinter(1, false, 0, 0);
                //hd.PrintToPrinter(1, false, 0, 0);
                //goimon.Update_DaThanhToan(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Print(int id, string number,DateTime ngay)
        {
            try
            {
                HoaDonCrystalReport hd = new HoaDonCrystalReport();
                hd.SetDataSource(hoadon.Load_HoaDon(id, number, ngay));
                InCrystalReportViewer.ReportSource = hd;
                InCrystalReportViewer.Refresh();

                //PrinterSettings settings = new PrinterSettings();
                //hd.PrintOptions.PrinterName = settings.PrinterName;

                hd.PrintToPrinter(1, false, 0, 0);
                //hd.PrintToPrinter(1, false, 0, 0);
                //goimon.Update_DaThanhToan(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FinddataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;
                mahd = FinddataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                soban = FinddataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {

            if (mahd == "" || soban == "")
            {
                MessageBox.Show("Please ! select bill !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (rdoHoaDon.Checked)
                {
                    FrmIn i = new FrmIn(mahd, soban, "preview");
                    i.ShowDialog();
                }
                else if (rdoNgay.Checked)
                {
                    FrmIn i = new FrmIn(mahd, soban, "preview", dtpDate.Value);
                    i.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Please ! select bill !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (mahd == "" || soban == "")
            {
                MessageBox.Show("Please ! select bill !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtpDate.Value.Date != DateTime.Today.Date)
            {
                MessageBox.Show("Sorry ! You can modify bill in today !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmGoiMon frm = new frmGoiMon(soban, "0");
            if (rdoHoaDon.Checked)
                frm.LoadMenu(mahd, soban, DateTime.Today);
            else if (rdoNgay.Checked)
                frm.LoadMenu(mahd, soban, dtpDate.Value);
            frm._IsEdit = true;
            frm.WindowState = FormWindowState.Normal;
            frm.Text = "Edit Menu";
            frm.ShowDialog();

            if (rdoHoaDon.Checked && !IsNumber(txtMaHD.Text))
            {
                MessageBox.Show("Bill number is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rdoHoaDon.Checked)
            {
                FinddataGridView.DataSource = thongke.LoadHD_mahd(txtMaHD.Text);
            }
            if (rdoNgay.Checked)
            {
                string n = dtpDate.Text.Substring(0, 2);
                string t = dtpDate.Text.Substring(3, 2);
                string nm = dtpDate.Text.Substring(6, 4);
                FinddataGridView.DataSource = thongke.LoadHD_ngaylap(n, t, nm);
            }
            btnPre.Enabled = true;
            btnIn.Enabled = true;
        }

        private void FinddataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FinddataGridView.ClearSelection();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
