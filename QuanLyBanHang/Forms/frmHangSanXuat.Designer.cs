namespace QuanLyBanHang.Forms
{
    partial class frmHangSanXuat
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
            lblTenHangSanXuat = new Label();
            txtTenHangSanXuat = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuyBo = new Button();
            btnThoat = new Button();
            btnNhap = new Button();
            btnXuat = new Button();
            grpDanhSach = new GroupBox();
            dataGridView = new DataGridView();
            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblTenHangSanXuat);
            grpThongTin.Controls.Add(txtTenHangSanXuat);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLuu);
            grpThongTin.Controls.Add(btnHuyBo);
            grpThongTin.Controls.Add(btnThoat);
            grpThongTin.Controls.Add(btnNhap);
            grpThongTin.Controls.Add(btnXuat);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Location = new Point(0, 0);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(900, 90);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin hãng sản xuất";
            // 
            // lblTenHangSanXuat
            // 
            lblTenHangSanXuat.AutoSize = true;
            lblTenHangSanXuat.Location = new Point(12, 30);
            lblTenHangSanXuat.Name = "lblTenHangSanXuat";
            lblTenHangSanXuat.Size = new Size(150, 20);
            lblTenHangSanXuat.TabIndex = 0;
            lblTenHangSanXuat.Text = "Tên hãng sản xuất (*):";
            // 
            // txtTenHangSanXuat
            // 
            txtTenHangSanXuat.Location = new Point(160, 27);
            txtTenHangSanXuat.Name = "txtTenHangSanXuat";
            txtTenHangSanXuat.Size = new Size(670, 27);
            txtTenHangSanXuat.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(160, 58);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 25);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(245, 58);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 25);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(330, 58);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 25);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(415, 58);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 25);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(500, 58);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(75, 25);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(585, 58);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 25);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(670, 58);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(75, 25);
            btnNhap.TabIndex = 8;
            btnNhap.Text = "Nhập...";
            btnNhap.Click += btnNhap_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(755, 58);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(75, 25);
            btnXuat.TabIndex = 9;
            btnXuat.Text = "Xuất...";
            btnXuat.Click += btnXuat_Click;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(dataGridView);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Location = new Point(0, 90);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(900, 410);
            grpDanhSach.TabIndex = 0;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách hãng sản xuất";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeight = 29;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(894, 384);
            dataGridView.TabIndex = 0;
            // 
            // frmHangSanXuat
            // 
            ClientSize = new Size(900, 500);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            Name = "frmHangSanXuat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hãng sản xuất";
            Load += frmHangSanXuat_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpThongTin, grpDanhSach;
        private Label lblTenHangSanXuat;
        private TextBox txtTenHangSanXuat;
        private Button btnThem, btnSua, btnXoa, btnLuu, btnHuyBo, btnThoat, btnNhap, btnXuat;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn colID, colTenHangSanXuat;
    }
}
