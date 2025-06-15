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
using quanly;
using quanly.tournament;

namespace quanly
{

    public partial class FormXemHoSoGiaiDau : Form
    {
        private Form parentForm;
        string connectionString = Program.connectString;
        public FormXemHoSoGiaiDau(Form parent, int tournamentID)
        {
            InitializeComponent();
            parentForm = parent; // ← Gán form cha
            LoadTournamentDetail(tournamentID);
        }

        private void FormXemHoSoGiaiDau_Load(object sender, EventArgs e)
        {

        }
        private int ID;
        private void LoadTournamentDetail(int id)
        {
            LoadTeamsByTournamentID(id);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT tournamentName, startDate, endDate, avatarURL FROM Tournament WHERE tournamentID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // tournamentName
                    if (!reader.IsDBNull(0))
                        lbgd.Text = reader.GetString(0);
                    else
                        lbgd.Text = "Không có tên";

                    // startDate
                    if (!reader.IsDBNull(1))
                        lblNgayBatDau.Text = reader.GetDateTime(1).ToString("dd/MM/yyyy");
                    else
                        lblNgayBatDau.Text = "Chưa rõ";

                    // endDate
                    if (!reader.IsDBNull(2))
                        lblNgayKetThuc.Text = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                    else
                        lblNgayKetThuc.Text = "Chưa rõ";

                    // avatarURL (ảnh)
                    string logoPath = "";
                    if (!reader.IsDBNull(3))
                        logoPath = reader.GetString(3);

                    if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                    {
                        picLogoTournament.Image = Image.FromFile(logoPath);
                    }
                    else
                    {
                        picLogoTournament.Image = null; // hoặc ảnh mặc định
                    }
                }
                reader.Close();
            }
        }
        private void LoadTeamsByTournamentID(int tournamentID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT T.teamID, T.nameTeam, T.logoURL " +
                               "FROM Team T " +
                               "INNER JOIN TournamentTeams TT ON T.teamID = TT.teamID " +
                               "WHERE TT.tournamentID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", tournamentID);
                ID = tournamentID;
                SqlDataReader reader = cmd.ExecuteReader();

                flpTeamList.Controls.Clear(); // Xóa các panel cũ trước khi thêm mới

                while (reader.Read())
                {
                    string teamName = reader["nameTeam"].ToString();
                    string logoPath = reader["logoURL"].ToString();
                    int teamID = Convert.ToInt32(reader["teamID"]);

                    Panel teamPanel = new Panel();
                    teamPanel.Size = new Size(290, 100); // Điều chỉnh kích thước panel cho phù hợp
                    teamPanel.BorderStyle = BorderStyle.FixedSingle;
                    teamPanel.Margin = new Padding(10);

                    // PictureBox logo
                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(80, 80);
                    pic.Location = new Point(10, 10);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                        pic.Image = Image.FromFile(logoPath);

                    // Label "Tên đội:"
                    Label lblTeamLabel = new Label();
                    lblTeamLabel.Text = "Tên đội:";
                    lblTeamLabel.Font = new Font("Microsoft Sans Serif", 8.2F);
                    lblTeamLabel.Location = new Point(100, 10);
                    lblTeamLabel.AutoSize = true;
                    lblTeamLabel.TextAlign = ContentAlignment.MiddleLeft;

                    // Label chứa tên đội (readonly)
                    Label lblTeamName = new Label();
                    lblTeamName.Text = teamName;
                    lblTeamName.Font = new Font("Microsoft Sans Serif", 8.2F, FontStyle.Bold);
                    lblTeamName.Location = new Point(100, 30);
                    lblTeamName.AutoSize = true;
                    lblTeamName.TextAlign = ContentAlignment.MiddleLeft;

                    // Button xem đội
                    Button btnViewTeam = new Button();
                    btnViewTeam.Text = "Xem đội";
                    btnViewTeam.Size = new Size(90, 30);
                    btnViewTeam.Location = new Point(100, 60);
                    btnViewTeam.Tag = teamID;
                    btnViewTeam.Click += (s, e) =>
                    {
                        int id = (int)((Button)s).Tag;
                        FormChitietdoibong form = new FormChitietdoibong(id);
                        form.ShowDialog();
                    };

                    // Thêm control vào panel
                    teamPanel.Controls.Add(pic);
                    teamPanel.Controls.Add(lblTeamLabel);
                    teamPanel.Controls.Add(lblTeamName);
                    teamPanel.Controls.Add(btnViewTeam);

                    // Thêm panel vào FlowLayoutPanel
                    flpTeamList.Controls.Add(teamPanel);
                }

                reader.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
        }

        private void buttonTournamentRank_Click(object sender, EventArgs e)
        {
            FormBangXepHang form = new FormBangXepHang(ID);
            form.ShowDialog();
        }

        private void buttonTranDau_Click(object sender, EventArgs e)
        {
            Lichthidau_giaidau form = new Lichthidau_giaidau(ID);
            form.ShowDialog();
        }
    }
}
