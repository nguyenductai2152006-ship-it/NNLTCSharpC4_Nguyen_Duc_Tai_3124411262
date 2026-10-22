using System;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    public partial class frmListbox : Form
    {
        public frmListbox()
        {
            InitializeComponent();
        }

        // Nhập số tự nhiên N vào Listbox
        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSo.Text.Trim(), out int n) && n >= 0)
            {
                lstSo.Items.Add(n);
                txtSo.Clear();
                txtSo.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tự nhiên (N >= 0)!");
            }
        }

        // Tính tổng các phần tử
        private void btnTong_Click(object sender, EventArgs e)
        {
            int tong = 0;
            foreach (var item in lstSo.Items) tong += Convert.ToInt32(item);
            MessageBox.Show("Tổng các phần tử trong List là: " + tong, "Kết quả");
        }

        // Xóa phần tử đầu và cuối
        private void btnXoaDauCuoi_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count > 0) lstSo.Items.RemoveAt(0); // Xóa đầu
            if (lstSo.Items.Count > 0) lstSo.Items.RemoveAt(lstSo.Items.Count - 1); // Xóa cuối
        }

        // Xóa các phần tử đang chọn
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            for (int i = lstSo.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstSo.Items.RemoveAt(lstSo.SelectedIndices[i]);
            }
        }

        // Tăng mỗi phần tử lên 2
        private void btnTang2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                lstSo.Items[i] = Convert.ToInt32(lstSo.Items[i]) + 2;
            }
        }

        // Thay mỗi phần tử bằng bình phương của chính nó
        private void btnBinhPhuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                int val = Convert.ToInt32(lstSo.Items[i]);
                lstSo.Items[i] = val * val;
            }
        }

        // Chọn các phần tử là số chẵn
        private void btnChonChan_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected();
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                if (Convert.ToInt32(lstSo.Items[i]) % 2 == 0)
                    lstSo.SetSelected(i, true);
            }
        }

        // Chọn các phần tử là số lẻ
        private void btnChonLe_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected();
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                if (Convert.ToInt32(lstSo.Items[i]) % 2 != 0)
                    lstSo.SetSelected(i, true);
            }
        }
    }
}