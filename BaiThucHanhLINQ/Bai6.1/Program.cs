using System;
using System.Collections.Generic;

namespace BaiThucHanhLINQ
{
    // ---------------------------------------------------------
    // BƯỚC 1: TẠO LỚP He
    // ---------------------------------------------------------
    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";
    }

    // ---------------------------------------------------------
    // BƯỚC 2: TẠO PHƯƠNG THỨC GIẢ LẬP DỮ LIỆU
    // (Tôi tạo một lớp DuLieuHe riêng để chứa danh sách này)
    // ---------------------------------------------------------
    public class DuLieuHe
    {
        public static List<He> DS_He()
        {
            return new List<He>
            {
                new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
                new He { MaHe = "CD",  TenHe = "Chuyên đề" },
                new He { MaHe = "OT",  TenHe = "Chứng chỉ quốc tế" }
            };
        }
    }

    // ---------------------------------------------------------
    // BƯỚC 3: HÀM MAIN KIỂM TRA
    // ---------------------------------------------------------
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bai61();
        }

        static void Bai61()
        {
            Console.WriteLine("=== BÀI 6.1: XÂY DỰNG NGUỒN DỮ LIỆU LỚP HE ===");

            // Lấy danh sách từ class DuLieuHe
            List<He> danhSachHe = DuLieuHe.DS_He();

            Console.WriteLine($"Đã khởi tạo thành công danh sách gồm {danhSachHe.Count} hệ đào tạo.\n");

            Console.WriteLine("Danh sách các Hệ đào tạo:");
            foreach (var h in danhSachHe)
            {
                Console.WriteLine($"- Mã hệ: {h.MaHe,-5} | Tên hệ: {h.TenHe}");
            }
        }
    }
}