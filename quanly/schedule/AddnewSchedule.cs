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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanly.schedule
{
    public partial class AddnewSchedule : Form
    {
        string connectionString = Program.connectString;

        public int Matchid {get;set;}
        public AddnewSchedule()
        {
            InitializeComponent();
            InitializeMatchStatusComboBox();
            LoadTournamentData();
            buttonHomelineup.Visible = false;
            buttonSublineup.Visible = false;
            buttonExit.Visible = false;
            buttonSave.Visible = true;
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel1.Visible = true;
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

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
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

        

        private void buttonSave_Click(object sender, EventArgs e)
        {
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

            // Lấy logoUrl từ comboBoxHomeTeam
            string logo1Url = "";
            if (comboBoxHomeTeam.SelectedItem is DataRowView homeRow)
            {
                logo1Url = homeRow["logoUrl"].ToString();
            }

            // Lấy logoUrl từ comboBoxAwayTeam
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
                if (!int.TryParse(textBoxHome.Text, out homeScore))
                {
                    MessageBox.Show("Khi trận đấu đang hoặc đã diễn ra phải có tỉ số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBoxAway.Text, out awayScore))
                {
                    MessageBox.Show("Khi trận đấu đang hoặc đã diễn ra phải có tỉ số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string insertMatchScheduleQuery = @"INSERT INTO MatchSchedule 
                        (MatchTeamID_A, MatchTeamID_B, TournamentID, Location, MatchTime, status_name, Score1, Score2, Logo1_url, Logo2_url)
                        OUTPUT INSERTED.MatchID
                        VALUES 
                        (@HomeTeamID, @AwayTeamID, @TournamentId, @Location, @MatchTime, @StatusName, @HomeScore, @AwayScore, @Logo1_url, @Logo2_url)";
                    SqlCommand insertMatchScheduleCmd = new SqlCommand(insertMatchScheduleQuery, conn);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@HomeTeamID", comboBoxHomeTeam.SelectedValue);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@AwayTeamID", comboBoxAwayTeam.SelectedValue);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@TournamentId", tournamentId);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@Location", location);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@MatchTime", formattedTime);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@StatusName", statusName);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@HomeScore", homeScore == -1 ? (object)DBNull.Value : homeScore);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@AwayScore", awayScore == -1 ? (object)DBNull.Value : awayScore);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@Logo1_url", logo1Url);
                    insertMatchScheduleCmd.Parameters.AddWithValue("@Logo2_url", logo2Url);
                    object MatchId = insertMatchScheduleCmd.ExecuteScalar();

                    if (MatchId != null)
                    {
                        string insertMatchQuery = @"INSERT INTO TranDau 
                            (team1ID, team2ID, tournamentID, matchDate, team1Score, team2Score, status)
                            OUTPUT INSERTED.matchID
                            VALUES 
                            (@Team1ID, @Team2ID, @TournamentID, @MatchDate, @Team1Score, @Team2Score, @Status);
                            SELECT SCOPE_IDENTITY();";

                        SqlCommand insertMatchCmd = new SqlCommand(insertMatchQuery, conn);                        

                        insertMatchCmd.Parameters.AddWithValue("@Team1ID", comboBoxHomeTeam.SelectedValue);
                        insertMatchCmd.Parameters.AddWithValue("@Team2ID", comboBoxAwayTeam.SelectedValue);
                        insertMatchCmd.Parameters.AddWithValue("@TournamentID", tournamentId);
                        insertMatchCmd.Parameters.AddWithValue("@MatchDate", formattedTime);
                        insertMatchCmd.Parameters.AddWithValue("@Team1Score", homeScore == -1 ? (object)DBNull.Value : homeScore);
                        insertMatchCmd.Parameters.AddWithValue("@Team2Score", awayScore == -1 ? (object)DBNull.Value : awayScore);
                        insertMatchCmd.Parameters.AddWithValue("@Status", statusName);



                        object matchIdResult = insertMatchCmd.ExecuteScalar();
                        if (matchIdResult != null)
                        {
                            if (isMatchPlayed)
                            {
                                int team1Win = 0, team1Draw = 0, team1Loss = 0, team1Points = 0;
                                int team2Win = 0, team2Draw = 0, team2Loss = 0, team2Points = 0;

                                if (homeScore > awayScore)
                                {
                                    // Đội nhà thắng
                                    team1Win = 1;
                                    team2Loss = 1;
                                    team1Points = 3;
                                    team2Points = 0;
                                }
                                else if (homeScore == awayScore)
                                {
                                    // Hòa
                                    team1Draw = 1;
                                    team2Draw = 1;
                                    team1Points = 1;
                                    team2Points = 1;
                                }
                                else if (homeScore < awayScore)
                                {
                                    // Đội khách thắng
                                    team2Win = 1;
                                    team1Loss = 1;
                                    team2Points = 3;
                                    team1Points = 0;
                                }

                                // Cập nhật bảng TranDau
                                string updateMatchQuery = @"UPDATE TranDau SET 
                                    team1Win = @Team1Win, team1Draw = @Team1Draw, team1Loss = @Team1Loss, team1Points = @Team1Points,
                                    team2Win = @Team2Win, team2Draw = @Team2Draw, team2Loss = @Team2Loss, team2Points = @Team2Points,
                                    updatedAt = GETDATE()
                                    WHERE matchID = @MatchID";
                                SqlCommand updateMatchCmd = new SqlCommand(updateMatchQuery, conn);
                                updateMatchCmd.Parameters.AddWithValue("@MatchID", matchIdResult);
                                updateMatchCmd.Parameters.AddWithValue("@Team1Win", team1Win);
                                updateMatchCmd.Parameters.AddWithValue("@Team1Draw", team1Draw);
                                updateMatchCmd.Parameters.AddWithValue("@Team1Loss", team1Loss);
                                updateMatchCmd.Parameters.AddWithValue("@Team1Points", team1Points);
                                updateMatchCmd.Parameters.AddWithValue("@Team2Win", team2Win);
                                updateMatchCmd.Parameters.AddWithValue("@Team2Draw", team2Draw);
                                updateMatchCmd.Parameters.AddWithValue("@Team2Loss", team2Loss);
                                updateMatchCmd.Parameters.AddWithValue("@Team2Points", team2Points);

                                int rowsUpdated = updateMatchCmd.ExecuteNonQuery();
                                if (rowsUpdated <= 0)
                                {
                                    MessageBox.Show("Không thể cập nhật điểm cho trận đấu trong bảng Match!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                UpdateRanking(conn, tournamentId, Convert.ToInt32(comboBoxHomeTeam.SelectedValue), Convert.ToInt32(comboBoxAwayTeam.SelectedValue));

                            }
                            var result = MessageBox.Show( "Đã thêm trận đấu thành công! Bạn có muốn thêm đội hình cho trận đấu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            int matchId = Convert.ToInt32(MatchId);
                            Matchid = matchId;                            

                            if (result == DialogResult.Yes)
                            {
                                buttonHomelineup.Visible = true;
                                buttonSublineup.Visible = true;
                                buttonExit.Visible = true;
                                buttonSave.Visible = false;
                                panel1.Visible = false; // k cho sửa trận đấu đã thêm 
                                // KHÔNG đóng form để cho phép nhập đội hình
                            }
                            else
                            {
                                // Người dùng không muốn thêm đội hình → đóng form luôn
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm trận đấu vào bảng Match!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm trận đấu vào bảng MatchSchedule!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonHomelineup_Click(object sender, EventArgs e)
        {
            FormTaoDoiHinh form = new FormTaoDoiHinh(comboBoxHomeTeam.SelectedValue.ToString(), Matchid);
            form.ShowDialog();
        }

        private void buttonSublineup_Click(object sender, EventArgs e)
        {
            FormTaoDoiHinh form = new FormTaoDoiHinh(comboBoxAwayTeam.SelectedValue.ToString(), Matchid);
            form.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}
