using System;
using System.Text;
using System.Collections.Generic;
namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            // while(true) tạo vòng lặp menu vô hạn.
            // Chương trình chỉ dừng khi gặp "return" ở lựa chọn 0.
            while (true)
            {
                Console.Clear();        // Xóa toàn bộ nội dung Console cũ trước khi hiển thị menu mới.

                // Hiển thị menu cho người dùng lựa chọn bài tập.
                Console.WriteLine("===== MENU BAI TAP LAB 01 =====");
                Console.WriteLine("1. Bai 2: Nhap xuat ho ten");
                Console.WriteLine("2. Bai 3: Tinh x^y");
                Console.WriteLine("3. Bai 4: Tinh x^y (co bao loi)");
                Console.WriteLine("4. Bai 5: Menu tinh toan so thuc");
                Console.WriteLine("5. Bai 6: Tim max 3 so nguyen");
                Console.WriteLine("6. Bai 7: Kiem tra so nguyen to");
                Console.WriteLine("7. Bai 8: Hoan vi 2 so thuc (ref)");
                Console.WriteLine("8. Bai 9: Tim min max 3 so thuc (out)");
                Console.WriteLine("9. Bai 10: Kiem tra chuoi doi xung");
                Console.WriteLine("10.Bai 11: Dao nguoc chuoi");
                Console.WriteLine("11.Bai 12: Chuyen chuoi hoa thuong, dem tu");
                Console.WriteLine("12.Bai 13: Nhap xuat thong tin sinh vien");
                Console.WriteLine("13.Bai 14: Tinh luong nhan vien");
                Console.WriteLine("14.Bai 15: Mang 1 chieu (nhap, xuat, MinMax, So nguyen to)");
                Console.WriteLine("15.Bai 16: Nhap danh sach ho ten va sap xep");
                Console.WriteLine("16.Bai 17: Mang 2 chieu ngau nhien, tach so chan le");
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
                    case "6": Bai07(); break;
                    case "7": Bai08(); break;
                    case "8": Bai09(); break;
                    case "9": Bai10(); break;
                    case "10": Bai11(); break;
                    case "11": Bai12(); break;
                    case "12": Bai13(); break;
                    case "13": Bai14(); break;
                    case "14": Bai15(); break;
                    case "15": Bai16(); break; 
                    case "16": Bai17(); break; 
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

        // ================= BAI 7 =================
        // Hàm trả về true nếu n là số nguyên tố, ngược lại false.
        static bool KiemTraNguyenTo(int n)
        {
            // Số nguyên tố phải lớn hơn hoặc bằng 2.
            if (n < 2) return false;
            // Chỉ cần thử ước từ 2 đến căn bậc hai của n.
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                // Nếu chia hết cho i thì n không phải số nguyên tố.
                if (n % i == 0) return false;
            }
            // Không tìm thấy ước nào => n là số nguyên tố.
            return true;
        }

        static void Bai07()
        {
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());
            if (KiemTraNguyenTo(n))
                Console.WriteLine($"{n} la so nguyen to.");
            else
                Console.WriteLine($"{n} khong phai so nguyen to.");
        }

        // ================= BAI 8 =================
        // Hàm hoán vị 2 số thực.
        // ref cho phép hàm thay đổi trực tiếp giá trị biến bên ngoài.
        static void HoanVi(ref double a, ref double b)
        {
            // Lưu a tạm thời để tránh mất dữ liệu khi đổi chỗ.
            double temp = a;
            a = b;
            b = temp;
        }

        static void Bai08()
        {
            Console.Write("Nhap a: "); double a = double.Parse(Console.ReadLine());
            Console.Write("Nhap b: "); double b = double.Parse(Console.ReadLine());
            // Khi gọi hàm phải dùng ref vì tham số của hàm cũng dùng ref.
            HoanVi(ref a, ref b);
            Console.WriteLine($"Sau khi hoan vi: a = {a}, b = {b}");
        }

        // ================= BAI 9 =================
        // Hàm tìm cả Min và Max.
        // out cho phép hàm trả về nhiều giá trị thông qua tham số.
        static void TimMinMax(double a, double b, double c, out double min, out double max)
        {
            // Tìm giá trị nhỏ nhất.
            min = Math.Min(a, Math.Min(b, c));
            // Tìm giá trị lớn nhất.
            max = Math.Max(a, Math.Max(b, c));
        }

        static void Bai09()
        {
            Console.Write("Nhap a: "); double a = double.Parse(Console.ReadLine());
            Console.Write("Nhap b: "); double b = double.Parse(Console.ReadLine());
            Console.Write("Nhap c: "); double c = double.Parse(Console.ReadLine());
            // Nhận đồng thời min và max từ hàm TimMinMax.
            TimMinMax(a, b, c, out double min, out double max);
            Console.WriteLine($"Min = {min}, Max = {max}");
        }

        // ================= BAI 10 =================
        // Kiểm tra chuỗi đối xứng (đọc từ trái sang phải giống từ phải sang trái).
        static bool KiemTraDoiXung(string s)
        {
            // left bắt đầu ở đầu chuỗi, right bắt đầu ở cuối chuỗi.
            int left = 0, right = s.Length - 1;
            // So sánh từng cặp ký tự từ hai đầu tiến vào giữa.
            while (left < right)
            {
                // Chỉ cần một cặp khác nhau => không đối xứng.
                if (s[left] != s[right]) return false;

                // Di chuyển hai con trỏ vào trong.
                left++;
                right--;
            }
            return true;
        }

        static void Bai10()
        {
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine();
            if (KiemTraDoiXung(s))
                Console.WriteLine("Chuoi doi xung.");
            else
                Console.WriteLine("Chuoi khong doi xung.");
        }


        // ================= BAI 11 =================
        // Hàm tạo một chuỗi mới bằng cách đọc ký tự từ cuối về đầu.
        static string DaoNguocChuoi(string s)
        {
            // StringBuilder dùng để nối nhiều ký tự hiệu quả.
            StringBuilder sb = new StringBuilder();
            // Duyệt chuỗi từ vị trí cuối cùng về vị trí 0.
            for (int i = s.Length - 1; i >= 0; i--)
            {
                // Thêm từng ký tự vào StringBuilder.
                sb.Append(s[i]);
            }
            // Chuyển StringBuilder thành chuỗi string để trả về.
            return sb.ToString();
        }
        static void Bai11()
        {
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine();
            Console.WriteLine($"Chuoi dao nguoc: {DaoNguocChuoi(s)}");
        }

        // ================= BAI 12 =================
        // Mục tiêu: đổi chữ hoa/thường và đếm số từ trong chuỗi.
        static void Bai12()
        {
            Console.Write("Nhap chuoi nhieu tu: ");
            string s = Console.ReadLine();
            // ToLower() chuyển toàn bộ chuỗi thành chữ thường.
            Console.WriteLine($"Chu thuong: {s.ToLower()}");
            // ToUpper() chuyển toàn bộ chuỗi thành chữ hoa.
            Console.WriteLine($"Chu hoa: {s.ToUpper()}");
            // Split tách chuỗi thành mảng từ.
            // RemoveEmptyEntries bỏ các phần tử rỗng do nhiều dấu cách liên tiếp.
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"So tu: {words.Length}");
        }

        // ================= BAI 13 =================
        // Lớp SinhVien dùng để mô tả thông tin của một sinh viên.
        class SinhVien
        {
            // Các property lưu dữ liệu của sinh viên.
            public string MaSV { get; set; }
            public string HoTen { get; set; }
            public string DiaChi { get; set; }
            public int NamSinh { get; set; }
            // Constructor dùng để khởi tạo đối tượng SinhVien ngay khi new.
            public SinhVien(string ma,string ten,string dc,int ns)
            {
                MaSV = ma;
                HoTen = ten;
                DiaChi = dc;
                NamSinh = ns;
            }
            // Phương thức in toàn bộ thông tin sinh viên.
            public void XuatThongTin()
            {
                Console.WriteLine($"MaSV: {MaSV}, HoTen: {HoTen}, DiaChi: {DiaChi}, Nam: {NamSinh}");
            }
        }

        static void Bai13()
        {
            Console.Write("Nhap ma sinh vien: ");string ma = Console.ReadLine();
            Console.Write("Nhap ho ten: ");string ten = Console.ReadLine();
            Console.Write("Nhap dia chi: ");string dc = Console.ReadLine();
            Console.Write("Sinh vien nam: ");int ns = int.Parse(Console.ReadLine());
            // Tạo đối tượng SinhVien bằng constructor.
            SinhVien sv = new SinhVien(ma, ten, dc, ns);
            // Gọi phương thức in thông tin sinh viên.
            sv.XuatThongTin();
        }

        // ================= BAI 14 =================
        // Lớp NhanVien mô tả thông tin và cách tính lương của nhân viên.
        class NhanVien
        {
            // Các property lưu thông tin nhân viên.
            public string HoTen { get; set; }
            public double MucLuong { get; set; }
            public int SoNgayVang { get; set; }
            // Constructor khởi tạo một đối tượng NhanVien.
            public NhanVien(string ten, double luong, int vang)
            {
                HoTen = ten;
                MucLuong = luong;
                SoNgayVang = vang;
            }

            // Tính lương thực nhận theo công thức:
            // Lương thực nhận = Mức lương - Số ngày vắng * 100000.
            public double TinhLuong()
            {
                return MucLuong - SoNgayVang * 100000;
            }

            // In thông tin và mức lương thực nhận.
            public void XuatThongTin()
            {
                Console.WriteLine($"Nhan vien {HoTen}");
                Console.WriteLine($"Luong thuc nhan: {TinhLuong()} VND");
            }
        }
        static void Bai14()
        {
            Console.Write("Nhap ho ten nhan vien: "); string ten = Console.ReadLine();
            Console.Write("Nhap muc luong: "); double luong = double.Parse(Console.ReadLine());
            Console.Write("Nhap so ngay vang: "); int vang = int.Parse(Console.ReadLine());
            // Tạo đối tượng NhanVien.
            NhanVien nv = new NhanVien(ten, luong, vang);
            // Gọi phương thức xuất thông tin và lương.
            nv.XuatThongTin();
        }

        // ================= BAI 15 =================
        // Hàm nhập các phần tử cho mảng 1 chiều.
        static void NhapMang(int[] arr)
        {
            // arr.Length là số lượng phần tử của mảng.
            for (int i = 0; i < arr.Length; i++)
            {       // arr[i] là phần tử tại vị trí i.s
                Console.Write($"Nhap phan tu arr[{i}]: ");  
                arr[i] = int.Parse(Console.ReadLine());
            }
        }
        // Hàm xuất toàn bộ mảng.
        static void XuatMang(int[] arr)
        {            // string.Join nối các phần tử bằng dấu ", ".
            Console.WriteLine("Mang: "+ string.Join(", ", arr));
        }
        // Hàm tìm Min và Max của mảng
        static void TimMinMaxMang(int[] arr, out int min, out int max)
        {
            // Tạm lấy phần tử đầu tiên làm Min và Max ban đầu.
            min = arr[0];
            max = arr[0];
            // foreach lần lượt lấy từng phần tử trong mảng.
            foreach (int x in arr)
            {
                // foreach lần lượt lấy từng phần tử trong mảng.
                if (x < min) min = x;
                // Nếu x lớn hơn Max hiện tại thì cập nhật Max.
                if (x > max) max = x;
            }
        }
        // Hàm lấy các số nguyên tố trong mảng.
        static int[] LaySoNguyenTo(int[] arr)
        {        // Tạo List để lưu các số nguyên tố tìm được.
            List<int> result = new List<int>();
            foreach(int x in arr)
            {      // Nếu x là số nguyên tố thì thêm x vào List.
                if (KiemTraNguyenTo(x)) result.Add(x);
            }
            // Chuyển List<int> thành int[] trước khi trả về.
            return result.ToArray();
        }

        static void Bai15()
        {
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());
            // Cấp phát mảng có n phần tử.
            int[] arr = new int[n];

            // Gọi các hàm để nhập, xuất, tìm Min/Max và lọc số nguyên tố.
            NhapMang(arr);
            XuatMang(arr);
            TimMinMaxMang(arr, out int min, out int max);
            Console.WriteLine($"Min = {min}, Max = {max}"); 
            int[] nguyenTo = LaySoNguyenTo(arr);
            Console.WriteLine("Cac so nguyen to: " + string.Join(", ", nguyenTo));
        }
        // ================= BAI 16 =================
        // Mục tiêu: nhập danh sách họ tên và sắp xếp.
        static void Bai16()
        {
            Console.Write("Nhap mang ho ten cua n nguoi: ");
            int n = int.Parse(Console.ReadLine());
            // Tạo mảng string để lưu n họ tên.
            string[] hoTen = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap ho ten thu {i + 1}: ");
                hoTen[i] = Console.ReadLine();
            }
            // Array.Sort sắp xếp mảng chuỗi theo thứ tự tăng dần.
            Array.Sort(hoTen);
            Console.WriteLine("Danh sach ho ten sau khi sap xep:");
            foreach(string s in hoTen)
            {
                Console.WriteLine(s);
            }
        }
        // ================= BAI 17 =================
        // Mục tiêu: tạo mảng 2 chiều ngẫu nhiên, sau đó tách số chẵn và lẻ.
        static void Bai17()
        {
            Console.Write("Nhap n: "); int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap m: "); int m = int.Parse(Console.ReadLine());
            // int[,] là mảng 2 chiều có n dòng và m cột.
            int[,] arr = new int[n, m];
            // Random dùng để sinh số ngẫu nhiên.
            Random rd = new Random();
            // ===== Sinh ngẫu nhiên các phần tử =====
            // Vòng lặp i duyệt từng dòng.
            for (int i = 0; i < n; i++)
            {
                // Vòng lặp j duyệt từng cột trong dòng i.
                for (int j = 0; j < m; j++)
                {
                    // Sinh số ngẫu nhiên từ 0 đến 99.
                    arr[i, j] = rd.Next(9,101);
                }
            }
            // ===== In mảng 2 chiều =====
            Console.WriteLine("Mang 2 chieu:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            // ===== Tách số chẵn và số lẻ =====
            // Hai List dùng để lưu riêng các số chẵn và số lẻ.
            List<int> chan = new List<int>();
            List<int> le = new List<int>();
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // % là phép chia lấy dư.
                    // Dư 0 khi chia 2 => số chẵn; ngược lại => số lẻ.
                    if (arr[i, j] % 2 == 0)
                        chan.Add(arr[i, j]);
                    else
                        le.Add(arr[i, j]);
                }
            }
            Console.WriteLine("Nhap so chan: " + string.Join(", ", chan));
            Console.WriteLine("Nhap so le: " + string.Join(", ", le));
        }
    }
}