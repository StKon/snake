using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        //Вывод точки
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        //Конструктор без аргументов
        public Point()
        {
        }

        //Конструктор с аргументами
        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }
    }
}
