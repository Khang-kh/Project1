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

namespace quanly
{
    public partial class FormSuaHoSoDoiBong : Form
    {
        private string teamID;
        string connectionString = Program.connectString;
        public FormSuaHoSoDoiBong(string teamID)
        {
            InitializeComponent();
            this.teamID = teamID;
            LoadTeamInfo();
        }
        private void LoadTeamInfo()
        {
            string query = "SELECT nameTeam, logoUrl FROM Team WHERE teamID = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", teamID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox1.Text = reader["nameTeam"].ToString();

                        string imageURL = reader["logoUrl"].ToString();
                        picTeamlogo.SizeMode = PictureBoxSizeMode.Zoom;

                        if (!string.IsNullOrWhiteSpace(imageURL))
                        {
                            try
                            {
                                picTeamlogo.LoadAsync(imageURL);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi tải ảnh logo:\n" + ex.Message);
                            }
                        }
                        else
                        {
                            picTeamlogo.Image = null;
                            // Bạn có thể đặt một ảnh mặc định ở đây nếu muốn
                            // pictureBoxLogo.Image = Properties.Resources.default_logo;
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin đội bóng: " + ex.Message);
                }
            }
        }
        private void btnSaveTeam_Click(object sender, EventArgs e)
        {
            string TenDoiBong = textBox1.Text.Trim();
            string logoUrl = "";

            if (string.IsNullOrWhiteSpace(TenDoiBong))
            {
                MessageBox.Show("Tên đội bóng không được để trống!");
                return;
            }

            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                string imageName = Path.GetFileName(selectedImagePath);
                string imagesDirectory = Path.Combine(Application.StartupPath, "team_logos"); // Thư mục lưu ảnh
                string savePath = Path.Combine(imagesDirectory, imageName);

                // Tạo thư mục nếu chưa tồn tại
                Directory.CreateDirectory(imagesDirectory);

                try
                {
                    File.Copy(selectedImagePath, savePath, true); // Sao chép ảnh
                    logoUrl = Path.Combine("team_logos", imageName); // Đường dẫn tương đối lưu vào DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}");
                    return;
                }
            }
            else
            {
                // Nếu không chọn ảnh mới, giữ nguyên đường dẫn cũ trong database
                logoUrl = picTeamlogo.ImageLocation;
                // Loại bỏ đường dẫn tuyệt đối nếu có, chỉ giữ lại phần tương đối
                if (!string.IsNullOrEmpty(logoUrl) && logoUrl.Contains(Application.StartupPath))
                {
                    logoUrl = logoUrl.Substring(Application.StartupPath.Length + 1);
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Team SET nameTeam = @nameTeam, logoUrl = @logoUrl WHERE teamID = @id";
                if (IsTeamNameExists(TenDoiBong))
                {
                    MessageBox.Show("Tên đội bóng đã tồn tại!");
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nameTeam", TenDoiBong);
                    cmd.Parameters.AddWithValue("@logoUrl", logoUrl);
                    cmd.Parameters.AddWithValue("@id", teamID);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin đội bóng thành công.");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Không có bản ghi nào được cập nhật.");
                        }
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật database: {ex.Message}");
                    }
                }
            }
        }
        string selectedImagePath = "";

        // Kiểm tra tên đội bóng có tồn tại hay không
        private bool IsTeamNameExists(string nameTeam)
        {
            string query = "SELECT COUNT(*) FROM Team WHERE nameTeam = @nameTeam AND teamID != @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nameTeam", nameTeam);
                    cmd.Parameters.AddWithValue("@id", teamID);
                    var count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }       

        //Nút upload ảnh
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                picTeamlogo.Image = Image.FromFile(selectedImagePath); // Hiển thị ảnh
                picTeamlogo.SizeMode = PictureBoxSizeMode.Zoom;
                picTeamlogo.ImageLocation = selectedImagePath; // Lưu đường dẫn để có thể dùng sau
            }
        }

        private void btnAddAchievement_Click(object sender, EventArgs e)
        {
            //FormThemThanhTich formThemThanhTich = new FormThemThanhTich(teamID);
            //formThemThanhTich.ShowDialog();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaHoSoDoiBong_Load(object sender, EventArgs e)
        {

        }

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
