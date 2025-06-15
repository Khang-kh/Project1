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

namespace quanly
{
    public partial class FormQLPlayer : Form
    {
        private Form previousForm;

        string connectionString = Program.connectString;
        private string selectedPlayerId = null;
        private string selectedPlayerName = null;

        public DataTable GetData(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public FormQLPlayer(Form callerForm)
        {
            InitializeComponent();
            previousForm = callerForm;
        }

        private void LblDoibong_Click(object sender, EventArgs e)
        {

        }

        private void LblSoao_Click(object sender, EventArgs e)
        {

        }

        private void BtnXoacauthu_Click(object sender, EventArgs e)
        {
            IsDeleteMode = true;
            isEditModeAll = false;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is UCcauthu_doibong playerCard)
                {
                    playerCard.SetDeleteMode(IsDeleteMode); // Cập nhật hiển thị nút xóa
                    playerCard.SetEditMode(isEditModeAll);
                }
            }

            // Bỏ chọn cầu thủ khi bật chế độ xóa (tùy chọn)
            if (IsDeleteMode)
            {
                selectedPlayerId = null;
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is UCcauthu_doibong)
                    {
                        control.BackColor = SystemColors.Control;
                    }
                }
            }
        }

        private void Quanlycauthu_Load(object sender, EventArgs e)
        {
            LoadPlayerData();
        }
        private void LoadPlayerData()
        {
            string query = @"
            SELECT 
            p.playerID, 
            p.namePlayer, 
            t.nameTeam, 
            p.shirtNumber,
            p.avatarUrl
            FROM Player p
            INNER JOIN Team_Player tp ON p.playerID = tp.playerID
            INNER JOIN Team t ON tp.teamID = t.teamID
            ORDER BY p.namePlayer ASC ";

            DataTable dt = GetData(query);

            flowLayoutPanel1.Controls.Clear();


            foreach (DataRow row in dt.Rows)
            {
                UCcauthu_doibong playerCard = new UCcauthu_doibong();
                playerCard.PlayerId = row["playerID"].ToString();
                playerCard.PlayerName = row["namePlayer"].ToString();
                playerCard.ShirtNumber = row["shirtNumber"].ToString();
                playerCard.TeamName = row["nameTeam"].ToString();
                playerCard.SuaClick += PlayerCard_SuaClick;
                playerCard.XoaClick += PlayerCard_XoaClick;

                if (row["avatarUrl"] != DBNull.Value)
                {
                    try
                    {
                        playerCard.Avatar = Image.FromFile(row["avatarUrl"].ToString()); // Thay đổi ở đây
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine("Lỗi tải ảnh: " + ex.Message);
                    }
                }
               

                flowLayoutPanel1.Controls.Add(playerCard);


                // Gắn sự kiện Click cho PlayerCard (nếu bạn muốn xử lý click trên từng card)
                playerCard.Click += PlayerCard_Click;
                foreach (Control control in playerCard.Controls)
                {
                    control.Click += PlayerCard_Click;// Để click vào label hoặc picturebox cũng kích hoạt sự kiện
                }
            }
        }


        private void PlayerCard_Click(object sender, EventArgs e)
        {
            UCcauthu_doibong clickedCard = null;
            if (sender is UCcauthu_doibong card)
            {
                clickedCard = card;
            }
            else if (sender is Control control && control.Parent is UCcauthu_doibong parentCard)
            {
                clickedCard = parentCard;
            }
            if (clickedCard != null)
            {
                selectedPlayerId = clickedCard.PlayerId;

                // Tùy chọn: Hiển thị trực quan cầu thủ nào đang được chọn
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is UCcauthu_doibong uc)
                    {
                        uc.BackColor = SystemColors.Control;
                    }
                }
                clickedCard.BackColor = Color.LightBlue;

                selectedPlayerName = clickedCard.PlayerName; // Cập nhật tên nếu cần
            }
        }

        private void PlayerCard_SuaClick(object sender, EventArgs e)
        {
            if (sender is UCcauthu_doibong clickedCard)
            {
                string playerIdToEdit = clickedCard.PlayerId;
                // Mở form Suacauthu và truyền playerId
                Suacauthu form = new Suacauthu(playerIdToEdit);
                form.ShowDialog();
                LoadPlayerData(); // Tải lại dữ liệu sau khi sửa (tùy chọn)
            }
        }

        private void PlayerCard_XoaClick(object sender, EventArgs e)
        {
            if (sender is UCcauthu_doibong clickedCard)
            {
                string playerIdToDelete = clickedCard.PlayerId;

                // Hiển thị hộp thoại xác nhận và thực hiện xóa (code xóa của bạn)
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa cầu thủ '{clickedCard.PlayerName}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (DeletePlayerFromDatabase(playerIdToDelete)) 
                    {
                        flowLayoutPanel1.Controls.Remove(clickedCard); // Xóa khỏi giao diện
                        MessageBox.Show("Đã xóa cầu thủ thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa cầu thủ thất bại!");
                    }
                }
            }

        }

        private bool DeletePlayerFromDatabase(string playerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // Bắt đầu transaction

                try
                {
                    // 1. Xóa bản ghi từ Team_Player
                    string deleteTeamPlayerQuery = "DELETE FROM Team_Player WHERE playerID = @PlayerID";
                    using (SqlCommand deleteTeamPlayerCmd = new SqlCommand(deleteTeamPlayerQuery, conn, transaction))
                    {
                        deleteTeamPlayerCmd.Parameters.AddWithValue("@PlayerID", playerId);
                        deleteTeamPlayerCmd.ExecuteNonQuery();
                    }

                    // 2. Xóa bản ghi từ Player
                    string deletePlayerQuery = "DELETE FROM Player WHERE playerID = @PlayerID";
                    using (SqlCommand deletePlayerCmd = new SqlCommand(deletePlayerQuery, conn, transaction))
                    {
                        deletePlayerCmd.Parameters.AddWithValue("@PlayerID", playerId);
                        deletePlayerCmd.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Commit transaction nếu mọi thứ thành công
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback transaction nếu có lỗi
                    Console.WriteLine("Lỗi xóa: " + ex.ToString());
                    return false;
                }
            }
        }


        private void PlayerPanel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel)sender;
            selectedPlayerId = clickedPanel.Tag.ToString();

            // Tùy chọn: Hiển thị trực quan cầu thủ nào đang được chọn
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel)
                {
                    control.BackColor = SystemColors.Control; // Đặt lại màu nền cho tất cả các panel
                }
            }
            clickedPanel.BackColor = Color.LightBlue; // Đánh dấu panel được chọn

            // Bạn cũng có thể lấy tên cầu thủ nếu cần
            Label nameLabel = clickedPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Tên: "));
            if (nameLabel != null)
            {
                selectedPlayerName = nameLabel.Text.Substring(nameLabel.Text.IndexOf(':') + 2);
            }
            else
            {
                selectedPlayerName = null;
            }
        }

        private bool isEditModeAll = false;
        private bool IsDeleteMode = false;
        private void BtnSuacauthu_Click(object sender, EventArgs e)
        {
            isEditModeAll = true;
            IsDeleteMode = false;
            
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is UCcauthu_doibong playerCard)
                {
                    playerCard.SetEditMode(isEditModeAll); // Cập nhật hiển thị nút sửa
                    playerCard.SetDeleteMode(IsDeleteMode);
                }
            }

            // Thay đổi text của nút sửa lớn (tùy chọn)
            
        }

        private void BtnHienthi_Click(object sender, EventArgs e)
        {
            LoadPlayerData();
        }

        private void Quanlycauthu_Resize(object sender, EventArgs e)
        {
            LoadPlayerData(); // Gọi lại LoadPlayerData để cập nhật kích thước panel
        }

        private void BtnTimkiem_Click(object sender, EventArgs e)
        {
            string ten = TxtCauthu.Text.Trim();
            string doiBong = TxtDoibong.Text.Trim();
            string soAo = TxtSoao.Text.Trim();

            string query = @"
            SELECT 
            p.playerID, 
            p.namePlayer, 
            t.nameTeam, 
            p.shirtNumber,
            p.avatarUrl
            FROM Player p
            INNER JOIN Team_Player tp ON p.playerID = tp.playerID
            INNER JOIN Team t ON tp.teamID = t.teamID
            WHERE 1=1";

            if (!string.IsNullOrEmpty(ten))
                query += " AND p.namePlayer LIKE N'%" + ten + "%'";
            if (!string.IsNullOrEmpty(doiBong))
                query += " AND t.nameTeam LIKE N'%" + doiBong + "%'";
            if (int.TryParse(soAo, out int shirtNum))
                query += $" AND p.shirtNumber = {shirtNum}";


            Console.WriteLine("Truy vấn SQL: " + query);
            DataTable dt = GetData(query);
            flowLayoutPanel1.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {
                UCcauthu_doibong playerCard = new UCcauthu_doibong();
                playerCard.PlayerId = row["playerID"].ToString();
                playerCard.PlayerName = row["namePlayer"].ToString();
                playerCard.ShirtNumber = row["shirtNumber"].ToString();
                playerCard.TeamName = row["nameTeam"].ToString();

                playerCard.SuaClick += PlayerCard_SuaClick;
                playerCard.XoaClick += PlayerCard_XoaClick;
                if (row["avatarUrl"] != DBNull.Value)
                {
                    try
                    {
                        playerCard.Avatar = Image.FromFile(row["avatarUrl"].ToString());  // Thay đổi ở đây
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi nếu không tải được ảnh (ví dụ: gán ảnh mặc định)
                        
                        Console.WriteLine("Lỗi tải ảnh: " + ex.Message);
                    }
                }
                

                flowLayoutPanel1.Controls.Add(playerCard);
                playerCard.Click += PlayerCard_Click;
                foreach (Control control in playerCard.Controls)
                {
                    control.Click += PlayerCard_Click;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            Themcauthu themCauthuForm = new Themcauthu();

            // Hiển thị form Themcauthu
            themCauthuForm.ShowDialog();

            // Sau khi form Themcauthu được đóng (nếu bạn muốn tải lại dữ liệu)
            LoadPlayerData();
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }
    }
}
