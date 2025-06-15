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
    public partial class UCTournamentItem_trangchu : UserControl
    {

        public int TournamentID { get; set; }
        public UCTournamentItem_trangchu()
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


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private giaodienchinh parentForm;
        private void UCTournamentItem_Click(object sender, EventArgs e)
        {
            FormXemHoSoGiaiDau form = new FormXemHoSoGiaiDau(null, this.TournamentID);
            form.ShowDialog();
        }
    }
}
