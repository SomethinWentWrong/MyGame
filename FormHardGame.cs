using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FormHardGame : Form
    {
        public FormHardGame()
        {
            InitializeComponent();
        }
        GameHandler gameHandler { get; set; }
        private List<PictureBox> PictureBoxesHard { get; set; }

        private void FormHardGame_Load(object sender, EventArgs e)
        {
            PictureBoxesHard = new List<PictureBox>
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
                pictureBox10,
                pictureBox11,
                pictureBox12,
                pictureBox13,
                pictureBox14,
                pictureBox15,
                pictureBox16,
                pictureBox17,
                pictureBox18,
                pictureBox19,
                pictureBox20,
                pictureBox21,
                pictureBox22,
                pictureBox23,
                pictureBox24,
                pictureBox25,
                pictureBox26,
                pictureBox27,
                pictureBox28,
                pictureBox29,
                pictureBox30,
                pictureBox31,
                pictureBox32,
                pictureBox33,
                pictureBox34,
                pictureBox35,
                pictureBox36,
                pictureBox37,
                pictureBox38,
                pictureBox39,
                pictureBox40
            };
            gameHandler = new GameHandler(this, PictureBoxesHard, Level.Hard);
            gameHandler.SetPairs();
            gameHandler.ShowAllCards();
            TimerHard.Start();

        }
        private void TimerHard_Tick(object sender, EventArgs e)
        {
            gameHandler.FillBoxesWithCardBacks();
            TimerHard.Stop();
        }

        private void pictureBoxes_Click(object sender, EventArgs e)
        {
            gameHandler.HandlePictureboxClick((PictureBox)sender);
        }
    }
}
