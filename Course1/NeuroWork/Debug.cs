using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroWork
{
    public partial class Debug : Form
    {
        private bool closeAllThread = false;

        /// <summary>
        /// Точка входа в форму
        /// </summary>
        public Debug()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Таймер для графиков и полос
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!closeAllThread)
            {
                var tParam = new Thread(() => plotParam());
                tParam.Start();

                var tWaves = new Thread(() => plotWaves());
                tWaves.Start();
            }
        }

        /// <summary>
        /// Отрисовка полос
        /// </summary>
        private void plotParam()
        {
            SignalDebug_Label.Invoke((MethodInvoker)(() => SignalDebug_Label.Text = "Signal: " + (Application.OpenForms["Headband"] as Headband).PoorSignal + "%"));

            AttentionDebug_Label.Invoke((MethodInvoker)(() => AttentionDebug_Label.Text = "Attention: " + (Application.OpenForms["Headband"] as Headband).Attention));
            AttentionDebug_Bar.Invoke((MethodInvoker)(() => AttentionDebug_Bar.Value = (Application.OpenForms["Headband"] as Headband).Attention));

            MeditationDebug_Label.Invoke((MethodInvoker)(() => MeditationDebug_Label.Text = "Meditation: " + (Application.OpenForms["Headband"] as Headband).Meditation));
            MeditationDebug_Bar.Invoke((MethodInvoker)(() => MeditationDebug_Bar.Value = (Application.OpenForms["Headband"] as Headband).Meditation));

            if (closeAllThread)
            {
                Thread.CurrentThread.Abort();
            }
        }

        /// <summary>
        /// Отрисовка графиков
        /// </summary>
        private void plotWaves()
        {
            DeltaDebug_Label.Invoke((MethodInvoker)(() => DeltaDebug_Label.Text = "Delta: " + (Application.OpenForms["Headband"] as Headband).Delta));
            DeltaDebug_Chart.Invoke((MethodInvoker)(() => DeltaDebug_Chart.Series["Delta"].Points.AddY((Application.OpenForms["Headband"] as Headband).Delta)));

            if (DeltaDebug_Chart.Series["Delta"].Points.Count > 20)
            {
                DeltaDebug_Chart.Invoke((MethodInvoker)(() => DeltaDebug_Chart.Series["Delta"].Points.RemoveAt(0)));

            }
            DeltaDebug_Chart.Invoke((MethodInvoker)(() => DeltaDebug_Chart.ChartAreas[0].AxisY.Maximum = 1000000));


            ThetaDebug_Label.Invoke((MethodInvoker)(() => ThetaDebug_Label.Text = "Theta: " + (Application.OpenForms["Headband"] as Headband).Theta));
            ThetaDebug_Chart.Invoke((MethodInvoker)(() => ThetaDebug_Chart.Series["Theta"].Points.AddY((Application.OpenForms["Headband"] as Headband).Theta)));

            if (ThetaDebug_Chart.Series["Theta"].Points.Count > 20)
            {
                ThetaDebug_Chart.Invoke((MethodInvoker)(() => ThetaDebug_Chart.Series["Theta"].Points.RemoveAt(0)));
            }
            ThetaDebug_Chart.Invoke((MethodInvoker)(() => ThetaDebug_Chart.ChartAreas[0].AxisY.Maximum = 400000));


            LowAlphaDebug_Label.Invoke((MethodInvoker)(() => LowAlphaDebug_Label.Text = "Low Alpha: " + (Application.OpenForms["Headband"] as Headband).LowAlpha));
            AlphaDebug_Chart.Invoke((MethodInvoker)(() => AlphaDebug_Chart.Series["Low Alpha"].Points.AddY((Application.OpenForms["Headband"] as Headband).LowAlpha)));

            if (AlphaDebug_Chart.Series["Low Alpha"].Points.Count > 20)
            {
                AlphaDebug_Chart.Invoke((MethodInvoker)(() => AlphaDebug_Chart.Series["Low Alpha"].Points.RemoveAt(0)));
            }
            AlphaDebug_Chart.Invoke((MethodInvoker)(() => AlphaDebug_Chart.ChartAreas[0].AxisY.Maximum = 100000));


            HighAlphaDebug_Label.Invoke((MethodInvoker)(() => HighAlphaDebug_Label.Text = "High Alpha: " + (Application.OpenForms["Headband"] as Headband).HighAlpha));
            AlphaDebug_Chart.Invoke((MethodInvoker)(() => AlphaDebug_Chart.Series["High Alpha"].Points.AddY((Application.OpenForms["Headband"] as Headband).HighAlpha)));

            if (AlphaDebug_Chart.Series["High Alpha"].Points.Count > 20)
            {
                AlphaDebug_Chart.Invoke((MethodInvoker)(() => AlphaDebug_Chart.Series["High Alpha"].Points.RemoveAt(0)));
            }


            LowBetaDebug_Label.Invoke((MethodInvoker)(() => LowBetaDebug_Label.Text = "Low Beta: " + (Application.OpenForms["Headband"] as Headband).LowBeta));
            BetaDebug_Chart.Invoke((MethodInvoker)(() => BetaDebug_Chart.Series["Low Beta"].Points.AddY((Application.OpenForms["Headband"] as Headband).LowBeta)));

            if (BetaDebug_Chart.Series["Low Beta"].Points.Count > 20)
            {
                BetaDebug_Chart.Invoke((MethodInvoker)(() => BetaDebug_Chart.Series["Low Beta"].Points.RemoveAt(0)));
            }

            BetaDebug_Chart.Invoke((MethodInvoker)(() => BetaDebug_Chart.ChartAreas[0].AxisY.Maximum = 50000));
            BetaDebug_Chart.Invoke((MethodInvoker)(() => BetaDebug_Chart.ChartAreas[0].AxisY.Minimum = 5));


            HighBetaDebug_Label.Invoke((MethodInvoker)(() => HighBetaDebug_Label.Text = "High Beta: " + (Application.OpenForms["Headband"] as Headband).HighBeta));
            BetaDebug_Chart.Invoke((MethodInvoker)(() => BetaDebug_Chart.Series["High Beta"].Points.AddY((Application.OpenForms["Headband"] as Headband).HighBeta)));

            if (BetaDebug_Chart.Series["High Beta"].Points.Count > 20)
            {
                BetaDebug_Chart.Invoke((MethodInvoker)(() => BetaDebug_Chart.Series["High Beta"].Points.RemoveAt(0)));
            }


            LowGammaDebug_Label.Invoke((MethodInvoker)(() => LowGammaDebug_Label.Text = "Low Gamma: " + (Application.OpenForms["Headband"] as Headband).LowGamma));
            GammaDebug_Chart.Invoke((MethodInvoker)(() => GammaDebug_Chart.Series["Low Gamma"].Points.AddY((Application.OpenForms["Headband"] as Headband).LowGamma)));

            if (GammaDebug_Chart.Series["Low Gamma"].Points.Count > 20)
            {
                GammaDebug_Chart.Invoke((MethodInvoker)(() => GammaDebug_Chart.Series["Low Gamma"].Points.RemoveAt(0)));
            }
            GammaDebug_Chart.Invoke((MethodInvoker)(() => GammaDebug_Chart.ChartAreas[0].AxisY.Maximum = 20000));


            HighGammaDebug_Label.Invoke((MethodInvoker)(() => HighGammaDebug_Label.Text = "High Gamma: " + (Application.OpenForms["Headband"] as Headband).HighGamma));
            GammaDebug_Chart.Invoke((MethodInvoker)(() => GammaDebug_Chart.Series["High Gamma"].Points.AddY((Application.OpenForms["Headband"] as Headband).HighGamma)));

            if (GammaDebug_Chart.Series["High Gamma"].Points.Count > 20)
            {
                GammaDebug_Chart.Invoke((MethodInvoker)(() => GammaDebug_Chart.Series["High Gamma"].Points.RemoveAt(0)));
            }


            RawDebug_Label.Invoke((MethodInvoker)(() => RawDebug_Label.Text = "Raw: " + (Application.OpenForms["Headband"] as Headband).Raw));
            RawDebug_Chart.Invoke((MethodInvoker)(() => RawDebug_Chart.ChartAreas[0].AxisY.Minimum = -400));
            RawDebug_Chart.Invoke((MethodInvoker)(() => RawDebug_Chart.ChartAreas[0].AxisY.Maximum = 400));
            RawDebug_Chart.Invoke((MethodInvoker)(() => RawDebug_Chart.Series["EEG"].Points.AddY((Application.OpenForms["Headband"] as Headband).Raw)));

            if (RawDebug_Chart.Series["EEG"].Points.Count > 200)
            {
                RawDebug_Chart.Invoke((MethodInvoker)(() => RawDebug_Chart.Series["EEG"].Points.RemoveAt(0)));
            }
        

            if (closeAllThread)
            {
                Thread.CurrentThread.Abort();
            }
}
    }
}
