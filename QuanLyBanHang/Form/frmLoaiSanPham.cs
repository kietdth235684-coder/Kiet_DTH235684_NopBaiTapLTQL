using QuanLyBanHang.Data;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;

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

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nh?p d? li?u t? t?p tin Excel";
            openFileDialog.Filter = "T?p tin Excel|*.xls;*.xlsx";
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
                            // ??c dòng tiêu ?? (dòng ??u tiên)
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString());
                                firstRow = false;
                            }
                            else // ??c các dòng n?i dung (các dòng ti?p theo)
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
                                LoaiSanPham lsp = new LoaiSanPham();
                                lsp.TenLoai = r["TenLoai"].ToString();
                                context.LoaiSanPham.Add(lsp);
                            }
                            context.SaveChanges();

                            MessageBox.Show("?ã nh?p thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmLoaiSanPham_Load(sender, e);
                        }
                        if (firstRow)
                            MessageBox.Show("T?p tin Excel r?ng.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xu?t d? li?u ra t?p tin Excel";
            saveFileDialog.Filter = "T?p tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "LoaiSanPham_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    table.Columns.AddRange(new DataColumn[2] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("TenLoai", typeof(string))
            });

                    var loaiSanPham = context.LoaiSanPham.ToList();
                    if (loaiSanPham != null)
                    {
                        foreach (var p in loaiSanPham)
                            table.Rows.Add(p.ID, p.TenLoai);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "LoaiSanPham");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("?ã xu?t d? li?u ra t?p tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

    }
}
