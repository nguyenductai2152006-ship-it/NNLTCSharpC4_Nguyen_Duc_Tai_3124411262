using System.Drawing;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    partial class frmDongHo
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblThoiGian;
        private Button btnBatDau;
        private Timer timer1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblThoiGian = new Label()
            {
                Text = "30:00",
                Font = new Font("Consolas", 18, FontStyle.Bold),
                Location = new Point(75, 18),
                AutoSize = true
            };

            this.btnBatDau = new Button() { Text = "Bắt đầu", Location = new Point(72, 58), Size = new Size(85, 35) };
            this.timer1 = new Timer(this.components) { Interval = 1000 }; // Mỗi 1 giây (1000ms) giảm 1 đơn vị

            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            this.ClientSize = new Size(230, 115);
            this.Controls.AddRange(new Control[] { lblThoiGian, btnBatDau });
            this.Text = "Đồng hồ";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}