using quanly.schedule;
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
    public partial class menuquanly : Form
    {
        string connectionString = Program.connectString;
        private Form previousForm;
        public menuquanly(Form callerForm)
        {
            InitializeComponent();
            previousForm = callerForm;
        }

        

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            previousForm.Show(); // Hiện lại form cũ
            ((giaodienchinh)previousForm).LoadListOfSchedule();
            this.Close();
        }

        private void menuquanly_Load(object sender, EventArgs e)
        {
            if (CheckPermissionToAccess(SessionManager.CurrentUsername))
            {
                BtnAdmin.Visible = true; // hiện nút phân quyền
            }
            else
            {
                BtnAdmin.Visible = false; // ẩn nút phân quyền
            }
        }
        private bool CheckPermissionToAccess(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT COUNT(*) 
                FROM Actors A
                JOIN Actors_Role AR ON A.ActorID = AR.ActorID
                JOIN Roles R ON AR.RoleID = R.RoleID
                WHERE A.ActorUsername = @username AND R.RoleName = 'Master'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                int count = (int)cmd.ExecuteScalar(); // Lấy số lượng role "Master" của user

                return count > 0; // Nếu có ít nhất 1 quyền "Master", trả về true
            }
        }



        private void BtnBaibao_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBaibao formqlbaibao = new FormBaibao(this);
            formqlbaibao.ShowDialog();
            
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPQ formqlphanquyen = new FormPQ(this);
            formqlphanquyen.ShowDialog();
            
            
        }
        private void BtnCauthu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQLPlayer formplayer= new FormQLPlayer(this);
            formplayer.ShowDialog();
        }

        private void BtnGiaidau_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuanLyGiaiDau formtournament = new FormQuanLyGiaiDau(this);
            formtournament.ShowDialog();
        }

        private void BtnDoibong_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuanLyDoiBong formtournament = new FormQuanLyDoiBong(this);
            formtournament.ShowDialog();
        }

        private void BtnLichthidau_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuanlylichthidau lich = new FormQuanlylichthidau(this);
            lich.ShowDialog();
        }
    }
}
