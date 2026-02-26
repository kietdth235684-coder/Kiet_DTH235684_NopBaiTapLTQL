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

            List<DanhSachHoaDon> hd = new List<DanhSachHoaDon>();
            hd = context.HoaDon.Select(r => new DanhSachHoaDon
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

        private void btnLapHoaDon_Click_1(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet())
            {
                chiTiet.ShowDialog();
            }
            frmHoaDon_Load(sender, e); // Tải lại dữ liệu
        }
    }
}
