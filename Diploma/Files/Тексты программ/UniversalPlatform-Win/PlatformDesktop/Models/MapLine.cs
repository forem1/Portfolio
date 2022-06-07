using System;
using System.IO;
using System.Windows.Media;
using GMap.NET.WindowsPresentation;
using PlatformDesktop.Models;
using Path = System.Windows.Shapes.Path;

namespace WPFMap.Models
{ 

/// <summary>
///     Класс линии
/// </summary>
public class MapLine
{
    /// <summary>
    ///     Конструктор линии
    /// </summary>
    /// <param name="startMapPoint">Начальная позиция</param>
    /// <param name="endMapPoint">Конечная позиция</param>
    /// <param name="brush">Цвет линии (<see cref="Brushes.Red" />)</param>
    /// <param name="thickness">Толщина линии (
    ///     <value>1.5</value>
    ///     )
    /// </param>
    public MapLine(Point startMapPoint, Point endMapPoint, Brush? brush = null, double? thickness = null)
    {
        (StartMapPoint, EndMapPoint) = (startMapPoint, endMapPoint);

        // Проверка, указаны ли значения для стартовой и конечной точки линии одинаковые координаты
        if (startMapPoint.Equals(endMapPoint))
            throw new InvalidDataException("Ошибка: Недопустимое совпадение значений начальной и конечной координаты.");

        // Проверка на допустимое значение толщины линии
        if (thickness is < 0.0d)
        throw new InvalidDataException("Ошибка: Недопустимое значение толщины линии.");

        if (thickness is not null)
            Thickness = (double) thickness;
        if (brush is not null)
            Brush = (Brush) brush;
    }

    /// <summary>
    ///     Начальная точка прямой
    /// </summary>
    public Point StartMapPoint { get; set; }

    /// <summary>
    ///     Конечная точка прямой
    /// </summary>
    public Point EndMapPoint { get; set; }

    /// <summary>
    ///     Цвет линии 
    /// </summary>
    public Brush Brush { get; set; } = Brushes.Red;

    /// <summary>
    ///     Толщина (По умолчанию
    ///     <value>1.5</value>
    ///     )
    /// </summary>
    public double Thickness { get; set; } = 1.5d;
}

    /// <summary>
    ///     Класс методов
    /// </summary>
    public static class Methods
    {
        /// <summary>
        ///     Нарисовать линию
        /// </summary>
        /// <param name="map">Элемент управления картой</param>
        /// <param name="mapLine">Линия</param>
        /// <exception cref="ArgumentNullException">Ошибка: Не были указаны либо стартовая либо/и конечная позиция линии</exception>
        /// <exception cref="InvalidDataException">Ошибка: Недопустимое совпадение значений начальной и конечной координаты</exception>
        /// <exception cref="InvalidDataException">Ошибка: Недопустимое значение толщины линии.</exception>
        public static void DrawLine(this GMapControl map, MapLine mapLine)
        {
            // Проверка, указаны ли начальная и конечная точка линии
            if (mapLine.StartMapPoint == default! || mapLine.EndMapPoint == default!)
                throw new ArgumentNullException("Ошибка: Не были указаны либо стартовая либо/и конечная позиция линии.");

            // Проверка, указаны ли значения для стартовой и конечной точки линии одинаковые координаты
            if (mapLine.StartMapPoint.Equals(mapLine.EndMapPoint))
                throw new InvalidDataException("Ошибка: Недопустимое совпадение значений начальной и конечной координаты.");

            // Проверка на допустимое значение толщины линии
            if (mapLine.Thickness < 0.0d)
                throw new InvalidDataException("Ошибка: Недопустимое значение толщины линии.");

            // Начальная точка
            var start = mapLine.StartMapPoint.GetPointLatLng();
            // Конечная точка 
            var end = mapLine.EndMapPoint.GetPointLatLng();
            // Создание маршрута (полигона)
            var polygon = new GMapPolygon(new[] { start, end });
            // Генерация полигона
            map.RegenerateShape(polygon);
            // Задание цвета прямой
            (polygon.Shape as Path)!.Stroke = mapLine.Brush;
            // Задание ширины прямой
            (polygon.Shape as Path)!.StrokeThickness = mapLine.Thickness;
            // Добавление линии на карту
            map.Markers.Add(polygon);
        }
    }
}