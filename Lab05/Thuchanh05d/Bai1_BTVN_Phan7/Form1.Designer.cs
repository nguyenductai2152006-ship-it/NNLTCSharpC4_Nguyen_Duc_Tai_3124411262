using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmLop
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaKhoa, lblMaLop, lblTenLop;
        private TextBox txtMaKhoa, txtMaLop, txtTenLop;
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaKhoa = new Label() { Text = "Mã khoa", Location = new Point(25, 22), AutoSize = true };
            this.txtMaKhoa = new TextBox() { Location = new Point(90, 19), Size = new Size(210, 22) };

            this.lblMaLop = new Label() { Text = "Mã lớp", Location = new Point(25, 58), AutoSize = true };
            this.txtMaLop = new TextBox() { Location = new Point(90, 55), Size = new Size(210, 22) };

            this.lblTenLop = new Label() { Text = "Tên lớp", Location = new Point(25, 94), AutoSize = true };
            this.txtTenLop = new TextBox() { Location = new Point(90, 91), Size = new Size(210, 22) };

            this.btnThem = new Button() { Text = "Thêm", Location = new Point(25, 135), Size = new Size(80, 32) };
            this.btnXoa = new Button() { Text = "Xóa", Location = new Point(120, 135), Size = new Size(80, 32) };
            this.btnSua = new Button() { Text = "Sửa", Location = new Point(215, 135), Size = new Size(80, 32) };

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.ClientSize = new Size(325, 185);
            this.Controls.AddRange(new Control[] { lblMaKhoa, txtMaKhoa, lblMaLop, txtMaLop, lblTenLop, txtTenLop, btnThem, btnXoa, btnSua });
            this.Text = "frmLop";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}