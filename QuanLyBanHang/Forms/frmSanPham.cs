using QuanLyBanHang.Data;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyBanHang.Forms
{
    public partial class frmSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        int id;
        string imagesFolder = Path.Combine(Application.StartupPath, "Images");

        public frmSanPham()
        {
            InitializeComponent();
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            cboHangSanXuat.Enabled = giaTri;
            cboLoaiSanPham.Enabled = giaTri;
            txtTenSanPham.Enabled = giaTri;
            numSoLuong.Enabled = giaTri;
            numDonGia.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;
            btnDoiAnh.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        public void LayLoaiSanPhamVaoComboBox()
        {
            cboLoaiSanPham.DataSource = context.LoaiSanPham.ToList();
            cboLoaiSanPham.ValueMember = "ID";
            cboLoaiSanPham.DisplayMember = "TenLoai";
        }

        public void LayHangSanXuatVaoComboBox()
        {
            cboHangSanXuat.DataSource = context.HangSanXuat.ToList();
            cboHangSanXuat.ValueMember = "ID";
            cboHangSanXuat.DisplayMember = "TenHangSanXuat";
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LayLoaiSanPhamVaoComboBox();
            LayHangSanXuatVaoComboBox();
            dataGridView.AutoGenerateColumns = false;

            List<DanhSachSanPham> sp = context.SanPham
                .Include(r => r.LoaiSanPham)
                .Include(r => r.HangSanXuat)
                .Select(r => new DanhSachSanPham
                {
                    ID = r.ID,
                    LoaiSanPhamID = r.LoaiSanPhamID,
                    TenLoai = r.LoaiSanPham.TenLoai,
                    HangSanXuatID = r.HangSanXuatID,
                    TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                    TenSanPham = r.TenSanPham,
                    SoLuong = r.SoLuong,
                    DonGia = r.DonGia,
                    HinhAnh = r.HinhAnh ?? "no-image.png",
                    MoTa = r.MoTa
                }).ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sp;

            cboLoaiSanPham.DataBindings.Clear();
            cboLoaiSanPham.DataBindings.Add("SelectedValue", bindingSource, "LoaiSanPhamID", false, DataSourceUpdateMode.Never);
            cboHangSanXuat.DataBindings.Clear();
            cboHangSanXuat.DataBindings.Add("SelectedValue", bindingSource, "HangSanXuatID", false, DataSourceUpdateMode.Never);

            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Add("Text", bindingSource, "TenSanPham", false, DataSourceUpdateMode.Never);
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bindingSource, "MoTa", false, DataSourceUpdateMode.Never);

            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bindingSource, "SoLuong", false, DataSourceUpdateMode.Never);
            numDonGia.DataBindings.Clear();
            numDonGia.DataBindings.Add("Value", bindingSource, "DonGia", false, DataSourceUpdateMode.Never);

            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bindingSource, "HinhAnh");
            hinhAnh.Format += (s, ev) =>
            {
                if (ev.Value != null)
                    ev.Value = Path.Combine(imagesFolder, ev.Value.ToString()!);
            };
            picHinhAnh.DataBindings.Add(hinhAnh);

            dataGridView.DataSource = bindingSource;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                try
                {
                    string imgPath = Path.Combine(imagesFolder, e.Value.ToString()!);
                    if (File.Exists(imgPath))
                    {
                        Image image = Image.FromFile(imgPath);
                        e.Value = new Bitmap(image, 32, 32);
                    }
                }
                catch { }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cboLoaiSanPham.SelectedIndex = -1;
            cboHangSanXuat.SelectedIndex = -1;
            txtTenSanPham.Clear();
            txtMoTa.Clear();
            numSoLuong.Value = 0;
            numDonGia.Value = 0;
            picHinhAnh.Image = null;
            txtTenSanPham.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            txtTenSanPham.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboLoaiSanPham.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cboLoaiSanPham.Text))
            { MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cboHangSanXuat.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cboHangSanXuat.Text))
            { MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            { MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (numSoLuong.Value <= 0)
            { MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (numDonGia.Value <= 0)
            { MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (xuLyThem)
            {
                SanPham sp = new SanPham();
                sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);
                sp.HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);
                sp.TenSanPham = txtTenSanPham.Text.Trim();
                sp.SoLuong = (int)numSoLuong.Value;
                sp.DonGia = (int)numDonGia.Value;
                sp.MoTa = txtMoTa.Text.Trim();
                sp.HinhAnh = "no-image.png";
                context.SanPham.Add(sp);
                context.SaveChanges();
            }
            else
            {
                SanPham? sp = context.SanPham.Find(id);
                if (sp != null)
                {
                    sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);
                    sp.HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);
                    sp.TenSanPham = txtTenSanPham.Text.Trim();
                    sp.SoLuong = (int)numSoLuong.Value;
                    sp.DonGia = (int)numDonGia.Value;
                    sp.MoTa = txtMoTa.Text.Trim();
                    context.SanPham.Update(sp);
                    context.SaveChanges();
                }
            }
            frmSanPham_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (MessageBox.Show("Xác nhận xóa sản phẩm " + txtTenSanPham.Text + "?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                SanPham? sp = context.SanPham.Find(id);
                if (sp != null)
                {
                    context.SanPham.Remove(sp);
                    context.SaveChanges();
                }
                frmSanPham_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmSanPham_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần đổi ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Cập nhật hình ảnh sản phẩm";
            ofd.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(ofd.FileName);
                string newFileName = Guid.NewGuid().ToString() + ext;
                string destPath = Path.Combine(imagesFolder, newFileName);
                File.Copy(ofd.FileName, destPath, true);

                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                SanPham? sp = context.SanPham.Find(id);
                if (sp != null)
                {
                    sp.HinhAnh = newFileName;
                    context.SanPham.Update(sp);
                    context.SaveChanges();
                }
                frmSanPham_Load(sender, e);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên sản phẩm cần tìm:", "Tìm kiếm", "");
            if (string.IsNullOrWhiteSpace(keyword)) return;

            var sp = context.SanPham
                .Include(r => r.LoaiSanPham)
                .Include(r => r.HangSanXuat)
                .Where(r => r.TenSanPham.Contains(keyword))
                .Select(r => new DanhSachSanPham
                {
                    ID = r.ID,
                    LoaiSanPhamID = r.LoaiSanPhamID,
                    TenLoai = r.LoaiSanPham.TenLoai,
                    HangSanXuatID = r.HangSanXuatID,
                    TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                    TenSanPham = r.TenSanPham,
                    SoLuong = r.SoLuong,
                    DonGia = r.DonGia,
                    HinhAnh = r.HinhAnh ?? "no-image.png",
                    MoTa = r.MoTa
                }).ToList();

            BindingSource bs = new BindingSource { DataSource = sp };
            cboLoaiSanPham.DataBindings.Clear();
            cboLoaiSanPham.DataBindings.Add("SelectedValue", bs, "LoaiSanPhamID", false, DataSourceUpdateMode.Never);
            cboHangSanXuat.DataBindings.Clear();
            cboHangSanXuat.DataBindings.Add("SelectedValue", bs, "HangSanXuatID", false, DataSourceUpdateMode.Never);
            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Add("Text", bs, "TenSanPham", false, DataSourceUpdateMode.Never);
            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bs, "SoLuong", false, DataSourceUpdateMode.Never);
            numDonGia.DataBindings.Clear();
            numDonGia.DataBindings.Add("Value", bs, "DonGia", false, DataSourceUpdateMode.Never);
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
                        if (firstRow)
                        {
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange)) table.Columns.Add(cell.Value.ToString());
                            firstRow = false;
                        }
                        else
                        {
                            table.Rows.Add();
                            int ci = 0;
                            foreach (IXLCell cell in row.Cells(readRange)) table.Rows[table.Rows.Count - 1][ci++] = cell.Value.ToString();
                        }
                    }
                    if (firstRow) { MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                }
                foreach (DataRow r in table.Rows)
                {
                    // Tìm LoaiSanPhamID và HangSanXuatID theo tên
                    var loai = context.LoaiSanPham.FirstOrDefault(x => x.TenLoai == r["TenLoai"].ToString());
                    var hang = context.HangSanXuat.FirstOrDefault(x => x.TenHangSanXuat == r["TenHangSanXuat"].ToString());
                    if (loai == null || hang == null)
                    {
                        MessageBox.Show($"Không tìm thấy loại '{r["TenLoai"]}' hoặc hãng '{r["TenHangSanXuat"]}'. Bỏ qua dòng này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                    context.SanPham.Add(new SanPham
                    {
                        TenSanPham = r["TenSanPham"].ToString()!,
                        LoaiSanPhamID = loai.ID,
                        HangSanXuatID = hang.ID,
                        DonGia = Convert.ToInt32(r["DonGia"]),
                        SoLuong = Convert.ToInt32(r["SoLuong"]),
                        MoTa = r["MoTa"].ToString(),
                        HinhAnh = "no-image.png"
                    });
                }
                context.SaveChanges();
                MessageBox.Show($"Đã nhập thành công {table.Rows.Count} dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmSanPham_Load(sender, e);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Xuất dữ liệu ra tập tin Excel";
            sfd.Filter = "Tập tin Excel|*.xlsx";
            sfd.FileName = "SanPham_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                DataTable table = new DataTable();
                table.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("TenLoai", typeof(string)),
                    new DataColumn("TenHangSanXuat", typeof(string)),
                    new DataColumn("TenSanPham", typeof(string)),
                    new DataColumn("DonGia", typeof(int)),
                    new DataColumn("SoLuong", typeof(int)),
                    new DataColumn("MoTa", typeof(string))
                });
                var dsSanPham = context.SanPham
                    .Include(r => r.LoaiSanPham)
                    .Include(r => r.HangSanXuat)
                    .ToList();
                foreach (var p in dsSanPham)
                    table.Rows.Add(p.ID, p.LoaiSanPham.TenLoai, p.HangSanXuat.TenHangSanXuat,
                        p.TenSanPham, p.DonGia, p.SoLuong, p.MoTa);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var sheet = wb.Worksheets.Add(table, "SanPham");
                    sheet.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                }
                MessageBox.Show("Đã xuất dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
