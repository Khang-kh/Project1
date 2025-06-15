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
    public partial class UC_RankItem : UserControl
    {
        public UC_RankItem()
        {
            InitializeComponent();
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
        public void SetData(int position, Image logo, string teamName, int wins, int draws, int losses)
        {
            lblPosition.Text = position.ToString();             // "Hạng"
            picLogo.Image = logo;                               // PictureBox
            lblTeamName.Text = teamName;                        // "Đội bóng"
            lblWins.Text = wins.ToString();                     // "Thắng"
            lblDraws.Text = draws.ToString();                   // "Hòa"
            lblLosses.Text = losses.ToString();                 // "Thua"

            int points = wins * 3 + draws;
            lblPoints.Text = points.ToString();                 // "Tổng điểm"
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
