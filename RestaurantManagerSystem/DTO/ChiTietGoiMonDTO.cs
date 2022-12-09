using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagerSystem.DTO
{
    public class ChiTietGoiMonDTO
    {
        private int _maCTGoiMon;
        private int _maGoiMon;
        private int _maTD;
        private double _donGia;
        private int _soLuong;

        //Phuong thuc khoi tao mac dinh
        public ChiTietGoiMonDTO()
        {
            _maCTGoiMon = 0;
            _maGoiMon = 0;
            _maTD = 0;
            _donGia = 0;
            _soLuong = 0;
        }

        //Phuong thuc khoi tao co tham so
        public ChiTietGoiMonDTO(int maCTGoiMon, int maGoiMon, int maTD,double donGia, int soLuong)
        {
            _maCTGoiMon = maCTGoiMon;
            _maGoiMon = maGoiMon;
            _maTD = maTD;
            _donGia = donGia;
            _soLuong = soLuong;
        }

        //Phuong thuc khoi tao sao chep
        public ChiTietGoiMonDTO(ChiTietGoiMonDTO ctgm)
        {
            _maCTGoiMon = ctgm._maCTGoiMon;
            _maGoiMon = ctgm._maGoiMon;
            _maTD = ctgm._maTD;
            _donGia = ctgm._donGia;
            _soLuong = ctgm._soLuong;
        }

        //Properties
        public int MaCTGoiMon
        {
            get { return _maCTGoiMon; }
            set { _maCTGoiMon = value; }
        }

        public int MaGoiMon
        {
            get { return _maGoiMon; }
            set { _maGoiMon = value; }
        }

        public int MaTD
        {
            get { return _maTD; }
            set { _maTD = value; }
        }
        public double DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
    }
}
