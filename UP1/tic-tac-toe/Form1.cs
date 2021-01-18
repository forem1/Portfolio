using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        int XScore = 0;
        int OScore = 0;
        int all = 0;
        bool OrXO = true;
        Button[] buttons;

        public Form1()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D; //Хмм... А зачем нам менять размер окна? 
            InitializeComponent();

            buttons = new Button[]
            {
                button1, button2, button3, button4, button5, button6, button7, button8, button9
            };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += NextStep;
            }
        }

        private void NextStep(object sender, EventArgs e)
        {
            all++;
            
            if (OrXO)
            {
                (sender as Button).Text = "X";
                OrXO = false;
                label1.Text = "Ход O";
            }
            else
            {
                (sender as Button).Text = "O";
                OrXO = true;
                label1.Text = "Ход X";
            }
            (sender as Button).Enabled = false;

            WinCheck();
        }

        private void WinCheck()
        {
            if(((String)button1.Text == "X" && (String)button4.Text == "X" && (String)button7.Text == "X") || ((String)button2.Text == "X" && (String)button5.Text == "X" && (String)button8.Text == "X") || ((String)button3.Text == "X" && (String)button6.Text == "X" && (String)button9.Text == "X") || ((String)button1.Text == "X" && (String)button2.Text == "X" && (String)button3.Text == "X") || ((String)button4.Text == "X" && (String)button5.Text == "X" && (String)button6.Text == "X") || ((String)button7.Text == "X" && (String)button8.Text == "X" && (String)button9.Text == "X") || ((String)button1.Text == "X" && (String)button5.Text == "X" && (String)button9.Text == "X") || ((String)button3.Text == "X" && (String)button5.Text == "X" && (String)button7.Text == "X"))
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
                label1.Text = "Нажмите на кнопку 'Новая игра'";
                MessageBox.Show("Крестики выиграли!");
                all = 0;
                XScore++;
                label5.Text = XScore.ToString();
            }
            else if(((String)button1.Text == "O" && (String)button4.Text == "O" && (String)button7.Text == "O") || ((String)button2.Text == "O" && (String)button5.Text == "O" && (String)button8.Text == "O") || ((String)button3.Text == "O" && (String)button6.Text == "O" && (String)button9.Text == "O") || ((String)button1.Text == "O" && (String)button2.Text == "O" && (String)button3.Text == "O") || ((String)button4.Text == "O" && (String)button5.Text == "O" && (String)button6.Text == "O") || ((String)button7.Text == "O" && (String)button8.Text == "O" && (String)button9.Text == "O") || ((String)button1.Text == "O" && (String)button5.Text == "O" && (String)button9.Text == "O") || ((String)button3.Text == "O" && (String)button5.Text == "O" && (String)button7.Text == "O"))
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
                label1.Text = "Нажмите на кнопку 'Новая игра'";
                MessageBox.Show("Нолики выиграли!");
                all = 0;
                OScore++;
                label6.Text = OScore.ToString();
            }
            else if(all == 9)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
                label1.Text = "Нажмите на кнопку 'Новая игра'";
                MessageBox.Show("Ничья");
                all = 0;
            }
        }

        private void NewGame(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = "";
                buttons[i].Enabled = true;
            }
            OrXO = true;
            label1.Text = "Ход X";
            all = 0;

        }
    }
}
