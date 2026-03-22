namespace QuanLyBanHang.Forms
{
    partial class frmHoaDon_ChiTiet
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpHoaDon = new GroupBox();
            grpChiTiet = new GroupBox();
            pnlButtons = new Panel();

            lblNhanVien = new Label(); cboNhanVien = new ComboBox();
            lblKhachHang = new Label(); cboKhachHang = new ComboBox();
            lblGhiChu = new Label(); txtGhiChuHoaDon = new TextBox();
            lblSanPham = new Label(); cboSanPham = new ComboBox();
            lblDonGiaBan = new Label(); numDonGiaBan = new NumericUpDown();
            lblSoLuongBan = new Label(); numSoLuongBan = new NumericUpDown();
            btnXacNhanBan = new Button();
            btnXoa = new Button();
            btnLuuHoaDon = new Button();
            btnInHoaDon = new Button();
            btnThoat = new Button();

            dataGridView = new DataGridView();
            colSanPhamID = new DataGridViewTextBoxColumn();
            colTenSanPham = new DataGridViewTextBoxColumn();
            colDonGiaBan = new DataGridViewTextBoxColumn();
            colSoLuongBan = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();

            grpHoaDon.SuspendLayout();
            grpChiTiet.SuspendLayout();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();

            // grpHoaDon
            grpHoaDon.Controls.AddRange(new Control[] {
                lblNhanVien, cboNhanVien, lblKhachHang, cboKhachHang, lblGhiChu, txtGhiChuHoaDon
            });
            grpHoaDon.Dock = DockStyle.Top;
            grpHoaDon.Size = new Size(1000, 90);
            grpHoaDon.Text = "Thông tin hóa đơn";

            lblNhanVien.AutoSize = true; lblNhanVien.Location = new Point(10, 30); lblNhanVien.Text = "Nhân viên lập (*):";
            cboNhanVien.Location = new Point(125, 27); cboNhanVien.Name = "cboNhanVien"; cboNhanVien.Size = new Size(200, 23); cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            lblKhachHang.AutoSize = true; lblKhachHang.Location = new Point(360, 30); lblKhachHang.Text = "Khách hàng (*):";
            cboKhachHang.Location = new Point(460, 27); cboKhachHang.Name = "cboKhachHang"; cboKhachHang.Size = new Size(200, 23); cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            lblGhiChu.AutoSize = true; lblGhiChu.Location = new Point(10, 60); lblGhiChu.Text = "Ghi chú hóa đơn:";
            txtGhiChuHoaDon.Location = new Point(125, 57); txtGhiChuHoaDon.Name = "txtGhiChuHoaDon"; txtGhiChuHoaDon.Size = new Size(535, 23);

            // grpChiTiet
            grpChiTiet.Controls.AddRange(new Control[] {
                lblSanPham, cboSanPham, lblDonGiaBan, numDonGiaBan,
                lblSoLuongBan, numSoLuongBan, btnXacNhanBan, btnXoa, dataGridView
            });
            grpChiTiet.Dock = DockStyle.Fill;
            grpChiTiet.Text = "Thông tin chi tiết hóa đơn";

            lblSanPham.AutoSize = true; lblSanPham.Location = new Point(10, 28); lblSanPham.Text = "Sản phẩm (*):";
            cboSanPham.Location = new Point(100, 25); cboSanPham.Name = "cboSanPham"; cboSanPham.Size = new Size(220, 23); cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanPham.SelectionChangeCommitted += cboSanPham_SelectionChangeCommitted;

            lblDonGiaBan.AutoSize = true; lblDonGiaBan.Location = new Point(330, 28); lblDonGiaBan.Text = "Đơn giá bán (*):";
            numDonGiaBan.Location = new Point(425, 25); numDonGiaBan.Name = "numDonGiaBan"; numDonGiaBan.Size = new Size(130, 23);
            numDonGiaBan.Minimum = 0; numDonGiaBan.Maximum = 1000000000; numDonGiaBan.ThousandsSeparator = true;

            lblSoLuongBan.AutoSize = true; lblSoLuongBan.Location = new Point(570, 28); lblSoLuongBan.Text = "Số lượng bán (*):";
            numSoLuongBan.Location = new Point(670, 25); numSoLuongBan.Name = "numSoLuongBan"; numSoLuongBan.Size = new Size(80, 23);
            numSoLuongBan.Minimum = 0; numSoLuongBan.Maximum = 1000; numSoLuongBan.ThousandsSeparator = true; numSoLuongBan.Value = 1;

            btnXacNhanBan.Location = new Point(760, 23); btnXacNhanBan.Size = new Size(100, 28); btnXacNhanBan.Text = "Xác nhận bán"; btnXacNhanBan.Click += btnXacNhanBan_Click;
            btnXoa.Location = new Point(870, 23); btnXoa.Size = new Size(60, 28); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;

            // dataGridView
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Location = new Point(10, 60);
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.Size = new Size(970, 300);
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Name = "dataGridView";
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                colSanPhamID, colTenSanPham, colDonGiaBan, colSoLuongBan, colThanhTien
            });

            colSanPhamID.DataPropertyName = "SanPhamID"; colSanPhamID.HeaderText = "ID"; colSanPhamID.Name = "SanPhamID"; colSanPhamID.Width = 50;
            colTenSanPham.DataPropertyName = "TenSanPham"; colTenSanPham.HeaderText = "Tên sản phẩm"; colTenSanPham.Name = "TenSanPham";
            colDonGiaBan.DataPropertyName = "DonGiaBan"; colDonGiaBan.HeaderText = "Đơn giá bán"; colDonGiaBan.Name = "DonGiaBan";
            colDonGiaBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDonGiaBan.DefaultCellStyle.Format = "N0";
            colSoLuongBan.DataPropertyName = "SoLuongBan"; colSoLuongBan.HeaderText = "Số lượng bán"; colSoLuongBan.Name = "SoLuongBan";
            colSoLuongBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colThanhTien.DataPropertyName = "ThanhTien"; colThanhTien.HeaderText = "Thành tiền"; colThanhTien.Name = "ThanhTien";
            colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colThanhTien.DefaultCellStyle.Format = "N0";
            colThanhTien.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colThanhTien.DefaultCellStyle.ForeColor = Color.DarkBlue;

            // pnlButtons
            pnlButtons.Controls.AddRange(new Control[] { btnLuuHoaDon, btnInHoaDon, btnThoat });
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Height = 45;

            btnLuuHoaDon.Location = new Point(300, 8); btnLuuHoaDon.Size = new Size(100, 28); btnLuuHoaDon.Text = "Lưu hóa đơn"; btnLuuHoaDon.Click += btnLuuHoaDon_Click;
            btnInHoaDon.Location = new Point(410, 8); btnInHoaDon.Size = new Size(100, 28); btnInHoaDon.Text = "In hóa đơn..."; btnInHoaDon.Click += btnInHoaDon_Click;
            btnThoat.Location = new Point(520, 8); btnThoat.Size = new Size(75, 28); btnThoat.Text = "Thoát"; btnThoat.Click += btnThoat_Click;

            // Form
            ClientSize = new Size(1000, 560);
            Controls.Add(grpChiTiet);
            Controls.Add(grpHoaDon);
            Controls.Add(pnlButtons);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa đơn chi tiết";
            Load += frmHoaDon_ChiTiet_Load;

            grpHoaDon.ResumeLayout(false);
            grpHoaDon.PerformLayout();
            grpChiTiet.ResumeLayout(false);
            grpChiTiet.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpHoaDon, grpChiTiet;
        private Panel pnlButtons;
        private Label lblNhanVien, lblKhachHang, lblGhiChu, lblSanPham, lblDonGiaBan, lblSoLuongBan;
        private ComboBox cboNhanVien, cboKhachHang, cboSanPham;
        private TextBox txtGhiChuHoaDon;
        private NumericUpDown numDonGiaBan, numSoLuongBan;
        private Button btnXacNhanBan, btnXoa, btnLuuHoaDon, btnInHoaDon, btnThoat;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn colSanPhamID, colTenSanPham, colDonGiaBan, colSoLuongBan, colThanhTien;
    }
}
