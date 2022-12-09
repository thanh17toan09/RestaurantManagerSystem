using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RestaurantManagerSystem.DTO;

namespace RestaurantManagerSystem.DAO
{
    public class GiaDAO
    {
        public static bool ThemGia(GiaDTO g)
        {
            string sql = string.Format("set dateformat DMY insert into Gia values (convert(varchar(10),'{0}', 103), {1}, {2})", g.NgayADGia, g.MaTD, g.Gia);
            bool kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool XoaGiaTheoMaTDVaNgayAD(int maTD, DateTime ngayAD)
        {
            string sql = string.Format("set dateformat DMY delete Gia where MaThucDon = {0} and convert(varchar(10),NgayADGia, 103) = convert(varchar(10), convert(datetime,'{1}'), 103)", maTD, ngayAD);
            bool kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool CapNhatGia(GiaDTO g)
        {
            string sql = string.Format("set dateformat DMY update Gia set NgayADGia = '{0}', Gia = {1} where MaThucDon = {2}", g.NgayADGia, g.Gia, g.MaTD);
            bool kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static double LayGiaTheoMaThucDon(int maTD)
        {
            double gia;
            string sql = string.Format("select Gia from Gia where MaThucDon = {0}", maTD);
            DataTable dt = new DataTable();
            dt = SqlDataAccessHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                gia = double.Parse(dt.Rows[0]["Gia"].ToString());
            else
                gia = 0;
            return gia;
        }

        public static int MaTuTang()
        {
            string sql = "select * from Gia";
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
