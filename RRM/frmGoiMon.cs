using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LibList;

namespace QLCF
{
    public partial class frmGoiMon : Form
    {
        private LibList.List listBS = new LibList.List();
        int gia;
        public bool _IsEdit = false;
        string temp,tonghd, idban, quyen;
        DataTable dta,dafood,dadrink;
        BusinessLayer.Ban ban = new BusinessLayer.Ban();
        BusinessLayer.GoiMon goimon = new BusinessLayer.GoiMon();
        BusinessLayer.ThucDon thuc_don = new BusinessLayer.ThucDon();
        BusinessLayer.HoaDon hoadon = new BusinessLayer.HoaDon();
        BusinessLayer.ThongKe tk = new BusinessLayer.ThongKe();
        DateTime ngaylap = DateTime.Today;

        public frmGoiMon()
        {
            InitializeComponent();
            //var timer = new Timer();
            //timer.Tick += new EventHandler(timer1_Tick);
            //timer.Interval = 10000; //10 seconds
            //timer.Start();
        }

        public frmGoiMon(string idtable,string ro)
        {
            InitializeComponent();
            //var timer = new Timer();
            //timer.Tick += new EventHandler(timer1_Tick);
            //timer.Interval = 5000; //10 seconds
            //timer.Start();
            idban = idtable;
            quyen = ro;
        }
        private int TextBox_Rong(string text)
        {
            if (text == "")
                return 1;
            return 0;
        }

        private bool IsNumber(string s)
        {
            Regex regex = new Regex(@"^[0-9]{1,45}$");
            return regex.IsMatch(s);
        }

        private void Load_cbbBan()
        {
            cbbBan.DataSource = ban.Load_Ban();
            cbbBan.DisplayMember = ban.Load_Ban().Columns[0].ToString();
            cbbBan.ValueMember = ban.Load_Ban().Columns[0].ToString();
          
        }

        private void Load_ThucDonListBox()
        {
            ThucDonListBox.DataSource = thuc_don.Load_ThucDon();
            ThucDonListBox.DisplayMember = thuc_don.Load_ThucDon().Columns[1].ToString();
            ThucDonListBox.ValueMember = thuc_don.Load_ThucDon().Columns[0].ToString();
        }

        private string Check_Delivery(string idban)
        {
            if (ban.KT_BanDelivery(idban) != 0)
                return "5";
            return "0";

        }

        private void Load_ThucDonListBoxFillter(string loaiid)
        {
            ThucDonListBox.DataSource = thuc_don.Load_ThucDonFilter(loaiid);
            ThucDonListBox.DisplayMember = thuc_don.Load_ThucDonFilter(loaiid).Columns[1].ToString();
            ThucDonListBox.ValueMember = thuc_don.Load_ThucDonFilter(loaiid).Columns[0].ToString();
        }

        private void Load_GoiMon(int sohd)
        {
            GoiMonDataGridView.DataSource = goimon.Load_GoiMon(sohd);
        }

        private void Load_GoiMon(int sohd,string ngaylap)
        {
            GoiMonDataGridView.DataSource = goimon.Load_GoiMon(sohd, ngaylap);
        }

        public void Tinh_tonghd(int mahd)
        {
            try
            {
                dta = goimon.Tong_HD(mahd);
                if (dta.Rows.Count != 0)
                {
                    tonghd = lblTotal.Text = dauphay(dta.Rows[0]["Total"].ToString());
                }
                dta.Dispose();
            }
            catch
            {
            }
        }

        public string Tinh_Total(double ser, double del)
        {
            string temp2 = ghepchuoi(lblTotal.Text);
            if (temp2 == "") temp2 = "0";
            int total = int.Parse(temp2);
            double ketqua = total + del + total  * (ser / 100);
            double ketqua2 = Math.Round(ketqua, 0);
            return dauphay(ketqua2.ToString());
        }

        public string Tinh_Tax(double kq)
        {
            double ketqua = kq - kq / 1.1 ;
            double ketqua2 = Math.Round(ketqua, 0);
            return dauphay(ketqua2.ToString());
        }

        public string Tinh_Discount(double food, double drink)
        {
            string temp2 = ghepchuoi(tonghd);
            int total = int.Parse(temp2);
            double ketqua = total - (food + drink);
            double ketqua2 = Math.Round(ketqua, 0);
            return dauphay(ketqua2.ToString());
        }

        public void Update_Discount(int soHD,string food, string drink)
        {

            dafood = thuc_don.Load_MenubyBill(soHD, 1);
            dadrink = thuc_don.Load_MenubyBill(soHD, 0);
            foreach (DataRow row in dafood.Rows)
            {
                string monfood = row["MaMon"].ToString();
                int giamfood = int.Parse(txtDisFood.Text);
                thuc_don.Update_Discount(monfood, giamfood);
            }
            foreach (DataRow row2 in dadrink.Rows)
            {
                string mondrink = row2["MaMon"].ToString();
                int giamdrink = int.Parse(txtDisDrink.Text);
                thuc_don.Update_Discount(mondrink, giamdrink);
            }
            dafood.Dispose();
            dadrink.Dispose();

       }

        public string dauphay(string s)
        {
            string chuoi1 = "",chuoi2 = "", chuoi3 = "", chuoi4 = "";
            int leng = s.Length;
            if (leng > 3)
            {
                chuoi1 = s.Substring(leng - 3, 3);
            }
            if (leng == 4)
            {
                chuoi2 = s.Substring(leng - 4, 1);
            }
            if (leng == 5)
            {
                chuoi2 = s.Substring(leng - 5, 2);
            }
            if (leng == 6)
            {
                chuoi2 = s.Substring(leng - 6, 3);
            }
            if (leng == 7)
            {
                chuoi2 = s.Substring(leng - 6, 3);
                chuoi3 = s.Substring(0, 1);
            }
            if (leng == 8)
            {
                chuoi2 = s.Substring(leng - 6, 3);
                chuoi3 = s.Substring(0, 2);
            }
            if (chuoi3 != "")
            {
                chuoi4 = chuoi3 + ".";
            }

            return chuoi4 + chuoi2 + "." + chuoi1;

        }

        public string ghepchuoi(string s)
        {
            string[] leng = s.Split('.');
            string result = "";
            foreach (string a in leng)
            {
                result += a;
            }
            return result;
           
        }

        private void Load_Type()
        {
            cboType.DataSource = thuc_don.Load_LoaiThucDon();
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "Name";

        }

        private void Load_TypebyType(string type)
        {
            cboType.DataSource = thuc_don.Load_LoaiThucDonbyType(type);
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "Name";

        }

        private void KT_BillDaIn(int sohd,string soban)
        {
            if (goimon.KT_BillDaIn(sohd, idban) >= 0 && goimon.KT_BillDaIn(sohd, idban) > 1 && goimon.KT_BillDaIn(sohd, idban) != -1)
            {
                btnStaff.Enabled = false;
            }
            else
                btnStaff.Enabled = true;

            if (goimon.KT_BillDaIn(sohd, idban) >= 0 && goimon.KT_BillDaIn(sohd, idban) == 1 && goimon.KT_BillDaIn(sohd, idban) != -1)
            {
                btnStaff.Text = "Staff Bill 2";
            }
        }

        private void frmGoiMon_Load(object sender, EventArgs e)
        {
            try
            {
                //Load_ThucDonListBox();
                //Load_cbbBan();
                //TinhSoHDThieu();
                Load_Type();
                txtSer.Text = Check_Delivery(idban);
                cbbBan.Text = idban;
                lblban.Text = idban;
                cbbBan_SelectedValueChanged(sender, e);
                cboType_SelectionChangeCommitted(sender, e);
                if (cbbBan.Text != null)
                {
                    string idtable = cbbBan.Text;
                    int idbill = goimon.getHD(idtable);
                    if (goimon.TinhTrangBan(idtable) == false)
                    {
                        Tinh_tonghd(idbill);
                        lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));
                    }
                    KT_BillDaIn(idbill, idtable);
                }
                //if (quyen == "0")
                //    grpEdit.Visible = true;
                rdoID.Checked = true;
                rdoID_CheckedChanged(sender, e);
                txtID.Text = "";
                txtID.Focus();
            }
            catch { }
           
        }

        private void btnThemGoiMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Rong(txtSoLuong.Text) == 1)
                {
                    MessageBox.Show("Please !Enter Quantity !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsNumber(txtDiscount.Text))
                {
                    MessageBox.Show("Field Discount is number", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsNumber(txtSoLuong.Text))
                {
                    MessageBox.Show("Quantity is number", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string idmat = TinhSoHDThieu();
                string soban = cbbBan.Text;
                int soluong = int.Parse(txtSoLuong.Text);
                int giam = int.Parse(txtDiscount.Text);
                string mamon = ThucDonListBox.SelectedValue.ToString();
                if (mamon != null)
                    gia = int.Parse(goimon.GiabyID(mamon).Rows[0][0].ToString());
                if (goimon.TinhTrangBan(soban) == true && quyen != "0")
                {
                        goimon.ThemHD(soban, ngaylap);
                        goimon.Update_Ban(soban);
                }

                int sohd;
                if (quyen != "0")
                {
                    sohd = goimon.getHD(cbbBan.Text);
                }
                else
                {
                    sohd = int.Parse(txtBillIDFind.Text);
                }

                if (goimon.KiemTraMon(sohd, mamon) != 0)
                {
                    goimon.Update_SLGoiMon(sohd, mamon, soluong);
                }
                else
                {
                    goimon.Them_GoiMon(sohd, mamon, soluong, gia, giam);
                }
                Load_GoiMon(sohd, ngaylap.ToString("dd/MM/yyyy"));
                Tinh_tonghd(sohd);
                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));
                KT_BillDaIn(sohd, soban);
                GC.Collect();
                //MessageBox.Show("Insert Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error '" + ex + "'", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaGoiMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (goimon.TinhTrangBan(cbbBan.Text) == true && quyen != "0")
                {
                    return;
                }
                if (TextBox_Rong(txtSoLuong.Text) == 1)
                {
                    MessageBox.Show("Please !Enter Quantity !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsNumber(txtDiscount.Text))
                {
                    MessageBox.Show("Field Discount is number", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsNumber(txtSoLuong.Text))
                {
                    MessageBox.Show("Quantity is number", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int sohd;
                if (quyen != "0")
                {
                    sohd = goimon.getHD(cbbBan.Text);
                }
                else
                {
                    sohd = int.Parse(txtBillIDFind.Text);
                }
                
                int soluong = int.Parse(txtSoLuong.Text);
                int dis = int.Parse(txtDiscount.Text);
                if (temp != "")
                {
                    goimon.Sua_GoiMon(sohd, temp, soluong, dis);
                }
                else
                {
                    MessageBox.Show("Please ! select menu", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Load_GoiMon(sohd,ngaylap.ToString("dd/MM/yyyy"));
                Tinh_tonghd(sohd);
                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));
                txtSoLuong.Text = "1";
                GC.Collect();
                //MessageBox.Show("Modify Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Please ! Check data enter", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaGoiMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (goimon.TinhTrangBan(cbbBan.Text) == true && quyen != "0")
                {
                    return;
                }
                int sohd;
                if (quyen != "0")
                {
                    sohd = goimon.getHD(cbbBan.Text);
                }
                else
                {
                    sohd = int.Parse(txtBillIDFind.Text);
                }
                if (temp != "")
                {
                    goimon.Xoa_GoiMon(sohd, temp);
                }
                else
                {
                    MessageBox.Show("Please ! select menu", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (goimon.KiemTraCTHD_Rong(sohd) == 0)
                    goimon.Update_DaThanhToan(cbbBan.Text);
                Load_GoiMon(sohd,ngaylap.ToString("dd/MM/yyyy"));
                Tinh_tonghd(sohd);
                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));
                //Load_DoiTuBan();
                GC.Collect();
                //MessageBox.Show("Delete Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Please ! Check data input ", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbbBan_SelectedValueChanged(object sender, EventArgs e)
        {
            //groupPanel1.Text = "Menu for table  " + cbbBan.Text;

                try
                {
                    if (goimon.TinhTrangBan(cbbBan.Text) == false)
                    {
                        int sohd = goimon.getHD(cbbBan.Text);
                        Load_GoiMon(sohd, DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                }
                catch
                {
                    return;
                }


        }

        private void GoiMonDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;
                ThucDonListBox.Text =  GoiMonDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSoLuong.Text = GoiMonDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                temp = txtID.Text = GoiMonDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiscount.Text = GoiMonDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (txtDiscount.Text == "")
                    txtDiscount.Text = "0";
            }
            catch
            {
            }
        }

        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager manager = (CurrencyManager)this.BindingContext[this.listBS.DataSource];
                DataView list = (DataView)manager.List;
                list.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch
            {
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ThucDonListBox.SelectedIndex = ThucDonListBox.FindString(txtTimKiem.Text);
            ThucDonListBox.TopIndex = ThucDonListBox.SelectedIndex;
        }

        private void cbbBan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string soban = cbbBan.Text;
                if (ban.KT_BanTonTai(soban) == 0)
                    cbbBan.Text = "1";
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // frmGoiMon_Load(sender, e);
        }

        private void frmGoiMon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //timer1.Stop();
            System.GC.Collect();
            GC.WaitForPendingFinalizers();
            if (quyen != "0")
            {
                frmShow sh = new frmShow(quyen);
                sh.MdiParent = this.ParentForm;
                sh.Show();
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (!KiemTraSave()) return;
            
            try
            {
                string tableid = cbbBan.Text;
                int billid;
                if (quyen != "0")
                {
                    billid = goimon.getHD(cbbBan.Text);
                }
                else
                {
                    billid = int.Parse(txtBillIDFind.Text);
                }
                if (goimon.TinhTrangBan(tableid) == false || quyen == "0")
                {
                    Update_Discount(billid, (txtDisFood.Text == "") ? "0" : txtDisFood.Text, (txtDisDrink.Text == "") ? "0" : txtDisDrink.Text);
                    goimon.Update_price(billid, tableid, txtSer.Text, txtDel.Text == "" ? "0" : txtDel.Text);
                    goimon.Update_GiamGia(billid, tableid, (txtDisFood.Text == "") ? "0" : txtDisFood.Text, (txtDisDrink.Text == "") ? "0" : txtDisDrink.Text, lblFo.Text, lblDr.Text);
                }
                else
                {
                    MessageBox.Show("This Table is Empty !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Print(billid, tableid);                               
                empty();
                txtSer.Text = Check_Delivery(idban); 
                txtID.Focus();
                lblTotal.Text = "0";
                lblTotal2.Text = "0";
                //frmIn i = new frmIn(billid.ToString(), tableid.ToString(), "print");
                //i.Hide();
              
                //goimon.Update_DaThanhToan(tableid);
                GC.Collect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void empty()
        {
            GoiMonDataGridView.DataSource = null;
            lblTotal.Text = "0";
            lblTotal2.Text = "0";
            txtDel.Text = "0";
            txtSer.Text = "5";
            txtDisDrink.Text = "0";
            txtDisFood.Text = "0";
            txtID.Text = "";
            txtSoLuong.Text = "1";
            txtSoLuongSpeed.Text = "1";
        }

        public void Print(int id, string number)
        {
            try
            {

                HoaDonCrystalReport hd = new HoaDonCrystalReport();
                hd.SetDataSource(hoadon.Load_HoaDon(id, number));
                IncrystalReportViewer.ReportSource = hd;
                IncrystalReportViewer.Refresh();

                PrinterSettings settings = new PrinterSettings();
                hd.PrintOptions.PrinterName = settings.PrinterName;

                hd.PrintToPrinter(1, false, 0, 0);
                hd.PrintToPrinter(1, false, 0, 0);
                goimon.Update_DaThanhToan(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Print2(int id, string number)
        {
            try
            {
                StaffBillCrystalReport hd = new StaffBillCrystalReport();
                //HoaDonCrystalReport hd = new HoaDonCrystalReport();
                hd.SetDataSource(hoadon.Load_HoaDon(id, number));
                IncrystalReportViewer.ReportSource = hd;
                IncrystalReportViewer.Refresh();

                hd.PrintToPrinter(1, false, 0, 0);
                //hd.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cboType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedValue != null)
            {
                Load_ThucDonListBoxFillter(cboType.SelectedValue.ToString());
            }
        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkAll.Checked = false;
            if (cboType.SelectedValue != null)
            {
                Load_ThucDonListBoxFillter(cboType.SelectedValue.ToString());
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                Load_ThucDonListBox();
            }
            else
            {
                Load_ThucDonListBoxFillter(cboType.SelectedValue.ToString());
            }
        }

        private void txtSer_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtSer.Text == "")
                    txtSer.Text = "0";
                if (!IsNumber(txtSer.Text))
                {
                    MessageBox.Show("Service charge is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSer.Text = "0";
                    return;
                }
                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));

            }
            catch
            {
            }
        }

        private void txtDel_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (!IsNumber(txtDel.Text))
                {
                    MessageBox.Show("Delivery charge is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDel.Text = "0";
                    return;
                }

                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text == "" ? "0" : txtDel.Text));
            }
            catch
            {
            }
        }

        private void ThucDonListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThemGoiMon_Click(sender, e);
                txtTimKiem.Text = "";
                txtTimKiem.Focus();
            }

        }

        private void rdoFood_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Load_TypebyType("1");
            }
            catch
            {
            }
        }

        private void rdoDrink_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Load_TypebyType("0");
            }
            catch
            {
            }
        }

        private void txtDisFood_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int bill= goimon.getHD(idban);
                if (!IsNumber(txtDisFood.Text))
                {
                    MessageBox.Show("Discount Food is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDisFood.Text = "0";
                    return;
                }
                lblFo.Text = thuc_don.Load_Discountbytype(bill, 1, txtDisFood.Text == "" ? "0" : txtDisFood.Text).Rows[0]["Discount"].ToString();
                if (lblFo.Text == "") lblFo.Text = "0";
                lblTotal.Text = Tinh_Discount(double.Parse(lblFo.Text), double.Parse(lblDr.Text));
                GC.Collect();
            }
            catch
            {
            }
        }

        private void txtDisDrink_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int bill = goimon.getHD(idban);

                if (!IsNumber(txtDisDrink.Text))
                {
                    MessageBox.Show("Discount Drink is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDisDrink.Text = "0";
                    return;
                }
                lblDr.Text = thuc_don.Load_Discountbytype(bill, 0, txtDisDrink.Text == "" ? "0" : txtDisDrink.Text).Rows[0]["Discount"].ToString();
                if (lblDr.Text == "") lblDr.Text = "0";
                lblTotal.Text = Tinh_Discount(double.Parse(lblFo.Text), double.Parse(lblDr.Text));
                GC.Collect();
            }
            catch
            {
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        public void LoadMenu(string billid, string tableid, DateTime date)
        {
            try
            {
                lblban.Text = cbbBan.Text = idban = tableid;
                txtBillIDFind.Text = billid;
                ngaylap = date;
                int id = int.Parse(txtBillIDFind.Text);
                Load_GoiMon(id, date.ToString("dd/MM/yyyy"));
                Tinh_tonghd(id);
                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));
                _IsEdit = true;
                btncacel.Text = "Delete";
            }
            catch
            { }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBillIDFind.Text);
                Load_GoiMon(id,DateTime.Now.ToString("dd/MM/yyyy"));
                Tinh_tonghd(id);
                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));
            }
            catch
            { }
        }

        private void txtBillIDFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBillIDFind.Text == "")
                    txtBillIDFind.Text = "0";
                if (!IsNumber(txtBillIDFind.Text))
                {
                    MessageBox.Show("Bill ID is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBillIDFind.Text = "0";
                    return;
                }
            }
            catch
            {
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        bool KiemTraSave()
        {
            if (!IsNumber(txtDel.Text))
            {
                MessageBox.Show("Delivery charge is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsNumber(txtDis.Text))
            {
                MessageBox.Show("Discount charge is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsNumber(txtSer.Text))
            {
                MessageBox.Show("Service charge is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {

            if (!KiemTraSave()) return;
            try
            {
                string tableid = cbbBan.Text;
                int billid;
                if (quyen != "0")
                {
                    billid = goimon.getHD(cbbBan.Text);
                }
                else
                {
                    billid = int.Parse(txtBillIDFind.Text);
                }
                if (goimon.TinhTrangBan(tableid) == false || quyen == "0")
                {
                    Update_Discount(billid, txtDisFood.Text, txtDisDrink.Text);
                    goimon.Update_price(billid, tableid, txtSer.Text, txtDel.Text);
                    goimon.Update_GiamGia(billid, tableid, txtDisFood.Text, txtDisDrink.Text, lblFo.Text, lblDr.Text);
                }
                else
                {
                    MessageBox.Show("This Table is Empty !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmIn i = new FrmIn(billid.ToString(), tableid, "preview");
                i.ShowDialog();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtSer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDisFood_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDisDrink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            txtSer_TextChanged(sender, e);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            txtID.Text = txtID.Text.ToUpper();
            txtID.SelectionStart = txtID.TextLength;

        }

        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoName.Checked == true)
            {
                grbName.Enabled = true;
                grbID.Enabled = false;
                grpAdd.Enabled = false;
                btnThemGoiMon.Enabled = true;

            }
            else
            {

            }
            txtTimKiem.Focus();
        }

        private void rdoID_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoID.Checked == true)
            {
                grbID.Enabled = true;
                grbName.Enabled = false;
                grpAdd.Enabled = false;
                btnThemGoiMon.Enabled = false;
            }
            else
            {
                grbName.Enabled = true;
            }
            txtID.Focus();
        }
        bool KiemTra()
        {
            if (TextBox_Rong(txtID.Text) == 1)
            {
                MessageBox.Show("Please !Enter ID !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
                return false;
            }
            if (TextBox_Rong(txtSoLuong.Text) == 1)
            {
                MessageBox.Show("Please !Enter Quantity !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsNumber(txtDiscount.Text))
            {
                MessageBox.Show("Field Discount is number", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsNumber(txtSoLuong.Text))
            {
                MessageBox.Show("Quantity is number  and greater than 0!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsNumber(txtSoLuongSpeed.Text))
            {
                MessageBox.Show("Quantity is number and greater than 0!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongSpeed.Focus();
                return false;

            }
            return true;
        }
        private void btnAddSpeed_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTra()) return;
                string idmat = TinhSoHDThieu();
                string soban = cbbBan.Text;
                int soluong = int.Parse(txtSoLuongSpeed.Text);
                int giam = int.Parse(txtDiscount.Text);
                gia = int.Parse(goimon.GiabyID(txtID.Text).Rows[0][0].ToString());
                if (goimon.TinhTrangBan(soban) == true && quyen != "0")
                {
                    //if (idmat != "")
                    //    goimon.ThemHD(idmat, soban, ngaylap);
                    //else
                        goimon.ThemHD(soban, ngaylap);
                        goimon.Update_Ban(soban);
                }
                int sohd;
                if (quyen != "0")
                {
                    sohd = goimon.getHD(cbbBan.Text);
                }
                else
                {
                    sohd = int.Parse(txtBillIDFind.Text);
                }
                if (goimon.KiemTraMon(sohd, txtID.Text) != 0)
                {
                    goimon.Update_SLGoiMon(sohd, txtID.Text, soluong);
                }
                else
                {
                    goimon.Them_GoiMon(sohd, txtID.Text, soluong, gia, giam);
                }
                Load_GoiMon(sohd,ngaylap.ToString("dd/MM/yyyy"));
                Tinh_tonghd(sohd);
                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));
                KT_BillDaIn(sohd, soban);
                GC.Collect();
                //MessageBox.Show("Insert Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error '" + ex + "'", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtSoLuongSpeed.Text = "1";
            txtID.Text = "";
            txtID.Focus();
        }

        private string TinhSoHDThieu()
        {
            try
            {
                int i = 0;
                int socu = 0;
                DataTable dt = goimon.SelectSoHD();
                string[] arr = new string[dt.Rows.Count];
                foreach (DataRow dr in dt.Rows)
                {
                    arr[i] = dr["SoHD"].ToString();
                    i++;
                }
                for (int j = 0; j <= dt.Rows.Count; j++)
                {//1,2,4
                    if (int.Parse(arr[j].ToString()) != 1 && arr.Length == 1)
                        return "1";
                    if (int.Parse(arr[j + 1].ToString()) - 1 != int.Parse(arr[j].ToString()))
                    {
                        return (int.Parse(arr[j].ToString()) + 1).ToString();
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        private void txtID_Validated(object sender, EventArgs e)
        {
            try
            {
                
                if (thuc_don.checkid(txtID.Text) && txtID.Text != "")
                {
                    MessageBox.Show("ID is not found ", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                    txtID.Text = "";
                    return;

                }
            }
            catch
            {
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSoLuongSpeed_TextChanged(object sender, EventArgs e)
        {
           // txtSoLuong.Text = txtSoLuongSpeed.Text;
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void GoiMonDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            
           
        }

        private void rdoadd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoadd.Checked == true)
            {
                grpAdd.Enabled = true;
                grbID.Enabled = false;
                grbName.Enabled = false;
                btnThemGoiMon.Enabled = false;


            }
            else
            {

            }
            txtName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Rong(txtName.Text) == 1)
                {
                    MessageBox.Show("Please !Enter Name !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                    return;
                }
                if (TextBox_Rong(txtsl.Text) == 1)
                {
                    MessageBox.Show("Please !Enter Quantity !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsNumber(txtprice.Text))
                {
                    MessageBox.Show("Field Price is number and greater than 0!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsNumber(txtsl.Text))
                {
                    MessageBox.Show("Quantity is number  and greater than 0!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int type = 0;
                if (rdoFood1.Checked)
                {
                    type = 9999;
                }
                if (rdoDrink1.Checked)
                {
                    type = 8888;
                }
                string idmat = TinhSoHDThieu();
                string soban = cbbBan.Text;
                DateTime ngaylap = DateTime.Now;
                int soluong = int.Parse(txtsl.Text);
                gia = int.Parse(txtprice.Text);
                string mamon = "BS" + (goimon.Getrownum("BS").Rows.Count + 1).ToString();
                if (goimon.TinhTrangBan(soban) == true && quyen != "0")
                {

                        goimon.ThemHD(soban, ngaylap);
                        goimon.Update_Ban(soban);
                }

                int sohd;
                if (quyen != "0")
                {
                    sohd = goimon.getHD(cbbBan.Text);
                }
                else
                {
                    sohd = int.Parse(txtBillIDFind.Text);
                }
                
                if (goimon.KiemTraMon(sohd, mamon) != 0)
                {
                    goimon.Update_SLGoiMon(sohd, mamon, soluong);
                }
                else
                {
                    thuc_don.Them(mamon, txtName.Text, gia, type);
                    goimon.Them_GoiMon(sohd, mamon, soluong, gia, 0);
                }
                Load_GoiMon(sohd,ngaylap.ToString("dd/MM/yyyy"));
                Tinh_tonghd(sohd);
                lblTotal2.Text = Tinh_Total(double.Parse(txtSer.Text), double.Parse(txtDel.Text));
                txtName.Text = txtprice.Text = txtsl.Text = "";
                txtName.Focus();
                KT_BillDaIn(sohd, soban);
                //MessageBox.Show("Insert Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error '" + ex + "'", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btncacel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult h = new DialogResult();
                h = MessageBox.Show("Are you sure ?!", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (h.ToString() == "OK")
                {
                    if (goimon.TinhTrangBan(cbbBan.Text) == true && quyen != "0")
                    {
                        return;
                    }
                    int sohd;
                    if (quyen != "0")
                    {
                        sohd = goimon.getHD(cbbBan.Text);
                    }
                    else
                    {
                        sohd = int.Parse(txtBillIDFind.Text);
                    }
                    DataTable dt3 = goimon.Getmenubybillid(sohd);
                    string a = "";
                    foreach (DataRow r in dt3.Rows)
                    {
                        a += r["MaMon"].ToString() + ",";
                    }
                    string[] mamon = a.Split(',');
                    foreach (string ma in mamon)
                    {
                        if (ma != "")
                        {
                            goimon.Xoa_GoiMon(sohd, ma);
                        }
                    }
                    goimon.Del_HoaDon(sohd);
                    goimon.Update_DaThanhToan(cbbBan.Text);
                    empty();
                    txtSer.Text = Check_Delivery(cbbBan.Text);
                    tk.Reset_ID();
                    lblTotal.Text = "0";
                    lblTotal2.Text = "0";
                    GC.Collect();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
             if (!IsNumber(txtDel.Text))
            {
                MessageBox.Show("Delivery charge is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsNumber(txtDis.Text))
            {
                MessageBox.Show("Discount charge is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsNumber(txtSer.Text))
            {
                MessageBox.Show("Service charge is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                string tableid = cbbBan.Text;
                int billid;
                if (quyen != "0")
                {
                    billid = goimon.getHD(cbbBan.Text);
                }
                else
                {
                    billid = int.Parse(txtBillIDFind.Text);
                }
                if (goimon.TinhTrangBan(tableid) == false)
                {
                    Update_Discount(billid, (txtDisFood.Text == "") ? "0" : txtDisFood.Text, (txtDisDrink.Text == "") ? "0" : txtDisDrink.Text);
                    goimon.Update_price(billid, tableid, txtSer.Text, txtDel.Text == "" ? "0" : txtDel.Text);
                    goimon.Update_GiamGia(billid, tableid, (txtDisFood.Text == "") ? "0" : txtDisFood.Text, (txtDisDrink.Text == "") ? "0" : txtDisDrink.Text, lblFo.Text, lblDr.Text);
                    goimon.Update_BillDaIn(billid, tableid);
                }
                else
                {
                    MessageBox.Show("This Table is Empty !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Print2(billid, tableid);
                //empty();
                txtID.Focus();
                KT_BillDaIn(billid, tableid);
                //btnStaff.Enabled = false;
                //frmIn i = new frmIn(billid.ToString(), tableid.ToString(), "print");
                //i.Hide();
              
                //goimon.Update_DaThanhToan(tableid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  
    }
}
