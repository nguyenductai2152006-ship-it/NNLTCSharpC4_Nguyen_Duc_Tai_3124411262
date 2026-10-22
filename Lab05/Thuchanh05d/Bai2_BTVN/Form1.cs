using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmMainTuan6 : Form
    {
        public frmMainTuan6()
        {
            InitializeComponent();
        }

        // Hàm mở Form con bên trong vùng MDI của Form Main
        private void MoFormCon(Form f)
        {
            f.MdiParent = this;
            f.Show();
        }
    }
}