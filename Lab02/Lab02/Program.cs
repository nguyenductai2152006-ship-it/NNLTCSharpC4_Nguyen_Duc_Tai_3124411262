using System;

namespace ThucHanh02
{
    // Tạo lớp SinhVien để quản lý thông tin và hành vi của đối tượng sinh viên
    class SinhVien
    {
        // Sử dụng Property (thuộc tính) để lưu trữ dữ liệu
        public string HoTen { get; set; }
        public int NamSinh { get; set; }

        // Phương thức nhập thông tin
        public void Nhap()
        {
            Console.Write("Nhập họ tên sinh viên: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhập năm sinh: ");
            // Đọc dữ liệu từ bàn phím (chuỗi) và ép kiểu sang số nguyên (int)
            NamSinh = int.Parse(Console.ReadLine());
        }

        // Phương thức tính tuổi
        public int TinhTuoi()
        {
            // Lấy năm hiện tại từ hệ thống để tính tuổi chính xác theo thời gian thực
            int namHienTai = DateTime.Now.Year;
            return namHienTai - NamSinh;
        }

        // Phương thức xuất thông tin
        public void Xuat()
        {
            // Gọi phương thức TinhTuoi() ngay bên trong lệnh in để xuất kết quả
            Console.WriteLine($"\n--- THÔNG TIN SINH VIÊN ---");
            Console.WriteLine($"Họ và tên: {HoTen}");
            Console.WriteLine($"Năm sinh: {NamSinh}");
            Console.WriteLine($"Tuổi hiện tại: {TinhTuoi()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Hỗ trợ in tiếng Việt có dấu

            // Khởi tạo đối tượng sv từ lớp SinhVien
            SinhVien sv = new SinhVien();

            // Lần lượt gọi các phương thức để thực thi
            sv.Nhap();
            sv.Xuat();

            Console.ReadLine(); // Dừng màn hình để xem kết quả
        }
    }
}