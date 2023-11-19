using System;

namespace maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new MazeBuilder();
            var maze = builder.Build(6,6);


            var drawer = new Drawer();
            drawer.DrawMaze(maze);


        
        }
    }
}
