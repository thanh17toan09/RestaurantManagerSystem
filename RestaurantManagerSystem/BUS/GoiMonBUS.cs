using System;
using System.Collections.Generic;
using System.Text;
using RestaurantManagerSystem.DTO;
using RestaurantManagerSystem.DAO;

namespace RestaurantManagerSystem.BUS
{
    public class GoiMonBUS
    {
        public static bool ThemGoiMon(GoiMonDTO gm)
        {
            bool kq = GoiMonDAO.ThemGoiMon(gm);
            return kq;
        }
        public static int LayMaGoiMonCanLap()
        {
            int maGM = GoiMonDAO.MaTuTang();
            return maGM;
        }
        public static int LayMaGoiMonTuMaBan(int maBan)
        {
            int maGM = GoiMonDAO.LayMaGoiMonTuMaBan(maBan);
            return maGM;
        }
        public static List<int> LayDSMaBan()
        {
            List<int> _ds = new List<int>();
            _ds = GoiMonDAO.LayDSMaBan();
            return _ds;
        }
        public static bool XoaGoiMonTheoMaBan(int maBan)
        {
            bool kq = GoiMonDAO.XoaGoiMonTheoMaBan(maBan);
            return kq;
        }
    }
}
