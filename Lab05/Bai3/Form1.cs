using System;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmQuanLyHocVien : Form
    {
        public frmQuanLyHocVien()
        {
            InitializeComponent();
        }

        // Khởi tạo dữ liệu mẫu giống hình trong đề bài
        private void frmQuanLyHocVien_Load(object sender, EventArgs e)
        {
            lstLopA.Items.AddRange(new string[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Tứ" });
            lstLopB.Items.AddRange(new string[] { "Tuấn Hưng", "Hồng Ngọc", "Anh Minh", "Bảo Lâm" });
        }

        // Phương thức public để Form Nhập học viên mới gọi trực tiếp khi thêm học viên
        public void ThemHocVienVaoLop(string hoTen, string tenLop)
        {
            if (tenLop == "Lớp A") lstLopA.Items.Add(hoTen);
            else lstLopB.Items.Add(hoTen);
        }

        // 1. Menu Nhập học viên mới: Mở form con và truyền tham chiếu form chính sang
        private void mnuNhapMoi_Click(object sender, EventArgs e)
        {
            frmNhapHocVienMoi frm = new frmNhapHocVienMoi(this);
            frm.ShowDialog();
        }

        // 2. Menu Chuyển sang lớp B (Từ Lớp A -> Lớp B)
        private void mnuChuyenSangB_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên trong Lớp A trước khi chuyển!", "Thông báo");
                return;
            }

            // Thêm sang Lớp B trước, sau đó xóa ngược từ dưới lên ở Lớp A
            foreach (var item in lstLopA.SelectedItems)
            {
                lstLopB.Items.Add(item);
            }
            for (int i = lstLopA.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstLopA.Items.RemoveAt(lstLopA.SelectedIndices[i]);
            }
        }

        // 3. Menu Chuyển sang lớp A (Từ Lớp B -> Lớp A)
        private void mnuChuyenSangA_Click(object sender, EventArgs e)
        {
            if (lstLopB.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên trong Lớp B trước khi chuyển!", "Thông báo");
                return;
            }

            foreach (var item in lstLopB.SelectedItems)
            {
                lstLopA.Items.Add(item);
            }
            for (int i = lstLopB.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstLopB.Items.RemoveAt(lstLopB.SelectedIndices[i]);
            }
        }

        // 4. Menu Xóa học viên: Xóa tất cả học viên đang chọn ở cả Lớp A và Lớp B
        private void mnuXoaHV_Click(object sender, EventArgs e)
        {
            for (int i = lstLopA.SelectedIndices.Count - 1; i >= 0; i--)
                lstLopA.Items.RemoveAt(lstLopA.SelectedIndices[i]);

            for (int i = lstLopB.SelectedIndices.Count - 1; i >= 0; i--)
                lstLopB.Items.RemoveAt(lstLopB.SelectedIndices[i]);
        }

        // 5. Menu Kết thúc: Hỏi xác nhận trước khi thoát
        private void mnuKetThuc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn kết thúc chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}