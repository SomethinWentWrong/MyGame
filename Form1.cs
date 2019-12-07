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
        }
        readonly Dictionary<int, object> pictures = new Dictionary<int, object>(5)
        {
            [1] = Properties.Resources.Syr_Konrad,
            [2] = Properties.Resources.Syr_Carah,
            [3] = Properties.Resources.Syr_Alin,
            [4] = Properties.Resources.Syr_Elenora,
            [5] = Properties.Resources.Syr_Faren
        };
        static readonly Random r = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = RandomizePic(pictures);
            pictureBox2.BackgroundImage = RandomizePic(pictures);
            pictureBox3.BackgroundImage = RandomizePic(pictures);
            pictureBox4.BackgroundImage = RandomizePic(pictures);
            pictureBox5.BackgroundImage = RandomizePic(pictures);
            pictureBox6.BackgroundImage = RandomizePic(pictures);
            pictureBox7.BackgroundImage = RandomizePic(pictures);
            pictureBox8.BackgroundImage = RandomizePic(pictures);
            pictureBox9.BackgroundImage = RandomizePic(pictures);
            pictureBox10.BackgroundImage = RandomizePic(pictures);
        }
        public static Image RandomizePic(Dictionary<int, object> x)
        {
            return (Image)x[r.Next(1, 6)];
        }
    }
}
