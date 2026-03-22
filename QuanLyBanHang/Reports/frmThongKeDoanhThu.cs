using QuanLyBanHang.Data;
using Microsoft.Reporting.WinForms;

namespace QuanLyBanHang.Reports
{
    public partial class frmThongKeDoanhThu : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        QLBHDataSet.DanhSachHoaDonDataTable danhSachHoaDonDataTable = new QLBHDataSet.DanhSachHoaDonDataTable();
        string reportsFolder = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory
                .Replace("bin\\Debug\\net8.0-windows\\", "")
                .Replace("bin\\Debug\\net8.0-windows", ""),
            "Reports");

        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            HienThiBaoCao(null, null, "(Tất cả thời gian)");
        }

        private void HienThiBaoCao(DateTime? tuNgay, DateTime? denNgay, string moTa)
        {
            var query = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => (double)(ct.SoLuongBan * ct.DonGiaBan))
            }).AsQueryable();

            if (tuNgay.HasValue && denNgay.HasValue)
            {
                DateTime den = denNgay.Value.Date.AddDays(1);
                query = query.Where(r => r.NgayLap >= tuNgay.Value.Date && r.NgayLap < den);
            }

            var danhSach = query.ToList();

            danhSachHoaDonDataTable.Clear();
            foreach (var row in danhSach)
                danhSachHoaDonDataTable.AddDanhSachHoaDonRow(
                    row.ID, row.NhanVienID, row.HoVaTenNhanVien,
                    row.KhachHangID, row.HoVaTenKhachHang,
                    row.NgayLap, row.GhiChuHoaDon, row.TongTienHoaDon ?? 0);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DanhSachHoaDon", (System.Data.DataTable)danhSachHoaDonDataTable));
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");
            reportViewer1.LocalReport.SetParameters(
                new ReportParameter("MoTaKetQuaHienThi", moTa));
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            string moTa = "Từ ngày " + dtpTuNgay.Text + " - Đến ngày: " + dtpDenNgay.Text;
            HienThiBaoCao(dtpTuNgay.Value, dtpDenNgay.Value, moTa);
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            HienThiBaoCao(null, null, "(Tất cả thời gian)");
        }
    }
}
