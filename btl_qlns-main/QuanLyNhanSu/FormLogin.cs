using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ALLIGATOR;Initial Catalog=QLNS;Integrated Security=True");
        private void FormLogin_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string user_password = txtMatKhau.Text;
            try
            {
                String query = "SELECT * FROM Accounts WHERE username = '" + txtTaiKhoan.Text + "' AND password = '" + txtMatKhau.Text + "'";

                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    username = txtTaiKhoan.Text;
                    user_password = txtMatKhau.Text;

                    FormMain fm = new FormMain();
                    fm.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult res;
                    res = MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Clear();
                    txtMatKhau.Clear();

                    txtTaiKhoan.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
 
}
