using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmMainTuan6
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuBai1, mnuBai2, mnuBaiNC, mnuDongHo;
        private ToolStripMenuItem mnuCSDL, mnuQLMonHoc, mnuQLSinhVien, mnuQLDiem, mnuQLLop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.mnuBai1 = new ToolStripMenuItem("Bài 1 (Tại lớp)");
            this.mnuBai2 = new ToolStripMenuItem("Bài 2 (Tại lớp)");
            this.mnuBaiNC = new ToolStripMenuItem("Bài Nâng cao (QL Học viên)");
            this.mnuDongHo = new ToolStripMenuItem("BTVN 1 (Đồng hồ)");

            // Nhóm Menu cho Bài 7 (CSDL ADO.NET) trong cùng file PDF
            this.mnuCSDL = new ToolStripMenuItem("Bài 7 (CSDL ADO.NET)");
            this.mnuQLMonHoc = new ToolStripMenuItem("Quản lý Môn học");
            this.mnuQLSinhVien = new ToolStripMenuItem("Quản lý Sinh viên");
            this.mnuQLDiem = new ToolStripMenuItem("Quản lý Điểm");
            this.mnuQLLop = new ToolStripMenuItem("Quản lý Lớp");
            this.mnuCSDL.DropDownItems.AddRange(new ToolStripItem[] { mnuQLMonHoc, mnuQLSinhVien, mnuQLDiem, mnuQLLop });

            this.menuStrip1.Items.AddRange(new ToolStripItem[] { mnuBai1, mnuBai2, mnuBaiNC, mnuDongHo, mnuCSDL });

            // Gán sự kiện mở các Form tương ứng
            this.mnuBai1.Click += (s, e) => MoFormCon(new frmBaitap1());
            this.mnuBai2.Click += (s, e) => MoFormCon(new frmBaiTap2());
            this.mnuBaiNC.Click += (s, e) => MoFormCon(new frmQuanLyHocVien());
            this.mnuDongHo.Click += (s, e) => MoFormCon(new frmDongHo());
            this.mnuQLMonHoc.Click += (s, e) => MoFormCon(new frmQLMonHoc());
            this.mnuQLSinhVien.Click += (s, e) => MoFormCon(new frmQLSinhVien());
            this.mnuQLDiem.Click += (s, e) => MoFormCon(new frmQLDiem());
            this.mnuQLLop.Click += (s, e) => MoFormCon(new frmLop());

            this.IsMdiContainer = true; // Thiết lập làm Form cha MDI
            this.ClientSize = new Size(800, 600);
            this.MainMenuStrip = this.menuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Text = "BTVN_Tuan6";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}