using System;
using System.Collections; // Thư viện bắt buộc để sử dụng ArrayList

namespace ThucHanh02
{
    // Lớp Point rút gọn để dùng cho bài này
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point() { X = 0; Y = 0; }
        public Point(double x, double y) { X = x; Y = y; }

        public void Input()
        {
            Console.Write("  Nhập x: ");
            X = double.Parse(Console.ReadLine());
            Console.Write("  Nhập y: ");
            Y = double.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    // Lớp ArrayPoint quản lý danh sách các Point
    class ArrayPoint
    {
        // 1. Field: Một ArrayList lưu các Point
        private ArrayList arrPoint;

        // Constructor khởi tạo ArrayList
        public ArrayPoint()
        {
            arrPoint = new ArrayList();
        }

        // 2. Indexer: Cho phép truy cập phần tử thứ i bằng cú pháp array[i]
        public Point this[int i]
        {
            get
            {
                // ArrayList mặc định lưu kiểu 'object', nên khi lấy ra phải ép kiểu về (Point)
                return (Point)arrPoint[i];
            }
            set
            {
                arrPoint[i] = value;
            }
        }

        // Property đếm số lượng phần tử hiện có
        public int Count
        {
            get { return arrPoint.Count; }
        }

        // Method thêm 1 điểm vào danh sách
        public void Add(Point p)
        {
            arrPoint.Add(p);
        }

        // Method nhập danh sách điểm
        public void Nhap()
        {
            Console.Write("Nhập số lượng điểm: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập tọa độ điểm thứ {i}:");
                Point p = new Point();
                p.Input();
                this.Add(p); // Thêm vào ArrayList
            }
        }

        // Method xuất danh sách điểm
        public void Xuat()
        {
            for (int i = 0; i < this.Count; i++)
            {
                // Sử dụng Indexer this[i] để lấy ra Point thứ i và in
                Console.WriteLine($"Điểm [{i}] = {this[i].ToString()}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== NHẬP DANH SÁCH ĐIỂM ===");
            ArrayPoint list = new ArrayPoint();
            list.Nhap();

            Console.WriteLine("\n=== XUẤT DANH SÁCH ĐIỂM ===");
            list.Xuat();

            // Test Indexer: Truy cập và thay đổi giá trị
            if (list.Count > 0)
            {
                Console.WriteLine("\n=== TEST INDEXER ===");
                Console.WriteLine($"Lấy phần tử đầu tiên (list[0]): {list[0]}");

                Console.WriteLine("Đổi giá trị phần tử list[0] thành (99, 99)...");
                list[0] = new Point(99, 99); // Gọi phần 'set' của Indexer

                Console.WriteLine("Danh sách sau khi sửa:");
                list.Xuat();
            }

            Console.ReadLine();
        }
    }
}