using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        List<Plants> plantsList = new List<Plants>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.plantsList.Clear();

            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        this.plantsList.Add(Flower.Generate());
                        break;
                    case 1:
                        this.plantsList.Add(Shrub.Generate());
                        break;
                    case 2:
                        this.plantsList.Add(Tree.Generate());
                        break;
                }
            }
            ShowInfo();
            Queue();
        }
        private void Queue()
        {

            String str = "Очередь:\n";
            for (int i = 0; i < this.plantsList.Count; i++)
            {
                var plant = this.plantsList[i];
                if (plant is Flower) str += $"{i + 1} " + "Цветок\n";
                if (plant is Shrub) str += $"{i + 1} " + "Кустарник\n";
                if (plant is Tree) str += $"{i + 1} " + "Дерево\n";
            }
            richTextBox3.Text = str;

        }
        private void ShowInfo()
        {
            int floawerCount = 0;
            int shrubCount = 0;
            int treesCount = 0;

            foreach (var a in this.plantsList)
            {
                if (a is Flower)
                {
                    floawerCount++;
                }
                if (a is Shrub)
                {
                    shrubCount++;
                }
                if (a is Tree)
                {
                    treesCount++;
                }
            }
            richTextBox2.Text = "Цветы\tКустарники\tДеревья";
            richTextBox2.Text += "\n";
            richTextBox2.Text += String.Format("{0}\t{1}\t\t{2}", floawerCount, shrubCount, treesCount);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.plantsList.Count == 0)
            {
                richTextBox4.Text = "";
                return;
            }
            var plant = this.plantsList[0];
            this.plantsList.RemoveAt(0);
            richTextBox4.Text = plant.GetInfo();
            ShowInfo();
            Queue();

        }
    }
}
