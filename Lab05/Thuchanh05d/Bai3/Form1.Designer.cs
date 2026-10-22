using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmQuanLyHocVien
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuCapNhat, mnuKetThuc;
        private ToolStripMenuItem mnuNhapMoi, mnuChuyenSangB, mnuChuyenSangA, mnuXoaHV;
        private GroupBox grpLopA, grpLopB;
        private ListBox lstLopA, lstLopB;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.mnuCapNhat = new ToolStripMenuItem("Cập nhật");
            this.mnuKetThuc = new ToolStripMenuItem("&Kết thúc");

            this.mnuNhapMoi = new ToolStripMenuItem("Nhập học viên mới");
            this.mnuChuyenSangB = new ToolStripMenuItem("Chuyển sang lớp B");
            this.mnuChuyenSangA = new ToolStripMenuItem("Chuyển sang lớp A");
            this.mnuXoaHV = new ToolStripMenuItem("Xóa học viên");

            this.mnuCapNhat.DropDownItems.AddRange(new ToolStripItem[] { mnuNhapMoi, mnuChuyenSangB, mnuChuyenSangA, mnuXoaHV });
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { mnuCapNhat, mnuKetThuc });

            // GroupBox & ListBox Lớp A (Cho phép chọn nhiều mục cùng lúc)
            this.grpLopA = new GroupBox() { Text = "Lớp A", Location = new Point(25, 45), Size = new Size(190, 210) };
            this.lstLopA = new ListBox() { Location = new Point(12, 22), Size = new Size(165, 175), SelectionMode = SelectionMode.MultiExtended };
            this.grpLopA.Controls.Add(this.lstLopA);

            // GroupBox & ListBox Lớp B (Cho phép chọn nhiều mục cùng lúc)
            this.grpLopB = new GroupBox() { Text = "Lớp B", Location = new Point(240, 45), Size = new Size(190, 210) };
            this.lstLopB = new ListBox() { Location = new Point(12, 22), Size = new Size(165, 175), SelectionMode = SelectionMode.MultiExtended };
            this.grpLopB.Controls.Add(this.lstLopB);

            // Gán sự kiện
            this.Load += new System.EventHandler(this.frmQuanLyHocVien_Load);
            this.mnuNhapMoi.Click += new System.EventHandler(this.mnuNhapMoi_Click);
            this.mnuChuyenSangB.Click += new System.EventHandler(this.mnuChuyenSangB_Click);
            this.mnuChuyenSangA.Click += new System.EventHandler(this.mnuChuyenSangA_Click);
            this.mnuXoaHV.Click += new System.EventHandler(this.mnuXoaHV_Click);
            this.mnuKetThuc.Click += new System.EventHandler(this.mnuKetThuc_Click);

            this.ClientSize = new Size(460, 280);
            this.MainMenuStrip = this.menuStrip1;
            this.Controls.AddRange(new Control[] { menuStrip1, grpLopA, grpLopB });
            this.Text = "Quản lý học viên";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}