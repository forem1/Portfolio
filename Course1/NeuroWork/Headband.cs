using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;
using System.IO;
using System.IO.Ports;
using System.Data.SQLite;

namespace NeuroWork
{
    public partial class Headband : Form
    {
        private SQLiteConnection connection = new SQLiteConnection();
        private SQLiteCommand cmd = new SQLiteCommand();

        static Connector connector;
        public bool ConnectedDevice = false;
        public bool OpenedForm = false;

        public int PoorSignal = 0;
        public int Raw = 0;
        public int Attention = 0;
        public int Meditation = 0;
        public int Delta = 0;
        public int Theta = 0;
        public int LowAlpha = 0;
        public int HighAlpha = 0;
        public int LowBeta = 0;
        public int HighBeta = 0;
        public int LowGamma = 0;
        public int HighGamma = 0;

        public Headband()
        {
            InitializeComponent();

            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.Show();

            if (!File.Exists("DB.db3"))
            {
                SQLiteConnection.CreateFile("DB.db3");

                try
                {
                    connection = new SQLiteConnection("Data Source=DB.db3");
                    connection.Open();
                    cmd.Connection = connection;

                    cmd.CommandText = @"CREATE TABLE [Journal] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Date] TEXT NOT NULL,
                    [Post] TEXT NOT NULL,
                    [Emotion] TEXT NOT NULL
                    );
                    CREATE TABLE [AvaragePoints] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Date] TEXT NOT NULL,
                    [Time] INTEGER NOT NULL,
                    [TypeOfActivity] TEXT NOT NULL,
                    [Value] INTEGER NOT NULL
                    );";

                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            Connect();
        }

        public void Connect()
        {
            State_Label.Text = "Подключение";

            // Initialize a new Connector and add event handlers
            connector = new Connector();
            connector.DeviceConnected += new EventHandler(OnDeviceConnected);
            connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
            connector.DeviceValidating += new EventHandler(OnDeviceValidating);

            // Scan for devices
            connector.ConnectScan("COM6");
        }

        public void OnDeviceConnected(object sender, EventArgs e)
        {
            Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;

            State_Label.Invoke((MethodInvoker)(() => State_Label.Text = "Устройство подключено: " + de.Device.PortName));
            Console.WriteLine( "Device found on: "  + de.Device.PortName);
            ConnectedDevice = true;

            de.Device.DataReceived += new EventHandler(OnDataReceived);
        }

        public void OnDeviceFail(object sender, EventArgs e)
        {
            State_Label.Invoke((MethodInvoker)(() => State_Label.Text = "Устройство не найдено!"));
            Console.WriteLine( "No devices found!");

            ConnectedDevice = false;
        }

        public void OnDeviceValidating(object sender, EventArgs e)
        {
            Console.WriteLine("Validating...");
            State_Label.Invoke((MethodInvoker)(() => State_Label.Text = "Проверка..."));
        }

        public void OnDataReceived(object sender, EventArgs e)
        {
            Device.DataEventArgs de = (Device.DataEventArgs)e;

            NeuroSky.ThinkGear.DataRow[] tempDataRowArray = de.DataRowArray;

            TGParser tgParser = new TGParser();
            tgParser.Read(de.DataRowArray);

            Console.WriteLine("-------------Signals------------");

            for (int i = 0; i < tgParser.ParsedData.Length; i++)
            {

                if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
                {
                    PoorSignal = Convert.ToInt32(100 - tgParser.ParsedData[i]["PoorSignal"]);
                    Console.WriteLine(PoorSignal);
                }

                if (tgParser.ParsedData[i].ContainsKey("Raw"))
                {
                    Raw = Convert.ToInt32(tgParser.ParsedData[i]["Raw"]);
                    Console.WriteLine();
                }

                if (tgParser.ParsedData[i].ContainsKey("Attention"))
                {
                    Attention = Convert.ToInt32(tgParser.ParsedData[i]["Attention"]);
                    Console.WriteLine(Attention);
                }

                if (tgParser.ParsedData[i].ContainsKey("Meditation"))
                {
                    Meditation = Convert.ToInt32(tgParser.ParsedData[i]["Meditation"]);
                    Console.WriteLine(Meditation);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
                {
                    Delta = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerDelta"]);
                    Console.WriteLine(Delta);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerTheta"))
                {
                    Theta = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerTheta"]);
                    Console.WriteLine(Theta);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha1"))
                {
                    LowAlpha = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerAlpha1"]);
                    Console.WriteLine(LowAlpha);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha2"))
                {
                    HighAlpha = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerAlpha2"]);
                    Console.WriteLine(HighAlpha);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta1"))
                {
                    LowBeta = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerBeta1"]);
                    Console.WriteLine(LowBeta);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta2"))
                {
                    HighBeta = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerBeta2"]);
                    Console.WriteLine(HighBeta);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma1"))
                {
                    LowGamma = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerGamma1"]);
                    Console.WriteLine(LowGamma);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma2"))
                {
                    HighGamma = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerGamma2"]);
                    Console.WriteLine(HighGamma);
                }
            }
            Console.WriteLine("-------------Signals------------");

            PoorSignal_Label.Invoke((MethodInvoker)(() => PoorSignal_Label.Text = "Сила сигнала: " + PoorSignal));
            if (PoorSignal == 100 && !OpenedForm)
            {
                this.Invoke((MethodInvoker)(() => this.Hide()));
                OpenedForm = true;
            } 
        }

        private void ButtonConnect_Btn_Click(object sender, EventArgs e)
        {
            if(!ConnectedDevice) Connect();
        }
    }
}
