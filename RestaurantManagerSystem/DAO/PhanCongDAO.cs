using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RestaurantManagerSystem.DTO;

namespace RestaurantManagerSystem.DAO
{
    public class PhanCongDAO
    {
        public static DataTable LayDSPhanCong()
        {
            string sql = "select Ca as 'Ca', HoTen as 'Tên Nhân Viên', MaSoBan as 'Mã Số Bàn' from PhanCong, NhanVien where PhanCong.MaNV = NhanVien.MaNV";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            return dt;
        }

        public static bool ThemPhanCong(PhanCongDTO pc)
        {
            bool kq;
            string sql = string.Format("insert into PhanCong values({0}, {1}, {2})", pc.Ca, pc.MsNV, pc.MsBan);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool XoaPhanCong(PhanCongDTO pc)
        {
            bool kq;
            string sql = string.Format("delete PhanCong where Ca = {0} and MaNV = {1} and MaSoBan = {2}", pc.Ca, pc.MsNV, pc.MsBan);
            kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static int LayMaNVTheoMaBanVaCa(int maBan, int ca)
        {
            string sql = string.Format("select MaNV from PhanCong where MaSoBan = {0} and Ca = {1}", maBan, ca);
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            int maNV = int.Parse(dt.Rows[0]["MaNV"].ToString());
            return maNV;
        }

        public static int LayCaTheoGio(int gio)
        { 
            int ca;
            if (gio >= 7 && gio < 11)
                ca = 1;
            else
            {
                if (gio >= 11 && gio < 18)
                    ca = 2;
                else
                    ca = 3;
            }
            return ca;
        }
    }
}

