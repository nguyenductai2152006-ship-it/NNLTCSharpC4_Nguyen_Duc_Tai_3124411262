using System;
using System.Collections.Generic; // Thư viện để dùng List<T>

namespace ThucHanh02
{
    // === LỚP PERSON (Tái sử dụng từ Bài 1.3) ===
    class Person
    {
        private string id;
        private string name;
        private int yob;
        private int yod;

        public Person()
        {
            id = "Chưa có";
            name = "Chưa có";
            yob = 0;
            yod = 0;
        }

        public Person(Person p)
        {
            this.id = p.id;
            this.name = p.name;
            this.yob = p.yob;
            this.yod = p.yod;
        }

        public void Input()
        {
            Console.Write("  Nhập ID: ");
            id = Console.ReadLine();
            Console.Write("  Nhập họ tên: ");
            name = Console.ReadLine();
            Console.Write("  Nhập năm sinh: ");
            yob = int.Parse(Console.ReadLine());

            // Validate logic năm mất
            do
            {
                Console.Write("  Nhập năm mất (nhập 0 nếu còn sống): ");
                yod = int.Parse(Console.ReadLine());
                if (yod != 0 && yod < yob)
                    Console.WriteLine("  -> Lỗi: Năm mất phải >= năm sinh!");
            }
            while (yod != 0 && yod < yob);
        }

        public void Output()
        {
            string tinhTrang = (yod == 0) ? "Còn sống" : yod.ToString();
            Console.WriteLine($"  [{id}] {name} - Sinh: {yob} - Mất: {tinhTrang}");
        }

        public bool IsLiving()
        {
            return yod == 0;
        }
    }

    // === LỚP PERSONLIST QUẢN LÝ DANH SÁCH ===
    class PersonList
    {
        // Sử dụng List<Person> để lưu trữ, tiện hơn mảng thường vì có thể Add thoải mái
        private List<Person> dsNguoi;

        // 1. Default Constructor
        public PersonList()
        {
            dsNguoi = new List<Person>(); // Khởi tạo danh sách rỗng
        }

        // 2. Copy Constructor (Sao chép sâu - Deep Copy)
        public PersonList(PersonList pl)
        {
            dsNguoi = new List<Person>();
            // Duyệt qua danh sách cũ, tạo ra các đối tượng Person MỚI (dùng Copy Constructor của Person)
            foreach (Person p in pl.dsNguoi)
            {
                this.dsNguoi.Add(new Person(p));
            }
        }

        // 3. Hàm Thêm 1 người vào danh sách
        public void Add(Person x)
        {
            dsNguoi.Add(x);
        }

        // 4. Hàm Nhập danh sách
        public void Input()
        {
            Console.Write("Nhập số lượng người cần quản lý: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin người thứ {i + 1} ---");
                Person p = new Person();
                p.Input();
                this.Add(p); // Gọi hàm Add để đưa vào list
            }
        }

        // 5. Hàm Xuất danh sách
        public void Output()
        {
            if (dsNguoi.Count == 0)
            {
                Console.WriteLine("  -> Danh sách trống!");
                return;
            }

            foreach (Person p in dsNguoi)
            {
                p.Output();
            }
        }

        // 6. Hàm Lọc ra những người còn sống
        // Trả về một đối tượng PersonList mới tinh, chỉ chứa người còn sống
        public PersonList LivingPeople()
        {
            PersonList listConSong = new PersonList();

            foreach (Person p in this.dsNguoi)
            {
                if (p.IsLiving())
                {
                    // Nếu còn sống thì hốt vào danh sách mới
                    listConSong.Add(new Person(p));
                }
            }
            return listConSong;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== TẠO DANH SÁCH NHÂN KHẨU =====");
            PersonList dsLocal = new PersonList();
            dsLocal.Input();

            Console.WriteLine("\n===== DANH SÁCH VỪA NHẬP =====");
            dsLocal.Output();

            Console.WriteLine("\n===== DANH SÁCH NGƯỜI CÒN SỐNG =====");
            // Gọi hàm LivingPeople() để lấy ra PersonList mới
            PersonList dsLiving = dsLocal.LivingPeople();
            dsLiving.Output();

            // Test Copy Constructor thử xem có xịn không
            Console.WriteLine("\n===== TEST COPY CONSTRUCTOR =====");
            PersonList dsBackup = new PersonList(dsLocal);
            Console.WriteLine("Danh sách Backup (Copy từ danh sách gốc):");
            dsBackup.Output();

            Console.ReadLine();
        }
    }
}