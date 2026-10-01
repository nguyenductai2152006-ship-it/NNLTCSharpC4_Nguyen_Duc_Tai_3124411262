using System;
using System.Linq; // Bắt buộc phải có using System.Linq để dùng các phương thức LINQ

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main()
        {
            // Hỗ trợ in tiếng Việt có dấu ra Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Gọi hàm bài 2.1
            Bai21();
        }

        static void Bai21()
        {
            // Khởi tạo mảng số nguyên như đề bài yêu cầu
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            Console.WriteLine("=== BÀI 2.1: TRUY VẤN MẢNG SỐ NGUYÊN ===");
            Console.WriteLine("Mảng gốc: " + string.Join(", ", mangSo));

            // ---------------------------------------------------------
            // a. Liệt kê các phần tử chia hết cho 4 và 3
            // Sử dụng Method Syntax (Cú pháp phương thức) với hàm Where
            // ---------------------------------------------------------
            var cauA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);

            Console.WriteLine("\na. Các phần tử chia hết cho 4 và 3:");
            // string.Join dùng để nối các phần tử lại thành một chuỗi, cách nhau bởi dấu phẩy
            Console.WriteLine(string.Join(", ", cauA));

            // ---------------------------------------------------------
            // b. Liệt kê các phần tử nhỏ hơn hoặc bằng 3
            // Sử dụng Query Syntax (Cú pháp truy vấn giống SQL)
            // ---------------------------------------------------------
            var cauB = from x in mangSo
                       where x <= 3
                       select x;

            Console.WriteLine("\nb. Các phần tử nhỏ hơn hoặc bằng 3:");
            Console.WriteLine(string.Join(", ", cauB));

            // ---------------------------------------------------------
            // c. Tạo dãy mới: số chẵn chia đôi, số lẻ giữ nguyên
            // Sử dụng Method Syntax với hàm Select (để biến đổi dữ liệu)
            // ---------------------------------------------------------
            // Giải thích toán tử 3 ngôi: (điều kiện) ? (giá trị nếu đúng) : (giá trị nếu sai)
            var cauC = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);

            Console.WriteLine("\nc. Dãy mới (chẵn chia đôi, lẻ giữ nguyên):");
            Console.WriteLine(string.Join(", ", cauC));
        }
    }
}