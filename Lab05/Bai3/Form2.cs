using System;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmNhapHocVienMoi : Form
    {
        private frmQuanLyHocVien frmChinh;

        public frmNhapHocVienMoi(frmQuanLyHocVien parentForm)
        {
            InitializeComponent();
            this.frmChinh = parentForm;
        }

        private void frmNhapHocVienMoi_Load(object sender, EventArgs e)
        {
            cboLop.Items.AddRange(new string[] { "Lớp A", "Lớp B" });
            cboLop.SelectedIndex = 0;
        }

        // Cập nhật học viên vào ListBox tương ứng trên Form chính
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ và Tên học viên!", "Thông báo");
                txtHoTen.Focus();
                return;
            }

            frmChinh.ThemHocVienVaoLop(hoTen, cboLop.Text);
            txtHoTen.Clear();
            txtHoTen.Focus();
        }
    }
}