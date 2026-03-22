using QuanLyBanHang.Data;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyBanHang.Forms
{
    public partial class frmHangSanXuat : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        int id;

        public frmHangSanXuat()
        {
            InitializeComponent();
            HelpSupport.DangKy(this);
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenHangSanXuat.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmHangSanXuat_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            List<HangSanXuat> hsx = context.HangSanXuat.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = hsx;
            txtTenHangSanXuat.DataBindings.Clear();
            txtTenHangSanXuat.DataBindings.Add("Text", bindingSource, "TenHangSanXuat", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenHangSanXuat.Clear();
            txtTenHangSanXuat.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            txtTenHangSanXuat.Focus();
        }

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
                HangSanXuat hsx = new HangSanXuat();
                hsx.TenHangSanXuat = txtTenHangSanXuat.Text.Trim();
                context.HangSanXuat.Add(hsx);
            }
            else
            {
                HangSanXuat? hsx = context.HangSanXuat.Find(id);
                if (hsx != null)
                {
                    hsx.TenHangSanXuat = txtTenHangSanXuat.Text.Trim();
                    context.HangSanXuat.Update(hsx);
                }
            }
            context.SaveChanges();
            frmHangSanXuat_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (MessageBox.Show("Xác nhận xóa hãng sản xuất?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                HangSanXuat? hsx = context.HangSanXuat.Find(id);
                if (hsx != null)
                {
                    context.HangSanXuat.Remove(hsx);
                    context.SaveChanges();
                }
                frmHangSanXuat_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmHangSanXuat_Load(sender, e);
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
                    bool firstRow = true; string readRange = "1:1";
                    foreach (IXLRow row in ws.RowsUsed())
                    {
                        if (firstRow) { readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber); foreach (IXLCell cell in row.Cells(readRange)) table.Columns.Add(cell.Value.ToString()); firstRow = false; }
                        else { table.Rows.Add(); int ci = 0; foreach (IXLCell cell in row.Cells(readRange)) table.Rows[table.Rows.Count - 1][ci++] = cell.Value.ToString(); }
                    }
                    if (firstRow) { MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                }
                foreach (DataRow r in table.Rows)
                    context.HangSanXuat.Add(new HangSanXuat { TenHangSanXuat = r["TenHangSanXuat"].ToString()! });
                context.SaveChanges();
                MessageBox.Show($"Đã nhập thành công {table.Rows.Count} dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmHangSanXuat_Load(sender, e);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Xuất dữ liệu ra tập tin Excel";
            sfd.Filter = "Tập tin Excel|*.xlsx";
            sfd.FileName = "HangSanXuat_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                DataTable table = new DataTable();
                table.Columns.AddRange(new DataColumn[] { new DataColumn("ID", typeof(int)), new DataColumn("TenHangSanXuat", typeof(string)) });
                foreach (var p in context.HangSanXuat.ToList()) table.Rows.Add(p.ID, p.TenHangSanXuat);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var sheet = wb.Worksheets.Add(table, "HangSanXuat");
                    sheet.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                }
                MessageBox.Show("Đã xuất dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
