using quanly.schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static quanly.FormChitietdoibong;

namespace quanly
{
    public partial class FormChitietdoibong : Form
    {
        string connectionString = Program.connectString;
        private int _teamID;
        public FormChitietdoibong(int teamId)
        {
            InitializeComponent();
            _teamID = teamId;
            LoadThongTinDoiBong();
            LoadDanhSachCauThu(_teamID.ToString());
        }

        private void FormChitietdoibong_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Bạn có thể đặt DialogResult của form là OK và truyền teamId nếu cần
            this.DialogResult = DialogResult.OK;
        }

        public int SelectedTeamId
        {
            get { return _teamID; }
        }

        public class Player
        {
            public int playerID { get; set; }
            public string namePlayer { get; set; }
            public int shirtNumber { get; set; }
            public string avatarUrl { get; set; }
            public string nameTeam { get; set; }

        }

        private void LoadThongTinDoiBong()
        {
            string query = "SELECT nameTeam, logoUrl FROM Team WHERE teamID = @teamId";
            using (SqlConnection conn = new SqlConnection(Program.connectString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@teamId", _teamID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        TxtTendoi.Text = reader["nameTeam"].ToString();
                        string logoUrl = reader["logoUrl"].ToString();
                        LoadLogo(logoUrl); // Gọi phương thức để tải logo
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin đội bóng: " + ex.Message);
                }
            }
        }

        private void LoadLogo(string logoUrl)
        {
            if (!string.IsNullOrEmpty(logoUrl))
            {
                string imagePath = Path.Combine(Application.StartupPath, logoUrl);
                if (File.Exists(imagePath))
                {
                    try
                    {
                        picTeamlogo.LoadAsync(imagePath);
                        picTeamlogo.SizeMode = PictureBoxSizeMode.Zoom; // Điều chỉnh chế độ hiển thị nếu cần
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải logo: " + ex.Message);
                        picTeamlogo.Image = null; // Đặt ảnh về null nếu có lỗi
                    }
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy file logo tại đường dẫn: {imagePath}");
                    picTeamlogo.Image = null; // Đặt ảnh về null nếu không tìm thấy file
                }
            }
            else
            {
                picTeamlogo.Image = null; // Không có URL logo, đặt ảnh về null
            }
        }

        private void lblAchievement_Click(object sender, EventArgs e)
        {

        }

        private void FormChitietdoibong_Load(object sender, EventArgs e)
        {

        }

        private List<Player> GetPlayersByTeamId()
        {
            List<Player> players = new List<Player>();
            string query = @"
                SELECT p.playerID, p.namePlayer, p.shirtNumber, p.avatarUrl, t.nameTeam
                FROM Player p
                JOIN Team_Player tp ON p.playerID = tp.playerID
                JOIN Team t ON tp.teamID = t.teamID
                WHERE tp.teamID = @teamId";

            using (SqlConnection conn = new SqlConnection(Program.connectString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@teamId", _teamID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Player player = new Player
                        {
                            playerID = Convert.ToInt32(reader["playerID"]),
                            namePlayer = reader["namePlayer"].ToString(),
                            shirtNumber = Convert.ToInt32(reader["shirtNumber"]),
                            avatarUrl = reader["avatarUrl"].ToString(),
                            nameTeam = reader["nameTeam"].ToString()
                        };
                        players.Add(player);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin cầu thủ: " + ex.Message);
                }
            }
            return players;
        }

        private void LoadDanhSachCauThu(string maDoiBong)
        {
            string query = $@"
                SELECT
                    p.playerID,
                    p.namePlayer,
                    p.shirtNumber,
                    p.avatarUrl,
                    t.nameTeam
                FROM Player p
                INNER JOIN Team_Player tp ON p.playerID = tp.playerID
                INNER JOIN Team t ON tp.teamID = t.teamID
                WHERE tp.teamID = @teamId
                ORDER BY p.namePlayer ASC";

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@teamId", maDoiBong)
                };
            DataTable dt = GetData(query, parameters); // Sử dụng hàm GetData của bạn (hoặc tương tự)


            // Giả sử bạn có một FlowLayoutPanel tên là 'flowLayoutPanelDanhSachCauThu' để chứa các UCcauthu
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                UCcauthucuadoibong playerCard = new UCcauthucuadoibong();
                playerCard.PlayerId = row["playerID"].ToString();
                playerCard.PlayerName = row["namePlayer"].ToString();
                playerCard.ShirtNumber = row["shirtNumber"].ToString();
                playerCard.TeamName = row["nameTeam"].ToString();
                

                if (row["avatarUrl"] != DBNull.Value)
                {
                    try
                    {
                        string avatarPath = row["avatarUrl"].ToString();
                        // Nếu là đường dẫn tương đối, kết hợp với Application.StartupPath
                        if (!Path.IsPathRooted(avatarPath))
                        {
                            avatarPath = Path.Combine(Application.StartupPath, avatarPath);
                        }
                        playerCard.Avatar = Image.FromFile(avatarPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi tải ảnh cho {playerCard.PlayerName}: {ex.Message}");
                        // Xử lý lỗi bằng cách hiển thị ảnh mặc định (nếu có)
                        // playerCard.Avatar = Image.FromFile("path/to/default_avatar.png");
                        playerCard.Avatar = null;
                    }
                }
                else
                {
                    playerCard.Avatar = null;
                }

                flowLayoutPanel1.Controls.Add(playerCard);
            }
        }

        private DataTable GetData(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Program.connectString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        if (parameters != null)
                        {
                            adapter.SelectCommand.Parameters.AddRange(parameters); // Thêm các tham số vào SqlCommand
                        }
                        adapter.Fill(dt);
                    }
                }
                catch (SqlException ex)
                {
                    // Xử lý các lỗi liên quan đến SQL Server (ví dụ: lỗi cú pháp, lỗi kết nối)
                    Console.WriteLine("Lỗi SQL: " + ex.Message);
                    // Có thể log lỗi hoặc ném một ngoại lệ tùy chỉnh ở đây
                    throw; // Ném lại ngoại lệ để lớp gọi có thể xử lý
                }
                catch (Exception ex)
                {
                    // Xử lý các lỗi khác (ví dụ: lỗi hệ thống)
                    Console.WriteLine("Lỗi không xác định: " + ex.Message);
                    // Có thể log lỗi hoặc ném một ngoại lệ tùy chỉnh ở đây
                    throw; // Ném lại ngoại lệ để lớp gọi có thể xử lý
                }

                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close(); // Đóng kết nối một cách rõ ràng
                    }
                }
            }
            return dt;
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCauthu_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadDanhSachCauThu(_teamID.ToString());
        }
        private void LoadRankings(string teamID)
        {
            // 1. Lấy danh sách các giải đấu đội này tham gia
            List<int> tournamentIds = new List<int>();
            string queryTournament = "SELECT DISTINCT tournamentID FROM Rank WHERE teamID = @teamID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryTournament, conn))
            {
                cmd.Parameters.AddWithValue("@teamID", teamID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tournamentIds.Add(Convert.ToInt32(reader["tournamentID"]));
                    }
                }
            }

            flowLayoutPanel1.Controls.Clear();

            foreach (int tid in tournamentIds)
            {
                List<dynamic> teams = new List<dynamic>();
                string queryRank = @"
            SELECT 
                R.teamID,
                R.totalWins,
                R.totalDraws,
                R.totalLosses,
                R.totalGoals,
                R.totalGoalsAgainst,
                T.nameTeam,
                T.logoUrl,
                Tr.tournamentName
            FROM Rank R
            JOIN Team T ON R.teamID = T.teamID
            JOIN Tournament Tr ON R.tournamentID = Tr.tournamentID
            WHERE R.tournamentID = @tournamentID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(queryRank, conn))
                {
                    cmd.Parameters.AddWithValue("@tournamentID", tid);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int wins = (int)reader["totalWins"];
                            int draws = (int)reader["totalDraws"];
                            int losses = (int)reader["totalLosses"];
                            int goalsFor = (int)reader["totalGoals"];
                            int goalsAgainst = (int)reader["totalGoalsAgainst"];
                            int points = wins * 3 + draws;
                            int goalDiff = goalsFor - goalsAgainst;

                            Image logo = null;
                            string logoPath = reader["logoUrl"].ToString();
                            if (!string.IsNullOrEmpty(logoPath))
                            {
                                string fullPath = Path.Combine(Application.StartupPath, logoPath);
                                if (File.Exists(fullPath))
                                    logo = Image.FromFile(fullPath);
                            }

                            teams.Add(new
                            {
                                TeamID = (int)reader["teamID"],
                                TournamentName = reader["tournamentName"].ToString(),
                                TournamentID = tid,
                                Wins = wins,
                                Draws = draws,
                                Losses = losses,
                                Points = points,
                                GoalDiff = goalDiff,
                                Logo = logo
                            });
                        }
                    }
                }

                var sorted = teams.OrderByDescending(x => x.Points)
                                  .ThenByDescending(x => x.GoalDiff)
                                  .ToList();

                int position = 1;
                foreach (var team in sorted)
                {
                    if (team.TeamID.ToString() == teamID)  // chỉ hiển thị đúng đội cần xem
                    {
                        UC_RankItem_doibong uc = new UC_RankItem_doibong();
                        uc.SetData(position, team.Logo, team.TournamentName, team.Wins, team.Draws, team.Losses, team.TournamentID);
                        flowLayoutPanel1.Controls.Add(uc);
                        break;
                    }
                    position++;
                }
            }
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string query = "SELECT " +
                                     "m.MatchID, " +
                                     "m.TournamentID, " +
                                     "m.MatchTeamID_A, " +
                                     "m.MatchTeamID_B, " +
                                     "m.MatchTime, " +
                                     "t1.nameTeam AS HomeTeamName, " +
                                     "t2.nameTeam AS AwayTeamName, " +
                                     "m.Logo1_url AS HomeLogo, " +
                                     "m.Logo2_url AS AwayLogo, " +
                                     "m.Score1 AS HomeScore, " +
                                     "m.Score2 AS AwayScore, " +
                                     "m.Location, " +
                                     "m.status_name " +
                                     "FROM MatchSchedule m " +
                                     "JOIN Team t1 ON m.MatchTeamID_A = t1.teamID " +
                                     "JOIN Team t2 ON m.MatchTeamID_B = t2.teamID " +
                                     "WHERE m.MatchTeamID_A = @TeamID OR m.MatchTeamID_B = @TeamID " +
                                     "ORDER BY m.MatchTime";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TeamID", _teamID);

                conn.Open();
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

        private void buttonRank_Click(object sender, EventArgs e)
        {
            LoadRankings(_teamID.ToString());
            
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
