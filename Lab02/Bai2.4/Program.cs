using System;

namespace ThucHanh02
{
    // Lớp Mang2Chieu đại diện cho một ma trận các số nguyên
    class Mang2Chieu
    {
        // 1. Fields
        private int[,] arr; // Cú pháp khai báo mảng 2 chiều trong C#
        private int n;      // Số dòng (rows)
        private int m;      // Số cột (columns)

        // 2. Các loại Constructor
        // Constructor mặc định
        public Mang2Chieu()
        {
            n = 0;
            m = 0;
            arr = new int[0, 0];
        }

        // Constructor có tham số để tạo mảng nxm
        public Mang2Chieu(int rows, int cols)
        {
            n = rows;
            m = cols;
            arr = new int[n, m];
        }

        // 3. Indexer 2 chiều để truy cập phần tử tại vị trí (i, j)
        public int this[int i, int j]
        {
            get
            {
                return arr[i, j];
            }
            set
            {
                arr[i, j] = value;
            }
        }

        // 4. Nhập mảng 2 chiều
        public void Nhap()
        {
            Console.Write("Nhập số dòng (n): ");
            n = int.Parse(Console.ReadLine());

            Console.Write("Nhập số cột (m): ");
            m = int.Parse(Console.ReadLine());

            // Cấp phát lại bộ nhớ cho mảng 2 chiều theo kích thước vừa nhập
            arr = new int[n, m];

            Console.WriteLine("--- Bắt đầu nhập phần tử ---");
            // Vòng lặp ngoài duyệt từng dòng
            for (int i = 0; i < n; i++)
            {
                // Vòng lặp trong duyệt từng cột của dòng đó
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"  arr[{i}, {j}] = ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        // 5. Xuất mảng 2 chiều
        public void Xuat()
        {
            if (n == 0 || m == 0)
            {
                Console.WriteLine("Mảng rỗng!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // In các số cách nhau bằng dấu tab (\t) để tạo thành dạng bảng (ma trận)
                    Console.Write($"{this[i, j]}\t");
                }
                Console.WriteLine(); // Xuống dòng khi hết 1 dòng
            }
        }

        // --- Hàm hỗ trợ: Kiểm tra 1 số có phải số nguyên tố không ---
        // Hàm này private vì chỉ phục vụ nội bộ cho hàm TimSoNguyenTo bên dưới
        private bool KiemTraNguyenTo(int x)
        {
            if (x < 2) return false; // 0, 1 và số âm không phải số nguyên tố

            // Chỉ cần chạy đến căn bậc 2 của x để tối ưu hiệu năng
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                    return false; // Phát hiện có ước số khác 1 và chính nó -> sai
            }
            return true; // Nếu thoát được vòng lặp thì là số nguyên tố
        }

        // 6. Tìm các số nguyên tố trong mảng
        public void TimSoNguyenTo()
        {
            Console.Write("Các số nguyên tố trong mảng là: ");
            bool coSoNT = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Gọi hàm kiểm tra, nếu trả về true thì in ra
                    if (KiemTraNguyenTo(arr[i, j]))
                    {
                        Console.Write($"{arr[i, j]}  ");
                        coSoNT = true;
                    }
                }
            }

            if (!coSoNT)
            {
                Console.Write("Không có số nguyên tố nào!");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== KHỞI TẠO VÀ NHẬP MẢNG 2 CHIỀU =====");
            Mang2Chieu matrix = new Mang2Chieu();
            matrix.Nhap();

            Console.WriteLine("\n===== MA TRẬN VỪA NHẬP =====");
            matrix.Xuat();

            Console.WriteLine("\n===== TÌM SỐ NGUYÊN TỐ =====");
            matrix.TimSoNguyenTo();

            Console.WriteLine("\n===== TEST INDEXER 2 CHIỀU =====");
            // Test thử đổi giá trị tại dòng 0 cột 0
            Console.WriteLine($"Phần tử đầu tiên matrix[0, 0] là: {matrix[0, 0]}");
            Console.WriteLine("Gán matrix[0, 0] = 99...");
            matrix[0, 0] = 99;

            Console.WriteLine("Ma trận sau khi sửa:");
            matrix.Xuat();

            Console.ReadLine();
        }
    }
}