using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BusinessLayer;

namespace QLCF
{
    public partial class frmBan : Form
    {
        BusinessLayer.Ban ban = new BusinessLayer.Ban();
        private bool _IsEdit = false;
        public frmBan()
        {
            InitializeComponent();
        }
        private int TextBox_Rong(string text)
        {
            if (text == "")
                return 1;
            return 0;
        }
        private void Load_Ban()
        {
            BanDataGridView.DataSource = ban.Load_Ban();
        }

        bool KiemTra()
        {
            if (TextBox_Rong(txtSoGhe.Text) == 1)
            {
                MessageBox.Show("Chair number is not null", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (TextBox_Rong(txtSoBan.Text) == 1)
            {
                MessageBox.Show("Table number is not null", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsNumber(txtSoGhe.Text))
            {
                MessageBox.Show("Chair number is number and greater than 0 !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsNumber(string s)
        {
            Regex regex = new Regex(@"^[0-9]{1,45}$");
            return regex.IsMatch(s);
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            Load_Ban();
            SetEnable(true);
        }


        private void BanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            txtSoBan.Text = BanDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSoGhe.Text = BanDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGhiChu.Text = BanDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            SetEnable(true);
        }

        private void txtSoBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        void SetEnable(bool ena)
        {
            btNew.Enabled = ena;
            btSave.Enabled = !ena;
            btnSua.Enabled = ena;
            btHuy.Enabled = !ena;
            btnXoa.Enabled = ena;
            txtSoBan.Enabled = !ena;
            txtSoGhe.Enabled = !ena;
            txtGhiChu.Enabled = !ena;
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            _IsEdit = false;
            SetEnable(false);
            txtSoBan.Text = txtSoGhe.Text = txtGhiChu.Text = "";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!KiemTra()) return;
            int soghe = int.Parse(txtSoGhe.Text);
            if (!_IsEdit)
            {
                try
                {
                    ban.Them(txtSoBan.Text, soghe, txtGhiChu.Text);
                    Load_Ban();
                    MessageBox.Show("Insert Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoBan.Text = txtSoGhe.Text = txtGhiChu.Text = "";
                    txtSoBan.Focus();
                }
                catch
                {
                    if (ban.KT_BanTonTai(txtSoBan.Text) != 0)
                    {
                        MessageBox.Show("Table ID is exist", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else
            {
                ban.Sua(txtSoBan.Text, soghe, txtGhiChu.Text);
                Load_Ban();
                MessageBox.Show("Modify Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoBan.Text = txtSoGhe.Text = txtGhiChu.Text = "";
            }
            SetEnable(true);
        }
        void SetEnaID(bool ena)
        {
            txtSoBan.Enabled = ena;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            _IsEdit = true;
            SetEnable(false);
            SetEnaID(false);
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            SetEnable(true);
            SetEnaID(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Rong(txtSoBan.Text) == 1)
                {
                    MessageBox.Show("Please select table !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ban.Xoa(txtSoBan.Text);
                Load_Ban();
                MessageBox.Show("Delete Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoBan.Text = txtSoGhe.Text = txtGhiChu.Text = "";
            }
            catch
            {
                MessageBox.Show("System can't delete " + txtSoBan.Text + " ! Because this is table print bill", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BanDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            BanDataGridView.ClearSelection();
        }
    }
}
