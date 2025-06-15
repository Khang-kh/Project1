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
using quanly.tournament.NewFolder1;

namespace quanly
{
    public partial class FormSuaHoSoGiaiDau : Form
    {
        private FormQuanLyGiaiDau parentForm;
        private string connectionString = Program.connectString;
        private int tournamentId;
        private List<int> selectedTeamIDs = new List<int>();
        private List<(int id, string name, string logoUrl)> availableTeams = new List<(int, string, string)>();
        private Dictionary<int, Panel> teamPanels = new Dictionary<int, Panel>();
        public FormSuaHoSoGiaiDau(FormQuanLyGiaiDau parent, int tournamentId)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.tournamentId = tournamentId;
            LoadAvailableTeams();
            LoadTournamentInfo();
        }

        private void FormSuaHoSoGiaiDau_Load(object sender, EventArgs e)
        {
            LoadTournamentInfo(); // Tải thông tin giải đấu
            LoadTeamsByTournamentID(); // Tải danh sách đội bóng đã tham gia giải đấu
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh đại diện giải đấu";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picLogoTournament.Image = Image.FromFile(ofd.FileName);
                picLogoTournament.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void LoadAvailableTeams()
        {
            availableTeams.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT teamID, nameTeam, logoUrl FROM Team";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string logo = reader.IsDBNull(2) ? null : reader.GetString(2);
                    availableTeams.Add((id, name, logo));
                }
            }
        }
        private void LoadTournamentInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT tournamentName, startDate, endDate, avatarURL FROM Tournament WHERE tournamentID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", tournamentId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTounamentName.Text = reader.GetString(0);
                    dateTimePickerStart.Value = reader.GetDateTime(1);
                    dateTimePickerEnd.Value = reader.GetDateTime(2);
                    string logoPath = reader.IsDBNull(3) ? null : reader.GetString(3);
                    if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                    {
                        picLogoTournament.Image = Image.FromFile(logoPath);
                    }
                }
            }
        }
        private void LoadTeamsByTournamentID()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT T.teamID, T.nameTeam, T.logoUrl FROM Team T INNER JOIN TournamentTeams TT ON T.teamID = TT.teamID WHERE TT.tournamentID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", tournamentId);
                SqlDataReader reader = cmd.ExecuteReader();
                flpTeamList.Controls.Clear(); // Xóa các điều khiển hiện tại
                selectedTeamIDs.Clear(); // Xóa danh sách ID đội bóng đã chọn

                while (reader.Read())
                {
                    int teamId = reader.GetInt32(0);
                    string teamName = reader.GetString(1);
                    string logoUrl = reader.IsDBNull(2) ? null : reader.GetString(2);
                    selectedTeamIDs.Add(teamId);
                    AddTeamPanel(teamId, teamName, logoUrl); // Thêm panel cho mỗi đội
                }
            }
        }
        private void AddTeamPanel(int teamId, string teamName, string logoUrl)
        {
            Panel teamPanel = new Panel
            {
                Width = flpTeamList.Width - 351,
                Height = 85,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            PictureBox picLogo = new PictureBox
            {
                Width = 60,
                Height = 60,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(5, 10)
            };
            teamPanel.Controls.Add(picLogo);

            Label lblTitle = new Label
            {
                Text = "Tên đội:",
                Location = new Point(70, 10),
                AutoSize = true
            };
            teamPanel.Controls.Add(lblTitle);

            Label lblTeamName = new Label
            {
                Text = teamName,
                Location = new Point(140, 10),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            teamPanel.Controls.Add(lblTeamName);

            ComboBox cmbTeamList = new ComboBox
            {
                Location = new Point(70, 30),
                Width = teamPanel.Width - 110,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            foreach (var team in availableTeams)
            {
                cmbTeamList.Items.Add(new TeamItem { Text = team.name, Value = team.id });
            }
            if (teamId > 0)
            {
                cmbTeamList.SelectedItem = cmbTeamList.Items
                    .OfType<TeamItem>()
                    .FirstOrDefault(t => t.Value == teamId);

                var selectedItem = cmbTeamList.SelectedItem as TeamItem;
                if (selectedItem != null)
                {
                    lblTeamName.Text = selectedItem.Text;
                    UpdateTeamLogo(cmbTeamList, picLogo);
                }
            }
            cmbTeamList.DisplayMember = "Text";
            cmbTeamList.ValueMember = "Value";
            cmbTeamList.SelectedValue = teamId; // Set giá trị ban đầu
            UpdateTeamLogo(cmbTeamList, picLogo);

            cmbTeamList.SelectedIndexChanged += (s, e) =>
            {
                TeamItem selectedItem = cmbTeamList.SelectedItem as TeamItem;
                if (selectedItem != null)
                {
                    int selectedTeamId = selectedItem.Value;
                    string selectedTeamName = selectedItem.Text;

                    // Check trùng đội
                    foreach (Control otherPanel in flpTeamList.Controls)
                    {
                        if (otherPanel is Panel p && p != teamPanel)
                        {
                            ComboBox otherCb = p.Controls.OfType<ComboBox>().FirstOrDefault();
                            TeamItem otherItem = otherCb?.SelectedItem as TeamItem;
                            if (otherItem != null && otherItem.Value == selectedTeamId)
                            {
                                MessageBox.Show($"Đội '{selectedTeamName}' đã được chọn.", "Trùng đội", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cmbTeamList.SelectedIndex = -1;
                                return;
                            }
                        }
                    }

                    // Cập nhật tên và logo
                    lblTeamName.Text = selectedTeamName;
                    UpdateTeamLogo(cmbTeamList, picLogo);
                }
            };

            teamPanel.Controls.Add(cmbTeamList);

            Button btnDeleteSingle = new Button
            {
                Text = "X",
                Size = new Size(30, 30),
                Location = new Point(teamPanel.Width - 35, 5),
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            btnDeleteSingle.Click += (s, args) =>
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa đội này khỏi danh sách?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    flpTeamList.Controls.Remove(teamPanel);
                    selectedTeamIDs.Remove(teamId);
                }
            };
            teamPanel.Controls.Add(btnDeleteSingle);

            flpTeamList.Controls.Add(teamPanel);
            CheckBox chkDeleteMultiple = new CheckBox
            {
                Location = new Point(teamPanel.Width - 40, 40), // Điều chỉnh vị trí checkbox
                Text = "" // Bỏ chữ "Chọn" nếu chỉ muốn ô vuông
            };
            teamPanel.Controls.Add(chkDeleteMultiple);
        }
        void UpdateTeamLogo(ComboBox combo, PictureBox pic)
        {
            if (combo.SelectedItem != null)
            {
                var selectedItem = combo.SelectedItem;
                int selectedTeamId = (int)((dynamic)selectedItem).Value;
                string logoPath = availableTeams.FirstOrDefault(t => t.id == selectedTeamId).logoUrl;
                if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                {
                    using (var fs = new FileStream(logoPath, FileMode.Open, FileAccess.Read))
                    {
                        pic.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    pic.Image = null;
                }
            }
        }
        private void CbTeam_Format(object sender, ListControlConvertEventArgs e)
        {

            if (e.ListItem != null)
            {
                int teamId = ((dynamic)e.ListItem).Value;
                e.Value = (teamId != 0) ? "" : ((dynamic)e.ListItem).Text; // Ẩn tên đội trong ComboBox đã chọn
            }
        }
        private void DeleteTeamFromTournament(int teamId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM TournamentTeams WHERE tournamentID = @tournamentId AND teamID = @teamId";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                    cmd.Parameters.AddWithValue("@teamId", teamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form sửa
            parentForm.Show(); // Hiện lại form quản lý
        }
        private void flpTeamList_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string avatarPath = null;
                    if (picLogoTournament.Image != null)
                    {
                        string fileName = $"{Guid.NewGuid()}.png";
                        avatarPath = Path.Combine(Application.StartupPath, "Images", fileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(avatarPath));
                        picLogoTournament.Image.Save(avatarPath);
                    }

                    // Cập nhật thông tin giải đấu
                    string updateTournament = @"UPDATE Tournament SET tournamentName = @name, startDate = @start, endDate = @end, avatarURL = @avatar WHERE tournamentID = @id";
                    using (SqlCommand cmd = new SqlCommand(updateTournament, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtTounamentName.Text);
                        cmd.Parameters.AddWithValue("@start", dateTimePickerStart.Value);
                        cmd.Parameters.AddWithValue("@end", dateTimePickerEnd.Value);
                        cmd.Parameters.AddWithValue("@avatar", (object)avatarPath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", tournamentId);
                        cmd.ExecuteNonQuery();
                    }

                    // Kiểm tra trùng lặp tên đội bóng
                    HashSet<int> uniqueTeamIds = new HashSet<int>();
                    HashSet<string> teamNames = new HashSet<string>();
                    Dictionary<int, string> teamIdToName = new Dictionary<int, string>(); // ✅

                    foreach (Control control in flpTeamList.Controls)
                    {
                        if (control is Panel panel)
                        {
                            ComboBox combo = panel.Controls.OfType<ComboBox>().FirstOrDefault();
                            if (combo != null && combo.SelectedItem != null)
                            {
                                var selectedItem = combo.SelectedItem;
                                int teamID = (int)((dynamic)selectedItem).Value;
                                string teamName = ((dynamic)selectedItem).Text;

                                // Kiểm tra tên đội trùng lặp
                                if (!teamNames.Add(teamName))
                                {
                                    MessageBox.Show($"Đội bóng '{teamName}' đã được chọn nhiều lần trong danh sách.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                // Kiểm tra đội đã được thêm chưa
                                if (!uniqueTeamIds.Add(teamID))
                                {
                                    MessageBox.Show($"Đội bóng '{teamName}' đã được thêm vào danh sách.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                teamIdToName[teamID] = teamName; // ✅ lưu tên đội
                            }
                        }
                    }

                    // Kiểm tra xem đội có tham gia giải đấu khác không
                    foreach (int teamID in uniqueTeamIds)
                    {
                        string checkOtherTournament = "SELECT COUNT(*) FROM TournamentTeams WHERE teamID = @teamID AND tournamentID <> @currentTournamentID";
                        using (SqlCommand checkCmd = new SqlCommand(checkOtherTournament, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@teamID", teamID);
                            checkCmd.Parameters.AddWithValue("@currentTournamentID", tournamentId);
                            int count = (int)checkCmd.ExecuteScalar();
                            if (count > 0)
                            {
                                string teamName = teamIdToName.ContainsKey(teamID) ? teamIdToName[teamID] : $"ID {teamID}"; // ✅
                                MessageBox.Show($"Đội bóng '{teamName}' hiện đang tham gia một giải đấu khác.", "Đội đang thi đấu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // Xóa đội bóng cũ và thêm đội bóng mới
                    string deleteOldTeams = "DELETE FROM TournamentTeams WHERE tournamentID = @id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteOldTeams, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", tournamentId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    foreach (int teamID in uniqueTeamIds)
                    {
                        string insertTournamentTeam = @"INSERT INTO TournamentTeams (tournamentID, TeamID) VALUES (@tournamentID, @teamID)";
                        using (SqlCommand cmd = new SqlCommand(insertTournamentTeam, conn))
                        {
                            cmd.Parameters.AddWithValue("@tournamentID", tournamentId);
                            cmd.Parameters.AddWithValue("@teamID", teamID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Cập nhật thành công!");
                    LoadTeamsByTournamentID();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            AddTeamPanel(0, "", ""); // Thêm một panel mới với ComboBox rỗng
        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {

            // Danh sách các panel được chọn (checkbox được tích)
            var selectedPanelsToDelete = new List<Panel>();

            foreach (Control control in flpTeamList.Controls)
            {
                if (control is Panel panel)
                {
                    var chk = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                    if (chk != null && chk.Checked)
                    {
                        selectedPanelsToDelete.Add(panel);
                    }
                }
            }

            if (selectedPanelsToDelete.Count > 0)
            {
                var confirmDelete = MessageBox.Show($"Bạn có chắc muốn xóa {selectedPanelsToDelete.Count} đội đã chọn?",
                    "Xác nhận xóa đội", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmDelete == DialogResult.Yes)
                {
                    foreach (var panel in selectedPanelsToDelete)
                    {
                        ComboBox cb = panel.Controls.OfType<ComboBox>().FirstOrDefault();
                        if (cb?.SelectedItem is TeamItem selectedItem)
                        {
                            selectedTeamIDs.Remove(selectedItem.Value);
                        }

                        flpTeamList.Controls.Remove(panel);
                    }

                    MessageBox.Show("Đã xóa đội bóng được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return; // Sau khi xóa đội hàng loạt thì không lưu đội nào hết
            }

            // Nếu không chọn đội nào để xóa (checkbox không tích) và người dùng vẫn bấm nút
            if (flpTeamList.Controls.Count > 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một đội để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Trường hợp không xóa gì cả, thực hiện lưu danh sách đội hiện có
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Xóa hết đội cũ khỏi TournamentTeams
                string deleteOldTeams = "DELETE FROM TournamentTeams WHERE tournamentID = @id";
                using (SqlCommand cmd = new SqlCommand(deleteOldTeams, conn))
                {
                    cmd.Parameters.AddWithValue("@id", tournamentId);
                    cmd.ExecuteNonQuery();
                }

                // 2. Thêm lại các đội còn trong giao diện
                foreach (Control control in flpTeamList.Controls)
                {
                    if (control is Panel panel)
                    {
                        ComboBox cbTeam = panel.Controls.OfType<ComboBox>().FirstOrDefault();
                        if (cbTeam != null && cbTeam.SelectedItem is TeamItem selectedItem)
                        {
                            int selectedTeamId = selectedItem.Value;
                            string selectedTeamName = selectedItem.Text;

                            // Kiểm tra đội đã thuộc giải khác chưa
                            string checkOtherTournament = @"SELECT COUNT(*) FROM TournamentTeams 
                                                    WHERE teamID = @teamID AND tournamentID != @tournamentID";
                            using (SqlCommand checkCmd = new SqlCommand(checkOtherTournament, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@teamID", selectedTeamId);
                                checkCmd.Parameters.AddWithValue("@tournamentID", tournamentId);
                                int count = (int)checkCmd.ExecuteScalar();

                                if (count > 0)
                                {
                                    MessageBox.Show($"Đội bóng '{selectedTeamName}' đã tham gia một giải đấu khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            // Thêm vào bảng TournamentTeams
                            string insertTeam = @"INSERT INTO TournamentTeams (tournamentID, teamID)
                                          VALUES (@tournamentID, @teamID)";
                            using (SqlCommand insertCmd = new SqlCommand(insertTeam, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@tournamentID", tournamentId);
                                insertCmd.Parameters.AddWithValue("@teamID", selectedTeamId);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("Lưu thông tin giải đấu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private int GetTeamIdByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT teamID FROM Team WHERE nameTeam = @name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
