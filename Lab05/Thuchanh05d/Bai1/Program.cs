using System;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mạc định chạy Form Main (BTVN Bài 2) chứa Menu mở tất cả các bài tập tuần này.
            // Hoặc đổi tên Form dưới đây để chạy trực tiếp từng bài:
            // Phần 1 (WinForm Nâng cao 2): frmBaitap1, frmBaiTap2, frmQuanLyHocVien, frmDongHo, frmMainTuan6
            // Phần 2 (CSDL ADO.NET): frmQLMonHoc, frmQLSinhVien, frmQLDiem, frmLop
            Application.Run(new frmBaitap1());
        }
    }
}