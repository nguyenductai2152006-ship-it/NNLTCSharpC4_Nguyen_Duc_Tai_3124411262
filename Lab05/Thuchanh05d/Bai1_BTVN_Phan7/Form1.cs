using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmLop : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TAIZ-2105\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True");

        public frmLop()
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
                else MessageBox.Show("Không tìm thấy Mã lớp tương ứng!", "Thông báo");
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Thất bại: " + ex.Message, "Lỗi CSDL");
            }
        }

        // 1. Thêm: Mã khoa, Mã lớp, Tên lớp không được để trống
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maKhoa = txtMaKhoa.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            if (string.IsNullOrEmpty(maKhoa) || string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Mã khoa, Mã lớp và Tên lớp không được để trống!");
                return;
            }

            // Cấu trúc bảng Lop(MaLop, TenLop, MaKhoa)
            string sql = $"INSERT INTO Lop(MaLop, TenLop, MaKhoa) VALUES('{maLop}', N'{tenLop}', '{maKhoa}')";
            ThucThiSQL(sql);
        }

        // 2. Xóa: Mã lớp không để trống; Mã khoa và Tên lớp không nhập dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKhoa = txtMaKhoa.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Mã lớp không được để trống khi xóa!");
                return;
            }
            if (!string.IsNullOrEmpty(maKhoa) || !string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Khi xóa chỉ nhập Mã lớp, không nhập Mã khoa và Tên lớp!");
                return;
            }

            string sql = $"DELETE FROM Lop WHERE MaLop = '{maLop}'";
            ThucThiSQL(sql);
        }

        // 3. Sửa: Mã lớp không để trống; Mã khoa, Tên lớp phải có ít nhất 1 trường có dữ liệu
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKhoa = txtMaKhoa.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Mã lớp không được để trống khi sửa!");
                return;
            }

            List<string> capNhat = new List<string>();
            if (!string.IsNullOrEmpty(maKhoa)) capNhat.Add($"MaKhoa = '{maKhoa}'");
            if (!string.IsNullOrEmpty(tenLop)) capNhat.Add($"TenLop = N'{tenLop}'");

            if (capNhat.Count == 0)
            {
                MessageBox.Show("Phải nhập ít nhất một trong hai trường (Mã khoa hoặc Tên lớp) để sửa!");
                return;
            }

            string sql = $"UPDATE Lop SET {string.Join(", ", capNhat)} WHERE MaLop = '{maLop}'";
            ThucThiSQL(sql);
        }
    }
}