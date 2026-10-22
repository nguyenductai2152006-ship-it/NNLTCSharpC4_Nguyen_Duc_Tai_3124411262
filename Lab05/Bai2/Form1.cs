using System;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmBaiTap2 : Form
    {
        public frmBaiTap2()
        {
            InitializeComponent();
        }

        // Đánh lại số thứ tự (STT) tự động và tính lại Tổng tiền sau khi Thêm hoặc Xóa
        private void CapNhatSTTVaTongTien()
        {
            decimal tongTien = 0;
            for (int i = 0; i < lsvTaiKhoan.Items.Count; i++)
            {
                // Đánh lại STT từ 1
                lsvTaiKhoan.Items[i].SubItems[0].Text = (i + 1).ToString();

                // Cộng dồn số tiền (bỏ dấu phẩy ngăn cách hàng nghìn trước khi ép kiểu)
                string chuoiTien = lsvTaiKhoan.Items[i].SubItems[4].Text.Replace(",", "");
                if (decimal.TryParse(chuoiTien, out decimal tien))
                {
                    tongTien += tien;
                }
            }
            txtTongTien.Text = tongTien.ToString("N0");
        }

        // Khi nhấn nút "Thêm" <-> "Hủy"
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                txtSoTK.Clear();
                txtTenKH.Clear();
                txtDiaChi.Clear();
                txtSoTien.Clear();
                txtSoTK.Focus();
            }
            else
            {
                btnThem.Text = "Thêm";
                btnLuu.Enabled = false;
            }
        }

        // Khi nhấn nút "Lưu": Lưu thông tin từ các TextBox vào ListView
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string soTK = txtSoTK.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrEmpty(soTK) || string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!", "Thông báo");
                return;
            }

            if (!decimal.TryParse(txtSoTien.Text.Trim(), out decimal soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền trong tài khoản phải là số hợp lệ!", "Thông báo");
                txtSoTien.Focus();
                return;
            }

            // Kiểm tra nếu trùng Số tài khoản thì cập nhật, ngược lại thì thêm mới
            ListViewItem itemTonTai = null;
            foreach (ListViewItem it in lsvTaiKhoan.Items)
            {
                if (it.SubItems[1].Text == soTK)
                {
                    itemTonTai = it;
                    break;
                }
            }

            if (itemTonTai != null)
            {
                itemTonTai.SubItems[2].Text = tenKH;
                itemTonTai.SubItems[3].Text = diaChi;
                itemTonTai.SubItems[4].Text = soTien.ToString("N0");
            }
            else
            {
                ListViewItem newItem = new ListViewItem((lsvTaiKhoan.Items.Count + 1).ToString());
                newItem.SubItems.Add(soTK);
                newItem.SubItems.Add(tenKH);
                newItem.SubItems.Add(diaChi);
                newItem.SubItems.Add(soTien.ToString("N0"));
                lsvTaiKhoan.Items.Add(newItem);
            }

            CapNhatSTTVaTongTien();

            // Đưa nút Thêm/Lưu về trạng thái ban đầu
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
        }

        // Khi chọn 1 dòng trong ListView: Bật nút Xóa và hiển thị thông tin lên TextBox
        private void lsvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXoa.Enabled = (lsvTaiKhoan.SelectedItems.Count > 0);

            if (lsvTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvTaiKhoan.SelectedItems[0];
                txtSoTK.Text = item.SubItems[1].Text;
                txtTenKH.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                txtSoTien.Text = item.SubItems[4].Text.Replace(",", "");
            }
        }

        // Khi nhấn nút "Xóa": Xóa mẫu tin hiện hành và cập nhật lại STT + Tổng tiền
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedItems.Count > 0)
            {
                lsvTaiKhoan.SelectedItems[0].Remove();
                CapNhatSTTVaTongTien();
                btnXoa.Enabled = false;
            }
        }
    }
}