using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanly
{
    public partial class UCcauthutrangchu : UserControl
    {

        public Image Avatar
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        public string PlayerId { get; set; }
        private void LblSo_Click(object sender, EventArgs e)
        {

        }

        public string PlayerName
        {
            get => LblTen.Text;
            set => LblTen.Text = value;
        }

        public string ShirtNumber
        {
            get => LblSo.Text;
            set => LblSo.Text = "Số áo: " + value;
        }

        public string TeamName
        {
            get => LblDoi.Text;
            set => LblDoi.Text = "Đội: " + value;
        }
        
        private void LblTen_Click(object sender, EventArgs e)
        {

        }

        public UCcauthutrangchu()
        {
            InitializeComponent();
            this.Click += UCcauthu_Click;
        }
        private void UCcauthu_Click(object sender, EventArgs e)
        {
            Thongtinchitietcauthu detailform = new Thongtinchitietcauthu(this.PlayerId);
            detailform.ShowDialog();
        }

 
        private void UCcauthu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
