using QuanLyBanHang.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace QuanLyBanHang.Forms
{
    public partial class frmHoaDon_ChiTiet : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        int id;
        bool isReadOnly;
        BindingList<DanhSachHoaDon_ChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>();

        public frmHoaDon_ChiTiet(int maHoaDon = 0, bool readOnly = false)
        {
            InitializeComponent();
            HelpSupport.DangKy(this);
            id = maHoaDon;
            isReadOnly = readOnly;
        }

        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
        }

        public void LayKhachHangVaoComboBox()
        {
            cboKhachHang.DataSource = context.KhachHang.ToList();
            cboKhachHang.ValueMember = "ID";
            cboKhachHang.DisplayMember = "HoVaTen";
        }

        public void LaySanPhamVaoComboBox()
        {
            cboSanPham.DataSource = context.SanPham.ToList();
            cboSanPham.ValueMember = "ID";
            cboSanPham.DisplayMember = "TenSanPham";
        }

        public void BatTatChucNang()
        {
            bool coSanPham = hoaDonChiTiet.Count > 0;
            btnLuuHoaDon.Enabled = coSanPham && !isReadOnly;
            btnXoa.Enabled = coSanPham && !isReadOnly;
        }

        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayKhachHangVaoComboBox();
            LaySanPhamVaoComboBox();
            dataGridView.AutoGenerateColumns = false;

            if (id != 0)
            {
                var hoaDon = context.HoaDon.Where(r => r.ID == id).SingleOrDefault();
                if (hoaDon != null)
                {
                    cboNhanVien.SelectedValue = hoaDon.NhanVienID;
                    cboKhachHang.SelectedValue = hoaDon.KhachHangID;
                    txtGhiChuHoaDon.Text = hoaDon.GhiChuHoaDon;
                }

                var ct = context.HoaDon_ChiTiet
                    .Where(r => r.HoaDonID == id)
                    .Include(r => r.SanPham)
                    .Select(r => new DanhSachHoaDon_ChiTiet
                    {
                        ID = r.ID,
                        HoaDonID = r.HoaDonID,
                        SanPhamID = r.SanPhamID,
                        TenSanPham = r.SanPham.TenSanPham,
                        SoLuongBan = r.SoLuongBan,
                        DonGiaBan = r.DonGiaBan,
                        ThanhTien = r.SoLuongBan * r.DonGiaBan
                    }).ToList();

                hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>(ct);
            }

            dataGridView.DataSource = hoaDonChiTiet;

            if (isReadOnly)
            {
                cboNhanVien.Enabled = false;
                cboKhachHang.Enabled = false;
                txtGhiChuHoaDon.Enabled = false;
                cboSanPham.Enabled = false;
                numSoLuongBan.Enabled = false;
                numDonGiaBan.Enabled = false;
                btnXacNhanBan.Enabled = false;
                grpChiTiet.Text = "Chi tiết hóa đơn (chỉ xem)";
            }

            BatTatChucNang();
        }

        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSanPham.Text))
            { MessageBox.Show("Vui lòng chọn sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (numSoLuongBan.Value <= 0)
            { MessageBox.Show("Số lượng bán phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (numDonGiaBan.Value <= 0)
            { MessageBox.Show("Đơn giá bán sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int maSanPham = Convert.ToInt32(cboSanPham.SelectedValue);
            var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);

            if (chiTiet != null)
            {
                // Cập nhật nếu đã tồn tại
                chiTiet.SoLuongBan = Convert.ToInt16(numSoLuongBan.Value);
                chiTiet.DonGiaBan = Convert.ToInt32(numDonGiaBan.Value);
                chiTiet.ThanhTien = Convert.ToInt32(numSoLuongBan.Value * numDonGiaBan.Value);
                dataGridView.Refresh();
            }
            else
            {
                DanhSachHoaDon_ChiTiet ct = new DanhSachHoaDon_ChiTiet
                {
                    ID = 0,
                    HoaDonID = id,
                    SanPhamID = maSanPham,
                    TenSanPham = cboSanPham.Text,
                    SoLuongBan = Convert.ToInt16(numSoLuongBan.Value),
                    DonGiaBan = Convert.ToInt32(numDonGiaBan.Value),
                    ThanhTien = Convert.ToInt32(numSoLuongBan.Value * numDonGiaBan.Value)
                };
                hoaDonChiTiet.Add(ct);
            }
            BatTatChucNang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            int maSanPham = Convert.ToInt32(dataGridView.CurrentRow.Cells["SanPhamID"].Value.ToString());
            var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);
            if (chiTiet != null)
                hoaDonChiTiet.Remove(chiTiet);
            BatTatChucNang();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboNhanVien.Text))
            { MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (string.IsNullOrWhiteSpace(cboKhachHang.Text))
            { MessageBox.Show("Vui lòng chọn khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (hoaDonChiTiet.Count == 0)
            { MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (id != 0)
            {
                // Cập nhật hóa đơn
                HoaDon? hd = context.HoaDon.Find(id);
                if (hd != null)
                {
                    hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue);
                    hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue);
                    hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                    context.HoaDon.Update(hd);

                    // Xóa chi tiết cũ
                    var old = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).ToList();
                    context.HoaDon_ChiTiet.RemoveRange(old);

                    // Thêm lại chi tiết mới
                    foreach (var item in hoaDonChiTiet)
                    {
                        context.HoaDon_ChiTiet.Add(new HoaDon_ChiTiet
                        {
                            HoaDonID = id,
                            SanPhamID = item.SanPhamID,
                            SoLuongBan = item.SoLuongBan,
                            DonGiaBan = item.DonGiaBan
                        });
                    }
                    context.SaveChanges();
                }
            }
            else
            {
                // Thêm hóa đơn mới
                HoaDon hd = new HoaDon
                {
                    NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue),
                    KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue),
                    NgayLap = DateTime.Now,
                    GhiChuHoaDon = txtGhiChuHoaDon.Text
                };
                context.HoaDon.Add(hd);
                context.SaveChanges();

                foreach (var item in hoaDonChiTiet)
                {
                    context.HoaDon_ChiTiet.Add(new HoaDon_ChiTiet
                    {
                        HoaDonID = hd.ID,
                        SanPhamID = item.SanPhamID,
                        SoLuongBan = item.SoLuongBan,
                        DonGiaBan = item.DonGiaBan
                    });
                }
                context.SaveChanges();
            }

            MessageBox.Show("Đã lưu hóa đơn thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (hoaDonChiTiet.Count == 0)
            { MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string tenNV = cboNhanVien.Text;
            string tenKH = cboKhachHang.Text;
            double tongTien = hoaDonChiTiet.Sum(x => (double)x.ThanhTien);

            string info = $"=== HÓA ĐƠN BÁN HÀNG ===\n\n" +
                          $"Nhân viên: {tenNV}\nKhách hàng: {tenKH}\n" +
                          $"Ngày lập: {DateTime.Now:dd/MM/yyyy}\n\n" +
                          $"--- SẢN PHẨM ---\n";
            foreach (var item in hoaDonChiTiet)
                info += $"{item.TenSanPham}: {item.SoLuongBan} x {item.DonGiaBan:N0} = {item.ThanhTien:N0}\n";
            info += $"\nTỔNG TIỀN: {tongTien:N0} VNĐ";

            MessageBox.Show(info, "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null) return;
            int maSanPham = Convert.ToInt32(cboSanPham.SelectedValue);
            var sanPham = context.SanPham.Find(maSanPham);
            if (sanPham != null)
                numDonGiaBan.Value = sanPham.DonGia;
        }
    }
}
