namespace QuanLyBanHang.Forms
{
    partial class frmDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblTenDangNhap = new Label();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            btnHuyBo = new Button();
            picLock = new PictureBox();

            ((System.ComponentModel.ISupportInitialize)picLock).BeginInit();
            SuspendLayout();

            // picLock
            picLock.Location = new Point(20, 60);
            picLock.Size = new Size(80, 80);
            picLock.SizeMode = PictureBoxSizeMode.Zoom;
            picLock.BackColor = Color.Transparent;

            // lblTitle
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(110, 60);
            lblTitle.Size = new Size(280, 35);
            lblTitle.Text = "ĐĂNG NHẬP";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblTenDangNhap
            lblTenDangNhap.Location = new Point(110, 105);
            lblTenDangNhap.Size = new Size(280, 20);
            lblTenDangNhap.Text = "Tên đăng nhập:";

            // txtTenDangNhap
            txtTenDangNhap.Location = new Point(110, 125);
            txtTenDangNhap.Size = new Size(280, 23);
            txtTenDangNhap.Name = "txtTenDangNhap";
           
            // lblMatKhau
            lblMatKhau.Location = new Point(110, 158);
            lblMatKhau.Size = new Size(280, 20);
            lblMatKhau.Text = "Mật khẩu:";

            // txtMatKhau
            txtMatKhau.Location = new Point(110, 178);
            txtMatKhau.Size = new Size(280, 23);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;

            // btnDangNhap
            btnDangNhap.Location = new Point(110, 215);
            btnDangNhap.Size = new Size(130, 30);
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.BackColor = Color.SteelBlue;
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Click += btnDangNhap_Click;

            // btnHuyBo
            btnHuyBo.Location = new Point(260, 215);
            btnHuyBo.Size = new Size(130, 30);
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.Click += btnHuyBo_Click;

            // Form
            ClientSize = new Size(420, 270);
            Controls.AddRange(new Control[] {
                picLock, lblTitle,
                lblTenDangNhap, txtTenDangNhap,
                lblMatKhau, txtMatKhau,
                btnDangNhap, btnHuyBo });
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Name = "frmDangNhap";

            ((System.ComponentModel.ISupportInitialize)picLock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle, lblTenDangNhap, lblMatKhau;
        public TextBox txtTenDangNhap = null!;
        public TextBox txtMatKhau = null!;
        private Button btnDangNhap, btnHuyBo;
        private PictureBox picLock;
    }
}
