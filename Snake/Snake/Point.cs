﻿using System;
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

        //Конструктор из точки
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
                x = x + offset;
            else if (direction == Direction.LEFT)
                x = x - offset;
            else if (direction == Direction.UP)
                y = y - offset;
            else if (direction == Direction.DOWN)
                y = y + offset;
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }

        //затереть точку на экране
        public void Clear()
        {
            char savesym = sym;
            sym = ' ';
            Draw();
            sym = savesym;
        }

        //проверка совпадения точек
        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }
}
