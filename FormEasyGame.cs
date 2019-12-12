using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FormEasyGame : Form
    {
        public FormEasyGame()
        {
            InitializeComponent();
        }
        GameHandler gameHandler { get; set; } 
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
            gameHandler = new GameHandler(PictureBoxesEasy, Level.Easy);
            gameHandler.SetPairs();
            gameHandler.ShowAllCards();
            TimerEasy.Start();
        }
        private void TimerEasy_Tick(object sender, EventArgs e)
        {
            gameHandler.FillBoxesWithCardBacks();
            TimerEasy.Stop();
        }
        private void pictureBoxes_Click(object sender, EventArgs e)
        {
            bool hasWon = false;
            Task task = new Task(() => 
            { 
                hasWon = gameHandler.HandlePictureBoxClick((PictureBox)sender);
                if (hasWon)
                {
                    EndGame();
                }
            });
            task.Start();
        }
        private void EndGame()
        {
            MessageBox.Show("You have won!");
            this.Close();
        }
    }
}
