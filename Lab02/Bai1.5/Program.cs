using System;

namespace ThucHanh02
{
    // Tạo lớp DonThuc để xử lý biểu thức dạng a*x^n
    class DonThuc
    {
        // Property tự động (gọn hơn xài Field private)
        public double HeSo { get; set; } // a
        public int SoMu { get; set; }    // n

        // Constructor mặc định (khởi tạo bằng 0 cho an toàn)
        public DonThuc()
        {
            HeSo = 0;
            SoMu = 0;
        }

        // Constructor có tham số (cái này xíu nữa dùng để return kết quả đạo hàm cho lẹ)
        public DonThuc(double a, int n)
        {
            HeSo = a;
            SoMu = (n >= 0) ? n : 0; // Tránh tình trạng gán mũ âm
        }

        // Method nhập dữ liệu từ bàn phím
        public void Nhap()
        {
            Console.Write("Nhập hệ số (a): ");
            HeSo = double.Parse(Console.ReadLine());

            // Vòng lặp bẫy lỗi bóp người dùng nhập mũ >= 0 theo đúng đề bài
            do
            {
                Console.Write("Nhập số mũ (n >= 0): ");
                SoMu = int.Parse(Console.ReadLine());

                if (SoMu < 0)
                {
                    Console.WriteLine("-> Lỗi rùi! Số mũ không được âm. Nhập lại nha bạn.");
                }
            } while (SoMu < 0);
        }

        // Method in ra màn hình cho dễ nhìn
        public void Xuat()
        {
            if (HeSo == 0)
                Console.Write("0"); // Hệ số 0 thì nguyên cục bằng 0
            else if (SoMu == 0)
                Console.Write($"{HeSo}"); // Mũ 0 thì x^0 = 1, in ra mỗi hệ số
            else if (SoMu == 1)
                Console.Write($"{HeSo}*x"); // Mũ 1 thì khỏi ghi ^1
            else
                Console.Write($"{HeSo}*x^{SoMu}"); // Bình thường

            Console.WriteLine();
        }

        // a) Tính giá trị đơn thức với x cho trước
        public double TinhGiaTri(double x)
        {
            // Công thức: a * x^n
            return HeSo * Math.Pow(x, SoMu);
        }

        // b) Tính đạo hàm P'(x) = a*n*x^(n-1)
        public DonThuc DaoHam()
        {
            // Trường hợp hằng số (mũ = 0), đạo hàm của hằng số là 0
            if (SoMu == 0)
            {
                return new DonThuc(0, 0);
            }

            // Khởi tạo một đối tượng DonThuc mới chứa kết quả đạo hàm rồi ném ra ngoài
            return new DonThuc(HeSo * SoMu, SoMu - 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== BÀI TẬP ĐƠN THỨC ===");
            DonThuc P = new DonThuc();
            P.Nhap();

            Console.Write("\nĐơn thức P(x) bạn vừa nhập là: P(x) = ");
            P.Xuat();

            // Test câu (a): Tính giá trị P(x)
            Console.Write("\nNhập một giá trị x để test: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine($"=> Kết quả P({x}) = {P.TinhGiaTri(x)}");

            // Test câu (b): Đạo hàm
            // Gọi method DaoHam() nó sẽ quăng về 1 cái DonThuc, mình hứng nó vào biến Q
            DonThuc Q = P.DaoHam();
            Console.Write("\n=> Đạo hàm Q(x) = P'(x) = ");
            Q.Xuat();

            Console.ReadLine(); // Dừng màn hình
        }
    }
}