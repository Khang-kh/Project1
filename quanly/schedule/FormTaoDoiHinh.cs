using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;
using static quanly.FormChitietdoibong;
using System.Text.RegularExpressions;


namespace quanly.schedule
{
    public partial class FormTaoDoiHinh : Form
    {
        string connectionString = Program.connectString;
        public string TeamID { get; set; }
        public int matchid { get; set; }
        public FormTaoDoiHinh(string id, int matchid)
        {
            InitializeComponent();
            TeamID = id;
            this.matchid = matchid;
            LoadPlayerData1(TeamID);
            LoadPlayerData2(TeamID);
        }
        private void LoadPlayerData1(string TeamID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT p.playerID, p.namePlayer, p.avatarUrl FROM Player p JOIN Team_Player tp ON p.playerID = tp.playerID WHERE tp.teamID = @teamID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@teamID", TeamID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gán dữ liệu vào các ComboBox
                    comboBox1.DataSource = dt.Copy();
                    comboBox1.DisplayMember = "namePlayer";
                    comboBox1.ValueMember = "playerID";

                    comboBox2.DataSource = dt.Copy();
                    comboBox2.DisplayMember = "namePlayer";
                    comboBox2.ValueMember = "playerID";

                    comboBox3.DataSource = dt.Copy();
                    comboBox3.DisplayMember = "namePlayer";
                    comboBox3.ValueMember = "playerID";

                    comboBox4.DataSource = dt.Copy();
                    comboBox4.DisplayMember = "namePlayer";
                    comboBox4.ValueMember = "playerID";

                    comboBox5.DataSource = dt.Copy();
                    comboBox5.DisplayMember = "namePlayer";
                    comboBox5.ValueMember = "playerID";

                    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                    comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
                    comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
                    comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
                    comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;

                    UpdatePlayerLogos1();
                    ComboBox[] mainBoxes = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5 };
                    if (HasSavedLineup(matchid, Convert.ToInt32(TeamID), "match_line_up"))
                    {
                        LoadSavedLineup("match_line_up", mainBoxes, matchid, Convert.ToInt32(TeamID));
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách cầu thủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPlayerData2(string TeamID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT p.playerID, p.namePlayer, p.avatarUrl FROM Player p JOIN Team_Player tp ON p.playerID = tp.playerID WHERE tp.teamID = @teamID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@teamID", TeamID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gán dữ liệu vào các ComboBox
                    comboBox6.DataSource = dt.Copy();
                    comboBox6.DisplayMember = "namePlayer";
                    comboBox6.ValueMember = "playerID";

                    comboBox7.DataSource = dt.Copy();
                    comboBox7.DisplayMember = "namePlayer";
                    comboBox7.ValueMember = "playerID";

                    comboBox8.DataSource = dt.Copy();
                    comboBox8.DisplayMember = "namePlayer";
                    comboBox8.ValueMember = "playerID";

                    comboBox9.DataSource = dt.Copy();
                    comboBox9.DisplayMember = "namePlayer";
                    comboBox9.ValueMember = "playerID";

                    comboBox10.DataSource = dt.Copy();
                    comboBox10.DisplayMember = "namePlayer";
                    comboBox10.ValueMember = "playerID";

                    comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
                    comboBox7.SelectedIndexChanged += comboBox7_SelectedIndexChanged;
                    comboBox8.SelectedIndexChanged += comboBox8_SelectedIndexChanged;
                    comboBox9.SelectedIndexChanged += comboBox9_SelectedIndexChanged;
                    comboBox10.SelectedIndexChanged += comboBox10_SelectedIndexChanged;

                    UpdatePlayerLogos2();
                    ComboBox[] subBoxes = { comboBox6, comboBox7, comboBox8, comboBox9, comboBox10 };
                    if (HasSavedLineup(matchid, Convert.ToInt32(TeamID), "match_line_up_sub"))
                    {
                        LoadSavedLineup("match_line_up_sub", subBoxes, matchid, Convert.ToInt32(TeamID));
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách cầu thủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdatePlayerLogos1()
        {
            UpdateLogoFromComboBox1(comboBox1, pictureBox1);
            UpdateLogoFromComboBox1(comboBox2, pictureBox2);
            UpdateLogoFromComboBox1(comboBox3, pictureBox3);
            UpdateLogoFromComboBox1(comboBox4, pictureBox4);
            UpdateLogoFromComboBox1(comboBox5, pictureBox5);
        }
        private void UpdatePlayerLogos2()
        {
            UpdateLogoFromComboBox2(comboBox6, pictureBox6);
            UpdateLogoFromComboBox2(comboBox7, pictureBox7);
            UpdateLogoFromComboBox2(comboBox8, pictureBox8);
            UpdateLogoFromComboBox2(comboBox9, pictureBox9);
            UpdateLogoFromComboBox2(comboBox10, pictureBox10);
        }
        private void UpdateLogoFromComboBox1(System.Windows.Forms.ComboBox comboBox, PictureBox pictureBox)
        {
            if (comboBox.SelectedItem is DataRowView row)
            {
                string logoPath = row["avatarUrl"].ToString();
                if (!string.IsNullOrWhiteSpace(logoPath) && File.Exists(logoPath))
                {
                    pictureBox.LoadAsync(logoPath);
                }
                else
                {
                    pictureBox.Image = null; // hoặc đặt ảnh mặc định
                }
            }
        }
        private void UpdateLogoFromComboBox2(System.Windows.Forms.ComboBox comboBox, PictureBox pictureBox)
        {
            if (comboBox.SelectedItem is DataRowView row)
            {
                string logoPath = row["avatarUrl"].ToString();
                if (!string.IsNullOrWhiteSpace(logoPath) && File.Exists(logoPath))
                {
                    pictureBox.LoadAsync(logoPath);
                }
                else
                {
                    pictureBox.Image = null; // hoặc đặt ảnh mặc định
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox1(comboBox1, pictureBox1);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox1(comboBox2, pictureBox2);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox1(comboBox3, pictureBox3);
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox1(comboBox4, pictureBox4);
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox1(comboBox5, pictureBox5);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox2(comboBox6, pictureBox6);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox2(comboBox7, pictureBox7);
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox2(comboBox8, pictureBox8);
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox2(comboBox9, pictureBox9);
        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogoFromComboBox2(comboBox10, pictureBox10);
        }

        bool HasSavedLineup(int matchID, int teamID, string table)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT COUNT(*) FROM {table} WHERE MatchID = @matchID AND teamID = @teamID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@matchID", matchID);
                cmd.Parameters.AddWithValue("@teamID", teamID);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }




        private void button3_Click(object sender, EventArgs e) //nút save á tr
        {
            string[] positions = { "ST", "LCM", "RCM", "CB", "GK" };
            ComboBox[] playerBoxes = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5 };

            // 1. Kiểm tra trùng cầu thủ trong đội hình chính
            var mainIDs = new HashSet<int>();
            for (int i = 0; i < playerBoxes.Length; i++)
            {
                int playerID = Convert.ToInt32(playerBoxes[i].SelectedValue);
                if (!mainIDs.Add(playerID))
                {
                    MessageBox.Show("Không được trùng cầu thủ trong đội hình chính!");
                    return; // dừng lưu
                }
            }
            int teamid = Convert.ToInt32(TeamID);

            // 2. Kiểm tra đội hình phụ đã lưu chưa
            if (HasSavedLineup(matchid, teamid, "match_line_up_sub"))
            {
                // Lấy danh sách cầu thủ đội hình phụ
                var subIDs = new List<int>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT playerID FROM match_line_up_sub WHERE MatchID = @matchID AND teamID = @teamID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@matchID", matchid);
                    cmd.Parameters.AddWithValue("@teamID", teamid);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subIDs.Add(reader.GetInt32(0));
                        }
                    }
                }

                // So sánh nếu có cầu thủ trong đội hình chính trùng đội hình phụ
                if (mainIDs.Any(id => subIDs.Contains(id)))
                {
                    MessageBox.Show("Đội hình chính không được trùng với đội hình phụ đã lưu!");
                    return; // dừng lưu
                }
            }

            // Xóa đội hình chính cũ (nếu muốn ghi đè) trước khi thêm mới
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // Xóa trước dữ liệu cũ của đội hình chính
                    string deleteQuery = "DELETE FROM match_line_up WHERE MatchID = @matchID AND teamID = @teamID";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, trans);
                    deleteCmd.Parameters.AddWithValue("@matchID", matchid);
                    deleteCmd.Parameters.AddWithValue("@teamID", teamid);
                    deleteCmd.ExecuteNonQuery();

                    // Insert mới
                    string insertQuery = "INSERT INTO match_line_up(MatchID, teamID, playerID, position) VALUES(@matchID, @teamID, @playerID, @position)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn, trans);

                    cmd.Parameters.Add("@matchID", SqlDbType.Int).Value = matchid;
                    cmd.Parameters.Add("@teamID", SqlDbType.Int).Value = teamid;
                    cmd.Parameters.Add("@playerID", SqlDbType.Int);
                    cmd.Parameters.Add("@position", SqlDbType.VarChar);

                    for (int i = 0; i < 5; i++)
                    {
                        int playerID = Convert.ToInt32(playerBoxes[i].SelectedValue);
                        string pos = positions[i];

                        cmd.Parameters["@playerID"].Value = playerID;
                        cmd.Parameters["@position"].Value = pos;

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Lưu đội hình đội chính thành công!");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi lưu đội hình: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadSavedLineup(string tableName, ComboBox[] comboBoxes, int matchID, int teamID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT playerID FROM {tableName} WHERE MatchID = @matchID AND teamID = @teamID ORDER BY position";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@matchID", matchID);
                cmd.Parameters.AddWithValue("@teamID", teamID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int index = 0;
                    while (reader.Read() && index < comboBoxes.Length)
                    {
                        int savedPlayerID = reader.GetInt32(0);
                        comboBoxes[index].SelectedValue = savedPlayerID;
                        index++;
                    }
                }
            }
        }







        private void buttonSaveSub_Click(object sender, EventArgs e)
        {
            string[] positions = { "ST", "LCM", "RCM", "CB", "GK" };
            ComboBox[] playerBoxes = { comboBox6, comboBox7, comboBox8, comboBox9, comboBox10 };

            // 1. Kiểm tra trùng cầu thủ trong đội hình phụ
            var subIDsCurrent = new HashSet<int>();
            for (int i = 0; i < playerBoxes.Length; i++)
            {
                int playerID = Convert.ToInt32(playerBoxes[i].SelectedValue);
                if (!subIDsCurrent.Add(playerID))
                {
                    MessageBox.Show("Không được trùng cầu thủ trong đội hình phụ!");
                    return; // dừng lưu
                }
            }
            int teamid = Convert.ToInt32(TeamID);

            // 2. Kiểm tra đội hình chính đã lưu chưa
            if (HasSavedLineup(matchid, teamid, "match_line_up"))
            {
                // Lấy danh sách cầu thủ đội hình chính
                var mainIDs = new List<int>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT playerID FROM match_line_up WHERE MatchID = @matchID AND teamID = @teamID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@matchID", matchid);
                    cmd.Parameters.AddWithValue("@teamID", teamid);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mainIDs.Add(reader.GetInt32(0));
                        }
                    }
                }

                // So sánh nếu có cầu thủ trong đội hình phụ trùng đội hình chính
                if (subIDsCurrent.Any(id => mainIDs.Contains(id)))
                {
                    MessageBox.Show("Đội hình phụ không được trùng với đội hình chính đã lưu!");
                    return; // dừng lưu
                }
            }

            // Xóa đội hình phụ cũ (nếu muốn ghi đè)
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // Xóa dữ liệu cũ của đội hình phụ
                    string deleteQuery = "DELETE FROM match_line_up_sub WHERE MatchID = @matchID AND teamID = @teamID";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, trans);
                    deleteCmd.Parameters.AddWithValue("@matchID", matchid);
                    deleteCmd.Parameters.AddWithValue("@teamID", teamid);
                    deleteCmd.ExecuteNonQuery();

                    // Insert mới
                    string insertQuery = "INSERT INTO match_line_up_sub(MatchID, teamID, playerID, position) VALUES(@matchID, @teamID, @playerID, @position)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn, trans);

                    cmd.Parameters.Add("@matchID", SqlDbType.Int).Value = matchid;
                    cmd.Parameters.Add("@teamID", SqlDbType.Int).Value = teamid;
                    cmd.Parameters.Add("@playerID", SqlDbType.Int);
                    cmd.Parameters.Add("@position", SqlDbType.VarChar);

                    for (int i = 0; i < 5; i++)
                    {
                        int playerID = Convert.ToInt32(playerBoxes[i].SelectedValue);
                        string pos = positions[i];

                        cmd.Parameters["@playerID"].Value = playerID;
                        cmd.Parameters["@position"].Value = pos;

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Lưu đội hình đội phụ thành công!");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi lưu đội hình: " + ex.Message);
                }
            }
        }
    }
    
}
