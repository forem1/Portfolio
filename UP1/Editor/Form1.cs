using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Editor
{
    public partial class Form1 : Form
    {
        bool saved = true;
        bool Bold = true;
        bool Cursive = true;
        bool Line = true;

        public Form1()
        {
            InitializeComponent();
            fontDialog1.ShowColor = true;
            TextPlace.Font = new Font("Calibri", 12);
            TextPlace.ContextMenuStrip = contextMenuStrip1;
            FontStyleBtn.Text = TextPlace.Font.Name + " " + TextPlace.Font.Size;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) //Открываем файл
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            TextPlace.Rtf = fileText;
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saving(false);
        } //Обработка сохранения
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosingApp();
        } //Обрабатываем выход из диалога
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение создано Андреем Дрюпиным :)", "Что вы хотели здесь увидеть?");
        } //Я. Просто Я.
        private void ExitToolStripMenuItem_Click(object sender, FormClosingEventArgs e)
        {
            ClosingApp();
        } //Обрабатываем закрытие окна
        private void TextPlace_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }  //Обрабатываем изменение текста

        private void Saving(bool exit)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, TextPlace.Rtf);
            saved = true;
            if (exit) Application.Exit();
        } //Сохранение
        private void ClosingApp()
        {
            if (!saved)
            {
                var result = MessageBox.Show("Вы хотите сохранить изменения в файле?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) Saving(true);
                if (result == DialogResult.No) Application.Exit();
            }
            else Application.Exit();
        } //Закрываем если сохранили


        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^c");
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^v");
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^x");
        }
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^a");
        }
        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DELETE}");
        }

        private void Bold_Click(object sender, EventArgs e)
        {
            if(Bold)
            {
                TextPlace.SelectionFont = new Font(TextPlace.Font, FontStyle.Bold);
                (sender as Button).ForeColor = Color.White;
                (sender as Button).BackColor = Color.Blue;
                Bold = false;
            }
            else
            {
                TextPlace.SelectionFont = new Font(TextPlace.Font, FontStyle.Regular);
                (sender as Button).ForeColor = default;
                (sender as Button).BackColor = default;
                Bold = true;
            }
        }
        private void CursiveBtn_Click(object sender, EventArgs e)
        {
            if (Cursive)
            {
                TextPlace.SelectionFont = new Font(TextPlace.Font, FontStyle.Italic);
                (sender as Button).ForeColor = Color.White;
                (sender as Button).BackColor = Color.Blue;
                Cursive = false;
            }
            else
            {
                TextPlace.SelectionFont = new Font(TextPlace.Font, FontStyle.Regular);
                (sender as Button).ForeColor = default;
                (sender as Button).BackColor = default;
                Cursive = true;
            }
        }
        private void LineBtn_Click(object sender, EventArgs e)
        {
            if (Line)
            {
                TextPlace.SelectionFont = new Font(TextPlace.Font, FontStyle.Underline);
                (sender as Button).ForeColor = Color.White;
                (sender as Button).BackColor = Color.Blue;
                Line = false;
            }
            else
            {
                TextPlace.SelectionFont = new Font(TextPlace.Font, FontStyle.Regular);
                (sender as Button).ForeColor = default;
                (sender as Button).BackColor = default;
                Line = true;
            }
        }

        private void FontStyleBtn_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            TextPlace.SelectionFont = fontDialog1.Font;
            TextPlace.SelectionColor = fontDialog1.Color;
            FontStyleBtn.Text = fontDialog1.Font.Name + " " + fontDialog1.Font.Size;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    TextPlace.SelectionAlignment = HorizontalAlignment.Left;
                    break;
                case 1:
                    TextPlace.SelectionAlignment = HorizontalAlignment.Center;
                    break;
                case 2:
                    TextPlace.SelectionAlignment = HorizontalAlignment.Right;
                    break;
                default:
                    TextPlace.SelectionAlignment = HorizontalAlignment.Left;
                    break;
            }
        } //Устанавливаем выравнивание

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            TextPlace.SelectionCharOffset = Convert.ToInt32((sender as ComboBox).Text);
        } //Устанавливаем межстрочный интервал

        private void ListBtn_Click(object sender, EventArgs e) 
        {
            string temptext = TextPlace.SelectedText;

            int SelectionStart = TextPlace.SelectionStart;
            int SelectionLength = TextPlace.SelectionLength;

            TextPlace.SelectionStart = TextPlace.GetFirstCharIndexOfCurrentLine();
            TextPlace.SelectionLength = 0;
            TextPlace.SelectedText = "1. ";

            int j = 2;
            for (int i = SelectionStart; i < SelectionStart + SelectionLength; i++)
                if (TextPlace.Text[i] == '\n')
                {
                    TextPlace.SelectionStart = i + 1;
                    TextPlace.SelectionLength = 0;
                    TextPlace.SelectedText = j.ToString() + ". ";
                    j++;
                    SelectionLength += 3;
                }
        } //Создаем список по клику

        private void TextPlace_KeyDown(object sender, KeyEventArgs e)
        {
            int tempNum;
            if (e.KeyCode == Keys.Enter)
                try
                {
                    if (char.IsDigit(TextPlace.Text[TextPlace.GetFirstCharIndexOfCurrentLine()]))
                    {
                        if (char.IsDigit(TextPlace.Text[TextPlace.GetFirstCharIndexOfCurrentLine() + 1]) && TextPlace.Text[TextPlace.GetFirstCharIndexOfCurrentLine() + 2] == '.')
                            tempNum = int.Parse(TextPlace.Text.Substring(TextPlace.GetFirstCharIndexOfCurrentLine(), 2));
                        else tempNum = int.Parse(TextPlace.Text[TextPlace.GetFirstCharIndexOfCurrentLine()].ToString());

                        if (TextPlace.Text[TextPlace.GetFirstCharIndexOfCurrentLine() + 1] == '.' || (char.IsDigit(TextPlace.Text[TextPlace.GetFirstCharIndexOfCurrentLine() + 1]) && TextPlace.Text[TextPlace.GetFirstCharIndexOfCurrentLine() + 2] == '.'))
                        {
                            tempNum++;
                            TextPlace.SelectedText = "\r\n" + tempNum.ToString() + ". ";
                            e.SuppressKeyPress = true;
                        }
                    }
                }
                catch { }
        } //Продолжаем список по нажатию на Enter
    }
}
