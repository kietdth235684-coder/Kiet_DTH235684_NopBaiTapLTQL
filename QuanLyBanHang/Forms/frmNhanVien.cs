using QuanLyBanHang.Data;
using BC = BCrypt.Net.BCrypt;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyBanHang.Forms
{
    public partial class frmNhanVien : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        int id;

        public frmNhanVien()
        {
            InitializeComponent();
            HelpSupport.DangKy(this);
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtTenDangNhap.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;

            List<NhanVien> nv = context.NhanVien.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = nv;

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", false, DataSourceUpdateMode.Never);

            cboQuyenHan.DataBindings.Clear();
            cboQuyenHan.DataBindings.Add("SelectedIndex", bindingSource, "QuyenHan", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.SelectedIndex = -1;
            txtHoVaTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            txtMatKhau.Clear();
            txtHoVaTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
            { MessageBox.Show("Vui lòng nhập họ và tên nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            { MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cboQuyenHan.SelectedIndex == -1)
            { MessageBox.Show("Vui lòng chọn quyền hạn cho nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (xuLyThem)
            {
                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                { MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                NhanVien nv = new NhanVien();
                nv.HoVaTen = txtHoVaTen.Text.Trim();
                nv.DienThoai = txtDienThoai.Text.Trim();
                nv.DiaChi = txtDiaChi.Text.Trim();
                nv.TenDangNhap = txtTenDangNhap.Text.Trim();
                nv.MatKhau = BC.HashPassword(txtMatKhau.Text);
                nv.QuyenHan = cboQuyenHan.SelectedIndex == 0;
                context.NhanVien.Add(nv);
                context.SaveChanges();
            }
            else
            {
                NhanVien? nv = context.NhanVien.Find(id);
                if (nv != null)
                {
                    nv.HoVaTen = txtHoVaTen.Text.Trim();
                    nv.DienThoai = txtDienThoai.Text.Trim();
                    nv.DiaChi = txtDiaChi.Text.Trim();
                    nv.TenDangNhap = txtTenDangNhap.Text.Trim();
                    nv.QuyenHan = cboQuyenHan.SelectedIndex == 0;
                    context.NhanVien.Update(nv);

                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        context.Entry(nv).Property(x => x.MatKhau).IsModified = false;
                    else
                        nv.MatKhau = BC.HashPassword(txtMatKhau.Text);

                    context.SaveChanges();
                }
            }
            frmNhanVien_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (MessageBox.Show("Xác nhận xóa nhân viên " + txtHoVaTen.Text + "?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                NhanVien? nv = context.NhanVien.Find(id);
                if (nv != null)
                {
                    context.NhanVien.Remove(nv);
                    context.SaveChanges();
                }
                frmNhanVien_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên nhân viên cần tìm:", "Tìm kiếm", "");
            if (string.IsNullOrWhiteSpace(keyword)) return;

            List<NhanVien> nv = context.NhanVien.Where(n => n.HoVaTen.Contains(keyword)).ToList();
            BindingSource bs = new BindingSource { DataSource = nv };
            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bs, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bs, "DienThoai", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bs, "DiaChi", false, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", bs, "TenDangNhap", false, DataSourceUpdateMode.Never);
            cboQuyenHan.DataBindings.Clear();
            cboQuyenHan.DataBindings.Add("SelectedIndex", bs, "QuyenHan", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bs;
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
                    context.NhanVien.Add(new NhanVien { HoVaTen = r["HoVaTen"].ToString()!, DienThoai = r["DienThoai"].ToString(), DiaChi = r["DiaChi"].ToString(), TenDangNhap = r["TenDangNhap"].ToString()!, MatKhau = BC.HashPassword(r["MatKhau"].ToString()!), QuyenHan = r["QuyenHan"].ToString() == "True" });
                context.SaveChanges();
                MessageBox.Show($"Đã nhập thành công {table.Rows.Count} dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmNhanVien_Load(sender, e);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Xuất dữ liệu ra tập tin Excel";
            sfd.Filter = "Tập tin Excel|*.xlsx";
            sfd.FileName = "NhanVien_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                DataTable table = new DataTable();
                table.Columns.AddRange(new DataColumn[] { new DataColumn("ID", typeof(int)), new DataColumn("HoVaTen", typeof(string)), new DataColumn("DienThoai", typeof(string)), new DataColumn("DiaChi", typeof(string)), new DataColumn("TenDangNhap", typeof(string)), new DataColumn("QuyenHan", typeof(bool)) });
                foreach (var p in context.NhanVien.ToList()) table.Rows.Add(p.ID, p.HoVaTen, p.DienThoai, p.DiaChi, p.TenDangNhap, p.QuyenHan);
                using (XLWorkbook wb = new XLWorkbook()) { var sheet = wb.Worksheets.Add(table, "NhanVien"); sheet.Columns().AdjustToContents(); wb.SaveAs(sfd.FileName); }
                MessageBox.Show("Đã xuất dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
