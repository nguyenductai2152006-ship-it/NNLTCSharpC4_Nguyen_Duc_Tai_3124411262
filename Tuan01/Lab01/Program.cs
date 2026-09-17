using System;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            // while(true) tạo vòng lặp menu vô hạn.
            // Chương trình chỉ dừng khi gặp "return" ở lựa chọn 0.
            while (true) {
                Console.Clear();        // Xóa toàn bộ nội dung Console cũ trước khi hiển thị menu mới.

                // Hiển thị menu cho người dùng lựa chọn bài tập.
                Console.WriteLine("===== MENU BAI TAP LAB 01 =====");
                Console.WriteLine("1. Bai 2: Nhap xuat ho ten");
                Console.WriteLine("2. Bai 3: Tinh x^y");
                Console.WriteLine("3. Bai 4: Tinh x^y (co bao loi)");
                Console.WriteLine("4. Bai 5: Menu tinh toan so thuc");
                Console.WriteLine("5. Bai 6: Tim max 3 so nguyen");
                Console.WriteLine("0. Thoat");

                Console.Write("Chon bai: ");
                string choice = Console.ReadLine();     // Đọc lựa chọn của người dùng dưới dạng chuỗi.
                Console.Clear();        // Xóa màn hình để khi vào bài tập sẽ gọn hơn.

                // switch dùng để kiểm tra người dùng đã chọn bài nào.
                switch (choice)
                {
                    // Mỗi case gọi đúng hàm của bài tương ứng.
                    case "1": Bai02(); break;
                    case "2": Bai03(); break;
                    case "3": Bai04(); break;
                    case "4": Bai05(); break;
                    case "5": Bai06(); break;
                    case "0": return;     // return kết thúc luôn hàm Main => thoát chương trình.

                    default: Console.WriteLine("Lua chon khong hop le!"); break;         // Nếu lựa chọn không nằm trong các case trên => thoát chương trình.
              
                 }
                // Sau khi làm xong một bài, dừng màn hình để người dùng xem kết quả.
                Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                Console.ReadKey();      // Chờ người dùng nhấn một phím bất kỳ.
            }
        }

        // ================= BAI 2 =================
        // Mục tiêu: nhập họ tên và in lời chào.
        static void Bai02()
        {
            // Hiển thị yêu cầu nhập dữ liệu.
            Console.Write("Nhap ho ten cua ban: ");
            // ReadLine đọc cả dòng người dùng nhập và trả về kiểu string.
            string hoTen = Console.ReadLine();

            // $ trước chuỗi cho phép chèn biến vào bên trong { }.
            Console.WriteLine($"Chao ban {hoTen}!");
        }

        // ================= BAI 3 =================
        // Mục tiêu: tính x^y bằng Math.Pow().
        static void Bai03()
        {
            Console.Write("Nhap so nguyen x: ");
            // Parse chuyển chuỗi nhập vào thành số nguyên int.
            int x = int.Parse(Console.ReadLine());

            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());

            // Math.Pow(x, y) tính x mũ y và trả về kiểu double.
            double ketQua = Math.Pow(x, y);
            Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
        }

        // ================= BAI 4 =================
        // Mục tiêu: tính x^y nhưng có kiểm tra dữ liệu nhập.
        static void Bai04()
        {
            // Khai báo trước hai biến để dùng với TryParse và out.
            int x, y;
            Console.Write("Nhap so nguyen x: ");
            // TryParse thử chuyển chuỗi sang int.
            // Nếu chuyển thất bại -> trả false và vòng lặp yêu cầu nhập lại.
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("x khong hop le, nhap lai: ");
            }
            Console.Write("Nhap so nguyen y: ");
            // Kiểm tra y tương tự như x.
            while (!int.TryParse(Console.ReadLine(), out y))
            {
                Console.Write("y khong hop le, nhap lai: ");
            }
            double ketQua = Math.Pow(x, y);
            Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
        }

        // ================= BAI 5 =================
        // Mục tiêu: tạo một menu con để nhập số và thực hiện phép tính.
        static void Bai05()
        {
            // Gán giá trị ban đầu để x, y có giá trị trước khi sử dụng.
            double x = 0, y = 0;
            // Lặp menu con cho đến khi người dùng chọn chức năng 4.
            while (true)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");
                int chon = int.Parse(Console.ReadLine());

                // switch thực hiện chức năng tương ứng với lựa chọn.
                switch (chon)
                {
                    case 1:
                        // Nhập hai giá trị số thực.
                        Console.Write("Nhap x: ");
                        x = double.Parse(Console.ReadLine());

                        Console.Write("Nhap y: ");
                        y = double.Parse(Console.ReadLine());
                        break;
                    case 2:
                        // Tính x mũ y.
                        Console.WriteLine($"x^y = {Math.Pow(x, y)}");
                        break;
                    case 3:
                        // Math.Sqrt tính căn bậc hai.
                        Console.WriteLine($"Can bac 2 cua x = {Math.Sqrt(x)}");
                        Console.WriteLine($"Can bac 2 cua y = {Math.Sqrt(y)}");
                        break;
                    case 4:
                        // return thoát khỏi Bai05 và quay lại menu chính.
                        return;
                    default:
                        Console.WriteLine("Chon sai!");
                        break;
                }
            }
        }

        // ================= BAI 6 =================
        // Hàm phụ: tìm số lớn nhất trong 3 số nguyên.
        static int TimMax(int a, int b, int c)
        {
            // Math.Max(a, b) tìm số lớn hơn giữa a và b.
            // Sau đó so sánh kết quả với c.
            return Math.Max(a, Math.Max(b, c));
        }

        static void Bai06()
        {
            // Nhập 3 số nguyên.
            Console.Write("Nhap a: "); int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap b: "); int b = int.Parse(Console.ReadLine());
            Console.Write("Nhap c: "); int c = int.Parse(Console.ReadLine());
            // Gọi hàm TimMax để lấy giá trị lớn nhất rồi in ra.
            Console.WriteLine($"Max = {TimMax(a, b, c)}");
        }


    }
}