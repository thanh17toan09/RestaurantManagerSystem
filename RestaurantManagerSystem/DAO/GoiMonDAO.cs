using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RestaurantManagerSystem.DTO;

namespace RestaurantManagerSystem.DAO
{
    public class GoiMonDAO
    {
        //Rút trích dữ liêu: select 
        public static List<GoiMonDTO> LayDSGoiMon()
        {
            List<GoiMonDTO> _ds = new List<GoiMonDTO>();
            string sql = "select * from GoiMon";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GoiMonDTO gm = new GoiMonDTO();
                gm.MaGoiMon = int.Parse(dt.Rows[i]["MaGoiMon"].ToString());
                gm.MsBan = int.Parse(dt.Rows[i]["MaSoBan"].ToString());
                _ds.Add(gm);
            }
            return _ds;
        }
        public static List<int> LayDSMaBan()
        {
            List<int> _ds = new List<int>();
            string sql = "select * from GoiMon";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int maBan = int.Parse(dt.Rows[i]["MaSoBan"].ToString());
                _ds.Add(maBan);
            }
            return _ds;
        }
        public static int LayMaGoiMonTuMaBan(int maBan)
        {
            int maGM = 0;
            string sql = "select * from GoiMon where MaSoBan = " + maBan;
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                maGM = int.Parse(dt.Rows[0]["MaGoiMon"].ToString());
            }
            return maGM;
        }
        public static bool ThemGoiMon(GoiMonDTO gm)
        {
            gm.MaGoiMon = MaTuTang(); 
            bool kq;
            string sql = string.Format("insert into GoiMon values ({0}, {1})", gm.MaGoiMon, gm.MsBan);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }
        public static bool XoaGoiMonTheoMaBan(int maBan)
        {
            bool kq;
            string sql = string.Format("delete from GoiMon where MaSoBan = {0}", maBan);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }
        public static int MaTuTang()
        {
            string sql = "select * from GoiMon";
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
