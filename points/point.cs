using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mrowki.points
{
    public class point
    {
        private int X;
        private int Y;
        public point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public string GetData()
        {
            return string.Format($"{this.X},{this.Y}");
        }
    }
}
