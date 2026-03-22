using QuanLyBanHang.Data;
using QuanLyBanHang.Forms;
using QuanLyBanHang.Reports;
using System.Diagnostics;
using BC = BCrypt.Net.BCrypt;

namespace QuanLyBanHang
{
    public partial class frmMain : Form
    {
        QLBHDbContext context = new QLBHDbContext();

        frmLoaiSanPham? loaiSanPham = null;
        frmHangSanXuat? hangSanXuat = null;
        frmSanPham? sanPham = null;
        frmKhachHang? khachHang = null;
        frmNhanVien? nhanVien = null;
        frmHoaDon? hoaDon = null;
        frmDangNhap? dangNhap = null;

        string hoVaTenNhanVien = "";

        public frmMain()
        {
            InitializeComponent();
            // Đăng ký HelpProvider cho frmMain – phím F1 và Ctrl+F1 mở trang hướng dẫn
            HelpSupport.DangKy(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
            DangNhap();
        }

        private void DangNhap()
        {
        LamLai:
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new frmDangNhap();

            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                string tenDangNhap = dangNhap.txtTenDangNhap.Text;
                string matKhau = dangNhap.txtMatKhau.Text;

                if (tenDangNhap.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                else if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtMatKhau.Focus();
                    goto LamLai;
                }
                else
                {
                    var nv = context.NhanVien
                        .Where(r => r.TenDangNhap == tenDangNhap)
                        .SingleOrDefault();

                    if (nv == null)
                    {
                        MessageBox.Show("Tên đăng nhập không chính xác!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtTenDangNhap.Focus();
                        goto LamLai;
                    }
                    else
                    {
                        bool matKhauHopLe = false;
                        try { matKhauHopLe = BC.Verify(matKhau, nv.MatKhau); }
                        catch { matKhauHopLe = (matKhau == nv.MatKhau); }

                        if (matKhauHopLe)
                        {
                            hoVaTenNhanVien = nv.HoVaTen;
                            if (nv.QuyenHan == true)
                                QuyenQuanLy();
                            else
                                QuyenNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không chính xác!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dangNhap.txtMatKhau.Focus();
                            goto LamLai;
                        }
                    }
                }
            }
        }

        public void ChuaDangNhap()
        {
            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;
            mnuLoaiSanPham.Enabled = false;
            mnuHangSanXuat.Enabled = false;
            mnuSanPham.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuHoaDon.Enabled = false;
            mnuThongKeSanPham.Enabled = false;
            mnuThongKeDoanhThu.Enabled = false;
            lblTrangThai.Text = "Chưa đăng nhập.";
        }

        public void QuyenQuanLy()
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuLoaiSanPham.Enabled = true;
            mnuHangSanXuat.Enabled = true;
            mnuSanPham.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuThongKeSanPham.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;
            lblTrangThai.Text = "Quản lý: " + hoVaTenNhanVien;
        }

        public void QuyenNhanVien()
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuLoaiSanPham.Enabled = false;
            mnuHangSanXuat.Enabled = false;
            mnuSanPham.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuKhachHang.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuThongKeSanPham.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;
            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
        }

        private void mnuDangNhap_Click(object sender, EventArgs e) => DangNhap();

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
                child.Close();
            ChuaDangNhap();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đổi mật khẩu đang phát triển.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuThoat_Click(object sender, EventArgs e) => Application.Exit();

        private void MoMdiForm<T>(ref T? field) where T : Form, new()
        {
            if (field == null || field.IsDisposed)
            {
                field = new T();
                field.MdiParent = this;
                field.Show();
            }
            else
                field.Activate();
        }

        private void mnuLoaiSanPham_Click(object sender, EventArgs e) => MoMdiForm(ref loaiSanPham);
        private void mnuHangSanXuat_Click(object sender, EventArgs e) => MoMdiForm(ref hangSanXuat);
        private void mnuSanPham_Click(object sender, EventArgs e) => MoMdiForm(ref sanPham);
        private void mnuKhachHang_Click(object sender, EventArgs e) => MoMdiForm(ref khachHang);
        private void mnuNhanVien_Click(object sender, EventArgs e) => MoMdiForm(ref nhanVien);
        private void mnuHoaDon_Click(object sender, EventArgs e) => MoMdiForm(ref hoaDon);

        private void mnuThongKeSanPham_Click(object sender, EventArgs e)
        {
            using var frm = new frmThongKeSanPham();
            frm.ShowDialog();
        }

        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            using var frm = new frmThongKeDoanhThu();
            frm.ShowDialog();
        }

        // ── Helper: mở trang HTML hướng dẫn bằng trình duyệt mặc định ──
        public static void MoTrangHuongDan()
        {
            // Tìm file Help\index.html tương đối so với thư mục exe
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            // Khi debug: …\bin\Debug\net8.0-windows\  →  lùi 3 cấp về thư mục project
            string helpFile = Path.Combine(exeDir, "Help", "index.html");
            if (!File.Exists(helpFile))
            {
                // Thử đường dẫn từ thư mục project (khi chạy trong VS)
                string projectDir = exeDir
                    .TrimEnd(Path.DirectorySeparatorChar)
                    .Replace(@"bin\Debug\net8.0-windows", "")
                    .Replace(@"bin\Release\net8.0-windows", "");
                helpFile = Path.Combine(projectDir, "Help", "index.html");
            }
            if (File.Exists(helpFile))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = helpFile,
                    UseShellExecute = true   // mở bằng trình duyệt mặc định
                });
            }
            else
            {
                MessageBox.Show("Không tìm thấy file hướng dẫn.\nĐường dẫn dự kiến:\n" + helpFile,
                    "Hướng dẫn sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            MoTrangHuongDan();
        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quản lý Bán hàng v1.0\n© 2024 FIT - AGU\n\nKhoa Công nghệ Thông tin\nTrường Đại học An Giang",
                "Thông tin phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblLienKet_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://fit.agu.edu.vn",
                UseShellExecute = true
            });
        }
    }
}
