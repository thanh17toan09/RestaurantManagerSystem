using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RestaurantManagerSystem.GUI;
using RestaurantManagerSystem.DTO;
using RestaurantManagerSystem.BUS;
using RestaurantManagerSystem.Reports;

namespace RestaurantManagerSystem
{
    public partial class frmMain : Office2007Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private NhanVienDTO _nv = new NhanVienDTO();

        public NhanVienDTO Nv
        {
            get { return _nv; }
            set { _nv = value; }
        }
        int flag;
        private void Form1_Load(object sender, EventArgs e)
        {
            DuaLoaiThucDonLenCombobox();
            DuaDSHoaDonLenDataGridView();
            DuaBanLenCombobox();
            DuaDSNhanVienLenCombobox();
            DuaDSNhanVienLenDataGridView();
            DuaDSBanDaGoiLenCombobox();
            DuaDanhSachPhanCongLenDataGridView();
            LoadNhanVienPhanCongLenCombobox();
            LoadThongTinNguoiDung();
            DuaBanPhanCongLenCombobox();
            DuaLoaiTDLenCombobox();
            diNgaySinh.MaxDate = DateTime.Today;
            dtiNgayAD.MaxDate = DateTime.Today;
        }
        public void DuaBanLenCombobox()
        {
            List<BanDTO> _dsban = BanBUS.LayDSBan();
            List<int> _dsBanDaDat = HoaDonBUS.LayDSBanChuaThanhToan();
            List<int> _dsTam = new List<int>();
            for (int i = 0; i < _dsban.Count; i++)
            {
                bool flag = false;
                for (int j = 0; j < _dsBanDaDat.Count; j++)
                {
                    if (_dsban[i].MaBan == _dsBanDaDat[j])
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    _dsTam.Add(int.Parse(_dsban[i].MaBan.ToString()));
                }
            }
            cmbBan.DataSource = _dsTam;
        }

        public void DuaDSBanDaGoiLenCombobox()
        {
            cmbDSBanCanLapHD.Items.Clear();
            cmbDSBanCapNhat.Items.Clear();
            cmbDSBanCanLapHD.Text = "";
            cmbDSBanCapNhat.Text = "";
            List<int> _dsMaBan = HoaDonBUS.LayDSBanChuaThanhToan();
            for (int i = 0; i < _dsMaBan.Count; i++)
            {
                cmbDSBanCanLapHD.Items.Add(_dsMaBan[i].ToString());
                cmbDSBanCapNhat.Items.Add(_dsMaBan[i].ToString());
            }
        }
        private void LoadThongTinNguoiDung()
        {
            lbTenDN.Text = Nv.TenDN.ToString();
            lbHoTen.Text = Nv.HoTen.ToString();
            lbQuyen.Text = Nv.Quyen.ToString();
        }
        public void DuaLoaiThucDonLenCombobox()
        {
            List<LoaiThucDonDTO> _dsltd = LoaiThucDonBUS.LayDSLoaiThucDon();
            cmbLoaiTD.DataSource = _dsltd;
            cmbLoaiTD.DisplayMember = "TenLoai";
            cmbLoaiTD.ValueMember = "MaLoai";

            cbLoaiTD.DataSource = _dsltd;
            cbLoaiTD.DisplayMember = "TenLoai";
            cbLoaiTD.ValueMember = "MaLoai";

            cmbLoaiTDCN.DataSource = _dsltd;
            cmbLoaiTDCN.DisplayMember = "TenLoai";
            cmbLoaiTDCN.ValueMember = "MaLoai";            
        }

        public void DuaLoaiTDLenCombobox()
        {
            List<LoaiThucDonDTO> _dsltd = LoaiThucDonBUS.LayDSLoaiThucDon();
            cmbLoaiThucDon.DataSource = _dsltd;
            cmbLoaiThucDon.DisplayMember = "TenLoai";
            cmbLoaiThucDon.ValueMember = "MaLoai";
            
        }        
        
        public void DuaDSNhanVienLenCombobox()
        {
            DataTable _dsNV = NhanVienBUS.LayDSNhanVienTiepTan();
            cmbDSNhanVien.DataSource = _dsNV;
            cmbDSNhanVien.DisplayMember = "Họ Tên";
            cmbDSNhanVien.ValueMember = "Mã NV";
        }
        public void DuaDSHoaDonLenDataGridView()
        {
            DataTable _dshd = HoaDonBUS.LayDSHoaDon();
            dtgDSHD.DataSource = _dshd;
        }
        public void DuaDSNhanVienLenDataGridView()
        {
            DataTable _dsnd = NhanVienBUS.LayDSNhanVien();
            dtgDSNV.DataSource = _dsnd;
        }
        private void cmbLoaiTD_SelectedValueChanged(object sender, EventArgs e)
        {
            List<ThucDonDTO> _dstd = new List<ThucDonDTO>();
            string tenLoai = cmbLoaiTD.Text.ToString();
            int maLoaiTD = LoaiThucDonBUS.LayMaLoaiTuTenLoai(tenLoai);
            _dstd = ThucDonBUS.LayDSThucDonTheoMaLoai(maLoaiTD);
            lbDSTD.DataSource = _dstd;
            lbDSTD.DisplayMember = "TenTD";
            lbDSTD.ValueMember = "MaTD";
            tbDonGia.Text = "";
            lbGiaTK.Text = "0";
        }

        private void btThemTDVaoList_Click(object sender, EventArgs e)
        {
            if (tbDonGia.Text != "")
            {
                int maTD = int.Parse(lbDSTD.SelectedValue.ToString());
                string tenTD = ThucDonBUS.LayTenThucDonTuMaThucDon(maTD);
                bool tonTai = false;
                int dong = 0;
                for (int i = 0; i < lvChiTietGoiMon.Items.Count; i++)
                {
                    if (int.Parse(lvChiTietGoiMon.Items[i].SubItems[0].Text) == maTD)
                    {
                        tonTai = true;
                        dong = i;
                    }
                }
                string soLuong = "1";
                if (tbSL.Text != "")
                {
                    soLuong = tbSL.Text;
                }
                if (tonTai == false)
                {
                    string donGia = tbDonGia.Text;
                    ListViewItem item = new ListViewItem();
                    item.Text = maTD.ToString();
                    item.SubItems.Add(tenTD);
                    item.SubItems.Add(donGia);
                    item.SubItems.Add(soLuong);
                    this.lvChiTietGoiMon.Items.Add(item);
                    tbSL.Text = "1";
                }
                else
                {
                    int sl = int.Parse(lvChiTietGoiMon.Items[dong].SubItems[3].Text) + int.Parse(soLuong);
                    lvChiTietGoiMon.Items[dong].SubItems[3].Text = sl.ToString();
                }
            }
            else
            {
                MessageBoxEx.Show("Bạn nhập giá không chính xác!");
            }
        }

        private void tbSL_Click(object sender, EventArgs e)
        {
            tbSL.Text = "";
        }

        private void btXoaTDDuocChon_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa thực đơn này không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    lvChiTietGoiMon.FocusedItem.Remove();
                } 
            }
            catch
            {
                MessageBoxEx.Show("Vui lòng chọn ĐT cần xóa!");
            }
        }

        private void btXoaDSTD_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa hết danh sách không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
            if (result == DialogResult.Yes)
            {
                lvChiTietGoiMon.Items.Clear();
            } 
        }       

        private void btTinhTien_Click(object sender, EventArgs e)
        {
            if (cmbDSBanCanLapHD.Text == "")
                MessageBox.Show("Chưa chọn bàn cần tính!");
            else
            {
                double tongTien = 0;
                for (int i = 0; i < lvDSCTGMCanLapHD.Items.Count; i++)
                {
                    double donGia = double.Parse(lvDSCTGMCanLapHD.Items[i].SubItems[1].Text);
                    int soLuong = int.Parse(lvDSCTGMCanLapHD.Items[i].SubItems[2].Text);
                    tongTien += donGia * soLuong;
                }
                lbTongTien.Text = tongTien.ToString();
            }
        }        

        private void dtgDSHD_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = dtgDSHD.CurrentRow.Index;
                int maHD = int.Parse(dtgDSHD.Rows[idx].Cells[0].Value.ToString());
                DataTable _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(maHD);
                dtgDSCTHD.DataSource = _ds;
            }
            catch { }
                   
        }

        private void btXoaTDDuocChonCN_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa thực đơn này không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    lvChiTietGoiMonCN.FocusedItem.Remove();
                } 
            }
            catch
            {
                MessageBoxEx.Show("Vui lòng chọn ĐT cần xóa!");
            }
        }

        private void btXoaDSTDCN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa hết danh sách không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
            if (result == DialogResult.Yes)
            {
                lvChiTietGoiMonCN.Items.Clear();
            }
            
        }

       

        private void cmbLoaiTDCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ThucDonDTO> _dstd = new List<ThucDonDTO>();
            string tenLoai = cmbLoaiTDCN.Text.ToString();
            int maLoaiTD = LoaiThucDonBUS.LayMaLoaiTuTenLoai(tenLoai);
            _dstd = ThucDonBUS.LayDSThucDonTheoMaLoai(maLoaiTD);
            lbDSTDCN.DataSource = _dstd;
            lbDSTDCN.DisplayMember = "TenTD";
            lbDSTDCN.ValueMember = "MaTD";
            tbDonGiaCN.Text = "";
            lbGiaTKCN.Text = "0";
        }

        private void btThemTDVaoListCN_Click(object sender, EventArgs e)
        {
            if (cmbDSBanCapNhat.Text != "")
            {
                if (tbDonGiaCN.Text != "")
                {
                    int maTD = int.Parse(lbDSTDCN.SelectedValue.ToString());
                    string tenTD = ThucDonBUS.LayTenThucDonTuMaThucDon(maTD);
                    bool tonTai = false;
                    int dong = 0;
                    for (int i = 0; i < lvChiTietGoiMonCN.Items.Count; i++)
                    {
                        if (lvChiTietGoiMonCN.Items[i].SubItems[0].Text == tenTD)
                        {
                            tonTai = true;
                            dong = i;
                        }
                    }
                    string soLuong = "1";
                    if (tbSL.Text != "")
                    {
                        soLuong = tbSL.Text;
                    }
                    if (tonTai == false)
                    {
                        string donGia = tbDonGiaCN.Text;
                        ListViewItem item = new ListViewItem();
                        item.Text = tenTD;
                        item.SubItems.Add(donGia);
                        item.SubItems.Add(soLuong);
                        this.lvChiTietGoiMonCN.Items.Add(item);
                        tbSL.Text = "1";
                    }
                    else
                    {
                        int sl = int.Parse(lvChiTietGoiMonCN.Items[dong].SubItems[2].Text) + int.Parse(soLuong);
                        lvChiTietGoiMonCN.Items[dong].SubItems[2].Text = sl.ToString();
                    }
                }
                else
                {
                    MessageBoxEx.Show("Bạn nhập giá không chính xác!");
                }
            }
            else
            {
                MessageBoxEx.Show("Chưa chọn bàn cần cập nhật!");
            }    
        }
        
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
            }
        }

        private void dtgDSNV_Click(object sender, EventArgs e)
        {
            int idx = dtgDSNV.CurrentRow.Index;
            tbHoTen.Text = dtgDSNV.Rows[idx].Cells[1].Value.ToString();
            diNgaySinh.Text = dtgDSNV.Rows[idx].Cells[2].Value.ToString();
            tbTenDN.Text = dtgDSNV.Rows[idx].Cells[3].Value.ToString();
            cmbQuyen.Text = dtgDSNV.Rows[idx].Cells[4].Value.ToString();
            if (cmbQuyen.Text == "Admin")
            {
                tbTenDN.ReadOnly= false;
                tbMatKhau.ReadOnly = false;
                tbMatKhau2.ReadOnly = false;
                cmbQuyen.Enabled = false;
            }
            else
                cmbQuyen.Enabled = true;
            string MatKhau = NhanVienBUS.LayMatKhauTuTenDN(dtgDSNV.Rows[idx].Cells[3].Value.ToString());
            tbMatKhau.Text = MatKhau;
            tbMatKhau2.Text = tbMatKhau.Text;
        }

        //private void dtgDSNV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e.ColumnIndex == 4)
        //    {
        //        e.Value = new string('*', e.Value.ToString().Length);
        //    }
        //}
        public void ThemNhanVien()
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.HoTen = tbHoTen.Text;
            nv.NgaySinh = DateTime.Parse(diNgaySinh.Text);
            nv.TenDN = tbTenDN.Text;
            nv.MatKhau = tbMatKhau.Text;
            nv.Quyen = cmbQuyen.Text;
            if (!NhanVienBUS.KiemTraTenDNTonTai(nv.TenDN, nv.MaNV))
            {
                bool kq = NhanVienBUS.ThemNhanVien(nv);
                if (kq == true)
                {
                    MessageBoxEx.Show("Thêm người dùng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DuaDSNhanVienLenDataGridView();
                    tbTenDN.Text = "";
                    tbMatKhau.Text = "";
                    tbMatKhau2.Text = "";
                    tbHoTen.Text = "";
                    cmbQuyen.Text = "Tiếp Tân";
                }
                else
                {
                    MessageBoxEx.Show("Thêm thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBoxEx.Show("Tên đăng nhập này đã tồn tại!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btThemND_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                if (cmbQuyen.Text != "Tiếp Tân")
                {
                    if (tbTenDN.Text.Length >=6 && tbTenDN.Text.Length <=20)
                    {
                        if (tbHoTen.Text != "")
                        {
                            if (tbMatKhau.Text.Length >=6 && tbMatKhau.Text.Length <=20)
                            {
                                if (tbMatKhau.Text == tbMatKhau2.Text)
                                {
                                    if (diNgaySinh.Text != "")
                                    {
                                        ThemNhanVien();
                                    }
                                    else
                                    {
                                        MessageBoxEx.Show("Ngày sinh không được rỗng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBoxEx.Show("Mật khẩu không trùng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbMatKhau2.Text = "";
                                    tbMatKhau2.Focus();
                                }
                            }
                            else
                            {
                                MessageBoxEx.Show("Mật khẩu phải lớn hơn 5 và nhỏ hơn 21 ký tự!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbMatKhau.Text = "";
                                tbMatKhau.Focus();
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("Họ tên không được rỗng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbHoTen.Focus();
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Tên Đăng nhập phải lớn hơn 5 và nhỏ hơn 21 ký tự!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbTenDN.Text = "";
                        tbTenDN.Focus();
                    }
                }
                else
                {
                    if (tbHoTen.Text != "")
                    {
                        if (diNgaySinh.Text != "")
                        {
                            ThemNhanVien();
                        }
                        else
                        {
                            MessageBoxEx.Show("Ngày sinh không được rỗng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Họ tên nhân viên không được rỗng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbHoTen.Focus();
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SuaNhanVien()
        {
            NhanVienDTO nv = new NhanVienDTO();
            int idx = dtgDSNV.CurrentRow.Index;
            nv.MaNV = int.Parse(dtgDSNV.Rows[idx].Cells[0].Value.ToString());
            nv.HoTen = tbHoTen.Text;
            nv.NgaySinh = DateTime.Parse(diNgaySinh.Text);
            nv.TenDN = tbTenDN.Text;
            nv.MatKhau = tbMatKhau.Text;
            nv.Quyen = cmbQuyen.Text;
            if (!NhanVienBUS.KiemTraTenDNTonTai(nv.TenDN, nv.MaNV))
            {
                bool kq = NhanVienBUS.CapNhatNhanVien(nv);
                if (kq == true)
                {
                    MessageBoxEx.Show("Cập nhật thông tin người dùng thành công!");
                    DuaDSNhanVienLenDataGridView();
                    tbTenDN.Text = "";
                    tbMatKhau.Text = "";
                    tbMatKhau2.Text = "";
                    tbHoTen.Text = "";
                    cmbQuyen.Text = "Tiếp Tân";
                }
                else
                {
                    MessageBoxEx.Show("Cập nhật thất bại!");
                }
            }
            else
                MessageBoxEx.Show("Tên đăng nhập này đã tồn tại!");              
        }
        private void btSuaND_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                if (cmbQuyen.Text != "Tiếp Tân")
                {
                    if (tbTenDN.Text.Length >= 6 && tbTenDN.Text.Length <= 20)
                    {
                        if (tbHoTen.Text != "")
                        {
                            if (tbMatKhau.Text.Length >= 6 && tbMatKhau.Text.Length <= 20)
                            {
                                if (tbMatKhau.Text == tbMatKhau2.Text)
                                {
                                    if (diNgaySinh.Text != "")
                                    {
                                        SuaNhanVien();
                                    }
                                    else
                                    {
                                        MessageBoxEx.Show("Ngày sinh không được rỗng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBoxEx.Show("Mật khẩu không trùng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbMatKhau2.Text = "";
                                    tbMatKhau2.Focus();
                                }
                            }
                            else
                            {
                                MessageBoxEx.Show("Mật khẩu phải lớn hơn 5 và nhỏ hơn 21 ký tự!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbMatKhau.Text = "";
                                tbMatKhau.Focus();
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("Họ tên nhân viên không được rỗng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbHoTen.Focus();
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Tên Đăng nhập phải lớn hơn 5 và nhỏ hơn 21 ký tự!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbTenDN.Text = "";
                        tbTenDN.Focus();
                    }
                }
                else
                {
                    if (tbHoTen.Text != "")
                    {
                        if (diNgaySinh.Text != "")
                        {
                            SuaNhanVien();
                        }
                        else
                        {
                            MessageBoxEx.Show("Ngày sinh không được rỗng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Họ tên nhân viên không được rỗng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btXoaND_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                int idx = dtgDSNV.CurrentRow.Index;
                int maNV = int.Parse(dtgDSNV.Rows[idx].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    string quyen = NhanVienBUS.LayQuyenNVTheoMaNV(maNV);
                    if (quyen != "Admin")
                    {
                        bool kq;
                        try
                        {
                            kq = NhanVienBUS.XoaNhanVien(maNV);
                            if (kq == true)
                            {
                                MessageBoxEx.Show("Đã xóa nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DuaDSNhanVienLenDataGridView();
                                tbTenDN.Text = "";
                                tbMatKhau.Text = "";
                                tbMatKhau2.Text = "";
                                tbHoTen.Text = "";
                            }
                            else
                                MessageBoxEx.Show("Xóa nhân viên thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch
                        {
                            MessageBoxEx.Show("Nhân viên đang được phân công không thể xóa!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBoxEx.Show("Không thể xóa tài khoản Admin!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQuyen.Text == "Tiếp Tân")
            {
                tbTenDN.Text = "";
                tbMatKhau.Text = "";
                tbMatKhau2.Text = "";
                tbTenDN.ReadOnly = true;
                tbMatKhau.ReadOnly = true;
                tbMatKhau2.ReadOnly = true;
            }
            else
            {
                tbTenDN.ReadOnly = false;
                tbMatKhau.ReadOnly = false;
                tbMatKhau2.ReadOnly = false;
            }
        }

        private void btLuuGoiMon_Click(object sender, EventArgs e)
        {
            if (lvChiTietGoiMon.Items.Count > 0)
            {
                if (tbSoKhach.Text != "")
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    CT_HoaDonDTO cthd = new CT_HoaDonDTO();
                    hd.MsBan = int.Parse(cmbBan.Text);
                    int maHD = HoaDonBUS.LayMaHoaDonCanLap();
                    hd.TongTien = 0;
                    hd.MsNVLap = _nv.MaNV;
                    
                    hd.MsNVTT = _nv.MaNV;
                    try
                    {
                        int soKhach = int.Parse(tbSoKhach.Text);
                        if (soKhach > 0)
                        {
                            hd.SoKhach = soKhach;

                            bool kq = HoaDonBUS.LapHoaDon(hd);
                            if (kq == true)
                            {
                                for (int i = 0; i < lvChiTietGoiMon.Items.Count; i++)
                                {
                                    cthd.SoHD = hd.SoHD;
                                    cthd.MaTD = int.Parse(lvChiTietGoiMon.Items[i].SubItems[0].Text);
                                    cthd.DonGia = double.Parse(lvChiTietGoiMon.Items[i].SubItems[2].Text);
                                    cthd.SoLuong = int.Parse(lvChiTietGoiMon.Items[i].SubItems[3].Text);
                                    CT_HoaDonBUS.ThemChiTietHoaDon(cthd);
                                }
                                MessageBoxEx.Show("Lưu gọi món thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DuaDSBanDaGoiLenCombobox();
                                DuaBanLenCombobox();
                                lvChiTietGoiMon.Items.Clear();
                                tbDonGia.Text = "";
                                tbSoKhach.Text = "";
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("Số khách phải lớn hơn 0!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbSoKhach.Text = "";
                            tbSoKhach.Focus();
                        }
                    }
                    catch
                    {
                        MessageBoxEx.Show("Kiểu dữ liệu số khách không đúng!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbSoKhach.Text = "";
                        tbSoKhach.Focus();
                    }
                }
                else
                {
                    MessageBoxEx.Show("Chưa nhập số lượng khách!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbSoKhach.Text = "";
                    tbSoKhach.Focus();
                }
            }
            else
            {
                MessageBoxEx.Show("Chưa chọn thực đơn!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDSBanCanLapHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDSNhanVien.Text = "";
            lvDSCTGMCanLapHD.Items.Clear();
            DataTable _ds = new DataTable();
            int maBan = int.Parse(cmbDSBanCanLapHD.Text);
            int maHD = HoaDonBUS.LaySoHDTuMaBan(maBan);
            _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(maHD);
            for (int i = 0; i < _ds.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = _ds.Rows[i]["Tên TĐ"].ToString();
                item.SubItems.Add(_ds.Rows[i]["Đơn Giá"].ToString());
                item.SubItems.Add(_ds.Rows[i]["Số Lượng"].ToString());
                lvDSCTGMCanLapHD.Items.Add(item);
            }

            int gioLap = HoaDonBUS.LayGioLapHDChuaThanhToanTheoMaBan(maBan);
            int ca = PhanCongBUS.LayCaTheoGio(gioLap);
            int maNV = PhanCongBUS.LayMaNVTheoMaBanVaCa(maBan, ca);

            string tenNV = NhanVienBUS.LayTenNVTheoMaNV(maNV);
            cmbDSNhanVien.Text = tenNV;
        }

        private void btLapHD_Click(object sender, EventArgs e)
        {
            if (lvDSCTGMCanLapHD.Items.Count > 0)
            {
                if (cmbDSNhanVien.Text == "")
                    MessageBoxEx.Show("Chưa chọn nhân viên tiếp tân!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (lbTongTien.Text == "0")
                        MessageBoxEx.Show("Chưa tính tổng tiền!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        HoaDonDTO hd = new HoaDonDTO();
                        hd.MsNVTT = int.Parse(cmbDSNhanVien.SelectedValue.ToString());
                        hd.MsBan = int.Parse(cmbDSBanCanLapHD.Text);
                        hd.SoHD = HoaDonBUS.LaySoHDTuMaBan(hd.MsBan);
                        hd.TongTien = double.Parse(lbTongTien.Text);
                        bool kq = HoaDonBUS.CapNhatLapHoaDon(hd);
                        if (kq == true)
                        {
                            MessageBoxEx.Show("Lập hóa đơn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DuaDSHoaDonLenDataGridView();
                            DuaBanLenCombobox();
                            lvDSCTGMCanLapHD.Items.Clear();
                            DuaDSBanDaGoiLenCombobox();
                            lbTongTien.Text = "0";
                            DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn này ra không!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                            if (result == DialogResult.Yes)
                            {

                                ViewHoaDon frm = new ViewHoaDon();
                                frm.SoHD = hd.SoHD;
                                frm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("Lập hóa đơn thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("Chưa chọn bàn!");
            }

        }

        private void lbDSTD_Click(object sender, EventArgs e)
        {
            int maTD = int.Parse(lbDSTD.SelectedValue.ToString());
            double gia = GiaBUS.LayGiaTheoMaThucDon(maTD);
            lbGiaTK.Text = gia.ToString();
            tbDonGia.Text = Convert.ToString(double.Parse(lbGiaTK.Text) - (double.Parse(cmbKhuyenMai.Text) / 100) * double.Parse(lbGiaTK.Text));
        }

        private void cmbDSBanCapNhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SoHD = HoaDonBUS.LaySoHDTuMaBan(int.Parse(cmbDSBanCapNhat.SelectedItem.ToString()));
            DataTable _ds = new DataTable();
            _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(SoHD);
            lvChiTietGoiMonCN.Items.Clear();
            int soKhach = HoaDonBUS.LaySoKhachTuSoHD(SoHD);
            tbSoKhachCN.Text = soKhach.ToString();
            for (int i = 0; i < +_ds.Rows.Count; i++)
            {
                ListViewItem li = new ListViewItem();
                li.Text = _ds.Rows[i]["Tên TĐ"].ToString();
                li.SubItems.Add(_ds.Rows[i]["Đơn Giá"].ToString());
                li.SubItems.Add(_ds.Rows[i]["Số Lượng"].ToString());
                lvChiTietGoiMonCN.Items.Add(li);
            }
        }

        private void btCapNhatGoiMon_Click(object sender, EventArgs e)
        {
            if (lvChiTietGoiMonCN.Items.Count > 0)
            {
                if (tbSoKhachCN.Text != "")
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    CT_HoaDonDTO cthd = new CT_HoaDonDTO();
                    hd.MsBan = int.Parse(cmbDSBanCapNhat.Text);
                    hd.SoKhach = int.Parse(tbSoKhachCN.Text);
                    hd.SoHD = HoaDonBUS.LaySoHDTuMaBan(int.Parse(cmbDSBanCapNhat.Text));
                    HoaDonBUS.CapNhatSoKhach(hd.SoKhach, hd.SoHD);
                    bool kq = CT_HoaDonBUS.XoaCTHDTheoSoHD(hd.SoHD);

                    for (int i = 0; i < lvChiTietGoiMonCN.Items.Count; i++)
                    {
                        cthd.SoHD = hd.SoHD;
                        cthd.MaTD = ThucDonBUS.LayMaThucDonTuTenThucDon(lvChiTietGoiMonCN.Items[i].SubItems[0].Text);
                        cthd.DonGia = double.Parse(lvChiTietGoiMonCN.Items[i].SubItems[1].Text);
                        cthd.SoLuong = int.Parse(lvChiTietGoiMonCN.Items[i].SubItems[2].Text);
                        CT_HoaDonBUS.ThemChiTietHoaDon(cthd);
                    }
                    if (kq == true)
                    {
                        MessageBoxEx.Show("Cập nhật gọi món thành công!");
                        DuaDSBanDaGoiLenCombobox();
                        DuaBanLenCombobox();
                        lvChiTietGoiMonCN.Items.Clear();
                        tbDonGia.Text = "";
                    }
                }
                else
                {
                    MessageBoxEx.Show("Nhập số lượng khách!");
                }
            }
            else
            {
                MessageBoxEx.Show("Chưa chọn thực đơn!");
            }
        }

        private void lbDSTDCN_Click(object sender, EventArgs e)
        {
            int maTD = int.Parse(lbDSTDCN.SelectedValue.ToString());
            double gia = GiaBUS.LayGiaTheoMaThucDon(maTD);
            lbGiaTKCN.Text = gia.ToString();
            tbDonGiaCN.Text = Convert.ToString(double.Parse(lbGiaTKCN.Text) - (double.Parse(cmbKhuyenMaiCN.Text) / 100) * double.Parse(lbGiaTKCN.Text));
        }

        private void btTKTheoNgay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay = dtNgayPC.Value;
                DataTable kq = HoaDonBUS.ThongKeHDTheoNgay(ngay);
                dgvThongKe.DataSource = kq;
                ThongKe(kq);
                if (kq.Rows.Count > 0)
                    flag = 1;
                else
                    flag = 0;
            }
            catch
            {
                MessageBoxEx.Show("Mời chọn ngày cần thống kê!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btTKTheoThang_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(cbThangTK.Text);
                int nam = int.Parse(tbNamTK.Text);
                DataTable dt = HoaDonBUS.ThongKeHDTheoThang(thang, nam);
                dgvThongKe.DataSource = dt;
                ThongKe(dt);
                if (dt.Rows.Count > 0)
                    flag = 2;
                else
                    flag = 0;
            }
            catch
            {
                MessageBoxEx.Show("Mời chọn tháng cần thống kê!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DuaDanhSachPhanCongLenDataGridView()
        {
            DataTable dt = PhanCongBUS.LayDSPhanCong();
            dgvDSPhanCong.DataSource = dt;
        }
        public void LoadNhanVienPhanCongLenCombobox()
        {
            DataTable dt = NhanVienBUS.LayDSNhanVienTiepTan();
            cmbNhanVienPC.DataSource = dt;
            cmbNhanVienPC.DisplayMember = "Họ Tên";
            cmbNhanVienPC.ValueMember = "Mã NV";
        }
        public void DuaBanPhanCongLenCombobox()
        {
            List<BanDTO> dt = new List<BanDTO>(); 
            dt = BanBUS.LayDSBan();
            cmbBanPC.DataSource = dt;
            cmbBanPC.DisplayMember = "MaBan";
            cmbBanPC.ValueMember = "MaBan";
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                try
                {
                    if (cmbNhanVienPC.Text != "")
                    {
                        if (cmbCa.Text != "")
                        {
                            if (cmbBanPC.Text != "")
                            {
                                PhanCongDTO pc = new PhanCongDTO();
                                pc.Ca = int.Parse(cmbCa.Text);
                                pc.MsNV = int.Parse(cmbNhanVienPC.SelectedValue.ToString());
                                pc.MsBan = int.Parse(cmbBanPC.Text);                                    

                                bool kq = PhanCongBUS.ThemPhanCong(pc);
                                if (kq == true)
                                {
                                    MessageBoxEx.Show("Phân công nhân viên thành công!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DuaDanhSachPhanCongLenDataGridView();
                                }
                                else
                                {
                                    MessageBoxEx.Show("Phân công thất bại!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                                MessageBoxEx.Show("Chưa chọn bàn!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBoxEx.Show("Chưa chọn ca!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBoxEx.Show("Chưa chọn nhân viên!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBoxEx.Show("Phân công này đã có rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btXoaPC_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                PhanCongDTO pc = new PhanCongDTO();
                int idx = dgvDSPhanCong.CurrentRow.Index;                
                pc.Ca = int.Parse(dgvDSPhanCong.Rows[idx].Cells[0].Value.ToString());
                pc.MsNV = NhanVienBUS.LayMaNVTuTenNV(dgvDSPhanCong.Rows[idx].Cells[1].Value.ToString());
                pc.MsBan = int.Parse(dgvDSPhanCong.Rows[idx].Cells[2].Value.ToString());

                DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    bool kq = PhanCongBUS.XoaPhanCong(pc);
                    if (kq == true)
                    {
                        MessageBoxEx.Show("Xóa phân công thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DuaDanhSachPhanCongLenDataGridView();
                    }
                    else
                    {
                        MessageBoxEx.Show("Xóa phân công thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btTKTheoKhoangNgay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtiTuNgay.Value;
                DateTime denNgay = dtiDenNgay.Value;

                DataTable dt = HoaDonBUS.ThongKeHDTheoKhoangNgay(tuNgay, denNgay);
                dgvThongKe.DataSource = dt;
                ThongKe(dt);
                if (dt.Rows.Count > 0)
                    flag = 3;
                else
                    flag = 0;
            }
            catch
            {
                MessageBoxEx.Show("Chưa chọn mốc ngày thống kê!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        
        private void cbLoaiTD_SelectedValueChanged(object sender, EventArgs e)
        {
            int maLoai = LoaiThucDonBUS.LayMaLoaiTuTenLoai(cbLoaiTD.Text);
            DataTable dsTD = ThucDonBUS.LayDanhSachTDTheoMaLoai(maLoai);
            dgvDSThucDon.DataSource = dsTD;
            tbTenTDTraCuu.Text = "";
        }

        private void dgvDSThucDon_Click(object sender, EventArgs e)
        {
            int idx = dgvDSThucDon.CurrentRow.Index;
            tbTenTD.Text = dgvDSThucDon.Rows[idx].Cells[1].Value.ToString();
            tbDonGiaTD.Text = dgvDSThucDon.Rows[idx].Cells[2].Value.ToString();
            dtiNgayAD.Text = dgvDSThucDon.Rows[idx].Cells[3].Value.ToString();
            tbDVT.Text = dgvDSThucDon.Rows[idx].Cells[4].Value.ToString();
            cmbLoaiThucDon.Text = dgvDSThucDon.Rows[idx].Cells[5].Value.ToString();
        }

        public void ThemThucDon()
        {
            ThucDonDTO td = new ThucDonDTO();
            GiaDTO g = new GiaDTO();
            td.MaTD = ThucDonBUS.MaTuTang();
            td.MaLoai = LoaiThucDonBUS.LayMaLoaiTuTenLoai(cbLoaiTD.Text);
            td.TenTD = tbTenTD.Text;
            td.DonViTinh = tbDVT.Text;

            g.MaTD = td.MaTD;
            g.NgayADGia = dtiNgayAD.Value;
            
            try
            {
                g.Gia = double.Parse(tbDonGiaTD.Text);
                bool kt = ThucDonBUS.KiemTraTrungTenThucDon(td.TenTD);
                if (kt == true)
                {
                    bool kq1 = ThucDonBUS.ThemThucDon(td);
                    bool kq2 = GiaBUS.ThemGia(g);
                    if (kq1 == true && kq2 == true)
                        MessageBoxEx.Show("Thêm thực đơn thành công!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBoxEx.Show("Thực đơn này đã có!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBoxEx.Show("Kiểu dữ liệu nhập đơn giá không chính xác! Vui lòng nhập lại đơn giá!");
            }            
        }

        private void btThemTD_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                if (tbTenTD.Text != "")
                {
                    if (tbDonGiaTD.Text != "")
                    {
                        if (dtiNgayAD.Text != "")
                        {
                            if (tbDVT.Text != "")
                            {
                                ThemThucDon();
                            }
                            else
                                MessageBoxEx.Show("Chưa nhập đơn vị tính!");
                        }
                        else
                            MessageBoxEx.Show("Chưa nhập ngày áp dụng đơn giá!");
                    }
                    else
                        MessageBoxEx.Show("Chưa nhập đơn giá!");
                }
                else
                    MessageBoxEx.Show("Chưa nhập tên thực đơn!");
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(tbDonGia.Text!="")
                    tbDonGia.Text = Convert.ToString(double.Parse(lbGiaTK.Text) - (double.Parse(cmbKhuyenMai.Text) / 100) * double.Parse(lbGiaTK.Text));
            }
            catch{}
        }

        private void cmbKhuyenMaiCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbDonGiaCN.Text = Convert.ToString(double.Parse(lbGiaTKCN.Text) - (double.Parse(cmbKhuyenMaiCN.Text) / 100) * double.Parse(lbGiaTKCN.Text));
        }

        public void ThongKe(DataTable kq)
        {
            if (kq.Rows.Count > 0)
            {
                double tongDoanhThu = 0;
                int tongKhachDen = 0;
                for (int i = 0; i < dgvThongKe.Rows.Count - 1; i++)
                {
                    tongDoanhThu += double.Parse(dgvThongKe.Rows[i].Cells[6].Value.ToString());
                    tongKhachDen += int.Parse(dgvThongKe.Rows[i].Cells[3].Value.ToString());
                }
                lbTongDoanhThu.Text = tongDoanhThu.ToString() + " VNÐ";
                lbSoLuongKhachDen.Text = tongKhachDen.ToString() + " Khách";

                DataTable  _ds = new DataTable();
                _ds.Columns.Add("SoHD", typeof(int));
                _ds.Columns.Add("MaThucDon", typeof(int));
                _ds.Columns.Add("SoLuong", typeof(int));
                _ds.Columns.Add("DonGia", typeof(double));
                _ds.PrimaryKey = new DataColumn[] { _ds.Columns["SoHD"], _ds.Columns["MaThucDon"] };
                for (int i = 0; i < kq.Rows.Count; i++)
                {
                    int SoHD = int.Parse(kq.Rows[i][0].ToString());
                    if (_ds.Rows.Count == 0)
                    {
                        DataTable dtct = CT_HoaDonBUS.LayDSCTHD(SoHD);
                        for (int j = 0; j < dtct.Rows.Count; j++)
                        {
                            DataRow ct = _ds.NewRow();
                            ct[0] = int.Parse(dtct.Rows[j][0].ToString());
                            ct[1] = int.Parse(dtct.Rows[j][1].ToString());
                            ct[2] = int.Parse(dtct.Rows[j][2].ToString());
                            ct[3] = double.Parse(dtct.Rows[j][3].ToString());
                            _ds.Rows.Add(ct);
                        }
                    }
                    else
                    {
                        DataTable dtct = CT_HoaDonBUS.LayDSCTHD(SoHD);
                        for (int j = 0; j < dtct.Rows.Count; j++)
                        {
                            bool kt = false;
                            int dong = 0;
                            for (int k = 0; k < _ds.Rows.Count; k++)
                            {
                                if (dtct.Rows[j][1].ToString() == _ds.Rows[k][1].ToString())
                                {
                                    dong = k;
                                    kt = true;
                                }
                            }
                            if (kt == true)
                            {
                                _ds.Rows[dong][2] = int.Parse(_ds.Rows[dong][2].ToString()) + int.Parse(dtct.Rows[j][2].ToString());
                            }
                            else
                            {
                                DataRow ct = _ds.NewRow();
                                ct[0] = int.Parse(dtct.Rows[j][0].ToString());
                                ct[1] = int.Parse(dtct.Rows[j][1].ToString());
                                ct[2] = int.Parse(dtct.Rows[j][2].ToString());
                                ct[3] = double.Parse(dtct.Rows[j][3].ToString());
                                _ds.Rows.Add(ct);
                            }
                        }
                    }
                }

                DataTable _dstd = new DataTable();
                _dstd.Columns.Add("SoHD", typeof(int));
                _dstd.Columns.Add("MaThucDon", typeof(int));
                _dstd.Columns.Add("SoLuong", typeof(int));
                _dstd.Columns.Add("DonGia", typeof(double));
                _dstd.PrimaryKey = new DataColumn[] { _dstd.Columns["SoHD"], _dstd.Columns["MaThucDon"] };

                DataTable _dstu = new DataTable();
                _dstu.Columns.Add("SoHD", typeof(int));
                _dstu.Columns.Add("MaThucDon", typeof(int));
                _dstu.Columns.Add("SoLuong", typeof(int));
                _dstu.Columns.Add("DonGia", typeof(double));
                _dstu.PrimaryKey = new DataColumn[] { _dstu.Columns["SoHD"], _dstu.Columns["MaThucDon"] };

                for (int i = 0; i < _ds.Rows.Count; i++)
                {
                    if (ThucDonBUS.KiemTraThucAnNuocUong(int.Parse(_ds.Rows[i][1].ToString())))
                    {
                        DataRow ct = _dstd.NewRow();
                        ct[0] = int.Parse(_ds.Rows[i][0].ToString());
                        ct[1] = int.Parse(_ds.Rows[i][1].ToString());
                        ct[2] = int.Parse(_ds.Rows[i][2].ToString());
                        ct[3] = double.Parse(_ds.Rows[i][3].ToString());
                        _dstd.Rows.Add(ct);
                    }
                    else
                    {
                        DataRow ct = _dstu.NewRow();
                        ct[0] = int.Parse(_ds.Rows[i][0].ToString());
                        ct[1] = int.Parse(_ds.Rows[i][1].ToString());
                        ct[2] = int.Parse(_ds.Rows[i][2].ToString());
                        ct[3] = double.Parse(_ds.Rows[i][3].ToString());
                        _dstu.Rows.Add(ct);
                    }
                }

                if (_dstd.Rows.Count > 0)
                {
                    int MaxTD = int.Parse(_dstd.Rows[0][2].ToString());
                    for (int i = 0; i < _dstd.Rows.Count; i++)
                    {
                        int sl = int.Parse(_dstd.Rows[i][2].ToString());
                        if (MaxTD < sl)
                            MaxTD = int.Parse(_dstd.Rows[i][2].ToString());
                    }
                    int y = 0;
                    for (int i = 0; i < _dstd.Rows.Count; i++)
                    {
                        if (MaxTD == int.Parse(_dstd.Rows[i][2].ToString()))
                            y = i;
                    }

                    int MaTD = int.Parse(_dstd.Rows[y][1].ToString()) ;
                    lbSLTDBanNhieuNhat.Text = MaxTD.ToString();
                    lbTDBanNhieuNhat.Text = ThucDonBUS.LayTenThucDonTuMaThucDon(MaTD);
                    lbDVTDBanNhieuNhat.Text = ThucDonBUS.LayDonViTinhTuMaTD(MaTD);
                }

                if (_dstu.Rows.Count > 0)
                {
                    int MaxTU = 0;
                    for (int i = 0; i < _dstu.Rows.Count; i++)
                    {
                        if (MaxTU < int.Parse(_dstu.Rows[i][2].ToString()))
                            MaxTU = int.Parse(_dstu.Rows[i][2].ToString());
                    }
                    int z = 0;
                    for (int i = 0; i < _dstu.Rows.Count; i++)
                    {
                        if (MaxTU == int.Parse(_dstu.Rows[i][2].ToString()))
                            z = i;
                    }

                    int MaTU = int.Parse(_dstu.Rows[z][1].ToString());
                    lbSLTUBanNhieuNhat.Text = MaxTU.ToString();
                    lbTUBanNhieuNhat.Text = ThucDonBUS.LayTenThucDonTuMaThucDon(MaTU);
                    lbDVTUBanNhieuNhat.Text = ThucDonBUS.LayDonViTinhTuMaTD(MaTU);
                }

            }
            else
            {
                lbTDBanNhieuNhat.Text = "Null";
                lbTUBanNhieuNhat.Text = "Null";
                lbDVTDBanNhieuNhat.Text = "Null";
                lbDVTUBanNhieuNhat.Text = "Null";
                lbSLTDBanNhieuNhat.Text = "0";
                lbSLTUBanNhieuNhat.Text = "0";
            }

        }

        private void btSuaTD_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                ThucDonDTO td = new ThucDonDTO();
                GiaDTO g = new GiaDTO();
                
                int idx = dgvDSThucDon.CurrentRow.Index;
                if (tbTenTD.Text != "")
                {

                    if (tbDVT.Text != "")
                    {
                        td.MaTD = int.Parse(dgvDSThucDon.Rows[idx].Cells[0].Value.ToString());
                        td.MaLoai = LoaiThucDonBUS.LayMaLoaiTuTenLoai(cmbLoaiThucDon.Text);
                        td.TenTD = tbTenTD.Text;
                        td.DonViTinh = tbDVT.Text;
                        bool kt;
                        kt = ThucDonBUS.KiemTraTenTDCapNhat(tbTenTD.Text, td.MaTD);
                        if (kt == true)
                        {
                            g.MaTD = td.MaTD;
                            if (dtiNgayAD.Text != "")
                            {
                                g.NgayADGia = DateTime.Parse(dtiNgayAD.Text);

                                try
                                {
                                    double gia = double.Parse(tbDonGiaTD.Text);
                                    if (gia > 0)
                                    {
                                        g.Gia = gia;
                                        bool kq1 = ThucDonBUS.CapNhatThucDon(td);
                                        bool kq2 = GiaBUS.CapNhatGia(g);
                                        if (kq1 == true && kq2 == true)
                                        {
                                            MessageBoxEx.Show("Cập nhật thực đơn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            tbTenTD.Text = "";
                                            tbDonGiaTD.Text = "";
                                            dtiNgayAD.Text = "";
                                            tbDVT.Text = "";
                                            cbLoaiTD_SelectedValueChanged(sender, e);
                                        }
                                        else
                                            MessageBoxEx.Show("Cập nhật thực đơn thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        MessageBoxEx.Show("Đơn giá phải lớn hơn 0!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        tbDonGiaTD.Text = "";
                                        tbDonGiaTD.Focus();
                                    }
                                }
                                catch
                                {
                                    MessageBoxEx.Show("Chưa nhập đơn giá hoặc kiểu dữ liệu đơn giá không đúng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbDonGiaTD.Text = "";
                                    tbDonGiaTD.Focus();
                                }
                            }
                            else
                                MessageBoxEx.Show("Chưa nhập ngày áp dụng giá!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBoxEx.Show("Tên thực đơn bị trùng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbTenTD.Text = "";
                            tbTenTD.Focus();
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Chưa nhập đơn vị tính!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbDVT.Text = "";
                        tbDVT.Focus();
                    }
                }
                else
                {
                    MessageBoxEx.Show("Chưa nhập tên thực đơn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbTenTD.Text = "";
                    tbTenTD.Focus();
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btXoaTD_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                try
                {
                    int idx = dgvDSThucDon.CurrentRow.Index;
                    int maTD = int.Parse(dgvDSThucDon.Rows[idx].Cells[0].Value.ToString());
                    DateTime ngayAD = DateTime.Parse(dtiNgayAD.Text);
                    DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                    if (result == DialogResult.Yes)
                    {
                        bool kq1, kq2;
                        try
                        {
                            kq1 = GiaBUS.XoaGiaTheoMaTDVaNgayAD(maTD, ngayAD);
                            kq2 = ThucDonBUS.XoaThucDonTheoMaTD(maTD);

                            if (kq1 == true && kq2 == true)
                            {
                                MessageBoxEx.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbTenTD.Text = "";
                                tbDonGiaTD.Text = "";
                                dtiNgayAD.Text = "";
                                tbDVT.Text = "";
                                
                                if (tbTenTDTraCuu.Text != "")
                                    btTim_Click(sender, e);
                                if (cbLoaiTD.Text != "")
                                    cbLoaiTD_SelectedValueChanged(sender, e);
                            }
                            else
                                MessageBoxEx.Show("Xóa thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            MessageBoxEx.Show("Thực đơn đã được gọi món hoặc có trong hóa đơn. Không thể xóa!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBoxEx.Show("Chưa chọn thực đơn cần xóa!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btInHD_Click(object sender, EventArgs e)
        {
            try
            {
                ViewHoaDon frm = new ViewHoaDon();
                int idx = dtgDSHD.CurrentRow.Index;
                frm.SoHD = int.Parse(dtgDSHD.Rows[idx].Cells[0].Value.ToString());
                frm.ShowDialog();
            }
            catch
            {
                MessageBoxEx.Show("Chưa chọn hóa đơn cần in!", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btXoaHD_Click(object sender, EventArgs e)
        {
            if (_nv.Quyen == "Admin")
            {
                DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idx = dtgDSHD.CurrentRow.Index;
                        int SoHD = int.Parse(dtgDSHD.Rows[idx].Cells[0].Value.ToString());
                        CT_HoaDonBUS.XoaCTHDTheoSoHD(SoHD);
                        HoaDonBUS.XoaHDTheoSoHD(SoHD);
                        MessageBoxEx.Show("Xóa Thành Công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DuaDSHoaDonLenDataGridView();
                        dtgDSCTHD.DataSource = null;
                        try
                        {
                            int idx2 = dtgDSHD.CurrentRow.Index;
                            int maHD = int.Parse(dtgDSHD.Rows[idx2].Cells[0].Value.ToString());
                            DataTable _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(maHD);
                            dtgDSCTHD.DataSource = _ds;
                        }
                        catch { }
                    }
                    catch
                    {
                        MessageBoxEx.Show("Không có hóa đơn thanh toán nào trong hệ thống!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btTim_Click(object sender, EventArgs e)
        {
            tbTenTD.Text = "";
            cbLoaiTD.Text = "";
            dtiNgayAD.Text = "";
            tbDonGiaTD.Text = "";
            tbDVT.Text = "";
            if (tbTenTDTraCuu.Text == "")
                MessageBoxEx.Show("Chưa nhập tên thực đơn cần tra cứu!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataTable kq = ThucDonBUS.TraCuuThucDonTheoTen(tbTenTDTraCuu.Text);
                dgvDSThucDon.DataSource = kq;
            }
        }

        private void btTraCuuNV_Click(object sender, EventArgs e)
        {
            if (tbTenNVTraCuu.Text == "")
                MessageBoxEx.Show("Chưa nhập tên nhân viên cần tra cứu!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                tbHoTen.Text = "";
                tbTenDN.Text = "";
                tbMatKhau.Text = "";
                tbMatKhau2.Text = "";
                diNgaySinh.Text = "";
                cmbQuyen.Text = "Tiếp Tân";
                DataTable dt = NhanVienBUS.TraCuuNhanVienTheoTen(tbTenNVTraCuu.Text);
                dtgDSNV.DataSource = dt;
            }
        }

        private void tbTenNVTraCuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btTraCuuNV_Click(sender, e);
        }

        private void tbTenTDTraCuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btTim_Click(sender, e);
        }

        private void btDSNV_Click(object sender, EventArgs e)
        {
            tbHoTen.Text = "";
            tbTenDN.Text = "";
            tbMatKhau.Text = "";
            tbMatKhau2.Text = "";
            diNgaySinh.Text = "";
            cmbQuyen.Text = "Tiếp Tân";
            tbTenNVTraCuu.Text = "";
            DuaDSNhanVienLenDataGridView();
        }

        private void btInDSHD_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count < 1 || flag == 0)
            {
                MessageBoxEx.Show("Danh sách rỗng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (flag == 1)
                {
                    ViewThongKeTheoNgay frm = new ViewThongKeTheoNgay();
                    frm.TongDoanhThu = lbTongDoanhThu.Text;
                    frm.Ngay = dtNgayPC.Value;
                    frm.ShowDialog();
                }
                if (flag == 2)
                {
                    ViewThongKeTheoThangNam frm = new ViewThongKeTheoThangNam();
                    frm.ThangNam = cbThangTK.Text + "/" + tbNamTK.Text;
                    frm.TongDoanhThu = lbTongDoanhThu.Text;
                    frm.ShowDialog();
                }
                if (flag == 3)
                {
                    ViewThongKeTheoKhoangNgay frm = new ViewThongKeTheoKhoangNgay();
                    frm.TongDoanhThu = lbTongDoanhThu.Text;
                    frm.TuNgay = dtiTuNgay.Value;
                    frm.DenNgay = dtiDenNgay.Value;
                    frm.ShowDialog();
                }
            }

        }

        private void btTCHDTheoNgay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay = dtiNgayTCHD.Value;
                DataTable kq = HoaDonBUS.ThongKeHDTheoNgay(ngay);
                dtgDSHD.DataSource = kq;
            }
            catch
            {
                MessageBoxEx.Show("Mời chọn ngày cần tra cứu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btTCHDTheoThangNam_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(cmbThangTCHD.Text);
                int nam = int.Parse(tbNamTCHD.Text);
                DataTable dt = HoaDonBUS.ThongKeHDTheoThang(thang, nam);
                dtgDSHD.DataSource = dt;
            }
            catch
            {
                MessageBoxEx.Show("Mời chọn tháng cần tra cứu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btTCHDTheoKhoangNgay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtiTuNgayTCHD.Value;
                DateTime denNgay = dtiDenNgayTCHD.Value;

                DataTable dt = HoaDonBUS.ThongKeHDTheoKhoangNgay(tuNgay, denNgay);
                dtgDSHD.DataSource = dt;
            }
            catch
            {
                MessageBoxEx.Show("Chưa chọn mốc ngày tra cứu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
        }

        private void btXoaHDTheoNgay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay = dtiNgayTCHD.Value;
                DataTable dt = HoaDonBUS.ThongKeHDTheoNgay(ngay);
                XoaDSHD(dt);
            }
            catch
            {
               MessageBoxEx.Show("Xóa hóa đơn không thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XoaDSHD(DataTable dt)
        {
            if (_nv.Quyen == "Admin")
            {
                DialogResult result = MessageBox.Show("Chắn chắn xóa?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int soHD = int.Parse(dt.Rows[i][0].ToString());
                        CT_HoaDonBUS.XoaCTHDTheoSoHD(soHD);
                        HoaDonBUS.XoaHDTheoSoHD(soHD);
                    }
                    MessageBoxEx.Show("Xóa hóa đơn thành công!");
                    DuaDSHoaDonLenDataGridView();

                    dtgDSCTHD.DataSource = null;
                    try
                    {
                        int idx2 = dtgDSHD.CurrentRow.Index;
                        int maHD = int.Parse(dtgDSHD.Rows[idx2].Cells[0].Value.ToString());
                        DataTable _ds = CT_HoaDonBUS.LayDSCTHDTuMaHD(maHD);
                        dtgDSCTHD.DataSource = _ds;
                    }
                    catch { }
                }
            }
            else
            {
                MessageBoxEx.Show("Chỉ có Admin mới có thể sử dụng chức năng này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btXoaHDTheoThangNam_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(cmbThangTCHD.Text);
                int nam = int.Parse(tbNamTCHD.Text);
                DataTable dt = HoaDonBUS.ThongKeHDTheoThang(thang, nam);
                dtgDSHD.DataSource = dt;
                XoaDSHD(dt);
            }
            catch
            {
                MessageBoxEx.Show("Xóa hóa đơn không thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoaHDTheoKhoangNgay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtiTuNgayTCHD.Value;
                DateTime denNgay = dtiDenNgayTCHD.Value;

                DataTable dt = HoaDonBUS.ThongKeHDTheoKhoangNgay(tuNgay, denNgay);
                dtgDSHD.DataSource = dt;
                XoaDSHD(dt);
            }
            catch
            {
                MessageBoxEx.Show("Xóa hóa đơn không thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelX51_Click(object sender, EventArgs e)
        {

        }
    }
}