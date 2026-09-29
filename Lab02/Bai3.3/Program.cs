using System;

namespace ThucHanh02
{
    // Lớp SinhVien bình thường, KHÔNG CẦN kế thừa Interface IComparable nữa
    // Vì luật so sánh sẽ được tách ra ngoài nhờ Delegate
    class SinhVien
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
    }

    // 1. Khai báo một Delegate tổng quát (Generic Delegate)
    // Nó đại diện cho TẤT CẢ CÁC HÀM có 2 tham số kiểu T và trả về số nguyên (int)
    public delegate int SoSanhDelegate<T>(T a, T b);

    class TienIch
    {
        // 2. Hàm sắp xếp nhận vào một mảng và một ĐẠI DIỆN HÀM (delegate)
        public static void Sort<T>(T[] arr, SoSanhDelegate<T> hamSoSanh)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    // Thay vì gọi arr[i].CompareTo, ta gọi cái hàm được truyền vào
                    // Nếu hàm này trả về > 0, tức là phần tử i lớn hơn j -> Hoán vị
                    if (hamSoSanh(arr[i], arr[j]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }

    class Program
    {
        // --- 3. Định nghĩa các hàm so sánh cụ thể (Khớp với khuôn mẫu của Delegate) ---

        // Hàm so sánh Điểm Tăng Dần
        static int DiemTangDan(SinhVien sv1, SinhVien sv2)
        {
            return sv1.Diem.CompareTo(sv2.Diem);
        }

        // Hàm so sánh Điểm Giảm Dần
        static int DiemGiamDan(SinhVien sv1, SinhVien sv2)
        {
            return sv2.Diem.CompareTo(sv1.Diem); // Đảo ngược lại sv2 so với sv1
        }

        static string LayTen(string hoTen)
        {
            hoTen = hoTen.Trim(); // Xóa khoảng trắng 2 đầu để tránh lỗi
            int viTriKhoangTrangCuoi = hoTen.LastIndexOf(' ');

            // Nếu không tìm thấy khoảng trắng (tên chỉ có 1 chữ), trả về nguyên chuỗi
            if (viTriKhoangTrangCuoi == -1) return hoTen;

            // Cắt từ vị trí sau khoảng trắng cuối cùng cho đến hết chuỗi
            return hoTen.Substring(viTriKhoangTrangCuoi + 1);
        }

        // Hàm so sánh theo Tên (Theo bảng chữ cái)
        static int TenTangDan(SinhVien sv1, SinhVien sv2)
        {
            string ten1 = LayTen(sv1.HoTen);
            string ten2 = LayTen(sv2.HoTen);

            int ketQua = ten1.CompareTo(ten2);

            // Nếu trùng tên nhau, ta so sánh lại bằng toàn bộ chuỗi Họ Tên để xếp theo Họ
            if (ketQua == 0)
            {
                return sv1.HoTen.CompareTo(sv2.HoTen);
            }

            return ketQua;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SinhVien[] dsSV = new SinhVien[]
            {
                new SinhVien("Trần Tài", 7.5),
                new SinhVien("Lê Sếp", 9.0),
                new SinhVien("Nguyễn Lười", 4.0),
                new SinhVien("Phạm Khá", 8.0)
            };

            Console.WriteLine("===== DANH SÁCH BAN ĐẦU =====");
            InDanhSach(dsSV);

            // Test 1: Sắp xếp điểm Tăng Dần
            // Mình truyền trực tiếp tên hàm "DiemTangDan" vào trong hàm Sort
            Console.WriteLine("\n===== SẮP XẾP ĐIỂM TĂNG DẦN =====");
            TienIch.Sort(dsSV, DiemTangDan);
            InDanhSach(dsSV);

            // Test 2: Sắp xếp điểm Giảm Dần
            Console.WriteLine("\n===== SẮP XẾP ĐIỂM GIẢM DẦN =====");
            TienIch.Sort(dsSV, DiemGiamDan);
            InDanhSach(dsSV);

            // Test 3: Sắp xếp theo Tên chữ cái
            Console.WriteLine("\n===== SẮP XẾP THEO TÊN (A -> Z) =====");
            TienIch.Sort(dsSV, TenTangDan);
            InDanhSach(dsSV);

            Console.ReadLine();
        }

        static void InDanhSach(SinhVien[] ds)
        {
            foreach (SinhVien sv in ds)
            {
                Console.WriteLine(sv.ToString());
            }
        }
    }
}