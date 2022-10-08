using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheColor
{
    public partial class Form1 : Form
    {

        List<string> main_colors = new List<string>() { "Brown", "Black", "Pink", "Blue",
            "BlueViolet", "Green", "Yellow", "Orange",
            "Red", "White", "Gray", "Gold" };

        List<string> random_colors = new List<string>();

        public Form1()
        {
            InitializeComponent();
            displayQuestion();
        }

        public void displayQuestion()
        {
            if (main_colors.Count < 4) return;

            List<string> temp_colors = new List<string>(main_colors);

            for (int i = 0; i < 4; i++)
            {
                int rndx = new Random().Next(temp_colors.Count);
                random_colors.Add(temp_colors[rndx]);
                temp_colors.RemoveAt(rndx);
            }

            int rnd = new Random().Next(4);
            ColorBox.BackColor = Color.FromName(random_colors[rnd]);

            button1.Text = random_colors[0];
            button2.Text = random_colors[1];
            button3.Text = random_colors[2];
            button4.Text = random_colors[3];

            random_colors.Clear();
        }

        public void gameOver(string msg)
        {
            main_colors = resetList();
            MessageBox.Show(msg);
        }

        public List<string> resetList()
        {
            List<string> main_colors = new List<string>() { "Brown", "Black", "Pink", "Blue",
            "BlueViolet", "Green", "Yellow", "Orange",
            "Red", "White", "Gray", "Gold" };

            return main_colors;
        }

        public void handleAnswer(string s)
        {

            if (ColorBox.BackColor.ToString() == $"Color [{s}]")
            {
                main_colors.Remove(s);
                displayQuestion();

                if (main_colors.Count < 4)
                {
                    gameOver("congrats");
                    displayQuestion();
                }
            }
            else
            {
                gameOver("I dərəcəli rəng koru");
                displayQuestion();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            handleAnswer(s);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            handleAnswer(s);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            handleAnswer(s);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            handleAnswer(s);
        }
    }
}
