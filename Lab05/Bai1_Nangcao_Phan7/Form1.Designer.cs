using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmQLSinhVien
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaLop, lblMaSV, lblHoTen, lblNgaySinh;
        private TextBox txtMaLop, txtMaSV, txtHoTen;
        private MaskedTextBox mskNgaySinh;
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaLop = new Label() { Text = "Mã lớp", Location = new Point(25, 22), AutoSize = true };
            this.txtMaLop = new TextBox() { Location = new Point(95, 19), Size = new Size(215, 22) };

            this.lblMaSV = new Label() { Text = "Mã sv", Location = new Point(25, 55), AutoSize = true };
            this.txtMaSV = new TextBox() { Location = new Point(95, 52), Size = new Size(215, 22) };

            this.lblHoTen = new Label() { Text = "Họ tên", Location = new Point(25, 88), AutoSize = true };
            this.txtHoTen = new TextBox() { Location = new Point(95, 85), Size = new Size(215, 22) };

            this.lblNgaySinh = new Label() { Text = "Ngày sinh", Location = new Point(25, 121), AutoSize = true };
            this.mskNgaySinh = new MaskedTextBox() { Location = new Point(105, 118), Size = new Size(205, 22), Mask = "00/00/0000" };

            this.btnThem = new Button() { Text = "Thêm", Location = new Point(30, 160), Size = new Size(80, 32) };
            this.btnXoa = new Button() { Text = "Xóa", Location = new Point(125, 160), Size = new Size(80, 32) };
            this.btnSua = new Button() { Text = "Sửa", Location = new Point(220, 160), Size = new Size(80, 32) };

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.ClientSize = new Size(340, 210);
            this.Controls.AddRange(new Control[] { lblMaLop, txtMaLop, lblMaSV, txtMaSV, lblHoTen, txtHoTen, lblNgaySinh, mskNgaySinh, btnThem, btnXoa, btnSua });
            this.Text = "Quản lý sinh viên";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}