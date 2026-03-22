using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyBanHang.Data
{
    public class LoaiSanPham
    {
        public int ID { get; set; }
        public string TenLoai { get; set; } = null!;
        public virtual ObservableCollectionListSource<SanPham> SanPham { get; } = new();
    }
}
