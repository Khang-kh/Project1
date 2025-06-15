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

namespace quanly.schedule
{
    public partial class FormQuanlylichthidau : Form
    {
        string connectionString = Program.connectString;
        private Form previousForm;
        public FormQuanlylichthidau(Form callerForm)
        {
            InitializeComponent();
            LoadListOfSchedule();
            previousForm = callerForm;
        }
        private void LoadListOfSchedule()
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
                    banner.SetMatchInfor(matchId,teamid1,teamid2, homeTeamName, awayTeamName,location, formattedTime, homeLogoPath, awayLogoPath, homeScore, awayScore,statusName, tournamentId);
                    banner.Tag = matchId;
                    flowLayoutPanel1.Controls.Add(banner);
                }
                reader.Close();
            }
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadListOfSchedule();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu");
                txtSearch.Focus();
                return;
            }
            string keyword = txtSearch.Text.Trim();
            LoadListOfSchedule(keyword);
        }
        private void LoadListOfSchedule(string keyword)
        {
            flowLayoutPanel1.Controls.Clear();

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
                    banner.SetMatchInfor(matchId,teamid1,teamid2, homeTeamName, awayTeamName, location, formattedTime, homeLogoPath, awayLogoPath, homeScore, awayScore, statusName, tournamentId);
                    banner.Tag = matchId;
                    flowLayoutPanel1.Controls.Add(banner);
                }
                reader.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddnewSchedule form = new AddnewSchedule();
            if (form.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();
                LoadListOfSchedule();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_Schedule s1)
                {
                    s1.HideBtnDelete();
                    s1.ShowBtnModify();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_Schedule s2)
                {
                    s2.ShowBtnDelete();
                    s2.HideBtnModify();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }
    }
}
