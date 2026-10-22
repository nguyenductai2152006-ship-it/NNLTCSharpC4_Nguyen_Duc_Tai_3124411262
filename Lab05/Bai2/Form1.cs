using System;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    public partial class frmBaiTapTaiLop2 : Form
    {
        TreeNode rootNode;

        public frmBaiTapTaiLop2()
        {
            InitializeComponent();
        }

        // Khởi tạo dữ liệu khi mở Form
        private void frmBaiTapTaiLop2_Load(object sender, EventArgs e)
        {
            rootNode = new TreeNode("Danh sách lớp");
            trvLop.Nodes.Add(rootNode);

            string[] dsLop = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };
            foreach (string lop in dsLop)
            {
                rootNode.Nodes.Add(lop);
                cboLop.Items.Add(lop);
            }
            cboLop.SelectedIndex = 0;
            rootNode.ExpandAll();

            // Ẩn groupbox Thêm lớp ban đầu
            chkThemLop.Checked = false;
            grpThongTinLop.Visible = false;
        }

        // Ẩn/Hiện GroupBox Thông tin lớp theo CheckBox
        private void chkThemLop_CheckedChanged(object sender, EventArgs e)
        {
            grpThongTinLop.Visible = chkThemLop.Checked;
        }

        // Thêm lớp mới
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            string tenLop = txtTenLop.Text.Trim();
            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!");
                return;
            }

            // Kiểm tra trùng tên lớp (không phân biệt hoa thường)
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (string.Compare(node.Text, tenLop, true) == 0)
                {
                    MessageBox.Show("Lớp này đã tồn tại!");
                    return;
                }
            }

            rootNode.Nodes.Add(tenLop);
            cboLop.Items.Add(tenLop);
            txtTenLop.Clear();
            rootNode.Expand();
        }

        // Kiểm tra trùng Mã SV trên toàn bộ TreeView
        private bool KiemTraTrungMaSV(string maSV)
        {
            foreach (TreeNode lopNode in rootNode.Nodes)
            {
                foreach (TreeNode svNode in lopNode.Nodes)
                {
                    string maHienTai = svNode.Text.Split(',')[0].Trim();
                    if (string.Compare(maHienTai, maSV, true) == 0) return true;
                }
            }
            return false;
        }

        // Thêm sinh viên vào lớp đang chọn
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text.Trim();
            string ten = txtHoTen.Text.Trim();
            string dc = txtDiaChi.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!");
                return;
            }

            if (KiemTraTrungMaSV(ma))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!");
                return;
            }

            // Tìm node lớp tương ứng với ComboBox đang chọn
            foreach (TreeNode lopNode in rootNode.Nodes)
            {
                if (lopNode.Text == cboLop.Text)
                {
                    // Tạo node SV dạng "Mã, Họ Tên" và node con là "Địa chỉ"
                    TreeNode svNode = new TreeNode(ma + ", " + ten);
                    svNode.Nodes.Add(dc);
                    lopNode.Nodes.Add(svNode);
                    lopNode.ExpandAll();
                    break;
                }
            }

            txtMaSV.Clear(); txtHoTen.Clear(); txtDiaChi.Clear();
            txtMaSV.Focus();
        }

        // Chỉ cho phép xóa Node là sinh viên (Level == 2)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            TreeNode selected = trvLop.SelectedNode;
            // Level 0: Danh sách lớp | Level 1: Lớp | Level 2: Sinh viên | Level 3: Địa chỉ
            if (selected != null && selected.Level == 2)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    selected.Remove();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đúng node Sinh Viên cần xóa!");
            }
        }

        // Hiển thị thông tin sinh viên khi click chọn Node sinh viên
        private void trvLop_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selected = e.Node;
            if (selected.Level == 2) // Node Sinh viên
            {
                string[] parts = selected.Text.Split(',');
                if (parts.Length >= 2)
                {
                    txtMaSV.Text = parts[0].Trim();
                    txtHoTen.Text = parts[1].Trim();
                }
                if (selected.Nodes.Count > 0)
                {
                    txtDiaChi.Text = selected.Nodes[0].Text;
                }
                cboLop.Text = selected.Parent.Text;
            }
        }
    }
}