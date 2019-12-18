using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // * = Mine
            // | = Empty
            // ? = Unknown (Player Only)

            // Initialise/Declare variables needed
            Random rnd = new Random();
            int mines = 0;
            bool gameOver = false;
            int rowInput;
            int columnInput;
            int mineCount = 0;

            string[,] mineField = new string[6, 6];
            string[,] userField = new string[6, 6];

            // Minimum of 8 mines on map
            while (mines < 8)
            {
                for (int row = 0; row < 6; row++)
                {
                    // Randomly place mines along the map

                    for (int column = 0; column < 6; column++)
                    {
                        userField[row, column] = "?";

                        // Fifth chance of a mine
                        if (rnd.Next(1, 6) == 5)
                        {
                            mineField[row, column] = "*";
                            mines++;
                        }

                        // Indicates it as empty
                        else
                        {
                            mineField[row, column] = "|";
                        }

                        Console.Write(mineField[row, column]);

                    }

                    Console.WriteLine("\n");

                }


            }

            // Welcoming Message for First Play

            Console.WriteLine("Welcome to Minesweeper!");

            // Loop until win/loss condition is met
            while (!gameOver)
            {
                // Gain user input once game has started

                Console.WriteLine("Please input a row number (0-5):");
                rowInput = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Please input a column number (0-5):");
                columnInput = Int32.Parse(Console.ReadLine());

                // Loss condition activates and game is over
                if (mineField[rowInput, columnInput] == "*")
                {

                    Console.WriteLine("You just hit a mine! You lose!");
                    gameOver = true;

                }

                // Must have hit an empty space
                else
                {
                    // If the value is the top line, but not the corners
                    if (columnInput == 0 && rowInput != 0 && rowInput != 5)
                    {
                        for (int row = rowInput - 1; row < rowInput + 1; row++)
                        {
                            for (int column = 0; column < 2; column++)
                            {
                                if (mineField[row, column] == "*")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is the bottom line, but not the corners
                    else if (columnInput == 5 && rowInput != 0 && rowInput != 5)
                    {
                        for (int row = rowInput - 1; row < rowInput + 1; row++)
                        {

                            for (int column = 4; column < 6; column++)
                            {

                                if (mineField[row, column] == "*")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is the left line, but not the corners
                    else if (rowInput == 0 && columnInput != 0 && columnInput != 5)
                    {
                        for (int row = 0; row < 2; row++)
                        {
                            for (int column = columnInput - 1; column < columnInput + 1; column++)
                            {

                                if (mineField[row, column] == "*")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is the right line, but not the corners
                    else if (rowInput == 5 && columnInput != 0 && columnInput != 5)
                    {
                        for (int row = 4; row < 6; row++)
                        {
                            for (int column = columnInput - 1; column < column + 1; column++)
                            {

                                if (mineField[row, column] == "Q")
                                {

                                    mineCount++;

                                }

                            }

                        }


                    }

                    // If the value is the top left corner
                    else if (rowInput == 0 && columnInput == 0)
                    {
                        // Search the 3 closest boxes for mines
                        for (int row = 0; row < 2; row++)
                        {
                            for (int column = 0; column < 2; column++)
                            {
                                // Keep track of nearby mines
                                if (mineField[row, column] == "*")
                                {

                                    mineCount ++;

                                }
                            }
                        }
                    }

                    // If the value is the top right corner
                    else if (rowInput == 5 && columnInput == 0)
                    {
                        // Search 3 closest boxes
                        for (int row = 4; row < 6; row++)
                        {
                            for (int column = 0; column < 2; column++)
                            {
                                if (mineField[row, column] == "*")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is the bottom left corner
                    else if (rowInput == 0 && columnInput == 5)
                    {
                        for (int row = 0; row < 2; row++)
                        {
                            for (int column = 0; column < 6; column++)
                            {

                                if (mineField[row, column] == "*")
                                {

                                    mineCount++;

                                }

                            }
                        }
                    }

                    // If the value is the bottom right corner
                    else if (rowInput == 5 && columnInput == 5)
                    {

                        for (int row = 4; row < 6;  row++)
                        {

                            for (int column = 4; column < 6; column++)
                            {

                                if (mineField[row, column] == "*")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    else
                    {



                    }

                    // Change what the user sees to compensate
                    userField[rowInput, columnInput] = mineCount.ToString();
                    Console.Clear();

                    for (int row = 0; row < 6; row++)
                    {
                        for (int column = 0; column < 6; column++)
                        {

                            Console.Write(userField[row, column]);

                        }

                        Console.WriteLine("\n");

                    }

                }

            }

            Console.ReadKey();

        }
    }
}
