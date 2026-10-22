using System;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmDongHo : Form
    {
        // Đếm ngược từ 30 phút 00 giây (Tổng = 1800 giây)
        private int tongGiay = 30 * 60;

        public frmDongHo()
        {
            InitializeComponent();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
                btnBatDau.Text = "Tạm dừng";
            }
            else
            {
                timer1.Stop();
                btnBatDau.Text = "Bắt đầu";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tongGiay > 0)
            {
                tongGiay--;
                int phut = tongGiay / 60;
                int giay = tongGiay % 60;
                lblThoiGian.Text = $"{phut:D2}:{giay:D2}";
            }
            else
            {
                timer1.Stop();
                btnBatDau.Text = "Bắt đầu";
                MessageBox.Show("Đã hết thời gian!", "Thông báo");
            }
        }
    }
}