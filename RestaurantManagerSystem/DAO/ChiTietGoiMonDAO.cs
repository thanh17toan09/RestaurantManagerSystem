using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RestaurantManagerSystem.DTO;

namespace RestaurantManagerSystem.DAO
{
    public class ChiTietGoiMonDAO
    {
        //Rút trích dữ liêu: select 
        public static List<ChiTietGoiMonDTO> LayDSCTGMTuMaGoiMon(int maGoiMon)
        {
            List<ChiTietGoiMonDTO> _ds = new List<ChiTietGoiMonDTO>();
            string sql = "select * from ChiTietGoiMon where MaGoiMon = " + maGoiMon;
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietGoiMonDTO ctgm = new ChiTietGoiMonDTO();
                ctgm.MaCTGoiMon = int.Parse(dt.Rows[i]["MaCTGoiMon"].ToString());
                ctgm.MaGoiMon = int.Parse(dt.Rows[i]["MaGoiMon"].ToString());
                ctgm.MaTD = int.Parse(dt.Rows[i]["MaThucDon"].ToString());
                ctgm.DonGia = double.Parse(dt.Rows[i]["DonGia"].ToString());
                ctgm.SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                _ds.Add(ctgm);
            }
            return _ds;
        }
        public static bool ThemChiTietGoiMon(ChiTietGoiMonDTO ctgm)
        {
            bool kq;
            ctgm.MaCTGoiMon = MaTuTang();
            string sql = string.Format("insert into ChiTietGoiMon values ({0}, {1}, {2}, {3}, {4})", ctgm.MaCTGoiMon, ctgm.MaGoiMon, ctgm.MaTD, ctgm.DonGia, ctgm.SoLuong);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool CapNhatChiTietGoiMonTheoMaGoiMon(ChiTietGoiMonDTO ctgm)
        {
            bool kq;
            string sql = string.Format("update ChiTietGoiMon set MaThucDon = {0), SoLuong = {1} where MaGoiMon where MaGoiMon = {2}", ctgm.MaTD, ctgm.SoLuong, ctgm.MaGoiMon);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool XoaChiTietGoiMonTheoMaCTGM(int maCTGM)
        {
            bool kq;
            string sql = string.Format("delete from ChiTietGoiMon where MaCTGoiMon = {0}", maCTGM);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool XoaDSChiTietGoiMonTheoMaGoiMon(int maGoiMon)
        {
            bool kq;
            string sql = string.Format("delete from ChiTietGoiMon where MaGoiMon = {0}", maGoiMon);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }
        public static int MaTuTang()
        {
            string sql = "select * from ChiTietGoiMon";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            int maTuTang = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i][0].ToString()) != maTuTang)
                {
                    return maTuTang;
                }
                maTuTang++;
            }
            return maTuTang;
        }
    }
}
