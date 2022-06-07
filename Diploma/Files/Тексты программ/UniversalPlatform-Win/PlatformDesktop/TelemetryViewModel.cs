using LiveCharts;
using PlatformDesktop.Options;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PlatformDesktop
{
    class TelemetryViewModel : INotifyPropertyChanged
    {

        public TelemetryViewModel()
        {

        }

        private SeriesCollection _series = new();
        private SeriesCollection _seriesA = new();
        private SeriesCollection _seriesM = new();
        private SeriesCollection _seriesCurr = new();
        private SeriesCollection _seriesV = new();
        // гироскоп
        public void AddValueSeries(SeriesType st, double value)
        {
            if (!OnTelemetry) return;
            if (st == SeriesType.x && !OnX)
            {
                if (_series.ElementAt(0).Values.Count > 0)
                {
                    Series.ElementAt(0).Values.Clear();
                }
                return;
            }
            else if (st == SeriesType.y && !OnY)
            {
                if (_series.ElementAt(1).Values.Count > 0)
                {
                    Series.ElementAt(1).Values.Clear();
                }
                return;
            }
            else if (st == SeriesType.z && !OnZ)
            {
                if (_series.ElementAt(2).Values.Count > 0)
                {
                    Series.ElementAt(2).Values.Clear();
                }
                return;
            }


            var valueSeries = st switch
            {
                SeriesType.x => Series.ElementAt(0),
                SeriesType.y => Series.ElementAt(1),
                SeriesType.z => Series.ElementAt(2),
                _ => null
            };

            if (valueSeries.Values.Count > 21)
                valueSeries.Values.RemoveAt(0);
            if (valueSeries is null) return;
            valueSeries.Values.Add(value);


        }
        // Аксиомтер
        public void AddValueSeriesA(SeriesType stA, double value)
        {
            if (!OnTelemetry) return;
            if (stA == SeriesType.xA && !OnXa)
            {
                if (_seriesA.ElementAt(0).Values.Count > 0)
                {
                    SeriesA.ElementAt(0).Values.Clear();
                }
                return;
            }
            else if (stA == SeriesType.yA && !OnYa)
            {
                if (_seriesA.ElementAt(1).Values.Count > 0)
                {
                    SeriesA.ElementAt(1).Values.Clear();
                }
                return;
            }
            else if (stA == SeriesType.zA && !OnZa)
            {
                if (_seriesA.ElementAt(2).Values.Count > 0)
                {
                    SeriesA.ElementAt(2).Values.Clear();
                }
                return;
            }
            var valueSeriesA = stA switch
            {
                SeriesType.xA => SeriesA.ElementAt(0),
                SeriesType.yA => SeriesA.ElementAt(1),
                SeriesType.zA => SeriesA.ElementAt(2),
                _ => null
            };

            if (valueSeriesA.Values.Count > TelemetrySetting.Default.SIze + 1)
                valueSeriesA.Values.RemoveAt(0);
            if (valueSeriesA is null) return;
            valueSeriesA.Values.Add(value);
        }
        //
        public void AddValueSeriesM(SeriesType stM, double value)
        {
            if (!OnTelemetry) return;
            if (stM == SeriesType.xM && !OnXm)
            {
                if (_seriesM.ElementAt(0).Values.Count > 0)
                {
                    SeriesM.ElementAt(0).Values.Clear();
                }
                return;
            }
            else if (stM == SeriesType.yM && !OnYm)
            {
                if (_seriesM.ElementAt(1).Values.Count > 0)
                {
                    SeriesM.ElementAt(1).Values.Clear();
                }
                return;
            }
            else if (stM == SeriesType.zM && !OnZm)
            {
                if (_seriesM.ElementAt(2).Values.Count > 0)
                {
                    SeriesM.ElementAt(2).Values.Clear();
                }
                return;
            }
            var valueSeriesM = stM switch
            {
                SeriesType.xM => SeriesM.ElementAt(0),
                SeriesType.yM => SeriesM.ElementAt(1),
                SeriesType.zM => SeriesM.ElementAt(2),
                _ => null
            };
            if (valueSeriesM.Values.Count > TelemetrySetting.Default.SIze + 1)
                valueSeriesM.Values.RemoveAt(0);
            if (valueSeriesM is null) return;
            valueSeriesM.Values.Add(value);
        }
        // Ток
        public void AddValueSeriesCurr(SeriesType stCurr, double value)
        {
            if (!OnTelemetry) return;
            if (stCurr == SeriesType.lcurr && !OnLcurr)
            {
                if (_seriesCurr.ElementAt(0).Values.Count > 0)
                {
                    SeriesCurr.ElementAt(0).Values.Clear();
                }
                return;
            }
            else if (stCurr == SeriesType.rcurr && !OnRcurr)
            {
                if (_seriesCurr.ElementAt(1).Values.Count > 0)
                {
                    SeriesCurr.ElementAt(1).Values.Clear();
                }
                return;
            }
           
            var valueSeriesCurr = stCurr switch
            {
                SeriesType.lcurr => SeriesCurr.ElementAt(0),
                SeriesType.rcurr => SeriesCurr.ElementAt(1),
                _ => null
            };
            if (valueSeriesCurr.Values.Count > TelemetrySetting.Default.SIze + 1)
                valueSeriesCurr.Values.RemoveAt(0);
            if (valueSeriesCurr is null) return;
            valueSeriesCurr.Values.Add(value);
        }
        //
        // Vatt
        public void AddValueSeriesV(SeriesType stV, double value)
        {
            if (!OnTelemetry) return;
            if (stV == SeriesType.vbat && !OnV)
            {
                if (_seriesV.ElementAt(0).Values.Count > 0)
                {
                    SeriesV.ElementAt(0).Values.Clear();
                }
                return;
            }
            

            var valueSeriesV = stV switch
            {
                SeriesType.vbat => SeriesV.ElementAt(0),
                //SeriesType.yA => SeriesA.ElementAt(),
                //SeriesType.zA => SeriesA.ElementAt(2),
                _ => null
            };

            if (valueSeriesV.Values.Count > TelemetrySetting.Default.SiveV)
                valueSeriesV.Values.RemoveAt(0);
            if (valueSeriesV is null) return;
            valueSeriesV.Values.Add(value);
        }
        //
        public SeriesCollection Series
        {
            get => _series;
            set
            {
                _series = value;
                OnPropertyChanged();
            }
        }

        public string[] BarLabels
        {
            get => _barLabels;
            set
            {
                _barLabels = value;
                OnPropertyChanged();
            }
        }

        private string[] _barLabels;

        private bool _onTelemetry = true;

        public bool OnTelemetry
        {
            get => _onTelemetry;
            set
            {
                _onTelemetry = value;
                OnPropertyChanged();
            }
        }
        // 
        private bool _onX = true;

        public bool OnX
        {
            get => _onX;
            set
            {
                _onX = value;
                OnPropertyChanged();
            }
        }
        private bool _onY = true;

        public bool OnY
        {
            get => _onY;
            set
            {
                _onY = value;
                OnPropertyChanged();
            }
        }
        private bool _onZ = true;

        public bool OnZ
        {
            get => _onZ;
            set
            {
                _onZ = value;
                OnPropertyChanged();
            }
        }

        // Аксиометр
        public SeriesCollection SeriesA
        {
            get => _seriesA;
            set
            {
                _series = value;
                OnPropertyChanged();
            }
        }

        public string[] BarLabelsa
        {
            get => _barLabelsa;
            set
            {
                _barLabelsa = value;
                OnPropertyChanged();
            }
        }

        private string[] _barLabelsa;

        private bool _onTelemetryA = true;

        public bool OnTelemetryA
        {
            get => _onTelemetryA;
            set
            {
                _onTelemetryA = value;
                OnPropertyChanged();
            }
        }
        private bool _onXa = true;

        public bool OnXa
        {
            get => _onXa;
            set
            {
                _onXa = value;
                OnPropertyChanged();
            }
        }
        private bool _onYa = true;

        public bool OnYa
        {
            get => _onYa;
            set
            {
                _onYa = value;
                OnPropertyChanged();
            }
        }
        private bool _onZa = true;

        public bool OnZa
        {
            get => _onZa;
            set
            {
                _onZa = value;
                OnPropertyChanged();
            }
        }
        // Магнитометр
        private bool _onXm = true;

        public bool OnXm
        {
            get => _onXm;
            set
            {
                _onXm = value;
                OnPropertyChanged();
            }
        }
        private bool _onYm = true;

        public bool OnYm
        {
            get => _onYm;
            set
            {
                _onYm = value;
                OnPropertyChanged();
            }
        }
        private bool _onZm = true;

        public bool OnZm
        {
            get => _onZm;
            set
            {
                _onZm = value;
                OnPropertyChanged();
            }
        }

        public SeriesCollection SeriesM
        {
            get => _seriesM;
            set
            {
                _seriesM = value;
                OnPropertyChanged();
            }
        }

        public string[] BarLabelsm
        {
            get => _barLabelsm;
            set
            {
                _barLabelsm = value;
                OnPropertyChanged();
            }
        }

        private string[] _barLabelsm;

        private bool _onTelemetryM = true;

        public bool OnTelemetryM
        {
            get => _onTelemetryM;
            set
            {
                _onTelemetryM = value;
                OnPropertyChanged();
            }
        }
        // Ток
        public SeriesCollection SeriesCurr
        {
            get => _seriesCurr;
            set
            {
                _seriesCurr = value;
                OnPropertyChanged();
            }
        }

        public string[] BarLabelscurr
        {
            get => _barLabelscurr;
            set
            {
                _barLabelscurr = value;
                OnPropertyChanged();
            }
        }

        private string[] _barLabelscurr;

        private bool _onTelemetryCurr = true;

        public bool OnTelemetryCurr
        {
            get => _onTelemetryCurr;
            set
            {
                _onTelemetryCurr = value;
                OnPropertyChanged();
            }
        }
        private bool _onLcurr = true;

        public bool OnLcurr
        {
            get => _onLcurr;
            set
            {
                _onLcurr = value;
                OnPropertyChanged();
            }
        }
        private bool _onRcurr = true;

        public bool OnRcurr
        {
            get => _onRcurr;
            set
            {
                _onRcurr = value;
                OnPropertyChanged();
            }
        }

        // Volt
        public SeriesCollection SeriesV
        {
            get => _seriesV;
            set
            {
                _seriesV = value;
                OnPropertyChanged();
            }
        }

        public string[] BarLabelsv
        {
            get => _barLabelsv;
            set
            {
                _barLabelsv = value;
                OnPropertyChanged();
            }
        }

        private string[] _barLabelsv;

        private bool _onTelemetryv = true;

        public bool OnTelemetryV
        {
            get => _onTelemetryv;
            set
            {
                _onTelemetryv = value;
                OnPropertyChanged();
            }
        }
        private bool _onV = true;

        public bool OnV
        {
            get => _onV;
            set
            {
                _onV = value;
                OnPropertyChanged();
            }
        }
       //







        public Func<double, string> Formatter { get; set; }
        public Func<double, string> FormatterX { get; set; } = value => DateTime.Now.ToString("HH:mm:ss.fff");

        public event PropertyChangedEventHandler PropertyChanged;
        public Func<double, string> FormatterA { get; set; }
        public Func<double, string> FormatterXA { get; set; } = value => DateTime.Now.ToString("HH:mm:ss.fff");
        public Func<double, string> FormatterM { get; set; }
        public Func<double, string> FormatterXM { get; set; } = value => DateTime.Now.ToString("HH:mm:ss.fff");

        public Func<double, string> FormatterCurr { get; set; }
        public Func<double, string> FormatterCurrX { get; set; } = value => DateTime.Now.ToString("HH:mm:ss.fff");
        public Func<double, string> FormatterV { get; set; }
        public Func<double, string> FormatterXV { get; set; } = value => DateTime.Now.ToString("HH:mm:ss.fff");



        public void OnPropertyChanged([CallerMemberName] string propName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


    }
    public enum SeriesType
    {
        x, y, z, xA, yA, zA, xM, yM, zM, lcurr, rcurr, vbat
    }

}
