namespace QuanLyBanHang
{
    partial class frmHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            HoVaTenNhanVien = new DataGridViewTextBoxColumn();
            HoVaTenKhachHang = new DataGridViewTextBoxColumn();
            NgayLap = new DataGridViewTextBoxColumn();
            TongTienHoaDon = new DataGridViewTextBoxColumn();
            XemChiTiet = new DataGridViewLinkColumn();
            panel1 = new Panel();
            btnXuat = new Button();
            btnTimKiem = new Button();
            btnThoat = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnInHoaDon = new Button();
            btnLapHoaDon = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Controls.Add(panel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1264, 681);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách hóa đơn";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, HoVaTenNhanVien, HoVaTenKhachHang, NgayLap, TongTienHoaDon, XemChiTiet });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 25);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(1258, 553);
            dataGridView.TabIndex = 1;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // HoVaTenNhanVien
            // 
            HoVaTenNhanVien.DataPropertyName = "HoVaTenNhanVien";
            HoVaTenNhanVien.HeaderText = "Nhân viên";
            HoVaTenNhanVien.Name = "HoVaTenNhanVien";
            // 
            // HoVaTenKhachHang
            // 
            HoVaTenKhachHang.DataPropertyName = "HoVaTenNhanVien";
            HoVaTenKhachHang.HeaderText = "Khách hàng";
            HoVaTenKhachHang.Name = "HoVaTenKhachHang";
            // 
            // NgayLap
            // 
            NgayLap.DataPropertyName = "NgayLap";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            NgayLap.DefaultCellStyle = dataGridViewCellStyle1;
            NgayLap.HeaderText = "Ngày lập";
            NgayLap.Name = "NgayLap";
            // 
            // TongTienHoaDon
            // 
            TongTienHoaDon.DataPropertyName = "TongTienHoaDon";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Blue;
            dataGridViewCellStyle2.Format = "{0:N0}";
            TongTienHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            TongTienHoaDon.HeaderText = "Tổng tiền";
            TongTienHoaDon.Name = "TongTienHoaDon";
            TongTienHoaDon.Resizable = DataGridViewTriState.False;
            // 
            // XemChiTiet
            // 
            XemChiTiet.DataPropertyName = "XemChiTiet";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            XemChiTiet.DefaultCellStyle = dataGridViewCellStyle3;
            XemChiTiet.HeaderText = "Chi tiết";
            XemChiTiet.Name = "XemChiTiet";
            XemChiTiet.Resizable = DataGridViewTriState.True;
            XemChiTiet.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnXuat);
            panel1.Controls.Add(btnTimKiem);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnInHoaDon);
            panel1.Controls.Add(btnLapHoaDon);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 578);
            panel1.Name = "panel1";
            panel1.Size = new Size(1258, 100);
            panel1.TabIndex = 0;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(972, 37);
            btnXuat.Margin = new Padding(3, 3, 24, 3);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(98, 29);
            btnXuat.TabIndex = 6;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(847, 37);
            btnTimKiem.Margin = new Padding(3, 3, 24, 3);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(98, 29);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "Tìm kiếm...";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(740, 37);
            btnThoat.Margin = new Padding(3, 3, 24, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(80, 29);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(633, 37);
            btnXoa.Margin = new Padding(3, 3, 24, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 29);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(526, 37);
            btnSua.Margin = new Padding(3, 3, 24, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 29);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa...";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Location = new Point(387, 37);
            btnInHoaDon.Margin = new Padding(3, 3, 24, 3);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(112, 29);
            btnInHoaDon.TabIndex = 1;
            btnInHoaDon.Text = "In hóa đơn...";
            btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnLapHoaDon
            // 
            btnLapHoaDon.ForeColor = SystemColors.MenuHighlight;
            btnLapHoaDon.Location = new Point(203, 37);
            btnLapHoaDon.Margin = new Padding(3, 3, 24, 3);
            btnLapHoaDon.Name = "btnLapHoaDon";
            btnLapHoaDon.Size = new Size(157, 29);
            btnLapHoaDon.TabIndex = 0;
            btnLapHoaDon.Text = "Lập hóa đơn mới...";
            btnLapHoaDon.UseVisualStyleBackColor = true;
            btnLapHoaDon.Click += btnNhap_Click;
            // 
            // frmHoaDon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(groupBox1);
            Name = "frmHoaDon";
            Text = "Hóa đơn";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView;
        private Panel panel1;
        private Button btnLapHoaDon;
        private Button btnThoat;
        private Button btnXoa;
        private Button btnSua;
        private Button btnInHoaDon;
        private Button btnXuat;
        private Button btnTimKiem;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn HoVaTenNhanVien;
        private DataGridViewTextBoxColumn HoVaTenKhachHang;
        private DataGridViewTextBoxColumn NgayLap;
        private DataGridViewTextBoxColumn TongTienHoaDon;
        private DataGridViewLinkColumn XemChiTiet;
    }
}