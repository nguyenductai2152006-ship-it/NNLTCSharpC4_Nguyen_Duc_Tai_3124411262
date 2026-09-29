using System;

namespace ThucHanh02
{
    // === LỚP PHÂN SỐ (Tái sử dụng bản rút gọn từ Bài 1.4) ===
    class PhanSo
    {
        public int TuSo { get; set; }
        private int mauSo;
        public int MauSo
        {
            get { return mauSo; }
            set
            {
                if (value == 0) mauSo = 1; // Tránh lỗi chia 0
                else mauSo = value;
            }
        }

        public PhanSo()
        {
            TuSo = 0;
            MauSo = 1;
        }

        public PhanSo(int tu, int mau)
        {
            TuSo = tu;
            MauSo = mau;
            RutGon();
        }

        private int TimUCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a == 0 ? 1 : a;
        }

        public void RutGon()
        {
            int ucln = TimUCLN(TuSo, MauSo);
            TuSo /= ucln;
            MauSo /= ucln;
            if (MauSo < 0)
            {
                TuSo = -TuSo;
                MauSo = -MauSo;
            }
        }

        // Đa năng hóa toán tử cộng (+) 2 phân số để tính tổng cho lẹ
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tuMoi = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            int mauMoi = a.MauSo * b.MauSo;
            return new PhanSo(tuMoi, mauMoi);
        }

        public override string ToString()
        {
            if (MauSo == 1) return $"{TuSo}";
            if (TuSo == 0) return "0";
            return $"{TuSo}/{MauSo}";
        }
    }

    // === LỚP DÃY PHÂN SỐ ===
    class DayPhanSo
    {
        // Sử dụng mảng 1 chiều lưu các đối tượng PhanSo
        private PhanSo[] dsPhanSo;
        private int n;

        // Constructor
        public DayPhanSo()
        {
            n = 0;
            dsPhanSo = new PhanSo[0];
        }

        public void Nhap()
        {
            Console.Write("Nhập số lượng phân số (n): ");
            n = int.Parse(Console.ReadLine());

            // Cấp phát mảng
            dsPhanSo = new PhanSo[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhập phân số thứ {i + 1} ---");
                Console.Write("  Tử số: ");
                int tu = int.Parse(Console.ReadLine());
                Console.Write("  Mẫu số: ");
                int mau = int.Parse(Console.ReadLine());

                // Khởi tạo đối tượng phân số và đưa vào mảng
                dsPhanSo[i] = new PhanSo(tu, mau);
            }
        }

        public void Xuat()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{dsPhanSo[i]}");
                // In thêm dấu phẩy ngăn cách, trừ phần tử cuối cùng
                if (i < n - 1) Console.Write(", ");
            }
            Console.WriteLine();
        }

        // Tính tổng tất cả phân số trong dãy
        public PhanSo TinhTong()
        {
            // Bắt đầu với tổng = 0/1
            PhanSo tong = new PhanSo(0, 1);

            for (int i = 0; i < n; i++)
            {
                // Nhờ đã đa năng hóa toán tử +, ta cộng trực tiếp 2 object rất mượt
                tong = tong + dsPhanSo[i];
            }

            return tong;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== NHẬP DÃY PHÂN SỐ =====");
            DayPhanSo dayPS = new DayPhanSo();
            dayPS.Nhap();

            Console.WriteLine("\n===== DÃY PHÂN SỐ VỪA NHẬP =====");
            Console.Write("Các phân số: ");
            dayPS.Xuat();

            Console.WriteLine("\n===== TÍNH TỔNG =====");
            PhanSo tong = dayPS.TinhTong();
            Console.WriteLine($"=> Tổng của dãy phân số trên là: {tong}");

            Console.ReadLine();
        }
    }
}