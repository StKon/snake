﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        //Набор точек
        protected List<Point> pList;

        //Вывод на экран
        public virtual void Drow()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}
