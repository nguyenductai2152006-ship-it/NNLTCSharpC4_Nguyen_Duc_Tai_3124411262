using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmQLSinhVien : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TAIZ-2105\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True");

        public frmQLSinhVien()
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
                else MessageBox.Show("Không có dòng nào được cập nhật!", "Thông báo");
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Thất bại: " + ex.Message, "Lỗi CSDL");
            }
        }

        // 1. Thêm: Cả 4 trường Mã lớp, Mã SV, Họ tên, Ngày sinh không được để trống
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen) || !mskNgaySinh.MaskCompleted)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã lớp, Mã SV, Họ tên và Ngày sinh!");
                return;
            }

            if (!DateTime.TryParseExact(mskNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ (dd/MM/yyyy)!");
                return;
            }

            string sql = $"INSERT INTO SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) VALUES('{maSV}', N'{hoTen}', '{ngaySinh:yyyy-MM-dd}', '{maLop}')";
            ThucThiSQL(sql);
        }

        // 2. Xóa: Mã SV và Họ tên không để trống; Mã lớp và Ngày sinh không nhập dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string ngaySinhRaw = mskNgaySinh.Text.Replace("/", "").Trim();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Mã sinh viên và Họ tên không được để trống khi xóa!");
                return;
            }
            if (!string.IsNullOrEmpty(maLop) || !string.IsNullOrEmpty(ngaySinhRaw))
            {
                MessageBox.Show("Khi xóa không được nhập dữ liệu vào trường Mã lớp và Ngày sinh!");
                return;
            }

            string sql = $"DELETE FROM SinhVien WHERE MaSinhVien = '{maSV}' AND HoTen = N'{hoTen}'";
            ThucThiSQL(sql);
        }

        // 3. Sửa: Mã SV không trống; ít nhất 1 trong 3 trường (Mã lớp, Họ tên, Ngày sinh) có dữ liệu. Trường nào nhập mới sửa.
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string ngaySinhRaw = mskNgaySinh.Text.Replace("/", "").Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Mã sinh viên không được để trống khi sửa!");
                return;
            }

            List<string> capNhat = new List<string>();
            if (!string.IsNullOrEmpty(maLop)) capNhat.Add($"MaLop = '{maLop}'");
            if (!string.IsNullOrEmpty(hoTen)) capNhat.Add($"HoTen = N'{hoTen}'");
            if (!string.IsNullOrEmpty(ngaySinhRaw))
            {
                if (DateTime.TryParseExact(mskNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ns))
                    capNhat.Add($"NgaySinh = '{ns:yyyy-MM-dd}'");
                else
                {
                    MessageBox.Show("Ngày sinh không đúng định dạng dd/MM/yyyy!");
                    return;
                }
            }

            if (capNhat.Count == 0)
            {
                MessageBox.Show("Phải nhập ít nhất một trong các trường: Mã lớp, Họ tên hoặc Ngày sinh để sửa!");
                return;
            }

            string sql = $"UPDATE SinhVien SET {string.Join(", ", capNhat)} WHERE MaSinhVien = '{maSV}'";
            ThucThiSQL(sql);
        }
    }
}