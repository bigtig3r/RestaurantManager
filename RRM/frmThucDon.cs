using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QLCF
{
    public partial class frmThucDon : Form
    {
        BusinessLayer.ThucDon thuc_don = new BusinessLayer.ThucDon();
        int an;
        bool _IsEdit = false;

        public frmThucDon()
        {
            InitializeComponent();
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

        private bool IsID(string s)
        {
            Regex regex = new Regex("^[TDFN]{1,10}");
            return regex.IsMatch(s);
        }


        private bool IsID2(string s)
        {
            Regex regex = new Regex("^[0-9]{1,10}");
            return regex.IsMatch(s);
        }

        private void load_ThucDon()
        {
            ThucDonDataGridView.DataSource = thuc_don.Load_ThucDon();
        }

        private void load_ThucDonFilter(string id)
        {
            ThucDonDataGridView.DataSource = thuc_don.Load_ThucDonFilter(id);
        }

        private void load_Type()
        {
            cboType.DataSource = thuc_don.Load_LoaiThucDon();
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "Name";
        }

        private void frmThucDon_Load(object sender, EventArgs e)
        {
            load_ThucDon();
            load_Type();
            SetEnable(true);
        }

        private void ThucDonDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;
                txtMaMon.Text = ThucDonDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenMon.Text = ThucDonDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDonGia.Text = ThucDonDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboType.Text = "";
                cboType.SelectedText = ThucDonDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                cboType.SelectedValue = ThucDonDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                SetEnable(true);
            }
            catch { }
        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboType.SelectedValue != null)
            {
                load_ThucDonFilter(cboType.SelectedValue.ToString());
            }
        }

        private void txtMaMon_TextChanged(object sender, EventArgs e)
        {
            txtMaMon.Text = txtMaMon.Text.ToUpper();
            txtMaMon.SelectionStart = txtMaMon.TextLength;
        }

        private void txtMaMon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtMaMon_Validated(object sender, EventArgs e)
        {
            if (!IsID(txtMaMon.Text) && !IsID2(txtMaMon.Text) && !IsNumber(txtMaMon.Text) && txtMaMon.Text != "")
            {
                MessageBox.Show("Enter ID is not format ! \n Fist character is T,D,F,N or number", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMon.Text = "";
                txtMaMon.Focus();
                return;

            }     
        }

        void SetEnable(bool ena)
        {
            btNew.Enabled = ena;
            btSave.Enabled = !ena;
            btnSua.Enabled = ena;
            btHuy.Enabled = !ena;
            btnXoa.Enabled = ena;
            txtMaMon.Enabled = !ena;
            txtDonGia.Enabled = !ena;
            txtTenMon.Enabled = !ena;
        }

        void SetEnaID(bool ena)
        {
            txtMaMon.Enabled = ena;
        }
        private bool Kiemtra()
        {
            if (TextBox_Rong(txtTenMon.Text) == 1 || TextBox_Rong(txtDonGia.Text) == 1)
            {
                MessageBox.Show("Please enter Menu Name and Price", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;

            }
            if (!IsNumber(txtDonGia.Text))
            {
                MessageBox.Show("Price is number and greater than 0!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }

            if (cboType.SelectedValue == null)
            {
                MessageBox.Show("Please select Type", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            _IsEdit = false;
            SetEnable(false);
            cboType.Text = txtMaMon.Text = txtTenMon.Text = txtDonGia.Text = "";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Kiemtra()) return;
                if (!_IsEdit)
                {
                    if (!thuc_don.checkid(txtMaMon.Text))
                    {
                        MessageBox.Show("ID is exist in database \n Please ! Enter ID different.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaMon.Focus();
                        return;

                    }
                    int dongia = int.Parse(txtDonGia.Text);
                    thuc_don.Them(txtMaMon.Text, txtTenMon.Text, dongia, int.Parse(cboType.SelectedValue.ToString()));
                    if (cboType.SelectedValue != null)
                        load_ThucDonFilter(cboType.SelectedValue.ToString());
                    else
                        load_ThucDon();
                    MessageBox.Show("Insert Successfull !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboType.Text = txtMaMon.Text = txtTenMon.Text = txtDonGia.Text = "";
                    txtMaMon.Focus();
                }
                else
                {
                    string mamon = txtMaMon.Text;
                    int dongia = int.Parse(txtDonGia.Text);
                    thuc_don.Sua(mamon, txtTenMon.Text, dongia, int.Parse(cboType.SelectedValue.ToString()));
                    if (cboType.SelectedValue != null)
                        load_ThucDonFilter(cboType.SelectedValue.ToString());
                    else
                        load_ThucDon();
                    MessageBox.Show("Modify Successfull !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaMon.Text = txtTenMon.Text = txtDonGia.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Please ! Check data enter !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SetEnable(true);
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
                if (txtMaMon.Text == "")
                {
                    MessageBox.Show("Please select menu  !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string mamon = txtMaMon.Text;
                thuc_don.Xoa(mamon);
                if (cboType.SelectedValue != null)
                    load_ThucDonFilter(cboType.SelectedValue.ToString());
                else
                    load_ThucDon();
                MessageBox.Show("Delete Successfull  !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMon.Text = txtTenMon.Text = txtDonGia.Text = "";
            }
            catch
            {
                MessageBox.Show("System can't delete " + txtTenMon.Text + " ! Because this is menu print bill !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThucDonDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ThucDonDataGridView.ClearSelection();
        }
    }
}
