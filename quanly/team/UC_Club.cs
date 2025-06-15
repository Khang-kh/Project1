using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace quanly
{
    public partial class UC_Club : UserControl
    {
        string connectionString = Program.connectString;
        public string TeamID { get; private set; }

        public delegate void DeleteClubEventHandler(string teamId);
        public event DeleteClubEventHandler OnDeleteClub;

        public delegate void ViewDetailsEventHandler(string teamId);
        public event ViewDetailsEventHandler OnViewDetails;
        public UC_Club()
        {
            InitializeComponent();
            this.Click += UC_Club_Click;
            btnModify.Visible = false;
            btnDelete.Visible = false;
        }

        private void UC_Club_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.TeamID, out int teamId))
            {
                OnViewDetails?.Invoke(this.TeamID);
            }
            else
            {
                MessageBox.Show("Lỗi: TeamID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowBtnModify()
        {
            btnModify.Visible = true;
        }

        public void HideBtnModify()
        {
            btnModify.Visible = false;
        }

        public void ShowBtnDelete()
        {
            btnDelete.Visible = true;
        }

        public void HideBtnDelete()
        {
            btnDelete.Visible = false;
        }

        private (string nameTeam, string logoUrl) GetTeamById(string teamId, PictureBox picture)
        {
            string query = "SELECT nameTeam, logoUrl FROM Team WHERE teamID = @teamId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@teamId", teamId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string imageName = reader["logoUrl"].ToString();
                        picture.SizeMode = PictureBoxSizeMode.Zoom;

                        if (!string.IsNullOrWhiteSpace(imageName))
                        {
                            string imagePath = Path.Combine(Application.StartupPath, imageName);
                            if (File.Exists(imagePath))
                            {
                                try
                                {
                                    picture.LoadAsync(imagePath);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi khi tải ảnh logo từ file:\n" + ex.Message);
                                }
                            }
                            else
                            {
                                picture.Image = null; // Hoặc hiển thị ảnh mặc định
                                MessageBox.Show($"Không tìm thấy file ảnh: {imagePath}");
                            }
                        }
                        else
                        {
                            picture.Image = null;
                        }
                        return (reader["nameTeam"].ToString(), imageName); // Trả về tên file
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin đội bóng:\n" + ex.Message);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return ("", "");
            }
        }

        public void SetClubInfor(string teamId, string nameTeam, string logoUrl)
        {
            this.TeamID = teamId;
            lblClub.Text = nameTeam;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            if (!string.IsNullOrWhiteSpace(logoUrl))
            {
                // Tạo đường dẫn đầy đủ bằng cách kết hợp thư mục ứng dụng với đường dẫn từ database
                string imagePath = Path.Combine(Application.StartupPath, logoUrl);
                if (File.Exists(imagePath))
                {
                    try
                    {
                        pictureBox1.LoadAsync(imagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh logo từ file:\n" + ex.Message);
                    }
                }
                else
                {
                    pictureBox1.Image = null; // Hoặc hiển thị ảnh mặc định
                    MessageBox.Show($"Không tìm thấy file ảnh: {imagePath}");
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            
            FormSuaHoSoDoiBong editTeamForm = new FormSuaHoSoDoiBong(TeamID);
            if (editTeamForm.ShowDialog() == DialogResult.OK)
            {
                var teamInfo = GetTeamById(TeamID, pictureBox1);
                SetClubInfor(TeamID, teamInfo.nameTeam, teamInfo.logoUrl);
                if (this.Parent is FlowLayoutPanel panel)
                {
                    panel.Invalidate();
                }
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Sự kiện Click của PictureBox đã được chuyển hướng đến OnClubClicked
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Xóa đội bóng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Gọi sự kiện OnDeleteClub và truyền TeamId
                OnDeleteClub?.Invoke(TeamID);
            }
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            
        }

        private void lblClub_Click(object sender, EventArgs e)
        {
            FormChitietdoibong formChitiet = new FormChitietdoibong(int.Parse(this.TeamID)); // Chú ý: Chuyển TeamId sang int
            formChitiet.ShowDialog();
        }

        private void UC_Club_Load(object sender, EventArgs e)
        {

        }
    }
}