using System;
using System.Collections.Generic;
using System.Text;

namespace maze
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public override string ToString()
        {
            return $"[{X}], [{Y}], [{Symbol}]";
        }
    }
}
