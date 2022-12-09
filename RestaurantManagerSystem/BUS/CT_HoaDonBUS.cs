using System;
using System.Collections.Generic;
using System.Text;
using RestaurantManagerSystem.DTO;
using RestaurantManagerSystem.DAO;
using System.Data;

namespace RestaurantManagerSystem.BUS
{
    public class CT_HoaDonBUS
    {
        public static bool ThemChiTietHoaDon(CT_HoaDonDTO cthd)
        {
            bool kq = CT_HoaDonDAO.ThemChiTietHoaDon(cthd);
            return kq;
        }
        public static bool XoaCTHDTheoSoHD(int soHD)
        {
            bool kq = CT_HoaDonDAO.XoaCTHDTheoSoHD(soHD);
            return kq;
        }
        public static bool XoaCTHDTheoSoHDVaMaTD(int soHD, int MaTD)
        {
            bool kq = CT_HoaDonDAO.XoaCTHDTheoSoHDVaMaTD(soHD, MaTD);
            return kq;
        }
        public static DataTable LayDSCTHDTuMaHD(int maHD)
        {
            DataTable _ds = CT_HoaDonDAO.LayDSCTHDTuMaHD(maHD);
            return _ds;
        }
        public static DataTable LayDSCTHD(int SoHD)
        {
            DataTable dt = CT_HoaDonDAO.LayDSCTHD(SoHD);
            return dt;
        }
    }
}
