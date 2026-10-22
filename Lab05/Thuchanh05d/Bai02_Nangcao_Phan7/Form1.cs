using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmQLDiem : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TAIZ-2105\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True");

        public frmQLDiem()
        {
            InitializeComponent();
        }

        private void ThucThiSQL(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();

                if (kq > 0) MessageBox.Show("Thành công!", "Thông báo");
                else MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo");
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Thất bại: " + ex.Message, "Lỗi CSDL");
            }
        }

        // 1. Thêm: Mã SV, Mã MH, Điểm không được để trống
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();
            string diemStr = txtDiem.Text.Trim();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMH) || string.IsNullOrEmpty(diemStr))
            {
                MessageBox.Show("Mã sinh viên, Mã môn học và Điểm không được để trống!");
                return;
            }
            if (!double.TryParse(diemStr, out double diem))
            {
                MessageBox.Show("Điểm phải là một số hợp lệ!");
                return;
            }

            string sql = $"INSERT INTO Diem VALUES('{maSV}', '{maMH}', {diem.ToString(CultureInfo.InvariantCulture)})";
            ThucThiSQL(sql);
        }

        // 2. Xóa: Mã SV, Mã MH không để trống, Điểm không nhập dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();
            string diemStr = txtDiem.Text.Trim();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMH))
            {
                MessageBox.Show("Mã sinh viên và Mã môn học không được để trống!");
                return;
            }
            if (!string.IsNullOrEmpty(diemStr))
            {
                MessageBox.Show("Khi xóa không được nhập dữ liệu vào ô Điểm!");
                return;
            }

            string sql = $"DELETE FROM Diem WHERE MaSinhVien = '{maSV}' AND MaMonHoc = '{maMH}'";
            ThucThiSQL(sql);
        }

        // 3. Sửa: Mã SV, Mã MH không trống; Điểm phải nhập dữ liệu và chỉ được nhập số
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();
            string diemStr = txtDiem.Text.Trim();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMH) || string.IsNullOrEmpty(diemStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã SV, Mã MH và Điểm!");
                return;
            }
            if (!double.TryParse(diemStr, out double diem))
            {
                MessageBox.Show("Trường Điểm chỉ được phép nhập số!");
                txtDiem.Focus();
                return;
            }

            string sql = $"UPDATE Diem SET Diem = {diem.ToString(CultureInfo.InvariantCulture)} WHERE MaSinhVien = '{maSV}' AND MaMonHoc = '{maMH}'";
            ThucThiSQL(sql);
        }
    }
}