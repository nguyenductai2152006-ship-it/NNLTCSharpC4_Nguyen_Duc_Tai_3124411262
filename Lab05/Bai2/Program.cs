using System;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Đổi tên Form dưới đây để chạy bài tương ứng:
            // frmBaiTapTaiLop1, frmBaiTapTaiLop2, frmChuoi, frmTuDien, frmListbox, frmBTVN3
            Application.Run(new frmBaiTapTaiLop2());
        }
    }
}