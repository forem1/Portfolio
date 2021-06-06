using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroWork
{
    public partial class AddPost : Form
    {
        private SQLiteConnection connection = new SQLiteConnection();
        private string Emotion = "Не выбрано";

        /// <summary>
        /// Точка входа в форму
        /// </summary>
        public AddPost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сохранить пост
        /// </summary>
        private void SavePost_Btn_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                try
                {
                    connection = new SQLiteConnection("Data Source=DB.db3");
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand(String.Format("INSERT INTO Journal (Date, Post, Emotion) VALUES ('{0}','{1}', '{2}')", DateTime.Now.ToString(), richTextBox1.Text, Emotion), connection);
                    cmd.ExecuteNonQuery();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("Заметка добавлена");

                    MainMenu MainMenuForm = new MainMenu();
                    MainMenuForm.Show();
                }
            }
            else MessageBox.Show("Не заполнен текст заметки");
        }

        /// <summary>
        /// обработчик выбора эмоции
        /// </summary>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch(radioButton.TabIndex)
                {
                    case 0:
                        Emotion = "Нейтрально";
                        break;
                    case 1:
                        Emotion = "Радость";
                        break;
                    case 2:
                        Emotion = "Страх";
                        break;
                    case 3:
                        Emotion = "Гнев";
                        break;
                    case 4:
                        Emotion = "Отвращение";
                        break;
                    case 5:
                        Emotion = "Презрение";
                        break;
                    case 6:
                        Emotion = "Интерес";
                        break;
                    case 7:
                        Emotion = "Удивление";
                        break;
                    case 8:
                        Emotion = "Обида";
                        break;
                    case 9:
                        Emotion = "Смущение";
                        break;
                }
            }
        }
    }
}
