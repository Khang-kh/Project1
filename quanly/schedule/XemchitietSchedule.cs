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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace quanly.schedule
{
    public partial class XemchitietSchedule : Form
    {
        string connectionString = Program.connectString;
        public int MatchId { get; set; }    
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set; }
        public XemchitietSchedule(int id,int teamid1,int teamid2)
        {
            InitializeComponent();
            MatchId = id;
            LoadScheduleDetail();
            TeamId1 = teamid1;
            TeamId2 = teamid2;
        }
        private void LoadScheduleDetail()
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
                    cmd.Parameters.AddWithValue("@MatchID", MatchId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lbGiaidau.Text = reader["tournamentName"].ToString();
                        lblocation.Text = reader["Location"].ToString();

                        DateTime MatchTime = Convert.ToDateTime(reader["MatchTime"]);
                        string formattedDate = MatchTime.ToString("yyyy-MM-dd HH:mm:ss");
                        lbTime.Text = formattedDate;
                        lbhome.Text = reader["HomeTeamName"].ToString();
                        lbaway.Text = reader["AwayTeamName"].ToString();

                        labelStatus.Text = reader["status_name"].ToString();
                        diem1.Text = reader["Score1"] == DBNull.Value ? "-" : reader["Score1"].ToString();
                        diem2.Text = reader["Score2"] == DBNull.Value ? "-" : reader["Score2"].ToString();

                        string imageURL = reader["Logo1_url"].ToString();
                        homepic.SizeMode = PictureBoxSizeMode.Zoom;

                        if (!string.IsNullOrWhiteSpace(imageURL))
                        {
                            try
                            {
                                homepic.LoadAsync(imageURL);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                            }
                        }
                        string imageURL2 = reader["Logo2_url"].ToString();
                        homepic.SizeMode = PictureBoxSizeMode.Zoom;

                        if (!string.IsNullOrWhiteSpace(imageURL2))
                        {
                            try
                            {
                                awaypic.LoadAsync(imageURL2);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                            }
                        }

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void buttonHomelineup_Click(object sender, EventArgs e)
        {
            Xemchitietdoihinh doihinh = new Xemchitietdoihinh(MatchId,TeamId1);
            doihinh.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSublineup_Click(object sender, EventArgs e)
        {
            Xemchitietdoihinh doihinh = new Xemchitietdoihinh(MatchId, TeamId2);
            doihinh.ShowDialog();
        }
    }
}
