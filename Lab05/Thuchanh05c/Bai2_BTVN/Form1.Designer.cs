using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    partial class frmListbox
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle, lblLeft, lblRight;
        private TextBox txtSo;
        private Button btnNhap;
        private ListBox lstSo;
        private Button btnTong, btnXoaDauCuoi, btnXoaChon, btnTang2, btnBinhPhuong, btnChonChan, btnChonLe, btnKetThuc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label() { Text = "LISTBOX", Font = new Font("Arial", 16, FontStyle.Bold), ForeColor = Color.DarkOrange, Location = new Point(190, 10), AutoSize = true };

            this.lblLeft = new Label() { Text = "Listbox", Location = new Point(40, 50), AutoSize = true };
            this.txtSo = new TextBox() { Location = new Point(40, 72), Size = new Size(160, 22) };
            this.btnNhap = new Button() { Text = "Nhập", Location = new Point(40, 102), Size = new Size(160, 30) };
            // Cho phép chọn nhiều phần tử
            this.lstSo = new ListBox() { Location = new Point(40, 140), Size = new Size(160, 200), SelectionMode = SelectionMode.MultiExtended };

            this.lblRight = new Label() { Text = "Xử lý Listbox", Location = new Point(230, 50), AutoSize = true };
            this.btnTong = new Button() { Text = "Tổng các phần tử trong List", Location = new Point(230, 72), Size = new Size(220, 30) };
            this.btnXoaDauCuoi = new Button() { Text = "Xóa Phần tử đầu và cuối", Location = new Point(230, 110), Size = new Size(220, 30) };
            this.btnXoaChon = new Button() { Text = "Xóa Phần tử đang chọn", Location = new Point(230, 148), Size = new Size(220, 30) };
            this.btnTang2 = new Button() { Text = "Tăng mỗi phần tử lên 2", Location = new Point(230, 186), Size = new Size(220, 30) };
            this.btnBinhPhuong = new Button() { Text = "Thay bằng bình phương", Location = new Point(230, 224), Size = new Size(220, 30) };
            this.btnChonChan = new Button() { Text = "Chọn số chẵn", Location = new Point(230, 262), Size = new Size(220, 30) };
            this.btnChonLe = new Button() { Text = "Chọn số lẻ", Location = new Point(230, 300), Size = new Size(220, 30) };

            this.btnKetThuc = new Button() { Text = "KẾT THÚC", Location = new Point(40, 350), Size = new Size(410, 32) };

            // Gán sự kiện
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            this.btnTong.Click += new System.EventHandler(this.btnTong_Click);
            this.btnXoaDauCuoi.Click += new System.EventHandler(this.btnXoaDauCuoi_Click);
            this.btnXoaChon.Click += new System.EventHandler(this.btnXoaChon_Click);
            this.btnTang2.Click += new System.EventHandler(this.btnTang2_Click);
            this.btnBinhPhuong.Click += new System.EventHandler(this.btnBinhPhuong_Click);
            this.btnChonChan.Click += new System.EventHandler(this.btnChonChan_Click);
            this.btnChonLe.Click += new System.EventHandler(this.btnChonLe_Click);
            this.btnKetThuc.Click += (s, e) => this.Close();

            this.ClientSize = new Size(490, 400);
            this.Controls.AddRange(new Control[] { lblTitle, lblLeft, txtSo, btnNhap, lstSo, lblRight, btnTong, btnXoaDauCuoi, btnXoaChon, btnTang2, btnBinhPhuong, btnChonChan, btnChonLe, btnKetThuc });
            this.Text = "frmListbox";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}