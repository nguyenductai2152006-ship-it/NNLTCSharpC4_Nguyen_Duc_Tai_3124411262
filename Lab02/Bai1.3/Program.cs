using System;

namespace ThucHanh02
{
    // Lớp Person dùng để quản lý thông tin của một người
    class Person
    {
        // 1. Dữ liệu thành viên (Fields)
        private string id;
        private string name;
        private int yob; // year of birth - năm sinh
        private int yod; // year of death - năm mất

        // 2. Default Constructor (Hàm tạo mặc định)
        public Person()
        {
            id = "Chưa có";
            name = "Chưa có";
            yob = 0;
            yod = 0;
        }

        // 3. Copy Constructor (Hàm tạo sao chép)
        public Person(Person p)
        {
            this.id = p.id;
            this.name = p.name;
            this.yob = p.yob;
            this.yod = p.yod;
        }

        // 4. Nhập dữ liệu có kiểm tra logic
        public void Input()
        {
            Console.Write("Nhập ID: ");
            id = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            name = Console.ReadLine();

            Console.Write("Nhập năm sinh (yob): ");
            yob = int.Parse(Console.ReadLine());

            // Dùng do-while để bắt buộc người dùng nhập đúng logic
            do
            {
                Console.Write("Nhập năm mất (yod) [Nếu còn sống thì nhập 0]: ");
                yod = int.Parse(Console.ReadLine());

                // Nếu nhập năm mất khác 0 (đã chết) mà nhỏ hơn năm sinh -> báo lỗi
                if (yod != 0 && yod < yob)
                {
                    Console.WriteLine("--> LỖI: Năm mất không thể nhỏ hơn năm sinh! Vui lòng nhập lại.\n");
                }
            }
            while (yod != 0 && yod < yob); // Lặp lại nếu nhập sai logic
        }

        // 5. Xuất dữ liệu
        public void Output()
        {
            string tinhTrang = (yod == 0) ? "Còn sống" : yod.ToString();
            Console.WriteLine($"ID: {id} | Họ tên: {name} | Năm sinh: {yob} | Năm mất: {tinhTrang}");
        }

        // 6. Kiểm tra còn sống hay không
        public bool IsLiving()
        {
            return yod == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== NHẬP THÔNG TIN (TEST LỖI LOGIC) =====");
            Person p1 = new Person();
            p1.Input();

            Console.WriteLine("\n--- THÔNG TIN VỪA NHẬP ---");
            p1.Output();

            if (p1.IsLiving())
            {
                Console.WriteLine("-> Trạng thái: Người này hiện đang còn sống.");
            }
            else
            {
                Console.WriteLine("-> Trạng thái: Người này đã qua đời.");
            }

            Console.ReadLine();
        }
    }
}