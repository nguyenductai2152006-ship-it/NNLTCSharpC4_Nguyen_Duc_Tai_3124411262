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

        
            Application.Run(new frmListbox());
        }
    }
}