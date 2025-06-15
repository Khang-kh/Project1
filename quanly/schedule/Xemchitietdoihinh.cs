using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly.schedule
{
    public partial class Xemchitietdoihinh : Form
    {
        string connectionString = Program.connectString;
        public int ID { get; set; }
        public int TeamId { get; set; }
        public Xemchitietdoihinh(int id, int teamID)
        {
            InitializeComponent();
            ID = id;
            TeamId = teamID;
            LoadDoihinhchinh();
            LoadDoihinhphu();
        }
        private void LoadDoihinhchinh()
        {
            string query = @"
            SELECT p.playerID, p.namePlayer, p.avatarUrl, l.position
            FROM match_line_up l
            JOIN Player p ON l.playerID = p.playerID
            WHERE l.MatchID = @matchID AND l.teamID = @teamID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@matchID", ID);
                cmd.Parameters.AddWithValue("@teamID", TeamId);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int playerID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string imageUrl = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    string position = reader.GetString(3);

                    ShowPlayerchinh(position, name, imageUrl);

                }
            }
        }
        private void LoadDoihinhphu()
        {
            string query = @"
            SELECT p.playerID, p.namePlayer, p.avatarUrl, l.position
            FROM match_line_up_sub l
            JOIN Player p ON l.playerID = p.playerID
            WHERE l.MatchID = @matchID AND l.teamID = @teamID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@matchID", ID);
                cmd.Parameters.AddWithValue("@teamID", TeamId);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int playerID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string imageUrl = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    string position = reader.GetString(3);

                    ShowPlayerphu(position, name, imageUrl);

                }
            }
        }
        private void ShowPlayerchinh(string position, string playerName, string imageUrl)
        {
            switch (position)
            {
                case "ST":
                    lb1.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox1.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
                case "LCM":
                    lb2.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox2.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
                case "RCM":
                    lb3.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox3.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
                case "CB":
                    lb4.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox4.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
                case "GK":
                    lb5.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox5.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
            }
        }
        private void ShowPlayerphu(string position, string playerName, string imageUrl)
        {
            switch (position)
            {
                case "ST":
                    lb6.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox6.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
                case "LCM":
                    lb7.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox7.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
                case "RCM":
                    lb8.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox8.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
                case "CB":
                    lb9.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox9.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
                case "GK":
                    lb10.Text = playerName;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        try
                        {
                            pictureBox10.LoadAsync(imageUrl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    break;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}