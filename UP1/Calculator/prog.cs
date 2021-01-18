using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class prog : Form
    {
        Button[] buttons;
        public prog()
        {
            InitializeComponent();
            buttons = new Button[]
            {
                button1, button2, button3, button5, button6, button7,  button9, button10, button11, button13, button15
            };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += BtnClick;
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
                textBox3.Text += (sender as Button).Text;

            if((sender as Button).Text == "Clear")
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(int.Parse(textBox3.Text), 2);
                textBox2.Text = Convert.ToString(int.Parse(textBox3.Text), 8);
                textBox4.Text = Convert.ToString(int.Parse(textBox3.Text), 16);
            }
            catch { }
        }
    }
}
