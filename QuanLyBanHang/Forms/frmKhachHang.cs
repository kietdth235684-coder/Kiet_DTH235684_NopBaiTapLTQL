using QuanLyBanHang.Data;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyBanHang.Forms
{
    public partial class frmKhachHang : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        int id;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            List<KhachHang> kh = context.KhachHang.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = kh;

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtHoVaTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            txtHoVaTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoVaTen.Focus();
                return;
            }

            if (xuLyThem)
            {
                KhachHang kh = new KhachHang();
                kh.HoVaTen = txtHoVaTen.Text.Trim();
                kh.DienThoai = txtDienThoai.Text.Trim();
                kh.DiaChi = txtDiaChi.Text.Trim();
                context.KhachHang.Add(kh);
            }
            else
            {
                KhachHang? kh = context.KhachHang.Find(id);
                if (kh != null)
                {
                    kh.HoVaTen = txtHoVaTen.Text.Trim();
                    kh.DienThoai = txtDienThoai.Text.Trim();
                    kh.DiaChi = txtDiaChi.Text.Trim();
                    context.KhachHang.Update(kh);
                }
            }
            context.SaveChanges();
            frmKhachHang_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (MessageBox.Show("Xác nhận xóa khách hàng " + txtHoVaTen.Text + "?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                KhachHang? kh = context.KhachHang.Find(id);
                if (kh != null)
                {
                    context.KhachHang.Remove(kh);
                    context.SaveChanges();
                }
                frmKhachHang_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên khách hàng cần tìm:", "Tìm kiếm", "");
            if (string.IsNullOrWhiteSpace(keyword)) return;

            List<KhachHang> kh = context.KhachHang
                .Where(k => k.HoVaTen.Contains(keyword))
                .ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = kh;
            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
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
                using (XLWorkbook wb = new XLWorkbook(ofd.FileName))
                {
                    IXLWorksheet ws = wb.Worksheet(1);
                    bool firstRow = true; string readRange = "1:1";
                    foreach (IXLRow row in ws.RowsUsed())
                    {
                        if (firstRow) { readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber); foreach (IXLCell cell in row.Cells(readRange)) table.Columns.Add(cell.Value.ToString()); firstRow = false; }
                        else { table.Rows.Add(); int ci = 0; foreach (IXLCell cell in row.Cells(readRange)) table.Rows[table.Rows.Count - 1][ci++] = cell.Value.ToString(); }
                    }
                    if (firstRow) { MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                }
                foreach (DataRow r in table.Rows)
                    context.KhachHang.Add(new KhachHang { HoVaTen = r["HoVaTen"].ToString()!, DienThoai = r["DienThoai"].ToString(), DiaChi = r["DiaChi"].ToString() });
                context.SaveChanges();
                MessageBox.Show($"Đã nhập thành công {table.Rows.Count} dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmKhachHang_Load(sender, e);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Xuất dữ liệu ra tập tin Excel";
            sfd.Filter = "Tập tin Excel|*.xlsx";
            sfd.FileName = "KhachHang_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                DataTable table = new DataTable();
                table.Columns.AddRange(new DataColumn[] { new DataColumn("ID", typeof(int)), new DataColumn("HoVaTen", typeof(string)), new DataColumn("DienThoai", typeof(string)), new DataColumn("DiaChi", typeof(string)) });
                foreach (var p in context.KhachHang.ToList()) table.Rows.Add(p.ID, p.HoVaTen, p.DienThoai, p.DiaChi);
                using (XLWorkbook wb = new XLWorkbook()) { var sheet = wb.Worksheets.Add(table, "KhachHang"); sheet.Columns().AdjustToContents(); wb.SaveAs(sfd.FileName); }
                MessageBox.Show("Đã xuất dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
