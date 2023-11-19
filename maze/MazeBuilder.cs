using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace maze
{
    public class MazeBuilder
    {
        public const char Wall = '#';
        public const char Ground = '_';
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
                        Symbol = Wall,
                    };
                    mazeLevel.Cells.Add(cell);

                }        
               
            }


            var drawer = new Drawer();    //for draw in console



            var coreCell = mazeLevel
                .Cells
                .Where(cell => cell.X != 0 
                    && cell.X != mazeLevel.Width-1 
                    && cell.Y != 0 
                    && cell.Y != mazeLevel.Height-1)
                .ToList();

            
            var redMinerCell = GetRandom(coreCell);
            redMinerCell.Symbol = Ground;


            var blueWallCanBreak = new List<Cell>();

            do
            {
                drawer.DrawMaze(mazeLevel); //for draw in console
                Thread.Sleep(200);    //for draw in console
                

                var nearWalls = GetNearCell(mazeLevel.Cells, redMinerCell, Wall);


                blueWallCanBreak.AddRange(nearWalls);
                blueWallCanBreak.ForEach(x => x.Color = ConsoleColor.Blue);

                blueWallCanBreak = blueWallCanBreak
                    .Where(cell => GetNearCell(mazeLevel.Cells, cell, Ground).Count < 2).ToList();


                var wallToBreak = GetRandom(blueWallCanBreak);
                wallToBreak.Symbol = Ground;


                redMinerCell = wallToBreak;

                blueWallCanBreak.Remove(wallToBreak);
                blueWallCanBreak = blueWallCanBreak
                    .Where(cell => GetNearCell(mazeLevel.Cells, cell, Ground).Count < 2).ToList();
                
            } while(blueWallCanBreak.Any());

            

            return mazeLevel;

        }


        private List<Cell> GetNearCell(List<Cell> allCells, Cell currentCell, char cellSymbol)
        {
            var nearCells = allCells
                .Where(cell => cell.X == currentCell.X
                    && Math.Abs(cell.Y - currentCell.Y) == 1
                    || cell.Y == currentCell.Y
                    && Math.Abs(cell.X - currentCell.X) == 1)
                .Where(cell => cell.Symbol == cellSymbol);
            return nearCells.ToList();
        }
        private Cell GetRandom(List<Cell> cells)
        {
            var random = new Random();
            var randomIndex = random.Next(0, cells.Count);
            return cells[randomIndex];
            

        }
    }
}
