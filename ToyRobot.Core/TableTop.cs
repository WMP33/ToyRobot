using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Core
{
    public class TableTop :ITableTop
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public TableTop(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
