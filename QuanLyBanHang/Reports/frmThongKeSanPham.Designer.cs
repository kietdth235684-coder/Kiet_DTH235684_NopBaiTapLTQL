using Microsoft.Reporting.WinForms;

namespace QuanLyBanHang.Reports
{
    partial class frmThongKeSanPham
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
            lblHang = new Label();
            cboHangSanXuat = new ComboBox();
            lblLoai = new Label();
            cboLoaiSanPham = new ComboBox();
            btnLocKetQua = new Button();
            reportViewer1 = new ReportViewer();

            pnlFilter.SuspendLayout();
            SuspendLayout();

            // pnlFilter
            pnlFilter.Controls.AddRange(new Control[] {
                lblHang, cboHangSanXuat, lblLoai, cboLoaiSanPham, btnLocKetQua });
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Height = 45;
            pnlFilter.Padding = new Padding(5);

            lblHang.AutoSize = true; lblHang.Location = new Point(8, 13); lblHang.Text = "Hãng sản xuất:";
            cboHangSanXuat.Location = new Point(100, 9); cboHangSanXuat.Size = new Size(180, 23);
            cboHangSanXuat.Name = "cboHangSanXuat"; cboHangSanXuat.DropDownStyle = ComboBoxStyle.DropDownList;

            lblLoai.AutoSize = true; lblLoai.Location = new Point(295, 13); lblLoai.Text = "Loại sản phẩm:";
            cboLoaiSanPham.Location = new Point(390, 9); cboLoaiSanPham.Size = new Size(180, 23);
            cboLoaiSanPham.Name = "cboLoaiSanPham"; cboLoaiSanPham.DropDownStyle = ComboBoxStyle.DropDownList;

            btnLocKetQua.Location = new Point(580, 8); btnLocKetQua.Size = new Size(100, 27);
            btnLocKetQua.Name = "btnLocKetQua"; btnLocKetQua.Text = "Lọc kết quả";
            btnLocKetQua.BackColor = Color.SteelBlue; btnLocKetQua.ForeColor = Color.White;
            btnLocKetQua.Click += btnLocKetQua_Click;

            // reportViewer1
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Name = "reportViewer1";

            // Form
            ClientSize = new Size(1100, 700);
            Controls.Add(reportViewer1);
            Controls.Add(pnlFilter);
            Name = "frmThongKeSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê sản phẩm";
            Load += frmThongKeSanPham_Load;

            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlFilter;
        private Label lblHang, lblLoai;
        private ComboBox cboHangSanXuat, cboLoaiSanPham;
        private Button btnLocKetQua;
        private ReportViewer reportViewer1;
    }
}
