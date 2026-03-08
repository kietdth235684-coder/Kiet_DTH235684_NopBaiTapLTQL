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

namespace QuanLyBanHang
{
    public partial class frmHoaDon_ChiTiet : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        int id;
        BindingList<DanhSachHoaDon_ChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>();

        public frmHoaDon_ChiTiet()
        {
            InitializeComponent();
        }

        public frmHoaDon_ChiTiet(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
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
            if (id == 0 && dataGridView.Rows.Count == 0) // Thêm 
            {
                // Xóa trắng các trường 
                cboKhachHang.Text = "";
                cboNhanVien.Text = "";
                cboSanPham.Text = "";
                numSoLuongBan.Value = 1;
                numDonGiaBan.Value = 0;
            }

            // Nút lưu và xóa chỉ sáng khi có sản phẩm 
            btnLuuHoaDon.Enabled = dataGridView.Rows.Count > 0;
            btnXoa.Enabled = dataGridView.Rows.Count > 0;
        }

        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayKhachHangVaoComboBox();
            LaySanPhamVaoComboBox();

            dataGridView.AutoGenerateColumns = false;
            if (id != 0)
            {
                var hoaDon = context.HoaDon.SingleOrDefault(r => r.ID == id);
                cboNhanVien.SelectedValue = hoaDon.NhanVienID;
                cboKhachHang.SelectedValue = hoaDon.KhachHangID;
                txtGhiChuHoaDon.Text = hoaDon.GhiChuHoaDon;

                var ct = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).Select(r => new DanhSachHoaDon_ChiTiet
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
            BatTatChucNang();
        }

        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSanPham.Text))
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuongBan.Value <= 0)
                MessageBox.Show("Số lượng bán phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGiaBan.Value <= 0)
                MessageBox.Show("Đơn giá bán sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int maSanPham = Convert.ToInt32(cboSanPham.SelectedValue);
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);

                if (chiTiet != null)
                {
                    chiTiet.SoLuongBan = Convert.ToInt16(numSoLuongBan.Value);
                    chiTiet.DonGiaBan = Convert.ToInt32(numDonGiaBan.Value);
                    chiTiet.ThanhTien = chiTiet.SoLuongBan * chiTiet.DonGiaBan;
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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                int maSanPham = Convert.ToInt32(dataGridView.CurrentRow.Cells["SanPhamID"].Value);
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);
                if (chiTiet != null)
                {
                    hoaDonChiTiet.Remove(chiTiet);
                }
                BatTatChucNang();
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboNhanVien.Text))
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboKhachHang.Text))
                MessageBox.Show("Vui lòng chọn khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (id != 0)
                {
                    HoaDon hd = context.HoaDon.Find(id);
                    if (hd != null)
                    {
                        hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue);
                        hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue);
                        hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                        context.HoaDon.Update(hd);

                        var old = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).ToList();
                        context.HoaDon_ChiTiet.RemoveRange(old);

                        foreach (var item in hoaDonChiTiet)
                        {
                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet
                            {
                                HoaDonID = id,
                                SanPhamID = item.SanPhamID,
                                SoLuongBan = item.SoLuongBan,
                                DonGiaBan = item.DonGiaBan
                            };
                            context.HoaDon_ChiTiet.Add(ct);
                        }
                        context.SaveChanges();
                    }
                }
                else
                {
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
                        HoaDon_ChiTiet ct = new HoaDon_ChiTiet
                        {
                            HoaDonID = hd.ID,
                            SanPhamID = item.SanPhamID,
                            SoLuongBan = item.SoLuongBan,
                            DonGiaBan = item.DonGiaBan
                        };
                        context.HoaDon_ChiTiet.Add(ct);
                    }
                    context.SaveChanges();
                }
                MessageBox.Show("Đã lưu thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int maSanPham = Convert.ToInt32(cboSanPham.SelectedValue);
            var sanPham = context.SanPham.Find(maSanPham);
            if (sanPham != null)
                numDonGiaBan.Value = sanPham.DonGia;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
