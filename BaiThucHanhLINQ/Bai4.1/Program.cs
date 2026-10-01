using System;
using System.Collections.Generic; // Bắt buộc để sử dụng kiểu List<T>

namespace BaiThucHanhLINQ
{
    // ---------------------------------------------------------
    // BƯỚC 1: TẠO LỚP MonHoc
    // ---------------------------------------------------------
    public class MonHoc
    {
        // Khởi tạo giá trị mặc định là chuỗi rỗng "" để tránh cảnh báo (warning) null reference
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        // Kiểu byte (từ 0 đến 255) phù hợp với số tiết (không bao giờ âm và hiếm khi vượt 255)
        public byte SoTiet { get; set; }
    }

    // ---------------------------------------------------------
    // BƯỚC 2: TẠO LỚP DuLieu CHỨA DỮ LIỆU GIẢ LẬP (MOCK DATA)
    // ---------------------------------------------------------
    public class DuLieu
    {
        // Phương thức tĩnh (static) giúp ta gọi trực tiếp DuLieu.DS_Mon() 
        // mà không cần phải dùng từ khóa 'new' tạo object DuLieu.
        public static List<MonHoc> DS_Mon()
        {
            // Sử dụng Cú pháp Khởi tạo Bộ sưu tập (Collection Initializer)
            return new List<MonHoc>
            {
                new MonHoc { MaMon = "HP21", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP22", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP31", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP32", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP41", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP42", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP51", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP52", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
                new MonHoc { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
                new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
                new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
                new MonHoc { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
                new MonHoc { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
                new MonHoc { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
                // Môn XYZ hệ rỗng, số tiết 0 theo đúng bảng dữ liệu đề bài
                new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
            };
        }
    }

    // ---------------------------------------------------------
    // BƯỚC 3: HÀM MAIN VÀ HÀM CHẠY THỬ
    // ---------------------------------------------------------
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bai41();
        }

        static void Bai41()
        {
            Console.WriteLine("=== BÀI 4.1: XÂY DỰNG NGUỒN DỮ LIỆU LỚP MONHOC ===");

            // Lấy danh sách từ class DuLieu
            List<MonHoc> danhSach = DuLieu.DS_Mon();

            Console.WriteLine($"Đã khởi tạo thành công danh sách gồm {danhSach.Count} môn học.\n");

            // In thử 3 môn đầu tiên để kiểm chứng dữ liệu đã load đúng
            Console.WriteLine("In thử 3 môn học đầu tiên để kiểm tra:");
            for (int i = 0; i < 3; i++)
            {
                var m = danhSach[i];
                Console.WriteLine($"- [{m.MaMon}] {m.TenMon} | Hệ: {m.He} | Tiết: {m.SoTiet}");
            }
        }
    }
}