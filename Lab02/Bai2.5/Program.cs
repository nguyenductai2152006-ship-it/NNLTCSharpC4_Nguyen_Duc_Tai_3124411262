
using System;

namespace ThucHanh02
{
    // === LỚP NHÂN VIÊN ===
    class NhanVien
    {
        // 1. Properties tự động
        public string HoTen { get; set; }
        public double MucLuong { get; set; }
        public int SoNgayVang { get; set; }

        // 2. Constructor
        public NhanVien()
        {
            HoTen = "Chưa có tên";
            MucLuong = 0;
            SoNgayVang = 0;
        }

        // 3. Nhập thông tin nhân viên
        public void Nhap()
        {
            Console.Write("  Nhập họ tên: ");
            HoTen = Console.ReadLine();

            Console.Write("  Nhập mức lương cơ bản (VNĐ): ");
            MucLuong = double.Parse(Console.ReadLine());

            Console.Write("  Nhập số ngày vắng: ");
            SoNgayVang = int.Parse(Console.ReadLine());
        }

        // 4. Tính lương thực nhận
        public double TinhLuong()
        {
            // Theo đề bài: trừ 100.000 VNĐ cho mỗi ngày vắng
            double tienPhat = SoNgayVang * 100000;
            double luongThucNhan = MucLuong - tienPhat;

            // Đề phòng trường hợp vắng quá nhiều, tiền phạt lớn hơn cả lương
            // Lương không thể âm, nên nếu âm thì gán bằng 0
            if (luongThucNhan < 0)
            {
                return 0;
            }
            return luongThucNhan;
        }

        // 5. Xuất thông tin
        public void Xuat()
        {
            Console.WriteLine($"  Họ tên: {HoTen} | Lương cơ bản: {MucLuong:N0} | Vắng: {SoNgayVang} ngày | Lương nhận: {TinhLuong():N0} VNĐ");
        }
    }

    // === LỚP PHÒNG BAN QUẢN LÝ DANH SÁCH NHÂN VIÊN ===
    class PhongBan
    {
        private NhanVien[] dsNhanVien;
        private int n;

        // Nhập danh sách phòng ban
        public void Nhap()
        {
            Console.Write("Nhập số lượng nhân viên trong phòng ban: ");
            n = int.Parse(Console.ReadLine());

            dsNhanVien = new NhanVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin nhân viên thứ {i + 1} ---");
                dsNhanVien[i] = new NhanVien();
                dsNhanVien[i].Nhap();
            }
        }

        // Xuất danh sách nhân viên
        public void Xuat()
        {
            Console.WriteLine("\n--- DANH SÁCH NHÂN VIÊN PHÒNG BAN ---");
            for (int i = 0; i < n; i++)
            {
                dsNhanVien[i].Xuat();
            }
        }

        // Tính tổng lương cả phòng ban
        public double TongLuongPhongBan()
        {
            double tong = 0;
            for (int i = 0; i < n; i++)
            {
                tong += dsNhanVien[i].TinhLuong();
            }
            return tong;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== PHẦN MỀM TÍNH LƯƠNG =====");
            PhongBan pb = new PhongBan();

            // Nhập dữ liệu
            pb.Nhap();

            // In danh sách chi tiết
            pb.Xuat();

            // Tính và in tổng lương
            double tongQuyLuong = pb.TongLuongPhongBan();
            Console.WriteLine("\n=============================================");
            Console.WriteLine($"TỔNG QUỸ LƯƠNG CỦA PHÒNG BAN: {tongQuyLuong:N0} VNĐ");
            Console.WriteLine("=============================================");

            Console.ReadLine();
        }
    }
}