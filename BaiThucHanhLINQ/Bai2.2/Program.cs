using System;
using System.Linq; // Thư viện để dùng LINQ (Where, Select, OrderBy,...)

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main()
        {
            // Hỗ trợ hiển thị tiếng Việt có dấu trên cửa sổ Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Bai22();
        }

        static void Bai22()
        {
            // Khởi tạo mảng chuỗi
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga",
                                   "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            Console.WriteLine("=== BÀI 2.2: TRUY VẤN MẢNG CHUỖI ===");
            Console.WriteLine("Mảng gốc: " + string.Join(", ", mangChuoi));

            // ---------------------------------------------------------
            // a. Phần tử có 4 ký tự và sắp xếp tăng dần theo ký tự đầu tiên
            // Sử dụng Where để lọc và OrderBy để sắp xếp
            // ---------------------------------------------------------
            var cauA = mangChuoi.Where(s => s.Length == 4)
                                .OrderBy(s => s[0]);

            Console.WriteLine("\na. Các phần tử có 4 ký tự (sắp xếp tăng dần):");
            Console.WriteLine(string.Join(", ", cauA));

            // ---------------------------------------------------------
            // b. Biến đổi mỗi phần tử thành dạng: <chữ thường> - <CHỮ HOA>
            // Sử dụng Select để biến đổi dữ liệu, ToLower() và ToUpper() để đổi kiểu chữ
            // ---------------------------------------------------------
            var cauB = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");

            Console.WriteLine("\nb. Biến đổi <chữ thường> - <CHỮ HOA>:");
            foreach (var item in cauB)
            {
                Console.WriteLine(item); // In từng dòng cho dễ nhìn
            }

            // ---------------------------------------------------------
            // c. Liệt kê các phần tử có chứa ký tự "u" (bao gồm cả "ú", "u")
            // ---------------------------------------------------------
            var cauC = mangChuoi.Where(s => s.Contains("u") || s.Contains("ú"));

            Console.WriteLine("\nc. Các phần tử có chứa ký tự 'u' hoặc 'ú':");
            Console.WriteLine(string.Join(", ", cauC));

            // ---------------------------------------------------------
            // d. Chọn các phần tử bắt đầu bằng chữ in hoa
            // Dùng char.IsUpper() kiểm tra ký tự đầu s[0]. Cần check s.Length > 0 trước.
            // ---------------------------------------------------------
            var cauD = mangChuoi.Where(s => s.Length > 0 && char.IsUpper(s[0]));

            Console.WriteLine("\nd. Các từ bắt đầu bằng chữ in hoa:");
            // Nối bằng dấu cách (space) để tạo thành câu theo yêu cầu đề bài
            Console.WriteLine(string.Join(" ", cauD));
        }
    }
}