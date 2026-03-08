using QuanLyBanHang.Data;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;

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
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString());
                                firstRow = false;
                            }
                            else
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow r in table.Rows)
                            {
                                HangSanXuat hsx = new HangSanXuat();
                                hsx.TenHang = r["TenHang"].ToString();
                                // Nếu có thêm thuộc tính khác, bổ sung ở đây
                                context.HangSanXuat.Add(hsx);
                            }
                            context.SaveChanges();

                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmHangSanXuat_Load(sender, e);
                        }
                        if (firstRow)
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            saveFileDialog.FileName = "HangSanXuat_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    table.Columns.AddRange(new DataColumn[2] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("TenHang", typeof(string))
                // Nếu có thêm thuộc tính khác, bổ sung ở đây
            });

                    var hangSanXuat = context.HangSanXuat.ToList();
                    if (hangSanXuat != null)
                    {
                        foreach (var p in hangSanXuat)
                            table.Rows.Add(p.ID, p.TenHang);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "HangSanXuat");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
