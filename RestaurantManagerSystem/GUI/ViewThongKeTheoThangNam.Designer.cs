namespace RestaurantManagerSystem.GUI
{
    partial class ViewThongKeTheoThangNam
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
            this.crystalTKTheoThangNam = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalTKTheoThangNam
            // 
            this.crystalTKTheoThangNam.ActiveViewIndex = -1;
            this.crystalTKTheoThangNam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalTKTheoThangNam.DisplayGroupTree = false;
            this.crystalTKTheoThangNam.DisplayStatusBar = false;
            this.crystalTKTheoThangNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalTKTheoThangNam.Location = new System.Drawing.Point(0, 0);
            this.crystalTKTheoThangNam.Name = "crystalTKTheoThangNam";
            this.crystalTKTheoThangNam.SelectionFormula = "";
            this.crystalTKTheoThangNam.Size = new System.Drawing.Size(961, 513);
            this.crystalTKTheoThangNam.TabIndex = 0;
            this.crystalTKTheoThangNam.ViewTimeSelectionFormula = "";
            // 
            // ViewThongKeTheoThangNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 513);
            this.Controls.Add(this.crystalTKTheoThangNam);
            this.DoubleBuffered = true;
            this.Name = "ViewThongKeTheoThangNam";
            this.Text = "Thống kê theo tháng năm";
            this.Load += new System.EventHandler(this.ViewThongKeTheoThangNam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalTKTheoThangNam;
    }
}