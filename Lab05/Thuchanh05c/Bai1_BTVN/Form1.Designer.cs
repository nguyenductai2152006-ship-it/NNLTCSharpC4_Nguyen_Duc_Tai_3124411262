using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    partial class frmTuDien
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabTuDien;
        private TabPage tabAnhViet, tabVietAnh;
        private Label lblTA, lblTV, lblTV2, lblTA2;
        private ComboBox cboAnhViet, cboVietAnh;
        private TextBox txtNghiaTV, txtNghiaTA;
        private Button btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabTuDien = new TabControl() { Location = new Point(20, 15), Size = new Size(460, 320) };

            // Tab Anh - Việt
            this.tabAnhViet = new TabPage("ANH - VIỆT");
            this.lblTA = new Label() { Text = "Tiếng Anh", Location = new Point(15, 15), AutoSize = true };
            this.lblTV = new Label() { Text = "Tiếng Việt", Location = new Point(230, 15), AutoSize = true };
            // DropDownStyle = Simple để hiển thị luôn danh sách bên dưới giống giao diện đề bài
            this.cboAnhViet = new ComboBox() { Location = new Point(15, 40), Size = new Size(190, 240), DropDownStyle = ComboBoxStyle.Simple };
            this.txtNghiaTV = new TextBox() { Location = new Point(230, 40), Size = new Size(200, 240), Multiline = true, ReadOnly = true };
            this.tabAnhViet.Controls.AddRange(new Control[] { lblTA, lblTV, cboAnhViet, txtNghiaTV });

            // Tab Việt - Anh
            this.tabVietAnh = new TabPage("VIỆT - ANH");
            this.lblTV2 = new Label() { Text = "Tiếng Việt", Location = new Point(15, 15), AutoSize = true };
            this.lblTA2 = new Label() { Text = "Tiếng Anh", Location = new Point(230, 15), AutoSize = true };
            this.cboVietAnh = new ComboBox() { Location = new Point(15, 40), Size = new Size(190, 240), DropDownStyle = ComboBoxStyle.Simple };
            this.txtNghiaTA = new TextBox() { Location = new Point(230, 40), Size = new Size(200, 240), Multiline = true, ReadOnly = true };
            this.tabVietAnh.Controls.AddRange(new Control[] { lblTV2, lblTA2, cboVietAnh, txtNghiaTA });

            this.tabTuDien.TabPages.AddRange(new TabPage[] { tabAnhViet, tabVietAnh });
            this.btnThoat = new Button() { Text = "Thoát", Location = new Point(380, 345), Size = new Size(100, 30) };

            // Gán sự kiện
            this.Load += new System.EventHandler(this.frmTuDien_Load);
            this.cboAnhViet.KeyDown += new KeyEventHandler(this.cboAnhViet_KeyDown);
            this.cboAnhViet.DoubleClick += new System.EventHandler(this.cboAnhViet_DoubleClick);
            this.cboVietAnh.KeyDown += new KeyEventHandler(this.cboVietAnh_KeyDown);
            this.cboVietAnh.DoubleClick += new System.EventHandler(this.cboVietAnh_DoubleClick);
            this.btnThoat.Click += (s, e) => this.Close();

            this.ClientSize = new Size(500, 390);
            this.Controls.AddRange(new Control[] { tabTuDien, btnThoat });
            this.Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}