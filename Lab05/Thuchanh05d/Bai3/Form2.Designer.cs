using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmNhapHocVienMoi
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHoTen, lblLop;
        private TextBox txtHoTen;
        private ComboBox cboLop;
        private Button btnCapNhat, btnTroVe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHoTen = new Label() { Text = "Họ và Tên", Location = new Point(35, 30), AutoSize = true };
            this.txtHoTen = new TextBox() { Location = new Point(130, 27), Size = new Size(210, 22) };

            this.lblLop = new Label() { Text = "Lớp", Location = new Point(35, 72), AutoSize = true };
            this.cboLop = new ComboBox() { Location = new Point(130, 69), Size = new Size(210, 24), DropDownStyle = ComboBoxStyle.DropDownList };

            this.btnCapNhat = new Button() { Text = "Cập nhật", Location = new Point(130, 120), Size = new Size(95, 32) };
            this.btnTroVe = new Button() { Text = "Trở về", Location = new Point(245, 120), Size = new Size(95, 32) };

            this.Load += new System.EventHandler(this.frmNhapHocVienMoi_Load);
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            this.btnTroVe.Click += (s, e) => this.Close();

            this.ClientSize = new Size(380, 180);
            this.Controls.AddRange(new Control[] { lblHoTen, txtHoTen, lblLop, cboLop, btnCapNhat, btnTroVe });
            this.Text = "Nhập học viên mới";
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}