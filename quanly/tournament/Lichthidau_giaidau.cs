using quanly.schedule;
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

namespace quanly.tournament
{
    public partial class Lichthidau_giaidau : Form
    {
        string connectionString = Program.connectString;
        public int TournamentId { get; set; }
        public Lichthidau_giaidau(int id)
        {
            InitializeComponent();
            TournamentId = id;
            LoadMatchSchedule();
        }
        private void LoadMatchSchedule()
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
                                    "WHERE m.TournamentID = @TournamentId " +
                                    "ORDER BY m.MatchTime";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TournamentId", TournamentId);

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

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
