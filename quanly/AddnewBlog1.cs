using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanly
{
    public partial class AddnewBlog : Form
    {
        string connectionString = Program.connectString;
        public AddnewBlog()
        {
            InitializeComponent();
        }
        private bool IsTitleExists(string title)
        {
            string query = "SELECT COUNT(*) FROM Post WHERE title = @title";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string  Title = titlebox.Text;
            string Content = textBox.Text;
            string Author = authorbox.Text;
            string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string imageURL = "";

            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                string imageName = Path.GetFileName(selectedImagePath);
                string savePath = Path.Combine(Application.StartupPath, "Images", imageName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath)); // Tạo folder nếu chưa có
                File.Copy(selectedImagePath, savePath, true); // Copy ảnh
                imageURL = "Images/" + imageName; // Đường dẫn tương đối lưu vào DB
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Post (title,content,author,createdAt,imageURL) VALUES (@Title,@Content,@Author,@Time,@URL)";
                if (IsTitleExists(Title))
                {
                    MessageBox.Show("Tên bài báo đã tồn tại!");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Content))
                {
                    MessageBox.Show("Tiêu đề và nội dung không được để trống!");
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@Content", Content);
                    cmd.Parameters.AddWithValue("@Author", Author);
                    cmd.Parameters.AddWithValue("@Time", Time);
                    cmd.Parameters.AddWithValue("@URL", imageURL);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Thông tin bài báo mới đã được thêm.");
                }
            }
        }
        // Khai báo ở mức form-level để dùng được trong nhiều hàm
        string selectedImagePath = "";
        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                picturedetail.Image = Image.FromFile(selectedImagePath); // Hiển thị ảnh
                picturedetail.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Size textSize = TextRenderer.MeasureText(textBox.Text + "\n", textBox.Font, new Size(textBox.Width, int.MaxValue), TextFormatFlags.WordBreak);
            textBox.Height = textSize.Height + 10;
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
