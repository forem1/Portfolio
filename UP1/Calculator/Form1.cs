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
    public partial class Form1 : Form
    {
        float a, b;
        int count;
        bool znak = true;

        Button[] buttons;
        public Form1()
        {
            InitializeComponent();

            buttons = new Button[]
            {
                button0, button1, button2, button3, button4, button5, button6, button7, button8, button9, buttonComma
            };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += AddNum;
            }
        }

        private void AddNum(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + (sender as Button).Text;
        } //Добавление цифры

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        } //Проверка на буквы

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 1;
            label1.Text = a.ToString() + "+";
            znak = true;
        } //Сумма

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 4:
                    b = a / float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 5:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 6:
                    b = a/100* float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 7:
                    double c;
                    c = Math.Sqrt(a);
                    textBox1.Text = c.ToString();
                    break;

                default:
                    break;
            }

            label1.Text = "";
        } //Равно

        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Console.WriteLine(textBox1.Text);
                    if (double.Parse(textBox1.Text) != 0 && double.Parse(textBox1.Text) > 0)
                    {
                        textBox1.Clear();
                        textBox1.Text = Math.Log(double.Parse(textBox1.Text)).ToString();
                    }
                }
                catch { MessageBox.Show("неправильно введено число"); }
            }
        } //Логарифм

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 4;
            label1.Text = a.ToString() + "/";
            znak = true;
        } //деление

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 3;
            label1.Text = a.ToString() + "*";
            znak = true;
        } //Умножение

        private void buttonSub_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label1.Text = a.ToString() + "-";
            znak = true;
        } //вычитание

        private void buttonAddMin_Click(object sender, EventArgs e)
        {
            if (znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        } //Добавление минуса

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 5;
            label1.Text = a.ToString() + "^";
            znak = true;
        } //квадрат

        private void buttonPer_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 6;
            label1.Text = a.ToString() + "%";
            znak = true;
        } //Процент

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 7;
            label1.Text = "sqrt(" + a.ToString() + ")";
            znak = true;
        } //Квадратный корень

        private void buttonFactor_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (int.Parse(textBox1.Text) != 0 && int.Parse(textBox1.Text) > 0)
                {
                    int res = 1;
                    for (int i = int.Parse(textBox1.Text); i > 1; i--)
                        res *= i;
                    textBox1.Clear();
                    textBox1.Text = res.ToString();
                }
            }
        } //Факториал

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((sender as ComboBox).SelectedIndex)
            {
                case 1:
                    prog prog = new prog();
                    prog.Show();
                    break;
                case 2:
                    Dates dates = new Dates();
                    dates.Show();
                    break;
            }
        } //Меняем тип калькулятора

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            catch { }
        } //Стирание последнего символа
    }
}
