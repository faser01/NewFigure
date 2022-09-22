using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFigure
{
    public abstract class GeoFigure
    {

        public double _perimeter { get; set; }  // периметр фигуры
        public double Square { get; set; }     // площадь фигуры
        public string _figure { get; set; }  // стринга для названия
        public double _height { get; set; } // высота фигуры  // прописываю в конструкторе другой фигуры

        public const double pi = 3.14;
        public GeoFigure(string figure)
        {
            _figure = figure;
        }




        // абстрактный метод для получения периметра
        public abstract double Perimeter();
        // абстрактный метод для получения площади
        public abstract double Area();

        public void PrintFigure()
        {
            Console.WriteLine($" Площадь {_figure}а {Area()} см2 \n Периметр {_figure}а {Perimeter()} см \n");
        }

        public virtual void Print()
        {
            Console.WriteLine($" Площадь фигуры {Area()} см2 \n Периметр фигуры {Perimeter()} см ");
        }
    }
}
