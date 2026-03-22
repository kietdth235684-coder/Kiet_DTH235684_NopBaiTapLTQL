namespace QuanLyBanHang.Forms
{
    partial class frmHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpDanhSach = new GroupBox();
            dataGridView = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colHoVaTenNhanVien = new DataGridViewTextBoxColumn();
            colHoVaTenKhachHang = new DataGridViewTextBoxColumn();
            colNgayLap = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            colXemChiTiet = new DataGridViewLinkColumn();
            pnlButtons = new Panel();
            btnLapHoaDon = new Button();
            btnInHoaDon = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            btnTimKiem = new Button();
            btnXuat = new Button();

            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // grpDanhSach
            grpDanhSach.Controls.Add(dataGridView);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Text = "Danh sách hóa đơn";

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
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
                colID, colHoVaTenNhanVien, colHoVaTenKhachHang,
                colNgayLap, colTongTien, colXemChiTiet
            });

            colID.DataPropertyName = "ID"; colID.HeaderText = "ID"; colID.Name = "ID"; colID.Width = 50;
            colHoVaTenNhanVien.DataPropertyName = "HoVaTenNhanVien"; colHoVaTenNhanVien.HeaderText = "Nhân viên"; colHoVaTenNhanVien.Name = "HoVaTenNhanVien";
            colHoVaTenKhachHang.DataPropertyName = "HoVaTenKhachHang"; colHoVaTenKhachHang.HeaderText = "Khách hàng"; colHoVaTenKhachHang.Name = "HoVaTenKhachHang";

            colNgayLap.DataPropertyName = "NgayLap"; colNgayLap.HeaderText = "Ngày lập"; colNgayLap.Name = "NgayLap";
            colNgayLap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNgayLap.DefaultCellStyle.Format = "dd/MM/yyyy";

            colTongTien.DataPropertyName = "TongTienHoaDon"; colTongTien.HeaderText = "Tổng tiền"; colTongTien.Name = "TongTienHoaDon";
            colTongTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTongTien.DefaultCellStyle.Format = "N0";
            colTongTien.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colTongTien.DefaultCellStyle.ForeColor = Color.DarkBlue;

            colXemChiTiet.DataPropertyName = "XemChiTiet"; colXemChiTiet.HeaderText = "Chi tiết"; colXemChiTiet.Name = "XemChiTiet";
            colXemChiTiet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // pnlButtons
            pnlButtons.Controls.AddRange(new Control[] {
                btnLapHoaDon, btnInHoaDon, btnSua, btnXoa, btnThoat, btnTimKiem, btnXuat
            });
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Height = 45;
            pnlButtons.Padding = new Padding(5);

            btnLapHoaDon.Location = new Point(10, 8); btnLapHoaDon.Size = new Size(120, 28); btnLapHoaDon.Text = "Lập hóa đơn mới..."; btnLapHoaDon.Click += btnLapHoaDon_Click;
            btnInHoaDon.Location = new Point(140, 8); btnInHoaDon.Size = new Size(100, 28); btnInHoaDon.Text = "In hóa đơn..."; btnInHoaDon.Click += btnInHoaDon_Click;
            btnSua.Location = new Point(250, 8); btnSua.Size = new Size(75, 28); btnSua.Text = "Sửa..."; btnSua.Click += btnSua_Click;
            btnXoa.Location = new Point(335, 8); btnXoa.Size = new Size(75, 28); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnThoat.Location = new Point(420, 8); btnThoat.Size = new Size(75, 28); btnThoat.Text = "Thoát"; btnThoat.Click += btnThoat_Click;
            btnTimKiem.Location = new Point(505, 8); btnTimKiem.Size = new Size(90, 28); btnTimKiem.Text = "Tìm kiếm..."; btnTimKiem.Click += btnTimKiem_Click;
            btnXuat.Location = new Point(605, 8); btnXuat.Size = new Size(100, 28); btnXuat.Text = "Xuất Excel..."; btnXuat.Click += btnXuat_Click;

            // Form
            ClientSize = new Size(950, 520);
            Controls.Add(grpDanhSach);
            Controls.Add(pnlButtons);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa đơn";
            Load += frmHoaDon_Load;

            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private GroupBox grpDanhSach;
        private Panel pnlButtons;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn colID, colHoVaTenNhanVien, colHoVaTenKhachHang, colNgayLap, colTongTien;
        private DataGridViewLinkColumn colXemChiTiet;
        private Button btnLapHoaDon, btnInHoaDon, btnSua, btnXoa, btnThoat, btnTimKiem, btnXuat;
    }
}
