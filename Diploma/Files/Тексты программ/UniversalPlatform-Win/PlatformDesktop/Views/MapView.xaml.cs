using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using PlatformDesktop.Options;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WPFMap.Models;
using Placemark = SharpKml.Dom.Placemark;
using Point = PlatformDesktop.Models.Point;

namespace PlatformDesktop.Views
{

    /// <summary>
    ///     Interaction logic for GMapView.xaml
    /// </summary>
    public partial class MapView : Window
    {

        private StuctureDataClass s = new StuctureDataClass();

        public MapLine Track;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public MapView()
        {
            new MapView(new Point() { X = Convert.ToDouble(s.Lan), Y = Convert.ToDouble(s.Lon) });
            InitializeComponent();
            Configure();
            SetMarkerValue();
        }

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="marker">Класс маркера <see name="Point" /></param>
        public MapView(Point? marker = null)
        {
            InitializeComponent();

            if (marker.X == marker.Y || marker.X == 0 || marker.Y == 0) {
                Configure(null);
                return;
            }
            Configure(marker);
            Track = new MapLine(marker, Marker);
            SetMarkerValue(marker);
            Methods.DrawLine(MapGm, Track);
          
        }

        /// <summary>
        ///     Данные маркера
        /// </summary>
        public Point Marker { get; set; } = new();

        /// <summary>
        /// Конфигурация MapGm
        /// </summary>
        /// <param name="marker">Маркер</param>
        private void Configure(Point? marker = null)
        {
            // Создание события изменения XY
            Marker.SetXY += MarkerOnSetXY;

            // Настройка MapGm из файла MapSettings.setting
            MapGm.Bearing = MapSetting.Default.Bearing;
            MapGm.CanDragMap = MapSetting.Default.CanDragMap;
            MapGm.MaxZoom = MapSetting.Default.MaxZoom;
            MapGm.MinZoom = MapSetting.Default.MinZoom;
            MapGm.Zoom = MapSetting.Default.Zoom;
            MapGm.ShowTileGridLines = MapSetting.Default.ShowTileGridLines;
            MapGm.ShowCenter = MapSetting.Default.ShowCenter;

            // Остальные настройки MapGm
            MapGm.DragButton = MouseButton.Left;
            MapGm.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            MapGm.MapProvider = GMapProviders.GoogleMap;

            // Проверка на существование подключения к интернету
            GMaps.Instance.Mode = new Ping().Send(IPAddress.Parse("8.8.8.8")).Status == IPStatus.Success
                ? AccessMode.ServerOnly
                : AccessMode.CacheOnly;

            // Проверка режима (Из файла/По сети)
            // Путь к файлу задан в:
            // MapSetting.settings - название файла
            // App.xaml - задает полный путь
            // MapSetting.cs - хранит полный путь
            if (GMaps.Instance.Mode == AccessMode.CacheOnly)
            {
                // Установка пути элементу GMapControl к файлу с картой,
                // TODO: Файла с картой нет
                GMaps.Instance.ImportFromGMDB(MapSettings.MapPath);
            }
            else if (GMaps.Instance.Mode == AccessMode.ServerOnly)
            {
                // Настройка запросов
                GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
                GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;
            }
        }

        /// <summary>
        ///     Установка значения маркера
        /// </summary>
        /// <param name="marker">Маркер</param>
        private void SetMarkerValue(Point? marker = null)
        {
            // Координаты Москвы, задаются в MapSettings.setting
            Marker.SetValue(marker ?? new Point(MapSetting.Default.DefaultX, MapSetting.Default.DefaultY));

        }

        /// <summary>
        ///     Обработчик события изменения XY
        /// </summary>
        /// <param name="x">Новое значение X</param>
        /// <param name="y">Новое значение Y</param>
        /// <param name="oldX">Старое значение X</param>
        /// <param name="oldY">Старое значение Y</param>
        private void MarkerOnSetXY(double x, double y, double oldX, double oldY)
        {

            // Изменение основного маркера
            //x = s.Lon.Length;
            //y = s.Lan.Length;
            // Проверка существования основного маркера
            if (MapGm.Markers.Count > 0)
                // Изменение положения основного маркера
                MapGm.Markers[0].Position = new PointLatLng(x, y);  // x and y
            else
            {
                // Создание маркера
                var marker = new GMapMarker(Marker.GetPointLatLng())
                {
                    Shape = GetImage($"{Environment.CurrentDirectory}\\Images\\mark.png")
                };

                // Добавление нового маркера, c картинкой mark.png
                MapGm.Markers.Add(marker);
            }


            // Перемещение на позицию поставленного маркера
            MapGm.Position = Marker.GetPointLatLng();


            // Изменени трека
            // Изменение начальной и конечной точки линии
            Track.StartMapPoint = new Point(oldX, oldY);
            Track.EndMapPoint = new Point(x, y);  // x and y

            // Рисуем линию с новыми координатами
            Methods.DrawLine(MapGm, Track);
        }

        /// <summary>
        ///     Получение изображения
        /// </summary>
        /// <returns>Изображение</returns>
        private Image GetImage(string path)
        {
            return new Image
            {
                // Получение изображения
                Source = new BitmapImage(new Uri(path)),
                // Высота изображения, отображаемого изображения
                Height = 20,
                // Ширина изображения, отображаемого изображения
                Width = 20,
                // Статус видимости (видима)
                Visibility = Visibility.Visible,
                // Текст, отображаемый при наведении на маркер
                ToolTip = "Ты тут"
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}