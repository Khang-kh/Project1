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
    public partial class UCTournamentItem : UserControl
    {
        public event Action<int> OnEditClick;
        public event Action<int> OnDeleteClick;
        public event Action<int> OnViewDetail;
        public int TournamentID { get; set; }
        private FormQuanLyGiaiDau parentForm;
        public UCTournamentItem()
        {
            InitializeComponent();
            this.Click += UCTournamentItem_Click;
           
        }

        private void UCTournamentItem_Load(object sender, EventArgs e)
        {
            this.Click += UCTournamentItem_Click;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += UCTournamentItem_Click;
            }
        }
        public void SetData(int tournamentID, int stt, string tenGiaiDau, DateTime ngayBatDau, DateTime ngayKetThuc, Image logo)
        {
            TournamentID = tournamentID;
            lblSTT.Text = stt.ToString();
            lblTenGiaiDau.Text = tenGiaiDau;
            lblThoiGian.Text = $"Từ {ngayBatDau:dd/MM/yyyy} đến {ngayKetThuc:dd/MM/yyyy}";
            picLogo.Image = logo;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa giải đấu này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                OnDeleteClick?.Invoke(this.TournamentID); // Gửi ID giải đấu về form cha
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void SetEditMode(bool enable)
        {
            btnSua.Visible = enable;
            btnXoa.Visible = enable;
        }
        public void SetEditVisible(bool visible)
        {
            btnSua.Visible = visible;
        }

        public void SetDeleteVisible(bool visible)
        {
            btnXoa.Visible = visible;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormSuaHoSoGiaiDau suaForm = new FormSuaHoSoGiaiDau(parentForm, TournamentID);

            OnEditClick?.Invoke(this.TournamentID);
        }
        public void SetParentForm(FormQuanLyGiaiDau form)
        {
            parentForm = form;
        }
        private void UCTournamentItem_Click(object sender, EventArgs e)
        {
            OnViewDetail?.Invoke(this.TournamentID);
        }
    }
}
