using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);

            HorizontalLine hl = new HorizontalLine(0, 78, 24, '+');
            VerticalLine vl = new VerticalLine(0, 24, 0, '+');
            Point p1 = new Point(4, 5, '*');
            Figure fsnake = new Snake(p1, 4, Direction.RIGHT);
            Snake sn = (Snake)fsnake;
            
            List<Figure> figures = new List<Figure>();
            figures.Add(hl);
            figures.Add(vl);
            figures.Add(sn);
            foreach (Figure f in figures)
            {
                f.Drow();
                //Console.WriteLine(f.GetType().ToString());

            }
            Console.ReadKey();
            return;

            //отрисовать рамку
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

            //отрисовать змейку
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            //Еда
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            //Обработка нажатия клавиш
            while (true)  //бесконечный цикл
            {
                if(snake.Eat(food))  //еда
                {
                    food = foodCreator.CreateFood();  //съели еду. Появляется новая еда
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(200);  //задержка 200 млсек

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}
