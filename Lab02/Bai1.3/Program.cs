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
        // Khởi tạo các giá trị rỗng/bằng 0 ban đầu khi tạo đối tượng
        public Person()
        {
            id = "Chưa có";
            name = "Chưa có";
            yob = 0;
            yod = 0;
        }

        // 3. Copy Constructor (Hàm tạo sao chép)
        // Dùng để tạo ra một đối tượng mới bằng cách chép dữ liệu từ một đối tượng Person (p) đã có
        public Person(Person p)
        {
            this.id = p.id;
            this.name = p.name;
            this.yob = p.yob;
            this.yod = p.yod;
        }

        // 4. Nhập dữ liệu
        public void Input()
        {
            Console.Write("Nhập ID: ");
            id = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            name = Console.ReadLine();

            Console.Write("Nhập năm sinh (yob): ");
            yob = int.Parse(Console.ReadLine());

            Console.Write("Nhập năm mất (yod) [Nếu còn sống thì nhập 0]: ");
            yod = int.Parse(Console.ReadLine());
        }

        // 5. Xuất dữ liệu
        public void Output()
        {
            // Dùng toán tử 3 ngôi (? :) để hiển thị chuỗi "Còn sống" nếu yod == 0
            string tinhTrang = (yod == 0) ? "Còn sống" : yod.ToString();
            Console.WriteLine($"ID: {id} | Họ tên: {name} | Năm sinh: {yob} | Năm mất: {tinhTrang}");
        }

        // 6. Kiểm tra còn sống hay không
        // Trả về true nếu yod bằng 0, ngược lại trả về false
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

            Console.WriteLine("===== TẠO NGƯỜI THỨ 1 (DÙNG DEFAULT CONSTRUCTOR) =====");
            Person p1 = new Person();
            p1.Input();

            Console.WriteLine("\n--- THÔNG TIN NGƯỜI THỨ 1 ---");
            p1.Output();

            // Kiểm tra tình trạng
            if (p1.IsLiving())
            {
                Console.WriteLine("-> Trạng thái: Người này hiện đang còn sống.");
            }
            else
            {
                Console.WriteLine("-> Trạng thái: Người này đã qua đời.");
            }

            Console.WriteLine("\n===== TẠO NGƯỜI THỨ 2 (DÙNG COPY CONSTRUCTOR) =====");
            // Khởi tạo p2 bằng cách truyền p1 vào để sao chép toàn bộ thông tin
            Person p2 = new Person(p1);
            Console.WriteLine("Thông tin người thứ 2 (Bản sao của người 1):");
            p2.Output();

            Console.ReadLine();
        }
    }
}