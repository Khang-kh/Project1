using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using quanly;
using System.Net.NetworkInformation;

namespace quanly
{
    public partial class FormQuanLyGiaiDau : Form
    {
        private Form previousForm;
        string connectionString = Program.connectString;
        private bool isEditMode = false; // Biến theo dõi trạng thái ẩn/hiện nút sửa/xóa
        private enum EditModeType { None, Edit, Delete }
        private EditModeType currentMode = EditModeType.None;
        public FormQuanLyGiaiDau(Form callerForm)
        {
            InitializeComponent();
            previousForm = callerForm;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;

            flowLayoutPanel1.Controls.Clear();

            // Xây dựng truy vấn SQL động
            StringBuilder queryBuilder = new StringBuilder("SELECT t.tournamentID, t.tournamentName, t.startDate, t.endDate, t.avatarURL FROM Tournament t LEFT  JOIN TournamentTeams tt ON t.tournamentID = tt.tournamentID WHERE 1=1");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                if (!string.IsNullOrEmpty(keyword))
                {
                    queryBuilder.Append(" AND t.tournamentName LIKE @keyword");
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                }

                if (dtpStart.Checked)
                {
                    queryBuilder.Append(" AND t.startDate >= @start");
                    cmd.Parameters.AddWithValue("@start", start);
                }

                if (dtpEnd.Checked)
                {
                    queryBuilder.Append(" AND t.endDate <= @end");
                    cmd.Parameters.AddWithValue("@end", end);
                }

                cmd.CommandText = queryBuilder.ToString();

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int stt = 1;

                while (reader.Read())
                {
                    int tournamentID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    DateTime startDate = reader.GetDateTime(2);
                    DateTime endDate = reader.GetDateTime(3);
                    string logoPath = reader["avatarURL"].ToString();

                    // Kiểm tra đường dẫn ảnh hợp lệ trước khi load
                    Image logo = null;
                    if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                    {
                        try
                        {
                            logo = Image.FromFile(logoPath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi load ảnh: " + ex.Message);
                        }
                    }

                    var item = new UCTournamentItem();
                    item.SetData(tournamentID, stt++, name, startDate, endDate, logo);
                    item.OnEditClick += (id) =>
                    {
                        using (FormSuaHoSoGiaiDau formSua = new FormSuaHoSoGiaiDau(this, id))
                        {
                            if (formSua.ShowDialog() == DialogResult.OK)
                            {
                                LoadTournamentList(); // ← reload lại flowLayoutPanel1
                            }
                        }
                    };

                    item.OnViewDetail += (id) =>
                    {
                        FormXemHoSoGiaiDau formXem = new FormXemHoSoGiaiDau(this, id);
                        formXem.ShowDialog();
                    };
                    item.SetEditMode(false);
                    flowLayoutPanel1.Controls.Add(item);
                }
                reader.Close();
            }

            isEditMode = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThemGiaiDau_Click(object sender, EventArgs e)
        {
            FormTaoHoSoGiaiDau formTaoHoSo = new FormTaoHoSoGiaiDau(this); // truyền form hiện tại
            var dialogResult = formTaoHoSo.ShowDialog();

            // Nếu người dùng nhấn Lưu thành công thì reload danh sách
            if (dialogResult == DialogResult.OK)
            {
                LoadTournamentList();
            }
        }

        private void btnSuaGiaiDau_Click(object sender, EventArgs e)
        {
            if (currentMode == EditModeType.Edit)
                currentMode = EditModeType.None;
            else
                currentMode = EditModeType.Edit;

            UpdateItemButtons();
        }

        private void btnXoaGiaiDau_Click(object sender, EventArgs e)
        {
            if (currentMode == EditModeType.Delete)
                currentMode = EditModeType.None;
            else
                currentMode = EditModeType.Delete;

            UpdateItemButtons();
        }
        private void UpdateItemButtons()
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UCTournamentItem item)
                {
                    item.SetEditVisible(currentMode == EditModeType.Edit);
                    item.SetDeleteVisible(currentMode == EditModeType.Delete);
                }
            }
        }
       
        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            LoadTournamentList();
        }

        private void FormQuanLyGiaiDau_Load(object sender, EventArgs e)
        {
            LoadTournamentList();
        }
        public void LoadTournamentList()
        {
            flowLayoutPanel1.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                                    SELECT DISTINCT t.tournamentID, t.tournamentName, t.startDate, t.endDate, t.avatarUrl 
                                    FROM Tournament t
                                    LEFT  JOIN TournamentTeams tt ON t.tournamentID = tt.tournamentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int stt = 1;
                while (reader.Read())
                {
                    int tournamentID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    DateTime start = reader.GetDateTime(2);
                    DateTime end = reader.GetDateTime(3);

                    string logoPath = reader["avatarUrl"].ToString();
                    Image logo = null;
                    if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                    {
                        logo = Image.FromFile(logoPath);
                    }

                    var item = new UCTournamentItem();
                    item.SetParentForm(this); // ← Gán parentForm tại đây

                    item.SetData(tournamentID, stt++, name, start, end, logo);

                    // Ẩn nút sửa/xóa khi hiển thị tất cả
                    item.SetEditMode(false);
                    item.OnViewDetail += (viewid) =>
                    {
                        FormXemHoSoGiaiDau formXem = new FormXemHoSoGiaiDau(this, viewid);
                        formXem.ShowDialog();
                    };
                    // Đăng ký sự kiện sửa
                    item.OnEditClick += (id) =>
                    {
                        using (FormSuaHoSoGiaiDau formSua = new FormSuaHoSoGiaiDau(this, id))
                        {
                            if (formSua.ShowDialog() == DialogResult.OK)
                            {
                                LoadTournamentList(); // Cập nhật lại danh sách
                            }
                        }
                    };
                    item.OnDeleteClick += (id) => // THÊM DÒNG NÀY
                    {
                        XoaGiaiDau(id);
                    };

                    flowLayoutPanel1.Controls.Add(item);
                }
            }

            // Reset trạng thái chỉnh sửa/xóa
            currentMode = EditModeType.None;
        }
        private void XoaGiaiDau(int tournamentID)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa giải đấu này? Tất cả dữ liệu liên quan sẽ bị xóa.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        string[] deleteQueries = new string[]
                        {
                    "DELETE FROM match_line_up_sub WHERE MatchID IN (SELECT MatchID FROM MatchSchedule WHERE TournamentID = @id)",
                    "DELETE FROM match_line_up WHERE MatchID IN (SELECT MatchID FROM MatchSchedule WHERE TournamentID = @id)",
                    "DELETE FROM MatchSchedule WHERE TournamentID = @id",
                    "DELETE FROM TranDau WHERE tournamentID = @id",
                    "DELETE FROM Rank WHERE tournamentID = @id",
                    "DELETE FROM TeamAchievement WHERE tournamentID = @id",
                    "DELETE FROM TournamentTeams WHERE tournamentID = @id",
                    "UPDATE Tournament SET championTeamID = NULL WHERE tournamentID = @id", // Nếu có liên kết FK
                    "DELETE FROM Tournament WHERE tournamentID = @id"
                        };

                        foreach (string query in deleteQueries)
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", tournamentID);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã xóa giải đấu và các dữ liệu liên quan thành công.");
                        LoadTournamentList();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                    }
                }
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }
    }
}
