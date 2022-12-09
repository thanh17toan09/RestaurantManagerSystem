namespace RestaurantManagerSystem.GUI
{
    partial class ViewHoaDon
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
            this.crytalview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crytalview
            // 
            this.crytalview.ActiveViewIndex = -1;
            this.crytalview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crytalview.DisplayGroupTree = false;
            this.crytalview.DisplayStatusBar = false;
            this.crytalview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crytalview.Location = new System.Drawing.Point(0, 0);
            this.crytalview.Name = "crytalview";
            this.crytalview.SelectionFormula = "";
            this.crytalview.Size = new System.Drawing.Size(916, 513);
            this.crytalview.TabIndex = 0;
            this.crytalview.ViewTimeSelectionFormula = "";
            // 
            // ViewHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 513);
            this.Controls.Add(this.crytalview);
            this.DoubleBuffered = true;
            this.Name = "ViewHoaDon";
            this.Text = "ViewHoaDon";
            this.Load += new System.EventHandler(this.ViewHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crytalview;
    }
}