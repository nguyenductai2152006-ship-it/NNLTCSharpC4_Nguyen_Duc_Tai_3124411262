using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bai32();
        }

        static void Bai32()
        {
            // Khởi tạo mảng dữ liệu món ăn
            string[] monAn = {
                "Nước Cà phê", "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào", "Bún riêu",
                "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang"
            };

            Console.WriteLine("=== BÀI 3.2: THỐNG KÊ MẢNG CHUỖI ===");

            // ---------------------------------------------------------
            // a. Tìm các phần tử có chiều dài ngắn nhất và dài nhất
            // Bước 1: Tìm con số độ dài Min/Max. Bước 2: Lọc các món có độ dài bằng con số đó.
            // ---------------------------------------------------------
            int minLen = monAn.Min(x => x.Length);
            int maxLen = monAn.Max(x => x.Length);

            var monNganNhat = monAn.Where(x => x.Length == minLen);
            var monDaiNhat = monAn.Where(x => x.Length == maxLen);

            Console.WriteLine("\na. Các món có tên ngắn nhất và dài nhất:");
            Console.WriteLine($"- Ngắn nhất ({minLen} ký tự): {string.Join(", ", monNganNhat)}");
            Console.WriteLine($"- Dài nhất ({maxLen} ký tự): {string.Join(", ", monDaiNhat)}");

            // ---------------------------------------------------------
            // b. Phân nhóm theo từ đầu tiên của tên món
            // Dùng hàm Split(' ') để cắt chuỗi theo khoảng trắng. 
            // Vị trí [0] chính là từ đầu tiên (VD: "Bún bò" -> "Bún")
            // ---------------------------------------------------------
            var nhomTheoTuDau = monAn.GroupBy(x => x.Split(' ')[0]);

            Console.WriteLine("\nb. Phân nhóm theo từ đầu tiên:");
            foreach (var nhom in nhomTheoTuDau)
            {
                // nhom.Key ở đây chính là từ đầu tiên ("Nước", "Bún", "Bánh",...)
                Console.WriteLine($"- Nhóm '{nhom.Key}': {string.Join(", ", nhom)}");
            }

            // ---------------------------------------------------------
            // c. Đếm số phần tử có từ đầu tiên là "Bánh"
            // Vẫn áp dụng logic Split như câu b, nhưng dùng Count để đếm
            // ---------------------------------------------------------
            int countBanh = monAn.Count(x => x.Split(' ')[0] == "Bánh");
            Console.WriteLine($"\nc. Số lượng món có từ đầu tiên là 'Bánh': {countBanh} món");
        }
    }
}