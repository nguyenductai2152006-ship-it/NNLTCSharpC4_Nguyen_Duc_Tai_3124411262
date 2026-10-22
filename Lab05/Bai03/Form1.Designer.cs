
namespace BT_WinForm_NangCao
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnNhapTenNgauNhien = new System.Windows.Forms.Button();
            this.lstDanhSachTen = new System.Windows.Forms.ListBox();
            this.btnXoaDangChon = new System.Windows.Forms.Button();
            this.btnXoaTenSon = new System.Windows.Forms.Button();
            this.btnXoaHoLe = new System.Windows.Forms.Button();
            this.btnChuyenChuHoa = new System.Windows.Forms.Button();
            this.btnChuyenChuThuong = new System.Windows.Forms.Button();
            this.btnVietHoaDauTu = new System.Windows.Forms.Button();
            this.btnXoaTatCa = new System.Windows.Forms.Button();

            this.SuspendLayout();

            //
            // btnNhapTenNgauNhien
            //
            this.btnNhapTenNgauNhien.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.btnNhapTenNgauNhien.Location =
                new System.Drawing.Point(90, 28);

            this.btnNhapTenNgauNhien.Name =
                "btnNhapTenNgauNhien";

            this.btnNhapTenNgauNhien.Size =
                new System.Drawing.Size(205, 40);

            this.btnNhapTenNgauNhien.TabIndex = 0;
            this.btnNhapTenNgauNhien.Text = "Nhập tên ngẫu nhiên";
            this.btnNhapTenNgauNhien.UseVisualStyleBackColor = true;

            //
            // lstDanhSachTen
            //
            this.lstDanhSachTen.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.lstDanhSachTen.FormattingEnabled = true;
            this.lstDanhSachTen.IntegralHeight = false;
            this.lstDanhSachTen.ItemHeight = 18;

            this.lstDanhSachTen.Location =
                new System.Drawing.Point(90, 77);

            this.lstDanhSachTen.Name = "lstDanhSachTen";

            this.lstDanhSachTen.Size =
                new System.Drawing.Size(205, 365);

            this.lstDanhSachTen.TabIndex = 1;

            this.lstDanhSachTen.SelectionMode =
                System.Windows.Forms.SelectionMode.MultiExtended;

            //
            // btnXoaDangChon
            //
            this.btnXoaDangChon.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.btnXoaDangChon.Location =
                new System.Drawing.Point(305, 87);

            this.btnXoaDangChon.Name = "btnXoaDangChon";

            this.btnXoaDangChon.Size =
                new System.Drawing.Size(350, 40);

            this.btnXoaDangChon.TabIndex = 2;
            this.btnXoaDangChon.Text = "Xóa Phần tử đang chọn";
            this.btnXoaDangChon.UseVisualStyleBackColor = true;

            //
            // btnXoaTenSon
            //
            this.btnXoaTenSon.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.btnXoaTenSon.Location =
                new System.Drawing.Point(305, 137);

            this.btnXoaTenSon.Name = "btnXoaTenSon";

            this.btnXoaTenSon.Size =
                new System.Drawing.Size(350, 40);

            this.btnXoaTenSon.TabIndex = 3;
            this.btnXoaTenSon.Text = "Xóa phần tử có tên là Sơn";
            this.btnXoaTenSon.UseVisualStyleBackColor = true;

            //
            // btnXoaHoLe
            //
            this.btnXoaHoLe.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.btnXoaHoLe.Location =
                new System.Drawing.Point(305, 187);

            this.btnXoaHoLe.Name = "btnXoaHoLe";

            this.btnXoaHoLe.Size =
                new System.Drawing.Size(350, 40);

            this.btnXoaHoLe.TabIndex = 4;
            this.btnXoaHoLe.Text = "Xóa Phần tử có họ là Lê";
            this.btnXoaHoLe.UseVisualStyleBackColor = true;

            //
            // btnChuyenChuHoa
            //
            this.btnChuyenChuHoa.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.btnChuyenChuHoa.Location =
                new System.Drawing.Point(305, 237);

            this.btnChuyenChuHoa.Name = "btnChuyenChuHoa";

            this.btnChuyenChuHoa.Size =
                new System.Drawing.Size(350, 40);

            this.btnChuyenChuHoa.TabIndex = 5;
            this.btnChuyenChuHoa.Text =
                "Chuyển PT đang chọn thành chữ HOA";

            this.btnChuyenChuHoa.UseVisualStyleBackColor = true;

            //
            // btnChuyenChuThuong
            //
            this.btnChuyenChuThuong.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.btnChuyenChuThuong.Location =
                new System.Drawing.Point(305, 287);

            this.btnChuyenChuThuong.Name = "btnChuyenChuThuong";

            this.btnChuyenChuThuong.Size =
                new System.Drawing.Size(350, 40);

            this.btnChuyenChuThuong.TabIndex = 6;
            this.btnChuyenChuThuong.Text =
                "Chuyển PT đang chọn thành chữ thường";

            this.btnChuyenChuThuong.UseVisualStyleBackColor = true;

            //
            // btnVietHoaDauTu
            //
            this.btnVietHoaDauTu.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.btnVietHoaDauTu.Location =
                new System.Drawing.Point(305, 337);

            this.btnVietHoaDauTu.Name = "btnVietHoaDauTu";

            this.btnVietHoaDauTu.Size =
                new System.Drawing.Size(350, 57);

            this.btnVietHoaDauTu.TabIndex = 7;
            this.btnVietHoaDauTu.Text =
                "Chuyển PT đang chọn thành viết Hoa\r\nđầu mỗi từ";

            this.btnVietHoaDauTu.UseVisualStyleBackColor = true;

            //
            // btnXoaTatCa
            //
            this.btnXoaTatCa.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif", 11F);

            this.btnXoaTatCa.Location =
                new System.Drawing.Point(305, 404);

            this.btnXoaTatCa.Name = "btnXoaTatCa";

            this.btnXoaTatCa.Size =
                new System.Drawing.Size(350, 40);

            this.btnXoaTatCa.TabIndex = 8;
            this.btnXoaTatCa.Text = "Xóa tất cả các Phần tử";
            this.btnXoaTatCa.UseVisualStyleBackColor = true;

            //
            // Form1
            //
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.SystemColors.Control;

            this.ClientSize =
                new System.Drawing.Size(675, 460);

            this.Controls.Add(this.btnNhapTenNgauNhien);
            this.Controls.Add(this.lstDanhSachTen);
            this.Controls.Add(this.btnXoaDangChon);
            this.Controls.Add(this.btnXoaTenSon);
            this.Controls.Add(this.btnXoaHoLe);
            this.Controls.Add(this.btnChuyenChuHoa);
            this.Controls.Add(this.btnChuyenChuThuong);
            this.Controls.Add(this.btnVietHoaDauTu);
            this.Controls.Add(this.btnXoaTatCa);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.Name = "Form1";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "frmChuoi";

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnNhapTenNgauNhien;
        private System.Windows.Forms.ListBox lstDanhSachTen;
        private System.Windows.Forms.Button btnXoaDangChon;
        private System.Windows.Forms.Button btnXoaTenSon;
        private System.Windows.Forms.Button btnXoaHoLe;
        private System.Windows.Forms.Button btnChuyenChuHoa;
        private System.Windows.Forms.Button btnChuyenChuThuong;
        private System.Windows.Forms.Button btnVietHoaDauTu;
        private System.Windows.Forms.Button btnXoaTatCa;
    }
}
