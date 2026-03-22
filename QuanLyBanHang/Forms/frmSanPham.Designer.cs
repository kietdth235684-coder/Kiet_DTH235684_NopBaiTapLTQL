namespace QuanLyBanHang.Forms
{
    partial class frmSanPham
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpThongTin = new GroupBox(); grpDanhSach = new GroupBox();
            lblLoaiSanPham = new Label(); lblHangSanXuat = new Label();
            lblTenSanPham = new Label(); lblSoLuong = new Label();
            lblDonGia = new Label(); lblMoTa = new Label();
            cboLoaiSanPham = new ComboBox(); cboHangSanXuat = new ComboBox();
            txtTenSanPham = new TextBox(); txtMoTa = new TextBox();
            numSoLuong = new NumericUpDown(); numDonGia = new NumericUpDown();
            picHinhAnh = new PictureBox();
            btnThem = new Button(); btnSua = new Button(); btnXoa = new Button();
            btnLuu = new Button(); btnHuyBo = new Button(); btnThoat = new Button();
            btnTimKiem = new Button(); btnNhap = new Button(); btnXuat = new Button();
            btnDoiAnh = new Button();
            dataGridView = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colPhanLoai = new DataGridViewTextBoxColumn();
            colHangSanXuat = new DataGridViewTextBoxColumn();
            colTenSanPham = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colHinhAnh = new DataGridViewImageColumn();

            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();

            // grpThongTin
            grpThongTin.Controls.AddRange(new Control[] {
                lblLoaiSanPham, cboLoaiSanPham, lblSoLuong, numSoLuong, picHinhAnh, btnDoiAnh,
                lblHangSanXuat, cboHangSanXuat, lblDonGia, numDonGia,
                lblTenSanPham, txtTenSanPham,
                lblMoTa, txtMoTa,
                btnThem, btnSua, btnXoa, btnLuu, btnHuyBo, btnThoat,
                btnTimKiem, btnNhap, btnXuat
            });
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Size = new Size(1100, 160);
            grpThongTin.Text = "Thông tin sản phẩm";

            // Row 1: LoaiSanPham, SoLuong, PictureBox
            lblLoaiSanPham.AutoSize = true; lblLoaiSanPham.Location = new Point(10, 26); lblLoaiSanPham.Text = "Phân loại (*):";
            cboLoaiSanPham.Location = new Point(95, 23); cboLoaiSanPham.Name = "cboLoaiSanPham"; cboLoaiSanPham.Size = new Size(180, 23); cboLoaiSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            lblSoLuong.AutoSize = true; lblSoLuong.Location = new Point(290, 26); lblSoLuong.Text = "Số lượng (*):";
            numSoLuong.Location = new Point(375, 23); numSoLuong.Name = "numSoLuong"; numSoLuong.Size = new Size(120, 23);
            numSoLuong.Minimum = 0; numSoLuong.Maximum = 1000; numSoLuong.ThousandsSeparator = true;

            // PictureBox + DoiAnh button
            picHinhAnh.Location = new Point(720, 22); picHinhAnh.Name = "picHinhAnh"; picHinhAnh.Size = new Size(120, 120);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom; picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            btnDoiAnh.Location = new Point(850, 22); btnDoiAnh.Size = new Size(80, 30); btnDoiAnh.Text = "Đổi ảnh..."; btnDoiAnh.Click += btnDoiAnh_Click;

            // Row 2: HangSanXuat, DonGia, buttons col 1
            lblHangSanXuat.AutoSize = true; lblHangSanXuat.Location = new Point(10, 56); lblHangSanXuat.Text = "Hãng sản xuất (*):";
            cboHangSanXuat.Location = new Point(125, 53); cboHangSanXuat.Name = "cboHangSanXuat"; cboHangSanXuat.Size = new Size(150, 23); cboHangSanXuat.DropDownStyle = ComboBoxStyle.DropDownList;
            lblDonGia.AutoSize = true; lblDonGia.Location = new Point(290, 56); lblDonGia.Text = "Đơn giá (*):";
            numDonGia.Location = new Point(375, 53); numDonGia.Name = "numDonGia"; numDonGia.Size = new Size(120, 23);
            numDonGia.Minimum = 0; numDonGia.Maximum = 1000000000; numDonGia.ThousandsSeparator = true;

            btnThem.Location = new Point(530, 23); btnThem.Size = new Size(75, 25); btnThem.Text = "Thêm"; btnThem.Click += btnThem_Click;
            btnLuu.Location = new Point(615, 23); btnLuu.Size = new Size(75, 25); btnLuu.Text = "Lưu"; btnLuu.Click += btnLuu_Click;
            btnTimKiem.Location = new Point(530, 53); btnTimKiem.Size = new Size(75, 25); btnTimKiem.Text = "Tìm kiếm"; btnTimKiem.Click += btnTimKiem_Click;
            btnNhap.Location = new Point(615, 53); btnNhap.Size = new Size(75, 25); btnNhap.Text = "Nhập..."; btnNhap.Click += btnNhap_Click;

            // Row 3: TenSanPham
            lblTenSanPham.AutoSize = true; lblTenSanPham.Location = new Point(10, 88); lblTenSanPham.Text = "Tên sản phẩm (*):";
            txtTenSanPham.Location = new Point(125, 85); txtTenSanPham.Name = "txtTenSanPham"; txtTenSanPham.Size = new Size(370, 23);

            btnSua.Location = new Point(530, 83); btnSua.Size = new Size(75, 25); btnSua.Text = "Sửa"; btnSua.Click += btnSua_Click;
            btnHuyBo.Location = new Point(615, 83); btnHuyBo.Size = new Size(75, 25); btnHuyBo.Text = "Hủy bỏ"; btnHuyBo.Click += btnHuyBo_Click;
            btnXuat.Location = new Point(530, 113); btnXuat.Size = new Size(75, 25); btnXuat.Text = "Xuất..."; btnXuat.Click += btnXuat_Click;

            // Row 4: MoTa
            lblMoTa.AutoSize = true; lblMoTa.Location = new Point(10, 120); lblMoTa.Text = "Mô tả sản phẩm:";
            txtMoTa.Location = new Point(125, 117); txtMoTa.Name = "txtMoTa"; txtMoTa.Size = new Size(370, 23);

            btnXoa.Location = new Point(615, 113); btnXoa.Size = new Size(75, 25); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnThoat.Location = new Point(530, 140); btnThoat.Size = new Size(160, 25); btnThoat.Text = "Thoát"; btnThoat.Click += btnThoat_Click;

            // grpDanhSach
            grpDanhSach.Controls.Add(dataGridView);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Text = "Danh sách sản phẩm";

            // dataGridView
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Name = "dataGridView";
            dataGridView.AutoGenerateColumns = false;
            dataGridView.RowTemplate.Height = 36;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                colID, colPhanLoai, colHangSanXuat, colTenSanPham, colSoLuong, colDonGia, colHinhAnh
            });

            colID.DataPropertyName = "ID"; colID.HeaderText = "ID"; colID.Name = "ID"; colID.Width = 50;
            colPhanLoai.DataPropertyName = "TenLoai"; colPhanLoai.HeaderText = "Phân loại"; colPhanLoai.Name = "TenLoai";
            colHangSanXuat.DataPropertyName = "TenHangSanXuat"; colHangSanXuat.HeaderText = "Hãng sản xuất"; colHangSanXuat.Name = "TenHangSanXuat";
            colTenSanPham.DataPropertyName = "TenSanPham"; colTenSanPham.HeaderText = "Tên sản phẩm"; colTenSanPham.Name = "TenSanPham";
            colSoLuong.DataPropertyName = "SoLuong"; colSoLuong.HeaderText = "Số lượng"; colSoLuong.Name = "SoLuong"; colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDonGia.DataPropertyName = "DonGia"; colDonGia.HeaderText = "Đơn giá"; colDonGia.Name = "DonGia"; colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; colDonGia.DefaultCellStyle.Format = "N0";
            colHinhAnh.DataPropertyName = "HinhAnh"; colHinhAnh.HeaderText = "Hình ảnh"; colHinhAnh.Name = "HinhAnh"; colHinhAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;

            // Form
            ClientSize = new Size(1100, 650);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sản phẩm";
            Load += frmSanPham_Load;

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpThongTin, grpDanhSach;
        private Label lblLoaiSanPham, lblHangSanXuat, lblTenSanPham, lblSoLuong, lblDonGia, lblMoTa;
        private ComboBox cboLoaiSanPham, cboHangSanXuat;
        private TextBox txtTenSanPham, txtMoTa;
        private NumericUpDown numSoLuong, numDonGia;
        private PictureBox picHinhAnh;
        private Button btnThem, btnSua, btnXoa, btnLuu, btnHuyBo, btnThoat, btnTimKiem, btnNhap, btnXuat, btnDoiAnh;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn colID, colPhanLoai, colHangSanXuat, colTenSanPham, colSoLuong, colDonGia;
        private DataGridViewImageColumn colHinhAnh;
    }
}
