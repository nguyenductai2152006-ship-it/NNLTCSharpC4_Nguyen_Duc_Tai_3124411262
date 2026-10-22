using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmBaitap1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHoTen, lblMaSV, lblGioiTinh, lblNgoaiNgu, lblDanToc;
        private TextBox txtHoTen, txtMaSV;
        private RadioButton radNam, radNu;
        private CheckBox chkAnh, chkPhap, chkHoa;
        private ComboBox cboDanToc;
        private ListView lsvSinhVien;
        private ColumnHeader colHoTen, colMaSV, colGioiTinh, colNgoaiNgu, colDanToc;
        private Button btnThem, btnXoa, btnSua;
        private ContextMenuStrip cmsXoa;
        private ToolStripMenuItem mnuXoa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHoTen = new Label() { Text = "Họ và Tên", Location = new Point(70, 25), AutoSize = true };
            this.txtHoTen = new TextBox() { Location = new Point(210, 22), Size = new Size(230, 22) };

            this.lblMaSV = new Label() { Text = "Mã sinh viên", Location = new Point(70, 62), AutoSize = true };
            this.txtMaSV = new TextBox() { Location = new Point(210, 59), Size = new Size(230, 22) };

            this.lblGioiTinh = new Label() { Text = "Giới tính", Location = new Point(70, 98), AutoSize = true };
            this.radNam = new RadioButton() { Text = "Nam", Location = new Point(210, 96), AutoSize = true, Checked = true };
            this.radNu = new RadioButton() { Text = "Nữ", Location = new Point(310, 96), AutoSize = true };

            this.lblNgoaiNgu = new Label() { Text = "Ngoại ngữ", Location = new Point(70, 134), AutoSize = true };
            this.chkAnh = new CheckBox() { Text = "Anh", Location = new Point(210, 133), AutoSize = true, Checked = true };
            this.chkPhap = new CheckBox() { Text = "Pháp", Location = new Point(295, 133), AutoSize = true };
            this.chkHoa = new CheckBox() { Text = "Hoa", Location = new Point(380, 133), AutoSize = true };

            this.lblDanToc = new Label() { Text = "Dân tộc", Location = new Point(70, 170), AutoSize = true };
            this.cboDanToc = new ComboBox() { Location = new Point(210, 167), Size = new Size(230, 24), DropDownStyle = ComboBoxStyle.DropDownList };

            // Khởi tạo ContextMenuStrip chuột phải để xóa
            this.cmsXoa = new ContextMenuStrip(this.components);
            this.mnuXoa = new ToolStripMenuItem("Xóa dòng đang chọn");
            this.cmsXoa.Items.Add(this.mnuXoa);

            // Khởi tạo ListView
            this.lsvSinhVien = new ListView()
            {
                Location = new Point(15, 210),
                Size = new Size(510, 180),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                ContextMenuStrip = this.cmsXoa
            };
            this.colHoTen = new ColumnHeader() { Text = "Họ tên", Width = 130 };
            this.colMaSV = new ColumnHeader() { Text = "Mã sinh viên", Width = 95 };
            this.colGioiTinh = new ColumnHeader() { Text = "Giới tính", Width = 75 };
            this.colNgoaiNgu = new ColumnHeader() { Text = "Ngoại ngữ", Width = 115 };
            this.colDanToc = new ColumnHeader() { Text = "Dân tộc", Width = 90 };
            this.lsvSinhVien.Columns.AddRange(new ColumnHeader[] { colHoTen, colMaSV, colGioiTinh, colNgoaiNgu, colDanToc });

            // Các Button chức năng
            this.btnThem = new Button() { Text = "Thêm", Location = new Point(90, 405), Size = new Size(95, 38) };
            this.btnXoa = new Button() { Text = "Xóa", Location = new Point(225, 405), Size = new Size(95, 38) };
            this.btnSua = new Button() { Text = "Sửa", Location = new Point(355, 405), Size = new Size(95, 38) };

            // Gán sự kiện
            this.Load += new System.EventHandler(this.frmBaitap1_Load);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.mnuXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.lsvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lsvSinhVien_SelectedIndexChanged);
            this.FormClosing += new FormClosingEventHandler(this.frmBaitap1_FormClosing);

            this.ClientSize = new Size(540, 460);
            this.Controls.AddRange(new Control[] { lblHoTen, txtHoTen, lblMaSV, txtMaSV, lblGioiTinh, radNam, radNu, lblNgoaiNgu, chkAnh, chkPhap, chkHoa, lblDanToc, cboDanToc, lsvSinhVien, btnThem, btnXoa, btnSua });
            this.Text = "frmBaitap1";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}