using System;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    public partial class frmBTVN3 : Form
    {
        public frmBTVN3()
        {
            InitializeComponent();
        }

        // Load các chữ cái từ A -> Z lên TreeView khi mở Form
        private void frmBTVN3_Load(object sender, EventArgs e)
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                trvDanhBa.Nodes.Add(c.ToString());
            }
        }

        // Thêm người mới vào đúng Node chữ cái đầu của First Name (Tên)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string first = txtFirstName.Text.Trim();
            string last = txtLastName.Text.Trim();

            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(last))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ First Name và Last Name!");
                return;
            }

            // Lấy chữ cái đầu tiên của First Name và chuyển thành chữ IN HOA
            string chuCaiDau = first.Substring(0, 1).ToUpper();

            // Tìm Node tương ứng từ A -> Z để thêm vào
            foreach (TreeNode node in trvDanhBa.Nodes)
            {
                if (node.Text == chuCaiDau)
                {
                    node.Nodes.Add($"{first}, {last}");
                    node.Expand();
                    break;
                }
            }

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }
    }
}