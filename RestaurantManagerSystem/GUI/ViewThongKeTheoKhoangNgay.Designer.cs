namespace RestaurantManagerSystem.GUI
{
    partial class ViewThongKeTheoKhoangNgay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalTKTheoKhoangNgay = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalTKTheoKhoangNgay
            // 
            this.crystalTKTheoKhoangNgay.ActiveViewIndex = -1;
            this.crystalTKTheoKhoangNgay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalTKTheoKhoangNgay.DisplayGroupTree = false;
            this.crystalTKTheoKhoangNgay.DisplayStatusBar = false;
            this.crystalTKTheoKhoangNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalTKTheoKhoangNgay.Location = new System.Drawing.Point(0, 0);
            this.crystalTKTheoKhoangNgay.Name = "crystalTKTheoKhoangNgay";
            this.crystalTKTheoKhoangNgay.SelectionFormula = "";
            this.crystalTKTheoKhoangNgay.Size = new System.Drawing.Size(964, 514);
            this.crystalTKTheoKhoangNgay.TabIndex = 0;
            this.crystalTKTheoKhoangNgay.ViewTimeSelectionFormula = "";
            // 
            // ViewThongKeTheoKhoangNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 514);
            this.Controls.Add(this.crystalTKTheoKhoangNgay);
            this.DoubleBuffered = true;
            this.Name = "ViewThongKeTheoKhoangNgay";
            this.Text = "Thống kê theo khoảng ngày";
            this.Load += new System.EventHandler(this.ViewThongKeTheoKhoangNgay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalTKTheoKhoangNgay;
    }
}