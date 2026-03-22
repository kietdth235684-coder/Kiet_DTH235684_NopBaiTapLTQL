using QuanLyBanHang.Data;
using Microsoft.Reporting.WinForms;

namespace QuanLyBanHang.Reports
{
    public partial class frmThongKeSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        QLBHDataSet.DanhSachSanPhamDataTable danhSachSanPhamDataTable = new QLBHDataSet.DanhSachSanPhamDataTable();
        string reportsFolder = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory
                .Replace("bin\\Debug\\net8.0-windows\\", "")
                .Replace("bin\\Debug\\net8.0-windows", ""),
            "Reports");

        public frmThongKeSanPham()
        {
            InitializeComponent();
            HelpSupport.DangKy(this);
        }

        // Đưa dữ liệu Loại sản phẩm vào ComboBox
        public void LayLoaiSanPhamVaoComboBox()
        {
            var list = context.LoaiSanPham.OrderBy(r => r.TenLoai).ToList();
            cboLoaiSanPham.DisplayMember = "TenLoai";
            cboLoaiSanPham.ValueMember = "ID";
            cboLoaiSanPham.DataSource = list;
            cboLoaiSanPham.SelectedIndex = -1;
            cboLoaiSanPham.Text = "";
        }

        // Đưa dữ liệu Hãng sản xuất vào ComboBox
        public void LayHangSanXuatVaoComboBox()
        {
            var list = context.HangSanXuat.OrderBy(r => r.TenHangSanXuat).ToList();
            cboHangSanXuat.DisplayMember = "TenHangSanXuat";
            cboHangSanXuat.ValueMember = "ID";
            cboHangSanXuat.DataSource = list;
            cboHangSanXuat.SelectedIndex = -1;
            cboHangSanXuat.Text = "";
        }

        private void frmThongKeSanPham_Load(object sender, EventArgs e)
        {
            LayLoaiSanPhamVaoComboBox();
            LayHangSanXuatVaoComboBox();
            HienThiBaoCao("(Tất cả sản phẩm)", null, null);
        }

        private void HienThiBaoCao(string moTa, int? hangSanXuatID, int? loaiSanPhamID)
        {
            var query = context.SanPham.Select(r => new DanhSachSanPham
            {
                ID = r.ID,
                HangSanXuatID = r.HangSanXuatID,
                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                LoaiSanPhamID = r.LoaiSanPhamID,
                TenLoai = r.LoaiSanPham.TenLoai,
                TenSanPham = r.TenSanPham,
                DonGia = r.DonGia,
                SoLuong = r.SoLuong,
                HinhAnh = r.HinhAnh,
                MoTa = r.MoTa
            }).AsQueryable();

            if (hangSanXuatID.HasValue)
                query = query.Where(r => r.HangSanXuatID == hangSanXuatID.Value);
            if (loaiSanPhamID.HasValue)
                query = query.Where(r => r.LoaiSanPhamID == loaiSanPhamID.Value);

            var danhSach = query.ToList();

            danhSachSanPhamDataTable.Clear();
            foreach (var row in danhSach)
                danhSachSanPhamDataTable.AddDanhSachSanPhamRow(
                    row.ID, row.HangSanXuatID, row.TenHangSanXuat,
                    row.LoaiSanPhamID, row.TenLoai, row.TenSanPham,
                    row.DonGia, row.SoLuong, row.HinhAnh, row.MoTa);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DanhSachSanPham", (System.Data.DataTable)danhSachSanPhamDataTable));
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeSanPham.rdlc");
            reportViewer1.LocalReport.SetParameters(
                new ReportParameter("MoTaKetQuaHienThi", moTa));
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            if (cboHangSanXuat.Text == "" && cboLoaiSanPham.Text == "")
            {
                HienThiBaoCao("(Tất cả sản phẩm)", null, null);
                return;
            }

            int? hangSanXuatID = null;
            int? loaiSanPhamID = null;
            string hangPart = "";
            string loaiPart = "";

            if (cboHangSanXuat.Text != "" && cboHangSanXuat.SelectedValue != null)
            {
                hangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);
                hangPart = "Hãng sản xuất: " + cboHangSanXuat.Text;
            }
            if (cboLoaiSanPham.Text != "" && cboLoaiSanPham.SelectedValue != null)
            {
                loaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);
                loaiPart = "Phân loại: " + cboLoaiSanPham.Text;
            }

            string moTa = "(" + string.Join(" - ", new[] { hangPart, loaiPart }
                .Where(s => s != "")) + ")";

            HienThiBaoCao(moTa, hangSanXuatID, loaiSanPhamID);
        }
    }
}
