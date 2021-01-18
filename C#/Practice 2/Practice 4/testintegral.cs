using System;

namespace Patsev.Integrals

{

    public abstract class Integral //базовый класс

    {

        public Integral(double a, double b, int n)

        {

            this.a = a; this.b = b; this.n = n;

            //вычисление интеграла

            Solve();

            //вычисление погрешности

            accuracy = Math.Abs(Exact_value(a, b) - square);

        }

        public static double F(double x) //возвращает значение подинтегральной функции

        {

            return 1 / Math.Sqrt(1 + x * x);

        }

        protected static double Exact_value(double a, double b) //точное значение определенного интеграла

        {

            return Math.Log(Math.Abs(b + Math.Sqrt(1 + b * b))) -

            Math.Log(Math.Abs(a + Math.Sqrt(1 + a * a)));

        }

        abstract protected void Solve(); //{ } //метод, содержащий алгоритм вычислений

        public double Square //значение интеграла

        {

            get

            {

                return square;

            }

        }

        public double Accuracy //погрешность вычислений

        {

            get

            {

                return accuracy;

            }

        }

        public static volatile bool Killed; //Позволяет остановить цикл вычислений

        public static bool operator <(Integral x1, Integral x2)

        {

            if (x1.accuracy < x2.accuracy) return true;

            return false;

        }

        public static bool operator >(Integral x1, Integral x2)

        {

            if (x1.accuracy > x2.accuracy) return true;

            return false;

        }

        public override string ToString()

        {

            //return base.ToString();

            string s;

            if (Killed) return "";

            s = Square.ToString() + " / " + Accuracy.ToString();

            return s;

        }

        protected double square, accuracy, a, b;

        protected int n;

    }

    public sealed class Rectangles : Integral //метод прямоугольников

    {

        public Rectangles(double a, double b, int n) : base(a, b, n) { }

        override protected void Solve()

        {

            double yn = 0, y0, x0 = a, Delta = (b - a) / n;

            for (int i = 0; i < n; i++, yn += y0, x0 += Delta)

            {

                if (Killed) { square = -1; return; }

                y0 = F((2 * x0 + Delta) / 2);

            }

            square = yn * Delta;

        }

    }

    public sealed class Trapezoids : Integral //метод трапеций

    {

        public Trapezoids(double a, double b, int n) : base(a, b, n) { }

        override protected void Solve()

        {

            double yn = 0, y0, Delta = (b - a) / n, x0 = a + Delta;

            for (int i = 1; i < n; i++, yn += y0, x0 += Delta)

            {

                if (Killed) { square = -1; return; }

                y0 = F(x0);

            }

            square = Delta * ((F(a) + F(b)) / 2 + yn);

        }

    }

    public sealed class Simpsons : Integral //метод парабол

    {

        public Simpsons(double a, double b, int n) : base(a, b, n) { }

        override protected void Solve()

        {

            double yn1 = 0, yn2 = 0, y0, Delta = (b - a) / n, x0 = a + Delta;

            for (int i = 1; i < n; i += 2, yn1 += y0, x0 += 2 * Delta)

            {

                if (Killed == true) { square = -1; return; }

                y0 = F(x0);

            }

            x0 = a + 2 * Delta;

            for (int i = 2; i < n - 1; i += 2, yn2 += y0, x0 += 2 * Delta)

            {

                if (Killed == true) { square = -1; return; }

                y0 = F(x0);

            }

            square = (b - a) / 3 / n * (F(a) + F(b) + 4 * yn1 + 2 * yn2);

        }

    }

}

5.2Листинг файла «MainForm.cs»
using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Drawing;

using System.Text;

using System.Windows.Forms;

using System.Threading;

using Курсовая_работа_по_ООП;

using ZedGraph;

using Patsev.Integrals;

namespace Курсовая_работа_по_ООП

{

    public partial class MainForm : Form

    {

        public int PointsQuantity { get; set; }

        public int PointsSize { get; set; }

        public Single LineWidth { get; set; }

        double x1 { get; set; }

        double x2 { get; set; }

        int n { get; set; }

        string strMethodRectangles, strTrapezoids, strSimpsons; //Строки для хранения результатов

        string strCalcStatus; //информационная строка

        public MainForm()

        {

            InitializeComponent();

        }

        private void DisambleButtons()

        {

            StartBtn.Enabled = false;

            SettingsBtn.Enabled = false;

            txtBoxX1.Enabled = false;

            txtBoxX2.Enabled = false;

            txtBoxN.Enabled = false;

            strMethodRectangles = "";

            strTrapezoids = "";

            strSimpsons = "";

            strCalcStatus = "Вычисление...\nНажмите 'x'\n для отмены.";

            DrawGraph();

        }

        private void EnableButtons(object sender, RunWorkerCompletedEventArgs e)

        {

            StartBtn.Enabled = true;

            SettingsBtn.Enabled = true;

            txtBoxX1.Enabled = true;

            txtBoxX2.Enabled = true;

            txtBoxN.Enabled = true;

            strCalcStatus = "";

            DrawGraph();

        }

        private void Integration(object sender, DoWorkEventArgs e)

        {

            Integral myIntegral;

            Patsev.Integrals.Integral.Killed = false;

            myIntegral = new Patsev.Integrals.Rectangles(x1, x2, n);

            strMethodRectangles = myIntegral.ToString();

            myIntegral = new Patsev.Integrals.Trapezoids(x1, x2, n);

            strTrapezoids = myIntegral.ToString();

            myIntegral = new Patsev.Integrals.Simpsons(x1, x2, n);

            strSimpsons = myIntegral.ToString();

        }//интегрирование

        private void DrawGraph() //вывод графика функции

        {

            // Получим панель для рисования

            GraphPane pane = zedGraph.GraphPane;

            // Очистим список текстов и кривых на тот случай, если до этого сигналы уже были нарисованы

            pane.CurveList.Clear();

            pane.GraphObjList.Clear();

            // Печать заголовка

            TextObj headline = new TextObj("Значение интеграла / Погрешность", 0.27F, 0.04F);

            headline.FontSpec.FontColor = Color.DarkBlue;

            headline.FontSpec.IsBold = true;

            headline.FontSpec.Size = 8;

            headline.FontSpec.IsAntiAlias = true;

            // Disable the border and background fill options for the text

            headline.FontSpec.Border.IsVisible = false;

            headline.FontSpec.Fill.IsVisible = false;

            headline.FontSpec.IsUnderline = true;

            // Align the text such the the Left-Bottom corner is at the specified coordinates

            // use AxisFraction coordinates so the text is placed relative to the ChartRect

            headline.Location.CoordinateFrame = CoordType.ChartFraction;

            headline.Location.AlignH = AlignH.Left;

            headline.Location.AlignV = AlignV.Bottom;

            pane.GraphObjList.Add(headline);

            //Печать подписей к результатам

            string textline = "Метод прямоугольников: \nМетод трапеций: \nМетод парабол:";

            TextObj textresults = new TextObj(textline, 0.04F, 0.15F);

            textresults.Location.CoordinateFrame = CoordType.ChartFraction;

            textresults.FontSpec.Border.IsVisible = false;

            textresults.FontSpec.Fill.IsVisible = false;

            textresults.FontSpec.IsAntiAlias = true;

            textresults.FontSpec.Size = 8;

            textresults.Location.AlignH = AlignH.Left;

            textresults.Location.AlignV = AlignV.Bottom;

            textresults.FontSpec.StringAlignment = StringAlignment.Near;

            pane.GraphObjList.Add(textresults);

            //Печать результатов

            string strresults = strMethodRectangles + "\n" + strTrapezoids + "\n" + strSimpsons;

            TextObj results = new TextObj(strresults, 0.27F, 0.15F);

            results.Location.CoordinateFrame = CoordType.ChartFraction;

            results.FontSpec.FontColor = Color.DarkGreen;

            results.FontSpec.Border.IsVisible = false;

            results.FontSpec.Fill.IsVisible = false;

            results.FontSpec.IsAntiAlias = true;

            results.FontSpec.Size = 8;

            results.Location.AlignH = AlignH.Left;

            results.Location.AlignV = AlignV.Bottom;

            results.FontSpec.StringAlignment = StringAlignment.Near;

            pane.GraphObjList.Add(results);

            //Печать надписи "Вычисление..."

            TextObj txtCalc = new TextObj(strCalcStatus, 0.8F, 0.05F);

            // use AxisFraction coordinates so the text is placed relative to the ChartRect

            txtCalc.Location.CoordinateFrame = CoordType.ChartFraction;

            // rotate the text 15 degrees

            txtCalc.FontSpec.Angle = -45.0F;

            // Text will be red, bold, and 16 point

            txtCalc.FontSpec.FontColor = Color.Red;

            txtCalc.FontSpec.IsBold = true;

            txtCalc.FontSpec.Size = 16;

            // Disable the border and background fill options for the text

            txtCalc.FontSpec.Border.IsVisible = false;

            txtCalc.FontSpec.Fill.IsVisible = false;

            // Align the text such the the Left-Bottom corner is at the specified coordinates

            txtCalc.Location.AlignH = AlignH.Left;

            txtCalc.Location.AlignV = AlignV.Bottom;

            pane.GraphObjList.Add(txtCalc);

            //Вывод графика:

            // Создадим список точек

            PointPairList list = new PointPairList();

            PointPairList plist = new PointPairList();

            double xmin = x1;

            double xmax = x2;

            // Заполняем список точек

            plist.Add(xmin, Integral.F(xmin));

            double xp = Math.Max(Math.Abs(xmin), Math.Abs(xmax));

            double dx = 2 * xp * 1.2 / this.PointsQuantity;

            for (double x = -xp * 1.2; x <= xp * 1.2; x += dx)

            {

                // добавим в список точку

                list.Add(x, Integral.F(x));

                if (x >= xmin && x <= xmax)

                    plist.Add(x, Integral.F(x));

            }

            plist.Add(xmax, Integral.F(xmax));

            // Set the titles and axis labels

            pane.Title.Text = "Интегрируемая функция f(x) = Sqrt(1 + x^2)";

            pane.XAxis.Title.Text = "X";

            pane.YAxis.Title.Text = "Y";

            // Hide the legend

            pane.Legend.IsVisible = false;

            // Add a curve

            LineItem curve = pane.AddCurve("label", list, Color.Red, SymbolType.Circle);

            curve.Line.IsSmooth = true;

            curve.Line.Width = this.LineWidth;

            curve.Symbol.Fill = new Fill(Color.White);

            curve.Symbol.Size = this.PointsSize;

            // Fill the area under the curves

            LineItem pcurve = pane.AddCurve("", plist, Color.Blue, SymbolType.None);

            pcurve.Line.IsSmooth = true;

            pcurve.Line.Fill = new Fill(Color.White, Color.Blue, 95.0F);

            // Fill the axis background with a gradient

            pane.Chart.Fill = new Fill(Color.White, Color.SteelBlue, 90.0F);

            // Включим отображение сетки

            pane.XAxis.MajorGrid.IsVisible = true;

            pane.YAxis.MajorGrid.IsVisible = true;

            /* Вызываем метод AxisChange (), чтобы обновить данные об осях.

            В противном случае на рисунке будет показана только часть графика, которая умещается в интервалы по осям, установленные по умолчанию*/

            zedGraph.AxisChange();

            // Обновляем график

            zedGraph.Invalidate();

        }//прорисовка графика

        private void ExitBtn_Click(object sender, EventArgs e)

        {

            Close();

        }

        private void AboutBtn_Click(object sender, EventArgs e)

        {

            AboutBox frmAbout = new AboutBox();

            frmAbout.ShowDialog();

        }

        private void StartBtn_Click(object sender, EventArgs e)//запуск потоков вычислений

        {

            //проверка корректности вводимых значений

            try

            {

                try

                {

                    x1 = Convert.ToDouble(txtBoxX1.Text);

                }

                catch

                {

                    txtBoxX1.Focus();

                    txtBoxX1.SelectAll();

                    throw new Exception("Ошибка при вводе x1");

                }

                try

                {

                    x2 = Convert.ToDouble(txtBoxX2.Text);

                }

                catch

                {

                    txtBoxX2.Focus();

                    txtBoxX2.SelectAll();

                    throw new Exception("Ошибка при вводе x2");

                }

                try

                {

                    n = Convert.ToInt32(txtBoxN.Text);

                }

                catch

                {

                    txtBoxN.Focus();

                    txtBoxN.SelectAll();

                    throw new Exception("Ошибка при вводе n");

                }

                DisambleButtons();

                BackgroundWorker bw = new BackgroundWorker();

                bw.WorkerSupportsCancellation = true;

                bw.DoWork += Integration;

                bw.RunWorkerCompleted += EnableButtons;

                bw.RunWorkerAsync(null);

            }

            catch (Exception myexcepton)

            {

                MessageBox.Show(myexcepton.Message, "Ошибка ввода данных.");

            }

        }

        private void zedGraph_DoubleClick(object sender, EventArgs e)

        {

            zedGraph.GraphPane.CurveList.Clear();

            zedGraph.GraphPane.GraphObjList.Clear();

            zedGraph.Invalidate();

        }

        private void MainForm_Shown(object sender, EventArgs e)

        {

            x1 = Convert.ToDouble(txtBoxX1.Text);

            x2 = Convert.ToDouble(txtBoxX2.Text);

            n = Convert.ToInt32(txtBoxN.Text);

            DrawGraph();

        }

        private void SettingsBtn_Click(object sender, EventArgs e) //изменение настроек графика

        {

            SettingsForm SettingsFrm = new SettingsForm();

            SettingsFrm.txtPointsQuantity = this.PointsQuantity.ToString();

            SettingsFrm.txtPointsSize = this.PointsSize.ToString();

            SettingsFrm.txtLineWidth = this.LineWidth.ToString();

            if (SettingsFrm.ShowDialog() == DialogResult.OK)

            {

                try

                {

                    try

                    {

                        this.PointsQuantity = Convert.ToInt32(SettingsFrm.txtPointsQuantity);

                    }

                    catch

                    {

                        throw new Exception("Ошибка при вводе количества точек на графике");

                    }

                    try

                    {

                        this.PointsSize = Convert.ToInt32(SettingsFrm.txtPointsSize);

                    }

                    catch

                    {

                        throw new Exception("Ошибка при вводе размера точек");

                    }

                    try

                    {

                        this.LineWidth = Convert.ToSingle(SettingsFrm.txtLineWidth);

                    }

                    catch

                    {

                        throw new Exception("Ошибка при вводе толщины линии");

                    }

                    DrawGraph();

                }

                catch (Exception myexcepton)

                {

                    MessageBox.Show(myexcepton.Message + "\nОшибочные изменения не будут произведены."

                    , "Ошибка ввода данных.");

                }

            }

        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)

        {

            if (e.KeyChar == 120 || e.KeyChar == 1095) //отмена вычислений при нажатии 'x'

            {

                Patsev.Integrals.Integral.Killed = true;

                strMethodRectangles = "";

                strTrapezoids = "";

                strSimpsons = "";

            }

        }

    }

}