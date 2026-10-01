using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    // --- KHAI BÁO DỮ LIỆU ---
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";
    }

    public class DuLieu
    {
        public static List<MonHoc> DS_Mon() => new List<MonHoc>
        {
            new MonHoc { MaMon = "HP21", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP22", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
            new MonHoc { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
            new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
            new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
            new MonHoc { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
            // Môn XYZ không có hệ (He = "")
            new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
        }; // Tôi rút gọn danh sách để dễ nhìn kết quả chạy Console hơn

        public static List<He> DS_He() => new List<He>
        {
            new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
            new He { MaHe = "CD",  TenHe = "Chuyên đề" },
            new He { MaHe = "OT",  TenHe = "Chứng chỉ quốc tế" } // Hệ này không có môn nào
        };
    }

    // --- XỬ LÝ CHÍNH BÀI 6.2 ---
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bai62();
        }

        static void Bai62()
        {
            List<MonHoc> dsMon = DuLieu.DS_Mon();
            List<He> dsHe = DuLieu.DS_He();

            Console.WriteLine("=== BÀI 6.2: JOIN VÀ CÁC TOÁN TỬ TẬP HỢP ===\n");

            // ---------------------------------------------------------
            // a. Inner Join (Chỉ lấy các phần tử khớp cả 2 bảng)
            // ---------------------------------------------------------
            var innerJoin = dsHe.Join(
                dsMon,
                h => h.MaHe,     // Khóa ngoại của bảng 1
                m => m.He,       // Khóa ngoại của bảng 2
                (h, m) => new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet } // Dữ liệu trả về
            );

            Console.WriteLine("a. Inner Join (Tên hệ, Mã môn, Tên môn):");
            foreach (var item in innerJoin) Console.WriteLine($"- {item.TenHe}: [{item.MaMon}] {item.TenMon}");

            // ---------------------------------------------------------
            // b. Left Outer Join (Lấy cả những hệ CHƯA CÓ môn học)
            // GroupJoin gom các môn theo Hệ. DefaultIfEmpty() trả về mảng có 1 phần tử null nếu Hệ đó trống.
            // ---------------------------------------------------------
            var leftOuterJoin = dsHe.GroupJoin(dsMon, h => h.MaHe, m => m.He, (h, listMon) => new { h, listMon })
                .SelectMany(
                    z => z.listMon.DefaultIfEmpty(),
                    (z, mon) => new {
                        TenHe = z.h.TenHe,
                        // mon có thể null (do DefaultIfEmpty) nên phải kiểm tra
                        MaMon = mon != null ? mon.MaMon : "[None]",
                        TenMon = mon != null ? mon.TenMon : "[Hệ chưa có môn học]"
                    }
                ).ToList(); // Chuyển thành List để tái sử dụng ở câu C và D

            Console.WriteLine("\n------------------\nb. Left Outer Join (Lấy cả Hệ chưa có môn):");
            foreach (var item in leftOuterJoin) Console.WriteLine($"- {item.TenHe}: [{item.MaMon}] {item.TenMon}");

            // ---------------------------------------------------------
            // c. Full Outer Join (Cả Hệ chưa có môn + Môn chưa khai báo Hệ)
            // LINQ không có Full Outer Join trực tiếp. Ta lấy Left Outer Join GỘP (Concat) với Môn không có hệ.
            // ---------------------------------------------------------
            // Lọc ra các môn mà mã Hệ của nó không tồn tại trong danh sách Hệ
            var monKhongHe = dsMon.Where(m => !dsHe.Any(h => h.MaHe == m.He))
                                  .Select(m => new {
                                      TenHe = "[Môn chưa có hệ]",
                                      MaMon = m.MaMon,
                                      TenMon = m.TenMon
                                  }).ToList();

            var fullOuterJoin = leftOuterJoin.Concat(monKhongHe);

            Console.WriteLine("\n------------------\nc. Full Outer Join:");
            foreach (var item in fullOuterJoin) Console.WriteLine($"- {item.TenHe}: [{item.MaMon}] {item.TenMon}");

            // ---------------------------------------------------------
            // d. Chỉ liệt kê hệ chưa có môn + môn chưa có hệ
            // ---------------------------------------------------------
            var heKhongMon = leftOuterJoin.Where(x => x.MaMon == "[None]");
            var saiKhac = heKhongMon.Concat(monKhongHe);

            Console.WriteLine("\n------------------\nd. Các đối tượng chưa được liên kết (Hệ rỗng + Môn rỗng):");
            foreach (var item in saiKhac) Console.WriteLine($"- {item.TenHe}: [{item.MaMon}] {item.TenMon}");

            // ---------------------------------------------------------
            // e. Lấy 5 môn học đầu tiên có số tiết giảm dần (hiển thị Tên hệ, Mã môn...)
            // ---------------------------------------------------------
            var cauE = innerJoin.OrderByDescending(x => x.SoTiet).Take(5);

            Console.WriteLine("\n------------------\ne. Top 5 môn có số tiết cao nhất:");
            foreach (var item in cauE) Console.WriteLine($"- {item.TenHe}: [{item.MaMon}] {item.TenMon} ({item.SoTiet} tiết)");

            // ---------------------------------------------------------
            // f. Tổng số môn học của mỗi hệ
            // ---------------------------------------------------------
            var cauF = dsHe.GroupJoin(dsMon, h => h.MaHe, m => m.He,
                (h, ms) => new { h.MaHe, h.TenHe, TongMon = ms.Count() });

            Console.WriteLine("\n------------------\nf. Tổng số môn học của mỗi hệ:");
            foreach (var item in cauF) Console.WriteLine($"- [{item.MaHe}] {item.TenHe}: {item.TongMon} môn");

            // ---------------------------------------------------------
            // g & h. Distinct và FirstOrDefault
            // ---------------------------------------------------------
            int soLoaiTiet = dsMon.Select(m => m.SoTiet).Distinct().Count();
            Console.WriteLine($"\n------------------\ng. Có {soLoaiTiet} loại số tiết khác nhau.");

            var monDauTien = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"h. Môn đầu tiên bắt đầu bằng 'Lập trình': {(monDauTien != null ? monDauTien.TenMon : "Không tìm thấy")}");

            // ---------------------------------------------------------
            // i. Liệt kê môn theo hệ, có số thứ tự
            // ---------------------------------------------------------
            var cauI = dsHe.GroupJoin(dsMon, h => h.MaHe, m => m.He, (h, listMon) => new { h.TenHe, listMon });

            Console.WriteLine("\n------------------\ni. Danh sách môn học (có số thứ tự):");
            foreach (var he in cauI)
            {
                Console.WriteLine($"\n>> Hệ: {he.TenHe}");
                if (!he.listMon.Any())
                {
                    Console.WriteLine("   (Chưa có môn học nào)");
                    continue;
                }

                int index = 1; // Biến đếm số thứ tự
                foreach (var m in he.listMon)
                {
                    Console.WriteLine($"   {index++}. [{m.MaMon}] {m.TenMon}");
                }
            }
        }
    }
}