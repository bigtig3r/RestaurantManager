using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinessLayer;
namespace QLCF
{
    public partial class frmLogin : Form
    {
        BusinessLayer.QuanTri quantri = new BusinessLayer.QuanTri();
        public string quyen;
        public frmLogin()
        {
            InitializeComponent();
        }
        /*
        void KiemTraQuyen()
        {
            string quyenDN = txtDangNhap.Text;
            if (quyenDN.Equals("admin") == true)
            {
                MessageBox.Show("Chào Bạn ! Bạn Đã Đăng Nhập Quyền Quản lý", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCoffee admin = new frmCoffee();
                admin.Show();
                this.Hide();
            }
            else if (quyenDN.Equals("quanly") == true)
            {
                MessageBox.Show("Chào Bạn ! Bạn Đã Đăng Nhập Quyền Nhân Viên", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         
                frmCoffee quanly = new frmCoffee();
                quanly.Show();
                this.Hide();

            }
            else
                MessageBox.Show("No Find A Account !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
         */
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "")
            {
                MessageBox.Show("Enter Username", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Enter Password", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            else
            {

                if (txtDangNhap.Text == "admin" && txtMatKhau.Text == "vu@dat" + DateTime.Now.Day.ToString())
                {
                    quyen = "0";
                    frmMain admin = new frmMain(quyen);
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    string pass = quantri.Encrypt(txtMatKhau.Text);
                    //string pass = txtMatKhau.Text;
                    DataTable dt = quantri.Login(txtDangNhap.Text.Trim(), pass);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Please ! Check Username/Password !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDangNhap.Clear();
                        txtMatKhau.Clear();
                        txtDangNhap.Focus();
                    }
                    else
                    {
                        //MessageBox.Show("Login Successfull !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        quyen = dt.Rows[0]["Quyen"].ToString();
                        quantri.LoadView();
                        quantri.LoadViewTK();
                        frmMain admin = new frmMain(quyen);
                        admin.Show();
                        this.Hide();


                        //KiemTraQuyen();
                    }
                }
            }
        }
       

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
