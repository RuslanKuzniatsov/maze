using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maze
{
    public class Drawer
    {
        public void DrawMaze(MazeLevel mazeLevel)
        {
            Console.Clear();
            for (int yIndex = 0; yIndex< mazeLevel.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex< mazeLevel.Width; xIndex++)
                {


                    var cell = mazeLevel.Cells.First(Cell => Cell.X == xIndex && Cell.Y == yIndex);
                    
                    var oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = cell.Color;
                    Console.Write(cell.Symbol);
                    Console.ForegroundColor = oldColor;

                }
                Console.WriteLine();
            }
        }
    }
}
