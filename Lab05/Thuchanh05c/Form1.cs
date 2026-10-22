using System;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    public partial class frmBaiTapTaiLop1 : Form
    {
        public frmBaiTapTaiLop1()
        {
            InitializeComponent();
        }

        // Thêm số vào ComboBox
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập phải là số nguyên dương
            if (!int.TryParse(txtNhapSo.Text.Trim(), out int so) || so <= 0)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương hợp lệ!", "Thông báo");
                txtNhapSo.Focus();
                return;
            }

            // Kiểm tra trùng trong ComboBox trước khi thêm
            if (!cboSo.Items.Contains(so))
            {
                cboSo.Items.Add(so);
            }
            else
            {
                MessageBox.Show("Số này đã tồn tại trong danh sách!", "Thông báo");
            }

            txtNhapSo.Clear();
            txtNhapSo.Focus();
        }

        // Khi chọn số trên ComboBox -> Liệt kê ước số qua ListBox
        private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUocSo.Items.Clear();
            if (cboSo.SelectedItem != null)
            {
                int n = (int)cboSo.SelectedItem;
                for (int i = 1; i <= n; i++)
                {
                    if (n % i == 0) lstUocSo.Items.Add(i);
                }
            }
        }

        // Tính tổng các ước số
        private void btnTongUoc_Click(object sender, EventArgs e)
        {
            int tong = 0;
            foreach (int item in lstUocSo.Items) tong += item;
            MessageBox.Show("Tổng các ước số là: " + tong, "Kết quả");
        }

        // Đếm số lượng ước số chẵn
        private void btnUocChan_Click(object sender, EventArgs e)
        {
            int dem = 0;
            foreach (int item in lstUocSo.Items)
            {
                if (item % 2 == 0) dem++;
            }
            MessageBox.Show("Số lượng các ước số chẵn là: " + dem, "Kết quả");
        }

        // Hàm kiểm tra số nguyên tố
        private bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }

        // Đếm số lượng ước số nguyên tố
        private void btnUocNguyenTo_Click(object sender, EventArgs e)
        {
            int dem = 0;
            foreach (int item in lstUocSo.Items)
            {
                if (LaSoNguyenTo(item)) dem++;
            }
            MessageBox.Show("Số lượng các ước số nguyên tố là: " + dem, "Kết quả");
        }

        // Thoát có xác nhận
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}