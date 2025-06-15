using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly
{
    public partial class UC_RankItem_doibong : UserControl
    {
        public UC_RankItem_doibong()
        {
            InitializeComponent();
            this.Click += UC_RankItem_doibong_Click;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_RankItem_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private int Id;
        public int ID { get; set; }
        public void SetData(int position, Image logo, string tournamentName, int wins, int draws, int losses,int id)
        {
            lblPosition.Text = position.ToString();             // "Hạng"
            picLogo.Image = logo;                               // PictureBox
            lbTournamnetName.Text = tournamentName;                        // "Giải đấu"
            lblWins.Text = wins.ToString();                     // "Thắng"
            lblDraws.Text = draws.ToString();                   // "Hòa"
            lblLosses.Text = losses.ToString();                 // "Thua"
            ID = id;

            int points = wins * 3 + draws;
            lblPoints.Text = points.ToString();                 // "Tổng điểm"
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void UC_RankItem_doibong_Click(object sender, EventArgs e)
        {
            FormBangXepHang form = new FormBangXepHang(ID);
            form.ShowDialog();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
