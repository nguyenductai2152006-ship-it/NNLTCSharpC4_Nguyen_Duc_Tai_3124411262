using System;

namespace ThucHanh02
{
    // === LỚP ĐƠN THỨC (Tái sử dụng phiên bản rút gọn từ Bài 1.5) ===
    class DonThuc
    {
        public double HeSo { get; set; }
        public int SoMu { get; set; }

        public DonThuc(double heSo, int soMu)
        {
            HeSo = heSo;
            SoMu = soMu;
        }

        public double TinhGiaTri(double x)
        {
            return HeSo * Math.Pow(x, SoMu);
        }
    }

    // === LỚP ĐA THỨC CHỨA MẢNG N+1 ĐƠN THỨC ===
    class DaThuc
    {
        // 1. Fields
        private int n; // Bậc của đa thức
        private DonThuc[] dsDonThuc; // Mảng lưu trữ n+1 đơn thức

        // 2. Constructors
        // Constructor mặc định (Đa thức bậc 0: P(x) = 0)
        public DaThuc()
        {
            n = 0;
            dsDonThuc = new DonThuc[1];
            dsDonThuc[0] = new DonThuc(0, 0);
        }

        // Constructor có tham số (Tạo mảng chứa n+1 phần tử)
        public DaThuc(int bac)
        {
            n = bac;
            dsDonThuc = new DonThuc[n + 1];
        }

        // 3. Indexer để truy cập đơn thức thứ i
        public DonThuc this[int i]
        {
            get { return dsDonThuc[i]; }
            set { dsDonThuc[i] = value; }
        }

        // 4. Nhập đa thức
        public void Nhap()
        {
            Console.Write("Nhập bậc của đa thức (n): ");
            n = int.Parse(Console.ReadLine());

            // Cấp phát mảng kích thước n+1 (từ bậc 0 đến bậc n)
            dsDonThuc = new DonThuc[n + 1];

            Console.WriteLine("--- Nhập các hệ số ---");
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"Nhập hệ số a[{i}] (cho đơn thức bậc {i}): ");
                double a = double.Parse(Console.ReadLine());

                // Khởi tạo đơn thức thứ i với hệ số a và số mũ i
                dsDonThuc[i] = new DonThuc(a, i);
            }
        }

        // 5. Xuất đa thức ra màn hình
        public void Xuat()
        {
            bool tatCaBang0 = true; // Cờ kiểm tra trường hợp toàn hệ số 0

            for (int i = 0; i <= n; i++)
            {
                double heSo = dsDonThuc[i].HeSo;

                if (heSo == 0) continue; // Bỏ qua các hệ số bằng 0

                tatCaBang0 = false; // Đã có ít nhất 1 hệ số khác 0

                // Xử lý dấu cộng/trừ cho đẹp
                if (heSo > 0 && i > 0) Console.Write(" + ");
                if (heSo < 0) Console.Write(" - ");

                // Lấy trị tuyệt đối để in chung với dấu đã xét ở trên
                double val = Math.Abs(heSo);

                // Format biểu thức
                if (i == 0) Console.Write($"{val}");
                else if (i == 1) Console.Write($"{val}*x");
                else Console.Write($"{val}*x^{i}");
            }

            if (tatCaBang0)
            {
                Console.Write("0");
            }
            Console.WriteLine();
        }

        // 6. Tính giá trị đa thức với giá trị x
        public double TinhGiaTri(double x)
        {
            double tong = 0;
            // Duyệt qua tất cả đơn thức, gọi hàm TinhGiaTri của từng cái rồi cộng dồn
            for (int i = 0; i <= n; i++)
            {
                tong += dsDonThuc[i].TinhGiaTri(x);
            }
            return tong;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== KHỞI TẠO VÀ NHẬP ĐA THỨC =====");
            DaThuc P = new DaThuc();
            P.Nhap();

            Console.Write("\nĐa thức P(x) = ");
            P.Xuat();

            Console.WriteLine("\n===== TÍNH GIÁ TRỊ ĐA THỨC =====");
            Console.Write("Nhập giá trị x cần tính: ");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine($"=> Kết quả P({x}) = {P.TinhGiaTri(x)}");

            Console.WriteLine("\n===== TEST INDEXER =====");
            // Test lấy ra đơn thức bậc 1 (nếu có)
            if (P[0] != null)
            {
                Console.WriteLine($"Hệ số của đơn thức bậc 0 (a[0]) là: {P[0].HeSo}");
            }

            Console.ReadLine();
        }
    }
}