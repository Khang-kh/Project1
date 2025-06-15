using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace quanly.schedule
{
    public partial class UC_Schedule : UserControl
    {
        string connectionString = Program.connectString;
        public UC_Schedule()
        {
            InitializeComponent();
            this.Click += UC_Schedule_Click;
            Modify.Visible = false;
            Delete.Visible = false;
        }
        public void ShowBtnModify()
        {
            Modify.Visible = true;
        }
        public void HideBtnModify()
        {
            Modify.Visible = false;
        }
        public void ShowBtnDelete()
        {
            Delete.Visible = true;
        }
        public void HideBtnDelete()
        {
            Delete.Visible = false;
        }
        public int MatchId { get; set; }
        public int TournamentId { get; set; }
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set; }
        public void SetMatchInfor(int matchId,int teamid1,int teamid2, string homeTeamName, string awayTeamName,string location, string matchTime, string homeLogoPath, string awayLogoPath, int? homeScore, int? awayScore, string statusName, int tournamentId)
        {
            MatchId = matchId;
            lbHome.Text = homeTeamName;
            lbAway.Text = awayTeamName;
            lbLocation.Text = location;
            lbStatus.Text = statusName;
            TournamentId = tournamentId;
            lbTime.Text = matchTime;
            TeamId1 = teamid1;
            TeamId2 = teamid2;


            // Lấy và hiển thị tên giải đấu từ TournamentId
            lbGiaidau.Text = GetTournamentNameById(tournamentId);
            lbStatus.Text = statusName;

            if (!string.IsNullOrWhiteSpace(homeLogoPath))
            {
                try
                {
                    homepic.LoadAsync(homeLogoPath);// Load ảnh bất đồng bộ, đỡ bị treo UI
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                }
            }

            if (!string.IsNullOrWhiteSpace(awayLogoPath))
            {
                try
                {
                    awaypic.LoadAsync(awayLogoPath);// Load ảnh bất đồng bộ, đỡ bị treo UI
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                }
            }

            // Hiển thị tỷ số
            ScoreHome.Text = homeScore.HasValue ? homeScore.Value.ToString() : "-";
            awayscore.Text = awayScore.HasValue ? awayScore.Value.ToString() : "-";
        }
        private string GetTournamentNameById(int tournamentId)
        {
            string query = "SELECT tournamentName FROM Tournament WHERE tournamentID = @tournamentId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Sử dụng using cho SqlCommand
                    {
                        cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                        using (SqlDataReader reader = cmd.ExecuteReader()) // Sử dụng using cho SqlDataReader
                        {
                            if (reader.Read())
                            {
                                return reader["tournamentName"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tên giải đấu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return "Không tìm thấy";
            }
        }
        private void UC_Schedule_Click(object sender, EventArgs e)
        {
            XemchitietSchedule detailform = new XemchitietSchedule(MatchId,TeamId1,TeamId2);
            detailform.ShowDialog();
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            EditSchedule edit = new EditSchedule(MatchId);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                var schedule = GetScheduleById(MatchId);
                SetMatchInfor(MatchId,schedule.teamid1, schedule.teamid2, schedule.homeTeamName, schedule.awayTeamName, schedule.location, schedule.matchTime, schedule.homeLogoPath, schedule.awayLogoPath, schedule.homeScore, schedule.awayScore, schedule.statusName, schedule.tournamentId);
            }
        }
        private (int teamid1, int teamid2, string homeTeamName, string awayTeamName, string location, string matchTime, string homeLogoPath, string awayLogoPath, int? homeScore, int? awayScore, string statusName, int tournamentId) GetScheduleById(int id)
        {
            string query = @"SELECT ms.MatchTeamID_A, ms.MatchTeamID_B, ms.MatchTime, ms.Score1, " +
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
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MatchID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (
                                    Convert.ToInt32(reader["MatchTeamID_A"]),
                                    Convert.ToInt32(reader["MatchTeamID_B"]),
                                    reader["HomeTeamName"].ToString(),
                                    reader["AwayTeamName"].ToString(),
                                    reader["Location"].ToString(),
                                    reader["MatchTime"].ToString(),
                                    reader["Logo1_url"].ToString(),
                                    reader["Logo2_url"].ToString(),
                                    reader["Score1"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Score1"]) : null,
                                    reader["Score2"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Score2"]) : null,
                                    reader["status_name"].ToString(),
                                    Convert.ToInt32(reader["TournamentID"])
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin trận đấu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Giá trị mặc định nếu không tìm thấy
            return (0, 0, "Không rõ", "Không rõ", "", "", "", "", null, null, "Không rõ", 0);
        }


        private void Delete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xoá trận đấu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Xóa match_line_up_sub
                        string deleteSub = "DELETE FROM match_line_up_sub WHERE MatchID = @matchID";
                        using (SqlCommand cmd = new SqlCommand(deleteSub, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@matchID", MatchId);
                            cmd.ExecuteNonQuery();
                        }

                        // Xóa match_line_up
                        string deleteMain = "DELETE FROM match_line_up WHERE MatchID = @matchID";
                        using (SqlCommand cmd = new SqlCommand(deleteMain, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@matchID", MatchId);
                            cmd.ExecuteNonQuery();
                        }

                        // Xóa TranDau
                        string deleteTD = "DELETE FROM TranDau WHERE matchID = @matchID";
                        using (SqlCommand cmd = new SqlCommand(deleteTD, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@matchID", MatchId);
                            cmd.ExecuteNonQuery();
                        }

                        // Xóa MatchSchedule
                        string deleteSchedule = "DELETE FROM MatchSchedule WHERE MatchID = @matchID";
                        using (SqlCommand cmd = new SqlCommand(deleteSchedule, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@matchID", MatchId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã xóa toàn bộ dữ liệu liên quan đến trận đấu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Parent.Controls.Remove(this);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(" Lỗi khi xóa trận đấu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
    }

