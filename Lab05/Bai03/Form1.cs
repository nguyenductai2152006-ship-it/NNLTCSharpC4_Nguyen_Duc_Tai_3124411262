using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    public partial class frmChuoi : Form
    {
        string[] HO = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
        string[] TENLOT = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
        string[] TEN = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };
        Random rand = new Random();

        public frmChuoi()
        {
            InitializeComponent();
        }

        // Tạo ngẫu nhiên 50 họ tên
        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                string ho = HO[rand.Next(HO.Length)];
                string lot = TENLOT[rand.Next(TENLOT.Length)];
                string ten = TEN[rand.Next(TEN.Length)];
                lstTen.Items.Add($"{ho} {lot} {ten}");
            }
        }

        // Xóa các phần tử đang chọn (duyệt ngược từ dưới lên để không lệch Index)
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            for (int i = lstTen.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstTen.Items.RemoveAt(lstTen.SelectedIndices[i]);
            }
        }

        // Xóa phần tử có tên là Sơn (kết thúc bằng "Sơn")
        private void btnXoaTenSon_Click(object sender, EventArgs e)
        {
            for (int i = lstTen.Items.Count - 1; i >= 0; i--)
            {
                string hoTen = lstTen.Items[i].ToString().Trim();
                if (hoTen.EndsWith("Sơn", StringComparison.CurrentCultureIgnoreCase))
                {
                    lstTen.Items.RemoveAt(i);
                }
            }
        }

        // Xóa phần tử có họ là Lê (bắt đầu bằng "Lê ")
        private void btnXoaHoLe_Click(object sender, EventArgs e)
        {
            for (int i = lstTen.Items.Count - 1; i >= 0; i--)
            {
                string hoTen = lstTen.Items[i].ToString().Trim();
                if (hoTen.StartsWith("Lê ", StringComparison.CurrentCultureIgnoreCase))
                {
                    lstTen.Items.RemoveAt(i);
                }
            }
        }

        // Chuyển các phần tử đang chọn thành chữ IN HOA
        private void btnChuHoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTen.SelectedIndices.Count; i++)
            {
                int idx = lstTen.SelectedIndices[i];
                lstTen.Items[idx] = lstTen.Items[idx].ToString().ToUpper();
            }
        }

        // Chuyển các phần tử đang chọn thành chữ thường
        private void btnChuThuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTen.SelectedIndices.Count; i++)
            {
                int idx = lstTen.SelectedIndices[i];
                lstTen.Items[idx] = lstTen.Items[idx].ToString().ToLower();
            }
        }

        // Chuyển các phần tử đang chọn thành viết Hoa đầu mỗi từ
        private void btnHoaDauTu_Click(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            for (int i = 0; i < lstTen.SelectedIndices.Count; i++)
            {
                int idx = lstTen.SelectedIndices[i];
                string s = lstTen.Items[idx].ToString().ToLower();
                lstTen.Items[idx] = ti.ToTitleCase(s);
            }
        }

        // Xóa toàn bộ danh sách
        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            lstTen.Items.Clear();
        }

        // Double click mở hộp thoại sửa tên tại vị trí đang chọn
        private void lstTen_DoubleClick(object sender, EventArgs e)
        {
            if (lstTen.SelectedIndex != -1)
            {
                int idx = lstTen.SelectedIndex;
                string tenCu = lstTen.Items[idx].ToString();
                string tenMoi = ShowInputBox("Nhập tên mới thay thế:", "Cập nhật tên", tenCu);
                if (!string.IsNullOrWhiteSpace(tenMoi))
                {
                    lstTen.Items[idx] = tenMoi.Trim();
                }
            }
        }

        // Hàm tự tạo hộp thoại InputBox gọn nhẹ không cần thư viện ngoài
        private string ShowInputBox(string prompt, string title, string defaultValue)
        {
            Form promptForm = new Form() { Width = 350, Height = 150, Text = title, StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog };
            Label lbl = new Label() { Left = 20, Top = 15, Text = prompt, AutoSize = true };
            TextBox txt = new TextBox() { Left = 20, Top = 40, Width = 290, Text = defaultValue };
            Button btnOk = new Button() { Text = "OK", Left = 150, Width = 75, Top = 75, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Hủy", Left = 235, Width = 75, Top = 75, DialogResult = DialogResult.Cancel };
            promptForm.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnCancel });
            promptForm.AcceptButton = btnOk;
            return promptForm.ShowDialog() == DialogResult.OK ? txt.Text : "";
        }
    }
}