using Microsoft.Reporting.WinForms;

namespace QuanLyBanHang.Reports
{
    partial class frmThongKeDoanhThu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlFilter = new Panel();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnLocKetQua = new Button();
            btnHienTatCa = new Button();
            reportViewer1 = new ReportViewer();

            pnlFilter.SuspendLayout();
            SuspendLayout();

            // pnlFilter
            pnlFilter.Controls.AddRange(new Control[] {
                lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLocKetQua, btnHienTatCa });
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Height = 45;
            pnlFilter.Padding = new Padding(5);

            lblTuNgay.AutoSize = true; lblTuNgay.Location = new Point(8, 13); lblTuNgay.Text = "Từ ngày:";
            dtpTuNgay.Location = new Point(75, 9); dtpTuNgay.Size = new Size(130, 23);
            dtpTuNgay.Name = "dtpTuNgay"; dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.MinDate = new DateTime(2020, 1, 1);
            dtpTuNgay.MaxDate = new DateTime(2100, 12, 31);

            lblDenNgay.AutoSize = true; lblDenNgay.Location = new Point(215, 13); lblDenNgay.Text = "Đến ngày:";
            dtpDenNgay.Location = new Point(285, 9); dtpDenNgay.Size = new Size(130, 23);
            dtpDenNgay.Name = "dtpDenNgay"; dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.MinDate = new DateTime(2020, 1, 1);
            dtpDenNgay.MaxDate = new DateTime(2100, 12, 31);

            btnLocKetQua.Location = new Point(430, 8); btnLocKetQua.Size = new Size(100, 27);
            btnLocKetQua.Name = "btnLocKetQua"; btnLocKetQua.Text = "Lọc kết quả";
            btnLocKetQua.BackColor = Color.SteelBlue; btnLocKetQua.ForeColor = Color.White;
            btnLocKetQua.Click += btnLocKetQua_Click;

            btnHienTatCa.Location = new Point(540, 8); btnHienTatCa.Size = new Size(100, 27);
            btnHienTatCa.Name = "btnHienTatCa"; btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.Click += btnHienTatCa_Click;

            // reportViewer1
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Name = "reportViewer1";

            // Form
            ClientSize = new Size(1100, 700);
            Controls.Add(reportViewer1);
            Controls.Add(pnlFilter);
            Name = "frmThongKeDoanhThu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê doanh thu";
            Load += frmThongKeDoanhThu_Load;

            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlFilter;
        private Label lblTuNgay, lblDenNgay;
        private DateTimePicker dtpTuNgay, dtpDenNgay;
        private Button btnLocKetQua, btnHienTatCa;
        private ReportViewer reportViewer1;
    }
}
