using System;

namespace maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new MazeBuilder();
            var maze = builder.Build(3,3);


            var drawer = new Drawer();
            drawer.DrawMaze(maze);


        
        }
    }
}
