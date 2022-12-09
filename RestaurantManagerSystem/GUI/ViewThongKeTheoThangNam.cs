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
    public partial class ViewThongKeTheoThangNam : Office2007Form
    {
        private string thangNam;

        public string ThangNam
        {
            get { return thangNam; }
            set { thangNam = value; }
        }

        private string tongDoanhThu;

        public string TongDoanhThu
        {
            get { return tongDoanhThu; }
            set { tongDoanhThu = value; }
        }

        public ViewThongKeTheoThangNam()
        {
            InitializeComponent();
        }

        private void ViewThongKeTheoThangNam_Load(object sender, EventArgs e)
        {
            crystalTKTheoThangNam.Refresh();
            RptThongKeTheoThangNam rpt = new RptThongKeTheoThangNam();
            rpt.SetParameterValue(0, thangNam);
            rpt.SetParameterValue(1, tongDoanhThu);
            crystalTKTheoThangNam.ReportSource = rpt;
        }
    }
}