// C#
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHang.Data;
using ClosedXML.Excel;

namespace QuanLyBanHang
{
    public partial class frmSanPham : Form
    {
        // Global variables
        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        int id;
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "Images");

        public frmSanPham()
        {
            InitializeComponent();
            this.Load += frmSanPham_Load;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnLuu.Click += btnLuu_Click;
            btnXoa.Click += btnXoa_Click;
            btnHuyBo.Click += btnHuyBo_Click;
            btnThoat.Click += btnThoat_Click;
            btnDoiAnh.Click += btnDoiAnh_Click;
        }

        // Enable/disable controls
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

            btnThem.Enabled = !giaTri;
            btnDoiAnh.Enabled = !giaTri;
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

            var sp = context.SanPham.Select(r => new
            {
                ID = r.ID,
                LoaiSanPhamID = r.LoaiSanPhamID,
                TenLoai = r.LoaiSanPham.TenLoai,
                HangSanXuatID = r.HangSanXuatID,
                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                TenSanPham = r.TenSanPham,
                SoLuong = r.SoLuong,
                DonGia = r.DonGia,
                HinhAnh = r.HinhAnh,
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
                    ev.Value = Path.Combine(imagesFolder, ev.Value.ToString());
            };
            picHinhAnh.DataBindings.Add(hinhAnh);

            dataGridView.DataSource = bindingSource;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value != null)
            {
                string imgPath = Path.Combine(imagesFolder, e.Value.ToString());
                if (File.Exists(imgPath))
                {
                    Image image = Image.FromFile(imgPath);
                    image = new Bitmap(image, 24, 24);
                    e.Value = image;
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
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
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboLoaiSanPham.Text))
                MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboHangSanXuat.Text))
                MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuong.Value <= 0)
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGia.Value <= 0)
                MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    SanPham sp = new SanPham
                    {
                        LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue),
                        HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue),
                        TenSanPham = txtTenSanPham.Text,
                        SoLuong = Convert.ToInt32(numSoLuong.Value),
                        DonGia = Convert.ToInt32(numDonGia.Value),
                        MoTa = txtMoTa.Text,
                        HinhAnh = picHinhAnh.ImageLocation != null ? Path.GetFileName(picHinhAnh.ImageLocation) : null
                    };
                    context.SanPham.Add(sp);
                    context.SaveChanges();
                }
                else
                {
                    SanPham sp = context.SanPham.Find(id);
                    if (sp != null)
                    {
                        sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);
                        sp.HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);
                        sp.TenSanPham = txtTenSanPham.Text;
                        sp.SoLuong = Convert.ToInt32(numSoLuong.Value);
                        sp.DonGia = Convert.ToInt32(numDonGia.Value);
                        sp.MoTa = txtMoTa.Text;
                        sp.HinhAnh = picHinhAnh.ImageLocation != null ? Path.GetFileName(picHinhAnh.ImageLocation) : sp.HinhAnh;
                        context.SaveChanges();
                    }
                }
                frmSanPham_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa sản phẩm " + txtTenSanPham.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                SanPham sp = context.SanPham.Find(id);
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);
                string fileSavePath = Path.Combine(imagesFolder, fileName + ext);
                File.Copy(openFileDialog.FileName, fileSavePath, true);

                picHinhAnh.ImageLocation = fileSavePath;

                if (dataGridView.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                    SanPham sp = context.SanPham.Find(id);
                    if (sp != null)
                    {
                        sp.HinhAnh = fileName + ext;
                        context.SanPham.Update(sp);
                        context.SaveChanges();
                        frmSanPham_Load(sender, e);
                    }
                }
            }
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
                                SanPham sp = new SanPham();
                                sp.LoaiSanPhamID = int.Parse(r["LoaiSanPhamID"].ToString());
                                sp.HangSanXuatID = int.Parse(r["HangSanXuatID"].ToString());
                                sp.TenSanPham = r["TenSanPham"].ToString();
                                sp.SoLuong = int.Parse(r["SoLuong"].ToString());
                                sp.DonGia = int.Parse(r["DonGia"].ToString());
                                sp.HinhAnh = r.Table.Columns.Contains("HinhAnh") ? r["HinhAnh"].ToString() : null;
                                sp.MoTa = r.Table.Columns.Contains("MoTa") ? r["MoTa"].ToString() : null;
                                context.SanPham.Add(sp);
                            }
                            context.SaveChanges();

                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmSanPham_Load(sender, e);
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
            saveFileDialog.FileName = "SanPham_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("LoaiSanPhamID", typeof(int)),
                new DataColumn("HangSanXuatID", typeof(int)),
                new DataColumn("TenSanPham", typeof(string)),
                new DataColumn("SoLuong", typeof(int)),
                new DataColumn("DonGia", typeof(int)),
                new DataColumn("HinhAnh", typeof(string)),
                new DataColumn("MoTa", typeof(string))
            });

                    var sanPhamList = context.SanPham.ToList();
                    foreach (var sp in sanPhamList)
                    {
                        table.Rows.Add(sp.ID, sp.LoaiSanPhamID, sp.HangSanXuatID, sp.TenSanPham, sp.SoLuong, sp.DonGia, sp.HinhAnh, sp.MoTa);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "SanPham");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}