using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmQLMonHoc
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaMH, lblTenMH;
        private TextBox txtMaMH, txtTenMH;
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaMH = new Label() { Text = "Mã mh", Location = new Point(25, 25), AutoSize = true };
            this.txtMaMH = new TextBox() { Location = new Point(95, 22), Size = new Size(210, 22) };

            this.lblTenMH = new Label() { Text = "Tên mh", Location = new Point(25, 65), AutoSize = true };
            this.txtTenMH = new TextBox() { Location = new Point(95, 62), Size = new Size(210, 22) };

            this.btnThem = new Button() { Text = "Thêm", Location = new Point(30, 110), Size = new Size(80, 32) };
            this.btnXoa = new Button() { Text = "Xóa", Location = new Point(125, 110), Size = new Size(80, 32) };
            this.btnSua = new Button() { Text = "Sửa", Location = new Point(220, 110), Size = new Size(80, 32) };

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.ClientSize = new Size(335, 165);
            this.Controls.AddRange(new Control[] { lblMaMH, txtMaMH, lblTenMH, txtTenMH, btnThem, btnXoa, btnSua });
            this.Text = "Quản lý môn học";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}