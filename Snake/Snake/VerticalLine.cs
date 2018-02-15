using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine
    {
        //Набор точек
        List<Point> pList;

        public VerticalLine(int x, int yTop, int yBotton, char sym)
        {
            pList = new List<Point>();
            for (int y = yTop; y <= yBotton; y++)
            {
                pList.Add(new Point(x, y, sym));
            }
        }

        //Вывод на экран
        public void Drow()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

    }
}
