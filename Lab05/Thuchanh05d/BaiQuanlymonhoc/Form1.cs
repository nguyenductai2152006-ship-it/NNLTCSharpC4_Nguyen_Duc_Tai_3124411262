using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BT_WinForm_05d
{
    public partial class frmQLMonHoc : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True");

        public frmQLMonHoc()
        {
            InitializeComponent();
        }

        // Hàm thực thi câu lệnh Insert / Update / Delete dùng chung
        private void ThucThiSQL(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();

                if (kq > 0) MessageBox.Show("Thực hiện thành công!", "Thông báo");
                else MessageBox.Show("Không tìm thấy dữ liệu thỏa điều kiện!", "Thông báo");
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Thất bại: " + ex.Message, "Lỗi CSDL");
            }
        }

        // 1. Thêm: Mã môn học và Tên môn học không được để trống
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaMH.Text.Trim();
            string ten = txtTenMH.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Mã môn học và Tên môn học không được để trống!");
                return;
            }

            string sql = $"INSERT INTO MonHoc VALUES('{ma}', N'{ten}')";
            ThucThiSQL(sql);
        }

        // 2. Xóa: Mã môn học không để trống, Tên môn học không nhập dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaMH.Text.Trim();
            string ten = txtTenMH.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng nhập Mã môn học cần xóa!");
                return;
            }
            if (!string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Khi xóa chỉ nhập Mã môn học, trường Tên môn học phải để trống!");
                return;
            }

            string sql = $"DELETE FROM MonHoc WHERE MaMonHoc = '{ma}'";
            ThucThiSQL(sql);
        }

        // 3. Sửa: Mã môn học và Tên môn học không được để trống
        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaMH.Text.Trim();
            string ten = txtTenMH.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Mã môn học và Tên môn học không được để trống khi sửa!");
                return;
            }

            string sql = $"UPDATE MonHoc SET TenMonHoc = N'{ten}' WHERE MaMonHoc = '{ma}'";
            ThucThiSQL(sql);
        }
    }
}