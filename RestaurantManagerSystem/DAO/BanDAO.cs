using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RestaurantManagerSystem.DTO;

namespace RestaurantManagerSystem.DAO
{
    public class BanDAO
    {
        public static List<BanDTO> LayDSBan()
        {
            List<BanDTO> _ds = new List<BanDTO>();
            string sql = "select * from BanAn";
            DataTable dt = SqlDataAccessHelper.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BanDTO b = new BanDTO();
                b.MaBan = int.Parse(dt.Rows[i]["MaSoBan"].ToString());
                b.SoGhe = int.Parse(dt.Rows[i]["SoGhe"].ToString());
                _ds.Add(b);
            }
            return _ds;
        }
    }
}
