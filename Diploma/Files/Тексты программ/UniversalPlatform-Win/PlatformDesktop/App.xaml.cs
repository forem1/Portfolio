using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PlatformDesktop.Options;

namespace PlatformDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Установка полного пути к файлу карт
            // Environment.CurrentDirectory - путь к хранению программы
            MapSettings.MapPath = $"{Environment.CurrentDirectory}\\{MapSetting.Default.MapPath}";
        }
    }
}
