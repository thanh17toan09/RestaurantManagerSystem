using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagerSystem.DTO
{
    public class ChiTietCaDTO
    {
        private int _ca;
        private DateTime _timeBD;
        private DateTime _timeKT;

        //Phuong thuc khoi tao mac dinh
        public ChiTietCaDTO()
        {
            _ca = 0;
            _timeBD = DateTime.Today;
            _timeKT = DateTime.Today;
        }

        //Phuong thuc khoi tao co tham so
        public ChiTietCaDTO(int ca, DateTime timeBD, DateTime timeKT)
        {
            _ca = ca;
            _timeBD = timeBD;
            _timeKT = timeKT;
        }
        
        //Phuong thuc khoi tao sao chep
        private ChiTietCaDTO(ChiTietCaDTO ctCa)
        {
            _ca = ctCa._ca;
            _timeBD = ctCa._timeBD;
            _timeKT = ctCa._timeKT;
        }

        //Properties
        public int Ca
        {
            get { return _ca; }
            set { _ca = value; }
        }

        public DateTime TimeBD
        {
            get { return _timeBD; }
            set { _timeBD = value; }
        }

        public DateTime TimeKT
        {
            get { return _timeKT; }
            set { _timeKT = value; }
        }
    }
}
