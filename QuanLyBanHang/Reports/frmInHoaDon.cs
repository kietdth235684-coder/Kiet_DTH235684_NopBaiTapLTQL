using QuanLyBanHang.Data;
using Microsoft.Reporting.WinForms;
using Microsoft.EntityFrameworkCore;

namespace QuanLyBanHang.Reports
{
    public partial class frmInHoaDon : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        QLBHDataSet.DanhSachHoaDon_ChiTietDataTable danhSachHoaDon_ChiTietDataTable =
            new QLBHDataSet.DanhSachHoaDon_ChiTietDataTable();
        string reportsFolder = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory
                .Replace("bin\\Debug\\net8.0-windows\\", "")
                .Replace("bin\\Debug\\net8.0-windows", ""),
            "Reports");
        int id;

        public frmInHoaDon(int maHoaDon = 0)
        {
            InitializeComponent();
            HelpSupport.DangKy(this);
            id = maHoaDon;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            var hoaDon = context.HoaDon
                .Include(r => r.KhachHang)
                .Include(r => r.HoaDon_ChiTiet)
                .Where(r => r.ID == id)
                .SingleOrDefault();

            if (hoaDon == null) return;

            var chiTiet = context.HoaDon_ChiTiet
                .Where(r => r.HoaDonID == id)
                .Select(r => new DanhSachHoaDon_ChiTiet
                {
                    ID = r.ID,
                    HoaDonID = r.HoaDonID,
                    SanPhamID = r.SanPhamID,
                    TenSanPham = r.SanPham.TenSanPham,
                    SoLuongBan = r.SoLuongBan,
                    DonGiaBan = r.DonGiaBan,
                    ThanhTien = Convert.ToInt32(r.SoLuongBan * r.DonGiaBan)
                }).ToList();

            danhSachHoaDon_ChiTietDataTable.Clear();
            foreach (var row in chiTiet)
                danhSachHoaDon_ChiTietDataTable.AddDanhSachHoaDon_ChiTietRow(
                    row.ID, row.HoaDonID, row.SanPhamID, row.TenSanPham,
                    row.SoLuongBan, row.DonGiaBan, row.ThanhTien);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DanhSachHoaDon_ChiTiet",
                    (System.Data.DataTable)danhSachHoaDon_ChiTietDataTable));
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptInHoaDon.rdlc");

            long tongTien = hoaDon.HoaDon_ChiTiet.Sum(r => (long)r.SoLuongBan * r.DonGiaBan);

            var parameters = new List<ReportParameter>
            {
                new ReportParameter("NgayLap", string.Format("Ngày {0} Tháng {1} Năm {2}",
                    hoaDon.NgayLap.Day, hoaDon.NgayLap.Month, hoaDon.NgayLap.Year)),
                new ReportParameter("NguoiBan_Ten", "CÔNG TY TNHH LAZY ANT"),
                new ReportParameter("NguoiBan_DiaChi", "Mỹ Phước, TP. Long Xuyên, An Giang"),
                new ReportParameter("NguoiBan_MaSoThue", "1602162070"),
                new ReportParameter("NguoiMua_Ten", hoaDon.KhachHang.HoVaTen),
                new ReportParameter("NguoiMua_DiaChi", hoaDon.KhachHang.DiaChi ?? ""),
                new ReportParameter("NguoiMua_MaSoThue", ""),
                new ReportParameter("TongTien", tongTien.ToString("N0"))
            };

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }
    }
}
