using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmBaitap1 : Form
    {
        public frmBaitap1()
        {
            InitializeComponent();
        }

        // 1. Khi Load form: Thêm dữ liệu vào ComboBox Dân tộc
        private void frmBaitap1_Load(object sender, EventArgs e)
        {
            string[] danToc = { "Kinh", "Tày", "Thái", "Mường", "Hoa", "Khmer", "Nùng" };
            cboDanToc.Items.AddRange(danToc);
            cboDanToc.SelectedIndex = 0;
        }

        // Hàm lấy chuỗi ngoại ngữ từ các CheckBox đang chọn
        private string LayNgoaiNgu()
        {
            List<string> nn = new List<string>();
            if (chkAnh.Checked) nn.Add("Anh");
            if (chkPhap.Checked) nn.Add("Pháp");
            if (chkHoa.Checked) nn.Add("Hoa");
            return string.Join(", ", nn);
        }

        // Hàm kiểm tra trùng Mã sinh viên trên ListView (Cột Mã SV ở vị trí SubItems[1])
        private bool KiemTraTrungMaSV(string maSV)
        {
            foreach (ListViewItem item in lsvSinhVien.Items)
            {
                if (string.Compare(item.SubItems[1].Text.Trim(), maSV, true) == 0)
                    return true;
            }
            return false;
        }

        // 2. Chức năng Thêm sinh viên (Không cho trùng Mã SV)
        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string maSV = txtMaSV.Text.Trim();

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Mã sinh viên!", "Thông báo");
                return;
            }

            if (KiemTraTrungMaSV(maSV))
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại! Vui lòng nhập mã khác.", "Lỗi trùng mã");
                txtMaSV.Focus();
                return;
            }

            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string ngoaiNgu = LayNgoaiNgu();
            string danToc = cboDanToc.Text;

            // Thêm dòng mới vào ListView
            ListViewItem item = new ListViewItem(hoTen);
            item.SubItems.Add(maSV);
            item.SubItems.Add(gioiTinh);
            item.SubItems.Add(ngoaiNgu);
            item.SubItems.Add(danToc);
            lsvSinhVien.Items.Add(item);

            txtHoTen.Clear();
            txtMaSV.Clear();
            txtHoTen.Focus();
        }

        // 3. Chức năng Xóa (Dùng chung cho cả Button Xóa và ContextMenuStrip chuột phải)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo");
                return;
            }

            foreach (ListViewItem item in lsvSinhVien.SelectedItems)
            {
                item.Remove();
            }
        }

        // 4. Chức năng Sửa (Không cho phép sửa Mã sinh viên)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng trên danh sách để sửa!", "Thông báo");
                return;
            }

            ListViewItem item = lsvSinhVien.SelectedItems[0];

            // Kiểm tra nếu người dùng cố tình thay đổi Mã SV trên TextBox
            if (string.Compare(item.SubItems[1].Text, txtMaSV.Text.Trim(), true) != 0)
            {
                MessageBox.Show("Không được phép sửa Mã sinh viên!", "Cảnh báo");
                txtMaSV.Text = item.SubItems[1].Text; // Khôi phục lại mã cũ
                return;
            }

            // Cập nhật các thông tin còn lại
            item.SubItems[0].Text = txtHoTen.Text.Trim();
            item.SubItems[2].Text = radNam.Checked ? "Nam" : "Nữ";
            item.SubItems[3].Text = LayNgoaiNgu();
            item.SubItems[4].Text = cboDanToc.Text;
        }

        // Hiển thị ngược thông tin lên các Control khi click chọn dòng trong ListView
        private void lsvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvSinhVien.SelectedItems[0];
                txtHoTen.Text = item.SubItems[0].Text;
                txtMaSV.Text = item.SubItems[1].Text;

                if (item.SubItems[2].Text == "Nam") radNam.Checked = true;
                else radNu.Checked = true;

                string nn = item.SubItems[3].Text;
                chkAnh.Checked = nn.Contains("Anh");
                chkPhap.Checked = nn.Contains("Pháp");
                chkHoa.Checked = nn.Contains("Hoa");

                cboDanToc.Text = item.SubItems[4].Text;
            }
        }

        // 5. Hỏi xác nhận trước khi đóng Form
        private void frmBaitap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn đóng Form này không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true; // Hủy sự kiện đóng form
            }
        }
    }
}