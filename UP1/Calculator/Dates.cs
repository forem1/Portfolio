using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Dates : Form
    {
        public Dates()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime First = dateTimePicker1.Value;
            DateTime Second = dateTimePicker2.Value;
            TimeSpan div = (Second - First).Duration();
            label1.Text = ToDateDiff(div.Days);
        }

        private string ToDateDiff(int Day)
        {
            int year = Day / 365;
            int month = (Day % 365) / 30;
            int day = Day % 30;

            string YearRes;
            if (year > 19) { year = year % 10; }
            switch (year)
            {
                case 1: YearRes = "год"; break;
                case 4: YearRes = "года"; break;
                case 0: YearRes = "лет"; break;
                default: YearRes = "ошибка"; break;
            }
            string nYear = YearRes;

            string MonthRes;
            if (month > 19) { month = month % 10; }
            switch (month)
            {
                case 1: MonthRes = "месяц"; break;
                case 4: MonthRes = "месяца"; break;
                case 0: MonthRes = "месяцев"; break;
                default: MonthRes = "ошибка"; break;
            }
            string nMonth = MonthRes;

            string DayRes;
            if (day > 19) { day = day % 10; }
            switch (day)
            {
                case 1: DayRes = "день"; break;
                case 4: DayRes = "дня"; break;
                case 0: DayRes = "дней"; break;
                default: DayRes = "ошибка"; break;
            }
            string nDay = DayRes;

            if(year == 0 && month == 0 && day == 0) return string.Format("Одинаковые даты");
            else return string.Format($"{year} {nYear} {month} {nMonth} {day} {nDay}");
        }
    }
}
