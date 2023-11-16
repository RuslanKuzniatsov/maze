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
            for (int yIndex = 0; yIndex< mazeLevel.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex< mazeLevel.Width; xIndex++)
                {
                    for (int i = 0; i < mazeLevel.Cells.Count; i++)
                    {
                        var cell = mazeLevel.Cells[i];
                        if (cell.X == xIndex && cell.Y == yIndex)
                        {
                            var oldColor = Console.ForegroundColor;
                            Console.ForegroundColor = cell.Color;
                            Console.Write(cell.Symbol);

                            Console.ForegroundColor = oldColor;
                        }
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
