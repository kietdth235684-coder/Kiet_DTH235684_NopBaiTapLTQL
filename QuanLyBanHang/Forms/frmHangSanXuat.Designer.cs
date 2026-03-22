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
            grpDanhSach = new GroupBox();
            dataGridView = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colTenHangSanXuat = new DataGridViewTextBoxColumn();

            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();

            // grpThongTin
            grpThongTin.Controls.Add(lblTenHangSanXuat);
            grpThongTin.Controls.Add(txtTenHangSanXuat);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLuu);
            grpThongTin.Controls.Add(btnHuyBo);
            grpThongTin.Controls.Add(btnThoat);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Size = new Size(900, 90);
            grpThongTin.Text = "Thông tin hãng sản xuất";

            // lblTenHangSanXuat
            lblTenHangSanXuat.AutoSize = true;
            lblTenHangSanXuat.Location = new Point(12, 30);
            lblTenHangSanXuat.Text = "Tên hãng sản xuất (*):";

            // txtTenHangSanXuat
            txtTenHangSanXuat.Location = new Point(160, 27);
            txtTenHangSanXuat.Name = "txtTenHangSanXuat";
            txtTenHangSanXuat.Size = new Size(300, 23);

            // Buttons
            btnThem.Location = new Point(160, 58); btnThem.Size = new Size(75, 25); btnThem.Text = "Thêm"; btnThem.Click += btnThem_Click;
            btnSua.Location = new Point(245, 58); btnSua.Size = new Size(75, 25); btnSua.Text = "Sửa"; btnSua.Click += btnSua_Click;
            btnXoa.Location = new Point(330, 58); btnXoa.Size = new Size(75, 25); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnLuu.Location = new Point(415, 58); btnLuu.Size = new Size(75, 25); btnLuu.Text = "Lưu"; btnLuu.Click += btnLuu_Click;
            btnHuyBo.Location = new Point(500, 58); btnHuyBo.Size = new Size(75, 25); btnHuyBo.Text = "Hủy bỏ"; btnHuyBo.Click += btnHuyBo_Click;
            btnThoat.Location = new Point(585, 58); btnThoat.Size = new Size(75, 25); btnThoat.Text = "Thoát"; btnThoat.Click += btnThoat_Click;
            btnNhap = new Button(); btnNhap.Location = new Point(670, 58); btnNhap.Size = new Size(75, 25); btnNhap.Text = "Nhập..."; btnNhap.Click += btnNhap_Click;
            btnXuat = new Button(); btnXuat.Location = new Point(755, 58); btnXuat.Size = new Size(75, 25); btnXuat.Text = "Xuất..."; btnXuat.Click += btnXuat_Click;
            grpThongTin.Controls.Add(btnNhap);
            grpThongTin.Controls.Add(btnXuat);

            // grpDanhSach
            grpDanhSach.Controls.Add(dataGridView);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Text = "Danh sách hãng sản xuất";

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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colID, colTenHangSanXuat });

            colID.DataPropertyName = "ID"; colID.HeaderText = "ID"; colID.Name = "ID"; colID.Width = 60;
            colTenHangSanXuat.DataPropertyName = "TenHangSanXuat"; colTenHangSanXuat.HeaderText = "Tên hãng sản xuất"; colTenHangSanXuat.Name = "TenHangSanXuat";

            // frmHangSanXuat
            ClientSize = new Size(900, 500);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
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
