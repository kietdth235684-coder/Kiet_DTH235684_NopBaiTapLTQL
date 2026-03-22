namespace QuanLyBanHang.Forms
{
    partial class frmKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpThongTin = new GroupBox();
            lblHoVaTen = new Label(); lblDienThoai = new Label(); lblDiaChi = new Label();
            txtHoVaTen = new TextBox(); txtDienThoai = new TextBox(); txtDiaChi = new TextBox();
            btnThem = new Button(); btnSua = new Button(); btnXoa = new Button();
            btnLuu = new Button(); btnHuyBo = new Button(); btnThoat = new Button();
            btnTimKiem = new Button(); btnNhap = new Button(); btnXuat = new Button();
            grpDanhSach = new GroupBox();
            dataGridView = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colHoVaTen = new DataGridViewTextBoxColumn();
            colDienThoai = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();

            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();

            // grpThongTin
            grpThongTin.Controls.AddRange(new Control[] {
                lblHoVaTen, txtHoVaTen, lblDienThoai, txtDienThoai,
                lblDiaChi, txtDiaChi,
                btnThem, btnSua, btnXoa, btnLuu, btnHuyBo, btnThoat,
                btnTimKiem, btnNhap, btnXuat
            });
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Size = new Size(1000, 110);
            grpThongTin.Text = "Thông tin khách hàng";

            // Row 1: HoVaTen, DienThoai, buttons col 1
            lblHoVaTen.AutoSize = true; lblHoVaTen.Location = new Point(10, 28); lblHoVaTen.Text = "Họ và tên (*):";
            txtHoVaTen.Location = new Point(100, 25); txtHoVaTen.Name = "txtHoVaTen"; txtHoVaTen.Size = new Size(200, 23);
            lblDienThoai.AutoSize = true; lblDienThoai.Location = new Point(315, 28); lblDienThoai.Text = "Điện thoại:";
            txtDienThoai.Location = new Point(390, 25); txtDienThoai.Name = "txtDienThoai"; txtDienThoai.Size = new Size(160, 23);

            btnThem.Location = new Point(580, 22); btnThem.Size = new Size(75, 25); btnThem.Text = "Thêm"; btnThem.Click += btnThem_Click;
            btnLuu.Location = new Point(665, 22); btnLuu.Size = new Size(75, 25); btnLuu.Text = "Lưu"; btnLuu.Click += btnLuu_Click;
            btnTimKiem.Location = new Point(750, 22); btnTimKiem.Size = new Size(80, 25); btnTimKiem.Text = "Tìm kiếm"; btnTimKiem.Click += btnTimKiem_Click;

            // Row 2: DiaChi, buttons col 2
            lblDiaChi.AutoSize = true; lblDiaChi.Location = new Point(10, 58); lblDiaChi.Text = "Địa chỉ:";
            txtDiaChi.Location = new Point(100, 55); txtDiaChi.Name = "txtDiaChi"; txtDiaChi.Size = new Size(450, 23);

            btnSua.Location = new Point(580, 52); btnSua.Size = new Size(75, 25); btnSua.Text = "Sửa"; btnSua.Click += btnSua_Click;
            btnHuyBo.Location = new Point(665, 52); btnHuyBo.Size = new Size(75, 25); btnHuyBo.Text = "Hủy bỏ"; btnHuyBo.Click += btnHuyBo_Click;
            btnNhap.Location = new Point(750, 52); btnNhap.Size = new Size(80, 25); btnNhap.Text = "Nhập..."; btnNhap.Click += btnNhap_Click;

            btnXoa.Location = new Point(580, 80); btnXoa.Size = new Size(75, 25); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnThoat.Location = new Point(665, 80); btnThoat.Size = new Size(75, 25); btnThoat.Text = "Thoát"; btnThoat.Click += btnThoat_Click;
            btnXuat.Location = new Point(750, 80); btnXuat.Size = new Size(80, 25); btnXuat.Text = "Xuất..."; btnXuat.Click += btnXuat_Click;

            // grpDanhSach
            grpDanhSach.Controls.Add(dataGridView);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Text = "Danh sách khách hàng";

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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colID, colHoVaTen, colDienThoai, colDiaChi });

            colID.DataPropertyName = "ID"; colID.HeaderText = "ID"; colID.Name = "ID"; colID.Width = 50;
            colHoVaTen.DataPropertyName = "HoVaTen"; colHoVaTen.HeaderText = "Họ và tên"; colHoVaTen.Name = "HoVaTen";
            colDienThoai.DataPropertyName = "DienThoai"; colDienThoai.HeaderText = "Điện thoại"; colDienThoai.Name = "DienThoai";
            colDiaChi.DataPropertyName = "DiaChi"; colDiaChi.HeaderText = "Địa chỉ"; colDiaChi.Name = "DiaChi";

            // Form
            ClientSize = new Size(1000, 560);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khách hàng";
            Load += frmKhachHang_Load;

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpThongTin, grpDanhSach;
        private Label lblHoVaTen, lblDienThoai, lblDiaChi;
        private TextBox txtHoVaTen, txtDienThoai, txtDiaChi;
        private Button btnThem, btnSua, btnXoa, btnLuu, btnHuyBo, btnThoat, btnTimKiem, btnNhap, btnXuat;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn colID, colHoVaTen, colDienThoai, colDiaChi;
    }
}
