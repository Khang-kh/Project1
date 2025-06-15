using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace quanly.schedule
{
    public partial class EditSchedule : Form
    {
        private string connectionString = Program.connectString;
        private int MatchID;
        
        public EditSchedule(int id)
        {
            InitializeComponent();
            MatchID = id;
            
            InitializeMatchStatusComboBox();
            LoadTournamentData();

            LoadScheduleInfor();
        }
        private void InitializeMatchStatusComboBox()
        {
            comboBoxStatus.Items.Add("Chưa diễn ra");
            comboBoxStatus.Items.Add("Đang diễn ra");
            comboBoxStatus.Items.Add("Đã diễn ra");
            comboBoxStatus.SelectedIndex = 0;
        }
       private void LoadTournamentData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT DISTINCT t.tournamentID, t.tournamentName 
                             FROM TournamentTeams tt 
                             JOIN Tournament t ON tt.tournamentID = t.tournamentID";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow newRow = dt.NewRow();
                    newRow["tournamentID"] = DBNull.Value;
                    newRow["tournamentName"] = "-- Chọn giải đấu --";
                    dt.Rows.InsertAt(newRow, 0);

                    comboBoxTournament.DataSource = dt;
                    comboBoxTournament.DisplayMember = "tournamentName";
                    comboBoxTournament.ValueMember = "tournamentID";
                }

                // Gắn sự kiện SelectedIndexChanged để phản ứng dây chuyền
                comboBoxTournament.SelectedIndexChanged += ComboBoxTournament_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu giải đấu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ComboBoxTournament_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTournament.SelectedValue != null && int.TryParse(comboBoxTournament.SelectedValue.ToString(), out int tournamentID))
            {
                LoadTeamData(tournamentID);
            }
        }

        private void LoadTeamData(int tournamentID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT t.teamID, t.nameTeam, t.logoUrl
                FROM Team t
                JOIN TournamentTeams tt ON t.teamID = tt.teamID
                WHERE tt.tournamentID = @tournamentID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tournamentID", tournamentID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxHomeTeam.DataSource = dt.Copy();
                    comboBoxHomeTeam.DisplayMember = "nameTeam";
                    comboBoxHomeTeam.ValueMember = "teamID";

                    comboBoxAwayTeam.DataSource = dt;
                    comboBoxAwayTeam.DisplayMember = "nameTeam";
                    comboBoxAwayTeam.ValueMember = "teamID";

                    comboBoxHomeTeam.SelectedIndexChanged += comboBoxHomeTeam_SelectedIndexChanged;
                    comboBoxAwayTeam.SelectedIndexChanged += comboBoxAwayTeam_SelectedIndexChanged;

                    UpdateTeamLogos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đội bóng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateTeamLogos()
        {
            UpdateLogoFromComboBox(comboBoxHomeTeam, homepic);
            UpdateLogoFromComboBox(comboBoxAwayTeam, awaypic);
        }
        private void UpdateLogoFromComboBox(System.Windows.Forms.ComboBox comboBox, PictureBox pictureBox)
        {
            if (comboBox.SelectedItem is DataRowView row)
            {
                string logoPath = row["logoUrl"].ToString();
                if (!string.IsNullOrWhiteSpace(logoPath) && File.Exists(logoPath))
                {
                    pictureBox.LoadAsync(logoPath);
                }
                else
                {
                    pictureBox.Image = null; // hoặc đặt ảnh mặc định
                }
            }
        }
        private void comboBoxHomeTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox(comboBoxHomeTeam, homepic);
        }

        private void comboBoxAwayTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox(comboBoxAwayTeam, awaypic);
        }
        public async void LoadScheduleInfor()
        {
            string query = "SELECT ms.MatchTeamID_A, ms.MatchTeamID_B, ms.MatchTime, ms.Score1, " +
    "ms.Score2, ms.status_name, ms.Location, ms.Logo1_url, ms.Logo2_url, t.tournamentID, t.tournamentName, " +
    "teamA.nameTeam AS HomeTeamName, teamB.nameTeam AS AwayTeamName " +
    "FROM MatchSchedule ms " +
    "LEFT JOIN Tournament t ON ms.tournamentID = t.tournamentID " +
    "LEFT JOIN Team teamA ON ms.MatchTeamID_A = teamA.teamID " +
    "LEFT JOIN Team teamB ON ms.MatchTeamID_B = teamB.teamID " +
    "WHERE ms.MatchID = @MatchID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MatchID", MatchID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        // Lấy tournamentID và set SelectedValue
                        int tournamentID = Convert.ToInt32(row["tournamentID"]);
                        comboBoxTournament.SelectedValue = tournamentID; // Triggers LoadTeamData

                        // Gán các giá trị cơ bản
                        textBoxLocation.Text = row["Location"].ToString();
                        dateTime.Value = Convert.ToDateTime(row["MatchTime"]);
                        comboBoxStatus.Text = row["status_name"].ToString();
                        textBoxHome.Text = row["Score1"] == DBNull.Value ? "-" : row["Score1"].ToString();
                        textBoxAway.Text = row["Score2"] == DBNull.Value ? "-" : row["Score2"].ToString();

                        // Gán ảnh (nếu có)
                        string imageURL1 = row["Logo1_url"].ToString();
                        string imageURL2 = row["Logo2_url"].ToString();
                        homepic.SizeMode = PictureBoxSizeMode.Zoom;
                        awaypic.SizeMode = PictureBoxSizeMode.Zoom;

                        if (!string.IsNullOrWhiteSpace(imageURL1))
                        {
                            try { homepic.LoadAsync(imageURL1); }
                            catch (Exception ex) { MessageBox.Show("Lỗi khi tải ảnh đội nhà:\n" + ex.Message); }
                        }

                        if (!string.IsNullOrWhiteSpace(imageURL2))
                        {
                            try { awaypic.LoadAsync(imageURL2); }
                            catch (Exception ex) { MessageBox.Show("Lỗi khi tải ảnh đội khách:\n" + ex.Message); }
                        }

                        await Task.Delay(300);
                        comboBoxHomeTeam.Text = row["HomeTeamName"].ToString();
                        comboBoxAwayTeam.Text = row["AwayTeamName"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu trận đấu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            int matchID = this.MatchID;

            if (comboBoxHomeTeam.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đội nhà!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxAwayTeam.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đội khách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxHomeTeam.SelectedValue.ToString() == comboBoxAwayTeam.SelectedValue.ToString())
            {
                MessageBox.Show("Đội nhà và đội khách không thể giống nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxAwayTeam.SelectedIndex = -1;
                return;
            }

            if (comboBoxTournament.SelectedValue == null || comboBoxTournament.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Vui lòng chọn giải đấu cho trận đấu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime matchTime = dateTime.Value;
            string formattedTime = matchTime.ToString("yyyy-MM-dd HH:mm:ss");

            string location = textBoxLocation.Text.Trim();
            string homeScoreText = textBoxHome.Text.Trim();
            string awayScoreText = textBoxAway.Text.Trim();

            int tournamentId = Convert.ToInt32(comboBoxTournament.SelectedValue);

            string logo1Url = "";
            if (comboBoxHomeTeam.SelectedItem is DataRowView homeRow)
            {
                logo1Url = homeRow["logoUrl"].ToString();
            }

            string logo2Url = "";
            if (comboBoxAwayTeam.SelectedItem is DataRowView awayRow)
            {
                logo2Url = awayRow["logoUrl"].ToString();
            }

            string statusName = comboBoxStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(statusName))
            {
                MessageBox.Show("Vui lòng chọn trạng thái trận đấu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isMatchPlaying = statusName == "Đang diễn ra";
            bool isMatchPlayed = statusName == "Đã diễn ra";
            bool isMatchNotStarted = statusName == "Chưa diễn ra";

            int homeScore;
            int awayScore;

            if (isMatchPlaying || isMatchPlayed)
            {
                if (!int.TryParse(homeScoreText, out homeScore))
                {
                    MessageBox.Show("Tỉ số đội nhà phải là một số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(awayScoreText, out awayScore))
                {
                    MessageBox.Show("Tỉ số đội khách phải là một số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (isMatchNotStarted)
            {
                if (!string.IsNullOrEmpty(homeScoreText) || !string.IsNullOrEmpty(awayScoreText))
                {
                    MessageBox.Show("Không được nhập tỉ số khi trận đấu chưa diễn ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                homeScore = -1;
                awayScore = -1;
            }
            else
            {
                homeScore = -1;
                awayScore = -1;
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Vui lòng nhập địa điểm thi đấu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            object homeTeamID = null;
            object awayTeamID = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                     homeTeamID = comboBoxHomeTeam.SelectedValue;
                     awayTeamID = comboBoxAwayTeam.SelectedValue;

                    if (homeTeamID == null || awayTeamID == null)
                    {
                        MessageBox.Show("Đội nhà hoặc đội khách không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateMatchScheduleQuery = @"
                    UPDATE MatchSchedule SET
                        MatchTeamID_A = @HomeTeamID,
                        MatchTeamID_B = @AwayTeamID,
                        TournamentID = @TournamentId,
                        Location = @Location,
                        MatchTime = @MatchTime,
                        status_name = @StatusName,
                        Score1 = @HomeScore,
                        Score2 = @AwayScore,
                        Logo1_url = @Logo1_url,
                        Logo2_url = @Logo2_url
                    WHERE MatchID = @MatchID";

                    SqlCommand updateMatchScheduleCmd = new SqlCommand(updateMatchScheduleQuery, conn);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@HomeTeamID", homeTeamID);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@AwayTeamID", awayTeamID);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@TournamentId", tournamentId);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@Location", location);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@MatchTime", formattedTime);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@StatusName", statusName);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@HomeScore", homeScore == -1 ? (object)DBNull.Value : homeScore);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@AwayScore", awayScore == -1 ? (object)DBNull.Value : awayScore);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@Logo1_url", logo1Url);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@Logo2_url", logo2Url);
                    updateMatchScheduleCmd.Parameters.AddWithValue("@MatchID", matchID);

                    int rowsUpdatedSchedule = updateMatchScheduleCmd.ExecuteNonQuery();
                    if (rowsUpdatedSchedule == 0)
                    {
                        MessageBox.Show("Không tìm thấy trận đấu để cập nhật trong bảng MatchSchedule!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (isMatchPlayed)
                {
                    // Gọi cập nhật TranDau và Rank
                    UpdateMatchStatsAndRank(conn, matchID, Convert.ToInt32(homeTeamID), Convert.ToInt32(awayTeamID), homeScore, awayScore, tournamentId);
                }
                MessageBox.Show("Cập nhật thông tin trận đấu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                


                this.DialogResult = DialogResult.OK;
                this.Close(); // Đóng cửa sổ sau khi thành công
            }

        }

        private void buttonHomelineup_Click(object sender, EventArgs e)
        {
            FormTaoDoiHinh form1 = new FormTaoDoiHinh(comboBoxHomeTeam.SelectedValue.ToString(), MatchID);
            form1.ShowDialog();
        }

        private void buttonSublineup_Click(object sender, EventArgs e)
        {
            FormTaoDoiHinh form2 = new FormTaoDoiHinh(comboBoxAwayTeam.SelectedValue.ToString(), MatchID);
            form2.ShowDialog();
        }

        private void UpdateMatchStatsAndRank(SqlConnection conn, int matchID, int homeTeamID, int awayTeamID, int homeScore, int awayScore, int tournamentID)
        {
            int team1Win = 0, team1Draw = 0, team1Loss = 0, team1Points = 0;
            int team2Win = 0, team2Draw = 0, team2Loss = 0, team2Points = 0;

            if (homeScore > awayScore)
            {
                team1Win = 1;
                team2Loss = 1;
                team1Points = 3;
            }
            else if (homeScore == awayScore)
            {
                team1Draw = 1;
                team2Draw = 1;
                team1Points = 1;
                team2Points = 1;
            }
            else
            {
                team2Win = 1;
                team1Loss = 1;
                team2Points = 3;
            }

            string updateMatchQuery = @"UPDATE TranDau SET 
        team1Win = @Team1Win, team1Draw = @Team1Draw, team1Loss = @Team1Loss, team1Points = @Team1Points,
        team2Win = @Team2Win, team2Draw = @Team2Draw, team2Loss = @Team2Loss, team2Points = @Team2Points,
        updatedAt = GETDATE()
        WHERE matchID = @MatchID";
            using (SqlCommand cmd = new SqlCommand(updateMatchQuery, conn))
            {
                cmd.Parameters.AddWithValue("@MatchID", matchID);
                cmd.Parameters.AddWithValue("@Team1Win", team1Win);
                cmd.Parameters.AddWithValue("@Team1Draw", team1Draw);
                cmd.Parameters.AddWithValue("@Team1Loss", team1Loss);
                cmd.Parameters.AddWithValue("@Team1Points", team1Points);
                cmd.Parameters.AddWithValue("@Team2Win", team2Win);
                cmd.Parameters.AddWithValue("@Team2Draw", team2Draw);
                cmd.Parameters.AddWithValue("@Team2Loss", team2Loss);
                cmd.Parameters.AddWithValue("@Team2Points", team2Points);
                cmd.ExecuteNonQuery();
            }

            UpdateRanking(conn,tournamentID, homeTeamID, awayTeamID );
        }


        private void UpdateRanking(SqlConnection conn, int tournamentId, int team1Id, int team2Id)
        {
            try
            {
                // 1. Xóa điểm cũ của 2 đội trong giải này
                string deleteQuery = @"
            DELETE FROM Rank 
            WHERE tournamentID = @TournamentID 
              AND (teamID = @Team1ID OR teamID = @Team2ID)";
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@TournamentID", tournamentId);
                    deleteCmd.Parameters.AddWithValue("@Team1ID", team1Id);
                    deleteCmd.Parameters.AddWithValue("@Team2ID", team2Id);
                    deleteCmd.ExecuteNonQuery();
                }

                // 2. Tổng hợp lại cho từng đội
                foreach (int teamId in new int[] { team1Id, team2Id })
                {
                    string statQuery = @"
                SELECT 
                    COUNT(CASE WHEN (team1ID = @TeamID AND team1Win = 1) OR (team2ID = @TeamID AND team2Win = 1) THEN 1 END) AS Wins,
                    COUNT(CASE WHEN (team1ID = @TeamID AND team1Draw = 1) OR (team2ID = @TeamID AND team2Draw = 1) THEN 1 END) AS Draws,
                    COUNT(CASE WHEN (team1ID = @TeamID AND team1Loss = 1) OR (team2ID = @TeamID AND team2Loss = 1) THEN 1 END) AS Losses,
                    SUM(CASE WHEN team1ID = @TeamID THEN team1Score WHEN team2ID = @TeamID THEN team2Score ELSE 0 END) AS Goals,
                    SUM(CASE WHEN team1ID = @TeamID THEN team2Score WHEN team2ID = @TeamID THEN team1Score ELSE 0 END) AS GoalsAgainst,
                    SUM(CASE WHEN team1ID = @TeamID THEN team1Points WHEN team2ID = @TeamID THEN team2Points ELSE 0 END) AS Points
                FROM TranDau
                WHERE tournamentID = @TournamentID AND 
                      ((team1ID = @TeamID OR team2ID = @TeamID) AND team1Points IS NOT NULL AND team2Points IS NOT NULL)";

                    using (SqlCommand statCmd = new SqlCommand(statQuery, conn))
                    {
                        statCmd.Parameters.AddWithValue("@TournamentID", tournamentId);
                        statCmd.Parameters.AddWithValue("@TeamID", teamId);

                        using (SqlDataReader reader = statCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int wins = reader.GetInt32(0);
                                int draws = reader.GetInt32(1);
                                int losses = reader.GetInt32(2);
                                int goals = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                                int goalsAgainst = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                                int points = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                                int goalDifference = goals - goalsAgainst;

                                reader.Close();

                                string insertRank = @"
                            INSERT INTO Rank (teamID, tournamentID, totalPoints, totalWins, totalDraws, totalLosses, totalGoals, totalGoalsAgainst, goalDifference)
                            VALUES (@TeamID, @TournamentID, @Points, @Wins, @Draws, @Losses, @Goals, @GoalsAgainst, @GoalDifference)";
                                using (SqlCommand insertCmd = new SqlCommand(insertRank, conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@TeamID", teamId);
                                    insertCmd.Parameters.AddWithValue("@TournamentID", tournamentId);
                                    insertCmd.Parameters.AddWithValue("@Points", points);
                                    insertCmd.Parameters.AddWithValue("@Wins", wins);
                                    insertCmd.Parameters.AddWithValue("@Draws", draws);
                                    insertCmd.Parameters.AddWithValue("@Losses", losses);
                                    insertCmd.Parameters.AddWithValue("@Goals", goals);
                                    insertCmd.Parameters.AddWithValue("@GoalsAgainst", goalsAgainst);
                                    insertCmd.Parameters.AddWithValue("@GoalDifference", goalDifference);

                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật bảng xếp hạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
