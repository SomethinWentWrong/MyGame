﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FormNormalGame : Form
    {
        public FormNormalGame()
        {
            InitializeComponent();
        }
        GameHandler gameHandler { get; set; }
        private List<PictureBox> PictureBoxesNormal { get; set; }
        private void FormNormalGame_Load(object sender, EventArgs e)
        {
            PictureBoxesNormal = new List<PictureBox>
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
                pictureBox20
            };
            gameHandler = new GameHandler(this, PictureBoxesNormal, Level.Normal);
            gameHandler.SetPairs();
            gameHandler.ShowAllCards();
            TimerNormal.Start();
        }
        private void TimerNormal_Tick(object sender, EventArgs e)
        {
            gameHandler.FillBoxesWithCardBacks();
            TimerNormal.Stop();
        }

        private void pictureBoxes_Click(object sender, EventArgs e)
        {
            gameHandler.HandlePictureboxClick((PictureBox)sender);
        }
    }
}
