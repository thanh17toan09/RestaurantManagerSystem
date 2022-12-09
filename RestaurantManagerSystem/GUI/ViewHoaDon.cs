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
    public partial class ViewHoaDon : Office2007Form
    {
        public ViewHoaDon()
        {
            InitializeComponent();
        }
        private int soHD;

        public int SoHD
        {
            get { return soHD; }
            set { soHD = value; }
        }


        private void ViewHoaDon_Load(object sender, EventArgs e)
        {
            crytalview.Refresh();
            Reports.HoaDon rpt = new HoaDon();
            rpt.SetParameterValue(0, soHD);
            crytalview.ReportSource = rpt;
        }
    }
}