using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Playeer
{
    public sealed partial class MainPage : Page
    {

        bool PlayState = false;
        int PlayTime = 0;

        StorageFile file;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void PlayPauseChange(object sender, RoutedEventArgs e)
        {
            if (PlayState)
            {
                PlayState = false;
                PlayPauseButton.Content = "&#xE769;";
                MediaPlayer.Pause();
            }
            else
            {
                PlayState = true;
                PlayPauseButton.Content = "&#xE768;";
                MediaPlayer.Play();
            }

            //TimeChanger.Value = MediaPlayer.Position.TotalSeconds;
        } //Меняем значение кнопки воспр/пауза

        async private void AddNewSong(object sender, RoutedEventArgs e)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.FileTypeFilter.Add(".wma");
            openPicker.FileTypeFilter.Add(".mp3");

           var fileOpen = await openPicker.PickSingleFileAsync();
            if (fileOpen != null)
            {
                file = fileOpen;
                MusicList.Items.Add(new MyListObject(file.Name, file));              
                PlaySong();
            }
        } //Добавляем новую песню в плейлист

        async private void PlaySong()
        {
            var stream = await file.OpenReadAsync();
            MediaPlayer.SetSource(stream, "");
            MusicName.Text = file.Name;
            MediaPlayer.Play();
        } //Воспроизводит файл

        private void SelectSong(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine((MusicList.SelectedItem as MyListObject).Path);
            file = (MusicList.SelectedItem as MyListObject).Path;
            PlaySong();
        } //Выбираем песню из списка

        private void ChangeVolume(object sender, RangeBaseValueChangedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine((sender as Slider).Value);
            MediaPlayer.Volume = (sender as Slider).Value/100;
        } //Меняет громкость

        private void ChangeTime(object sender, RangeBaseValueChangedEventArgs e)
        {
            MediaPlayer.Pause();
            MediaPlayer.Position = TimeSpan.FromSeconds(TimeChanger.Value);
            MediaPlayer.Play();
        } //Меняет время

        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeChanger.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
        } //Получаем инфу из открытого файла

    }

    public class MyListObject
    {
        public string Name { get; set; }
        public StorageFile Path { get; set; }

        public MyListObject(string name, StorageFile path)
        {
            Path = path;
            Name = name;
        }
        // to nicely display it in List Box
        public override string ToString()
        {
            return Name;
        }
    }
}
