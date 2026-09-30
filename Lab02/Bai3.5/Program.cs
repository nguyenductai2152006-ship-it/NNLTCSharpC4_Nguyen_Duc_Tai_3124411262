using System;
using System.Collections.Generic;

namespace ThucHanh02
{
    // === 1. LỚP CHA TỔNG QUÁT (Lớp trừu tượng) ===
    // Dùng abstract vì hàm TinhLuong không thể định nghĩa ở lớp cha (mỗi loại nhân viên tính một kiểu)
    abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }

        // Hàm nhập thông tin chung có từ khóa virtual để lớp con có thể mở rộng
        public virtual void Nhap()
        {
            Console.Write("  Nhập Mã NV: ");
            MaNV = Console.ReadLine();
            Console.Write("  Nhập Họ tên: ");
            HoTen = Console.ReadLine();
        }

        // Hàm xuất thông tin chung
        public virtual void Xuat()
        {
            Console.Write($"[{MaNV}] {HoTen} | ");
        }

        // Phương thức trừu tượng tính lương (Bắt buộc các lớp con phải viết code cho hàm này)
        public abstract double TinhLuong();
    }

    // === 2. LỚP NHÂN VIÊN KINH DOANH (Kế thừa từ NhanVien) ===
    class NhanVienKinhDoanh : NhanVien
    {
        public double LuongCoBan { get; set; }
        public int SoHopDong { get; set; }

        public override void Nhap()
        {
            base.Nhap(); // Gọi lại hàm Nhap() của lớp cha để lấy Mã NV và Họ tên

            Console.Write("  Nhập lương cơ bản: ");
            LuongCoBan = double.Parse(Console.ReadLine());

            Console.Write("  Nhập số hợp đồng ký được: ");
            SoHopDong = int.Parse(Console.ReadLine());
        }

        // Ghi đè hàm tính lương theo công thức của NVKD
        public override double TinhLuong()
        {
            return LuongCoBan + (SoHopDong * 500000);
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Loại: Kinh Doanh | Hợp đồng: {SoHopDong} | Lương: {TinhLuong():N0} VNĐ");
        }
    }

    // === 3. LỚP NHÂN VIÊN SẢN XUẤT (Kế thừa từ NhanVien) ===
    class NhanVienSanXuat : NhanVien
    {
        public int SoSanPham { get; set; }

        public override void Nhap()
        {
            base.Nhap(); // Kế thừa việc nhập thông tin cơ bản

            Console.Write("  Nhập số lượng sản phẩm: ");
            SoSanPham = int.Parse(Console.ReadLine());
        }

        // Ghi đè hàm tính lương theo công thức của NVSX
        public override double TinhLuong()
        {
            double luong = SoSanPham * 1000;

            // Nếu làm trên 3000 sản phẩm thì được thưởng 5%
            if (SoSanPham > 3000)
            {
                luong += luong * 0.05; // Cộng thêm 5% của chính mức lương đó
            }
            return luong;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Loại: Sản Xuất | Sản phẩm: {SoSanPham} | Lương: {TinhLuong():N0} VNĐ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Dùng List<NhanVien> chứa được cả NVKD và NVSX nhờ tính chất Đa hình (Polymorphism)
            List<NhanVien> dsNhanVien = new List<NhanVien>();

            Console.Write("Nhập số lượng nhân viên cần quản lý: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin nhân viên thứ {i + 1} ---");
                Console.Write("Chọn loại nhân viên (1 - Kinh Doanh, 2 - Sản Xuất): ");
                int loai = int.Parse(Console.ReadLine());

                NhanVien nv = null; // Khởi tạo một tham chiếu từ lớp cha

                if (loai == 1)
                {
                    nv = new NhanVienKinhDoanh(); // Cấp phát vùng nhớ của lớp con
                }
                else if (loai == 2)
                {
                    nv = new NhanVienSanXuat();
                }
                else
                {
                    Console.WriteLine("Nhập sai loại! Mặc định chọn Nhân viên Sản xuất.");
                    nv = new NhanVienSanXuat();
                }

                nv.Nhap(); // Sẽ tự động gọi hàm Nhap() của đúng loại nhân viên vừa khởi tạo
                dsNhanVien.Add(nv);
            }

            Console.WriteLine("\n===== BẢNG LƯƠNG NHÂN VIÊN =====");
            double tongLuong = 0;

            foreach (NhanVien nv in dsNhanVien)
            {
                nv.Xuat(); // Đa hình: Tự động gọi Xuat() của NVKD hoặc NVSX
                tongLuong += nv.TinhLuong();
            }

            Console.WriteLine("================================");
            Console.WriteLine($"TỔNG LƯƠNG PHẢI TRẢ: {tongLuong:N0} VNĐ");

            Console.ReadLine();
        }
    }
}