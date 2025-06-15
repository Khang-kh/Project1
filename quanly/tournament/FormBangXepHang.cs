using quanly;
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
    public partial class FormBangXepHang : Form
    {
        public int TournamentID { get; set; }
        string connectionString = Program.connectString;
        public FormBangXepHang(int id)
        {
            InitializeComponent();
            TournamentID = id;
        }

        private void FormBangXepHang_Load(object sender, EventArgs e)
        {
            LoadRankings();
        }
        void LoadRankings()
        {
            string query = @"
            SELECT R.*, T.nameTeam, T.logoUrl
            FROM Rank R
            JOIN Team T ON R.teamID = T.teamID
            WHERE R.tournamentID = @tournamentID";

            List<dynamic> rankList = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tournamentID", TournamentID);
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
                        if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                        {
                            logo = Image.FromFile(logoPath);
                        }

                        rankList.Add(new
                        {
                            TeamName = reader["nameTeam"].ToString(),
                            Wins = wins,
                            Draws = draws,
                            Losses = losses,
                            GoalsFor = goalsFor,
                            GoalsAgainst = goalsAgainst,
                            Points = points,
                            GoalDiff = goalDiff,
                            Logo = logo
                        });
                    }
                }
            }

            var sortedList = rankList
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalDiff)
                .ToList();

            flpRankList.Controls.Clear();
            int position = 1;

            foreach (var item in sortedList)
            {
                UC_RankItem uc = new UC_RankItem();
                uc.SetData(position++, item.Logo, item.TeamName, item.Wins, item.Draws, item.Losses);
                flpRankList.Controls.Add(uc);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void flpRankList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
