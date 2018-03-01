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

            Walls walls = new Walls(80, 25);
            walls.Draw();

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
                if (walls.IsHit(snake) || snake.IsHitTail())  //змейка столкнулась с рамкой или собственным хвостом
                {
                    break;
                }

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
