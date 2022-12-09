using System;
using System.Collections.Generic;
using System.Text;
using RestaurantManagerSystem.DAO;
using RestaurantManagerSystem.DTO;

namespace RestaurantManagerSystem.BUS
{
    public class ChiTietGoiMonBUS
    {
        //Rút trích dữ liệu: select 
        public static List<ChiTietGoiMonDTO> LayDSCTGMTuMaGoiMon(int maGM)
        {
            List<ChiTietGoiMonDTO> _ds;
            _ds = ChiTietGoiMonDAO.LayDSCTGMTuMaGoiMon(maGM);
            return _ds;
        }
        public static bool ThemChiTietGoiMon(ChiTietGoiMonDTO ctgm)
        {
            bool kq = ChiTietGoiMonDAO.ThemChiTietGoiMon(ctgm);
            return kq;
        }
        public static bool XoaDSChiTietGoiMonTheoMaGoiMon(int maGM)
        {
            bool kq = ChiTietGoiMonDAO.XoaDSChiTietGoiMonTheoMaGoiMon(maGM);
            return kq;
        }
    }
}
