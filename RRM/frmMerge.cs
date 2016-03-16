using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLCF
{
    public partial class frmMerge : Form
    {
        public frmMerge()
        {
            InitializeComponent();
        }

        BusinessLayer.Ban table = new BusinessLayer.Ban();
        BusinessLayer.GoiMon goimon = new BusinessLayer.GoiMon();
        BusinessLayer.DoiBan doiban = new BusinessLayer.DoiBan();

        private void Load_DoiTuBan()
        {
            TuBanListBox.DataSource = table.Load_DoiTuBan();
            TuBanListBox.DisplayMember = table.Load_DoiTuBan().Columns[0].ToString();

        }

        private void load_sangban()
        {
            SangBanListBox.DataSource = table.Load_Ban();
            SangBanListBox.DisplayMember = table.Load_Ban().Columns[0].ToString();
            SangBanListBox.ValueMember = table.Load_Ban().Columns[0].ToString();
        }

        private void frmMerge_Load(object sender, EventArgs e)
        {
            Load_DoiTuBan();
            load_sangban();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Load_DoiTuBan();
        }

        private void btnDoiBan_Click(object sender, EventArgs e)
        {
           
            string soban1 = TuBanListBox.Text;
            string soban2 = SangBanListBox.Text;
          
            if (goimon.TinhTrangBan(soban1) == true)
            {
                MessageBox.Show("Table " + soban1 + " is Empty !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (soban1 == soban2)
            {
                MessageBox.Show("Cann't mergre from table " + soban1 + " to table " + soban2 + " !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int sohd1 = goimon.getHD(soban1);
            int sohd2 = goimon.getHD(soban2);
            if (goimon.TinhTrangBan(soban2) == false)
            {
                goimon.GhepBan(sohd1, sohd2);
                goimon.Update_DaThanhToan(soban1);
            }
            else
            {
                MessageBox.Show("Table " + soban2 + " is Empty ! \n Please ! Select function Change Table !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          
            MessageBox.Show("Merge Successfull !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Cap Nhat Lai Hoa Don Cua So Ban Hien Tai Tu Danh Muc Goi Mon
            //cbbBan.Text = soban2.ToString();
            //Load_GoiMon(goimon.getHD(soban2));
            //Show_Ban();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
