using System;
using System.Collections.Generic;

namespace ThucHanh02
{
    // === 1. LỚP CHA TỔNG QUÁT ===
    abstract class ThiSinh
    {
        public string SBD { get; set; }
        public string HoTen { get; set; }
        public double Bai1 { get; set; }
        public double Bai2 { get; set; }
        public double Bai3 { get; set; }

        // Cung cấp một Property chỉ đọc (Read-only) cho Tổng điểm
        // Lớp con sẽ chịu trách nhiệm định nghĩa cách tính
        public abstract double TongDiem { get; }

        public virtual void Nhap()
        {
            Console.Write("  Nhập Số báo danh: ");
            SBD = Console.ReadLine();
            Console.Write("  Nhập Họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("  Nhập điểm Bài 1: ");
            Bai1 = double.Parse(Console.ReadLine());
            Console.Write("  Nhập điểm Bài 2: ");
            Bai2 = double.Parse(Console.ReadLine());
            Console.Write("  Nhập điểm Bài 3: ");
            Bai3 = double.Parse(Console.ReadLine());
        }

        public virtual void Xuat()
        {
            Console.Write($"[{SBD}] {HoTen} | B1: {Bai1}, B2: {Bai2}, B3: {Bai3} | ");
        }
    }

    // === 2. LỚP THÍ SINH CHUYÊN ===
    class ThiSinhChuyen : ThiSinh
    {
        public double TiengAnh { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("  Nhập điểm Tiếng Anh: ");
            TiengAnh = double.Parse(Console.ReadLine());
        }

        // Ghi đè Property TongDiem để tính theo luật của thí sinh Chuyên
        public override double TongDiem
        {
            get
            {
                double tong = Bai1 + Bai2 + Bai3;
                double thuong = 0;

                // Xét điểm thưởng Tiếng Anh
                if (TiengAnh >= 9 && TiengAnh <= 10)
                {
                    thuong = 2;
                }
                else if (TiengAnh >= 7 && TiengAnh <= 8)
                {
                    thuong = 1;
                }

                return tong + thuong;
            }
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Anh: {TiengAnh} -> Tổng điểm: {TongDiem} (Đ.tượng: Chuyên)");
        }
    }

    // === 3. LỚP THÍ SINH SIÊU CÚP ===
    class ThiSinhSieuCup : ThiSinh
    {
        public double CSDL { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("  Nhập điểm CSDL: ");
            CSDL = double.Parse(Console.ReadLine());
        }

        // Ghi đè Property TongDiem để tính theo luật của thí sinh Siêu cúp
        public override double TongDiem
        {
            get
            {
                // Tổng điểm của 4 bài thi
                return Bai1 + Bai2 + Bai3 + CSDL;
            }
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"CSDL: {CSDL} -> Tổng điểm: {TongDiem} (Đ.tượng: Siêu Cúp)");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<ThiSinh> danhSachTS = new List<ThiSinh>();

            Console.WriteLine("===== QUẢN LÝ ĐIỂM THI CUỘC THI TIN HỌC =====");
            Console.Write("Nhập số lượng thí sinh tham gia: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin thí sinh thứ {i + 1} ---");
                Console.Write("Chọn đối tượng (1 - Chuyên, 2 - Siêu cúp): ");
                int loai = int.Parse(Console.ReadLine());

                ThiSinh ts = null;
                if (loai == 1)
                {
                    ts = new ThiSinhChuyen();
                }
                else if (loai == 2)
                {
                    ts = new ThiSinhSieuCup();
                }
                else
                {
                    Console.WriteLine("Nhập sai! Tự động chọn đối tượng Chuyên.");
                    ts = new ThiSinhChuyen();
                }

                ts.Nhap();
                danhSachTS.Add(ts);
            }

            Console.WriteLine("\n===== KẾT QUẢ CUỘC THI =====");
            foreach (ThiSinh ts in danhSachTS)
            {
                // Nhờ Đa hình, hàm Xuat() sẽ in đúng thông tin và cách tính điểm riêng của từng loại
                ts.Xuat();
            }

            Console.ReadLine();
        }
    }
}