using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagerSystem.DTO
{
    public class NguoiDungDTO
    {
        private int _maND;
        private string _tenDN;
        private string _matKhau;
        private string _hoTen;
        private string _quyen;

        //Phương thức khởi tạo mặc định
        public NguoiDungDTO()
        {
            _maND = 0;
            _tenDN = "";
            _matKhau = "";
            _hoTen = "";
            _quyen = "";
        }

        //Phương thức khởi tạo có tham số
        public NguoiDungDTO(int maND, string tenDN, string matKhau, string hoTen, string quyen)
        {
            _maND = maND;
            _tenDN = tenDN;
            _matKhau = matKhau;
            _hoTen = hoTen;
            _quyen = quyen;
        }

        //Phương thức khởi tạo sao chép.
        public NguoiDungDTO(NguoiDungDTO NguoiDung)
        {
            _maND = NguoiDung._maND;
            _tenDN = NguoiDung._tenDN;
            _matKhau = NguoiDung._matKhau;
            _hoTen = NguoiDung._hoTen;
            _quyen = NguoiDung._quyen;
        }

        //Properties
        public int MaND
        {
            get { return _maND; }
            set { _maND = value; }
        }
        public string TenDN
        {
            get { return _tenDN; }
            set { _tenDN = value; }
        }
        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }
        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }
        public string Quyen
        {
            get { return _quyen; }
            set { _quyen = value; }
        }
    }
}
