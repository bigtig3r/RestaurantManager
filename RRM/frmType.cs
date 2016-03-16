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
    public partial class frmType : Form
    {
        BusinessLayer.ThucDon type = new BusinessLayer.ThucDon();
        private bool _IsEdit = false;
        public frmType()
        {
            InitializeComponent();
        }
        int loai = 0;
        private int TextBox_Rong(string text)
        {
            if (text == "")
                return 1;
            return 0;
        }

        private void Load_Type()
        {
            TypeDataGridView.DataSource = type.Load_LoaiThucDon();
        }
        private bool Kiemtra()
        {
            if (TextBox_Rong(txtID.Text) == 1)
            {
                MessageBox.Show("ID is not null", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (TextBox_Rong(txtName.Text) == 1)
            {
                MessageBox.Show("Name is not null", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsNumber(txtID.Text))
            {
                MessageBox.Show("ID must is number!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool IsNumber(string s)
        {
            Regex regex = new Regex(@"^[0-9]{1,45}$");
            return regex.IsMatch(s);
        }
        private void frmType_Load(object sender, EventArgs e)
        {
            Load_Type();
            SetEnable(true);
        }

        private void TypeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;
                txtID.Text = TypeDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = TypeDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string temptype = TypeDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (temptype == "Food")
                {
                    rdoFood.Checked = true;
                }
                else
                {
                    rdoDrink.Checked = true;
                }
                SetEnable(true);
            }
            catch
            {
            }
        }

        private void rdoFood_CheckedChanged(object sender, EventArgs e)
        {
            //txtID.Text = "F";
            txtID.Focus();

        }

        private void rdoDrink_CheckedChanged(object sender, EventArgs e)
        {
            //txtID.Text = "D";
            txtID.Focus();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
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
            txtID.Enabled = !ena;
            txtName.Enabled = !ena;
            rdoFood.Enabled = !ena;
            rdoDrink.Enabled = !ena;
        }

        void SetEnaID(bool ena)
        {
            txtID.Enabled = ena;
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            _IsEdit = false;
            SetEnable(false);
            rdoFood.Checked = rdoDrink.Checked = false;
            txtID.Text = txtName.Text = "";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!Kiemtra()) return;
            if (!_IsEdit)
            {
                if (rdoFood.Checked) // food la 1 . drink la 0
                    loai = 1;
                type.Them_Loai(txtID.Text, txtName.Text, loai);
                Load_Type();
                MessageBox.Show("Insert Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Text = txtID.Text = "";
                rdoFood.Focus();
            }
            else
            {
                if (rdoFood.Checked) // food la 1 . drink la 0
                    loai = 1;
                type.Sua_Type(txtID.Text, txtName.Text, loai);
                Load_Type();
                MessageBox.Show("Modify Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = txtName.Text = "";
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
                if (txtID.Text == "")
                {
                    MessageBox.Show("Please select Typr  !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                type.Xoa_type(txtID.Text);
                Load_Type();
                MessageBox.Show("Delete Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = txtName.Text = "";
            }
            catch
            {
                MessageBox.Show("System can't delete " + txtName.Text + " ! Because this is table print bill", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TypeDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            TypeDataGridView.ClearSelection();
        }
    }
}
