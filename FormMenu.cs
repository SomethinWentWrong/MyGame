using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            comboBoxLevels.Items.AddRange(GetLevels());
        }
        private string[] GetLevels()
        {
            return Enum.GetNames(typeof(Level));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (comboBoxLevels.SelectedIndex < 0)
            {
                MessageBox.Show("Choose difficulty level!");
                return;
            }
            Level selectedLevel = (Level)Enum.Parse(typeof(Level), comboBoxLevels.SelectedItem.ToString());
            FormGame formGame = new FormGame(selectedLevel);
            formGame.Show();
            this.Close();
        }
    }
}
