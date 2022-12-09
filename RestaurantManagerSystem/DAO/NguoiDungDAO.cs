using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RestaurantManagerSystem.DTO;

namespace RestaurantManagerSystem.DAO
{
    public class NguoiDungDAO
    {
        //Rút trích dữ liêu: select 
        public static List<NguoiDungDTO> LayDSNguoiDung()
        {
            List<NguoiDungDTO> _ds = new List<NguoiDungDTO>();
            string sql = "select * from NguoiDung";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NguoiDungDTO nd = new NguoiDungDTO();
                nd.MaND = int.Parse(dt.Rows[i]["MaND"].ToString());
                nd.TenDN = dt.Rows[i]["TenDN"].ToString();
                nd.MatKhau = dt.Rows[i]["MatKhau"].ToString();
                nd.HoTen = dt.Rows[i]["HoTen"].ToString();
                nd.Quyen = dt.Rows[i]["Quyen"].ToString();
                _ds.Add(nd);
            }
            return _ds;
        }
        public static bool KiemTraTenDNTonTai(string tenDN)
        {
            bool kq;
            string sql = "select * from NguoiDung where TenDN = '" + tenDN + "'";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                kq = true;
            else
                kq = false;
            return kq;
        }
        public static bool ThemNguoiDung(NguoiDungDTO nd)
        {
            nd.MaND = MaTuTang();
            bool kq;
            string sql = string.Format("insert into NguoiDung values ({0}, '{1}', '{2}', '{3}', '{4}')", nd.MaND, nd.TenDN, nd.MatKhau, nd.HoTen, nd.Quyen);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static int MaTuTang()
        {
            string sql = "select * from NguoiDung";
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
