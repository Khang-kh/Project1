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
    public partial class Suacauthu : Form
    {
        string connectionString = Program.connectString;
        private string playerId;
        private string selectedAvatarFileName = "";
        public Suacauthu(string playerId)
        {
            InitializeComponent();
            this.playerId = playerId;
           
        }

        private void Suacauthu_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(playerId)) // Kiểm tra xem playerId có rỗng không
            {
                MessageBox.Show("Không có ID cầu thủ để sửa."); // Hiển thị thông báo lỗi nếu không có ID
                return;
            }

            string query = "SELECT p.namePlayer, p.shirtNumber, p.avatarUrl, p.position, p.age, tp.teamID " +
                           "FROM Player p " +
                           "INNER JOIN Team_Player tp ON p.playerID = tp.playerID " +
                           "WHERE p.playerID = @id";

            using (SqlConnection conn = new SqlConnection(connectionString)) // Sử dụng using để tự động đóng kết nối sau khi dùng xong
            {
                SqlCommand cmd = new SqlCommand(query, conn); // Tạo đối tượng SqlCommand để thực thi truy vấn
                cmd.Parameters.AddWithValue("@id", playerId); // Truyền giá trị playerId vào tham số @id trong câu truy vấn

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        TxtHoten.Text = reader["namePlayer"].ToString();
                        TxtSoao.Text = reader["shirtNumber"].ToString();
                        selectedAvatarFileName = reader["avatarUrl"].ToString();
                        LoadImage(selectedAvatarFileName);

                        // Load teams into the combo box and select the current team
                        LoadTeams(reader["teamID"].ToString());
                        TxtVitri.Text = reader["position"] != DBNull.Value ? reader["position"].ToString() : "";
                        TxtTuoi.Text = reader["age"] != DBNull.Value ? reader["age"].ToString() : "";
                    }

                    else
                    {
                        MessageBox.Show("Không tìm thấy cầu thủ có ID: " + playerId);
                        this.Close();
                    }
                    reader.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin cầu thủ: " + ex.Message);
                }
            }
        }

        private void LoadTeams(string selectedTeamId = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT teamID, nameTeam FROM Team";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    CmbDoibong.DataSource = dt;
                    CmbDoibong.DisplayMember = "nameTeam";
                    CmbDoibong.ValueMember = "teamID";

                    if (!string.IsNullOrEmpty(selectedTeamId))
                    {
                        CmbDoibong.SelectedValue = selectedTeamId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đội bóng: " + ex.Message);
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string ten = TxtHoten.Text.Trim();
            string soAoStr = TxtSoao.Text.Trim();
            string vitri = TxtVitri.Text.Trim();
            string tuoiStr = TxtTuoi.Text.Trim();

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(soAoStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cầu thủ.");
                return;
            }

            if (!int.TryParse(soAoStr, out int soAo))
            {
                MessageBox.Show("Số áo phải là một số.");
                return;
            }

            if (!int.TryParse(tuoiStr, out int tuoi))
            {
                MessageBox.Show("Tuổi phải là một số.");
                return;
            }

            if (CmbDoibong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đội bóng.");
                return;
            }
            int selectedTeamId = Convert.ToInt32(CmbDoibong.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Update Player table
                    string updatePlayerQuery = "UPDATE Player SET namePlayer = @name, shirtNumber = @soao, avatarUrl = @avatar, position = @position, age = @age WHERE playerID = @id";
                    SqlCommand updatePlayerCmd = new SqlCommand(updatePlayerQuery, conn, transaction);
                    updatePlayerCmd.Parameters.AddWithValue("@name", ten);
                    updatePlayerCmd.Parameters.AddWithValue("@soao", soAo);
                    updatePlayerCmd.Parameters.AddWithValue("@avatar", selectedAvatarFileName);
                    updatePlayerCmd.Parameters.AddWithValue("@id", playerId);
                    updatePlayerCmd.Parameters.AddWithValue("@position", vitri);
                    updatePlayerCmd.Parameters.AddWithValue("@age", tuoi);
                    int playerRowsAffected = updatePlayerCmd.ExecuteNonQuery();

                    string updateTeamPlayerQuery = "UPDATE Team_Player SET teamID = @teamId WHERE playerID = @playerId";
                    SqlCommand updateTeamPlayerCmd = new SqlCommand(updateTeamPlayerQuery, conn, transaction);
                    updateTeamPlayerCmd.Parameters.AddWithValue("@teamId", selectedTeamId);
                    updateTeamPlayerCmd.Parameters.AddWithValue("@playerId", playerId);
                    int teamPlayerRowsAffected = updateTeamPlayerCmd.ExecuteNonQuery();

                    transaction.Commit();

                    if (playerRowsAffected > 0 && teamPlayerRowsAffected > 0)
                    {
                        
                        MessageBox.Show("Cập nhật thông tin cầu thủ thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin cầu thủ.");
                    }
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open && transaction.Connection != null)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (SqlException rollbackEx)
                        {
                            // Xử lý lỗi có thể xảy ra trong quá trình rollback (ví dụ: mất kết nối)
                            MessageBox.Show("Lỗi khi rollback giao dịch: " + rollbackEx.Message);
                            // Có thể ghi log lỗi rollbackEx để điều tra thêm
                        }
                    }
                    MessageBox.Show("Lỗi khi cập nhật thông tin cầu thủ: " + ex.Message);
                }
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = openFileDialog.FileName;
                string fileName = Path.GetFileName(sourceFile);
                string destFolder = Path.Combine(Application.StartupPath, "imagesplayers");
                string destFile = Path.Combine(destFolder, fileName);

                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                // Kiểm tra file trùng
                if (File.Exists(destFile))
                {
                    MessageBox.Show("Không được chọn trùng ảnh cầu thủ.");
                    return; // Không tiếp tục nếu trùng
                }

                try
                {
                    File.Copy(sourceFile, destFile);
                    selectedAvatarFileName = Path.Combine("imagesplayers", fileName);

                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = Image.FromFile(destFile);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi khi sao chép file: {ex.Message}");
                }
            }
        }

        private void LoadImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(Path.Combine(Application.StartupPath, imagePath)))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, imagePath));
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message);
                }
            }
            else
            {
                pictureBox1.Image = null; // Or set a default image
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }                
}


    
