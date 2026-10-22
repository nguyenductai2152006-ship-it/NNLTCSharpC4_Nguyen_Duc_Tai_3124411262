using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    partial class frmBaiTapTaiLop2
    {
        private System.ComponentModel.IContainer components = null;
        private TreeView trvLop;
        private Label lblChonLop;
        private ComboBox cboLop;
        private GroupBox grpSinhVien;
        private Label lblMaSV, lblHoTen, lblDiaChi;
        private TextBox txtMaSV, txtHoTen, txtDiaChi;
        private Button btnCapNhat, btnXoa;
        private CheckBox chkThemLop;
        private GroupBox grpThongTinLop;
        private Label lblTenLop;
        private TextBox txtTenLop;
        private Button btnThemLop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.trvLop = new TreeView() { Location = new Point(12, 12), Size = new Size(240, 420) };

            this.lblChonLop = new Label() { Text = "Chọn Lớp", Location = new Point(280, 25), AutoSize = true };
            this.cboLop = new ComboBox() { Location = new Point(360, 22), Size = new Size(220, 24), DropDownStyle = ComboBoxStyle.DropDownList };

            this.grpSinhVien = new GroupBox() { Text = "Thông tin sinh viên", Location = new Point(270, 60), Size = new Size(340, 200) };
            this.lblMaSV = new Label() { Text = "Mã SV:", Location = new Point(20, 35), AutoSize = true };
            this.txtMaSV = new TextBox() { Location = new Point(90, 32), Size = new Size(220, 22) };
            this.lblHoTen = new Label() { Text = "Họ Tên:", Location = new Point(20, 75), AutoSize = true };
            this.txtHoTen = new TextBox() { Location = new Point(90, 72), Size = new Size(220, 22) };
            this.lblDiaChi = new Label() { Text = "Địa Chỉ:", Location = new Point(20, 115), AutoSize = true };
            this.txtDiaChi = new TextBox() { Location = new Point(90, 112), Size = new Size(220, 22) };
            this.btnCapNhat = new Button() { Text = "Cập Nhật", Location = new Point(90, 150), Size = new Size(110, 32) };
            this.btnXoa = new Button() { Text = "Xóa", Location = new Point(220, 150), Size = new Size(90, 32) };
            this.grpSinhVien.Controls.AddRange(new Control[] { lblMaSV, txtMaSV, lblHoTen, txtHoTen, lblDiaChi, txtDiaChi, btnCapNhat, btnXoa });

            this.chkThemLop = new CheckBox() { Text = "Thêm lớp", Location = new Point(270, 275), AutoSize = true };

            this.grpThongTinLop = new GroupBox() { Text = "Thông tin lớp", Location = new Point(270, 305), Size = new Size(340, 125) };
            this.lblTenLop = new Label() { Text = "Tên lớp", Location = new Point(20, 35), AutoSize = true };
            this.txtTenLop = new TextBox() { Location = new Point(90, 32), Size = new Size(220, 22) };
            this.btnThemLop = new Button() { Text = "Thêm lớp", Location = new Point(90, 70), Size = new Size(110, 32) };
            this.grpThongTinLop.Controls.AddRange(new Control[] { lblTenLop, txtTenLop, btnThemLop });

            // Gán sự kiện
            this.Load += new System.EventHandler(this.frmBaiTapTaiLop2_Load);
            this.chkThemLop.CheckedChanged += new System.EventHandler(this.chkThemLop_CheckedChanged);
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.trvLop.AfterSelect += new TreeViewEventHandler(this.trvLop_AfterSelect);

            this.ClientSize = new Size(630, 450);
            this.Controls.AddRange(new Control[] { trvLop, lblChonLop, cboLop, grpSinhVien, chkThemLop, grpThongTinLop });
            this.Text = "Quản lý sinh viên";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}