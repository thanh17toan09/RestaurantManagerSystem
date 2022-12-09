﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RestaurantManagerSystem.DTO;

namespace RestaurantManagerSystem.DAO
{
    public class ThucDonDAO
    {
        public static bool ThemThucDon(ThucDonDTO td)
        {
            string sql = string.Format("insert into ThucDon values ({0}, {1}, '{2}', '{3}')", td.MaTD, td.MaLoai, td.TenTD, td.DonViTinh);
            bool kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool XoaThucDonTheoMaTD(int maTD)
        {
            string sql = "delete ThucDon where MaThucDon = " + maTD;
            bool kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        public static bool CapNhatThucDon(ThucDonDTO td)
        {
            string sql = string.Format("update ThucDon set MaLoai = {0}, TenThucDon = N'{1}', DonViTinh = N'{2}' where MaThucDon = {3}", td.MaLoai, td.TenTD, td.DonViTinh, td.MaTD);
            bool kq = SqlDataAccessHelper.ExecuteNonQuery(sql);
            return kq;
        }

        //Rút trích dữ liêu: select 
        public static List<ThucDonDTO> LayDSThucDon()
        {
            List<ThucDonDTO> _ds = new List<ThucDonDTO>();
            string sql = "select * from ThucDon";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucDonDTO td = new ThucDonDTO();
                td.MaTD = int.Parse(dt.Rows[i]["MaThucDon"].ToString());
                td.MaLoai = int.Parse(dt.Rows[i]["MaLoai"].ToString());
                td.TenTD = dt.Rows[i]["TenThucDon"].ToString();
                td.DonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                _ds.Add(td);
            }
            return _ds;
        }

        public static List<ThucDonDTO> LayDSThucDonTheoMaLoai(int maLoai)
        {
            List<ThucDonDTO> _ds = new List<ThucDonDTO>();
            string sql = "select * from ThucDon where MaLoai = " + maLoai;
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucDonDTO td = new ThucDonDTO();
                td.MaTD = int.Parse(dt.Rows[i]["MaThucDon"].ToString());
                td.MaLoai = int.Parse(dt.Rows[i]["MaLoai"].ToString());
                td.TenTD = dt.Rows[i]["TenThucDon"].ToString();
                td.DonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                _ds.Add(td);
            }
            return _ds;
        }

        public static List<ThucDonDTO> LayDSMaTDVaTenTDTheoMaLoai(int maLoai)
        {
            List<ThucDonDTO> ds = new List<ThucDonDTO>();
            string sql = "select * from ThucDon where MaLoai = " + maLoai;
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucDonDTO td = new ThucDonDTO();
                td.MaTD = int.Parse(dt.Rows[i]["MaThucDon"].ToString());
                td.TenTD = dt.Rows[i]["TenThucDon"].ToString();
                ds.Add(td);
            }
            return ds;
        }

        public static DataTable LayDanhSachTDTheoMaLoai(int maLoai)
        {
            string sql = "select td.MaThucDon as 'Mã TĐ', td.TenThucDon as 'Tên Thực Đơn', g.Gia as 'Đơn Giá', g.NgayADGia as 'Ngày AD', td.DonViTinh as 'Đơn Vị Tính', l.TenLoai as 'Loại TĐ' from ThucDon td, Gia g, LoaiThucDon l where td.MaLoai = l.MaLoai and td.MaThucDon = g.MaThucDon and td.MaLoai =" + maLoai;
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            return dt;
        }

        public static string LayTenThucDonTuMaThucDon(int maTD)
        {
            string tenTD;
            string sql = "select TenThucDon from ThucDon where MaThucDon = " + maTD;
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                tenTD = dt.Rows[0]["TenThucDon"].ToString();
            else
                return "";
            return tenTD;
        }

        public static int LayMaThucDonTuTenTD(string tenTD)
        {
            int maTD;
            string sql = "select MaThucDon from ThucDon where TenThucDon = N'" + tenTD +"'";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                maTD = int.Parse(dt.Rows[0]["MaThucDon"].ToString());
            else
                return 0;
            return maTD;
        }

        public static string LayDonViTinhTheoMaTD(int maTD)
        {
            string dvt;
            string sql = "select DonViTinh from ThucDon where MaThucDon = " + maTD;
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            dvt = dt.Rows[0][0].ToString();
            return dvt;
        }

        public static bool KiemTraThucDonNuocUong(int maTD)
        {
            bool kq;
            string sql = string.Format("select l.Nhom from LoaiThucDon l, ThucDon td where l.MaLoai = td.MaLoai and td.MaThucDon = {0}", maTD);
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            if (dt.Rows[0][0].ToString() == "Thức Ăn")
                kq = true;
            else
                kq = false;
            return kq;
        }

        public static bool KiemTraTrungTenThucDon(string tenTD)
        {
            bool kq;
            string sql = "select * from ThucDon where TenThucDon = N'" + tenTD + "'";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                kq = false;
            else
                kq = true;
            return kq;
        }

        public static bool KiemTraTenTDCapNhat(string tenTD, int maTD)
        {
            bool kq;
            string sql = string.Format("select * from ThucDon where TenThucDon = N'{0}' and MaThucDon = {1}", tenTD, maTD);
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                kq = false;
            else
                kq = true;
            return kq;
        }

        public static DataTable TraCuuThucDonTheoTen(string tenTD)
        {
            string sql = string.Format("select td.MaThucDon as 'Mã TĐ', td.TenThucDon as 'Tên Thực Đơn', g.Gia as 'Đơn Giá', g.NgayADGia as 'Ngày AD', td.DonViTinh as 'Đơn Vị Tính', l.TenLoai as 'Loại TĐ' from ThucDon td, Gia g, LoaiThucDon l where td.TenThucDon like N'%{0}%' and td.MaThucDon = g.MaThucDon and td.MaLoai = l.MaLoai", tenTD);
            DataTable kq = SqlDataAccessHelper.ExecuteQuery(sql);
            return kq;
        }

        public static int MaTuTang()
        {
            string sql = "select * from ThucDon";
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
