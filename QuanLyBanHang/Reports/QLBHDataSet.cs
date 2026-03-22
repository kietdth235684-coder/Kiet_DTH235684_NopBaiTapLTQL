using System.Data;

namespace QuanLyBanHang.Reports
{
    /// <summary>
    /// Typed DataSet thay thế cho QLBHDataSet.xsd (dùng trong môi trường không có designer RDLC).
    /// </summary>
    public class QLBHDataSet : DataSet
    {
        public DanhSachSanPhamDataTable DanhSachSanPham { get; }
        public DanhSachHoaDonDataTable DanhSachHoaDon { get; }
        public DanhSachHoaDon_ChiTietDataTable DanhSachHoaDon_ChiTiet { get; }

        public QLBHDataSet()
        {
            DataSetName = "QLBHDataSet";
            DanhSachSanPham = new DanhSachSanPhamDataTable();
            DanhSachHoaDon = new DanhSachHoaDonDataTable();
            DanhSachHoaDon_ChiTiet = new DanhSachHoaDon_ChiTietDataTable();
            Tables.Add(DanhSachSanPham);
            Tables.Add(DanhSachHoaDon);
            Tables.Add(DanhSachHoaDon_ChiTiet);
        }

        // ── DanhSachSanPham ──────────────────────────────────────────
        public class DanhSachSanPhamDataTable : DataTable
        {
            public DanhSachSanPhamDataTable() : base("DanhSachSanPham")
            {
                Columns.Add("ID", typeof(int));
                Columns.Add("HangSanXuatID", typeof(int));
                Columns.Add("TenHangSanXuat", typeof(string));
                Columns.Add("LoaiSanPhamID", typeof(int));
                Columns.Add("TenLoai", typeof(string));
                Columns.Add("TenSanPham", typeof(string));
                Columns.Add("DonGia", typeof(int));
                Columns.Add("SoLuong", typeof(int));
                Columns.Add("HinhAnh", typeof(string));
                Columns.Add("MoTa", typeof(string));
                PrimaryKey = new DataColumn[] { Columns["ID"]! };
            }

            public void AddDanhSachSanPhamRow(int id, int hangSanXuatID, string tenHangSanXuat,
                int loaiSanPhamID, string tenLoai, string tenSanPham,
                int donGia, int soLuong, string? hinhAnh, string? moTa)
            {
                DataRow row = NewRow();
                row["ID"] = id;
                row["HangSanXuatID"] = hangSanXuatID;
                row["TenHangSanXuat"] = tenHangSanXuat ?? "";
                row["LoaiSanPhamID"] = loaiSanPhamID;
                row["TenLoai"] = tenLoai ?? "";
                row["TenSanPham"] = tenSanPham ?? "";
                row["DonGia"] = donGia;
                row["SoLuong"] = soLuong;
                row["HinhAnh"] = (object?)hinhAnh ?? DBNull.Value;
                row["MoTa"] = (object?)moTa ?? DBNull.Value;
                Rows.Add(row);
            }
        }

        // ── DanhSachHoaDon ────────────────────────────────────────────
        public class DanhSachHoaDonDataTable : DataTable
        {
            public DanhSachHoaDonDataTable() : base("DanhSachHoaDon")
            {
                Columns.Add("ID", typeof(int));
                Columns.Add("NhanVienID", typeof(int));
                Columns.Add("HoVaTenNhanVien", typeof(string));
                Columns.Add("KhachHangID", typeof(int));
                Columns.Add("HoVaTenKhachHang", typeof(string));
                Columns.Add("NgayLap", typeof(DateTime));
                Columns.Add("GhiChuHoaDon", typeof(string));
                Columns.Add("TongTienHoaDon", typeof(double));
                PrimaryKey = new DataColumn[] { Columns["ID"]! };
            }

            public void AddDanhSachHoaDonRow(int id, int nhanVienID, string hoVaTenNhanVien,
                int khachHangID, string hoVaTenKhachHang, DateTime ngayLap,
                string? ghiChuHoaDon, double tongTienHoaDon)
            {
                DataRow row = NewRow();
                row["ID"] = id;
                row["NhanVienID"] = nhanVienID;
                row["HoVaTenNhanVien"] = hoVaTenNhanVien ?? "";
                row["KhachHangID"] = khachHangID;
                row["HoVaTenKhachHang"] = hoVaTenKhachHang ?? "";
                row["NgayLap"] = ngayLap;
                row["GhiChuHoaDon"] = (object?)ghiChuHoaDon ?? DBNull.Value;
                row["TongTienHoaDon"] = tongTienHoaDon;
                Rows.Add(row);
            }
        }

        // ── DanhSachHoaDon_ChiTiet ────────────────────────────────────
        public class DanhSachHoaDon_ChiTietDataTable : DataTable
        {
            public DanhSachHoaDon_ChiTietDataTable() : base("DanhSachHoaDon_ChiTiet")
            {
                Columns.Add("ID", typeof(int));
                Columns.Add("HoaDonID", typeof(int));
                Columns.Add("SanPhamID", typeof(int));
                Columns.Add("TenSanPham", typeof(string));
                Columns.Add("SoLuongBan", typeof(short));
                Columns.Add("DonGiaBan", typeof(int));
                Columns.Add("ThanhTien", typeof(int));
                PrimaryKey = new DataColumn[] { Columns["ID"]! };
            }

            public void AddDanhSachHoaDon_ChiTietRow(int id, int hoaDonID, int sanPhamID,
                string tenSanPham, short soLuongBan, int donGiaBan, int thanhTien)
            {
                DataRow row = NewRow();
                row["ID"] = id;
                row["HoaDonID"] = hoaDonID;
                row["SanPhamID"] = sanPhamID;
                row["TenSanPham"] = tenSanPham ?? "";
                row["SoLuongBan"] = soLuongBan;
                row["DonGiaBan"] = donGiaBan;
                row["ThanhTien"] = thanhTien;
                Rows.Add(row);
            }
        }
    }
}
