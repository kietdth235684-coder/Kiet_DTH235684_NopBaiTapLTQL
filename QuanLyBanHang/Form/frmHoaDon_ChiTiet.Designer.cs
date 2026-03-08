namespace QuanLyBanHang
{
    partial class frmHoaDon_ChiTiet
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            panel2 = new Panel();
            cboNhanVien = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel3 = new Panel();
            cboKhachHang = new ComboBox();
            label2 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel4 = new Panel();
            txtGhiChuHoaDon = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            tableLayoutPanel8 = new TableLayoutPanel();
            btnLuuHoaDon = new Button();
            btnInHoaDon = new Button();
            btnThoat = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
            groupBox2 = new GroupBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            cboSanPham = new ComboBox();
            numDonGiaBan = new NumericUpDown();
            numSoLuongBan = new NumericUpDown();
            btnXacNhanBan = new Button();
            btnXoa = new Button();
            dataGridView = new DataGridView();
            SanPhamID = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            DonGiaBan = new DataGridViewTextBoxColumn();
            SoLuongBan = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1264, 182);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1258, 154);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1252, 71);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.8387089F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.16129F));
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(panel2, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(620, 65);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(179, 65);
            label1.TabIndex = 2;
            label1.Text = "Nhân viên lập (*):";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.Controls.Add(cboNhanVien);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(188, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(429, 59);
            panel2.TabIndex = 3;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(3, 16);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(423, 29);
            cboNhanVien.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.1935482F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.80645F));
            tableLayoutPanel4.Controls.Add(panel3, 1, 0);
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(629, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(620, 65);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(cboKhachHang);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(153, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(464, 59);
            panel3.TabIndex = 4;
            // 
            // cboKhachHang
            // 
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(3, 16);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(458, 29);
            cboKhachHang.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(144, 65);
            label2.TabIndex = 3;
            label2.Text = "Khách hàng (*):";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.015974F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.984024F));
            tableLayoutPanel5.Controls.Add(panel4, 0, 0);
            tableLayoutPanel5.Controls.Add(label3, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 80);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(1252, 71);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtGhiChuHoaDon);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(191, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1058, 65);
            panel4.TabIndex = 4;
            // 
            // txtGhiChuHoaDon
            // 
            txtGhiChuHoaDon.Location = new Point(3, 16);
            txtGhiChuHoaDon.Name = "txtGhiChuHoaDon";
            txtGhiChuHoaDon.Size = new Size(1049, 29);
            txtGhiChuHoaDon.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(182, 71);
            label3.TabIndex = 3;
            label3.Text = "Ghi chú hóa đơn:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel8);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 587);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 94);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 5;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.5963306F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.9357815F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.9357815F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.9357815F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.5963306F));
            tableLayoutPanel8.Controls.Add(btnLuuHoaDon, 1, 0);
            tableLayoutPanel8.Controls.Add(btnInHoaDon, 2, 0);
            tableLayoutPanel8.Controls.Add(btnThoat, 3, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(1264, 94);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // btnLuuHoaDon
            // 
            btnLuuHoaDon.Dock = DockStyle.Fill;
            btnLuuHoaDon.Font = new Font("Segoe UI", 12F);
            btnLuuHoaDon.ForeColor = SystemColors.MenuHighlight;
            btnLuuHoaDon.Location = new Point(213, 16);
            btnLuuHoaDon.Margin = new Padding(16);
            btnLuuHoaDon.Name = "btnLuuHoaDon";
            btnLuuHoaDon.Size = new Size(257, 62);
            btnLuuHoaDon.TabIndex = 0;
            btnLuuHoaDon.Text = "Lưu hóa đơn";
            btnLuuHoaDon.UseVisualStyleBackColor = true;
            btnLuuHoaDon.Click += btnLuuHoaDon_Click;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Dock = DockStyle.Fill;
            btnInHoaDon.Font = new Font("Segoe UI", 12F);
            btnInHoaDon.Location = new Point(502, 16);
            btnInHoaDon.Margin = new Padding(16);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(257, 62);
            btnInHoaDon.TabIndex = 1;
            btnInHoaDon.Text = "In hóa đơn";
            btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Dock = DockStyle.Fill;
            btnThoat.Font = new Font("Segoe UI", 12F);
            btnThoat.ForeColor = Color.Red;
            btnThoat.Location = new Point(791, 16);
            btnThoat.Margin = new Padding(16);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(257, 62);
            btnThoat.TabIndex = 2;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel6);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 182);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1264, 405);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết hóa đơn";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(tableLayoutPanel7, 0, 0);
            tableLayoutPanel6.Controls.Add(dataGridView, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 25);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 24.403183F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 75.59682F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(1258, 377);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 5;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.6877632F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.3122368F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 237F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
            tableLayoutPanel7.Controls.Add(label6, 2, 0);
            tableLayoutPanel7.Controls.Add(label5, 1, 0);
            tableLayoutPanel7.Controls.Add(label4, 0, 0);
            tableLayoutPanel7.Controls.Add(cboSanPham, 0, 1);
            tableLayoutPanel7.Controls.Add(numDonGiaBan, 1, 1);
            tableLayoutPanel7.Controls.Add(numSoLuongBan, 2, 1);
            tableLayoutPanel7.Controls.Add(btnXacNhanBan, 3, 1);
            tableLayoutPanel7.Controls.Add(btnXoa, 4, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 59.3023262F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 40.6976738F));
            tableLayoutPanel7.Size = new Size(1252, 86);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(599, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(16, 0, 0, 0);
            label6.Size = new Size(231, 51);
            label6.TabIndex = 4;
            label6.Text = "Số lượng bán (*):";
            label6.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(311, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(16, 0, 0, 0);
            label5.Size = new Size(282, 51);
            label5.TabIndex = 2;
            label5.Text = "Đơn giá bán (*):";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(16, 0, 0, 0);
            label4.Size = new Size(302, 51);
            label4.TabIndex = 0;
            label4.Text = "Sản phẩm (*):";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cboSanPham
            // 
            cboSanPham.Dock = DockStyle.Fill;
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(16, 54);
            cboSanPham.Margin = new Padding(16, 3, 3, 3);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(289, 29);
            cboSanPham.TabIndex = 1;
            // 
            // numDonGiaBan
            // 
            numDonGiaBan.Dock = DockStyle.Fill;
            numDonGiaBan.Location = new Point(324, 54);
            numDonGiaBan.Margin = new Padding(16, 3, 3, 3);
            numDonGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGiaBan.Name = "numDonGiaBan";
            numDonGiaBan.Size = new Size(269, 29);
            numDonGiaBan.TabIndex = 3;
            numDonGiaBan.ThousandsSeparator = true;
            // 
            // numSoLuongBan
            // 
            numSoLuongBan.Location = new Point(612, 54);
            numSoLuongBan.Margin = new Padding(16, 3, 3, 3);
            numSoLuongBan.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuongBan.Name = "numSoLuongBan";
            numSoLuongBan.Size = new Size(210, 29);
            numSoLuongBan.TabIndex = 5;
            numSoLuongBan.ThousandsSeparator = true;
            // 
            // btnXacNhanBan
            // 
            btnXacNhanBan.Dock = DockStyle.Fill;
            btnXacNhanBan.Location = new Point(849, 54);
            btnXacNhanBan.Margin = new Padding(16, 3, 16, 3);
            btnXacNhanBan.Name = "btnXacNhanBan";
            btnXacNhanBan.Size = new Size(228, 29);
            btnXacNhanBan.TabIndex = 6;
            btnXacNhanBan.Text = "Xác nhận bán";
            btnXacNhanBan.UseVisualStyleBackColor = true;
            btnXacNhanBan.Click += btnXacNhanBan_Click;
            // 
            // btnXoa
            // 
            btnXoa.Dock = DockStyle.Fill;
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(1109, 54);
            btnXoa.Margin = new Padding(16, 3, 16, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(127, 29);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { SanPhamID, TenSanPham, DonGiaBan, SoLuongBan, ThanhTien });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 95);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(1252, 279);
            dataGridView.TabIndex = 1;
            // 
            // SanPhamID
            // 
            SanPhamID.DataPropertyName = "SanPhamID";
            SanPhamID.HeaderText = "ID";
            SanPhamID.Name = "SanPhamID";
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Tên sản phẩm";
            TenSanPham.Name = "TenSanPham";
            // 
            // DonGiaBan
            // 
            DonGiaBan.DataPropertyName = "DonGiaBan";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            DonGiaBan.DefaultCellStyle = dataGridViewCellStyle4;
            DonGiaBan.HeaderText = "Đơn giá bán";
            DonGiaBan.Name = "DonGiaBan";
            // 
            // SoLuongBan
            // 
            SoLuongBan.DataPropertyName = "SoLuongBan";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            SoLuongBan.DefaultCellStyle = dataGridViewCellStyle5;
            SoLuongBan.HeaderText = "Số lượng bán";
            SoLuongBan.Name = "SoLuongBan";
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.ForeColor = Color.Blue;
            ThanhTien.DefaultCellStyle = dataGridViewCellStyle6;
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.Name = "ThanhTien";
            // 
            // frmHoaDon_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "frmHoaDon_ChiTiet";
            Text = "frmHoaDon_ChiTiet";
            Load += frmHoaDon_ChiTiet_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel3.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel2;
        private TextBox textBox1;
        private Panel panel3;
        private ComboBox cboKhachHang;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel4;
        private TextBox txtGhiChuHoaDon;
        private Label label3;
        private FileSystemWatcher fileSystemWatcher1;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label4;
        private Label label6;
        private Label label5;
        private ComboBox cboSanPham;
        private NumericUpDown numDonGiaBan;
        private NumericUpDown numSoLuongBan;
        private Button btnXacNhanBan;
        private Button btnXoa;
        private ComboBox cboNhanVien;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn SanPhamID;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn DonGiaBan;
        private DataGridViewTextBoxColumn SoLuongBan;
        private DataGridViewTextBoxColumn ThanhTien;
        private TableLayoutPanel tableLayoutPanel8;
        private Button btnLuuHoaDon;
        private Button btnInHoaDon;
        private Button btnThoat;
    }
}