using QuanLyBanHang.Data;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyBanHang.Forms
{
    public partial class frmLoaiSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        int id;

        public frmLoaiSanPham()
        {
            InitializeComponent();
            HelpSupport.DangKy(this);
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
            List<LoaiSanPham> lsp = context.LoaiSanPham.ToList();
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
            txtTenLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            txtTenLoai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLoai.Focus();
                return;
            }

            if (xuLyThem)
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.TenLoai = txtTenLoai.Text.Trim();
                context.LoaiSanPham.Add(lsp);
            }
            else
            {
                LoaiSanPham? lsp = context.LoaiSanPham.Find(id);
                if (lsp != null)
                {
                    lsp.TenLoai = txtTenLoai.Text.Trim();
                    context.LoaiSanPham.Update(lsp);
                }
            }
            context.SaveChanges();
            frmLoaiSanPham_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (MessageBox.Show("Xác nhận xóa loại sản phẩm?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                LoaiSanPham? lsp = context.LoaiSanPham.Find(id);
                if (lsp != null)
                {
                    context.LoaiSanPham.Remove(lsp);
                    context.SaveChanges();
                }
                frmLoaiSanPham_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Nhập dữ liệu từ tập tin Excel";
            ofd.Filter = "Tập tin Excel|*.xls;*.xlsx";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            try
            {
                DataTable table = new DataTable();
                using (XLWorkbook workbook = new XLWorkbook(ofd.FileName))
                {
                    IXLWorksheet ws = workbook.Worksheet(1);
                    bool firstRow = true;
                    string readRange = "1:1";
                    foreach (IXLRow row in ws.RowsUsed())
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
                            int ci = 0;
                            foreach (IXLCell cell in row.Cells(readRange))
                                table.Rows[table.Rows.Count - 1][ci++] = cell.Value.ToString();
                        }
                    }
                    if (firstRow) { MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                }
                foreach (DataRow r in table.Rows)
                    context.LoaiSanPham.Add(new LoaiSanPham { TenLoai = r["TenLoai"].ToString()! });
                context.SaveChanges();
                MessageBox.Show($"Đã nhập thành công {table.Rows.Count} dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmLoaiSanPham_Load(sender, e);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Xuất dữ liệu ra tập tin Excel";
            sfd.Filter = "Tập tin Excel|*.xlsx";
            sfd.FileName = "LoaiSanPham_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                DataTable table = new DataTable();
                table.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("TenLoai", typeof(string))
                });
                foreach (var p in context.LoaiSanPham.ToList())
                    table.Rows.Add(p.ID, p.TenLoai);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var sheet = wb.Worksheets.Add(table, "LoaiSanPham");
                    sheet.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                }
                MessageBox.Show("Đã xuất dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
