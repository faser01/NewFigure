using System;
using System.IO;
namespace AbstractGeoFigure
{
    abstract class GeoFigure
    {
        private string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public abstract decimal Square();
        public abstract decimal Perimeter();

    }
    class Rectangle : GeoFigure
    {
        public Rectangle()
        {
            name = "Прямоугольник";
            Console.Write("Введите длину: ");
            Lengh = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Введите ширину: ");
            Heigth = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();
        }
        public override decimal Square()
        {
            decimal _square = this.lengh * this.heigth;
            return _square;
        }
        public override decimal Perimeter()
        {
            decimal _perimeter = this.lengh + this.lengh + this.heigth + this.heigth;
            return _perimeter;
        }
        private decimal Lengh;

        public decimal lengh
        {
            get { return Lengh; }
            set { Lengh = value; }
        }
        private decimal Heigth;

        public decimal heigth
        {
            get { return Heigth; }
            set { Heigth = value; }
        }
    }





    class Romb : GeoFigure
    {
        public Romb()
        {
            name = "Ромб";
            Console.Write("Введите 1-ую Диагональ: ");
            A = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Введите 2-ую Диагональ: ");
            B = Convert.ToDecimal(Console.ReadLine());

        }
        private decimal A;

        public decimal a
        {
            get { return A; }
            set { A = value; }
        }
        private decimal B;

        public decimal b
        {
            get { return B; }
            set { B = value; }
        }


        public override decimal Square()
        {
            return b * a / 2;
        }
        public override decimal Perimeter()
        {
            return 4 * a;
        }
    }

    class createFigure
    {
        private int number, count = 0;
        private GeoFigure[] Array;
        private string request;
        private bool Correcten;


        private int Request()
        {
            do
            {
                Console.Write("Сколько  хотите создать фигур?:\n");
                request = Console.ReadLine();
                Correcten = Int32.TryParse(request, out int res);
                if (Correcten)
                {
                    number = Convert.ToInt32(request);
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз: ");
                    Correcten = false;
                }
            } while (Correcten == false);
            return number;
        }
        private GeoFigure[] CreateFigure()
        {
            int param = 0;
            number = Request();
            Console.WriteLine();
            Array = new GeoFigure[number];
            do
            {
                Console.WriteLine("Какую фигуру хотите создать?:\n" +
                    "1 - Прямоугольник\n" +
                    "2 - Ромб\n");
                   

                Console.Write("Ввод -> ");
                param = Convert.ToInt32(Console.ReadLine());

                switch (param)
                {
                    case 1:
                        Rectangle Rectangle = new Rectangle();
                        Array[count] = Rectangle;
                        count++;
                        break;

                    case 2:
                        Romb Romb = new Romb();
                        Array[count] = Romb;
                        count++;
                        break;
                }

            } while (count < number);

            return Array;
        }


        public void PrintFigure()
        {
            Array = CreateFigure();
            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine("{0}) {1} -> площадь - {2} и периметр - {3} ",
                    i + 1, Array[i].name, Array[i].Square(), Array[i].Perimeter());
                Console.WriteLine("Сохранить результат в файл? (Y) - (N)");
                string answer = Console.ReadLine();
                if (answer == "Y" | answer == "y")
                {
                    StreamWriter file = new StreamWriter("Log.txt", true);
                    file.WriteLine(Array[i].name);
                    file.WriteLine(" площадь - " + Array[i].Square());
                    file.WriteLine("периметр - " + Array[i].Perimeter());
                    file.Close();

                    Console.WriteLine("Информация добавлена в файл .");
                    if (answer == "N" | answer == "n")
                    {
                        return;

                    }
                    Console.ReadLine();

                }
            }

        }

        class Program
        {
            static void Main(string[] args)
            {
                createFigure Figure = new createFigure();
                Figure.PrintFigure();


            }
        }
    }
}