using System;
using System.Collections.Generic;
using System.Text;
using RestaurantManagerSystem.DTO;
using RestaurantManagerSystem.DAO;

namespace RestaurantManagerSystem.BUS
{
    public class NguoiDungBUS
    {
        //Rút trích dữ liệu: select 
        public static List<NguoiDungDTO> LayDSNguoiDung()
        {
            List<NguoiDungDTO> _ds;
            _ds = NguoiDungDAO.LayDSNguoiDung();
            return _ds;
        }

        //Thêm: insert 
        public static bool ThemNguoiDung(NguoiDungDTO nd)
        {
            bool kq = NguoiDungDAO.ThemNguoiDung(nd);
            return kq;
        }
        public static bool KiemTraTenDNTonTai(string tenDN)
        {
            bool kq = NguoiDungDAO.KiemTraTenDNTonTai(tenDN);
            return kq;
        }
    }
}
