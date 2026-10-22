
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    public partial class Form1 : Form
    {
        private string[] HO =
        {
            "Lê", "Nguyễn", "Lý", "Trần", "Lâm",
            "Hồ", "Lai", "Huỳnh", "La"
        };

        private string[] TENLOT =
        {
            "Quang", "Thành", "Ngọc", "Anh", "Xuân",
            "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng"
        };

        private string[] TEN =
        {
            "Hà", "Danh", "Sơn", "Mai", "Thắng",
            "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm"
        };

        private readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            lstDanhSachTen.SelectionMode = SelectionMode.MultiExtended;
            lstDanhSachTen.Sorted = false;

            // Gắn sự kiện cho các nút, tránh trùng với Designer
            btnNhapTenNgauNhien.Click -= btnNgauNhien_Click;
            btnNhapTenNgauNhien.Click += btnNgauNhien_Click;

            btnXoaDangChon.Click -= btnXoaDangChon_Click;
            btnXoaDangChon.Click += btnXoaDangChon_Click;

            btnXoaTenSon.Click -= btnXoaTenSon_Click;
            btnXoaTenSon.Click += btnXoaTenSon_Click;

            btnXoaHoLe.Click -= btnXoaHoLe_Click;
            btnXoaHoLe.Click += btnXoaHoLe_Click;

            btnChuyenChuHoa.Click -= btnChuyenChuHoa_Click;
            btnChuyenChuHoa.Click += btnChuyenChuHoa_Click;

            btnChuyenChuThuong.Click -= btnChuyenChuThuong_Click;
            btnChuyenChuThuong.Click += btnChuyenChuThuong_Click;

            btnVietHoaDauTu.Click -= btnVietHoaDauTu_Click;
            btnVietHoaDauTu.Click += btnVietHoaDauTu_Click;

            btnXoaTatCa.Click -= btnXoaTatCa_Click;
            btnXoaTatCa.Click += btnXoaTatCa_Click;

            lstDanhSachTen.DoubleClick -= lstDanhSachTen_DoubleClick;
            lstDanhSachTen.DoubleClick += lstDanhSachTen_DoubleClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // =====================================
        // 1. THÊM 50 HỌ TÊN NGẪU NHIÊN
        // =====================================
        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                string ho = HO[random.Next(HO.Length)];
                string tenLot = TENLOT[random.Next(TENLOT.Length)];
                string ten = TEN[random.Next(TEN.Length)];

                lstDanhSachTen.Items.Add(
                    ho + " " + tenLot + " " + ten);
            }
        }

        // =====================================
        // 2. XÓA CÁC PHẦN TỬ ĐANG CHỌN
        // =====================================
        private void btnXoaDangChon_Click(object sender, EventArgs e)
        {
            if (lstDanhSachTen.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn họ tên cần xóa!");
                return;
            }

            int[] viTri = lstDanhSachTen.SelectedIndices
                .Cast<int>()
                .OrderByDescending(i => i)
                .ToArray();

            foreach (int i in viTri)
            {
                lstDanhSachTen.Items.RemoveAt(i);
            }
        }

        // =====================================
        // 3. XÓA NGƯỜI CÓ TÊN SƠN
        // =====================================
        private void btnXoaTenSon_Click(object sender, EventArgs e)
        {
            for (int i = lstDanhSachTen.Items.Count - 1; i >= 0; i--)
            {
                string hoTen = lstDanhSachTen.Items[i].ToString();

                string[] parts = hoTen.Split(
                    new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0)
                    continue;

                if (string.Equals(
                    parts[parts.Length - 1],
                    "Sơn",
                    StringComparison.OrdinalIgnoreCase))
                {
                    lstDanhSachTen.Items.RemoveAt(i);
                }
            }
        }

        // =====================================
        // 4. XÓA NGƯỜI CÓ HỌ LÊ
        // =====================================
        private void btnXoaHoLe_Click(object sender, EventArgs e)
        {
            for (int i = lstDanhSachTen.Items.Count - 1; i >= 0; i--)
            {
                string hoTen = lstDanhSachTen.Items[i].ToString();

                string[] parts = hoTen.Split(
                    new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0)
                    continue;

                if (string.Equals(
                    parts[0],
                    "Lê",
                    StringComparison.OrdinalIgnoreCase))
                {
                    lstDanhSachTen.Items.RemoveAt(i);
                }
            }
        }

        // =====================================
        // 5. CHỈ CHUYỂN CÁC TÊN ĐANG CHỌN THÀNH HOA
        // =====================================
        private void btnChuyenChuHoa_Click(object sender, EventArgs e)
        {
            ChuyenDoiTen(hoTen => hoTen.ToUpper());
        }

        // =====================================
        // 6. CHỈ CHUYỂN CÁC TÊN ĐANG CHỌN THÀNH THƯỜNG
        // =====================================
        private void btnChuyenChuThuong_Click(object sender, EventArgs e)
        {
            ChuyenDoiTen(hoTen => hoTen.ToLower());
        }

        // =====================================
        // 7. VIẾT HOA ĐẦU TỪ CỦA CÁC TÊN ĐANG CHỌN
        // =====================================
        private void btnVietHoaDauTu_Click(object sender, EventArgs e)
        {
            ChuyenDoiTen(hoTen =>
            {
                string[] parts = hoTen.ToLower().Split(
                    new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < parts.Length; j++)
                {
                    parts[j] = parts[j].Substring(0, 1).ToUpper()
                             + parts[j].Substring(1);
                }

                return string.Join(" ", parts);
            });
        }

        // =====================================
        // 8. HÀM CHUYỂN ĐỔI CHỈ CÁC PHẦN TỬ ĐANG CHỌN
        // =====================================
        private void ChuyenDoiTen(Func<string, string> hamChuyenDoi)
        {
            if (lstDanhSachTen.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn họ tên cần chuyển!");
                return;
            }

            // Lưu vị trí được chọn
            int[] viTriChon = lstDanhSachTen.SelectedIndices
                .Cast<int>()
                .ToArray();

            // Lấy toàn bộ danh sách hiện tại
            string[] danhSach = lstDanhSachTen.Items
                .Cast<object>()
                .Select(item => item.ToString())
                .ToArray();

            // CHỈ thay đổi những phần tử đang chọn
            foreach (int i in viTriChon)
            {
                danhSach[i] = hamChuyenDoi(danhSach[i]);
            }

            // Hiển thị danh sách sau khi xử lý
            lstDanhSachTen.BeginUpdate();

            try
            {
                lstDanhSachTen.Items.Clear();
                lstDanhSachTen.Items.AddRange(danhSach);

                // Giữ nguyên các phần tử đang chọn
                foreach (int i in viTriChon)
                {
                    lstDanhSachTen.SetSelected(i, true);
                }
            }
            finally
            {
                lstDanhSachTen.EndUpdate();
            }
        }

        // =====================================
        // 9. XÓA TẤT CẢ HỌ TÊN
        // =====================================
        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            if (lstDanhSachTen.Items.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tất cả họ tên không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lstDanhSachTen.Items.Clear();
            }
        }

        // =====================================
        // 10. DOUBLECLICK ĐỂ SỬA HỌ TÊN
        // =====================================
        private void lstDanhSachTen_DoubleClick(object sender, EventArgs e)
        {
            int viTri = lstDanhSachTen.SelectedIndex;

            if (viTri < 0)
                return;

            string tenCu = lstDanhSachTen.Items[viTri].ToString();

            string tenMoi = HienThiInputBox(tenCu);

            if (string.IsNullOrWhiteSpace(tenMoi))
                return;

            lstDanhSachTen.Items[viTri] = tenMoi.Trim();
            lstDanhSachTen.SelectedIndex = viTri;
        }

        // =====================================
        // 11. INPUTBOX CHỈNH SỬA HỌ TÊN
        // =====================================
        private string HienThiInputBox(string tenCu)
        {
            using (Form inputBox = new Form())
            {
                inputBox.Text = "Chỉnh sửa họ tên";
                inputBox.ClientSize = new Size(400, 150);
                inputBox.StartPosition = FormStartPosition.CenterParent;
                inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputBox.MaximizeBox = false;
                inputBox.MinimizeBox = false;
                inputBox.ShowInTaskbar = false;

                Label lbl = new Label();
                lbl.Text = "Nhập họ tên mới:";
                lbl.Location = new Point(20, 15);
                lbl.AutoSize = true;

                TextBox txtTenMoi = new TextBox();
                txtTenMoi.Location = new Point(20, 45);
                txtTenMoi.Size = new Size(360, 25);
                txtTenMoi.Text = tenCu;

                Button btnOK = new Button();
                btnOK.Text = "OK";
                btnOK.Location = new Point(205, 90);
                btnOK.Size = new Size(80, 30);
                btnOK.DialogResult = DialogResult.OK;

                Button btnCancel = new Button();
                btnCancel.Text = "Cancel";
                btnCancel.Location = new Point(295, 90);
                btnCancel.Size = new Size(85, 30);
                btnCancel.DialogResult = DialogResult.Cancel;

                inputBox.Controls.Add(lbl);
                inputBox.Controls.Add(txtTenMoi);
                inputBox.Controls.Add(btnOK);
                inputBox.Controls.Add(btnCancel);

                inputBox.AcceptButton = btnOK;
                inputBox.CancelButton = btnCancel;

                inputBox.Shown += (s, e) =>
                {
                    txtTenMoi.Focus();
                    txtTenMoi.SelectAll();
                };

                if (inputBox.ShowDialog(this) == DialogResult.OK)
                {
                    return txtTenMoi.Text.Trim();
                }

                return "";
            }
        }
    }
}
