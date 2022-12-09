using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagerSystem.DTO
{
    public class GoiMonDTO
    {
        private int _maGoiMon;        
        private int _msBan;
        
        //Phuong thuc khoi tao mac dinh
        public GoiMonDTO()
        {
            _maGoiMon = 0;
            _msBan = 0;
        }
        
        //Phuong thuc khoi tao co tham so
        public GoiMonDTO(int maGoiMon, int msBan)
        {
            _maGoiMon = MaGoiMon;
            _msBan = msBan;
        }

        //Phuong thuc khoi tao sao chep
        public GoiMonDTO(GoiMonDTO goiMon)
        {
            _maGoiMon = goiMon._maGoiMon;
            _msBan = goiMon._msBan;
        }

        //Properties
        public int MaGoiMon
        {
            get { return _maGoiMon; }
            set { _maGoiMon = value; }
        }

        public int MsBan
        {
            get { return _msBan; }
            set { _msBan = value; }
        }
    }
}
