using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmQLDiem
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaSV, lblMaMH, lblDiem;
        private TextBox txtMaSV, txtMaMH, txtDiem;
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaSV = new Label() { Text = "Mã sv", Location = new Point(25, 22), AutoSize = true };
            this.txtMaSV = new TextBox() { Location = new Point(90, 19), Size = new Size(210, 22) };

            this.lblMaMH = new Label() { Text = "Mã mh", Location = new Point(25, 58), AutoSize = true };
            this.txtMaMH = new TextBox() { Location = new Point(90, 55), Size = new Size(210, 22) };

            this.lblDiem = new Label() { Text = "Điểm", Location = new Point(25, 94), AutoSize = true };
            this.txtDiem = new TextBox() { Location = new Point(90, 91), Size = new Size(210, 22) };

            this.btnThem = new Button() { Text = "Thêm", Location = new Point(25, 135), Size = new Size(80, 32) };
            this.btnXoa = new Button() { Text = "Xóa", Location = new Point(120, 135), Size = new Size(80, 32) };
            this.btnSua = new Button() { Text = "Sửa", Location = new Point(215, 135), Size = new Size(80, 32) };

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.ClientSize = new Size(325, 185);
            this.Controls.AddRange(new Control[] { lblMaSV, txtMaSV, lblMaMH, txtMaMH, lblDiem, txtDiem, btnThem, btnXoa, btnSua });
            this.Text = "Quản lý Điểm";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}