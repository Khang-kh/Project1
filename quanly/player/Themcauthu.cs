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
using System.IO;

namespace quanly
{
    public partial class Themcauthu : Form
    {
        string connectionString = Program.connectString;
        string selectedAvatarFileName = "";
        
        public Themcauthu()
        {
            InitializeComponent();
        }

        private void Themcauthu_Load(object sender, EventArgs e)
        {
            LoadTeams();
        }

        private void LoadTeams()
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

                    // Assuming your ComboBox is named 'cmbTeam'
                    cmbTeam.DataSource = dt;
                    cmbTeam.DisplayMember = "nameTeam"; // What the user sees
                    cmbTeam.ValueMember = "teamID";   // The actual value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teams: " + ex.Message);
            }
        }
        public static class DatabaseHelper
        {
            private static string connectionString = @"Server=LAPTOP-KN62CACQ\SQLEXPRESS;Database=kndata;Trusted_Connection=True;";

            public static void ExecuteQuery(string query, params SqlParameter[] parameters)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddRange(parameters);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public static DataTable GetData(string query, params SqlParameter[] parameters)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    if (parameters != null && parameters.Length > 0)
                    {
                        da.SelectCommand.Parameters.AddRange(parameters);
                    }
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(openFile.FileName); // Hiển thị ảnh
            }
        }


        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string ten = TxtHoten.Text.Trim();
            string soAoStr = TxtSoao.Text.Trim();
            string vitri = TxtVitri.Text.Trim(); // Get position
            string tuoiStr = TxtTuoi.Text.Trim();
            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(soAoStr) || string.IsNullOrEmpty(vitri) || string.IsNullOrEmpty(tuoiStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cầu thủ.");
                return;
            }

            if (!int.TryParse(soAoStr, out int soAo))
            {
                MessageBox.Show("Số áo phải là một số.");
                return;
            }

            if (!int.TryParse(tuoiStr, out int tuoi)) // Validate age
            {
                MessageBox.Show("Tuổi phải là một số.");
                return;
            }


            if (cmbTeam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đội bóng.");
                return;
            }

            int selectedTeamId = (int)cmbTeam.SelectedValue; // Get the teamID

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction(); // Start transaction

                    try
                    {
                        // 1. Insert into Player
                        string sqlPlayer = @"INSERT INTO Player (namePlayer, shirtNumber, avatarUrl, position, age) 
                                           VALUES (@name, @number, @avatar, @position, @age);
                                           SELECT SCOPE_IDENTITY();"; // Get the new playerID

                        SqlCommand cmdPlayer = new SqlCommand(sqlPlayer, conn, transaction);
                        cmdPlayer.Parameters.AddWithValue("@name", ten);
                        cmdPlayer.Parameters.AddWithValue("@number", soAo);
                        cmdPlayer.Parameters.AddWithValue("@avatar", selectedAvatarFileName);
                        cmdPlayer.Parameters.AddWithValue("@position", vitri); // Add position parameter
                        cmdPlayer.Parameters.AddWithValue("@age", tuoi);

                        int newPlayerId = Convert.ToInt32(cmdPlayer.ExecuteScalar()); // Execute and get the ID

                        // 2. Insert into Team_Player
                        string sqlTeamPlayer = "INSERT INTO Team_Player (teamID, playerID) VALUES (@teamId, @playerId)";
                        SqlCommand cmdTeamPlayer = new SqlCommand(sqlTeamPlayer, conn, transaction);
                        cmdTeamPlayer.Parameters.AddWithValue("@teamId", selectedTeamId);
                        cmdTeamPlayer.Parameters.AddWithValue("@playerId", newPlayerId);
                        cmdTeamPlayer.ExecuteNonQuery();

                        transaction.Commit(); // If everything is OK, commit
                        MessageBox.Show("Đã lưu cầu thủ thành công!");
                        this.DialogResult = DialogResult.OK; // Close the form and signal success
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // If any error, rollback
                        MessageBox.Show("Lỗi khi lưu cầu thủ: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = openFileDialog.FileName;
                string fileName = Path.GetFileName(sourceFile);
                string destFolder = Path.Combine(Application.StartupPath, "imagesplayers");
                string destFile = Path.Combine(destFolder, fileName);

                // Kiểm tra file trùng
                if (File.Exists(destFile))
                {
                    MessageBox.Show("Không chọn cùng ảnh cầu thủ.");
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
        

        private void LoadPlayerAvatars()
        {

            string query = "SELECT avatarUrl FROM Player";
            DataTable dt = DatabaseHelper.GetData(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string avatarPath = row["avatarUrl"].ToString();
                    string fullPath = Path.Combine(Application.StartupPath, avatarPath);
                    if (File.Exists(fullPath))
                    {
                        PictureBox pb = new PictureBox();
                        pb.Image = Image.FromFile(fullPath);
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Width = 100; // Đặt kích thước mong muốn
                        pb.Height = 100;
                        pb.Margin = new Padding(5); // Thêm khoảng cách giữa các ảnh
                    }
                    else
                    {
                        // Xử lý trường hợp file ảnh không tồn tại (ví dụ: hiển thị ảnh mặc định)
                        Console.WriteLine($"Không tìm thấy ảnh: {fullPath}");
                    }
                }
            }
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
