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


namespace quanly
{
    public partial class FormQuanLyDoiBong : Form
    {
        private Form previousForm;
        public FormQuanLyDoiBong(Form callerForm)
        {
            InitializeComponent();

            btnBack.Image = Properties.Resources.btnll;
            LoadListOfClubs();
            previousForm = callerForm;
        }
        string connectionString = Program.connectString;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuanLyDoiBong));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(66, 557);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Thêm đội bóng";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(265, 557);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Sửa đội bóng";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(464, 557);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 44);
            this.button3.TabIndex = 4;
            this.button3.Text = "Xóa đội bóng";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(657, 557);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(206, 44);
            this.button4.TabIndex = 5;
            this.button4.Text = "Hiển thị tất cả đội bóng";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(296, 49);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 67);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Quản Lý Đội Bóng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Window;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::quanly.Properties.Resources.btnll;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 46);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = "Đội bóng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 159);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(568, 34);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(771, 159);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 34);
            this.button5.TabIndex = 11;
            this.button5.Text = "Tìm kiếm";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(65, 213);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(798, 324);
            this.flowLayoutPanel1.TabIndex = 12;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // FormQuanLyDoiBong
            // 
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(925, 632);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.Name = "FormQuanLyDoiBong";
            this.Text = "QuanLyDoiBong";
            this.Load += new System.EventHandler(this.FormQuanLyDoiBong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }

        private void LoadListOfClubs()
        {
            flowLayoutPanel1.Controls.Clear();
            string query = "SELECT teamID, nameTeam, logoUrl FROM Team ORDER BY teamID DESC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string teamID = reader["teamID"].ToString();
                        string name = reader["nameTeam"].ToString();
                        string imageURL = reader["logoUrl"].ToString();

                        UC_Club banner = new UC_Club();
                        banner.SetClubInfor(teamID, name, imageURL);
                        banner.Click += UcClub_Click;
                        flowLayoutPanel1.Controls.Add(banner);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách đội bóng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void UcClub_Click(object sender, EventArgs e)
        {
            if (sender is UC_Club clickedClub)
            {
                if (!string.IsNullOrEmpty(clickedClub.TeamID) && int.TryParse(clickedClub.TeamID, out int teamId))
                {
                    FormChitietdoibong formChitiet = new FormChitietdoibong(teamId);
                    if (formChitiet.ShowDialog() == DialogResult.OK)
                    {
                        // Nếu bạn cần làm gì đó sau khi form chi tiết đóng, bạn có thể truy cập formChitiet.SelectedTeamId ở đây
                        // Ví dụ: int returnedTeamId = formChitiet.SelectedTeamId;
                        // Thực hiện hành động dựa trên returnedTeamId (nếu cần)
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi: TeamID của UC_Club không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void FormQuanLyDoiBong_Load(object sender, EventArgs e)
        {

        }

        
        //Hiện tất cả
        private void button4_Click(object sender, EventArgs e) 
        {
            flowLayoutPanel1.Controls.Clear();
            LoadListOfClubs();
        }

        //Nút tìm kiếm
        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            string keyword = textBox1.Text.Trim();
            LoadListOfClubs(keyword);
        }
        private void LoadListOfClubs(string keyword)
        {
            flowLayoutPanel1.Controls.Clear();

            string query = "SELECT teamID, nameTeam, logoUrl FROM Team WHERE nameTeam LIKE @keyword ORDER BY teamID DESC"; // Thêm ORDER BY

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%"); // Sử dụng @keyword

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string teamID = reader["teamID"].ToString();
                        string name = reader["nameTeam"].ToString();
                        string imageURL = reader["logoUrl"].ToString();
                        UC_Club banner = new UC_Club();
                        banner.SetClubInfor(teamID, name, imageURL);
                        banner.OnViewDetails += HandleViewClubDetails;
                        flowLayoutPanel1.Controls.Add(banner);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm đội bóng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void HandleViewClubDetails(string teamId)
        {
            if (int.TryParse(teamId, out int id))
            {
                FormChitietdoibong formChitiet = new FormChitietdoibong(id);
                formChitiet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lỗi: TeamID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click_1(object sender, EventArgs e) //Thêm đội bóng
        {
            FormThemDoiBong form = new FormThemDoiBong();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadListOfClubs();                
            }
            else if (form.DialogResult == DialogResult.Cancel)
            {
                // Người dùng có thể đã đóng form mà không lưu
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra trong quá trình thêm đội bóng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) //sửa đội bóng                    
        {
            // Ẩn nút sửa và hiển thị nút sửa trên tất cả các UC_Club
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_Club team)
                {
                    team.HideBtnDelete();
                    team.ShowBtnModify();
                }
            }            
        }


        private void button3_Click(object sender, EventArgs e) //Xóa đội bóng   
        {
            // Ẩn nút xóa và hiển thị nút sửa trên tất cả các UC_Club
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_Club team)
                {
                    team.HideBtnModify();
                    team.ShowBtnDelete();
                    team.OnDeleteClub += DeleteClub;
                }
            }
        }

        private void DeleteClub(string teamID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmdDeleteTeamPlayer = new SqlCommand("DELETE FROM Team_Player WHERE teamID = @teamID", conn))
                {
                    cmdDeleteTeamPlayer.Parameters.AddWithValue("@teamID", teamID);
                    cmdDeleteTeamPlayer.ExecuteNonQuery();
                }

                // Example: Delete from MatchSchedule
                using (SqlCommand cmdDeleteMatchSchedule = new SqlCommand("DELETE FROM MatchSchedule WHERE MatchTeamID_A = @teamID OR MatchTeamID_B = @teamID", conn))
                {
                    cmdDeleteMatchSchedule.Parameters.AddWithValue("@teamID", teamID);
                    cmdDeleteMatchSchedule.ExecuteNonQuery();
                }

                using (SqlCommand cmdDeleteTournamentTeams = new SqlCommand("DELETE FROM TournamentTeams WHERE teamID = @teamID", conn))
                {
                    cmdDeleteTournamentTeams.Parameters.AddWithValue("@teamID", teamID);
                    cmdDeleteTournamentTeams.ExecuteNonQuery();
                }

                // Example: Delete from Rank
                using (SqlCommand cmdDeleteRank = new SqlCommand("DELETE FROM Rank WHERE teamID = @teamID", conn))
                {
                    cmdDeleteRank.Parameters.AddWithValue("@teamID", teamID);
                    cmdDeleteRank.ExecuteNonQuery();
                }

                // Example: Delete from TeamAchievement
                using (SqlCommand cmdDeleteTeamAchievement = new SqlCommand("DELETE FROM TeamAchievement WHERE teamID = @teamID", conn))
                {
                    cmdDeleteTeamAchievement.Parameters.AddWithValue("@teamID", teamID);
                    cmdDeleteTeamAchievement.ExecuteNonQuery();
                }
                using (SqlCommand cmdDeleteTranDau = new SqlCommand(
                        "DELETE FROM TranDau WHERE team1ID = @teamID OR team2ID = @teamID", conn))
                {
                    cmdDeleteTranDau.Parameters.AddWithValue("@teamID", teamID);
                    cmdDeleteTranDau.ExecuteNonQuery();
                }
                using (SqlCommand cmdDeleteTeam = new SqlCommand("DELETE FROM Team WHERE teamID = @teamID", conn))
                {
                    cmdDeleteTeam.Parameters.AddWithValue("@teamID", teamID);
                    cmdDeleteTeam.ExecuteNonQuery();
                }


                using (SqlCommand cmdDeleteTeam = new SqlCommand("DELETE FROM Team WHERE teamID = @teamID", conn))
                {
                    cmdDeleteTeam.Parameters.AddWithValue("@teamID", teamID);
                    cmdDeleteTeam.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Đội bóng đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadListOfClubs(); // Refresh the list after deleting
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_Club team)
                {
                    team.HideBtnModify();
                    team.ShowBtnDelete();
                    team.OnDeleteClub += DeleteClub;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
