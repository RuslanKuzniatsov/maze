using System;
using System.Collections.Generic;
using System.Text;

namespace maze
{
    public class MazeBuilder
    {
        public MazeLevel Build(int width = 5, int height = 5)
        {
            var mazeLevel = new MazeLevel();
            mazeLevel.Width = width;
            mazeLevel.Height = height;
            mazeLevel.Cells = new List<Cell>();

            for (int y = 0; y < mazeLevel.Height; y++)
            {
                for (int x = 0; x < mazeLevel.Width; x++)
                {
                    var cell = new Cell()
                    {
                        X = x,
                        Y = y,
                        Color = ConsoleColor.Green,
                        Symbol = '#',
                    };
                    mazeLevel.Cells.Add(cell);

                }
                
            }

            return mazeLevel;
        }
    }
}
