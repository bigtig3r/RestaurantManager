using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLCF
{
    public partial class frmUser : Form
    {
        BusinessLayer.User user = new BusinessLayer.User();
        string role, permission, pm;
        public frmUser()
        {
            InitializeComponent();
        }
        public frmUser( string _role)
        {
            InitializeComponent();
            role = _role;
        }

        public void Load_User()
        {
            dataGridViewTK.DataSource = user.LoadUser();
        }

        public void Load_User_Hide()
        {
            dataGridViewTK.DataSource = user.LoadUser_Hide();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;
                txtID.Text = dataGridViewTK.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTen.Text = dataGridViewTK.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMK.Text = dataGridViewTK.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMK2.Text = txtMK.Text;
                txtHoTen.Text = dataGridViewTK.Rows[e.RowIndex].Cells[3].Value.ToString();
                permission = dataGridViewTK.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (permission == "1")
                    rdoQuanLy.Checked = true;
                if (permission == "2")
                    rdoNhanVien.Checked = true;

                txtHoTen.Focus();
            }
            catch
            { }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            Load_User_Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show("Please ! Enter username !","Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMK.Text == "")
            {
                MessageBox.Show("Please ! Enter password !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Please ! Enter fullname !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rdoNhanVien.Checked == false && rdoQuanLy.Checked == false)
            {
                MessageBox.Show("Please ! Select Permission !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMK.Text != txtMK2.Text)
            {
                MessageBox.Show("Please ! Check Password !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if(rdoQuanLy.Checked)
                    pm = "1";
                if(rdoNhanVien.Checked)
                    pm = "2";

                string pass = user.Encrypt(txtMK.Text);
                user.Add(txtTen.Text, pass, pm, txtHoTen.Text);
                Load_User_Hide();
                MessageBox.Show("Insert Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error '" + ex + "'!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtMK2_TextChanged(object sender, EventArgs e)
        {
            if (txtMK.Text == txtMK2.Text)
            {
                lblOk.Visible = true;
            }
            if (txtMK2.Text == "")
            {
                lblOk.Visible = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoQuanLy.Checked)
                    pm = "1";
                if (rdoNhanVien.Checked)
                    pm = "2";

                string pass = user.Encrypt(txtMK.Text);
                user.Edit(txtID.Text, txtTen.Text, pass, pm, txtHoTen.Text);
                Load_User_Hide();
                txtHoTen.Focus();
                MessageBox.Show("Modify Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : '" + ex + "'!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                user.Delete(txtID.Text);
                Load_User_Hide();
                MessageBox.Show("Delete Successfull ! !", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex + " ! ", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
