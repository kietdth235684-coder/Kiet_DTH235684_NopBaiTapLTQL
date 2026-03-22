using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyBanHang.Data
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string HoVaTen { get; set; } = null!;
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
    }
}
