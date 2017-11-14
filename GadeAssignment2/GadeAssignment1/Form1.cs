using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 16093491
// Joshua du Toit
//GADE6112_Assignment_2

namespace GadeAssignment1
{
    public partial class Form1 : Form
    {
        GameEngine engine = new GameEngine();

        public Form1()
        {
            InitializeComponent();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();

            engine.start();

            // show grid
            lblDisplay.Text = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    lblDisplay.Text += engine.map.Grid[i, j] + " ";
                }
                lblDisplay.Text += "\n";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            timer1.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            timer1.Enabled = false;
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            int mouseX = MousePosition.X;
            int mouseY = MousePosition.Y;

            int formX = this.Location.X;
            int formY = this.Location.Y;

            int y = (mouseX - formX - 39 - 6) / 15;
            int x = (mouseY - formY - 70 - 1) / 15;

            textBox1.Text = "";
            foreach (Unit u in engine.map.UnitsOnMap)
            {
                if (u.X == x && u.Y == y)
                {
                    textBox1.Text += u.toString();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        { 
          //  MeleeUnit.save();
          // RangedUnit.save();
          // ResourceBuilding.save();
          // FactoryBuilding.save();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //  MeleeUnit.read();
            // RangedUnit.read();
            // ResourceBuilding.read();
            // FactoryBuilding.read();
        }
    }
}
