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
        bool solved = false;

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

            if (!solved) // if the maze isn't solved, place x at current position, print,
                // and get enter stroke and clear the maze
            {
                maze[xStart, yStart] = 'X';
                this.printMaze(maze);
                Console.ReadLine();
                Console.Clear();

            }

            isEnd(maze, xStart, yStart); // Check to see if it's the end of the maze


                //Implement maze traversal recursive call
                // Base case
                if (!solved && CanMove(maze, xStart, yStart + 1)) // If you can move up
                {
                    mazeTraversal(maze, xStart, yStart + 1); // move up 
                }
                if (!solved && CanMove(maze, xStart, yStart - 1))// If you can move down
                {
                    mazeTraversal(maze, xStart, yStart - 1); // move down
                }
                if (!solved && CanMove(maze, xStart + 1, yStart))// If you can move right
                {
                    mazeTraversal(maze, xStart + 1, yStart); // move right
                }
                if (!solved && CanMove(maze, xStart - 1, yStart))// If you can move left
                {
                    mazeTraversal(maze, xStart - 1, yStart); // move left
                }

            if (!solved) // If the maze isn't solved, replace the X with an O
            {
                if (maze[xStart, yStart] == 'X')
                    maze[xStart, yStart] = 'O';

                this.printMaze(maze);
                Console.ReadLine();
                Console.Clear();

            
            }

        }

        // Checks to see if the next move is legal by making sure that 
        // the next "tile" is a dot and not the maze wall "#"
        private bool CanMove(char[,] maze, int xStart, int yStart)
        {

                if (maze[xStart, yStart] == '.') // if the next move is a period
                {
                    return true;
                }
                else
                    return false;
                
        }

        // Checks to see if the move is within the maze
        void isEnd(char[,] maze, int xStart, int yStart)
        {
            if (xStart == maze.GetLength(0) - 1 || xStart == 0 || yStart == maze.GetLength(1) - 1 || yStart == 0) // if the move is within the maze
            {
                solved = true;
            }
            else
            {
                solved = false;
            }
                
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
