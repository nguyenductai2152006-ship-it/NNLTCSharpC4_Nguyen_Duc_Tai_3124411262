using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    public partial class frmTuDien : Form
    {
        // Lưu danh sách từ vựng và nghĩa vào List
        List<string> listAnh = new List<string>() { "student", "teacher", "worker", "hat", "head", "mouse", "cat", "dog", "snake", "frog", "sheep" };
        List<string> listViet = new List<string>() { "Sinh viên, học sinh", "Giáo viên", "Công nhân", "Cái mũ", "Cái đầu", "Con chuột", "Con mèo", "Con chó", "Con rắn", "Con ếch", "Con cừu" };

        public frmTuDien()
        {
            InitializeComponent();
        }

        private void frmTuDien_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu và bật tính năng tự động dò tìm từ khớp gần nhất (AutoComplete)
            cboAnhViet.Items.AddRange(listAnh.ToArray());
            cboAnhViet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAnhViet.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboVietAnh.Items.AddRange(listViet.ToArray());
            cboVietAnh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboVietAnh.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // Tra cứu Anh -> Việt
        private void TraAnhViet()
        {
            int idx = listAnh.FindIndex(x => string.Compare(x, cboAnhViet.Text.Trim(), true) == 0);
            txtNghiaTV.Text = (idx != -1) ? listViet[idx] : "Không tìm thấy từ này!";
        }

        // Tra cứu Việt -> Anh
        private void TraVietAnh()
        {
            int idx = listViet.FindIndex(x => string.Compare(x, cboVietAnh.Text.Trim(), true) == 0);
            txtNghiaTA.Text = (idx != -1) ? listAnh[idx] : "Không tìm thấy từ này!";
        }

        private void cboAnhViet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TraAnhViet();
        }

        private void cboAnhViet_DoubleClick(object sender, EventArgs e) => TraAnhViet();

        private void cboVietAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TraVietAnh();
        }

        private void cboVietAnh_DoubleClick(object sender, EventArgs e) => TraVietAnh();
    }
}