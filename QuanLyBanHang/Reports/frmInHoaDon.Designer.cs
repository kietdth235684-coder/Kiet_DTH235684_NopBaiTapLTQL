using Microsoft.Reporting.WinForms;

namespace QuanLyBanHang.Reports
{
    partial class frmInHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            reportViewer1 = new ReportViewer();
            SuspendLayout();

            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Name = "reportViewer1";

            ClientSize = new Size(900, 700);
            Controls.Add(reportViewer1);
            Name = "frmInHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "In hóa đơn";
            Load += frmInHoaDon_Load;

            ResumeLayout(false);
        }

        private ReportViewer reportViewer1;
    }
}
