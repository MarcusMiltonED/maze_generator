using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            // Hello
            // Some variables:
            int nodesWidth = 42;
            int coordsWidth = 2 * nodesWidth + 1;
            int nodesHeight = 26;
            int coordsHeight = 2 * nodesHeight + 1;
            int iterations = nodesWidth * nodesHeight * 15;
            char dir;
            char newDir;
            int possibleDirLength;
            int oX = nodesWidth - 1;
            int oY = nodesHeight - 1;

            // Some arrays:        
            int[,] coords = new int[coordsWidth, coordsHeight];
            char[,] nodes = new char[nodesWidth, nodesHeight];
            char[] possibleDir = new char[4];


            // nodes array setup
            for (int y = 0; y < nodesHeight; y++)
            {
                for (int x = 0; x < nodesWidth; x++)
                {
                    if (x < nodesWidth - 1)
                    {
                        nodes[x, y] = 'd';
                    }
                    else
                    {
                        nodes[x, y] = 's';
                    }
                }
            }
            nodes[oX, oY] = 'o';

            // Randomizes the maze
            for (int i = 0; i < iterations; i++)
            {

                // Sets up all possible directions, use possibleDirLength for parameter in random method later
                /**
                 * 'w' is up
                 * 'a' is left
                 * 's' is down
                 * 'd' is right
                 */
                possibleDirLength = 0;
                if (oY > 0)
                {
                    possibleDir[possibleDirLength] = 'w';
                    possibleDirLength++;
                }
                if (oX > 0)
                {
                    possibleDir[possibleDirLength] = 'a';
                    possibleDirLength++;
                }
                if (oY < nodesHeight - 1)
                {
                    possibleDir[possibleDirLength] = 's';
                    possibleDirLength++;
                }
                if (oX < nodesWidth - 1)
                {
                    possibleDir[possibleDirLength] = 'd';
                    possibleDirLength++;
                }

                // Randomize the new direction newDir
                newDir = possibleDir[random.Next(0, possibleDirLength)];
                //Console.WriteLine(newDir);

                // Points the old origin point to the new origin point
                nodes[oX, oY] = newDir;

                // Assigns the new origin point
                switch (newDir)
                {
                    case ('w'):
                        oY--;
                        break;
                    case ('a'):
                        oX--;
                        break;
                    case ('s'):
                        oY++;
                        break;
                    case ('d'):
                        oX++;
                        break;
                    default:
                        Console.WriteLine("Error, the new origin point couldn't hava anew direction set!");
                        break;
                }
                nodes[oX, oY] = 'o';
            }

            // coordinates array setup
            for (int y = 0; y < coordsHeight; y++)
            {
                for (int x = 0; x < coordsWidth; x++)
                {
                    if (y == 0 || y == coordsWidth - 1)
                    {
                        coords[x, y] = 5;
                    }
                    else if (x == 0 || x == coordsWidth - 1)
                    {
                        coords[x, y] = 5;
                    }
                    else if(Math.Floor(x/2.0) == x/2.0 && Math.Floor(y/2.0) != y/2.0)
                    {
                        coords[x, y] = 5;
                    }
                    else if(Math.Floor(y/2.0) == y / 2.0)
                    {
                        coords[x, y] = 5;
                    }

                }
            }

            // Seperate loop for nodes to coords setup
            for(int y = 0; y < nodesHeight; y++)
            {
                //Console.Write("{");
                for(int x = 0; x < nodesWidth; x++)
                {
                    
                    switch(nodes[x, y])
                    {
                        case ('w'):
                            coords[2 * x + 1, 2 * y + 1 - 1] = 0;
                            break;
                        case ('a'):
                            coords[2 * x + 1 - 1, 2 * y + 1] = 0;
                            break;
                        case ('s'):
                            coords[2 * x + 1, 2 * y + 1 + 1] = 0;
                            break;
                        case ('d'):
                            coords[2 * x + 1 + 1, 2 * y + 1] = 0;
                            break;
                    }
                    
                    //Console.Write($"{nodes[x, y]}, ");
                }
                //Console.WriteLine("}");
            }

            for (int y = 0; y < coordsHeight; y++)
            {
                for (int x = 0; x < coordsWidth; x++)
                {
                    Console.Write("{0} ", coords[x, y] == 5 ? "X"/* : (Math.Floor(x/2.0) != x/2.0 && Math.Floor(y/2.0) != y/2.0) ? nodes[((x-1)/2), ((y-1)/2)].ToString() */: " ");
                }
                Console.WriteLine();
            }
        }
    }
}
