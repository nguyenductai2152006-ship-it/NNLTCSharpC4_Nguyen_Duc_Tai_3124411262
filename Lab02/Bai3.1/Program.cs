using System;

namespace ThucHanh02
{
    // Lớp SinhVien kế thừa (thực thi) Interface IComparable<SinhVien>
    // Bắt buộc phải có cái này thì Array.Sort() mới xài được cho class này
    class SinhVien : IComparable<SinhVien>
    {
        public string HoTen { get; set; }
        public double Diem { get; set; }

        public SinhVien() { }

        public SinhVien(string hoTen, double diem)
        {
            HoTen = hoTen;
            Diem = diem;
        }

        public void Nhap()
        {
            Console.Write("  Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("  Nhập điểm: ");
            Diem = double.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return $"[{HoTen} - Điểm: {Diem}]";
        }

        // Đây là method bắt buộc phải viết khi xài IComparable
        // Array.Sort() sẽ gọi hàm này liên tục để tự động sắp xếp
        public int CompareTo(SinhVien other)
        {
            if (other == null) return 1; // Xử lý an toàn nếu đối tượng kia bị null

            // Tiêu chí sắp xếp: Sắp xếp theo Điểm
            // Để sắp xếp TĂNG DẦN: return this.Diem.CompareTo(other.Diem);
            // Ở đây mình muốn GIẢM DẦN (Điểm cao đứng trước):
            return other.Diem.CompareTo(this.Diem);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Nhập số lượng sinh viên: ");
            int n = int.Parse(Console.ReadLine());

            // Khởi tạo mảng các đối tượng SinhVien
            SinhVien[] dsSinhVien = new SinhVien[n];

            Console.WriteLine("\n===== NHẬP DANH SÁCH =====");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Sinh viên {i + 1} ---");
                dsSinhVien[i] = new SinhVien();
                dsSinhVien[i].Nhap();
            }

            Console.WriteLine("\n===== DANH SÁCH BAN ĐẦU =====");
            InDanhSach(dsSinhVien);

            // Gọi phương thức tĩnh Array.Sort(...)
            // Nó sẽ tự động gọi hàm CompareTo bên trong lớp SinhVien để đổi chỗ
            Array.Sort(dsSinhVien);

            Console.WriteLine("\n===== DANH SÁCH SAU KHI SẮP XẾP (ĐIỂM GIẢM DẦN) =====");
            InDanhSach(dsSinhVien);

            Console.ReadLine();
        }

        // Hàm hỗ trợ in mảng cho lẹ đỡ phải viết for nhiều lần
        static void InDanhSach(SinhVien[] ds)
        {
            foreach (SinhVien sv in ds)
            {
                Console.WriteLine(sv.ToString());
            }
        }
    }
}