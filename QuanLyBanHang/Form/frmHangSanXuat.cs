using QuanLyBanHang.Data;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmHangSanXuat : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        int id;

        public frmHangSanXuat()
        {
            InitializeComponent();
            // Wire up DataGridView selection event
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
        }

        // Bật/tắt các chức năng theo trạng thái
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenHangSanXuat.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        // Tải dữ liệu lên DataGridView và thiết lập trạng thái controls
        private void frmHangSanXuat_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            var lsp = context.LoaiSanPham.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = lsp;

            dataGridView.DataSource = bindingSource;

            // Hiển thị dữ liệu dòng đầu tiên lên controls nếu có
            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Rows[0].Selected = true;
                HienThiDuLieuLenControls();
            }
            else
            {
                txtTenHangSanXuat.Clear();
            }
        }

        // Khi chọn 1 dòng trên DataGridView thì hiển thị dữ liệu lên controls
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!btnThem.Enabled) return; // Đang ở chế độ Thêm/Sửa thì không cập nhật
            HienThiDuLieuLenControls();
        }

        private void HienThiDuLieuLenControls()
        {
            if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.DataBoundItem is LoaiSanPham lsp)
            {
                txtTenHangSanXuat.Text = lsp.TenLoai;
                id = lsp.ID;
            }
        }

        // Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenHangSanXuat.Clear();
            txtTenHangSanXuat.Focus();
        }

        // Nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            txtTenHangSanXuat.Enabled = true;
            txtTenHangSanXuat.Focus();
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
        }

        // Nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHangSanXuat.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hãng sản xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHangSanXuat.Focus();
                return;
            }

            if (xuLyThem)
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.TenLoai = txtTenHangSanXuat.Text;
                context.LoaiSanPham.Add(lsp);
            }
            else
            {
                LoaiSanPham lsp = context.LoaiSanPham.Find(id);
                if (lsp != null)
                {
                    lsp.TenLoai = txtTenHangSanXuat.Text;
                    context.LoaiSanPham.Update(lsp);
                }
            }
            context.SaveChanges();
            frmHangSanXuat_Load(sender, e);
        }

        // Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (MessageBox.Show("Xác nhận xóa hãng sản xuất?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                LoaiSanPham lsp = context.LoaiSanPham.Find(id);
                if (lsp != null)
                {
                    context.LoaiSanPham.Remove(lsp);
                    context.SaveChanges();
                }
                frmHangSanXuat_Load(sender, e);
            }
        }

        // Nút Hủy bỏ
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmHangSanXuat_Load(sender, e);
        }

        // Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
