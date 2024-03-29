﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public class GameHandler
    {
        public GameHandler(Form gameForm, List<PictureBox> pictureBoxes, Level level)
        {
            this.GameForm = gameForm;
            this.PictureBoxes = pictureBoxes;
            countOpenedPictureboxes = PictureBoxes.Count;
            switch (level)
            {
                case Level.Easy:
                    {
                        Pictures = CardFactory.CardFactory.GetCards(5);
                        break;
                    }
                case Level.Normal:
                    {
                        Pictures = CardFactory.CardFactory.GetCards(10);
                        break;
                    }
                case Level.Hard:
                    {
                        Pictures = CardFactory.CardFactory.GetCards(20);
                        break;
                    }
                default: throw new Exception("Error!");
            }
            CurrentGameState = GameState.AllCardsClosed;
        }

        public Form GameForm { get; }

        Random r = new Random();

        int pictureIndexToCompare;
        int indexRemovedPicturebox;
        int countOpenedPictureboxes;

        public List<Bitmap> Pictures { get; set; }

        public Dictionary<int, int> CardMap { get; set; }

        public List<PictureBox> PictureBoxes { get; set; }

        private GameState CurrentGameState { get; set; }

        public void FillBoxesWithCardBacks()
        {
            this.CurrentGameState = GameState.HandlerBlocked;
            foreach (PictureBox x in PictureBoxes)
            {
                x.BackgroundImage = CardFactory.CardFactory.GetCardBack();
            }
            this.CurrentGameState = GameState.AllCardsClosed;
        }

        public void SetPairs()
        {
            this.CardMap = new Dictionary<int, int>();
            List<int> pictureBoxIds = new List<int>();
            for (int i = 0; i < this.PictureBoxes.Count; i++)
            {
                pictureBoxIds.Add(i);
            }
            for (int i = 0; i < this.Pictures.Count; i++)
            {
                int idx1 = r.Next(0, pictureBoxIds.Count);
                CardMap.Add(pictureBoxIds[idx1], i);
                pictureBoxIds.Remove(pictureBoxIds[idx1]);
                int idx2 = r.Next(0, pictureBoxIds.Count);
                CardMap.Add(pictureBoxIds[idx2], i);
                pictureBoxIds.Remove(pictureBoxIds[idx2]);
            }
        }
        public void ShowAllCards()
        {
            for (int i = 0; i < PictureBoxes.Count; i++)
            {
                PictureBoxes[i].BackgroundImage = Pictures[CardMap[i]];
            }
        }

        public void HandlePictureboxClick(PictureBox clickedPictureBox)
        {
            bool hasWon = false;
            if (!this.GameForm.InvokeRequired)
            {
                hasWon = this.ApplyActionByClick(clickedPictureBox);
                if (hasWon)
                {
                    EndGame();
                }
            }
            else
            {
                this.GameForm.Invoke(new Action<PictureBox>(HandlePictureboxClick), clickedPictureBox);
            }
        }

        private bool ApplyActionByClick(PictureBox clickedPicturebox)
        {
            switch (CurrentGameState)
            {
                case GameState.AllCardsClosed:
                    {
                        return OpenCard(clickedPicturebox);
                    }
                case GameState.OneCardOpen:
                    {
                        return OpenTwoAndCompare(clickedPicturebox);
                    }
                case GameState.HandlerBlocked:
                    {
                        return false;
                    }
                default: throw new Exception("Wrong game state!");
            }
        }

        private bool OpenCard(PictureBox clickedPicturebox)
        {
            CurrentGameState = GameState.HandlerBlocked;
            int clickedPictureBoxIndex = -1;
            for (int i = 0; i < PictureBoxes.Count; i++)
            {
                if (PictureBoxes[i] == clickedPicturebox)
                {
                    clickedPictureBoxIndex = i;
                    break;
                }
            }

            if (clickedPictureBoxIndex == -1)
            {
                return false;
            }
            PictureBoxes[clickedPictureBoxIndex].BackgroundImage = Pictures[CardMap[clickedPictureBoxIndex]];
            clickedPicturebox.Enabled = false;
            pictureIndexToCompare = CardMap[clickedPictureBoxIndex];
            indexRemovedPicturebox = clickedPictureBoxIndex;
            CurrentGameState = GameState.OneCardOpen;
            return false;
        }

        private bool OpenTwoAndCompare(PictureBox clickedPicturebox)
        {
            CurrentGameState = GameState.HandlerBlocked;
            int clickedPictureBoxIndex = -1;
            EnableAllPictureBoxes();
            for (int i = 0; i < PictureBoxes.Count; i++)
            {
                if (PictureBoxes[i] == clickedPicturebox)
                {
                    clickedPictureBoxIndex = i;
                    break;
                }
            }

            if (clickedPictureBoxIndex == -1)
            {
                return false;
            }

            PictureBoxes[clickedPictureBoxIndex].BackgroundImage = Pictures[CardMap[clickedPictureBoxIndex]];
            Task.Delay(1000).Wait();
            if (pictureIndexToCompare == CardMap[clickedPictureBoxIndex])
            {
                PictureBoxes[clickedPictureBoxIndex].Visible = false;
                PictureBoxes[indexRemovedPicturebox].Visible = false;
                countOpenedPictureboxes = countOpenedPictureboxes - 2;
                if (countOpenedPictureboxes == 0)
                {
                    return true;
                }
            }
            else
            {
                PictureBoxes[clickedPictureBoxIndex].BackgroundImage = CardFactory.CardFactory.GetCardBack();
                PictureBoxes[indexRemovedPicturebox].BackgroundImage = CardFactory.CardFactory.GetCardBack();
            }
            CurrentGameState = GameState.AllCardsClosed;
            return false;
        }

        private void EnableAllPictureBoxes()
        {
            foreach (PictureBox picturebox in PictureBoxes)
            {
                picturebox.Enabled = true;
            }
        }

        private void EndGame()
        {
            MessageBox.Show("You have won!");
            this.GameForm.Close();
        }
    }
}
