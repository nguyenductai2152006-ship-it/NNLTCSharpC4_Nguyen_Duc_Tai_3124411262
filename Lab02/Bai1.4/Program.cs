using System;

namespace ThucHanh02
{
    class PhanSo
    {
        // 1. Fields
        private int tuSo;
        private int mauSo;

        // 2. Properties (Có kiểm tra mẫu số khác 0)
        public int TuSo
        {
            get { return tuSo; }
            set { tuSo = value; }
        }

        public int MauSo
        {
            get { return mauSo; }
            set
            {
                if (value == 0)
                {
                    // Tránh lỗi chia cho 0, tự động gán bằng 1 nếu người dùng nhập 0
                    Console.WriteLine("LỖI: Mẫu số không được bằng 0! Đã tự động gán Mẫu số = 1.");
                    mauSo = 1;
                }
                else
                {
                    mauSo = value;
                }
            }
        }

        // --- HÀM BỔ TRỢ: TÌM UCLN VÀ RÚT GỌN ---
        // Thuật toán Euclid tìm Ước chung lớn nhất để rút gọn phân số
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
            int ucln = TimUCLN(tuSo, mauSo);
            tuSo /= ucln;
            mauSo /= ucln;

            // Xử lý dấu: Nếu mẫu âm thì chuyển dấu lên tử (VD: 1/-2 thành -1/2)
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
        }

        // 3. Constructors
        // Constructor mặc định (0/1)
        public PhanSo()
        {
            tuSo = 0;
            mauSo = 1;
        }

        // Constructor có tham số
        public PhanSo(int tu, int mau)
        {
            TuSo = tu;
            MauSo = mau; // Gọi qua Property để check khác 0
            RutGon();
        }

        // Constructor sao chép
        public PhanSo(PhanSo p)
        {
            this.tuSo = p.tuSo;
            this.mauSo = p.mauSo;
        }

        // 4. Override ToString()
        public override string ToString()
        {
            if (mauSo == 1) return $"{tuSo}"; // Nếu mẫu bằng 1 thì chỉ in tử số (VD: 5/1 -> 5)
            if (tuSo == 0) return "0";
            return $"{tuSo}/{mauSo}";
        }

        // 5. Đa năng hóa toán tử 1 ngôi (+, -)
        public static PhanSo operator +(PhanSo p)
        {
            return p; // Dấu + không làm thay đổi giá trị
        }

        public static PhanSo operator -(PhanSo p)
        {
            return new PhanSo(-p.tuSo, p.mauSo); // Đảo dấu tử số
        }

        // 6. Đa năng hóa toán tử 2 ngôi (+, -, *, /)
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo + b.tuSo * a.mauSo, a.mauSo * b.mauSo);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo - b.tuSo * a.mauSo, a.mauSo * b.mauSo);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.tuSo, a.mauSo * b.mauSo);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo, a.mauSo * b.tuSo);
        }

        // 7. Đa năng hóa toán tử so sánh (>, <, >=, <=, ==, !=)
        // Lưu ý: C# bắt buộc nạp chồng theo cặp
        public static bool operator >(PhanSo a, PhanSo b)
        {
            // Quy đồng rồi so sánh tử số (giả định mẫu luôn dương nhờ hàm RutGon)
            return (a.tuSo * b.mauSo) > (b.tuSo * a.mauSo);
        }

        public static bool operator <(PhanSo a, PhanSo b)
        {
            return (a.tuSo * b.mauSo) < (b.tuSo * a.mauSo);
        }

        public static bool operator >=(PhanSo a, PhanSo b)
        {
            return (a.tuSo * b.mauSo) >= (b.tuSo * a.mauSo);
        }

        public static bool operator <=(PhanSo a, PhanSo b)
        {
            return (a.tuSo * b.mauSo) <= (b.tuSo * a.mauSo);
        }

        public static bool operator ==(PhanSo a, PhanSo b)
        {
            // Ép kiểu về object để check null tránh vòng lặp vô hạn
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return ReferenceEquals(a, b);

            return (a.tuSo * b.mauSo) == (b.tuSo * a.mauSo);
        }

        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }

        // Bổ sung bắt buộc khi dùng toán tử ==
        public override bool Equals(object obj)
        {
            if (obj is PhanSo)
                return this == (PhanSo)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return tuSo.GetHashCode() ^ mauSo.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== KHỞI TẠO PHÂN SỐ =====");
            PhanSo p1 = new PhanSo(1, 2);  // 1/2
            PhanSo p2 = new PhanSo(3, 4);  // 3/4
            PhanSo p3 = new PhanSo(2, 4);  // 2/4 (Sẽ tự rút gọn thành 1/2)

            Console.WriteLine($"Phân số p1: {p1}");
            Console.WriteLine($"Phân số p2: {p2}");
            Console.WriteLine($"Phân số p3: {p3} (Khởi tạo là 2/4, đã tự rút gọn)");

            Console.WriteLine("\n===== TOÁN TỬ 1 NGÔI =====");
            Console.WriteLine($"+p1 = {+p1}");
            Console.WriteLine($"-p1 = {-p1}");

            Console.WriteLine("\n===== TOÁN TỬ 2 NGÔI =====");
            Console.WriteLine($"p1 + p2 = {p1 + p2}");
            Console.WriteLine($"p1 - p2 = {p1 - p2}");
            Console.WriteLine($"p1 * p2 = {p1 * p2}");
            Console.WriteLine($"p1 / p2 = {p1 / p2}");

            Console.WriteLine("\n===== TOÁN TỬ SO SÁNH =====");
            Console.WriteLine($"p1 > p2  : {p1 > p2}");
            Console.WriteLine($"p1 < p2  : {p1 < p2}");
            Console.WriteLine($"p1 == p3 : {p1 == p3}"); // So sánh 1/2 và 2/4 đã rút gọn
            Console.WriteLine($"p1 != p2 : {p1 != p2}");

            Console.WriteLine("\n===== TEST TRƯỜNG HỢP BIÊN =====");
            PhanSo pLoi = new PhanSo(5, 0); // Test chia cho 0
            Console.WriteLine($"Phân số pLoi sau khi xử lý: {pLoi}");

            Console.ReadLine();
        }
    }
}