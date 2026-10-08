using System;
using System.Windows.Forms;

namespace WinFormBasic1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ======================================================
        // 1. CHỨC NĂNG TÍNH TOÁN (+, -, x, /)
        // ======================================================
        private void btnCong_Click(object sender, EventArgs e) { TinhToan("+"); }
        private void btnTru_Click(object sender, EventArgs e) { TinhToan("-"); }
        private void btnNhan_Click(object sender, EventArgs e) { TinhToan("*"); }
        private void btnChia_Click(object sender, EventArgs e) { TinhToan("/"); }

        // Hàm xử lý dùng chung cho cả 4 nút
        private void TinhToan(string phepToan)
        {
            // Kiểm tra rỗng trước khi ép kiểu
            if (txtA.Text.Trim() == "" || txtB.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ hai số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ép kiểu dữ liệu từ chuỗi sang số
            double a = double.Parse(txtA.Text);
            double b = double.Parse(txtB.Text);
            double ketQua = 0;

            // Xử lý phép toán
            switch (phepToan)
            {
                case "+": ketQua = a + b; break;
                case "-": ketQua = a - b; break;
                case "*": ketQua = a * b; break;
                case "/":
                    if (b == 0)
                    {
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng hàm ngay lập tức
                    }
                    ketQua = a / b;
                    break;
            }

            // Xuất kết quả
            txtKetQua.Text = ketQua.ToString();
        }

        // ======================================================
        // 2. MỨC 1: DÙNG ERRORPROVIDER BÁO LỖI (SỰ KIỆN TEXTCHANGED)
        // ======================================================
        private void txtA_TextChanged(object sender, EventArgs e) { KiemTraLoi(txtA); }
        private void txtB_TextChanged(object sender, EventArgs e) { KiemTraLoi(txtB); }

        private void KiemTraLoi(TextBox txt)
        {
            if (txt.Text.Trim().Length == 0)
            {
                // Bật icon đỏ nếu bỏ trống
                errorProvider1.SetError(txt, "Dữ liệu không được để trống!");
            }
            else
            {
                // Xóa icon lỗi nếu đã nhập dữ liệu[cite: 16]
                errorProvider1.Clear();
            }
        }

        // ======================================================
        // 3. MỨC 2: CHẶN KÝ TỰ KHÔNG PHẢI SỐ (SỰ KIỆN KEYPRESS)
        // ======================================================
        private void txtA_KeyPress(object sender, KeyPressEventArgs e) { ChanKyTu(e); }
        private void txtB_KeyPress(object sender, KeyPressEventArgs e) { ChanKyTu(e); }

        private void ChanKyTu(KeyPressEventArgs e)
        {
            // Nếu không phải là số và không phải phím điều khiển (như nút Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Lệnh hủy thao tác gõ phím
                MessageBox.Show("Bạn chỉ được phép nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // 4. XÁC NHẬN THOÁT FORM (SỰ KIỆN FORMCLOSING)
        // ======================================================
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Bạn có muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.No)
            {
                e.Cancel = true; // Ngăn chặn tiến trình đóng Form
            }
        }
    }
}