namespace RestaurantManagerSystem.GUI
{
    partial class ViewThongKeTheoNgay
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
            this.crystalTKTheongay = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalTKTheongay
            // 
            this.crystalTKTheongay.ActiveViewIndex = -1;
            this.crystalTKTheongay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalTKTheongay.DisplayGroupTree = false;
            this.crystalTKTheongay.DisplayStatusBar = false;
            this.crystalTKTheongay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalTKTheongay.Location = new System.Drawing.Point(0, 0);
            this.crystalTKTheongay.Name = "crystalTKTheongay";
            this.crystalTKTheongay.SelectionFormula = "";
            this.crystalTKTheongay.Size = new System.Drawing.Size(928, 521);
            this.crystalTKTheongay.TabIndex = 0;
            this.crystalTKTheongay.ViewTimeSelectionFormula = "";
            // 
            // ViewThongKeTheoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 521);
            this.Controls.Add(this.crystalTKTheongay);
            this.DoubleBuffered = true;
            this.Name = "ViewThongKeTheoNgay";
            this.Text = "Thống kê theo ngày";
            this.Load += new System.EventHandler(this.ViewThongKeTheoNgay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalTKTheongay;
    }
}