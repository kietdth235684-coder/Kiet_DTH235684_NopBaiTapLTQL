using QuanLyBanHang.Data;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmLoaiSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext(); // Kh?i t?o bi?n ng? c?nh CSDL 
        bool xuLyThem = false; // Ki?m tra có nh?n vào nút Thêm hay không? 
        int id; // L?y mã lo?i s?n ph?m (dùng cho S?a và Xóa)

        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenLoai.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            List<LoaiSanPham> lsp = new List<LoaiSanPham>();
            lsp = context.LoaiSanPham.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = lsp;

            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", bindingSource, "TenLoai", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenLoai.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
                MessageBox.Show("Vui lòng nh?p tên lo?i s?n ph?m?", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    LoaiSanPham lsp = new LoaiSanPham();
                    lsp.TenLoai = txtTenLoai.Text;
                    context.LoaiSanPham.Add(lsp);

                    context.SaveChanges();
                }
                else
                {
                    LoaiSanPham lsp = context.LoaiSanPham.Find(id);
                    if (lsp != null)
                    {
                        lsp.TenLoai = txtTenLoai.Text;
                        context.LoaiSanPham.Update(lsp);

                        context.SaveChanges();
                    }
                }

                frmLoaiSanPham_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nh?n xóa lo?i s?n ph?m?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                LoaiSanPham lsp = context.LoaiSanPham.Find(id);
                if (lsp != null)
                {
                    context.LoaiSanPham.Remove(lsp);
                }
                context.SaveChanges();

                frmLoaiSanPham_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham_Load(sender, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
