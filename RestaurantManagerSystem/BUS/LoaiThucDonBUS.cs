using System;
using System.Collections.Generic;
using System.Text;
using RestaurantManagerSystem.DTO;
using RestaurantManagerSystem.DAO;

namespace RestaurantManagerSystem.BUS
{
    public class LoaiThucDonBUS
    {
        //Rút trích dữ liệu: select
        public static List<LoaiThucDonDTO> LayDSLoaiThucDon()
        {
            List<LoaiThucDonDTO> _ds;
            _ds = LoaiThucDonDAO.LayDSLoaiThucDon();
            return _ds;
        }

        public static int LayMaLoaiTuTenLoai(string tenLoai)
        {
            int maLoai = LoaiThucDonDAO.LayMaLoaiTuTenLoai(tenLoai);
            return maLoai;
        }
    }
}
