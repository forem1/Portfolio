using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlatformDesktop
{
    public class StuctureDataClass
    {

        public StuctureDataClass()
        {
        }


        public StuctureDataClass(char move, int speed, char value, double lcurr, double rcurr, double accx, double accy, double accz, double gyrox, double gyroy, double gyroz, double magx, double magy, double magz, string lan, string lon, double vbat,int systemStatus,int extid, int extstatus)
        {
            Move = move;
            Speed = speed;
            Value = value;
            Lcurr = lcurr;
            Rcurr = rcurr;
            Accx = accx;
            Accy = accy;
            Accz = accz;
            this.gyrox = gyrox;
            this.gyroy = gyroy;
            this.gyroz = gyroz;
            Magx = magx;
            Magy = magy;
            Magz = magz;
            Lan = lan;
            Lon = lon;
            Vbat = vbat;
            SystemStatus = systemStatus;
            Extid = extid;
            Extstatus = extstatus;

        }

        public char Move { get; set; }
        public int Speed { get; set; }
        public char Value { get; set; }
        public double Lcurr { get; set; }
        public double Rcurr { get; set; }
        public double Accx { get; set; }
        public double Accy { get; set; }
        public double Accz { get; set; }
        public double gyrox { get; set; }
        public double gyroy { get; set; }
        public double gyroz { get; set; }
        public double Magx { get; set; }
        public double Magy { get; set; }
        public double Magz { get; set; }
        public string Lan { get; set; }
        public string Lon { get; set; }
        public double Vbat { get; set; }
        public int SystemStatus { get; set; }
        public int Extid { get; set; }
        public int Extstatus { get; set; }

        ///     Pattern для id платформы

        private static readonly string _extIdPattern = @"\w+";

        ///     Pattern для статуса платформы

        private static readonly string _extStatusPattern = @"[01]";

        ///     Pattern для чисел с плавающей запятой

        private static string _doublePattern => @"[+-]?([0-9]*[.])?[0-9]+";

        ///     Pattern значений движения

        private static string _movePattern => @"[fblracdes]";

        ///     Pattern значений типа движения        
        private static string _valuePattern => @"[fs]";


        /// Pattern значений статуса системы

        private static string _systemStatusPattern => @"[0-6]";

        public static bool CheckLine(string structLine)
        {
            // Проверка на пустую строку
            if (structLine == null) throw new ArgumentNullException(nameof(structLine));

            // Добавить вместо ";" (кавычки тоже убрать), когда будут приходить последние 3 значения
            //"[,]" + _systemStatusPattern + "[,]" + _extIdPattern + "[,]" + _extStatusPattern + ";"


            // Pattern (шаблон)
            var pattern = @"[&][:]" + _movePattern + "[,](100|[0-9]|[1-9][0-9])[,]" + _valuePattern + "[,](" +
                          _doublePattern +
                          "[,]){14}" + _extStatusPattern + ";";
            return new Regex(pattern).IsMatch(structLine);
        }
        public static IEnumerable<string> GetValues(string structLine)
        {
            // Проверка на пустую строку
            if (structLine == null) throw new ArgumentNullException(nameof(structLine));
            // Проверка на правильность строки
            if (!CheckLine(structLine)) throw new InvalidDataException(nameof(structLine));

            // Добавить вместо ";" (кавычки тоже убрать), когда будут приходить последние 3 значения
            //")[,](" + _systemStatusPattern + ")[,](" + _extIdPattern + ")[,](" + _extStatusPattern + ");"

            // Pattern (шаблон)
            var pattern = @"[&][:](" + _movePattern + ")[,](100|[0-9]|[1-9][0-9])[,](" + _valuePattern + ")[,]((" +
                          _doublePattern +
                          ")[,]){14}(" + _extStatusPattern + ");";

            foreach (Match group in new Regex(pattern).Matches(structLine))
                foreach (var math in group.Groups.SkipByIndex<Group>(4, 6))
                    if (math.Captures.Any())
                    {
                        if (math.Index == 0) continue;
                        foreach (var capture in math.Captures.Select(x => x.Value))
                            yield return capture;
                    }
                    else
                    {
                        yield return group.Value;
                    }
        }
      

    }
    public static class Helper
    {
        public static IEnumerable<T> SkipByIndex<T>(this IEnumerable<T> list, params int[] indexes)
        {
            // Проверка на не пустой список значений
            if (list == null) throw new ArgumentNullException(nameof(list));
            // Проверка на не пустой массив индексов
            if (indexes == null) throw new ArgumentNullException(nameof(indexes));

            // Конвертирование списка значений в массив
            var array = list as T[] ?? list.ToArray();

            // Проверка на допустимые индексы по отношению к размеру массива
            if (indexes.Any(x => x < 0) || indexes.Max() > array.Length - 1) throw new DataException(nameof(indexes));

            for (var i = 0; i < array.Length; i++)
            {
                if (indexes.Contains(i)) continue;
                yield return array[i];
            }
        }
    }
}
