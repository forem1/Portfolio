using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroWork
{
    public partial class MainMenu : Form
    {
        /// <summary>
        /// Точка входа в форму
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Debug
        /// </summary>
        private void Debug_Btn_Click(object sender, EventArgs e)
        {
            Debug DebugForm = new Debug();
            DebugForm.Show();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Работа
        /// </summary>
        private void WorkMenu_Btn_Click(object sender, EventArgs e)
        {
            WorkTimer WorkTimerForm = new WorkTimer();
            WorkTimerForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Отдых
        /// </summary>
        private void RelaxMenu_Btn_Click(object sender, EventArgs e)
        {
            RelaxTimer RelaxTimerForm = new RelaxTimer();
            RelaxTimerForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Новая запись в дневнике
        /// </summary>
        private void PostMenu_Btn_Click(object sender, EventArgs e)
        {
            AddPost AddPostForm = new AddPost();
            AddPostForm.Show();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку закрытия формы
        /// </summary>
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Статистика и дневник
        /// </summary>
        private void Stats_Btn_Click(object sender, EventArgs e)
        {
            StatisticForm StatisticFormForm = new StatisticForm();
            StatisticFormForm.Show();
        }
    }
}
