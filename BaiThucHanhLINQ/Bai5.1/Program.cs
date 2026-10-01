using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    // --- KHAI BÁO CÁC LỚP DỮ LIỆU ĐÃ TẠO TỪ BÀI 4.1 ---
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

    public class DuLieu
    {
        public static List<MonHoc> DS_Mon()
        {
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
                new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
            };
        }
    }

    // --- XỬ LÝ CHÍNH BÀI 5.1 ---
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bai51();
        }

        static void Bai51()
        {
            // Lấy dữ liệu từ class DuLieu
            List<MonHoc> ds = DuLieu.DS_Mon();

            Console.WriteLine("=== BÀI 5.1: TRUY VẤN CƠ BẢN LIST<MONHOC> ===");

            // ---------------------------------------------------------
            // a. Liệt kê tên các môn học bắt đầu bằng "Lập trình"
            // Dùng StartsWith để kiểm tra chuỗi bắt đầu.
            // ---------------------------------------------------------
            var cauA = ds.Where(m => m.TenMon.StartsWith("Lập trình"));

            Console.WriteLine("\na. Các môn học bắt đầu bằng 'Lập trình':");
            foreach (var m in cauA)
            {
                Console.WriteLine($"- {m.TenMon}");
            }

            // ---------------------------------------------------------
            // b. Thuộc hệ "CD", sắp xếp số tiết giảm dần rồi mã môn tăng dần
            // Dùng OrderByDescending cho tiêu chí 1, ThenBy cho tiêu chí 2
            // ---------------------------------------------------------
            var cauB = ds.Where(m => m.He == "CD")
                         .OrderByDescending(m => m.SoTiet)
                         .ThenBy(m => m.MaMon);

            Console.WriteLine("\nb. Các môn hệ CD (Tiết giảm dần -> Mã môn tăng dần):");
            foreach (var m in cauB)
            {
                Console.WriteLine($"- [{m.MaMon}] {m.TenMon} | Số tiết: {m.SoTiet}");
            }

            // ---------------------------------------------------------
            // c. Tên chứa từ "web", CHỈ LẤY Tên môn và Hệ
            // Dùng ToLower() để đưa về chữ thường trước khi Contains("web") giúp không phân biệt hoa/thường.
            // Dùng Select(new { ... }) để tạo Kiểu dữ liệu ẩn danh (Anonymous Type).
            // ---------------------------------------------------------
            var cauC = ds.Where(m => m.TenMon.ToLower().Contains("web"))
                         .Select(m => new {
                             TenMon = m.TenMon,
                             He = m.He
                         });

            Console.WriteLine("\nc. Các môn có tên chứa 'web' (Chỉ lấy Tên môn và Hệ):");
            foreach (var m in cauC)
            {
                // Lúc này đối tượng 'm' chỉ có 2 thuộc tính là TenMon và He.
                Console.WriteLine($"- {m.TenMon} | Hệ: {m.He}");
            }

            // ---------------------------------------------------------
            // d. Thuộc hệ "KTV", sắp xếp tăng dần theo Mã môn
            // ---------------------------------------------------------
            var cauD = ds.Where(m => m.He == "KTV")
                         .OrderBy(m => m.MaMon);

            Console.WriteLine("\nd. Các môn hệ KTV (Mã môn tăng dần):");
            foreach (var m in cauD)
            {
                Console.WriteLine($"- [{m.MaMon}] {m.TenMon} | Hệ: {m.He}");
            }
        }
    }
}