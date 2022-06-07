using PlatformDesktop.Views;
using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Point = PlatformDesktop.Models.Point;

namespace PlatformDesktop
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        SerialPort sp = new SerialPort();
        MapView gps;
        private SpeedType _speedType = SpeedType.s;
        public int GPIO1Value = 0;
        public int GPIO2Value = 0;
        public int GPIO3Value = 0;
        public int GPIO4Value = 0;

        public List<Double> LanPoints = new List<double>();
        public List<Double> LonPoints = new List<double>();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void OPENSETTIGNS_CLICK(object sender, RoutedEventArgs e)
        {
            sett = new SettingsWindow(sp);
            sett.Owner = this;
            sett.Show();
        }
        SettingsWindow sett;
        TelemetryWindow telemet = new TelemetryWindow(new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d }, new[] { 0d });

        private void OPENTELEMETRY_CLICK(object sender, RoutedEventArgs e)
        {

            telemet.Show();
        }
        private StuctureDataClass s = new StuctureDataClass();
        private void OPENGPS_CLICK(object sender, RoutedEventArgs e)
        {
            Point marker = new Point(double.Parse("55,7522200"), double.Parse("37,6155600"));
            gps = new MapView(marker);
            gps.Show();

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new System.TimeSpan(0, 0, 10)
            };
            timer.Tick += WriteKMLTrack;
            timer.Start();

            DispatcherTimer timerSavePoint = new DispatcherTimer
            {
                Interval = new System.TimeSpan(0, 0, 5)
            };
            timerSavePoint.Tick += SaveCurrentPositionToKML;
            timerSavePoint.Start();
        }

        private void SaveCurrentPositionToKML(object? sender, EventArgs e)
        {
            LanPoints.Add(Convert.ToDouble(s.Lan));
            LonPoints.Add(Convert.ToDouble(s.Lon));
        }

            private void WriteKMLTrack(object? sender, EventArgs e)
        {

            var root = new Document();
            var track = new SharpKml.Dom.GX.Track();

            foreach (var gc in LanPoints.Zip(LonPoints))
            {
                var vector = new SharpKml.Base.Vector(gc.First, gc.Second);
                track.AddCoordinate(vector);
                track.AddWhen(DateTime.Now);
            }

            Placemark trackPm = new SharpKml.Dom.Placemark();
            trackPm.Geometry = track;
            root.AddFeature(trackPm);

            KmlFile kml = KmlFile.Create(root, false);

            // Open the stream and write to it.
            using (FileStream stream = File.OpenWrite("SavedLastTrack.kml"))
            {
                kml.Save(stream);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedcomboitem = sender as ComboBox;
            string name = selectedcomboitem.SelectedItem as string;
        }
        DispatcherTimer timer = new DispatcherTimer();
        

        //public bool connect = false;
        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            //if (connect == false)
            //{
            try
            {

                PortShow portShow = COM.SelectedItem as PortShow;
                //sp.PortName = portShow.COM;
                if (portShow.COM != null) sp.PortName = portShow.COM;
                else MessageBox.Show("Платформа не выбрана");
                sp.DataReceived += new SerialDataReceivedEventHandler(Recieve);
                sp.BaudRate = 57600;
                sp.Open();
                status.Text = "Подключено";
                timer.Start();
                Connect.Content = "Отключить";
                Connect.Background = Brushes.Red;

            }
            catch
            {
                sp.DataReceived -= new SerialDataReceivedEventHandler(Recieve);
                sp.Close();
                timer.Stop();

                status.Text = "Отключено";
                Connect.Content = "Подключить";
                Connect.Background = Brushes.Green;


            }
            return;



        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            // При закрытии программы, закрываем порт
            if (sp.IsOpen) sp.Close();
        }
        //else
        //{
        //    MessageBox.Show("Сначала подключитесь, а затем уже отключайтесь!");
        //}


        private void Recieve(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            // Collecting the characters received to our 'buffer' (string).
            //Debug.Write(sp.ReadExisting());
            ////Read.Invoke((MethodInvoker)(() => State_Label.Text = "Устройство подключено: " + de.Device.PortName));
            string recieved_data = string.Empty;
            try
            {
                recieved_data = sp.ReadLine();
            }
            catch
            {
            }
             
            //Debug.WriteLine(recieved_data.Length);
            
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                sw.Stop();
                lblsend.Content = sw.ElapsedMilliseconds;
                sw.Reset();
                text = recieved_data;
                if (sett != null && sett.ShowActivated)
                {
                    sett.AddData(recieved_data);
                }
                //if (!StuctureDataClass.CheckLine(text))
                //    return;

                Application.Current.Dispatcher.Invoke(new Action(() => Read.Text = recieved_data));
                //SettingsWindow.
                if (!string.IsNullOrEmpty(text))
                {
                    //MessageBox.Show(text);
                }
                
                if (text.StartsWith("&:") && text.Trim().EndsWith(';'))
                {
                    try
                    {
                        text.Trim();
                        text.Trim(new char[] { '&', ':', ';' });
                        string[] numbers = text.Split(new char[] { ',' });


                        s = new StuctureDataClass(

                        char.Parse(numbers[0][3].ToString()),
                        int.Parse(numbers[1]),
                        char.Parse(numbers[2][0].ToString()),
                        double.Parse(numbers[3].Replace('.', ',')),
                        double.Parse(numbers[4].Replace('.', ',')),
                        double.Parse(numbers[5].Replace('.', ',')),
                        double.Parse(numbers[6].Replace('.', ',')),
                        double.Parse(numbers[7].Replace('.', ',')),
                        double.Parse(numbers[8].Replace('.', ',')),
                        double.Parse(numbers[9].Replace('.', ',')),
                        double.Parse(numbers[10].Replace('.', ',')),
                        double.Parse(numbers[11].Replace('.', ',')),
                        double.Parse(numbers[12].Replace('.', ',')),
                        double.Parse(numbers[13].Replace('.', ',')),
                        numbers[14].Replace('.', ','),
                        numbers[15].Replace('.', ','),
                        double.Parse(numbers[16].Replace('.', ',')),
                        int.Parse(numbers[17].Replace('.', ',')),
                        int.Parse(numbers[18].Replace('.', ',')),
                        int.Parse(numbers[19].Trim().TrimEnd(';'))
                        );

                        if (gps is not null)
                        {
                            gps.Marker.SetValue(Convert.ToDouble(s.Lan), Convert.ToDouble(s.Lon));
                        }
                    }
                    catch
                {
                    //MessageBox.Show("Ошибка!");
                }
                if (telemet != null)
                    {
                        telemet.AddValueSeries(SeriesType.x, s.gyrox);
                        telemet.AddValueSeries(SeriesType.y, s.gyroy);
                        telemet.AddValueSeries(SeriesType.z, s.gyroz);
                
                        telemet.AddValueSeriesA(SeriesType.xA, s.Accx);
                        telemet.AddValueSeriesA(SeriesType.yA, s.Accy);
                        telemet.AddValueSeriesA(SeriesType.zA, s.Accz);
                        telemet.AddValueSeriesM(SeriesType.xM, s.Magx);
                        telemet.AddValueSeriesM(SeriesType.yM, s.Magy);
                        telemet.AddValueSeriesM(SeriesType.zM, s.Magz);
                        telemet.AddValueSeriesCurr(SeriesType.lcurr, s.Lcurr);
                        telemet.AddValueSeriesCurr(SeriesType.rcurr, s.Rcurr);
                        telemet.AddValueSeriesV(SeriesType.vbat, s.Vbat);
                    }
                    //GMap.x = double.Parse(s.Lon);
                    //gmmap.y = double.Parse(s.Lan);
                }
                if(s.SystemStatus == 0)
                {
                    lblStatusPlatform.Content = "Устройство не подключено";
                }
                if (s.SystemStatus == 1)
                {
                    lblStatusPlatform.Content = "Работа";
                }
                if (s.SystemStatus == 2)
                {
                    lblStatusPlatform.Content = "Инициализация";
                }
                if (s.SystemStatus == 3)
                {
                    lblStatusPlatform.Content = "Работа невозможно, вызвано исключение";
                }
                if (s.SystemStatus == 4)
                {
                    lblStatusPlatform.Content = "Неопознанное устройство, неверная синхронизация";
                }
                if (s.SystemStatus == 5)
                {
                    lblStatusPlatform.Content = "Неизвестная ошибка";
                }
                batteryBar.Value = s.Vbat;
                batteryBar.Minimum = 11.15;
                batteryBar.Maximum = 12.60;
                
                progresstext.Text = ((int)((s.Vbat - 11.1) / (12.6 - 11.1) * 100)).ToString() + "%";
                lblStatus.Content = s.Extstatus;
                if (s.Extstatus == 0)
                {
                    lblStatus.Content = "Стоп, обработка команд прекращена";
                }
                if (s.Extstatus == 1)
                {
                    lblStatus.Content = "Работа, обмен командами";
                }
                if (s.Extstatus == 2)
                {
                    lblStatus.Content = "Приготовится/Готов к отключению";
                }
                if (s.Extstatus == 3)
                {
                    lblStatus.Content = "Режим энергосбережения";
                }
                if (s.Extstatus == 4)
                {
                    lblStatus.Content = "Экстренный режим";
                }
                if (s.Extstatus == 5)
                {
                    lblStatus.Content = "Непредвиденная ошибка системы";
                }
                if (s.Extstatus == 6)
                {
                    lblStatus.Content = "Работа, есть проблемы";
                }
                
            }));
        }
        


        string text = "";
        Stopwatch sw = new Stopwatch();
        private List<PortShow> rightPorts = new List<PortShow>();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                try
                {
                    sp.PortName = port;
                    sp.BaudRate = 57600;
                    sp.Open();

                    sp.WriteLine("@");
                    string response = "";

                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    while (sw.Elapsed < System.TimeSpan.FromSeconds(1))
                    {
                        if (sp.BytesToRead > 0)
                        {
                            do
                            {
                                response += $"{(char)sp.ReadByte()}";
                            } while (sp.BytesToRead > 1);
                        }
                    }

                    

                    var pattern = @"@:(.*?),(.*?);";
                    if (new Regex(pattern).IsMatch(response))
                    {
                        var results = new Regex(pattern).Match(response);
                        rightPorts.Add(new PortShow(results.Groups[1].Value, results.Groups[2].Value, sp.PortName));
                    }
                }
                finally
                {
                    sp.Close();
                }
            }

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_TickAsync);
            timer.Interval = new System.TimeSpan(0, 0, 0, 0, 100);

            COM.ItemsSource = rightPorts;
            COM.DisplayMemberPath = "name";
            COM.SelectedValuePath = "key";


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Экстренное выключение применено!");
            timer.Stop();
            while(true) sp.WriteLine("%:s,0,s,0,0,0,0,0,4;");


        }

        async void timer_TickAsync(object sender, EventArgs e)
        {
            timer.Interval = keys.Any() ? new System.TimeSpan(0, 0, 0, 0, 100) : new System.TimeSpan(0, 0, 0, 0, 800);

            if (timer.Interval.TotalMilliseconds < 100)
            {
                good.Fill = Brushes.Green;
                norm.Fill = Brushes.Green;
                bad.Fill = Brushes.Green;
            }
            if (timer.Interval.TotalMilliseconds < 500)
            {
                good.Fill = Brushes.Transparent;
                bad.Fill = Brushes.Green;
                norm.Fill = Brushes.Green;
            }
            if (timer.Interval.TotalMilliseconds < 800)
            {
                good.Fill = Brushes.Transparent;
                norm.Fill = Brushes.Transparent;
                bad.Fill = Brushes.Green;
            }
            ///////////////// Проверить!
            if (timer.Interval.TotalMilliseconds > 5000)
            {
                for (int i = 0; i < 5; i++)
                {
                    await Task.Delay(1000);
                    PCfromArd = "%:s,0,s,0,"+GPIO1Value+","+GPIO2Value+","+GPIO3Value+","+GPIO4Value+",1;";
                    return;
                }

                MessageBox.Show("Ошибка! Проверьте соединение с платформой!");
                timer.Stop();
                sp.Close();


            }
            /////////////////////
            try
            {
                if (masterLinkManual != null)
                {
                    GPIO1Value = masterLinkManual.GPIO1Value;
                    GPIO2Value = masterLinkManual.GPIO2Value;
                    GPIO3Value = masterLinkManual.GPIO3Value;
                    GPIO4Value = masterLinkManual.GPIO4Value;
                }
                sp.WriteLine(PCfromArd);                        // Отправка на платформу
                PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
            }
            catch { }
            // Debug.WriteLine(PCfromArd);     ///////////////////////////////////
            sw.Start();
            lblTime.Content = DateTime.Now.ToString("HH:mm:ss.fff");
            
            CommandManager.InvalidateRequerySuggested();
           

        }


        private string _pcFromArd = "%:s,0,s,0,0,0,0,0,1;";

        public string PCfromArd
        {
            get => _pcFromArd;
            set
            {
                _pcFromArd = value;

                if (s.Move == 's')
                {
                    ostop.Opacity = 1;
                }
                else
                {
                    ostop.Opacity = 0.3;
                }

                if (s.Move == 'f')
                {
                    of.Opacity = 1;

                }
                else
                {
                    of.Opacity = 0.3;
                }
                if (s.Move == 'r')
                {
                    or.Opacity = 1;
                }
                else
                {
                    or.Opacity = 0.3;
                }
                if (s.Move == 'b')
                {
                    ob.Opacity = 1;

                }
                else
                {
                    ob.Opacity = 0.3;
                }
                if (s.Move == 'l')
                {
                    ol.Opacity = 1;

                   
                }
                else
                {
                    ol.Opacity = 0.3;
                }
                if (s.Move == 'a')
                {
                    ofandl.Opacity = 1;

                   
                }
                else
                {
                    ofandl.Opacity = 0.3;
                }
                if (s.Move == 'c')
                {
                    ofandr.Opacity = 1;

                   
                }
                else
                {
                    ofandr.Opacity = 0.3;

                }
                if (s.Move == 'd')
                {
                    obandl.Opacity = 1;

                    
                }
                else
                {
                    obandl.Opacity = 0.3;
                }
                if (s.Move == 'e')
                {
                    obandr.Opacity = 1;

                    
                }
                else
                {
                    obandr.Opacity = 0.3;
                }

                OnPropertyChanged();
            }
        }

        

        private void Image_MouseDownb(object sender, MouseButtonEventArgs e)
        {
            // ob.Opacity = 1;
            PCfromArd = $"%:b,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }
        private void Image_MouseDownbandl(object sender, MouseButtonEventArgs e)
        {
            // obandl.Opacity = 1;
            PCfromArd = $"%:d,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }
        private void Image_MouseDownl(object sender, MouseButtonEventArgs e)
        {
            // ol.Opacity = 1;
            PCfromArd = $"%:l,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }
        private void Image_MouseDownfandl(object sender, MouseButtonEventArgs e)
        {
            // ofandl.Opacity = 1;
            PCfromArd = $"%:a,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }
        private void Image_MouseDownf(object sender, MouseButtonEventArgs e)
        {
            // of.Opacity = 1;
            PCfromArd = $"%:f,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";


        }
        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
            //  of.Opacity = 0.3;
        }
        private void Image_MouseDownfandr(object sender, MouseButtonEventArgs e)
        {
            // ofandr.Opacity = 1;
            PCfromArd = $"%:c,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }
        private void Image_MouseDownr(object sender, MouseButtonEventArgs e)
        {
            // or.Opacity = 1;
            PCfromArd = $"%:r,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }
        private void Image_MouseDownbandr(object sender, MouseButtonEventArgs e)
        {
            // obandr.Opacity = 1;
            PCfromArd = $"%:e,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }
        private void Image_MouseDownstop(object sender, MouseButtonEventArgs e)
        {
             
            PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
            // ostop.Opacity = 1;
        }
        
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).Value = Math.Round(e.NewValue);
            ((Slider)sender).SelectionEnd = Math.Round(e.NewValue);
            PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkf.IsChecked ?? false)
            {
                _speedType = SpeedType.f;
            }
            else if (checks.IsChecked ?? false)
            {
                _speedType = SpeedType.s;
            }
            PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
        }

        private List<Key> keys = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (keys.Count < 2 && !keys.Contains(e.Key))
                keys.Add(e.Key);

            timer.Interval = keys.Any() ? new System.TimeSpan(0, 0, 0, 0, 100) : new System.TimeSpan(0, 0, 0, 0, 800);

            if (keys.Count == 2)
            {
                PCfromArd = TwoKey(keys.First(), keys.Last());
            }
            else
            {
                PCfromArd = BaseKey(e.Key);
            }

        }

        private void OnKeyUpHandler(object sender, KeyEventArgs e)
        {


            keys.Remove(e.Key);

            if (keys.Count > 0)
            {
                PCfromArd = BaseKey(keys.Last());
            }
            else
            {
                switch (e.Key)
                {
                    case Key.W:
                        PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                        break;
                    case Key.S:
                        PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                        break;
                    case Key.A:
                        PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                        break;
                    case Key.D:
                        PCfromArd = $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                        break;

                }
            }
        }

        private string BaseKey(Key key)
        {
            return key switch
            {
                Key.W => $"%:f,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;",
                Key.S => $"%:b,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;",
                Key.A => $"%:l,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;",
                Key.D => $"%:r,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;",
                _ => "%:s,0,s,0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;"
            };

        }

        private string TwoKey(Key key1, Key key2)
        {
            switch (key1)
            {
                case Key.W:
                    if (key2 == Key.W)
                    {
                        return $"%:f,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.S)
                    {
                        return $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.A)
                    {
                        return $"%:a,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.D)
                    {
                        return $"%:c,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else return $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                case Key.S:
                    if (key2 == Key.W)
                    {
                        return $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.S)
                    {
                        return $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.A)
                    {
                        return $"%:d,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.D)
                    {
                        return $"%:e,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else return $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                case Key.A:
                    if (key2 == Key.W)
                    {
                        return $"%:a,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.S)
                    {
                        return $"%:d,{slValue.Value},{_speedType}0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.A)
                    {
                        return $"%:l,{slValue.Value},{_speedType}0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.D)
                    {
                        return $"%:l,{slValue.Value},{_speedType}0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else return $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                case Key.D:
                    if (key2 == Key.W)
                    {
                        return $"%:c,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.S)
                    {
                        return $"%:e,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.A)
                    {
                        return $"%:l,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else if (key2 == Key.D)
                    {
                        return $"%:l,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                    }
                    else return $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
                default: return $"%:s,{slValue.Value},{_speedType},0,{GPIO1Value},{GPIO2Value},{GPIO3Value},{GPIO4Value},1;";
            }
        }

        private void godisp_Click(object sender, RoutedEventArgs e)
        {
            MasterLinkDisplay disp = new MasterLinkDisplay(sp);
            disp.Show();
        }
        MasterLinkManual masterLinkManual;
        private void MasterLink_Click(object sender, RoutedEventArgs e)
        {

            switch (s.Extid)
            {
                case 0:
                    masterLinkManual = new MasterLinkManual();
                    masterLinkManual.Show();
                    break;

                case 1:
                    MasterLinkDisplay disp = new MasterLinkDisplay(sp);
                    disp.Show();
                    break;
            }
            
        }
    }

    public enum SpeedType
    {
        f,
        s,
    }

 

}

// TODO 
/* Ползунок мощности 
 * GPS
 * Убрать режим разгона из мощности
 * стрелки пофиксить
 * модульность +-
 * дизайн дисплею +-
 * запись полученной телеметрии в графики
 * открытие модуля + закрытие модуля по extid
 */