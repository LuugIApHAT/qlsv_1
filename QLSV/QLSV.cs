using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class QLSV : Form
    {
        public QLSV()
        {
            InitializeComponent();
        }

        // Khởi tạo một bảng tạm để lưu trữ thông tin sinh viên
        DataTable dataTable = new DataTable();

        private void QLSV_Load(object sender, EventArgs e)
        {
            // Cài đặt cột cho DataGridView
            dataTable.Columns.Add("Tên");
            dataTable.Columns.Add("Lớp");
            dataTable.Columns.Add("Giới tính");
            dataTable.Columns.Add("Mã SV");
            dataTable.Columns.Add("Ngành");

            // Liên kết DataGridView với bảng tạm
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e) // Nút "Thêm"
        {
            string gioiTinh = radioButton1.Checked ? "Nam" : "Nữ";

            // Thêm thông tin sinh viên vào bảng
            dataTable.Rows.Add(textBox2.Text, textBox3.Text, gioiTinh, textBox4.Text, textBox5.Text);

            // Xóa dữ liệu trong các ô nhập sau khi thêm
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            // Cho phép nhập lại MSSV (trong trường hợp trước đó đã bị khóa)
            textBox4.Enabled = true; // textBox4 là ô nhập MSSV
        }


        private void button2_Click(object sender, EventArgs e) // Nút "Xóa"
        {
            // Xóa dòng đã chọn trong DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e) // Nút "Sửa"
        {
            // Sửa thông tin sinh viên đã chọn
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Cập nhật thông tin từ các TextBox
                selectedRow.Cells[0].Value = textBox2.Text;
                selectedRow.Cells[1].Value = textBox3.Text;
                selectedRow.Cells[2].Value = radioButton1.Checked ? "Nam" : "Nữ";
                selectedRow.Cells[4].Value = textBox5.Text;

                // Khóa ô nhập MSSV để không cho sửa đổi
                textBox4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e) // Nút "Thoát"
        {
            // Thoát ứng dụng
            this.Close();
        }

        // Các sự kiện không cần thay đổi
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
    }
}
