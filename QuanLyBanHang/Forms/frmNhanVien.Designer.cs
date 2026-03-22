namespace QuanLyBanHang.Forms
{
    partial class frmNhanVien
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
            lblHoVaTen = new Label(); lblDienThoai = new Label(); lblDiaChi = new Label();
            lblTenDangNhap = new Label(); lblMatKhau = new Label(); lblQuyenHan = new Label();
            txtHoVaTen = new TextBox(); txtDienThoai = new TextBox(); txtDiaChi = new TextBox();
            txtTenDangNhap = new TextBox(); txtMatKhau = new TextBox();
            cboQuyenHan = new ComboBox();
            btnThem = new Button(); btnSua = new Button(); btnXoa = new Button();
            btnLuu = new Button(); btnHuyBo = new Button(); btnThoat = new Button();
            btnTimKiem = new Button(); btnNhap = new Button(); btnXuat = new Button();
            dataGridView = new DataGridView();
            colID = new DataGridViewTextBoxColumn(); colHoVaTen = new DataGridViewTextBoxColumn();
            colDienThoai = new DataGridViewTextBoxColumn(); colDiaChi = new DataGridViewTextBoxColumn();
            colTenDangNhap = new DataGridViewTextBoxColumn(); colQuyenHan = new DataGridViewTextBoxColumn();

            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();

            // grpThongTin
            grpThongTin.Controls.AddRange(new Control[] {
                lblHoVaTen, txtHoVaTen, lblDienThoai, txtDienThoai,
                lblDiaChi, txtDiaChi, lblTenDangNhap, txtTenDangNhap,
                lblMatKhau, txtMatKhau, lblQuyenHan, cboQuyenHan,
                btnThem, btnSua, btnXoa, btnLuu, btnHuyBo, btnThoat,
                btnTimKiem, btnNhap, btnXuat
            });
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Size = new Size(1100, 118);
            grpThongTin.Text = "Thông tin nhân viên";

            // Row 1
            lblHoVaTen.AutoSize = true; lblHoVaTen.Location = new Point(10, 28); lblHoVaTen.Text = "Họ và tên (*):";
            txtHoVaTen.Location = new Point(100, 25); txtHoVaTen.Name = "txtHoVaTen"; txtHoVaTen.Size = new Size(180, 23);
            lblTenDangNhap.AutoSize = true; lblTenDangNhap.Location = new Point(295, 28); lblTenDangNhap.Text = "Tên đăng nhập (*):";
            txtTenDangNhap.Location = new Point(410, 25); txtTenDangNhap.Name = "txtTenDangNhap"; txtTenDangNhap.Size = new Size(140, 23);

            btnThem.Location = new Point(600, 22); btnThem.Size = new Size(75, 25); btnThem.Text = "Thêm"; btnThem.Click += btnThem_Click;
            btnLuu.Location = new Point(685, 22); btnLuu.Size = new Size(75, 25); btnLuu.Text = "Lưu"; btnLuu.Click += btnLuu_Click;
            btnTimKiem.Location = new Point(770, 22); btnTimKiem.Size = new Size(80, 25); btnTimKiem.Text = "Tìm kiếm"; btnTimKiem.Click += btnTimKiem_Click;

            // Row 2
            lblDienThoai.AutoSize = true; lblDienThoai.Location = new Point(10, 57); lblDienThoai.Text = "Điện thoại:";
            txtDienThoai.Location = new Point(100, 54); txtDienThoai.Name = "txtDienThoai"; txtDienThoai.Size = new Size(180, 23);
            lblMatKhau.AutoSize = true; lblMatKhau.Location = new Point(295, 57); lblMatKhau.Text = "Mật khẩu (*):";
            txtMatKhau.Location = new Point(410, 54); txtMatKhau.Name = "txtMatKhau"; txtMatKhau.Size = new Size(140, 23); txtMatKhau.PasswordChar = '*';

            btnSua.Location = new Point(600, 52); btnSua.Size = new Size(75, 25); btnSua.Text = "Sửa"; btnSua.Click += btnSua_Click;
            btnHuyBo.Location = new Point(685, 52); btnHuyBo.Size = new Size(75, 25); btnHuyBo.Text = "Hủy bỏ"; btnHuyBo.Click += btnHuyBo_Click;
            btnNhap.Location = new Point(770, 52); btnNhap.Size = new Size(80, 25); btnNhap.Text = "Nhập..."; btnNhap.Click += btnNhap_Click;

            // Row 3
            lblDiaChi.AutoSize = true; lblDiaChi.Location = new Point(10, 86); lblDiaChi.Text = "Địa chỉ:";
            txtDiaChi.Location = new Point(100, 83); txtDiaChi.Name = "txtDiaChi"; txtDiaChi.Size = new Size(180, 23);
            lblQuyenHan.AutoSize = true; lblQuyenHan.Location = new Point(295, 86); lblQuyenHan.Text = "Quyền hạn (*):";
            cboQuyenHan.Location = new Point(410, 83); cboQuyenHan.Name = "cboQuyenHan"; cboQuyenHan.Size = new Size(140, 23);
            cboQuyenHan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuyenHan.Items.AddRange(new object[] { "Quản lý", "Nhân viên" });

            btnXoa.Location = new Point(600, 82); btnXoa.Size = new Size(75, 25); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnThoat.Location = new Point(685, 82); btnThoat.Size = new Size(75, 25); btnThoat.Text = "Thoát"; btnThoat.Click += btnThoat_Click;
            btnXuat.Location = new Point(770, 82); btnXuat.Size = new Size(80, 25); btnXuat.Text = "Xuất..."; btnXuat.Click += btnXuat_Click;

            // grpDanhSach
            grpDanhSach.Controls.Add(dataGridView);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Text = "Danh sách nhân viên";

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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colID, colHoVaTen, colDienThoai, colDiaChi, colTenDangNhap, colQuyenHan });

            colID.DataPropertyName = "ID"; colID.HeaderText = "ID"; colID.Name = "ID"; colID.Width = 50;
            colHoVaTen.DataPropertyName = "HoVaTen"; colHoVaTen.HeaderText = "Họ và tên"; colHoVaTen.Name = "HoVaTen";
            colDienThoai.DataPropertyName = "DienThoai"; colDienThoai.HeaderText = "Điện thoại"; colDienThoai.Name = "DienThoai";
            colDiaChi.DataPropertyName = "DiaChi"; colDiaChi.HeaderText = "Địa chỉ"; colDiaChi.Name = "DiaChi";
            colTenDangNhap.DataPropertyName = "TenDangNhap"; colTenDangNhap.HeaderText = "Tên đăng nhập"; colTenDangNhap.Name = "TenDangNhap";
            colQuyenHan.DataPropertyName = "QuyenHan"; colQuyenHan.HeaderText = "Quyền hạn"; colQuyenHan.Name = "QuyenHan";

            // Form
            ClientSize = new Size(1100, 580);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhân viên";
            Load += frmNhanVien_Load;

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpThongTin, grpDanhSach;
        private Label lblHoVaTen, lblDienThoai, lblDiaChi, lblTenDangNhap, lblMatKhau, lblQuyenHan;
        private TextBox txtHoVaTen, txtDienThoai, txtDiaChi, txtTenDangNhap, txtMatKhau;
        private ComboBox cboQuyenHan;
        private Button btnThem, btnSua, btnXoa, btnLuu, btnHuyBo, btnThoat, btnTimKiem, btnNhap, btnXuat;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn colID, colHoVaTen, colDienThoai, colDiaChi, colTenDangNhap, colQuyenHan;
    }
}
