using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;  //направление движения

        //положение задается положением хвоста
        //direction - направление движения 
        public Snake(Point tail, int lenght, Direction _direction)
        {
            pList = new List<Point>();
            direction = _direction;

            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        public void Move()
        {
            //удалить последнюю точку в хвосте
            Point tail = pList.First<Point>();
            pList.Remove(tail);
            //новая точка в голове
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last<Point>();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        //голова не наехала на хвост
        internal bool IsHitTail()
        {
            var head = pList.Last<Point>();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        //обработка нажатия клавиши
        public void HandleKey(ConsoleKey key)
        {
                if (key == ConsoleKey.LeftArrow)
                   direction = Direction.LEFT;
                else if(key == ConsoleKey.RightArrow)
                   direction = Direction.RIGHT;
                else if (key == ConsoleKey.DownArrow)
                   direction = Direction.DOWN;
                else if (key == ConsoleKey.UpArrow)
                   direction = Direction.UP;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if(head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);   //змейка удлиняется
                food.Draw();   //перересовываем
                return true;
            }
            else
                return false;
        }
    }
}
