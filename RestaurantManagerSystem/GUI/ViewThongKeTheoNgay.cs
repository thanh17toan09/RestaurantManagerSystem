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
    public partial class ViewThongKeTheoNgay : Office2007Form
    {
        public ViewThongKeTheoNgay()
        {
            InitializeComponent();
        }
        private string tongDoanhThu;

        public string TongDoanhThu
        {
            get { return tongDoanhThu; }
            set { tongDoanhThu = value; }
        }

        private DateTime ngay;

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }

        private void ViewThongKeTheoNgay_Load(object sender, EventArgs e)
        {
            Reports.RptThongKeTheoNgay rpt = new RptThongKeTheoNgay();
            crystalTKTheongay.Refresh();
            rpt.SetParameterValue(0, ngay);
            rpt.SetParameterValue(1, tongDoanhThu);
            crystalTKTheongay.ReportSource = rpt;
        }
    }
}