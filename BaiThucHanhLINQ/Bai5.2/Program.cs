using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    // --- LỚP DỮ LIỆU ---
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

    // --- XỬ LÝ CHÍNH BÀI 5.2 ---
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bai52();
        }

        static void Bai52()
        {
            List<MonHoc> ds = DuLieu.DS_Mon();
            Console.WriteLine("=== BÀI 5.2: THỐNG KÊ TRÊN LIST<MONHOC> ===\n");

            // a. Tổng số môn hiện có
            Console.WriteLine($"a. Tổng số môn hiện có: {ds.Count}");

            // b. Đếm số môn có tên bắt đầu bằng "Lập trình"
            int countLapTrinh = ds.Count(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"b. Số môn bắt đầu bằng 'Lập trình': {countLapTrinh}");

            // c. Tính tổng số tiết của hệ KTV
            int sumTietKTV = ds.Where(m => m.He == "KTV").Sum(m => m.SoTiet);
            Console.WriteLine($"c. Tổng số tiết hệ KTV: {sumTietKTV}");

            // d. Cho biết tổng số môn của mỗi hệ: Hệ, Tổng số môn
            var cauD = ds.GroupBy(m => m.He)
                         .Select(g => new {
                             He = string.IsNullOrEmpty(g.Key) ? "[Chưa có hệ]" : g.Key,
                             TongMon = g.Count()
                         });
            Console.WriteLine("\nd. Tổng số môn của mỗi hệ:");
            foreach (var item in cauD) Console.WriteLine($"- Hệ: {item.He} | Tổng số môn: {item.TongMon}");

            // e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, sắp xếp giảm dần theo Số tiết
            var cauE = ds.GroupBy(m => m.SoTiet)
                         .Select(g => new { SoTiet = g.Key, TongMon = g.Count() })
                         .OrderByDescending(x => x.SoTiet);
            Console.WriteLine("\ne. Thống kê theo Số tiết (Giảm dần):");
            foreach (var item in cauE) Console.WriteLine($"- Số tiết: {item.SoTiet} | Tổng môn: {item.TongMon}");

            // f. Thông tin môn học có số tiết cao nhất
            int maxTiet = ds.Max(m => m.SoTiet);
            var cauF = ds.Where(m => m.SoTiet == maxTiet);
            Console.WriteLine("\nf. Môn học có số tiết cao nhất:");
            foreach (var m in cauF) Console.WriteLine($"- [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiết)");

            // g. Thống kê theo Hệ: tổng môn, tổng tiết, cao nhất, thấp nhất
            var cauG = ds.GroupBy(m => m.He)
                         .Select(g => new {
                             He = string.IsNullOrEmpty(g.Key) ? "[Chưa có hệ]" : g.Key,
                             TongMon = g.Count(),
                             TongTiet = g.Sum(m => m.SoTiet),
                             MaxTiet = g.Max(m => m.SoTiet),
                             MinTiet = g.Min(m => m.SoTiet)
                         });
            Console.WriteLine("\ng. Thống kê chi tiết theo Hệ:");
            foreach (var item in cauG)
            {
                Console.WriteLine($"- Hệ: {item.He} | Môn: {item.TongMon} | Tổng tiết: {item.TongTiet} | Max: {item.MaxTiet} | Min: {item.MinTiet}");
            }

            // h. Liệt kê các môn học được phân nhóm theo Hệ
            var cauH = ds.GroupBy(m => m.He);
            Console.WriteLine("\nh. Liệt kê môn học phân nhóm theo Hệ:");
            foreach (var nhom in cauH)
            {
                string tenHe = string.IsNullOrEmpty(nhom.Key) ? "[Chưa có hệ]" : nhom.Key;
                Console.WriteLine($"\n--- Hệ: {tenHe} ---");
                foreach (var m in nhom) Console.WriteLine($"  + [{m.MaMon}] {m.TenMon}");
            }

            // i. Liệt kê môn phân nhóm theo Số tiết, tăng dần theo Số tiết
            var cauI = ds.GroupBy(m => m.SoTiet).OrderBy(g => g.Key);
            Console.WriteLine("\n\ni. Phân nhóm theo Số tiết (Tăng dần theo số tiết):");
            foreach (var nhom in cauI)
            {
                Console.WriteLine($"\n--- Số tiết: {nhom.Key} ---");
                foreach (var m in nhom) Console.WriteLine($"  + [{m.MaMon}] {m.TenMon}");
            }

            // j. Với hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn
            // Dùng m.MaMon.Substring(0, 3) để lấy 3 ký tự đầu (ví dụ: HP21 -> HP2)
            var cauJ = ds.Where(m => m.He == "KTV")
                         .OrderBy(m => m.MaMon) // Sắp xếp theo mã môn TRƯỚC khi gộp nhóm
                         .GroupBy(m => m.MaMon.Substring(0, 3));
            Console.WriteLine("\n\nj. Hệ KTV phân nhóm theo học phần (HP2, HP3...):");
            foreach (var nhom in cauJ)
            {
                Console.WriteLine($"\n--- Học phần: {nhom.Key} ---");
                foreach (var m in nhom) Console.WriteLine($"  + [{m.MaMon}] {m.TenMon}");
            }

            // k. Phân nhóm theo Hệ, chỉ lấy môn Số tiết > 40; sắp xếp theo Mã môn
            var cauK = ds.Where(m => m.SoTiet > 40)
                         .OrderBy(m => m.MaMon)
                         .GroupBy(m => m.He);
            Console.WriteLine("\n\nk. Môn > 40 tiết, phân nhóm theo Hệ, sắp xếp Mã môn:");
            foreach (var nhom in cauK)
            {
                Console.WriteLine($"\n--- Hệ: {nhom.Key} ---");
                foreach (var m in nhom) Console.WriteLine($"  + [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiết)");
            }
        }
    }
}