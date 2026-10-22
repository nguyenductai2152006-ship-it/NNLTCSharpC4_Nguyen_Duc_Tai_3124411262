using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    partial class frmBaiTapTaiLop1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblNhapSo;
        private TextBox txtNhapSo;
        private Button btnCapNhat;
        private ComboBox cboSo;
        private Label lblUocSo;
        private ListBox lstUocSo;
        private Button btnTongUoc;
        private Button btnUocChan;
        private Button btnUocNguyenTo;
        private Button btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNhapSo = new Label() { Text = "Nhập Số", Location = new Point(50, 25), AutoSize = true };
            this.txtNhapSo = new TextBox() { Location = new Point(50, 55), Size = new Size(110, 22) };
            // Ký tự '&' giúp tạo HotKey (Alt + C)
            this.btnCapNhat = new Button() { Text = "&Cập nhật", Location = new Point(170, 52), Size = new Size(75, 28) };
            this.cboSo = new ComboBox() { Location = new Point(50, 100), Size = new Size(195, 24), DropDownStyle = ComboBoxStyle.DropDownList };

            this.lblUocSo = new Label() { Text = "Danh sách các ước số", Location = new Point(290, 25), AutoSize = true };
            this.lstUocSo = new ListBox() { Location = new Point(290, 50), Size = new Size(230, 100) };

            this.btnTongUoc = new Button() { Text = "&Tổng các ước số", Location = new Point(290, 165), Size = new Size(230, 30) };
            this.btnUocChan = new Button() { Text = "&Số lượng các ước số chẵn", Location = new Point(290, 205), Size = new Size(230, 30) };
            this.btnUocNguyenTo = new Button() { Text = "Số lượng các ước số &nguyên tố", Location = new Point(290, 245), Size = new Size(230, 30) };
            this.btnThoat = new Button() { Text = "Th&oát", Location = new Point(165, 245), Size = new Size(80, 30) };

            // Gán sự kiện
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            this.cboSo.SelectedIndexChanged += new System.EventHandler(this.cboSo_SelectedIndexChanged);
            this.btnTongUoc.Click += new System.EventHandler(this.btnTongUoc_Click);
            this.btnUocChan.Click += new System.EventHandler(this.btnUocChan_Click);
            this.btnUocNguyenTo.Click += new System.EventHandler(this.btnUocNguyenTo_Click);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.ClientSize = new Size(560, 300);
            this.Controls.AddRange(new Control[] { lblNhapSo, txtNhapSo, btnCapNhat, cboSo, lblUocSo, lstUocSo, btnTongUoc, btnUocChan, btnUocNguyenTo, btnThoat });
            this.Text = "Combobox";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}