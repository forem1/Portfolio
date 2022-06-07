using GMap.NET;
using System;
using System.IO;

namespace PlatformDesktop.Models
{


    public class Point
    {
       // просто делегаты (анонимные функции), которые задают шаблон методу события,
       
        public delegate void SetXEventHandler(double x);

        public delegate void SetXYEventHandler(double x, double y, double oldX, double oldY);

        public delegate void SetYEventHandler(double y);

        /// <summary>
        ///     Координата Lat (Latitude)
        /// </summary>
        private double _x;

        /// <summary>
        ///     Координата Lon (Longitude)
        /// </summary>
        private double _y;

        /// <summary>
        ///     Обычный конструктор
        /// </summary>
        /// <param name="x">Координата Lat (Latitude)</param>
        /// <param name="y">Координата Lon (Longitude)</param>
        /// <exception cref="InvalidDataException">
        ///     Ошибка: Недопустимое значение широты (Значение должно находиться в: -90 <= x <= 90)</exception>
        /// <exception cref="InvalidDataException">
        ///     Ошибка: Недопустимое значение долготы (Значение должно находиться в: -180 <= y <= 180)</exception>
        public Point(double x = 0d, double y = 0d)
        {
            // Проверка на допустимое значение широты (lat)
            if (x is < -90 or > 90)
                throw new InvalidDataException(
                    "Ошибка: Недопустимое значение широты (Значение должно находиться в: -90 <= x <= 90).");

            // Проверка на допустимое значение долготы (long)
            if (y is < -180 or > 180)
                throw new InvalidDataException(
                    "Ошибка: Недопустимое значение долготы (Значение должно находиться в: -180 <= y <= 180).");

            // Обычный кортеж
            (_x, _y) = (x, y);
        }

        /// <summary>
        ///     Координата Lat (Latitude)
        /// </summary>
        /// <exception cref="InvalidDataException">
        ///     Ошибка: Недопустимое значение широты (Значение должно находиться в: -90 <= x <= 90)</exception>
        public double X
        {
            get => _x;
            set
            {
                // Проверка на допустимое значение широты (lat)
                if (value is < -90 or > 90)
                    throw new InvalidDataException(
                        "Ошибка: Недопустимое значение широты (Значение должно находиться в: -90 <= x <= 90).");

                _x = value;

                // Вызов события
                SetX?.Invoke(value);
            }
        }

        /// <summary>
        ///     Координата Lon (Longitude)
        /// </summary>
        /// <exception cref="InvalidDataException">
        ///     Ошибка: Недопустимое значение долготы (Значение должно находиться в: -180<=y<=180)</exception>
        public double Y
        {
            get => _y;
            set
            {
                // Проверка на допустимое значение долготы (long)
                if (value is < -180 or > 180)
                    throw new InvalidDataException(
                        "Ошибка: Недопустимое значение долготы (Значение должно находиться в: -180<=y<=180)");

                _y = value;

                // Вызов события
                SetY?.Invoke(value);
            }
        }

        /// <summary>
        ///     Установка значения
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public void SetValue(double x, double y)
        {
            // Вызов события
            SetXY?.Invoke(x, y, X, Y);

            // Обычный кортеж
            (X, Y) = (x, y);
        }

        /// <summary>
        ///     Установка значения
        /// </summary>
        /// <param name="point">Значение</param>
        public void SetValue(Point? point)
        {
            // Приходит значение null, значит и менять нечего
            if (point is null) return;

            // Вызов события
            SetXY?.Invoke(point.X, point.Y, X, Y);

            // Обычные кортежи
            (X, Y) = (point.X, point.Y);
        }

        /// <summary>
        ///     Получение данных
        /// </summary>
        /// <param name="x">Координата Lat (Latitude)</param>
        /// <param name="y">Координата Lon (Longitude)</param>
        public void Deconstruct(out double x, out double y)
        {
            // Обычные кортежи
            (x, y) = (_x, _y);
        }

        /// <summary>
        ///     Получить PointLatLng необходимый для установки значения местоположения маркеру
        /// </summary>
        /// <returns>PointLatLng</returns>
        public PointLatLng GetPointLatLng()
        {
            return new PointLatLng(X, Y);
        }

        /// <summary>
        ///     Проверка на равное значение координат
        /// </summary>
        /// <param name="obj">Значение с которым идет сравнение координат</param>
        /// <returns></returns>
        public bool Equals(Point obj)
        {
            // Сравнение с точностью до шестого символа, (0.000001)
            return Math.Abs(X - obj.X) < 0.000001 && Math.Abs(Y - obj.Y) < 0.000001;
        }

        /// <summary>
        ///     Событие изменение X
        /// </summary>
        public event SetXEventHandler SetX;

        /// <summary>
        ///     Событие изменения Y
        /// </summary>
        public event SetYEventHandler SetY;

        /// <summary>
        ///     Событие изменения X и/или Y
        /// </summary>
        public event SetXYEventHandler SetXY;
    }
}