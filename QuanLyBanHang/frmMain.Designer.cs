namespace QuanLyBanHang
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            statusStrip = new StatusStrip();

            // Menu chính
            mnuHeThong = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();

            mnuQuanLy = new ToolStripMenuItem();
            mnuLoaiSanPham = new ToolStripMenuItem();
            mnuHangSanXuat = new ToolStripMenuItem();
            mnuSanPham = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            mnuHoaDon = new ToolStripMenuItem();

            mnuBaoCaoThongKe = new ToolStripMenuItem();
            mnuThongKeSanPham = new ToolStripMenuItem();
            mnuThongKeDoanhThu = new ToolStripMenuItem();

            mnuTroGiup = new ToolStripMenuItem();
            mnuHuongDanSuDung = new ToolStripMenuItem();
            mnuThongTinPhanMem = new ToolStripMenuItem();

            // Status labels
            lblTrangThai = new ToolStripStatusLabel();
            lblSpacer = new ToolStripStatusLabel();
            lblLienKet = new ToolStripStatusLabel();

            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();

            // ── menuStrip ──
            menuStrip.Items.AddRange(new ToolStripItem[] {
                mnuHeThong, mnuQuanLy, mnuBaoCaoThongKe, mnuTroGiup });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1024, 24);
            menuStrip.Text = "menuStrip";

            // Hệ thống
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Text = "Hệ thống";
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] {
                mnuDangNhap, mnuDangXuat, mnuDoiMatKhau, new ToolStripSeparator(), mnuThoat });

            mnuDangNhap.Name = "mnuDangNhap"; mnuDangNhap.Text = "Đăng nhập...";
            mnuDangNhap.Click += mnuDangNhap_Click;

            mnuDangXuat.Name = "mnuDangXuat"; mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;

            mnuDoiMatKhau.Name = "mnuDoiMatKhau"; mnuDoiMatKhau.Text = "Đổi mật khẩu...";
            mnuDoiMatKhau.Click += mnuDoiMatKhau_Click;

            mnuThoat.Name = "mnuThoat"; mnuThoat.Text = "Thoát";
            mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuThoat.Click += mnuThoat_Click;

            // Quản lý
            mnuQuanLy.Name = "mnuQuanLy"; mnuQuanLy.Text = "Quản lý";
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] {
                mnuLoaiSanPham, mnuHangSanXuat, mnuSanPham,
                mnuKhachHang, mnuNhanVien, mnuHoaDon });

            mnuLoaiSanPham.Name = "mnuLoaiSanPham"; mnuLoaiSanPham.Text = "Loại sản phẩm...";
            mnuLoaiSanPham.Click += mnuLoaiSanPham_Click;

            mnuHangSanXuat.Name = "mnuHangSanXuat"; mnuHangSanXuat.Text = "Hãng sản xuất...";
            mnuHangSanXuat.Click += mnuHangSanXuat_Click;

            mnuSanPham.Name = "mnuSanPham"; mnuSanPham.Text = "Sản phẩm...";
            mnuSanPham.Click += mnuSanPham_Click;

            mnuKhachHang.Name = "mnuKhachHang"; mnuKhachHang.Text = "Khách hàng...";
            mnuKhachHang.Click += mnuKhachHang_Click;

            mnuNhanVien.Name = "mnuNhanVien"; mnuNhanVien.Text = "Nhân viên...";
            mnuNhanVien.Click += mnuNhanVien_Click;

            mnuHoaDon.Name = "mnuHoaDon"; mnuHoaDon.Text = "Hóa đơn bán hàng...";
            mnuHoaDon.Click += mnuHoaDon_Click;

            // Báo cáo – Thống kê
            mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe"; mnuBaoCaoThongKe.Text = "Báo cáo - Thống kê";
            mnuBaoCaoThongKe.DropDownItems.AddRange(new ToolStripItem[] {
                mnuThongKeSanPham, mnuThongKeDoanhThu });

            mnuThongKeSanPham.Name = "mnuThongKeSanPham"; mnuThongKeSanPham.Text = "Thống kê sản phẩm...";
            mnuThongKeSanPham.Click += mnuThongKeSanPham_Click;

            mnuThongKeDoanhThu.Name = "mnuThongKeDoanhThu"; mnuThongKeDoanhThu.Text = "Thống kê doanh thu...";
            mnuThongKeDoanhThu.Click += mnuThongKeDoanhThu_Click;

            // Trợ giúp
            mnuTroGiup.Name = "mnuTroGiup"; mnuTroGiup.Text = "Trợ giúp";
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] {
                mnuHuongDanSuDung, mnuThongTinPhanMem });

            mnuHuongDanSuDung.Name = "mnuHuongDanSuDung"; mnuHuongDanSuDung.Text = "Hướng dẫn sử dụng";
            mnuHuongDanSuDung.ShortcutKeys = Keys.Control | Keys.F1;
            mnuHuongDanSuDung.Click += mnuHuongDanSuDung_Click;

            mnuThongTinPhanMem.Name = "mnuThongTinPhanMem"; mnuThongTinPhanMem.Text = "Thông tin phần mềm...";
            mnuThongTinPhanMem.Click += mnuThongTinPhanMem_Click;

            // ── statusStrip ──
            statusStrip.Items.AddRange(new ToolStripItem[] { lblTrangThai, lblSpacer, lblLienKet });
            statusStrip.Location = new Point(0, 738);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1024, 22);
            statusStrip.Text = "statusStrip";

            lblTrangThai.Name = "lblTrangThai"; lblTrangThai.Text = "Chưa đăng nhập.";

            lblSpacer.Name = "lblSpacer"; lblSpacer.Spring = true; lblSpacer.Text = "";

            lblLienKet.Name = "lblLienKet"; lblLienKet.Text = "© 2024 FIT";
            lblLienKet.IsLink = true;
            lblLienKet.Click += lblLienKet_Click;

            // ── Form ──
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 760);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý bán hàng";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;

            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip;
        private StatusStrip statusStrip;

        private ToolStripMenuItem mnuHeThong, mnuDangNhap, mnuDangXuat, mnuDoiMatKhau, mnuThoat;
        private ToolStripMenuItem mnuQuanLy, mnuLoaiSanPham, mnuHangSanXuat, mnuSanPham,
                                   mnuKhachHang, mnuNhanVien, mnuHoaDon;
        private ToolStripMenuItem mnuBaoCaoThongKe, mnuThongKeSanPham, mnuThongKeDoanhThu;
        private ToolStripMenuItem mnuTroGiup, mnuHuongDanSuDung, mnuThongTinPhanMem;

        private ToolStripStatusLabel lblTrangThai, lblSpacer, lblLienKet;
    }
}
