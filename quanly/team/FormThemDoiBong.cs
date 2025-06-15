using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace quanly
{
    public partial class FormThemDoiBong : Form
    {
        private string selectedPlayerId = null;
        private string selectedPlayerName = null;
        private string selectedLogoPath = null;
        public FormThemDoiBong()
        {
            InitializeComponent();
        }
        string connectionString = Program.connectString;
        private bool TeamCheck(string teamName) //Kiểm tra đội bóng đã tồn tại
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Team WHERE nameTeam = @nameTeam";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nameTeam", teamName);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Không cần xử lý sự kiện này nếu không có logic cụ thể
        }
        // Khai báo ở mức form-level để dùng được trong nhiều hàm
        

        private void txtListPlayer_Click(object sender, EventArgs e)
        {
            // Không cần xử lý sự kiện này nếu không có logic cụ thể
        }

        private void picTeamlogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                selectedLogoPath = openFile.FileName; // Lưu đường dẫn đã chọn
                picTeamlogo.Image = Image.FromFile(selectedLogoPath); // Hiển thị ảnh
                picTeamlogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private bool ImageCheck(string imagePath) //Kiểm tra ảnh đã tồn tại
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Team WHERE logoUrl = @logoUrl";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@logoUrl", imagePath);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnSaveTeam_Click(object sender, EventArgs e) //lưu
        {
            string TenDoiBong = Txttendoibong.Text;
            string logoUrl = "";

            if (string.IsNullOrEmpty(TenDoiBong))
            {
                MessageBox.Show("Tên đội bóng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedLogoPath))
            {
                MessageBox.Show("Vui lòng chọn logo đội bóng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tên file từ đường dẫn đầy đủ
            string imageName = Path.GetFileName(selectedLogoPath);
            // Tạo đường dẫn lưu tương đối (ví dụ: trong thư mục "team_logos" của ứng dụng)
            string relativePath = Path.Combine("team_logos", imageName);
            // Lấy đường dẫn đầy đủ để lưu file
            string destinationPath = Path.Combine(Application.StartupPath, relativePath);

            // Tạo thư mục nếu chưa tồn tại
            string directoryPath = Path.GetDirectoryName(destinationPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                // Sao chép file ảnh vào thư mục của ứng dụng
                File.Copy(selectedLogoPath, destinationPath, true);
                logoUrl = relativePath; // Lưu đường dẫn tương đối vào database

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Team (nameTeam, logoUrl) VALUES (@nameTeam, @logoUrl)";
                    if (TeamCheck(TenDoiBong)) // Kiểm tra tên đội bóng đã tồn tại
                    {
                        MessageBox.Show("Đội bóng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (ImageCheck(logoUrl)) // Kiểm tra logo đã tồn tại (nếu có chọn ảnh)
                    {
                        MessageBox.Show("Logo đội bóng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nameTeam", TenDoiBong);
                        cmd.Parameters.AddWithValue("@logoUrl", logoUrl);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Đội bóng đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Đóng form và báo kết quả OK
                            this.Close(); // Đóng form sau khi lưu thành công
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Đã xảy ra lỗi khi lưu vào database: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // Bạn có thể ghi log lỗi hoặc thực hiện các hành động xử lý lỗi khác tại đây
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sao chép hoặc lưu logo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý sự kiện này nếu không có logic cụ thể
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {

        }

        private void FormThemDoiBong_Load(object sender, EventArgs e)
        {
            LoadPlayerData();
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void LoadPlayerData()
        {
            string query = @"
            SELECT 
            p.playerID, 
            p.namePlayer, 
            t.nameTeam, 
            p.shirtNumber,
            p.avatarUrl
            FROM Player p
            INNER JOIN Team_Player tp ON p.playerID = tp.playerID
            INNER JOIN Team t ON tp.teamID = t.teamID
            ORDER BY p.namePlayer ASC ";

            DataTable dt = GetData(query);

            


            foreach (DataRow row in dt.Rows)
            {
                UCcauthucuadoibong playerCard = new UCcauthucuadoibong();
                playerCard.PlayerId = row["playerID"].ToString();
                playerCard.PlayerName = row["namePlayer"].ToString();
                string shirtNumberString = row["shirtNumber"].ToString();
                if (int.TryParse(shirtNumberString, out int shirtNumber))
                {
                    playerCard.ShirtNumber = shirtNumber.ToString();
                }
                else
                {
                    // Xử lý trường hợp không chuyển đổi được (ví dụ: hiển thị thông báo lỗi, gán giá trị mặc định)
                    MessageBox.Show($"Không thể chuyển đổi '{shirtNumberString}' thành số áo hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    playerCard.ShirtNumber = "N/A"; // Hoặc một giá trị mặc định nào đó
                }
                playerCard.TeamName = row["nameTeam"].ToString();


                if (row["avatarUrl"] != DBNull.Value)
                {
                    try
                    {
                        // Đường dẫn avatarUrl trong bảng Player có thể cần được điều chỉnh
                        // nếu cách lưu ảnh cầu thủ khác với logo đội bóng.
                        // Giả sử nó cũng là đường dẫn tương đối.
                        string avatarFullPath = Path.Combine(Application.StartupPath, row["avatarUrl"].ToString());
                        if (File.Exists(avatarFullPath))
                        {
                            playerCard.Avatar = Image.FromFile(avatarFullPath);
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy ảnh cầu thủ: {avatarFullPath}");
                            // Có thể đặt ảnh mặc định nếu không tìm thấy
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi tải ảnh cầu thủ: " + ex.Message);
                    }
                }


                // Gắn sự kiện Click cho PlayerCard (nếu bạn muốn xử lý click trên từng card)
                playerCard.Click += PlayerCard_Click;
                foreach (Control control in playerCard.Controls)
                {
                    control.Click += PlayerCard_Click;// Để click vào label hoặc picturebox cũng kích hoạt sự kiện
                }
            }
        }

        private void PlayerCard_Click(object sender, EventArgs e)
        {
            UCcauthucuadoibong clickedCard = null;
            if (sender is UCcauthucuadoibong card)
            {
                clickedCard = card;
            }
            else if (sender is Control control && control.Parent is UCcauthucuadoibong parentCard)
            {
                clickedCard = parentCard;
            }
            if (clickedCard != null)
            {
                selectedPlayerId = clickedCard.PlayerId;
            }
        
        }

        public DataTable GetData(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedLogoPath = openFileDialog.FileName;
                picTeamlogo.Image = Image.FromFile(selectedLogoPath); // Hiển thị ảnh
                picTeamlogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
    
}