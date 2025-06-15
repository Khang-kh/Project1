using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace quanly
{

    public partial class FormTaoHoSoGiaiDau : Form
    {
        private FormQuanLyGiaiDau previousForm;
        string connectionString = Program.connectString;
        private List<int> selectedTeamIDs = new List<int>();
        private List<(int id, string name, string logoUrl)> availableTeams = new List<(int, string, string)>();
        private Dictionary<int, Panel> teamPanels = new Dictionary<int, Panel>(); // Dictionary để theo dõi các panel đội bóng
        private List<int> usedTeamIds = new List<int>(); // Danh sách các TeamID đã được sử dụng
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
        public FormTaoHoSoGiaiDau(FormQuanLyGiaiDau formGoc)
        {
            InitializeComponent();
            previousForm = formGoc;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void picLogoTournament_Click(object sender, EventArgs e)
        {

        }

        private void txtListPlayer_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadImageTo(picLogoTournament);
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các đội chưa được chọn
            var unselectedTeams = availableTeams.Where(t => !usedTeamIds.Contains(t.id)).ToList();
            if (unselectedTeams.Count == 0)
            {
                MessageBox.Show("Tất cả các đội đã được thêm vào giải đấu.");
                return;
            }

            Panel teamPanel = new Panel
            {
                Width = flpTeamList.Width - 351,
                Height = 85, // Giảm chiều cao panel
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5) // Tăng margin cho thoáng hơn
            };

            PictureBox picLogo = new PictureBox
            {
                Width = 60, // Giảm kích thước logo
                Height = 60, // Giảm kích thước logo
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(5, 10) // Điều chỉnh vị trí logo
            };
            teamPanel.Controls.Add(picLogo);

            Label lblTitle = new Label
            {
                Text = "Tên đội:",
                Location = new Point(70, 10), // Điều chỉnh vị trí label
                AutoSize = true
            };
            teamPanel.Controls.Add(lblTitle);

            Label lblTeamName = new Label
            {
                Text = "Chưa chọn",
                Location = new Point(140, 10), // Điều chỉnh vị trí tên đội
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            teamPanel.Controls.Add(lblTeamName);

            ComboBox cmbTeamList = new ComboBox
            {
                Location = new Point(70, 30), // Điều chỉnh vị trí combobox
                Width = teamPanel.Width - 110, // Tăng chiều rộng combobox
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTeamList.Tag = teamPanel; // Lưu trữ panel vào Tag của ComboBox

            // Thêm các đội chưa được chọn vào ComboBox
            foreach (var team in unselectedTeams)
            {
                cmbTeamList.Items.Add(new { Text = team.name, Value = team.id });
            }

            cmbTeamList.DisplayMember = "Text";
            cmbTeamList.ValueMember = "Value";

            int? previousTeamID = null;

            cmbTeamList.SelectedIndexChanged += (s, args) =>
            {
                if (cmbTeamList.SelectedItem != null)
                {
                    var selectedItem = cmbTeamList.SelectedItem;
                    int newTeamID = (int)((dynamic)selectedItem).Value;
                    string teamName = ((dynamic)selectedItem).Text;

                    lblTeamName.Text = teamName;

                    string logoPath = availableTeams.FirstOrDefault(t => t.id == newTeamID).logoUrl;
                    if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                        picLogo.Image = Image.FromFile(logoPath);
                    else
                        picLogo.Image = null;

                    // Xóa teamID cũ ra khỏi danh sách đã dùng
                    if (previousTeamID.HasValue)
                    {
                        selectedTeamIDs.Remove(previousTeamID.Value);
                        usedTeamIds.Remove(previousTeamID.Value);
                        teamPanels.Remove(previousTeamID.Value);
                    }

                    // Thêm teamID mới
                    if (!selectedTeamIDs.Contains(newTeamID))
                    {
                        selectedTeamIDs.Add(newTeamID);
                        usedTeamIds.Add(newTeamID);
                        teamPanels[newTeamID] = teamPanel;
                    }

                    previousTeamID = newTeamID; // Cập nhật ID hiện tại
                }
            };

            teamPanel.Controls.Add(cmbTeamList);

            Button btnDeleteSingle = new Button
            {
                Text = "X",
                Size = new Size(30, 30), // Tăng kích thước nút X
                Location = new Point(teamPanel.Width - 35, 5), // Điều chỉnh vị trí nút X
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            btnDeleteSingle.Click += (s, args) =>
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa đội này khỏi danh sách?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    if (cmbTeamList.SelectedItem != null)
                    {
                        var item = (dynamic)cmbTeamList.SelectedItem;
                        int teamIdToRemove = item.Value;
                        selectedTeamIDs.Remove(teamIdToRemove);
                        usedTeamIds.Remove(teamIdToRemove);
                        teamPanels.Remove(teamIdToRemove);
                    }
                    flpTeamList.Controls.Remove(teamPanel);
                }
            };
            teamPanel.Controls.Add(btnDeleteSingle);

            CheckBox chkDeleteMultiple = new CheckBox
            {
                Location = new Point(teamPanel.Width - 40, 40), // Điều chỉnh vị trí checkbox
                Text = "" // Bỏ chữ "Chọn" nếu chỉ muốn ô vuông
            };
            teamPanel.Controls.Add(chkDeleteMultiple);

            flpTeamList.Controls.Add(teamPanel);
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTounamentName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên giải đấu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    // 1. Lưu thông tin giải đấu
                    string insertTournament = @"INSERT INTO Tournament (tournamentName, startDate, endDate, avatarURL)
                                                 OUTPUT INSERTED.tournamentID
                                                 VALUES (@name, @start, @end, @avatar)";
                    int tournamentID;

                    using (SqlCommand cmd = new SqlCommand(insertTournament, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtTounamentName.Text);
                        cmd.Parameters.AddWithValue("@start", dateTimePickerStart.Value);
                        cmd.Parameters.AddWithValue("@end", dateTimePickerEnd.Value);
                        cmd.Parameters.AddWithValue("@avatar", (object)avatarPath ?? DBNull.Value);
                        tournamentID = (int)cmd.ExecuteScalar();
                    }

                    // 2. Kiểm tra trùng lặp đội bóng và đội bóng đã tham gia giải đấu khác
                    HashSet<int> uniqueSelectedTeamIDs = new HashSet<int>();
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

                                if (uniqueSelectedTeamIDs.Contains(teamID))
                                {
                                    MessageBox.Show($"Đội bóng '{teamName}' đã được chọn nhiều lần trong danh sách.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return; // Dừng việc lưu nếu có trùng lặp
                                }
                                uniqueSelectedTeamIDs.Add(teamID);
                            }
                        }
                    }

                    // 3. Lưu thông tin đội bóng (chỉ khi không có trùng lặp và không tham gia giải đấu khác)
                    foreach (int teamID in uniqueSelectedTeamIDs)
                    {
                        string insertTournamentTeam = @"INSERT INTO TournamentTeams (tournamentID, TeamID)
                                                     VALUES (@tournamentID, @teamID)";
                        using (SqlCommand cmd = new SqlCommand(insertTournamentTeam, conn))
                        {
                            cmd.Parameters.AddWithValue("@tournamentID", tournamentID);
                            cmd.Parameters.AddWithValue("@teamID", teamID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Lưu thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form hiện tại
            previousForm.Show(); // Hiện lại form quản lý
        }

        private void lblTounamentName_Click(object sender, EventArgs e)
        {

        }

        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTounamentName_TextChanged(object sender, EventArgs e)
        {

        }


        private void FormTaoHoSoGiaiDau_Load(object sender, EventArgs e)
        {
            LoadAvailableTeams();
        }

        private void flpTeamList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void UploadImageTo(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh logo đội bóng";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            List<int> teamsToRemove = new List<int>();
            List<Panel> panelsToRemove = new List<Panel>();

            foreach (Control control in flpTeamList.Controls)
            {
                if (control is Panel panel)
                {
                    CheckBox chkDelete = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                    ComboBox combo = panel.Controls.OfType<ComboBox>().FirstOrDefault();

                    if (chkDelete != null && chkDelete.Checked && combo != null && combo.SelectedItem != null)
                    {
                        var selectedItem = combo.SelectedItem;
                        int teamIdToRemove = (int)((dynamic)selectedItem).Value;
                        teamsToRemove.Add(teamIdToRemove);
                        panelsToRemove.Add(panel);
                    }
                }
            }

            if (teamsToRemove.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một đội bóng để xóa.", "Chưa chọn đội", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa {teamsToRemove.Count} đội bóng đã chọn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (int teamIdToRemove in teamsToRemove)
                {
                    if (teamPanels.ContainsKey(teamIdToRemove))
                    {
                        flpTeamList.Controls.Remove(teamPanels[teamIdToRemove]);
                        selectedTeamIDs.Remove(teamIdToRemove);
                        usedTeamIds.Remove(teamIdToRemove);
                        teamPanels.Remove(teamIdToRemove);
                    }
                }
                MessageBox.Show($"Đã xóa {teamsToRemove.Count} đội bóng đã chọn.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}