using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetAnotherDice
{
    public partial class diceForm : Form
    {
        SetofDice s = new SetofDice();

        public diceForm()
        {
            InitializeComponent();
        }

        private void diceForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) s.keep(0);
            if (checkBox2.Checked) s.keep(1);
            if (checkBox3.Checked) s.keep(2);
            if (checkBox4.Checked) s.keep(3);
            if (checkBox5.Checked) s.keep(4);
            
            s.roll();

            textBox1.Text = s.getValue(0).ToString();
            pictureBox1.Image = imageList1.Images[s.getValue(0) -  1];
            textBox2.Text = s.getValue(1).ToString();
            pictureBox2.Image = imageList1.Images[s.getValue(1) - 1];
            textBox3.Text = s.getValue(2).ToString();
            pictureBox3.Image = imageList1.Images[s.getValue(2) - 1];
            textBox4.Text = s.getValue(3).ToString();
            pictureBox4.Image = imageList1.Images[s.getValue(3) - 1];
            textBox5.Text = s.getValue(4).ToString();
            pictureBox5.Image = imageList1.Images[s.getValue(4) - 1];

            if (s.max == false)
            {
                if (s.ThreeofaKind())
                {
                    //this.BackColor = Color.Green;
                    //MessageBox.Show("!!snoitalutargnoC !dnik a fo eerht tog ouY");
                    MessageBox.Show("You got a three of a kind! Congratulations!!");
                    textBox6.Text = s.score().ToString();
                }
                if (s.FullHouse())
                {
                    //this.BackColor = Color.Green;
                    //MessageBox.Show("!!snoitalutargnoC !dnik a fo eerht tog ouY");
                    MessageBox.Show("You got a full house! Congratulations!!");
                    textBox6.Text = s.score().ToString();
                }
                if (s.FourofaKind())
                {
                    //this.BackColor = Color.Green;
                    //MessageBox.Show("!!snoitalutargnoC !dnik a fo eerht tog ouY");
                    MessageBox.Show("You got a four of a kind! Congratulations!!");
                    textBox6.Text = s.score().ToString();
                }
                if (s.Yahtzee())
                {
                    //this.BackColor = Color.Green;
                    //MessageBox.Show("!!snoitalutargnoC !dnik a fo eerht tog ouY");
                    MessageBox.Show("You got Yatzhee! Congratulations!!");
                    textBox6.Text = s.score().ToString();
                }
                if (s.SmallStraight())
                {
                    //this.BackColor = Color.Green;
                    //MessageBox.Show("!!snoitalutargnoC !dnik a fo eerht tog ouY");
                    MessageBox.Show("You got small straight! Congratulations!!");
                    textBox6.Text = s.score().ToString();
                }
                if (s.LargeStraight())
                {
                    //this.BackColor = Color.Green;
                    //MessageBox.Show("!!snoitalutargnoC !dnik a fo eerht tog ouY");
                    MessageBox.Show("You got large straight! Congratulations!!");
                    textBox6.Text = s.score().ToString();
                }
            }
            else
            {
                MessageBox.Show("You have reached the max roll count, please click reset to play again!");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            s.reset();
            textBox6.Text = s.score().ToString();

            pictureBox1.Image = pictureBox6.Image;
            pictureBox2.Image = pictureBox6.Image;
            pictureBox3.Image = pictureBox6.Image;
            pictureBox4.Image = pictureBox6.Image;
            pictureBox5.Image = pictureBox6.Image;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }
    }
}
