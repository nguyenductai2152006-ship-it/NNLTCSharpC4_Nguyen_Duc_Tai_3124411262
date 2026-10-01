using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bai31();
        }

        static void Bai31()
        {
            // Khởi tạo mảng số theo đề bài
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            Console.WriteLine("=== BÀI 3.1: THỐNG KÊ MẢNG SỐ ===");
            Console.WriteLine("Mảng gốc: " + string.Join(", ", mangSo));

            // ---------------------------------------------------------
            // a. Thống kê số lượng: tổng số, chẵn, lẻ
            // Dùng Count() để đếm. Có thể truyền Lambda vào Count để đếm theo điều kiện.
            // ---------------------------------------------------------
            int tongSoPhanTu = mangSo.Count();
            int soPhanTuChan = mangSo.Count(x => x % 2 == 0);
            int soPhanTuLe = mangSo.Count(x => x % 2 != 0); // Hoặc: tongSoPhanTu - soPhanTuChan

            Console.WriteLine("\na. Thống kê số lượng:");
            Console.WriteLine($"- Tổng số phần tử: {tongSoPhanTu}");
            Console.WriteLine($"- Số phần tử chẵn: {soPhanTuChan}");
            Console.WriteLine($"- Số phần tử lẻ: {soPhanTuLe}");

            // ---------------------------------------------------------
            // b. Thống kê giá trị: tổng, max, min
            // ---------------------------------------------------------
            int tongGiaTri = mangSo.Sum();
            int giaTriMax = mangSo.Max();
            int giaTriMin = mangSo.Min();

            Console.WriteLine("\nb. Thống kê giá trị:");
            Console.WriteLine($"- Tổng các giá trị: {tongGiaTri}");
            Console.WriteLine($"- Giá trị lớn nhất: {giaTriMax}");
            Console.WriteLine($"- Giá trị nhỏ nhất: {giaTriMin}");

            // ---------------------------------------------------------
            // c. Cho biết có bao nhiêu giá trị khác nhau trong mảng
            // Dùng Distinct() để loại bỏ các phần tử trùng lặp trước, sau đó mới Count().
            // ---------------------------------------------------------
            int soGiaTriKhacNhau = mangSo.Distinct().Count();
            Console.WriteLine($"\nc. Số lượng giá trị khác nhau trong mảng: {soGiaTriKhacNhau}");

            // ---------------------------------------------------------
            // d. Phân nhóm các phần tử theo số dư khi chia cho 5
            // GroupBy tạo ra các nhóm. Mỗi nhóm sẽ có 1 thuộc tính Key (chính là số dư)
            // ---------------------------------------------------------
            var nhomTheoSoDu = mangSo.GroupBy(x => x % 5);

            Console.WriteLine("\nd. Phân nhóm các phần tử theo số dư khi chia cho 5:");
            foreach (var nhom in nhomTheoSoDu)
            {
                // nhom.Key chứa giá trị của điều kiện GroupBy (ở đây là số dư 0, 1, 2, 3, hoặc 4)
                // Bản thân biến "nhom" là một danh sách chứa các phần tử thuộc nhóm đó
                Console.WriteLine($"- Nhóm dư {nhom.Key}: {string.Join(", ", nhom)}");
            }
        }
    }
}