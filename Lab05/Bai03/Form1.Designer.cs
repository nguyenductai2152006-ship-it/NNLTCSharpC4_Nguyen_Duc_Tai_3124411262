using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    partial class frmChuoi
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnNgauNhien;
        private ListBox lstTen;
        private Button btnXoaChon, btnXoaTenSon, btnXoaHoLe, btnChuHoa, btnChuThuong, btnHoaDauTu, btnXoaTatCa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnNgauNhien = new Button() { Text = "Nhập tên ngẫu nhiên", Location = new Point(50, 20), Size = new Size(180, 32) };
            // Cho phép chọn nhiều phần tử trên ListBox
            this.lstTen = new ListBox() { Location = new Point(50, 60), Size = new Size(180, 290), SelectionMode = SelectionMode.MultiExtended };

            this.btnXoaChon = new Button() { Text = "Xóa Phần tử đang chọn", Location = new Point(250, 60), Size = new Size(280, 32) };
            this.btnXoaTenSon = new Button() { Text = "Xóa phần tử có tên là Sơn", Location = new Point(250, 100), Size = new Size(280, 32) };
            this.btnXoaHoLe = new Button() { Text = "Xóa Phần tử có họ là Lê", Location = new Point(250, 140), Size = new Size(280, 32) };
            this.btnChuHoa = new Button() { Text = "Chuyển PT đang chọn thành chữ HOA", Location = new Point(250, 180), Size = new Size(280, 32) };
            this.btnChuThuong = new Button() { Text = "Chuyển PT đang chọn thành chữ thường", Location = new Point(250, 220), Size = new Size(280, 32) };
            this.btnHoaDauTu = new Button() { Text = "Chuyển PT đang chọn thành viết Hoa\nđầu mỗi từ", Location = new Point(250, 260), Size = new Size(280, 45) };
            this.btnXoaTatCa = new Button() { Text = "Xóa tất cả các Phần tử", Location = new Point(250, 315), Size = new Size(280, 32) };

            // Gán sự kiện
            this.btnNgauNhien.Click += new System.EventHandler(this.btnNgauNhien_Click);
            this.btnXoaChon.Click += new System.EventHandler(this.btnXoaChon_Click);
            this.btnXoaTenSon.Click += new System.EventHandler(this.btnXoaTenSon_Click);
            this.btnXoaHoLe.Click += new System.EventHandler(this.btnXoaHoLe_Click);
            this.btnChuHoa.Click += new System.EventHandler(this.btnChuHoa_Click);
            this.btnChuThuong.Click += new System.EventHandler(this.btnChuThuong_Click);
            this.btnHoaDauTu.Click += new System.EventHandler(this.btnHoaDauTu_Click);
            this.btnXoaTatCa.Click += new System.EventHandler(this.btnXoaTatCa_Click);
            this.lstTen.DoubleClick += new System.EventHandler(this.lstTen_DoubleClick);

            this.ClientSize = new Size(560, 380);
            this.Controls.AddRange(new Control[] { btnNgauNhien, lstTen, btnXoaChon, btnXoaTenSon, btnXoaHoLe, btnChuHoa, btnChuThuong, btnHoaDauTu, btnXoaTatCa });
            this.Text = "frmChuoi";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}