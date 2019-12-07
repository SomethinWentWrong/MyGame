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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.PictureBoxes = new List<PictureBox>
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
            this.FillBoxesWithCardBacks();
            Thread.Sleep(3000);
            this.SetPairs();
            this.ShowAllCards();
        }
        readonly List<Bitmap> Pictures = new List<Bitmap>(5)
        {
            Properties.Resources.Syr_Konrad,
            Properties.Resources.Syr_Carah,
            Properties.Resources.Syr_Alin,
            Properties.Resources.Syr_Elenora,
            Properties.Resources.Syr_Faren
        };
        private List<PictureBox> PictureBoxes { get; set; }
        private Dictionary<int, int> CardMap { get; set; }
        static readonly Random r = new Random();
        public static Image RandomizePic(List<object> x)
        {
            return (Image)x[r.Next(1, 6)];
        }
        void FillBoxesWithCardBacks()
        {
            foreach (PictureBox x in this.PictureBoxes)
            {
                x.BackgroundImage = Properties.Resources.CardBack;
            }
        }
        private void SetPairs()
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
        private void ShowAllCards()
        {
            for (int i = 0; i < PictureBoxes.Count; i++)
            {
                PictureBoxes[i].BackgroundImage = Pictures[CardMap[i]];
            }
        }
    }
}
