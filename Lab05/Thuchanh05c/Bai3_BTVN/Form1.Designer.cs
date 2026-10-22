using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_NangCao
{
    partial class frmBTVN3
    {
        private System.ComponentModel.IContainer components = null;
        private TreeView trvDanhBa;
        private Label lblFirstName, lblLastName;
        private TextBox txtFirstName, txtLastName;
        private Button btnAdd, btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.trvDanhBa = new TreeView() { Location = new Point(12, 12), Size = new Size(210, 340) };

            this.lblFirstName = new Label() { Text = "First Name", Location = new Point(250, 50), AutoSize = true };
            this.txtFirstName = new TextBox() { Location = new Point(350, 47), Size = new Size(160, 22) };

            this.lblLastName = new Label() { Text = "Last Name", Location = new Point(250, 95), AutoSize = true };
            this.txtLastName = new TextBox() { Location = new Point(350, 92), Size = new Size(160, 22) };

            this.btnAdd = new Button() { Text = "Add", Location = new Point(430, 135), Size = new Size(80, 30) };
            this.btnExit = new Button() { Text = "Exit", Location = new Point(460, 200), Size = new Size(80, 30) };

            // Gán sự kiện
            this.Load += new System.EventHandler(this.frmBTVN3_Load);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnExit.Click += (s, e) => this.Close();

            this.ClientSize = new Size(560, 365);
            this.Controls.AddRange(new Control[] { trvDanhBa, lblFirstName, txtFirstName, lblLastName, txtLastName, btnAdd, btnExit });
            this.Text = "frmBTVN2"; // Tiêu đề theo hình mẫu trong đề
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}