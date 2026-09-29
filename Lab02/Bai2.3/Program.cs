using System;

namespace ThucHanh02
{
    // Lớp DaySo đóng gói một mảng 1 chiều các số nguyên
    class DaySo
    {
        // 1. Fields
        private int[] arr; // Mảng 1 chiều lưu các số nguyên
        private int n;     // Số lượng phần tử của mảng

        // 2. Các loại Constructor
        // Constructor mặc định: Tạo mảng rỗng
        public DaySo()
        {
            n = 0;
            arr = new int[0]; // Khởi tạo mảng 0 phần tử để tránh lỗi NullReference
        }

        // Constructor có tham số: Tạo mảng có kích thước định trước
        public DaySo(int size)
        {
            n = size;
            arr = new int[n];
        }

        // 3. Indexer để truy cập phần tử thứ i
        // Giúp đối tượng DaySo có thể thao tác như mảng (VD: day[0] = 5)
        public int this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }

        // Property phụ để lấy kích thước mảng (tiện cho vòng lặp ở hàm Main)
        public int Length
        {
            get { return n; }
        }

        // 4. Nhập dãy số
        public void Nhap()
        {
            Console.Write("Nhập số lượng phần tử của dãy số (n): ");
            n = int.Parse(Console.ReadLine());

            // Cấp phát lại vùng nhớ cho mảng dựa trên n vừa nhập
            arr = new int[n];

            Console.WriteLine("Bắt đầu nhập các phần tử:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"  arr[{i}] = ");
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // 5. Xuất dãy số
        public void Xuat()
        {
            if (n == 0)
            {
                Console.WriteLine("Dãy số đang rỗng!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                // Gọi tới get của Indexer bằng cách dùng this[i] hoặc arr[i] đều được
                Console.Write($"{this[i]}   ");
            }
            Console.WriteLine(); // Xuống dòng cho đẹp
        }

        // 6. Tìm và in ra các số chẵn
        public void TimSoChan()
        {
            Console.Write("Các số chẵn trong dãy là: ");
            bool coSoChan = false; // Cờ đánh dấu xem có số chẵn nào không

            for (int i = 0; i < n; i++)
            {
                // Số chẵn là số chia hết cho 2 (phần dư = 0)
                if (arr[i] % 2 == 0)
                {
                    Console.Write($"{arr[i]}   ");
                    coSoChan = true;
                }
            }

            // Nếu lướt hết mảng mà cờ vẫn là false thì báo không có
            if (coSoChan == false)
            {
                Console.Write("Không có số chẵn nào!");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== KHỞI TẠO VÀ NHẬP DÃY SỐ =====");
            DaySo ds = new DaySo();
            ds.Nhap();

            Console.WriteLine("\n===== DÃY SỐ VỪA NHẬP =====");
            ds.Xuat();

            Console.WriteLine("\n===== TÌM SỐ CHẴN =====");
            ds.TimSoChan();

            Console.WriteLine("\n===== TEST INDEXER =====");
            if (ds.Length > 0)
            {
                Console.WriteLine($"Phần tử đầu tiên (ds[0]) là: {ds[0]}");
                Console.WriteLine("Gán ds[0] = 999...");
                ds[0] = 999; // Gọi phần set của Indexer

                Console.Write("Dãy số sau khi sửa: ");
                ds.Xuat();
            }

            Console.ReadLine();
        }
    }
}