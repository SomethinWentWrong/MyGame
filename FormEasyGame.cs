using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FormEasyGame : Form
    {
        public FormEasyGame()
        {
            InitializeComponent();
        }
        GameHandler GameHandler { get; set; }
        public List<PictureBox> PictureBoxesEasy { get; set; }

        private void FormEasyGame_Load(object sender, EventArgs e)
        {
            PictureBoxesEasy = new List<PictureBox>
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9,
                pictureBox10
            };
            GameHandler = new GameHandler(this, PictureBoxesEasy, Level.Easy);
            GameHandler.SetPairs();
            GameHandler.ShowAllCards();
            TimerEasy.Start();
        }

        private void TimerEasy_Tick(object sender, EventArgs e)
        {
            GameHandler.FillBoxesWithCardBacks();
            TimerEasy.Stop();
        }

        private void pictureBoxes_Click(object sender, EventArgs e)
        {
            GameHandler.HandlePictureboxClick((PictureBox)sender);
        }
    }
}
