using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RestaurantManagerSystem.Reports;

namespace RestaurantManagerSystem.GUI
{
    public partial class ViewThongKeTheoKhoangNgay : Office2007Form
    {
        private DateTime tuNgay;

        public DateTime TuNgay
        {
            get { return tuNgay; }
            set { tuNgay = value; }
        }

        private DateTime denNgay;

        public DateTime DenNgay
        {
            get { return denNgay; }
            set { denNgay = value; }
        }

        private string tongDoanhThu;

        public string TongDoanhThu
        {
            get { return tongDoanhThu; }
            set { tongDoanhThu = value; }
        }

        public ViewThongKeTheoKhoangNgay()
        {
            InitializeComponent();
        }

        private void ViewThongKeTheoKhoangNgay_Load(object sender, EventArgs e)
        {
            Reports.RptThongKeTheoKhoangNgay rpt = new RptThongKeTheoKhoangNgay();
            crystalTKTheoKhoangNgay.Refresh();
            rpt.SetParameterValue(0, TongDoanhThu);
            rpt.SetParameterValue(1, tuNgay);
            rpt.SetParameterValue(2, denNgay);
            crystalTKTheoKhoangNgay.ReportSource = rpt;
        }

    }
}