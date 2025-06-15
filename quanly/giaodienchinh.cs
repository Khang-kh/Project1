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
using quanly.schedule;


namespace quanly
{
    public partial class giaodienchinh : Form
    {
        string connectionString = Program.connectString;
        public giaodienchinh()
        {
            InitializeComponent();
            LoadListOfSchedule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadListOfSchedule();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadTournamentList();
        }

        private void US_Doibong_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadListOfClubs();
        }

        private void btn_Cauthu_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadListOfPlayer();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadListOfBlog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Enabled = false;  // Vô hiệu hóa nút (chưa thoát khỏi giao diện đăng nhập thì k cho ra) 
                }
            }
            UserControl_Dangnhap dangnhap = new UserControl_Dangnhap();
            dangnhap.Location = new Point(
            (this.ClientSize.Width - dangnhap.Width) / 2, // Căn giữa theo chiều ngang
            (this.ClientSize.Height - dangnhap.Height) / 2 // Căn giữa theo chiều dọc
            );
            this.Controls.Add(dangnhap);
            dangnhap.BringToFront();

        }
        public void HienThiChucNangSauDangNhap()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Enabled = true;
                }
            }
            buttonDangxuat.Visible = true;
            buttonMenu.Visible = true;
        }
        public void Molaicacnutchucnangkhibamquaylai()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Enabled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonDangxuat.Visible = false;
            buttonMenu.Visible = false;

        }

        private void buttonDangxuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                buttonDangxuat.Visible = false;
                buttonMenu.Visible = false;
            }
        }


        private void US_Timkiem_Load_1(object sender, EventArgs e)
        {
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            menuquanly menuQuanLy = new menuquanly(this);
            this.Hide();
            menuQuanLy.Show();

        }

        private void LoadListOfBlog()
        {
            string query = "SELECT postID, title, createdAt, imageURL FROM Post ORDER BY createdAt DESC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string postId = reader["PostID"].ToString();
                    string title = reader["title"].ToString();
                    DateTime createdAt = Convert.ToDateTime(reader["createdAt"]);

                    // định dạng lại createdAt thành chuỗi theo định dạng 
                    string formattedDate = createdAt.ToString("yyyy-MM-dd HH:mm:ss");
                    // Lấy URL ảnh
                    string imageURL = reader["imageURL"].ToString();

                    UC_Blog_trangchu banner = new UC_Blog_trangchu();
                    banner.SetPostInfor(postId, title, formattedDate, imageURL);
                    flowLayoutPanel1.Controls.Add(banner);
                }

            }
        }
        public void LoadTournamentList()
        {
            flowLayoutPanel1.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT tournamentID, tournamentName, startDate, endDate, avatarUrl FROM Tournament";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int stt = 1;
                while (reader.Read())
                {
                    int tournamentID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    DateTime start = reader.GetDateTime(2);
                    DateTime end = reader.GetDateTime(3);

                    string logoPath = reader["avatarUrl"].ToString();
                    Image logo = null;
                    if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                    {
                        logo = Image.FromFile(logoPath);
                    }

                    var item = new UCTournamentItem_trangchu();
                    item.SetData(tournamentID, stt++, name, start, end, logo);
                    flowLayoutPanel1.Controls.Add(item);
                }
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
        private void LoadListOfPlayer()
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

            flowLayoutPanel1.Controls.Clear();


            foreach (DataRow row in dt.Rows)
            {
                UCcauthutrangchu playerCard = new UCcauthutrangchu();
                playerCard.PlayerId = row["playerID"].ToString();
                playerCard.PlayerName = row["namePlayer"].ToString();
                playerCard.ShirtNumber = row["shirtNumber"].ToString();
                playerCard.TeamName = row["nameTeam"].ToString();

                if (row["avatarUrl"] != DBNull.Value)
                {
                    try
                    {
                        playerCard.Avatar = Image.FromFile(row["avatarUrl"].ToString()); // Thay đổi ở đây
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Lỗi tải ảnh: " + ex.Message);
                    }
                }

                flowLayoutPanel1.Controls.Add(playerCard);
            }
        }

        private string keyword;
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            keyword = textBoxSearch.Text;

        }
        private void button_Search_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Search_player(keyword);
            Search_Club(keyword);
            Search_Blog(keyword);
            Search_Tournament(keyword);

        }

        private void Search_Blog(string keyword)
        {
            string query = "SELECT postID, title, createdAt, imageURL " + "FROM Post WHERE title LIKE @kw";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string postId = reader["PostID"].ToString();
                    string title = reader["title"].ToString();
                    DateTime createdAt = Convert.ToDateTime(reader["createdAt"]);

                    // định dạng lại createdAt thành chuỗi theo định dạng 
                    string formattedDate = createdAt.ToString("yyyy-MM-dd HH:mm:ss");
                    // Lấy URL ảnh
                    string imageURL = reader["imageURL"].ToString();

                    UC_Blog_trangchu banner = new UC_Blog_trangchu();
                    banner.SetPostInfor(postId, title, formattedDate, imageURL);
                    flowLayoutPanel1.Controls.Add(banner);
                }
            }
        }
        private void Search_player(string keyword)
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
            WHERE p.namePlayer LIKE @kw";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UCcauthutrangchu playerCard = new UCcauthutrangchu
                        {
                            PlayerId = reader["playerID"].ToString(),
                            PlayerName = reader["namePlayer"].ToString(),
                            ShirtNumber = reader["shirtNumber"].ToString(),
                            TeamName = reader["nameTeam"].ToString(),
                        };
                        if (reader["avatarUrl"] != DBNull.Value)
                        {
                            try
                            {
                                playerCard.Avatar = Image.FromFile(reader["avatarUrl"].ToString());  // Thay đổi ở đây
                            }
                            catch (Exception ex)
                            {
                                // Xử lý lỗi nếu không tải được ảnh (ví dụ: gán ảnh mặc định)

                                Console.WriteLine("Lỗi tải ảnh: " + ex.Message);
                            }
                        }

                        flowLayoutPanel1.Controls.Add(playerCard);
                    }
                }
            }
        }
        private void Search_Tournament(string keyword)
        {

            string query = @"SELECT tournamentID, tournamentName, startDate, endDate, avatarURL 
                     FROM Tournament 
                     WHERE tournamentName LIKE @keyword";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");


                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int stt = 1;
                    while (reader.Read())
                    {
                        int tournamentID = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        DateTime start = reader.GetDateTime(2);
                        DateTime end = reader.GetDateTime(3);
                        string logoPath = reader["avatarURL"].ToString();

                        Image logo = null;
                        if (File.Exists(logoPath))
                        {
                            logo = Image.FromFile(logoPath);
                        }

                        var item = new UCTournamentItem_trangchu();
                        item.SetData(tournamentID, stt++, name, start, end, logo);
                        flowLayoutPanel1.Controls.Add(item);
                    }
                    reader.Close();
                }
            }
        }

        private void LoadListOfClubs()
        {
            string query = "SELECT teamID, nameTeam, logoUrl FROM Team ORDER BY teamID DESC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string teamID = reader["teamID"].ToString();
                        string name = reader["nameTeam"].ToString();
                        string imageURL = reader["logoUrl"].ToString();

                        UC_Club banner = new UC_Club();
                        banner.SetClubInfor(teamID, name, imageURL);
                        banner.Click += UcClub_Click;
                        flowLayoutPanel1.Controls.Add(banner);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách đội bóng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void UcClub_Click(object sender, EventArgs e)
        {
            if (sender is UC_Club clickedClub)
            {
                if (!string.IsNullOrEmpty(clickedClub.TeamID) && int.TryParse(clickedClub.TeamID, out int teamId))
                {
                    FormChitietdoibong formChitiet = new FormChitietdoibong(teamId);
                    if (formChitiet.ShowDialog() == DialogResult.OK)
                    {
                        // Nếu bạn cần làm gì đó sau khi form chi tiết đóng, bạn có thể truy cập formChitiet.SelectedTeamId ở đây
                        // Ví dụ: int returnedTeamId = formChitiet.SelectedTeamId;
                        // Thực hiện hành động dựa trên returnedTeamId (nếu cần)
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi: TeamID của UC_Club không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Search_Club(string keyword)
        {
            

            string query = "SELECT teamID, nameTeam, logoUrl FROM Team WHERE nameTeam LIKE @keyword ORDER BY teamID DESC"; // Thêm ORDER BY

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%"); // Sử dụng @keyword

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string teamID = reader["teamID"].ToString();
                        string name = reader["nameTeam"].ToString();
                        string imageURL = reader["logoUrl"].ToString();
                        UC_Club banner = new UC_Club();
                        banner.SetClubInfor(teamID, name, imageURL);
                        banner.OnViewDetails += HandleViewClubDetails;
                        flowLayoutPanel1.Controls.Add(banner);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm đội bóng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void HandleViewClubDetails(string teamId)
        {
            if (int.TryParse(teamId, out int id))
            {
                FormChitietdoibong formChitiet = new FormChitietdoibong(id);
                formChitiet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lỗi: TeamID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadListOfSchedule()
        {
            string query = "SELECT " +
                                    "m.MatchID, " +
                                    "m.MatchTeamID_A, " +
                                    "m.MatchTeamID_B, " +
                                    "m.MatchTime, " +
                                    "t1.nameTeam AS HomeTeamName, " +
                                    "t2.nameTeam AS AwayTeamName, " +
                                    "m.Logo1_url AS HomeLogo, " +
                                    "m.Logo2_url AS AwayLogo, " +
                                    "m.Score1 AS HomeScore, " +
                                    "m.Score2 AS AwayScore, " +
                                    "m.TournamentID," +
                                    "m.Location, " +
                                    "m.status_name " +
                                    "FROM MatchSchedule m " +
                                    "JOIN Team t1 ON m.MatchTeamID_A = t1.teamID " +
                                    "JOIN Team t2 ON m.MatchTeamID_B = t2.teamID " +
                                    "ORDER BY m.MatchTime";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int matchId = Convert.ToInt32(reader["MatchID"]);

                    int teamid1 = Convert.ToInt32(reader["MatchTeamID_A"]);
                    int teamid2 = Convert.ToInt32(reader["MatchTeamID_B"]);

                    string homeTeamName = reader["HomeTeamName"].ToString();
                    string awayTeamName = reader["AwayTeamName"].ToString();

                    DateTime matchTime = Convert.ToDateTime(reader["MatchTime"]);
                    string formattedTime = matchTime.ToString("yyyy-MM-dd HH:mm:ss");


                    string homeLogoPath = reader["HomeLogo"].ToString();
                    string awayLogoPath = reader["AwayLogo"].ToString();
                    int? homeScore = reader["HomeScore"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["HomeScore"]);
                    int? awayScore = reader["AwayScore"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["AwayScore"]);
                    string location = reader["Location"].ToString();
                    string statusName = reader["status_name"].ToString();
                    int tournamentId = Convert.ToInt32(reader["TournamentID"]);

                    UC_Schedule banner = new UC_Schedule();
                    banner.SetMatchInfor(matchId, teamid1, teamid2, homeTeamName, awayTeamName, location, formattedTime, homeLogoPath, awayLogoPath, homeScore, awayScore, statusName, tournamentId);
                    banner.Tag = matchId;
                    flowLayoutPanel1.Controls.Add(banner);
                }
                reader.Close();
            }
        }

        private void LoadListOfSchedule(string keyword)
        {
            

            string query = "SELECT " +
                                    "m.MatchID, " +
                                    "m.MatchTeamID_A, " +
                                    "m.MatchTeamID_B, " +
                                    "m.MatchTime, " +
                                    "t1.nameTeam AS HomeTeamName, " +
                                    "t2.nameTeam AS AwayTeamName, " +
                                    "m.Logo1_url AS HomeLogo, " +
                                    "m.Logo2_url AS AwayLogo, " +
                                    "m.Score1 AS HomeScore, " +
                                    "m.Score2 AS AwayScore, " +
                                    "m.TournamentID," +
                                    "m.Location, " +
                                    "m.status_name " +
                                    "FROM MatchSchedule m " +
                                    "JOIN Team t1 ON m.MatchTeamID_A = t1.teamID " +
                                    "JOIN Team t2 ON m.MatchTeamID_B = t2.teamID " +
                                    "WHERE t1.nameTeam LIKE @teamName OR t2.nameTeam LIKE @teamName " +
                                    "ORDER BY m.MatchTime ASC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@teamName", "%" + keyword + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int matchId = Convert.ToInt32(reader["MatchID"]);
                    int teamid1 = Convert.ToInt32(reader["MatchTeamID_A"]);
                    int teamid2 = Convert.ToInt32(reader["MatchTeamID_B"]);

                    string homeTeamName = reader["HomeTeamName"].ToString();
                    string awayTeamName = reader["AwayTeamName"].ToString();

                    DateTime matchTime = Convert.ToDateTime(reader["MatchTime"]);
                    string formattedTime = matchTime.ToString("yyyy-MM-dd HH:mm:ss");


                    string homeLogoPath = reader["HomeLogo"].ToString();
                    string awayLogoPath = reader["AwayLogo"].ToString();
                    int? homeScore = reader["HomeScore"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["HomeScore"]);
                    int? awayScore = reader["AwayScore"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["AwayScore"]);
                    string location = reader["Location"].ToString();
                    string statusName = reader["status_name"].ToString();
                    int tournamentId = Convert.ToInt32(reader["TournamentID"]);

                    UC_Schedule banner = new UC_Schedule();
                    banner.SetMatchInfor(matchId, teamid1, teamid2, homeTeamName, awayTeamName, location, formattedTime, homeLogoPath, awayLogoPath, homeScore, awayScore, statusName, tournamentId);
                    banner.Tag = matchId;
                    flowLayoutPanel1.Controls.Add(banner);
                }
                reader.Close();
            }
        }
    }
}

