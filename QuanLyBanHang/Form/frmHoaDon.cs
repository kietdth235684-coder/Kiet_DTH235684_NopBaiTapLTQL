using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;

using static QuanLyBanHang.Data.HoaDon;

namespace QuanLyBanHang
{
    public partial class frmHoaDon : Form
    {
        //  Khai báo biến toàn cục
        QLBHDbContext context = new QLBHDbContext();
        int id;

        public frmHoaDon()
        {
            InitializeComponent();
        }

        //  Xử lý tải form
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;

            List<DanhSachHoaDon> hd = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGiaBan),
                XemChiTiet = "Xem chi tiết"
            }).ToList();

            dataGridView.DataSource = hd;
        }

        //  Xử lý khi nhấn nút Lập hóa đơn mới…
        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet())
            {
                chiTiet.ShowDialog();
            }
            frmHoaDon_Load(sender, e); // Tải lại dữ liệu
        }

        //  Xử lý khi nhấn nút Sửa…
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id))
                {
                    chiTiet.ShowDialog();
                }
                frmHoaDon_Load(sender, e); // Tải lại dữ liệu
            }
        }

        //  Xử lý khi nhấn nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var hoaDon = context.HoaDon.FirstOrDefault(h => h.ID == id);
                    if (hoaDon != null)
                    {
                        // Xóa chi tiết hóa đơn trước
                        context.HoaDon_ChiTiet.RemoveRange(hoaDon.HoaDon_ChiTiet);
                        // Xóa hóa đơn
                        context.HoaDon.Remove(hoaDon);
                        context.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        frmHoaDon_Load(sender, e); // Tải lại dữ liệu
                    }
                }
            }
        }

        // Nút Thoát - Đóng form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        // Nhập HoaDon
                        var wsHoaDon = workbook.Worksheet("HoaDon");
                        var dtHoaDon = wsHoaDon.RangeUsed().AsTable().AsNativeDataTable();
                        foreach (DataRow r in dtHoaDon.Rows)
                        {
                            int id = int.Parse(r["ID"].ToString());
                            if (context.HoaDon.Any(h => h.ID == id)) continue; // Tránh trùng ID

                            HoaDon hd = new HoaDon();
                            hd.ID = id;
                            hd.NhanVienID = int.Parse(r["NhanVienID"].ToString());
                            hd.KhachHangID = int.Parse(r["KhachHangID"].ToString());
                            hd.NgayLap = DateTime.Parse(r["NgayLap"].ToString());
                            hd.GhiChuHoaDon = r["GhiChuHoaDon"].ToString();
                            context.HoaDon.Add(hd);
                        }
                        context.SaveChanges();

                        // Nhập HoaDon_ChiTiet
                        var wsChiTiet = workbook.Worksheet("HoaDon_ChiTiet");
                        var dtChiTiet = wsChiTiet.RangeUsed().AsTable().AsNativeDataTable();
                        foreach (DataRow r in dtChiTiet.Rows)
                        {
                            int id = int.Parse(r["ID"].ToString());
                            if (context.HoaDon_ChiTiet.Any(ct => ct.ID == id)) continue; // Tránh trùng ID

                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                            ct.ID = id;
                            ct.HoaDonID = int.Parse(r["HoaDonID"].ToString());
                            ct.SanPhamID = int.Parse(r["SanPhamID"].ToString());
                            ct.SoLuongBan = int.Parse(r["SoLuongBan"].ToString());
                            ct.DonGiaBan = int.Parse(r["DonGiaBan"].ToString());
                            ct.GhiChuChiTiet = r["GhiChuChiTiet"].ToString();
                            context.HoaDon_ChiTiet.Add(ct);
                        }
                        context.SaveChanges();

                        MessageBox.Show("Đã nhập dữ liệu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmHoaDon_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Sheet HoaDon
                    DataTable dtHoaDon = new DataTable();
                    dtHoaDon.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("NhanVienID", typeof(int)),
                new DataColumn("KhachHangID", typeof(int)),
                new DataColumn("NgayLap", typeof(DateTime)),
                new DataColumn("GhiChuHoaDon", typeof(string))
            });

                    var hoaDonList = context.HoaDon.ToList();
                    foreach (var hd in hoaDonList)
                    {
                        dtHoaDon.Rows.Add(hd.ID, hd.NhanVienID, hd.KhachHangID, hd.NgayLap, hd.GhiChuHoaDon);
                    }

                    // Sheet HoaDon_ChiTiet
                    DataTable dtChiTiet = new DataTable();
                    dtChiTiet.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("HoaDonID", typeof(int)),
                new DataColumn("SanPhamID", typeof(int)),
                new DataColumn("SoLuongBan", typeof(int)),
                new DataColumn("DonGiaBan", typeof(int)),
                new DataColumn("GhiChuChiTiet", typeof(string))
            });

                    var chiTietList = context.HoaDon_ChiTiet.ToList();
                    foreach (var ct in chiTietList)
                    {
                        dtChiTiet.Rows.Add(ct.ID, ct.HoaDonID, ct.SanPhamID, ct.SoLuongBan, ct.DonGiaBan, ct.GhiChuChiTiet);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dtHoaDon, "HoaDon");
                        wb.Worksheets.Add(dtChiTiet, "HoaDon_ChiTiet");
                        foreach (var ws in wb.Worksheets)
                            ws.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

    }
}
