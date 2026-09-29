using System;

namespace ThucHanh02
{
    // 1. Lớp SinhVien thực thi giao diện IComparable
    // Bắt buộc thực thi thì mới có thể "chui" vào cái hàm sắp xếp tổng quát được
    class SinhVien : IComparable
    {
        public string HoTen { get; set; }
        public double Diem { get; set; }

        public SinhVien(string hoTen, double diem)
        {
            HoTen = hoTen;
            Diem = diem;
        }

        public override string ToString()
        {
            return $"[{HoTen} - Điểm: {Diem}]";
        }

        // Định nghĩa luật so sánh cho Sinh viên
        public int CompareTo(object obj)
        {
            // Ép kiểu object về lại SinhVien
            SinhVien other = obj as SinhVien;
            if (other == null) return 1; // Nếu không cùng kiểu thì coi như mình lớn hơn

            // Tiêu chí sắp xếp TĂNG DẦN theo Điểm
            return this.Diem.CompareTo(other.Diem);
        }
    }

    // 2. Lớp tiện ích tự viết để mô phỏng Array.Sort
    class TienIch
    {
        // HÀM MÔ PHỎNG: Nhận vào mảng IComparable[] thay vì một kiểu cụ thể
        // Đây chính là sức mạnh của Đa hình (Polymorphism)
        public static void CustomSort(IComparable[] arr)
        {
            int n = arr.Length;

            // Dùng thuật toán Interchange Sort (Đổi chỗ trực tiếp) cực kỳ quen thuộc
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    // arr[i].CompareTo(arr[j]) > 0 có nghĩa là phần tử trước lớn hơn phần tử sau
                    // Mà mình muốn sắp xếp tăng dần -> Cần hoán vị (Swap)
                    if (arr[i].CompareTo(arr[j]) > 0)
                    {
                        IComparable temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Khởi tạo mảng SinhVien cứng luôn cho lẹ để test thuật toán
            SinhVien[] dsSV = new SinhVien[]
            {
                new SinhVien("Nguyễn Đức Tài", 7.5),
                new SinhVien("Lê Văn Sếp", 9.0),
                new SinhVien("Trần Lười", 4.0),
                new SinhVien("Phạm Khá", 8.0)
            };

            Console.WriteLine("===== DANH SÁCH BAN ĐẦU =====");
            InDanhSach(dsSV);

            // Gọi hàm sắp xếp TỰ VIẾT thay vì dùng Array.Sort()
            // Do SinhVien kế thừa IComparable, nên mảng SinhVien[] tự động ép kiểu thành mảng IComparable[]
            TienIch.CustomSort(dsSV);

            Console.WriteLine("\n===== SAU KHI DÙNG CUSTOM_SORT (TĂNG DẦN) =====");
            InDanhSach(dsSV);

            Console.ReadLine();
        }

        // Hàm in danh sách
        static void InDanhSach(SinhVien[] ds)
        {
            foreach (SinhVien sv in ds)
            {
                Console.WriteLine(sv.ToString());
            }
        }
    }
}