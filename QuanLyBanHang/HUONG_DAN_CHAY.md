# HƯỚNG DẪN CHẠY PROJECT QuanLyBanHang

## YÊU CẦU HỆ THỐNG
- Visual Studio 2022 (hoặc mới hơn)
- .NET 8.0 SDK
- SQL Server Express (hoặc SQL Server)
- SQL Server Management Studio (SSMS)

## CÁC BƯỚC THỰC HIỆN

### Bước 1 – Mở Project
1. Giải nén file ZIP
2. Mở file `QuanLyBanHang.sln` bằng Visual Studio 2022

### Bước 2 – Kiểm tra chuỗi kết nối
Mở file `App.config`, kiểm tra dòng:
```
Server=.\SQLEXPRESS;Database=QLBH;...
```
Nếu SQL Server của bạn có tên khác (ví dụ: `MSSQLSERVER`), đổi thành:
```
Server=.;Database=QLBH;...
```

### Bước 3 – Cài NuGet Packages
Mở **Package Manager Console** (Tools → NuGet Package Manager → Package Manager Console) và chạy lần lượt:
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package BCrypt.Net-Next
Install-Package ClosedXML
Install-Package Microsoft.VisualBasic
```

### Bước 4 – Tạo CSDL bằng Migration
Trong **Package Manager Console**:
```
Add-Migration KhoiTaoCSDL
Update-Database
```

### Bước 5 – Nhập dữ liệu mẫu (Buổi 3, 4)
Mở SSMS → kết nối SQL Server → chạy file `QLBH.sql` do giáo viên cung cấp.

### Bước 6 – Chạy ứng dụng
Nhấn **F5** hoặc **Ctrl+F5** để chạy.

---

## CẤU TRÚC PROJECT
```
QuanLyBanHang/
├── Data/
│   ├── LoaiSanPham.cs
│   ├── HangSanXuat.cs
│   ├── SanPham.cs          (+ DanhSachSanPham)
│   ├── NhanVien.cs
│   ├── KhachHang.cs
│   ├── HoaDon.cs           (+ DanhSachHoaDon)
│   ├── HoaDon_ChiTiet.cs   (+ DanhSachHoaDon_ChiTiet)
│   └── QLBHDbContext.cs
├── Forms/
│   ├── frmLoaiSanPham.cs / .Designer.cs    ← Buổi 1 + Nhập/Xuất Excel
│   ├── frmHangSanXuat.cs / .Designer.cs    ← Buổi 1 + Nhập/Xuất Excel
│   ├── frmKhachHang.cs / .Designer.cs      ← Buổi 2 + Nhập/Xuất Excel
│   ├── frmNhanVien.cs / .Designer.cs       ← Buổi 2 + Nhập/Xuất Excel
│   ├── frmSanPham.cs / .Designer.cs        ← Buổi 3 + Nhập/Xuất Excel
│   ├── frmHoaDon.cs / .Designer.cs         ← Buổi 4 + Xuất Excel
│   └── frmHoaDon_ChiTiet.cs / .Designer.cs ← Buổi 4
├── Images/                                 ← Thư mục chứa hình ảnh sản phẩm
├── frmMain.cs / .Designer.cs               ← Menu chính (7 chức năng)
├── Program.cs
├── App.config
└── QuanLyBanHang.csproj
```

## TÍNH NĂNG ĐÃ HOÀN THÀNH
| Form | CRUD | Tìm kiếm | Nhập Excel | Xuất Excel |
|------|------|----------|------------|------------|
| Loại sản phẩm | ✅ | - | ✅ | ✅ |
| Hãng sản xuất | ✅ | - | ✅ | ✅ |
| Khách hàng | ✅ | ✅ | ✅ | ✅ |
| Nhân viên | ✅ | ✅ | ✅ | ✅ |
| Sản phẩm | ✅ | ✅ | ✅ | ✅ |
| Hóa đơn | ✅ | ✅ | - | ✅ (2 sheet) |
| Hóa đơn chi tiết | ✅ | - | - | - |

## LƯU Ý
- Thư mục `Images/` phải tồn tại (đã tạo sẵn). Đặt file `no-image.png` vào đây.
- Mật khẩu nhân viên được mã hóa bằng BCrypt.
- Xuất Excel hóa đơn tạo 2 sheet: **HoaDon** và **HoaDon_ChiTiet**.
- File Excel nhập sản phẩm cần có cột: `TenLoai`, `TenHangSanXuat`, `TenSanPham`, `DonGia`, `SoLuong`, `MoTa`.
