using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine : Figure  //Наследник Figure
    {
        public VerticalLine(int yTop, int yBotton, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yTop; y <= yBotton; y++)
            {
                pList.Add(new Point(x, y, sym));
            }
        }
    }
}
