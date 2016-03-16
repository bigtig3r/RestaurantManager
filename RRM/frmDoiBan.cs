using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLCF
{
    public partial class frmDoiBan : Form
    {
        BusinessLayer.Ban table = new BusinessLayer.Ban();
        BusinessLayer.GoiMon goimon = new BusinessLayer.GoiMon();
        BusinessLayer.DoiBan doiban = new BusinessLayer.DoiBan();

        public frmDoiBan()
        {
            InitializeComponent();
        }

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
        private void btnDoiBan_Click(object sender, EventArgs e)
        {
            string soban1 = TuBanListBox.Text;
            string soban2 = SangBanListBox.Text;
            int sohd1 = goimon.getHD(soban1);
            if (goimon.TinhTrangBan(soban2) == true)
            {
                doiban.DoiBan1(sohd1, soban2);
                goimon.Update_DaThanhToan(soban1);
                goimon.Update_Ban(soban2);
            }
            else
            {
                int sohd2 = goimon.getHD(soban2);
                doiban.DoiBan2(sohd1, sohd2, soban1, soban2);
            }
            MessageBox.Show("Change Successfull !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Cap Nhat Lai Hoa Don Cua So Ban Hien Tai Tu Danh Muc Goi Mon
            //cbbBan.Text = soban2.ToString();
            //Load_GoiMon(goimon.getHD(soban2));
            //Show_Ban();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Load_DoiTuBan();
        }

        private void frmDoiBan_Load(object sender, EventArgs e)
        {
            Load_DoiTuBan();
            load_sangban();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
