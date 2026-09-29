using System;

namespace ThucHanh02
{
    // Lớp Point mô tả một điểm trên hệ trục tọa độ Oxy
    class Point
    {
        // 1. Field (Trường dữ liệu): private để đảm bảo tính đóng gói
        private double x;
        private double y;

        // 2. Property (Thuộc tính): Cung cấp giao diện an toàn để truy xuất Field
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // 3. Constructor (Hàm tạo)
        // Default constructor khởi tạo giá trị ban đầu cho x và y bằng 0
        public Point()
        {
            x = 0;
            y = 0;
        }

        // Constructor có tham số (Thêm vào để hỗ trợ tính toán trả về Point mới dễ dàng)
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // 4. Method: Input và Output
        public void Input()
        {
            Console.Write("Nhập tọa độ x: ");
            x = double.Parse(Console.ReadLine());

            Console.Write("Nhập tọa độ y: ");
            y = double.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine(this.ToString());
        }

        // 5. Override hàm ToString() để xuất Point theo định dạng (x, y)
        public override string ToString()
        {
            return $"({x}, {y})";
        }

        // 6. Phép toán (Operator Overloading)
        // Phép cộng 2 điểm: (x1+x2, y1+y2)
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }

        // Phép trừ 2 điểm: (x1-x2, y1-y2)
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }

        // Lấy âm (-) 1 điểm: (-x, -y)
        public static Point operator -(Point p)
        {
            return new Point(-p.x, -p.y);
        }

        // 7(a). Khoảng cách giữa 2 điểm
        // Phương thức thành viên: tính khoảng cách từ điểm hiện tại (this) đến điểm p
        public double KhoangCach(Point p)
        {
            // Công thức: sqrt((x2 - x1)^2 + (y2 - y1)^2)
            return Math.Sqrt(Math.Pow(p.x - this.x, 2) + Math.Pow(p.y - this.y, 2));
        }

        // Phương thức tĩnh: tính khoảng cách giữa 2 điểm p1 và p2 được truyền vào
        public static double KhoangCach(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
        }

        // 7(b). Trung điểm của 2 điểm
        // Phương thức thành viên: tính trung điểm của điểm hiện tại (this) và điểm p
        public Point TrungDiem(Point p)
        {
            return new Point((this.x + p.x) / 2, (this.y + p.y) / 2);
        }

        // Phương thức tĩnh: tính trung điểm của 2 điểm p1 và p2
        public static Point TrungDiem(Point p1, Point p2)
        {
            return new Point((p1.x + p2.x) / 2, (p1.y + p2.y) / 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- NHẬP ĐIỂM A ---");
            Point A = new Point();
            A.Input();

            Console.WriteLine("\n--- NHẬP ĐIỂM B ---");
            Point B = new Point();
            B.Input();

            Console.WriteLine("\n===== KẾT QUẢ TÍNH TOÁN =====");
            Console.Write("Điểm A: "); A.Output();
            Console.Write("Điểm B: "); B.Output();

            // Test đa năng hóa toán tử
            Point C = A + B;
            Console.WriteLine($"\nA + B = {C}");
            Console.WriteLine($"A - B = {A - B}");
            Console.WriteLine($"Lấy âm điểm A (-A) = {-A}");

            // Test khoảng cách
            Console.WriteLine($"\nKhoảng cách A đến B (Instance method): {A.KhoangCach(B)}");
            Console.WriteLine($"Khoảng cách A đến B (Static method): {Point.KhoangCach(A, B)}");

            // Test trung điểm
            Console.WriteLine($"\nTrung điểm A và B (Instance method): {A.TrungDiem(B)}");
            Console.WriteLine($"Trung điểm A và B (Static method): {Point.TrungDiem(A, B)}");

            Console.ReadLine();
        }
    }
}