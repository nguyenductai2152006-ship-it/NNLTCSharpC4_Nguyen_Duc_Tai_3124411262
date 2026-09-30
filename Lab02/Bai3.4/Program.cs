using System;
using System.Collections.Generic;

namespace ThucHanh02
{
    // 1. Khai báo một Delegate để làm "khuôn mẫu" cho sự kiện chọn Menu
    // Bất kỳ hàm nào nhận vào 1 số nguyên (lựa chọn) đều có thể gắn vào sự kiện này
    public delegate void MenuHandler(int choice);

    // === LỚP CONSOLE MENU (Lớp cha tổng quát) ===
    class ConsoleMenu
    {
        // Danh sách các chức năng của Menu
        protected List<string> Options { get; set; }

        // Khai báo sự kiện (Event) dựa trên delegate MenuHandler
        public event MenuHandler Choose;

        public ConsoleMenu()
        {
            Options = new List<string>();
        }

        // Thêm một chức năng mới vào menu
        public void AddOption(string optionName)
        {
            Options.Add(optionName);
        }

        // Hàm hiển thị giao diện và vòng lặp xử lý
        public void Run()
        {
            int choice = -1;
            do
            {
                Console.WriteLine("\n========== MENU ==========");
                for (int i = 0; i < Options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Options[i]}");
                }
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("==========================");

                Console.Write("Thực hiện: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 0)
                    {
                        Console.WriteLine("Đang thoát chương trình...");
                        break; // Thoát vòng lặp
                    }
                    else if (choice > 0 && choice <= Options.Count)
                    {
                        Console.WriteLine($"\n---> Bạn thực hiện chức năng {choice}: {Options[choice - 1]}");

                        // Nếu có người đăng ký lắng nghe sự kiện này (Choose != null) 
                        // thì Phát sự kiện (Raise Event) để lớp con xử lý
                        if (Choose != null)
                        {
                            Choose(choice);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                    }
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập một số nguyên!");
                }

            } while (choice != 0); // Lặp liên tục tới khi người dùng chọn 0
        }
    }

    // === LỚP ỨNG DỤNG GIẢI PT BẬC 2 (Kế thừa từ ConsoleMenu) ===
    class PTBac2Console : ConsoleMenu
    {
        private double a, b, c;

        public PTBac2Console()
        {
            // Thiết lập các option cụ thể cho Menu này
            this.AddOption("Nhập hệ số a, b, c");
            this.AddOption("Giải phương trình bậc 2");

            // Đăng ký sự kiện: Khi menu cha phát sự kiện Choose, gọi hàm XuLyChonMenu
            this.Choose += XuLyChonMenu;
        }

        // Hàm này sẽ tự động được chạy khi người dùng gõ số 1 hoặc 2
        private void XuLyChonMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    NhapHeSo();
                    break;
                case 2:
                    GiaiPhuongTrinh();
                    break;
            }
        }

        private void NhapHeSo()
        {
            Console.WriteLine("--- Nhập các hệ số ---");
            Console.Write("Nhập a: ");
            a = double.Parse(Console.ReadLine());

            Console.Write("Nhập b: ");
            b = double.Parse(Console.ReadLine());

            Console.Write("Nhập c: ");
            c = double.Parse(Console.ReadLine());
        }

        private void GiaiPhuongTrinh()
        {
            Console.WriteLine($"Phương trình: {a}x^2 + {b}x + {c} = 0");

            // Xử lý trường hợp a = 0 (trở thành phương trình bậc 1: bx + c = 0)
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0) Console.WriteLine("=> Phương trình vô số nghiệm.");
                    else Console.WriteLine("=> Phương trình vô nghiệm.");
                }
                else
                {
                    Console.WriteLine($"=> Phương trình có 1 nghiệm: x = {-c / b}");
                }
                return; // Kết thúc hàm sớm
            }

            // Tính Delta cho trường hợp a != 0
            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                Console.WriteLine("=> Phương trình vô nghiệm (Delta < 0).");
            }
            else if (delta == 0)
            {
                Console.WriteLine($"=> Phương trình có nghiệm kép: x1 = x2 = {-b / (2 * a)}");
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"=> Phương trình có 2 nghiệm phân biệt:\n   x1 = {x1}\n   x2 = {x2}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== CHƯƠNG TRÌNH KHỞI ĐỘNG ===");

            // Chỉ cần khởi tạo đối tượng lớp con và gọi hàm Run() của lớp cha
            PTBac2Console app = new PTBac2Console();
            app.Run();

            Console.ReadLine();
        }
    }
}