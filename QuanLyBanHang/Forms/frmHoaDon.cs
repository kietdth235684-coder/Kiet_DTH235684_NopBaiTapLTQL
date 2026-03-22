using QuanLyBanHang.Data;
using QuanLyBanHang.Reports;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyBanHang.Forms
{
    public partial class frmHoaDon : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        int id;

        public frmHoaDon()
        {
            InitializeComponent();
            HelpSupport.DangKy(this);
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            LoadData();
        }

        private void LoadData()
        {
            List<DanhSachHoaDon> hd = context.HoaDon
                .Include(r => r.NhanVien)
                .Include(r => r.KhachHang)
                .Include(r => r.HoaDon_ChiTiet)
                .Select(r => new DanhSachHoaDon
                {
                    ID = r.ID,
                    NhanVienID = r.NhanVienID,
                    HoVaTenNhanVien = r.NhanVien.HoVaTen,
                    KhachHangID = r.KhachHangID,
                    HoVaTenKhachHang = r.KhachHang.HoVaTen,
                    NgayLap = r.NgayLap,
                    GhiChuHoaDon = r.GhiChuHoaDon,
                    TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => (double)(ct.SoLuongBan * ct.DonGiaBan)),
                    XemChiTiet = "Xem chi tiết"
                }).ToList();
            dataGridView.DataSource = hd;
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet())
            {
                chiTiet.ShowDialog();
            }
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id))
            {
                chiTiet.ShowDialog();
            }
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());

            if (MessageBox.Show("Xác nhận xóa hóa đơn này?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Xóa chi tiết trước
                var chiTiet = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).ToList();
                context.HoaDon_ChiTiet.RemoveRange(chiTiet);

                // Xóa hóa đơn
                HoaDon? hd = context.HoaDon.Find(id);
                if (hd != null)
                    context.HoaDon.Remove(hd);

                context.SaveChanges();
                LoadData();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id, readOnly: true))
                {
                    chiTiet.ShowDialog();
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmInHoaDon inHoaDon = new frmInHoaDon(id))
            {
                inHoaDon.ShowDialog();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên khách hàng hoặc nhân viên cần tìm:", "Tìm kiếm", "");
            if (string.IsNullOrWhiteSpace(keyword)) return;

            var hd = context.HoaDon
                .Include(r => r.NhanVien)
                .Include(r => r.KhachHang)
                .Include(r => r.HoaDon_ChiTiet)
                .Where(r => r.NhanVien.HoVaTen.Contains(keyword) || r.KhachHang.HoVaTen.Contains(keyword))
                .Select(r => new DanhSachHoaDon
                {
                    ID = r.ID,
                    NhanVienID = r.NhanVienID,
                    HoVaTenNhanVien = r.NhanVien.HoVaTen,
                    KhachHangID = r.KhachHangID,
                    HoVaTenKhachHang = r.KhachHang.HoVaTen,
                    NgayLap = r.NgayLap,
                    GhiChuHoaDon = r.GhiChuHoaDon,
                    TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => (double)(ct.SoLuongBan * ct.DonGiaBan)),
                    XemChiTiet = "Xem chi tiết"
                }).ToList();
            dataGridView.DataSource = hd;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Xuất dữ liệu ra tập tin Excel";
            sfd.Filter = "Tập tin Excel|*.xlsx";
            sfd.FileName = "HoaDon_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Sheet 1: HoaDon
                    DataTable tableHD = new DataTable();
                    tableHD.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTenNhanVien", typeof(string)),
                        new DataColumn("HoVaTenKhachHang", typeof(string)),
                        new DataColumn("NgayLap", typeof(string)),
                        new DataColumn("TongTienHoaDon", typeof(double)),
                        new DataColumn("GhiChuHoaDon", typeof(string))
                    });

                    var dshd = context.HoaDon
                        .Include(r => r.NhanVien).Include(r => r.KhachHang).Include(r => r.HoaDon_ChiTiet)
                        .ToList();
                    foreach (var hd in dshd)
                        tableHD.Rows.Add(hd.ID, hd.NhanVien.HoVaTen, hd.KhachHang.HoVaTen,
                            hd.NgayLap.ToString("dd/MM/yyyy"),
                            hd.HoaDon_ChiTiet.Sum(ct => (double)(ct.SoLuongBan * ct.DonGiaBan)),
                            hd.GhiChuHoaDon);

                    // Sheet 2: HoaDon_ChiTiet
                    DataTable tableCT = new DataTable();
                    tableCT.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoaDonID", typeof(int)),
                        new DataColumn("TenSanPham", typeof(string)),
                        new DataColumn("SoLuongBan", typeof(int)),
                        new DataColumn("DonGiaBan", typeof(int)),
                        new DataColumn("ThanhTien", typeof(long))
                    });

                    var dsct = context.HoaDon_ChiTiet.Include(r => r.SanPham).ToList();
                    foreach (var ct in dsct)
                        tableCT.Rows.Add(ct.ID, ct.HoaDonID, ct.SanPham.TenSanPham,
                            ct.SoLuongBan, ct.DonGiaBan, (long)ct.SoLuongBan * ct.DonGiaBan);

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheetHD = wb.Worksheets.Add(tableHD, "HoaDon");
                        sheetHD.Columns().AdjustToContents();
                        var sheetCT = wb.Worksheets.Add(tableCT, "HoaDon_ChiTiet");
                        sheetCT.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Đã xuất dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
