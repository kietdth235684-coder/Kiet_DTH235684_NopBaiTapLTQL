namespace QuanLyBanHang.Forms
{
    partial class frmLoaiSanPham
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
            lblTenLoai = new Label();
            txtTenLoai = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuyBo = new Button();
            btnThoat = new Button();
            grpDanhSach = new GroupBox();
            dataGridView = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colTenLoai = new DataGridViewTextBoxColumn();

            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();

            // grpThongTin
            grpThongTin.Controls.Add(lblTenLoai);
            grpThongTin.Controls.Add(txtTenLoai);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLuu);
            grpThongTin.Controls.Add(btnHuyBo);
            grpThongTin.Controls.Add(btnThoat);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Location = new Point(0, 0);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(900, 90);
            grpThongTin.Text = "Thông tin loại sản phẩm";

            // lblTenLoai
            lblTenLoai.AutoSize = true;
            lblTenLoai.Location = new Point(12, 30);
            lblTenLoai.Text = "Tên loại sản phẩm (*):";

            // txtTenLoai
            txtTenLoai.Location = new Point(155, 27);
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.Size = new Size(300, 23);

            // Buttons row
            btnThem.Location = new Point(155, 58); btnThem.Size = new Size(75, 25); btnThem.Text = "Thêm"; btnThem.Click += btnThem_Click;
            btnSua.Location = new Point(240, 58); btnSua.Size = new Size(75, 25); btnSua.Text = "Sửa"; btnSua.Click += btnSua_Click;
            btnXoa.Location = new Point(325, 58); btnXoa.Size = new Size(75, 25); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnLuu.Location = new Point(410, 58); btnLuu.Size = new Size(75, 25); btnLuu.Text = "Lưu"; btnLuu.Click += btnLuu_Click;
            btnHuyBo.Location = new Point(495, 58); btnHuyBo.Size = new Size(75, 25); btnHuyBo.Text = "Hủy bỏ"; btnHuyBo.Click += btnHuyBo_Click;
            btnThoat.Location = new Point(580, 58); btnThoat.Size = new Size(75, 25); btnThoat.Text = "Thoát"; btnThoat.Click += btnThoat_Click;
            btnNhap = new Button(); btnNhap.Location = new Point(665, 58); btnNhap.Size = new Size(75, 25); btnNhap.Text = "Nhập..."; btnNhap.Click += btnNhap_Click;
            btnXuat = new Button(); btnXuat.Location = new Point(750, 58); btnXuat.Size = new Size(75, 25); btnXuat.Text = "Xuất..."; btnXuat.Click += btnXuat_Click;
            grpThongTin.Controls.Add(btnNhap);
            grpThongTin.Controls.Add(btnXuat);

            // grpDanhSach
            grpDanhSach.Controls.Add(dataGridView);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Location = new Point(0, 90);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Text = "Danh sách loại sản phẩm";

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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colID, colTenLoai });

            // colID
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID";
            colID.Name = "ID";
            colID.Width = 60;

            // colTenLoai
            colTenLoai.DataPropertyName = "TenLoai";
            colTenLoai.HeaderText = "Tên loại sản phẩm";
            colTenLoai.Name = "TenLoai";

            // frmLoaiSanPham
            ClientSize = new Size(900, 500);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            Name = "frmLoaiSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loại sản phẩm";
            Load += frmLoaiSanPham_Load;

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpThongTin;
        private GroupBox grpDanhSach;
        private Label lblTenLoai;
        private TextBox txtTenLoai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuyBo;
        private Button btnThoat;
        private Button btnNhap;
        private Button btnXuat;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colTenLoai;
    }
}
