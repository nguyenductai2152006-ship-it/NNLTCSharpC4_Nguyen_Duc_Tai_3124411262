using System;
using System.Windows.Forms;

namespace WinFormBasic1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Lệnh quan trọng nhất: Khởi động chương trình và gọi Form1 lên[cite: 12, 34]
            Application.Run(new Form1());
        }
    }
}