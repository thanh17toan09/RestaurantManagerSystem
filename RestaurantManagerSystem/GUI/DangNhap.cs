using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RestaurantManagerSystem.DTO;
using RestaurantManagerSystem.BUS;

namespace RestaurantManagerSystem.GUI
{
    public partial class frmDangNhap : Office2007Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            tbTenDN.Text = "";
            tbMatKhau.Text = "";
        }
        public void DangNhap()
        {
            if (tbTenDN.Text == "")
            {
                MessageBoxEx.Show("Tên đang nhập không được rỗng!");
            }
            else if (tbMatKhau.Text == "")
            {
                MessageBoxEx.Show("Mật khẩu không được rỗng!");
            }
            else
            {
                DataTable _ds = NhanVienBUS.LayDSNhanVienCoMK();
                bool flag = false;
                for (int i = 0; i < _ds.Rows.Count ; i++)
                {
                    if (tbTenDN.Text == _ds.Rows[i]["TenDN"].ToString() && tbMatKhau.Text == _ds.Rows[i]["MatKhau"].ToString())
                    {
                        frmMain frmM = new frmMain();
                        frmM.Nv = new NhanVienDTO(int.Parse(_ds.Rows[i]["MaNV"].ToString()), _ds.Rows[i]["HoTen"].ToString(), DateTime.Parse(_ds.Rows[i]["NgaySinh"].ToString()), _ds.Rows[i]["TenDN"].ToString(), _ds.Rows[i]["MatKhau"].ToString(), _ds.Rows[i]["Quyen"].ToString());
                        frmM.Show();
                        this.Hide();
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    MessageBoxEx.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
                    tbMatKhau.Text = "";
                }
            }
        }
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void tbMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void tbTenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbMatKhau.Focus();
            }
        }
    }
}