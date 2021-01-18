using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace tic_tac_toe
{
    /// <summary>
    /// 3 - просто дописать логику
    /// 4 - счет
    /// 5 - 2 режима игры: вдвоем или с ботом
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            buttons = new Button[]
            {
                Bt1, Bt2, Bt3, Bt4, Bt5, Bt6, Bt7, Bt8, Bt9
            };
            for(int i = 0; i<buttons.Length; i++)
            {
                buttons[i].Click += Bt1_Click;
            }
        }

        int XScore = 0;
        int OScore = 0;

        Button[] buttons;

        private void Start_Click(object sender, RoutedEventArgs e)
        { 
            for (int i = 0; i< buttons.Length; i++)
            {
                buttons[i].Content = "";
                buttons[i].IsEnabled = true;
            }
            xo = true;
            all = 0;
        }

        bool xo;
        int all = 0;

        private void Bt1_Click(object sender, RoutedEventArgs e) {
            all++;

            if (all < 10)
            {
                //Sender as button
                (sender as Button).IsEnabled = false;
                if (xo && !Comp_Game)
                    (sender as Button).Content = "O";
                else
                    (sender as Button).Content = "X";
                xo = !xo;


                if (Comp_Game && xo)
                {
                    Random rnd = new Random();
                    int value = rnd.Next(0, 8);
                    while ((String)buttons[value].Content == "O" || (String)buttons[value].Content == "X" || (String)buttons[value].Content != "") 
                    {
                       value = rnd.Next(0, 8);
                    }

                    buttons[value].Content = "O";
                    buttons[value].IsEnabled = false;
                    xo = !xo;

                }
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("", "Ничья");
                _ = messageDialog.ShowAsync();
                all = 0;
            }


            if (((String)Bt1.Content == "X" && (String)Bt4.Content == "X" && (String)Bt7.Content == "X") || ((String)Bt2.Content == "X" && (String)Bt5.Content == "X" && (String)Bt8.Content == "X") || ((String)Bt3.Content == "X" && (String)Bt6.Content == "X" && (String)Bt9.Content == "X") || ((String)Bt1.Content == "X" && (String)Bt2.Content == "X" && (String)Bt3.Content == "X") || ((String)Bt4.Content == "X" && (String)Bt5.Content == "X" && (String)Bt6.Content == "X") || ((String)Bt7.Content == "X" && (String)Bt8.Content == "X" && (String)Bt9.Content == "X") || ((String)Bt1.Content == "X" && (String)Bt5.Content == "X" && (String)Bt9.Content == "X") || ((String)Bt3.Content == "X" && (String)Bt5.Content == "X" && (String)Bt7.Content == "X"))
            {
                XScore++;
                MessageDialog messageDialog = new MessageDialog("Счет "+ XScore, "Крестики победили");
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].IsEnabled = false;
                }
                _ = messageDialog.ShowAsync();
            }
            if(((String)Bt1.Content == "O" && (String)Bt4.Content == "O" && (String)Bt7.Content == "O") || ((String)Bt2.Content == "O" && (String)Bt5.Content == "O" && (String)Bt8.Content == "O") || ((String)Bt3.Content == "O" && (String)Bt6.Content == "O" && (String)Bt9.Content == "O") || ((String)Bt1.Content == "O" && (String)Bt2.Content == "O" && (String)Bt3.Content == "O") || ((String)Bt4.Content == "O" && (String)Bt5.Content == "O" && (String)Bt6.Content == "O") || ((String)Bt7.Content == "O" && (String)Bt8.Content == "O" && (String)Bt9.Content == "O") || ((String)Bt1.Content == "O" && (String)Bt5.Content == "O" && (String)Bt9.Content == "O") || ((String)Bt3.Content == "O" && (String)Bt5.Content == "O" && (String)Bt7.Content == "O")) {
                OScore++;
                MessageDialog messageDialog = new MessageDialog("Счет " + OScore, "Нолики победили");
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].IsEnabled = false;
                }
                _ = messageDialog.ShowAsync();
            }

            X_Score.Text = Convert.ToString(XScore);
            O_Score.Text = Convert.ToString(OScore);
        }

        bool Comp_Game;

        private void CompGame_Click(object sender, RoutedEventArgs e)
        {
            if (CompGame.IsChecked == true)
            {
                MessageDialog messageDialog = new MessageDialog("", "Компьютер - O");
                _ = messageDialog.ShowAsync();
                Comp_Game = true;
            }
            else {
                Comp_Game = false;
            }
        }
    }
}