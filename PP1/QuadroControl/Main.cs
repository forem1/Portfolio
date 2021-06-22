using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Globalization;

namespace QuadroControl
{
    public partial class Main : Form
    {
        bool isConnected = false;

        public int RemoteStatus = 0;
        public float RemotePowerCurrent = 0;
        public float RemotePowerVoltage = 0;
        public int RemoteMainDirection = 0;

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;


        public Main()
        {
            InitializeComponent();

            ConnectPortMain_ComboBox.Items.Clear();
            // Получаем список COM портов доступных в системе
            string[] portnames = SerialPort.GetPortNames();
            // Проверяем есть ли доступные
            if (portnames.Length == 0)
            {
                MessageBox.Show("COM Port not found");
            }
            foreach (string portName in portnames)
            {
                //добавляем доступные COM порты в список
                ConnectPortMain_ComboBox.Items.Add(portName);
                Console.WriteLine(portnames.Length);
                if (portnames[0] != null)
                {
                    ConnectPortMain_ComboBox.SelectedItem = portnames[0];
                }
            }

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
                comboBox1.Items.Add(Device.Name);
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void ConnectBtnMain_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isConnected)
                {
                    isConnected = true;
                    if (ConnectPortMain_ComboBox.SelectedIndex != -1)
                    {
                        string selectedPort = ConnectPortMain_ComboBox.GetItemText(ConnectPortMain_ComboBox.SelectedItem);
                        serialPort1.PortName = selectedPort;
                        serialPort1.BaudRate = 9600;
                        serialPort1.Open();
                        serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    }

                    if (comboBox1.SelectedIndex != -1)
                    {
                        videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
                        videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                        videoCaptureDevice.Start();
                    }

                    ConnectBtnMain_Btn.Text = "Disconnect";
                    ConnectBtnMain_Btn.BackColor = Color.Green;
                    Emergency_Btn.Visible = true;
                }
                else
                {
                    isConnected = false;
                    if (videoCaptureDevice.IsRunning == true) videoCaptureDevice.Stop();
                    serialPort1.Close();
                    ConnectBtnMain_Btn.Text = "Connect";
                    ConnectBtnMain_Btn.BackColor = Color.Red;
                    Emergency_Btn.Visible = false;
                }
            }
            catch { }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // При закрытии программы, закрываем порт
            if (serialPort1.IsOpen) serialPort1.Close();
        }

//---------------------------------------------------Telemetry--------------------------------------------------

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine(indata);
            if (indata.Length > 0)
            {
                try
                {
                    RemoteStatus = Convert.ToInt32(indata.Split(' ')[0]);
                    //RemotePowerCurrent = float.Parse(indata.Split(' ')[1], CultureInfo.InvariantCulture);
                    //RemotePowerVoltage = float.Parse(indata.Split(' ')[2], CultureInfo.InvariantCulture);
                    RemoteMainDirection = Convert.ToInt32(indata.Split(' ')[3]);
                    TelemetryRawMain_RichTextBox.Invoke(new Action(() => TelemetryRawMain_RichTextBox.Text += indata + "\r"));
                }
                catch { }
            }


            switch (RemoteStatus)
            {
                case 0:
                    TelemetryStatus_Label.Invoke(new Action(() => TelemetryStatus_Label.Text = "Status: Idle"));
                    TelemetryStatus_Label.Invoke(new Action(() => TelemetryStatus_Label.ForeColor = Color.White));
                    break;
                case 1:
                    TelemetryStatus_Label.Invoke(new Action(() => TelemetryStatus_Label.Text = "Status: Working"));
                    TelemetryStatus_Label.Invoke(new Action(() => TelemetryStatus_Label.ForeColor = Color.White));
                    DirectionForward_Btn.Invoke(new Action(() => DirectionForward_Btn.Enabled = true));
                    DirectionBackward_Btn.Invoke(new Action(() => DirectionBackward_Btn.Enabled = true));
                    DirectionLeft_Btn.Invoke(new Action(() => DirectionLeft_Btn.Enabled = true));
                    DirectionRight_Btn.Invoke(new Action(() => DirectionRight_Btn.Enabled = true));
                    break;
                case 2:
                    TelemetryStatus_Label.Invoke(new Action(() => TelemetryStatus_Label.Text = "Status: Emergency"));
                    TelemetryStatus_Label.Invoke(new Action(() => TelemetryStatus_Label.ForeColor = Color.Red));
                    break;
            }

            switch (RemoteMainDirection)
            {
                case 0:
                    TelemetryDirection_Label.Invoke(new Action(() => TelemetryDirection_Label.Text = "Direction: Backward"));
                    break;
                case 1:
                    TelemetryDirection_Label.Invoke(new Action(() => TelemetryDirection_Label.Text = "Direction: Forward"));
                    break;
            }

            //TelemetryCurrent_Label.Invoke(new Action(() => TelemetryCurrent_Label.Text = "Current: " + RemotePowerCurrent.ToString("0.0")));
            //TelemetryVoltage_Label.Invoke(new Action(() => TelemetryVoltage_Label.Text = "Voltage: " + RemotePowerVoltage.ToString("0.0")));
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        //---------------------------------------------------Telemetry--------------------------------------------------

        //---------------------------------------------------Send command-----------------------------------------------
        private void DirectionLeft_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            SendData('L');
        }

        private void DirectionRight_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            SendData('R');
        }

        private void DirectionRight_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            SendData('D');
        }

        private void DirectionForward_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            SendData('F');
        }

        private void DirectionBackward_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            SendData('B');
        }

        private void DirectionForward_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            SendData('S');
        }

        private void Emergency_Btn_Click(object sender, EventArgs e)
        {
            SendData('E');
            DirectionForward_Btn.Enabled = false;
            DirectionBackward_Btn.Enabled = false;
            DirectionLeft_Btn.Enabled = false;
            DirectionRight_Btn.Enabled = false;
        }

        bool isPressedKey = false;
        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W || e.KeyData == Keys.S) SendData('S');
            if (e.KeyData == Keys.A || e.KeyData == Keys.D) SendData('D');
            isPressedKey = false;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W && (!isPressedKey))
            {
                SendData('F');
                isPressedKey = true;
            }

            if (e.KeyData == Keys.A && (!isPressedKey))
            {
                SendData('L');
                isPressedKey = true;
            }
            if (e.KeyData == Keys.S && (!isPressedKey))
            {
                SendData('B');
                isPressedKey = true;
            }
            if (e.KeyData == Keys.D && (!isPressedKey))
            {
                SendData('R');
                isPressedKey = true;
            }
            if (e.KeyData == Keys.Escape)
            {
                SendData('E');
                isPressedKey = true;
                DirectionForward_Btn.Enabled = false;
                DirectionBackward_Btn.Enabled = false;
                DirectionLeft_Btn.Enabled = false;
                DirectionRight_Btn.Enabled = false;
                SendData('E');
            }
        }

        //---------------------------------------------------Send command-----------------------------------------------

        private void SendData(char data)
        {
            try
            {
                serialPort1.Write(data + "\n");
            }
            catch { }
        }

        private void SendRawCommand_Btn_Click(object sender, EventArgs e)
        {
            serialPort1.Write(RawCommand_TextBox.Text + "\n");
        }

        private void RawCommand_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            serialPort1.Write(RawCommand_TextBox.Text + "\n");
        }

        private void TelemetryRawMain_RichTextBox_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            TelemetryRawMain_RichTextBox.SelectionStart = TelemetryRawMain_RichTextBox.Text.Length;
            // scroll it automatically
            TelemetryRawMain_RichTextBox.ScrollToCaret();
        }
    }
}
