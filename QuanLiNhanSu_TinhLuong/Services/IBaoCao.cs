namespace QuanLiNhanSu_TinhLuong.Services
{
    // Chữ 'I' đứng đầu là quy ước đặt tên của Interface
    public interface IBaoCao
    {
        // Khai báo 1 hành động chung: Mọi báo cáo đều phải có khả năng "Xuất Báo Cáo"
        // Hàm này sẽ trả về đường dẫn file (string) sau khi xuất xong
        string XuatBaoCao(string tenNhanVien, string thangNam, decimal tongTien);
    }
}