using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        { }


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(maze, xStart, yStart);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary> 
        private void mazeTraversal(char[,] maze, int xStart, int yStart)
        {
            int newX;
            int newY;

            newX = xStart;
            newY = yStart;


            this.printMaze(maze);
            Console.ReadLine();
            Console.Clear();

            //Implement maze traversal recursive call
            // Base case
           // if (CanMove(maze, xStart, yStart) == false)
           //     Console.WriteLine("Test");
            if (CanMove(maze, xStart, yStart + 1))
            {
                if (maze[xStart, yStart] == 'X')
                    maze[xStart, yStart] = 'O';
                else
                    maze[xStart, yStart] = 'X';

                mazeTraversal(maze, xStart, yStart + 1); // move up
            }
            if (CanMove(maze, xStart, yStart - 1))
            {
                if (maze[xStart, yStart] == 'X')
                    maze[xStart, yStart] = 'O';
                else
                    maze[xStart, yStart] = 'X';

                mazeTraversal(maze, xStart, yStart - 1); // move down
            }
            if (CanMove(maze, xStart + 1, yStart))
            {
                if (maze[xStart, yStart] == 'X')
                    maze[xStart, yStart] = 'O';
                else
                    maze[xStart, yStart] = 'X';

                mazeTraversal(maze, xStart + 1, yStart); // move right
            }
            if (CanMove(maze, xStart - 1, yStart))
            {
                if (maze[xStart, yStart] == 'X')
                    maze[xStart, yStart] = 'O';
                else
                    maze[xStart, yStart] = 'X';

                mazeTraversal(maze, xStart - 1, yStart); // move left
            }
        }

        // Checks to see if the next move is legal by making sure that 
        // the next "tile" is a dot and not the maze wall "#"
        private bool CanMove(char[,] maze, int startX, int startY)
        {
            bool rangeBool = false;

            if (startX >= 12 || startX < 0 || startY >= 12 || startY < 0)
                rangeBool = true;

            if (rangeBool == false && maze[startX, startY] == '.')
                return true;
            else
                return false;

        }


        // PRINT OUT THE MAZE ********************************
        public void printMaze(char[,] maze)
        {
            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 12; col++)
                {
                    if (col < 11)
                        Console.Write("{0}", maze[row, col]);
                    else
                        Console.WriteLine("{0}", maze[row, col]);
                }
            }
        }
    }
}
