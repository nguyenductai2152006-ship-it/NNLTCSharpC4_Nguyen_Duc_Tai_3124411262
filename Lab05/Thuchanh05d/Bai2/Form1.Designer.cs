using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmBaiTap2
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle, lblSoTK, lblTenKH, lblDiaChi, lblSoTien, lblTongTien;
        private TextBox txtSoTK, txtTenKH, txtDiaChi, txtSoTien, txtTongTien;
        private Button btnThem, btnLuu, btnXoa, btnThoat;
        private ListView lsvTaiKhoan;
        private ColumnHeader colSTT, colSoTK, colTenKH, colDiaChi, colSoTien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label()
            {
                Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN",
                Font = new Font("Arial", 15, FontStyle.Bold),
                ForeColor = Color.Blue,
                Location = new Point(55, 15),
                AutoSize = true
            };

            this.lblSoTK = new Label() { Text = "Số tài khoản", Location = new Point(110, 65), AutoSize = true };
            this.txtSoTK = new TextBox() { Location = new Point(225, 62), Size = new Size(300, 22) };

            this.lblTenKH = new Label() { Text = "Tên khách hàng", Location = new Point(95, 98), AutoSize = true };
            this.txtTenKH = new TextBox() { Location = new Point(225, 95), Size = new Size(300, 22) };

            this.lblDiaChi = new Label() { Text = "Địa chỉ khách hàng", Location = new Point(78, 131), AutoSize = true };
            this.txtDiaChi = new TextBox() { Location = new Point(225, 128), Size = new Size(300, 22) };

            this.lblSoTien = new Label() { Text = "Số tiền trong tài khoản", Location = new Point(58, 164), AutoSize = true };
            this.txtSoTien = new TextBox() { Location = new Point(225, 161), Size = new Size(300, 22), TextAlign = HorizontalAlignment.Right };

            this.btnThem = new Button() { Text = "Thêm", Location = new Point(225, 198), Size = new Size(68, 28) };
            this.btnLuu = new Button() { Text = "Lưu", Location = new Point(302, 198), Size = new Size(68, 28), Enabled = false };
            this.btnXoa = new Button() { Text = "Xóa", Location = new Point(379, 198), Size = new Size(68, 28), Enabled = false };
            this.btnThoat = new Button() { Text = "Thoát", Location = new Point(456, 198), Size = new Size(68, 28) };

            this.lsvTaiKhoan = new ListView()
            {
                Location = new Point(15, 240),
                Size = new Size(520, 175),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            this.colSTT = new ColumnHeader() { Text = "STT", Width = 45 };
            this.colSoTK = new ColumnHeader() { Text = "Số tài khoản", Width = 110 };
            this.colTenKH = new ColumnHeader() { Text = "Tên khách hàng", Width = 135 };
            this.colDiaChi = new ColumnHeader() { Text = "Địa chỉ", Width = 105 };
            this.colSoTien = new ColumnHeader() { Text = "Số tiền", Width = 115, TextAlign = HorizontalAlignment.Right };
            this.lsvTaiKhoan.Columns.AddRange(new ColumnHeader[] { colSTT, colSoTK, colTenKH, colDiaChi, colSoTien });

            this.lblTongTien = new Label() { Text = "Tổng tiền", Location = new Point(320, 428), AutoSize = true };
            this.txtTongTien = new TextBox() { Location = new Point(405, 425), Size = new Size(130, 22), ReadOnly = true, TextAlign = HorizontalAlignment.Right };

            // Gán sự kiện
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnThoat.Click += (s, e) => this.Close();
            this.lsvTaiKhoan.SelectedIndexChanged += new System.EventHandler(this.lsvTaiKhoan_SelectedIndexChanged);

            this.ClientSize = new Size(550, 465);
            this.Controls.AddRange(new Control[] { lblTitle, lblSoTK, txtSoTK, lblTenKH, txtTenKH, lblDiaChi, txtDiaChi, lblSoTien, txtSoTien, btnThem, btnLuu, btnXoa, btnThoat, lsvTaiKhoan, lblTongTien, txtTongTien });
            this.Text = "frmBaiTap2";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}